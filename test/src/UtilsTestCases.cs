using System;
using System.Security.Cryptography;
using System.Text;
using Razorpay.Api;
using Razorpay.Api.Errors;
using NUnit.Framework;

namespace RazorpayClientTest
{
    class UtilsTestCases
    {
        public static void Init(string key, string secret)
        {
            Helper.client = new RazorpayClient(key, secret);
        }

        public static void VerifyPaymentSignatureTest()
        {
            Assert.DoesNotThrow(() => {
                Helper.TestVerifyPaymentSignature();
            });
        }

        public static void FailedVerifyPaymentSignatureTest()
        {
            Assert.Throws<SignatureVerificationError>(() => {
                Helper.TestFailedVerifyPaymentSignature();
            });
        }

        public static void VerifyWebhookSignatureTest()
        {
            Assert.DoesNotThrow(() => {
                Helper.TestVerifyWebhookSignature();
            });
        }

        public static void FailedVerifyWebhookSignatureTest()
        {
            Assert.Throws<SignatureVerificationError>(() => {
                Helper.TestFailedVerifyWebhookSignature();
            });
        }

        /// <summary>
        /// Test signature verification with unicode in payload.
        /// Validates that UTF-8 encoding correctly handles non-ASCII characters.
        /// </summary>
        public static void UnicodeInPayloadTest()
        {
            string payload = "{\"name\":\"Aarav कुमार\",\"amount\":1000}";
            string secret = "test_secret";
            string validSig = ComputeHmacSha256(payload, secret);

            Assert.DoesNotThrow(() => {
                Utils.verifyWebhookSignature(payload, validSig, secret);
            });
        }

        // Uses UTF8 encoding to match SDK's fixed encoding behavior.
        private static string ComputeHmacSha256(string payload, string secret)
        {
            byte[] keyBytes = Encoding.UTF8.GetBytes(secret);
            byte[] payloadBytes = Encoding.UTF8.GetBytes(payload);

            using (var hmac = new HMACSHA256(keyBytes))
            {
                byte[] hash = hmac.ComputeHash(payloadBytes);
                return BitConverter.ToString(hash).Replace("-", "").ToLower();
            }
        }
    }
}