using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace Razorpay.Api.Http
{
    // Minimal HTTP/1.1 response parser for the managed TLS transport.
    // Requests are sent with "Connection: close", so one response is read per connection.
    internal static class HttpResponseReader
    {
        private const int MaxLineBytes = 16 * 1024;
        private const int MaxBodyBytes = 32 * 1024 * 1024;

        public static HttpResult Read(Stream stream)
        {
            while (true)
            {
                Dictionary<string, string> headers;
                int statusCode = ReadHead(stream, out headers);

                // Skip interim responses such as "100 Continue".
                if (statusCode < 200)
                {
                    continue;
                }

                return new HttpResult(statusCode, Encoding.UTF8.GetString(ReadBody(stream, headers)));
            }
        }

        // Reads the status line and headers, leaving the stream positioned at the body.
        public static int ReadHead(Stream stream, out Dictionary<string, string> headers)
        {
            string statusLine = ReadLine(stream);
            if (statusLine == null)
            {
                throw new IOException("Connection closed before an HTTP response was received");
            }

            string[] parts = statusLine.Split(new[] { ' ' }, 3);
            int statusCode;
            if (parts.Length < 2
                || !parts[0].StartsWith("HTTP/1.", StringComparison.Ordinal)
                || parts[1].Length != 3
                || !int.TryParse(parts[1], NumberStyles.None, CultureInfo.InvariantCulture, out statusCode))
            {
                throw new IOException("Malformed HTTP status line");
            }

            headers = ReadHeaders(stream);
            return statusCode;
        }

        private static Dictionary<string, string> ReadHeaders(Stream stream)
        {
            Dictionary<string, string> headers = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            string line;
            while ((line = ReadLine(stream)) != string.Empty)
            {
                if (line == null)
                {
                    throw new IOException("Connection closed while reading HTTP headers");
                }

                int colon = line.IndexOf(':');
                if (colon <= 0)
                {
                    throw new IOException("Malformed HTTP header");
                }

                headers[line.Substring(0, colon).Trim()] = line.Substring(colon + 1).Trim();
            }
            return headers;
        }

        private static byte[] ReadBody(Stream stream, Dictionary<string, string> headers)
        {
            string value;
            if (headers.TryGetValue("Transfer-Encoding", out value)
                && value.IndexOf("chunked", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                return ReadChunked(stream);
            }

            if (headers.TryGetValue("Content-Length", out value))
            {
                long length;
                if (!long.TryParse(value, NumberStyles.None, CultureInfo.InvariantCulture, out length) || length > MaxBodyBytes)
                {
                    throw new IOException("Invalid HTTP Content-Length");
                }
                return ReadExactly(stream, (int)length);
            }

            return ReadToEnd(stream);
        }

        private static byte[] ReadChunked(Stream stream)
        {
            using (MemoryStream body = new MemoryStream())
            {
                while (true)
                {
                    string sizeLine = ReadLine(stream);
                    if (sizeLine == null)
                    {
                        throw new IOException("Connection closed while reading chunked body");
                    }

                    int extension = sizeLine.IndexOf(';');
                    string sizeText = (extension >= 0 ? sizeLine.Substring(0, extension) : sizeLine).Trim();
                    int size;
                    if (!int.TryParse(sizeText, NumberStyles.AllowHexSpecifier, CultureInfo.InvariantCulture, out size)
                        || size < 0 || body.Length + size > MaxBodyBytes)
                    {
                        throw new IOException("Invalid HTTP chunk size");
                    }

                    if (size == 0)
                    {
                        ReadHeaders(stream); // trailers
                        return body.ToArray();
                    }

                    byte[] chunk = ReadExactly(stream, size);
                    body.Write(chunk, 0, chunk.Length);

                    if (ReadLine(stream) != string.Empty)
                    {
                        throw new IOException("Malformed HTTP chunk terminator");
                    }
                }
            }
        }

        private static byte[] ReadExactly(Stream stream, int length)
        {
            byte[] buffer = new byte[length];
            int offset = 0;
            while (offset < length)
            {
                int read = stream.Read(buffer, offset, length - offset);
                if (read <= 0)
                {
                    throw new IOException("Connection closed before the full HTTP body was received");
                }
                offset += read;
            }
            return buffer;
        }

        private static byte[] ReadToEnd(Stream stream)
        {
            using (MemoryStream body = new MemoryStream())
            {
                byte[] buffer = new byte[8192];
                int read;
                while ((read = stream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    if (body.Length + read > MaxBodyBytes)
                    {
                        throw new IOException("HTTP body too large");
                    }
                    body.Write(buffer, 0, read);
                }
                return body.ToArray();
            }
        }

        // Reads one CRLF- or LF-terminated line byte by byte, so nothing past the
        // line is consumed. Returns null at end of stream.
        private static string ReadLine(Stream stream)
        {
            using (MemoryStream line = new MemoryStream())
            {
                int b;
                while ((b = stream.ReadByte()) >= 0)
                {
                    if (b == '\n')
                    {
                        return TrimCarriageReturn(line);
                    }
                    if (line.Length >= MaxLineBytes)
                    {
                        throw new IOException("HTTP line too long");
                    }
                    line.WriteByte((byte)b);
                }
                return line.Length == 0 ? null : TrimCarriageReturn(line);
            }
        }

        private static string TrimCarriageReturn(MemoryStream line)
        {
            byte[] bytes = line.ToArray();
            int length = bytes.Length > 0 && bytes[bytes.Length - 1] == '\r' ? bytes.Length - 1 : bytes.Length;
            return Encoding.ASCII.GetString(bytes, 0, length);
        }
    }
}
