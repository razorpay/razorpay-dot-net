using Razorpay.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RazorpayClientTest
{
    public class Helper
    {
        public static List<Payment> TestGetAllPayments()
        {
            Dictionary<string, object> options = new Dictionary<string, object>();

            DateTime endTime = DateTime.UtcNow;
            DateTime startTime = endTime.Add(TimeSpan.FromHours(-1));
            options.Add("from", Utils.ToUnixTimestamp(startTime));
            options.Add("to", Utils.ToUnixTimestamp(endTime));

            List<Payment> result = PaymentTestCases.client.Payment.All(options);
            return result;
        }

        public static Payment TestGetPaymentById()
        {
            List<Payment> result = TestGetAllPayments();
            Payment testEntity = result[0];
            string paymentId = testEntity["id"].ToString();

            Payment payment = PaymentTestCases.client.Payment.Fetch(paymentId);

            return payment;
        }

        public static Payment TestCapturePayment()
        {
            List<Payment> result = TestGetAllPayments();
            Payment payment = FindPaymentWithStatus("authorized", result);
 
            Dictionary<string, object> options = new Dictionary<string, object>();
            options.Add("amount", payment["amount"]);

            Payment paymentCaptured = payment.Capture(options);

            return paymentCaptured;
        }

        public static Refund TestRefundPayment()
        {
            List<Payment> payments = TestGetAllPayments();
            Payment paymentCaptured = FindPaymentWithStatus("captured", payments);
            Refund refund = paymentCaptured.Refund();

            return refund;
        }

        public static List<Refund> TestGetRefunds()
        {
            List<Payment> payments = TestGetAllPayments();
            Payment paymentRefunded = FindPaymentWithStatus("refunded", payments);
            List<Refund> refunds = paymentRefunded.Refunds.All();
            return refunds;
        }
        public static Refund TestGetRefundById()
        {
            List<Payment> payments = TestGetAllPayments();
            Payment paymentRefunded = FindPaymentWithStatus("refunded", payments);
            List<Refund> refunds = paymentRefunded.Refunds.All();
            Refund refund = paymentRefunded.Refunds.Fetch(refunds[0]["id"].ToString());
            return refund;
        }

        private static Payment FindPaymentWithStatus(string status, List<Payment> payments)
        {
            int index = 0;
            foreach (Payment payment in payments)
            {
                if (payment["status"] == status)
                {
                    break;
                }
                index++;
            }

            if (index == payments.Count())
            {
                throw new Exception("could not find any payment which is in state: " + status);
            }

            return payments[index];
        }
    }
}
