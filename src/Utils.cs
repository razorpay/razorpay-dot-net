using System;
using System.Text;
using Razorpay.Api.Errors;
using System.Collections.Generic;
using System.Security.Cryptography;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Modes;

namespace Razorpay.Api
{
    public class Utils
    {
        public static void verifyPaymentSignature(Dictionary<string, string> attributes)
        {
            string expectedSignature = attributes["razorpay_signature"];
            string orderId = attributes["razorpay_order_id"];
            string paymentId = attributes["razorpay_payment_id"];

            string payload = string.Format("{0}|{1}", orderId, paymentId);

            string secret = RazorpayClient.Secret;

            verifySignature(payload, expectedSignature, secret);
        }

        public static void verifySubscriptionSignature(Dictionary<string, string> attributes)
        {
            string expectedSignature = attributes["razorpay_signature"];
            string subscriptionId = attributes["razorpay_subscription_id"];
            string paymentId = attributes["razorpay_payment_id"];

            string payload = string.Format("{0}|{1}", paymentId, subscriptionId);

            string secret = RazorpayClient.Secret;

            verifySignature(payload, expectedSignature, secret);
        }

        public static void verifyPaymentLinkSignature(Dictionary<string, string> attributes)
        {
            string expectedSignature = attributes["razorpay_signature"];
            string paymentLinkStatus = attributes["payment_link_status"];
            string paymentLinkId = attributes["payment_link_id"];
            string paymentLinkRefId = attributes["payment_link_reference_id"];
            string paymentId = attributes["razorpay_payment_id"];

            string payload = string.Format("{0}|{1}|{2}|{3}", paymentLinkId, paymentLinkRefId, paymentLinkStatus, paymentId);

            string secret = RazorpayClient.Secret;

            verifySignature(payload, expectedSignature, secret);
        }

        public static void verifyWebhookSignature(string payload, string expectedSignature, string secret)
        {
            verifySignature(payload, expectedSignature, secret);
        }

        public static long ToUnixTimestamp(DateTime inputTime)
        {
            DateTime unixReferenceTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            TimeSpan diff = inputTime - unixReferenceTime;
            return (long)diff.TotalSeconds;
        }

        private static void verifySignature(string payload, string expectedSignature, string secret)
        {
            byte[] actualSignatureBytes = getActualSignatureBytes(payload, secret);

            // Decode expected signature from hex
            byte[] expectedSignatureBytes;
            try
            {
                expectedSignatureBytes = HexStringToByteArray(expectedSignature);
            }
            catch
            {
                throw new SignatureVerificationError("Invalid signature passed");
            }

            // Use constant-time comparison to prevent timing attacks
            bool verified = CryptographicEquals(actualSignatureBytes, expectedSignatureBytes);

            if (verified == false)
            {
                throw new SignatureVerificationError("Invalid signature passed");
            }
        }

        /// <summary>
        /// Constant-time byte array comparison to prevent timing attacks.
        /// </summary>
        private static bool CryptographicEquals(byte[] a, byte[] b)
        {
            if (a == null || b == null || a.Length != b.Length)
            {
                return false;
            }

            int result = 0;
            for (int i = 0; i < a.Length; i++)
            {
                result |= a[i] ^ b[i];
            }
            return result == 0;
        }

        private static byte[] HexStringToByteArray(string hex)
        {
            if (string.IsNullOrEmpty(hex) || hex.Length % 2 != 0)
            {
                throw new ArgumentException("Invalid hex string");
            }

            byte[] bytes = new byte[hex.Length / 2];
            for (int i = 0; i < bytes.Length; i++)
            {
                bytes[i] = Convert.ToByte(hex.Substring(i * 2, 2), 16);
            }
            return bytes;
        }

        private static byte[] getActualSignatureBytes(string payload, string secret)
        {
            byte[] secretBytes = Encoding.UTF8.GetBytes(secret);
            HMACSHA256 hashHmac = new HMACSHA256(secretBytes);
            byte[] payloadBytes = Encoding.UTF8.GetBytes(payload);
            return hashHmac.ComputeHash(payloadBytes);
        }
        
        public static string GenerateOnboardingSignature(Dictionary<string, object> attributes, string secret)
        {
            string jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(attributes);
            return Encrypt(jsonString, secret);
        }
        
        public static string Encrypt(string dataToEncrypt, string secret)
        {
            try
            {
                byte[] keyBytes = Encoding.UTF8.GetBytes(secret.Substring(0, 16));
                KeyParameter key = new KeyParameter(keyBytes);
                byte[] iv = new byte[12];
                Array.Copy(keyBytes, 0, iv, 0, 12);

                GcmBlockCipher cipher = new GcmBlockCipher(new AesEngine());
                AeadParameters parameters = new AeadParameters(key, 128, iv);

                cipher.Init(true, parameters);

                byte[] encryptedData = new byte[cipher.GetOutputSize(Encoding.UTF8.GetByteCount(dataToEncrypt))];
                int len = cipher.ProcessBytes(Encoding.UTF8.GetBytes(dataToEncrypt), 0, Encoding.UTF8.GetByteCount(dataToEncrypt), encryptedData, 0);
                cipher.DoFinal(encryptedData, len);

                return BytesToHex(encryptedData);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        
        public static string BytesToHex(byte[] bytes)
        {
            StringBuilder hexBuilder = new StringBuilder(bytes.Length * 2);
            foreach (byte b in bytes)
            {
                hexBuilder.AppendFormat("{0:x2}", b);
            }
            return hexBuilder.ToString();
        }

    }
}
