using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Razorpay.Api;
using System.Collections.Generic;
using System.Diagnostics;

namespace RazorpayClientTest
{
    [TestClass]
    public class PaymentTestCases
    {
        [ClassInitialize]
        public static void Init(TestContext testcontext)
        {
            Helper.client = new RazorpayClient("<api-key>", "<api-secret>");
        }

        [TestMethod]
        public void GetAllPaymentsTest()
        {
            List<Payment> result = Helper.TestGetAllPayments();
            Debug.Assert(result != null);
        }

        [TestMethod]
        public void GetPaymentById()
        {
            Payment payment = Helper.TestGetPaymentById();
        }

        [TestMethod]
        public void CapturePayment()
        {
            Payment payment = Helper.TestCapturePayment();
        }

        [TestMethod]
        public void RefundPayment()
        {
            Refund refund = Helper.TestRefundPayment();
        }

        [TestMethod]
        public void RefundPaymentPartial()
        {
            Refund refund = Helper.TestPartialRefundPayment();
        }

        [TestMethod]
        public void TestGetRefunds()
        {
            List<Refund> refunds = Helper.TestGetRefunds();
        }

        [TestMethod]
        public void TestGetRefundById()
        {
            Refund refund = Helper.TestGetRefundById();
        }
    }
}
