// Test file

namespace RazorpayClientTest
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            // Getting the Key ID, Key Secret and Base Url from user input            
            string key = args[0];
            string secret = args[1];
            string baseUrl = args[2];

            RunClientTestCases(key, secret, baseUrl);

            RunAllPaymentTests(key, secret, baseUrl);

            RunAllRefundTests(key, secret, baseUrl);

            RunAllOrderTests(key, secret, baseUrl);

            RunAllUtilsTests(key, secret, baseUrl);

            RunAllCustomerTests(key, secret, baseUrl);

            RunAllInvoiceTests(key, secret, baseUrl);

            RunAllCardTests(key, secret, baseUrl);

            RunAllTransferTests(key, secret, baseUrl);

            RunAllPlanTests(key, secret, baseUrl);

            RunAllSubscriptionTests(key, secret, baseUrl);

            RunAllAddonTests(key, secret, baseUrl);

            RunAllVirtualAccountTests(key, secret, baseUrl);
        }

        public static void RunClientTestCases(string key, string secret, string baseUrl)
        {
            ClientTestCases.Init(key, secret, baseUrl);

            ClientTestCases.TestGetKey(key);

            ClientTestCases.TestGetSecret(secret);

            ClientTestCases.TestAppsDetails();

            ClientTestCases.TestHeaders();

            ClientTestCases.TestGetBaseUrl();

            ClientTestCases.TestGetVersion();
        }

        public static void RunAllPaymentTests(string key, string secret, string baseUrl)
        {
            PaymentTestCases.Init(key, secret, baseUrl);

            PaymentTestCases.GetAllPaymentsTest();

            PaymentTestCases.GetPaymentById();

            PaymentTestCases.CapturePayment();

            PaymentTestCases.RefundPaymentPartial();

            PaymentTestCases.RefundPayment();

            PaymentTestCases.TestGetRefunds();

            PaymentTestCases.TestGetRefundById();
        }

        public static void RunAllRefundTests(string key, string secret, string baseUrl)
        {
            RefundTestCases.Init(key, secret, baseUrl);

            RefundTestCases.FetchAllRefundsTest();

            RefundTestCases.FetchRefundTest();

            RefundTestCases.CreateRefundTest();
        }

        public static void RunAllOrderTests(string key, string secret, string baseUrl)
        {
            OrderTestCases.Init(key, secret, baseUrl);

            OrderTestCases.TestCreateOrder();

            OrderTestCases.GetAllOrdersTest();

            OrderTestCases.GetOrderByIdTest();

            OrderTestCases.TestGetPaymentsByOrder();
        }

        public static void RunAllUtilsTests(string key, string secret, string baseUrl)
        {
            UtilsTestCases.Init(key, secret, baseUrl);

            UtilsTestCases.VerifyPaymentSignatureTest();

            UtilsTestCases.FailedVerifyPaymentSignatureTest();

            UtilsTestCases.VerifyWebhookSignatureTest();

            UtilsTestCases.FailedVerifyWebhookSignatureTest();
        }

        public static void RunAllCustomerTests(string key, string secret, string baseUrl)
        {
            CustomerTestCases.Init(key, secret, baseUrl);

            CustomerTestCases.CreateCustomerTest();

            CustomerTestCases.FetchCustomerTest();

            CustomerTestCases.EditCustomerTest();

            CustomerTestCases.GetCustomerTokenTest();

            CustomerTestCases.GetAllCustomerTokens();

            CustomerTestCases.DeleteTokenByIdTest();
        }

        public static void RunAllInvoiceTests(string key, string secret, string baseUrl)
        {
            InvoiceTestCases.Init(key, secret, baseUrl);

            InvoiceTestCases.CreateInvoiceTest();

            InvoiceTestCases.FetchInvoiceTest();
        }

        public static void RunAllCardTests(string key, string secret, string baseUrl)
        {
            CardTestCases.Init(key, secret, baseUrl);

            CardTestCases.FetchCardByIdTest();
        }

        public static void RunAllTransferTests(string key, string secret, string baseUrl)
        {
            TransferTestCases.Init(key, secret, baseUrl);

            TransferTestCases.CreatePaymentTransferTest();

            TransferTestCases.GetPaymentTransfersTest();

            TransferTestCases.CreateTransferTest();

            TransferTestCases.GetTransferByIdTest();

            TransferTestCases.CreateReversalByTransferIdTest();

            TransferTestCases.FetchReversalsByTransferIdTest();

            TransferTestCases.PatchTransferByIdTest();
        }

        public static void RunAllPlanTests(string key, string secret, string baseUrl)
        {
            PlanTestCases.Init(key, secret, baseUrl);

            PlanTestCases.PlanFetchTest();

            PlanTestCases.PlanCreateTest();

            PlanTestCases.PlanFetchAllTest();
        }

        public static void RunAllSubscriptionTests(string key, string secret, string baseUrl)
        {
            SubscriptionTestCases.Init(key, secret, baseUrl);

            SubscriptionTestCases.CreateSubscriptionTest();

            SubscriptionTestCases.FetchSubscriptionTest();

            SubscriptionTestCases.FetchAllSubscriptionTest();

            SubscriptionTestCases.CancelCreatedSubscriptionTest();
        }

        public static void RunAllAddonTests(string key, string secret, string baseUrl)
        {
            AddonTestCases.Init(key, secret, baseUrl);

            AddonTestCases.CreateAddonTest();

            AddonTestCases.FetchAddonTest();

            AddonTestCases.DeleteAddonTest();
        }

        public static void RunAllVirtualAccountTests(string key, string secret, string baseUrl)
        {
            VirtualAccountTestCases.Init(key, secret, baseUrl);

            VirtualAccountTestCases.CreateVirtualAccountTest();

            VirtualAccountTestCases.FetchVirtualAccountTest();

            VirtualAccountTestCases.EditVirtualAccountTest();

            VirtualAccountTestCases.CloseVirtualAccountTest();

            VirtualAccountTestCases.VirtualAccountPaymentsTest();

            VirtualAccountTestCases.FetchAllVirtualAccountTest();
        }
    }
}
