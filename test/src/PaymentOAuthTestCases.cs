using Razorpay.Api;
using System.Collections.Generic;
using NUnit.Framework;

namespace RazorpayClientTest
{
    public class PaymentOAuthTestCases
    {
        public static void Init(string accessToken)
        {
            Helper.client = new RazorpayClient(accessToken);
        }

        public static void GetAllPaymentsTest()
        {
            List<Payment> result = Helper.TestGetAllPayments();
            Assert.AreNotSame(null, result);
        }

        public static void GetPaymentById()
        {
            Payment payment = Helper.TestGetPaymentById();
            Assert.AreNotSame(null, payment);
        }

        public static void CapturePayment()
        {
            Payment payment = Helper.TestCapturePayment();
            Assert.AreNotSame(null, payment);
        }

        public static void RefundPayment()
        {
            Refund refund = Helper.TestRefundPayment();
            Assert.AreNotSame(null, refund);
        }
    }
}