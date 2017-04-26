﻿// Test file

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

            RunAllUtilsTests(key, secret);

            RunAllCustomerTests(key, secret);

            RunAllInvoiceTests(key, secret);

            RunAllTokenTests(key, secret);

            RunAllCardTests(key, secret);

            RunAllTransferTests(key, secret);
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

        public static void RunAllUtilsTests(string key, string secret)
        {
            UtilsTestCases.Init(key, secret);

            UtilsTestCases.VerifyPaymentSignatureTest();

            UtilsTestCases.FailedVerifyPaymentSignatureTest();

            UtilsTestCases.VerifyWebhookSignatureTest();

            UtilsTestCases.FailedVerifyWebhookSignatureTest();
        }

        public static void RunAllCustomerTests(string key, string secret)
        {
            CustomerTestCases.Init(key, secret);

            CustomerTestCases.CreateCustomerTest();

            CustomerTestCases.FetchCustomerTest();

            CustomerTestCases.EditCustomerTest();

            CustomerTestCases.GetCustomerTokenTest();
        }

        public static void RunAllInvoiceTests(string key, string secret)
        {
            InvoiceTestCases.Init(key, secret);

            InvoiceTestCases.CreateInvoiceTest();

            InvoiceTestCases.FetchInvoiceTest();
        }

        public static void RunAllTokenTests(string key, string secret)
        {
            TokenTestCases.Init(key, secret);

            TokenTestCases.FetchAllTokenTest();

            TokenTestCases.FetchTokenByIdTest();

            TokenTestCases.DeleteTokenByIdTest();
        }

        public static void RunAllCardTests(string key, string secret)
        {
            CardTestCases.Init(key, secret);

            CardTestCases.FetchCardByIdTest();
        }

        public static void RunAllTransferTests(string key, string secret)
        {
            TransferTestCases.Init(key, secret);

            TransferTestCases.CreatePaymentTransferTest();

            TransferTestCases.GetPaymentTransfersTest();

            TransferTestCases.CreateTransferTest();

            TransferTestCases.GetTransferByIdTest();

            TransferTestCases.CreateReversalByTransferIdTest();

            TransferTestCases.PatchTransferByIdTest();
        }
    }
}
