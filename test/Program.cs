// Test file

namespace RazorpayClientTest
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            // Getting the Key ID and Key Secret from user input
            string key = args[0];
            string secret = args[1];

            RunClientTestCases(key, secret);

            RunAllPaymentTests(key, secret);

            RunAllOrderTests(key, secret);
        }

        public static void RunClientTestCases(string key, string secret)
        {
            ClientTestCases.Init(key, secret);

            ClientTestCases.TestGetKey(key);

            ClientTestCases.TestGetSecret(secret);

            ClientTestCases.TestAppsDetails();

            ClientTestCases.TestGetBaseUrl();

            ClientTestCases.TestGetVersion();
        }

        public static void RunAllPaymentTests(string key, string secret)
        {
            PaymentTestCases.Init(key, secret);

            PaymentTestCases.GetAllPaymentsTest();

            PaymentTestCases.GetPaymentById();

            PaymentTestCases.CapturePayment();

            PaymentTestCases.RefundPaymentPartial();

            PaymentTestCases.RefundPayment();

            PaymentTestCases.TestGetRefunds();

            PaymentTestCases.TestGetRefundById();
        }

        public static void RunAllOrderTests(string key, string secret)
        {
            OrderTestCases.Init(key, secret);

            OrderTestCases.TestCreateOrder();

            OrderTestCases.GetAllOrdersTest();

            OrderTestCases.GetOrderByIdTest();

            OrderTestCases.TestGetPaymentsByOrder();
        }
    }
}
