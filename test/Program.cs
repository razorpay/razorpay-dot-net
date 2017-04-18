// Test file
using System;

namespace RazorpayClientTest
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            // Getting the Key ID and Key Secret from user input
            string key = args[0];
            string secret = args[1];

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
