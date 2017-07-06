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
    }
}