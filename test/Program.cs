// Test file

namespace RazorpayClientTest
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string key = "<api-key>";

            string secret = "<api-secret>";

            PaymentTestCases.Init(key, secret);

            PaymentTestCases.GetAllPaymentsTest();

            PaymentTestCases.GetPaymentById();

            PaymentTestCases.CapturePayment();

            PaymentTestCases.RefundPaymentPartial();

            PaymentTestCases.RefundPayment();

            PaymentTestCases.TestGetRefunds();

            PaymentTestCases.TestGetRefundById();


            OrderTestCases.Init(key, secret);

            OrderTestCases.TestCreateOrder();

            OrderTestCases.GetAllOrdersTest();

            OrderTestCases.GetOrderByIdTest();

            OrderTestCases.TestGetPaymentsByOrder();
        }
    }
}
