using Razorpay.Api;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RazorpayClientTest
{
    public class Helper
    {
        public static RazorpayClient client;

        public static List<Order> TestGetAllOrders()
        {
            Dictionary<string, object> options = new Dictionary<string, object>();

            DateTime endTime = DateTime.UtcNow;
            DateTime startTime = endTime.Add(TimeSpan.FromHours(-1800));
            options.Add("from", Utils.ToUnixTimestamp(startTime));
            options.Add("to", Utils.ToUnixTimestamp(endTime));

            List<Order> result = Helper.client.Order.All(options);
            return result;
        }

        public static Order TestGetOrderById()
        {
            List<Order> result = TestGetAllOrders();
            Order testEntity = result[0];
            string orderId = testEntity["id"].ToString();

            Order order = Helper.client.Order.Fetch(orderId);
            return order;
        }


        public static List<Payment> TestGetAllPayments()
        {
            Dictionary<string, object> options = new Dictionary<string, object>();

            DateTime endTime = DateTime.UtcNow;
            DateTime startTime = endTime.Add(TimeSpan.FromHours(-1800));
            options.Add("from", Utils.ToUnixTimestamp(startTime));
            options.Add("to", Utils.ToUnixTimestamp(endTime));

            List<Payment> result = Helper.client.Payment.All(options);
            return result;
        }

        public static Payment TestGetPaymentById()
        {
            List<Payment> result = TestGetAllPayments();
            Payment testEntity = result[0];
            string paymentId = testEntity["id"].ToString();

            Payment payment = Helper.client.Payment.Fetch(paymentId);

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

        public static Refund TestPartialRefundPayment()
        {
            List<Payment> payments = TestGetAllPayments();
            Payment paymentCaptured = FindPaymentWithStatus("captured", payments);

            Dictionary<string, object> data = new Dictionary<string, object>();
            data.Add("amount", "100");
            Refund refund = paymentCaptured.Refund(data);

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

        public static Order TestCreateOrder()
        {
            Dictionary<string, object> options = new Dictionary<string, object>();
            options.Add("amount", "1000");
            options.Add("currency", "INR");
            options.Add("receipt", "123");

            Order order = client.Order.Create(options);
            return order;
        }

        public static List<Payment> TestGetPaymentByOrderId()
        {
            List<Order> orders = TestGetAllOrders();
            Order order = orders[orders.Count() - 1];

            List<Payment> payments = order.Payments();
            return payments;
        }

        public static void TestVerifyPaymentSignature()
        {
            Dictionary<string, string> attributes = new Dictionary<string, string>();

            attributes.Add("razorpay_payment_id", "pay_1234567890");
            attributes.Add("razorpay_order_id", "order_123456789");
            attributes.Add("razorpay_signature", "1dcae2ddc7994c1a9b10a9e52a840d705dc9e9c5d48dc5ec04413aa4866a0784");

            Utils.verifyPaymentSignature(attributes);
        }

        public static void TestFailedVerifyPaymentSignature()
        {
            Dictionary<string, string> attributes = new Dictionary<string, string>();

            attributes.Add("razorpay_payment_id", "pay_1234567890");
            attributes.Add("razorpay_order_id", "order_123456789");
            attributes.Add("razorpay_signature", "this_hash_will_fail_signature_validation");   

            Utils.verifyPaymentSignature(attributes);
        }

        public static void TestVerifyWebhookSignature()
        {
            string payload = string.Format("{0}|{1}", "order_123456789", "pay_1234567890");
            string expected = "1dcae2ddc7994c1a9b10a9e52a840d705dc9e9c5d48dc5ec04413aa4866a0784";

            Utils.verifyWebhookSignature(payload, expected);
        }

        public static void TestFailedVerifyWebhookSignature()
        {
            string payload = string.Format("{0}|{1}", "pay_1234567890", "order_123456789");
            string expected = "this_hash_will_fail_signature_validation";

            Utils.verifyWebhookSignature(payload, expected);
        }
    }
}
