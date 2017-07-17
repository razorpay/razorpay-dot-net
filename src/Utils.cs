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