using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using NUnit.Framework;
using Razorpay.Api;
using Razorpay.Api.Errors;

namespace Razorpay.Tests
{
    [TestFixture]
    public class UtilsTests
    {
        private const string TestSecret = "test_secret_key";

        [SetUp]
        public void Setup()
        {
            new RazorpayClient("rzp_test_key", TestSecret);
        }

        #region Webhook Signature - Valid Cases

        [Test]
        public void VerifyWebhookSignature_ValidSignature_DoesNotThrow()
        {
            string payload = "{\"event\":\"payment.captured\"}";
            string secret = "webhook_secret";
            string validSig = ComputeHmacSha256(payload, secret);

            Assert.DoesNotThrow(() => Utils.verifyWebhookSignature(payload, validSig, secret));
        }

        [Test]
        public void VerifyWebhookSignature_JsonPayload_Works()
        {
            string payload = "{\"entity\":\"event\",\"event\":\"payment.authorized\",\"contains\":[\"payment\"]}";
            string secret = "whsec_test123";
            string validSig = ComputeHmacSha256(payload, secret);

            Assert.DoesNotThrow(() => Utils.verifyWebhookSignature(payload, validSig, secret));
        }

        [Test]
        public void VerifyWebhookSignature_SpecialCharsInPayload_Works()
        {
            string payload = "{\"key\":\"value with spaces & symbols <>\"}";
            string secret = "test_secret";
            string validSig = ComputeHmacSha256(payload, secret);

            Assert.DoesNotThrow(() => Utils.verifyWebhookSignature(payload, validSig, secret));
        }

        [Test]
        public void VerifyWebhookSignature_LongPayload_Works()
        {
            string payload = new string('a', 10000);
            string secret = "test_secret";
            string validSig = ComputeHmacSha256(payload, secret);

            Assert.DoesNotThrow(() => Utils.verifyWebhookSignature(payload, validSig, secret));
        }

        #endregion

        #region Webhook Signature - Invalid Cases

        [Test]
        public void VerifyWebhookSignature_InvalidSignature_ThrowsError()
        {
            Assert.Throws<SignatureVerificationError>(() =>
                Utils.verifyWebhookSignature("{\"event\":\"payment.captured\"}", "invalid_sig", "secret"));
        }

        [Test]
        public void VerifyWebhookSignature_EmptySignature_ThrowsError()
        {
            Assert.Throws<SignatureVerificationError>(() =>
                Utils.verifyWebhookSignature("test_payload", "", "test_secret"));
        }

        [Test]
        public void VerifyWebhookSignature_NullSignature_ThrowsError()
        {
            Assert.Throws<SignatureVerificationError>(() =>
                Utils.verifyWebhookSignature("test_payload", null, "test_secret"));
        }

        [Test]
        public void VerifyWebhookSignature_WrongLengthSignature_ThrowsError()
        {
            Assert.Throws<SignatureVerificationError>(() =>
                Utils.verifyWebhookSignature("test_payload", "abc123", "test_secret"));
        }

        [Test]
        public void VerifyWebhookSignature_NonHexSignature_ThrowsError()
        {
            Assert.Throws<SignatureVerificationError>(() =>
                Utils.verifyWebhookSignature("test_payload", "not-valid-hex!@#$%^&*()", "test_secret"));
        }

        [Test]
        public void VerifyWebhookSignature_TamperedSignature_ThrowsError()
        {
            string tamperedSig = new string('a', 64);
            Assert.Throws<SignatureVerificationError>(() =>
                Utils.verifyWebhookSignature("test_payload", tamperedSig, "test_secret"));
        }

        [Test]
        public void VerifyWebhookSignature_WrongSecret_ThrowsError()
        {
            string payload = "test_payload";
            string correctSig = ComputeHmacSha256(payload, "correct_secret");

            Assert.Throws<SignatureVerificationError>(() =>
                Utils.verifyWebhookSignature(payload, correctSig, "wrong_secret"));
        }

        [Test]
        public void VerifyWebhookSignature_ModifiedPayload_ThrowsError()
        {
            string originalPayload = "original_payload";
            string secret = "test_secret";
            string sig = ComputeHmacSha256(originalPayload, secret);

            Assert.Throws<SignatureVerificationError>(() =>
                Utils.verifyWebhookSignature("modified_payload", sig, secret));
        }

        [Test]
        public void VerifyWebhookSignature_OddLengthHex_ThrowsError()
        {
            Assert.Throws<SignatureVerificationError>(() =>
                Utils.verifyWebhookSignature("test_payload", "abc", "test_secret"));
        }

        #endregion

        #region Payment Signature

        [Test]
        public void VerifyPaymentSignature_ValidSignature_DoesNotThrow()
        {
            var attributes = new Dictionary<string, string>
            {
                { "razorpay_payment_id", "pay_123" },
                { "razorpay_order_id", "order_456" },
                { "razorpay_signature", ComputeHmacSha256("order_456|pay_123", TestSecret) }
            };

            Assert.DoesNotThrow(() => Utils.verifyPaymentSignature(attributes));
        }

        [Test]
        public void VerifyPaymentSignature_InvalidSignature_ThrowsError()
        {
            var attributes = new Dictionary<string, string>
            {
                { "razorpay_payment_id", "pay_123" },
                { "razorpay_order_id", "order_456" },
                { "razorpay_signature", "invalid_signature" }
            };

            Assert.Throws<SignatureVerificationError>(() => Utils.verifyPaymentSignature(attributes));
        }

        [Test]
        public void VerifyPaymentSignature_TamperedPaymentId_ThrowsError()
        {
            string originalSig = ComputeHmacSha256("order_456|pay_123", TestSecret);
            var attributes = new Dictionary<string, string>
            {
                { "razorpay_payment_id", "pay_999" },
                { "razorpay_order_id", "order_456" },
                { "razorpay_signature", originalSig }
            };

            Assert.Throws<SignatureVerificationError>(() => Utils.verifyPaymentSignature(attributes));
        }

        [Test]
        public void VerifyPaymentSignature_TamperedOrderId_ThrowsError()
        {
            string originalSig = ComputeHmacSha256("order_456|pay_123", TestSecret);
            var attributes = new Dictionary<string, string>
            {
                { "razorpay_payment_id", "pay_123" },
                { "razorpay_order_id", "order_999" },
                { "razorpay_signature", originalSig }
            };

            Assert.Throws<SignatureVerificationError>(() => Utils.verifyPaymentSignature(attributes));
        }

        #endregion

        #region Subscription Signature

        [Test]
        public void VerifySubscriptionSignature_ValidSignature_DoesNotThrow()
        {
            var attributes = new Dictionary<string, string>
            {
                { "razorpay_payment_id", "pay_123" },
                { "razorpay_subscription_id", "sub_456" },
                { "razorpay_signature", ComputeHmacSha256("pay_123|sub_456", TestSecret) }
            };

            Assert.DoesNotThrow(() => Utils.verifySubscriptionSignature(attributes));
        }

        [Test]
        public void VerifySubscriptionSignature_InvalidSignature_ThrowsError()
        {
            var attributes = new Dictionary<string, string>
            {
                { "razorpay_payment_id", "pay_123" },
                { "razorpay_subscription_id", "sub_456" },
                { "razorpay_signature", "invalid_signature" }
            };

            Assert.Throws<SignatureVerificationError>(() => Utils.verifySubscriptionSignature(attributes));
        }

        #endregion

        #region Payment Link Signature

        [Test]
        public void VerifyPaymentLinkSignature_ValidSignature_DoesNotThrow()
        {
            string payload = "plink_123|ref_456|paid|pay_789";
            var attributes = new Dictionary<string, string>
            {
                { "payment_link_id", "plink_123" },
                { "payment_link_reference_id", "ref_456" },
                { "payment_link_status", "paid" },
                { "razorpay_payment_id", "pay_789" },
                { "razorpay_signature", ComputeHmacSha256(payload, TestSecret) }
            };

            Assert.DoesNotThrow(() => Utils.verifyPaymentLinkSignature(attributes));
        }

        [Test]
        public void VerifyPaymentLinkSignature_InvalidSignature_ThrowsError()
        {
            var attributes = new Dictionary<string, string>
            {
                { "payment_link_id", "plink_123" },
                { "payment_link_reference_id", "ref_456" },
                { "payment_link_status", "paid" },
                { "razorpay_payment_id", "pay_789" },
                { "razorpay_signature", "invalid_signature" }
            };

            Assert.Throws<SignatureVerificationError>(() => Utils.verifyPaymentLinkSignature(attributes));
        }

        #endregion

        #region Encryption

        [Test]
        public void GenerateOnboardingSignature_ReturnsNonEmptyString()
        {
            var data = new Dictionary<string, object>
            {
                { "test_key", "test_value" }
            };
            string result = Utils.GenerateOnboardingSignature(data, "1234567890123456");

            Assert.That(result, Is.Not.Null.And.Not.Empty);
        }

        [Test]
        public void GenerateOnboardingSignature_DifferentInputs_DifferentOutputs()
        {
            var data1 = new Dictionary<string, object> { { "key", "value1" } };
            var data2 = new Dictionary<string, object> { { "key", "value2" } };
            string secret = "1234567890123456";

            string result1 = Utils.GenerateOnboardingSignature(data1, secret);
            string result2 = Utils.GenerateOnboardingSignature(data2, secret);

            Assert.That(result1, Is.Not.EqualTo(result2));
        }

        [Test]
        public void Encrypt_ReturnsHexString()
        {
            string result = Utils.Encrypt("test_data", "1234567890123456");

            Assert.That(result, Is.Not.Null.And.Not.Empty);
            Assert.That(result, Does.Match("^[0-9a-f]+$"));
        }

        [Test]
        public void Encrypt_SameInputs_SameOutput()
        {
            string data = "test_data";
            string secret = "1234567890123456";

            string result1 = Utils.Encrypt(data, secret);
            string result2 = Utils.Encrypt(data, secret);

            Assert.That(result1, Is.EqualTo(result2));
        }

        [Test]
        public void BytesToHex_ReturnsCorrectFormat()
        {
            byte[] bytes = new byte[] { 0x00, 0xFF, 0xAB, 0x12 };
            string result = Utils.BytesToHex(bytes);

            Assert.That(result, Is.EqualTo("00ffab12"));
        }

        [Test]
        public void BytesToHex_EmptyArray_ReturnsEmptyString()
        {
            byte[] bytes = new byte[0];
            string result = Utils.BytesToHex(bytes);

            Assert.That(result, Is.Empty);
        }

        #endregion

        #region ToUnixTimestamp

        [Test]
        public void ToUnixTimestamp_ReturnsCorrectValue()
        {
            var date = new DateTime(2020, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            long expected = 1577836800;

            long result = Utils.ToUnixTimestamp(date);

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void ToUnixTimestamp_UnixEpoch_ReturnsZero()
        {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

            long result = Utils.ToUnixTimestamp(epoch);

            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void ToUnixTimestamp_BeforeEpoch_ReturnsNegative()
        {
            var date = new DateTime(1969, 1, 1, 0, 0, 0, DateTimeKind.Utc);

            long result = Utils.ToUnixTimestamp(date);

            Assert.That(result, Is.LessThan(0));
        }

        [Test]
        public void ToUnixTimestamp_FutureDate_ReturnsPositive()
        {
            var date = new DateTime(2030, 1, 1, 0, 0, 0, DateTimeKind.Utc);

            long result = Utils.ToUnixTimestamp(date);

            Assert.That(result, Is.GreaterThan(0));
        }

        #endregion

        #region Edge Cases

        [Test]
        public void VerifyWebhookSignature_UppercaseSignature_Fails()
        {
            string payload = "test_payload";
            string secret = "test_secret";
            string sig = ComputeHmacSha256(payload, secret).ToUpper();

            Assert.Throws<SignatureVerificationError>(() =>
                Utils.verifyWebhookSignature(payload, sig, secret));
        }

        [Test]
        public void VerifyPaymentSignature_MissingPaymentId_ThrowsError()
        {
            var attributes = new Dictionary<string, string>
            {
                { "razorpay_order_id", "order_456" },
                { "razorpay_signature", "some_signature" }
            };

            Assert.Throws<KeyNotFoundException>(() => Utils.verifyPaymentSignature(attributes));
        }

        [Test]
        public void VerifyPaymentSignature_MissingOrderId_ThrowsError()
        {
            var attributes = new Dictionary<string, string>
            {
                { "razorpay_payment_id", "pay_123" },
                { "razorpay_signature", "some_signature" }
            };

            Assert.Throws<KeyNotFoundException>(() => Utils.verifyPaymentSignature(attributes));
        }

        [Test]
        public void VerifyPaymentSignature_MissingSignature_ThrowsError()
        {
            var attributes = new Dictionary<string, string>
            {
                { "razorpay_payment_id", "pay_123" },
                { "razorpay_order_id", "order_456" }
            };

            Assert.Throws<KeyNotFoundException>(() => Utils.verifyPaymentSignature(attributes));
        }

        [Test]
        public void VerifySubscriptionSignature_MissingPaymentId_ThrowsError()
        {
            var attributes = new Dictionary<string, string>
            {
                { "razorpay_subscription_id", "sub_456" },
                { "razorpay_signature", "some_signature" }
            };

            Assert.Throws<KeyNotFoundException>(() => Utils.verifySubscriptionSignature(attributes));
        }

        [Test]
        public void VerifySubscriptionSignature_MissingSubscriptionId_ThrowsError()
        {
            var attributes = new Dictionary<string, string>
            {
                { "razorpay_payment_id", "pay_123" },
                { "razorpay_signature", "some_signature" }
            };

            Assert.Throws<KeyNotFoundException>(() => Utils.verifySubscriptionSignature(attributes));
        }

        [Test]
        public void VerifyPaymentLinkSignature_MissingFields_ThrowsError()
        {
            var attributes = new Dictionary<string, string>
            {
                { "payment_link_id", "plink_123" },
                { "razorpay_signature", "some_signature" }
            };

            Assert.Throws<KeyNotFoundException>(() => Utils.verifyPaymentLinkSignature(attributes));
        }

        [Test]
        public void VerifyWebhookSignature_EmptyPayload_Works()
        {
            string payload = "";
            string secret = "test_secret";
            string validSig = ComputeHmacSha256(payload, secret);

            Assert.DoesNotThrow(() => Utils.verifyWebhookSignature(payload, validSig, secret));
        }

        [Test]
        public void VerifyWebhookSignature_SingleCharPayload_Works()
        {
            string payload = "a";
            string secret = "s";
            string validSig = ComputeHmacSha256(payload, secret);

            Assert.DoesNotThrow(() => Utils.verifyWebhookSignature(payload, validSig, secret));
        }

        [Test]
        public void ToUnixTimestamp_SpecificKnownDate_ReturnsCorrectValue()
        {
            var date = new DateTime(2024, 6, 15, 12, 30, 45, DateTimeKind.Utc);
            long expected = 1718454645;
            long result = Utils.ToUnixTimestamp(date);

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void GenerateOnboardingSignature_EmptyData_ReturnsResult()
        {
            var data = new Dictionary<string, object>();
            string result = Utils.GenerateOnboardingSignature(data, "1234567890123456");

            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public void GenerateOnboardingSignature_NestedData_Works()
        {
            var innerData = new Dictionary<string, object> { { "inner_key", "inner_value" } };
            var data = new Dictionary<string, object>
            {
                { "outer_key", innerData }
            };

            string result = Utils.GenerateOnboardingSignature(data, "1234567890123456");
            Assert.That(result, Is.Not.Null.And.Not.Empty);
        }

        [Test]
        public void Encrypt_EmptyData_ReturnsHex()
        {
            string result = Utils.Encrypt("", "1234567890123456");

            Assert.That(result, Is.Not.Null);
            Assert.That(result, Does.Match("^[0-9a-f]*$"));
        }

        [Test]
        public void BytesToHex_AllZeros_ReturnsCorrectFormat()
        {
            byte[] bytes = new byte[] { 0x00, 0x00, 0x00, 0x00 };
            string result = Utils.BytesToHex(bytes);

            Assert.That(result, Is.EqualTo("00000000"));
        }

        [Test]
        public void BytesToHex_AllOnes_ReturnsCorrectFormat()
        {
            byte[] bytes = new byte[] { 0xFF, 0xFF, 0xFF, 0xFF };
            string result = Utils.BytesToHex(bytes);

            Assert.That(result, Is.EqualTo("ffffffff"));
        }

        [Test]
        public void BytesToHex_SingleByte_ReturnsCorrectFormat()
        {
            byte[] bytes = new byte[] { 0x5A };
            string result = Utils.BytesToHex(bytes);

            Assert.That(result, Is.EqualTo("5a"));
        }

        #endregion

        #region Signature Verification Robustness

        [Test]
        public void VerifyWebhookSignature_MultipleValidCalls_AllSucceed()
        {
            string payload = "test_payload";
            string secret = "test_secret";
            string validSig = ComputeHmacSha256(payload, secret);

            for (int i = 0; i < 100; i++)
            {
                Assert.DoesNotThrow(() => Utils.verifyWebhookSignature(payload, validSig, secret));
            }
        }

        [Test]
        public void VerifyWebhookSignature_MultipleInvalidCalls_AllFail()
        {
            string payload = "test_payload";
            string secret = "test_secret";
            string invalidSig = new string('a', 64);

            for (int i = 0; i < 100; i++)
            {
                Assert.Throws<SignatureVerificationError>(() =>
                    Utils.verifyWebhookSignature(payload, invalidSig, secret));
            }
        }

        #endregion

        #region Helper

        // Uses ASCIIEncoding to match current SDK behavior.
        // Update to UTF8 when SDK encoding is fixed.
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

        #endregion
    }
}
