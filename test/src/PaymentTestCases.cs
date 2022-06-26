using Razorpay.Api;
using System.Collections.Generic;
using NUnit.Framework;

namespace RazorpayClientTest
{
    public class PaymentTestCases
    {
        public static void Init(string key, string secret)
        {
            Helper.client = new RazorpayClient(key, secret);
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

        public static void RefundPaymentPartial()
        {
            Refund refund = Helper.TestPartialRefundPayment();
            Assert.AreNotSame(null, refund);
        }

        public static void TestGetRefunds()
        {
            List<Refund> refunds = Helper.TestGetRefunds();
            Assert.AreNotSame(null, refunds);
        }

        public static void TestGetRefundById()
        {
            Refund refund = Helper.TestGetRefundById();
            Assert.AreNotSame(null, refund);
        }

        public static void TestFetchCardDetails()
        {
            Card card = Helper.TestFetchCardDetails();
            Assert.NotNull(card);
        }

        public static void TestGetAllDowntime()
        {
            List <Payment> results = Helper.TestGetAllDowntime();
            Assert.AreNotSame(null, results);
        }

        public static void TestFetchPaymentDowntimeById()
        {
            Payment result = Helper.TestFetchPaymentDowntimeById();
            Assert.AreNotSame(null, result);
        }

        public static void TestEditPayment()
        {
            Payment result = Helper.TestEditPayment();
            Assert.AreNotSame(null, result);
        }

    }
}
