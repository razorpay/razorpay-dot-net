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

        // ========== Negative-path crypto tests ==========

        /// <summary>
        /// Test that an empty signature is rejected.
        /// </summary>
        public static void EmptySignatureRejectedTest()
        {
            Assert.Throws<SignatureVerificationError>(() => {
                Utils.verifyWebhookSignature("test_payload", "", "test_secret");
            });
        }

        /// <summary>
        /// Test that a short/wrong-length signature is rejected.
        /// </summary>
        public static void WrongLengthSignatureRejectedTest()
        {
            Assert.Throws<SignatureVerificationError>(() => {
                Utils.verifyWebhookSignature("test_payload", "abc123", "test_secret");
            });
        }

        /// <summary>
        /// Test that a non-hex signature is rejected.
        /// </summary>
        public static void NonHexSignatureRejectedTest()
        {
            Assert.Throws<SignatureVerificationError>(() => {
                Utils.verifyWebhookSignature("test_payload", "not-valid-hex!@#$%^&*()", "test_secret");
            });
        }

        /// <summary>
        /// Test that a valid hex signature with correct length but wrong value is rejected.
        /// </summary>
        public static void TamperedValidHexSignatureRejectedTest()
        {
            // 64 hex chars = 32 bytes (SHA-256 output), but wrong value
            string tamperedSig = new string('a', 64);
            Assert.Throws<SignatureVerificationError>(() => {
                Utils.verifyWebhookSignature("test_payload", tamperedSig, "test_secret");
            });
        }

        /// <summary>
        /// Test that a dynamically computed valid signature is accepted.
        /// </summary>
        public static void ValidDynamicSignatureAcceptedTest()
        {
            string payload = "{\"event\":\"payment.captured\",\"payload\":{\"id\":\"pay_123\"}}";
            string secret = "webhook_secret_123";
            string validSig = ComputeHmacSha256(payload, secret);

            Assert.DoesNotThrow(() => {
                Utils.verifyWebhookSignature(payload, validSig, secret);
            });
        }

        /// <summary>
        /// Test signature verification with special characters in payload.
        /// </summary>
        public static void SpecialCharsInPayloadTest()
        {
            string payload = "{\"key\":\"value with spaces & symbols <>\"}";
            string secret = "test_secret";
            string validSig = ComputeHmacSha256(payload, secret);

            Assert.DoesNotThrow(() => {
                Utils.verifyWebhookSignature(payload, validSig, secret);
            });
        }

        // NOTE: Uses ASCIIEncoding to match current SDK behavior in StringEncode().
        // Unicode test will be added in the fix PR that changes encoding to UTF8.
        private static string ComputeHmacSha256(string payload, string secret)
        {
            var encoding = new ASCIIEncoding();
            byte[] keyBytes = encoding.GetBytes(secret);
            byte[] payloadBytes = encoding.GetBytes(payload);

            using (var hmac = new HMACSHA256(keyBytes))
            {
                byte[] hash = hmac.ComputeHash(payloadBytes);
                return BitConverter.ToString(hash).Replace("-", "").ToLower();
            }
        }
    }
}