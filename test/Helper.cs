
using System;
using System.IO;
using System.Text;
using System.Linq;
using Razorpay.Api;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace RazorpayClientTest
{
    public class Helper
    {
        private static string alphaNum = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        private static string num = "0123456789";

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

        public static Customer TestCreateCustomer()
        {
            Dictionary<string, object> data = new Dictionary<string, object>();

            string name = generateRandomString(10, true);
            string number = generateRandomString(10, false);

            data.Add("name", name);
            data.Add("email", string.Format("{0}@gmail.com", name));
            data.Add("contact", number);

            return Helper.client.Customer.Create(data);
        }

        public static Customer TestFetchCustomer(Customer customer)
        {
            string id = (string) customer["id"];

            return Helper.client.Customer.Fetch(id);
        }

        public static Customer TestEditCustomer(Customer customer)
        {
            Dictionary<string, object> data = new Dictionary<string, object>();

            string name = generateRandomString(11, true);
            string number = generateRandomString(11, false);

            data.Add("name", name);
            data.Add("email", string.Format("{0}@gmail.com", name));
            data.Add("contact", number);

            return customer.Edit(data);
        }

        public static Token TestGetCustomerToken(Customer customer)
        {
            return customer.Tokens();
        }

        // returns Invoice
        public static Invoice TestCreateInvoice()
        {
            Dictionary<string, object> items = new Dictionary<string, object>();

            using (StreamReader r = new StreamReader("./test/data/invoice-create.json"))
            {
                string json = r.ReadToEnd();
                items = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
            }

            // Different receipt each time
            items["receipt"] = generateRandomString(14, false);

            return Helper.client.Invoice.Create(items);
        }

        public static Invoice TestFetchInvoice(Invoice invoice)
        {
            string id = invoice["id"];

            return Helper.client.Invoice.Fetch(id);
        }

        // public static Token TestFetchCustomerToken(Token token)
        // {
        //     List<Token> tokens = token.All();

        //     return tokens[0];
        // }

        public static string generateRandomString(int length, bool alphaNumeric)
        {
            Random random = new Random();
            string characters = string.Empty;

            characters = (alphaNumeric == true) ? alphaNum : num;
            
            StringBuilder result = new StringBuilder(length);

            for (int i = 0; i < length; i++) {
                result.Append(characters[random.Next(characters.Length)]);
            }
            return result.ToString();
        }   
    }
}
