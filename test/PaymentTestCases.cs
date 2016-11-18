using Razorpay.Api;
using System.Collections.Generic;
using System.Diagnostics;

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
            Debug.Assert(result != null);
        }

        public static void GetPaymentById()
        {
            Payment payment = Helper.TestGetPaymentById();
            Debug.Assert(payment != null);
        }

        public static void CapturePayment()
        {
            Payment payment = Helper.TestCapturePayment();
            Debug.Assert(payment != null);
        }

        public static void RefundPayment()
        {
            Refund refund = Helper.TestRefundPayment();
            Debug.Assert(refund != null);
        }

        public static void RefundPaymentPartial()
        {
            Refund refund = Helper.TestPartialRefundPayment();
            Debug.Assert(refund != null);
        }

        public static void TestGetRefunds()
        {
            List<Refund> refunds = Helper.TestGetRefunds();
            Debug.Assert(refunds != null);
        }

        public static void TestGetRefundById()
        {
            Refund refund = Helper.TestGetRefundById();
            Debug.Assert(refund != null);
        }
    }
}
