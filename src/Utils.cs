using System;
using System.Text;
using Razorpay.Api.Errors;
using System.Collections.Generic;
using System.Security.Cryptography;

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
            string actualSignature = getActualSignature(payload, secret);

            bool verified = actualSignature.Equals(expectedSignature);

            if (verified == false)
            {
                throw new SignatureVerificationError("Invalid signature passed");
            }
        }

        private static string getActualSignature(string payload, string secret)
        {
            byte[] secretBytes = StringEncode(secret);

            HMACSHA256 hashHmac = new HMACSHA256(secretBytes);

            var bytes = StringEncode(payload);

            return HashEncode(hashHmac.ComputeHash(bytes));
        }
        
        public static string GenerateOnboardingSignature(Dictionary<string, object> attributes, string secret)
        {
            string jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(attributes);
            return Encrypt(jsonString, secret);
        }
        
        public static string Encrypt(string dataToEncrypt, string secret)
        {
            byte[] iv = Encoding.UTF8.GetBytes(secret);
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = iv;
                aesAlg.Mode = CipherMode.CBC;
                aesAlg.Padding = PaddingMode.None;

                try
                {
                    ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
                    byte[] encryptedBytes = encryptor.TransformFinalBlock(Encoding.UTF8.GetBytes(dataToEncrypt), 0, dataToEncrypt.Length);
                    return BytesToHex(encryptedBytes);
                }
                catch (Exception e)
                {
                    throw new BadRequestError(e.Message, "BAD_REQUEST_ERROR", 400);
                }
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

        private static byte[] StringEncode(string text)
        {
            var encoding = new ASCIIEncoding();
            return encoding.GetBytes(text);
        }

        private static string HashEncode(byte[] hash)
        {
            return BitConverter.ToString(hash).Replace("-", "").ToLower();
        }
    }
}
