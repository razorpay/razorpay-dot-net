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
            Helper.Assert(result != null, "No payments retrieved");
        }

        public static void GetPaymentById()
        {
            Payment payment = Helper.TestGetPaymentById();
            Helper.Assert(payment != null, "Could not fetch payment by Id");
        }

        public static void CapturePayment()
        {
            Payment payment = Helper.TestCapturePayment();
            Helper.Assert(payment != null, "Payment capture could not be completed");
        }

        public static void RefundPayment()
        {
            Refund refund = Helper.TestRefundPayment();
            Helper.Assert(refund != null, "Payment refund could not be completed");
        }

        public static void RefundPaymentPartial()
        {
            Refund refund = Helper.TestPartialRefundPayment();
            Helper.Assert(refund != null, "Payment partial refund could not be completed");
        }

        public static void TestGetRefunds()
        {
            List<Refund> refunds = Helper.TestGetRefunds();
            Helper.Assert(refunds != null, "Could not get refunds");
        }

        public static void TestGetRefundById()
        {
            Refund refund = Helper.TestGetRefundById();
            Helper.Assert(refund != null, "Could not get refund by id");
        }
    }
}
