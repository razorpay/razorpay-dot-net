using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Tls;
using Org.BouncyCastle.Tls.Crypto;
using Org.BouncyCastle.Tls.Crypto.Impl.BC;
using Org.BouncyCastle.X509;

namespace Razorpay.Api.Http
{
    // Opt-in transport that performs TLS in managed code (BouncyCastle) instead of
    // the operating system's TLS stack. Lets hosts whose OS lacks modern cipher
    // suites (e.g. Windows Server 2012 R2, which has no ECDHE-RSA-AES-GCM) still
    // negotiate TLS 1.3 or TLS 1.2 with AEAD ciphers. Enable via
    // RazorpayClient.UseManagedTls.
    internal sealed class ManagedTlsTransport : IHttpTransport
    {
        internal static readonly ManagedTlsTransport Instance = new ManagedTlsTransport();

        public HttpResult Send(HttpRequestData request)
        {
            Uri uri = request.Uri;
            if (uri.Scheme != Uri.UriSchemeHttps)
            {
                throw new ArgumentException("Managed TLS transport only supports https URLs", "request");
            }

            using (TcpClient tcp = Connect(uri, request.TimeoutMilliseconds))
            {
                TlsClientProtocol tls = new TlsClientProtocol(tcp.GetStream());
                try
                {
                    tls.Connect(new RazorpayTlsClient(new BcTlsCrypto(), uri.IdnHost));
                }
                catch (IOException ex)
                {
                    throw new WebException("TLS handshake with " + uri.Host + " failed: " + ex.Message, ex, WebExceptionStatus.SecureChannelFailure, null);
                }

                try
                {
                    WriteRequest(tls.Stream, request);
                    return HttpResponseReader.Read(new BufferedStream(tls.Stream));
                }
                catch (IOException ex)
                {
                    throw new WebException("Request to " + uri.Host + " failed: " + ex.Message, ex, WebExceptionStatus.ReceiveFailure, null);
                }
                finally
                {
                    CloseQuietly(tls);
                }
            }
        }

        private static TcpClient Connect(Uri uri, int timeoutMilliseconds)
        {
            IWebProxy proxy = WebRequest.DefaultWebProxy;
            Uri proxyUri = proxy == null || proxy.IsBypassed(uri) ? null : proxy.GetProxy(uri);
            bool viaProxy = proxyUri != null && proxyUri != uri;

            TcpClient tcp = OpenSocket(viaProxy ? proxyUri.Host : uri.IdnHost, viaProxy ? proxyUri.Port : uri.Port, timeoutMilliseconds);
            try
            {
                if (viaProxy)
                {
                    OpenProxyTunnel(tcp.GetStream(), uri);
                }
                return tcp;
            }
            catch
            {
                tcp.Dispose();
                throw;
            }
        }

        private static TcpClient OpenSocket(string host, int port, int timeoutMilliseconds)
        {
            TcpClient tcp = new TcpClient { NoDelay = true, ReceiveTimeout = timeoutMilliseconds, SendTimeout = timeoutMilliseconds };
            try
            {
                if (!tcp.ConnectAsync(host, port).Wait(timeoutMilliseconds))
                {
                    throw new WebException("Timed out connecting to " + host, WebExceptionStatus.Timeout);
                }
                return tcp;
            }
            catch (AggregateException ex)
            {
                tcp.Dispose();
                throw new WebException("Could not connect to " + host + ": " + ex.InnerException.Message, ex.InnerException, WebExceptionStatus.ConnectFailure, null);
            }
            catch
            {
                tcp.Dispose();
                throw;
            }
        }

        // HTTP CONNECT tunnel through the system proxy. Proxy authentication is not
        // supported: it would send proxy credentials in cleartext.
        private static void OpenProxyTunnel(Stream stream, Uri uri)
        {
            string target = uri.IdnHost + ":" + uri.Port;
            byte[] connect = Encoding.ASCII.GetBytes("CONNECT " + target + " HTTP/1.1\r\nHost: " + target + "\r\n\r\n");
            stream.Write(connect, 0, connect.Length);
            stream.Flush();

            Dictionary<string, string> headers;
            int statusCode = HttpResponseReader.ReadHead(stream, out headers);
            if (statusCode != 200)
            {
                throw new WebException("Proxy refused CONNECT to " + target + " with HTTP " + statusCode, WebExceptionStatus.RequestProhibitedByProxy);
            }
        }

        private static void WriteRequest(Stream stream, HttpRequestData request)
        {
            Uri uri = request.Uri;
            StringBuilder head = new StringBuilder();
            head.Append(request.Method).Append(' ').Append(uri.PathAndQuery).Append(" HTTP/1.1\r\n");
            AppendHeader(head, "Host", uri.IsDefaultPort ? uri.IdnHost : uri.IdnHost + ":" + uri.Port);
            AppendHeader(head, "User-Agent", request.UserAgent);
            AppendHeader(head, "Content-Type", request.ContentType);
            foreach (KeyValuePair<string, string> header in request.Headers)
            {
                AppendHeader(head, header.Key, header.Value);
            }
            if (request.Body != null)
            {
                AppendHeader(head, "Content-Length", request.Body.Length.ToString());
            }
            AppendHeader(head, "Connection", "close");
            head.Append("\r\n");

            byte[] headBytes = Encoding.UTF8.GetBytes(head.ToString());
            stream.Write(headBytes, 0, headBytes.Length);
            if (request.Body != null)
            {
                stream.Write(request.Body, 0, request.Body.Length);
            }
            stream.Flush();
        }

        private static void AppendHeader(StringBuilder head, string name, string value)
        {
            if (value == null)
            {
                return;
            }
            if (name.IndexOfAny(new[] { '\r', '\n', ':' }) >= 0 || value.IndexOfAny(new[] { '\r', '\n' }) >= 0)
            {
                throw new ArgumentException("Invalid HTTP header: " + name);
            }
            head.Append(name).Append(": ").Append(value).Append("\r\n");
        }

        private static void CloseQuietly(TlsClientProtocol tls)
        {
            try
            {
                tls.Close();
            }
            catch (IOException)
            {
                // Server already closed the connection ("Connection: close").
            }
        }

        private sealed class RazorpayTlsClient : DefaultTlsClient
        {
            // AEAD suites only. ECDHE-ECDSA suites are omitted: over TLS 1.2 they
            // need NIST curves, which the key-exchange policy below excludes.
            private static readonly int[] CipherSuites =
            {
                CipherSuite.TLS_AES_256_GCM_SHA384,
                CipherSuite.TLS_AES_128_GCM_SHA256,
                CipherSuite.TLS_CHACHA20_POLY1305_SHA256,
                CipherSuite.TLS_ECDHE_RSA_WITH_AES_256_GCM_SHA384,
                CipherSuite.TLS_ECDHE_RSA_WITH_AES_128_GCM_SHA256,
            };

            private readonly string host;

            public RazorpayTlsClient(TlsCrypto crypto, string host)
                : base(crypto)
            {
                this.host = host;
            }

            protected override ProtocolVersion[] GetSupportedVersions()
            {
                return ProtocolVersion.TLSv13.DownTo(ProtocolVersion.TLSv12);
            }

            protected override int[] GetSupportedCipherSuites()
            {
                return TlsUtilities.GetSupportedCipherSuites(Crypto, CipherSuites);
            }

            // X25519 only for key exchange; no NIST curves.
            protected override IList<int> GetSupportedGroups(IList<int> namedGroupRoles)
            {
                return new List<int> { NamedGroup.x25519 };
            }

            protected override IList<ServerName> GetSniServerNames()
            {
                return new List<ServerName> { new ServerName(NameType.host_name, Encoding.ASCII.GetBytes(host)) };
            }

            protected override IList<ProtocolName> GetProtocolNames()
            {
                return new List<ProtocolName> { ProtocolName.Http_1_1 };
            }

            public override TlsAuthentication GetAuthentication()
            {
                return new ServerCertificateValidator(host);
            }
        }

        // Fails the handshake unless the server certificate chains to a root in the
        // OS trust store (with online revocation checking) and names the host.
        private sealed class ServerCertificateValidator : TlsAuthentication
        {
            private const string ServerAuthOid = "1.3.6.1.5.5.7.3.1";

            private readonly string host;

            public ServerCertificateValidator(string host)
            {
                this.host = host;
            }

            // Fully qualified: .NET also defines X509Certificates.CertificateRequest.
            public TlsCredentials GetClientCredentials(Org.BouncyCastle.Tls.CertificateRequest certificateRequest)
            {
                return null;
            }

            public void NotifyServerCertificate(TlsServerCertificate serverCertificate)
            {
                Certificate chain = serverCertificate.Certificate;
                if (chain == null || chain.IsEmpty)
                {
                    throw new TlsFatalAlert(AlertDescription.bad_certificate, "Server sent no certificate");
                }

                byte[] leaf = chain.GetCertificateAt(0).GetEncoded();
                if (!IsTrusted(leaf, chain))
                {
                    throw new TlsFatalAlert(AlertDescription.bad_certificate, "Server certificate is not trusted");
                }
                if (!NamesHost(leaf))
                {
                    throw new TlsFatalAlert(AlertDescription.bad_certificate, "Server certificate does not match " + host);
                }
            }

            private static bool IsTrusted(byte[] leaf, Certificate chain)
            {
                List<X509Certificate2> intermediates = new List<X509Certificate2>();
                try
                {
                    using (X509Certificate2 leafCertificate = new X509Certificate2(leaf))
                    using (X509Chain x509Chain = new X509Chain())
                    {
                        X509ChainPolicy policy = x509Chain.ChainPolicy;
                        policy.RevocationMode = X509RevocationMode.Online;
                        policy.RevocationFlag = X509RevocationFlag.ExcludeRoot;
                        policy.VerificationFlags = X509VerificationFlags.NoFlag;
                        policy.ApplicationPolicy.Add(new Oid(ServerAuthOid));

                        for (int i = 1; i < chain.Length; i++)
                        {
                            X509Certificate2 intermediate = new X509Certificate2(chain.GetCertificateAt(i).GetEncoded());
                            intermediates.Add(intermediate);
                            policy.ExtraStore.Add(intermediate);
                        }

                        return x509Chain.Build(leafCertificate);
                    }
                }
                finally
                {
                    foreach (X509Certificate2 intermediate in intermediates)
                    {
                        intermediate.Dispose();
                    }
                }
            }

            // Matches subjectAltName dNSName entries only (no CN fallback).
            private bool NamesHost(byte[] leaf)
            {
                IList<IList<object>> names = new X509CertificateParser().ReadCertificate(leaf).GetSubjectAlternativeNames();
                if (names == null)
                {
                    return false;
                }

                foreach (IList<object> name in names)
                {
                    if (name.Count >= 2 && Convert.ToInt32(name[0]) == GeneralName.DnsName
                        && HostnameMatcher.Matches(name[1] as string, host))
                    {
                        return true;
                    }
                }
                return false;
            }
        }
    }
}
