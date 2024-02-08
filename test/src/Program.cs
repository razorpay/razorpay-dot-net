// Test file

namespace RazorpayClientTest
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            // Getting the Key ID, Key Secret and Base Url from user input    
            string key = args[0];
            string secret = args[1] ;

            RunClientTestCases(key, secret);

            RunAllPaymentTests(key, secret);

            RunAllRefundTests(key, secret);

            RunAllOrderTests(key, secret);

            RunAllUtilsTests(key, secret);

            RunAllCustomerTests(key, secret);

            RunAllInvoiceTests(key, secret);

            RunAllCardTests(key, secret);

            RunAllTransferTests(key, secret);

            RunAllPlanTests(key, secret);

            RunAllSubscriptionTests(key, secret);

            RunAllAddonTests(key, secret);

            RunAllVirtualAccountTests(key, secret);

            RunAllOAuthClientTests();
            
            RunAllOAuthPaymentTests(key);
        }

        public static void RunClientTestCases(string key, string secret)
        {
            ClientTestCases.Init(key, secret);

            ClientTestCases.TestGetKey(key);

            ClientTestCases.TestGetSecret(secret);

            ClientTestCases.TestAppsDetails();

            ClientTestCases.TestHeaders();

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

        public static void RunAllRefundTests(string key, string secret)
        {
            RefundTestCases.Init(key, secret);

            RefundTestCases.FetchAllRefundsTest();

            RefundTestCases.FetchRefundTest();

            RefundTestCases.CreateRefundTest();
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

            CustomerTestCases.GetAllCustomerTokens();

            CustomerTestCases.DeleteTokenByIdTest();
        }

        public static void RunAllInvoiceTests(string key, string secret)
        {
            InvoiceTestCases.Init(key, secret);

            InvoiceTestCases.CreateInvoiceTest();

            InvoiceTestCases.FetchInvoiceTest();
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

            TransferTestCases.FetchReversalsByTransferIdTest();

            TransferTestCases.PatchTransferByIdTest();
        }

        public static void RunAllPlanTests(string key, string secret)
        {
            PlanTestCases.Init(key, secret);

            PlanTestCases.PlanFetchTest();

            PlanTestCases.PlanCreateTest();

            PlanTestCases.PlanFetchAllTest();
        }

        public static void RunAllSubscriptionTests(string key, string secret)
        {
            SubscriptionTestCases.Init(key, secret);

            SubscriptionTestCases.CreateSubscriptionTest();

            SubscriptionTestCases.FetchSubscriptionTest();

            SubscriptionTestCases.FetchAllSubscriptionTest();

            SubscriptionTestCases.CancelCreatedSubscriptionTest();
        }

        public static void RunAllAddonTests(string key, string secret)
        {
            AddonTestCases.Init(key, secret);

            AddonTestCases.CreateAddonTest();

            AddonTestCases.FetchAddonTest();

            AddonTestCases.DeleteAddonTest();
        }

        public static void RunAllVirtualAccountTests(string key, string secret)
        {
            VirtualAccountTestCases.Init(key, secret);

            VirtualAccountTestCases.CreateVirtualAccountTest();

            VirtualAccountTestCases.FetchVirtualAccountTest();

            VirtualAccountTestCases.EditVirtualAccountTest();

            VirtualAccountTestCases.CloseVirtualAccountTest();

            VirtualAccountTestCases.VirtualAccountPaymentsTest();

            VirtualAccountTestCases.FetchAllVirtualAccountTest();
        }
        
        public static void RunAllOAuthClientTests()
        {
            OAuthClientTestCases.Init();
            
            OAuthClientTestCases.GetAuthUrlTest();
            
            OAuthClientTestCases.RequestValidationFailureForGetAuthUrlTest();
            
            OAuthClientTestCases.GetAccessTokenTest();
            
            OAuthClientTestCases.RequestValidationFailureForGetAccessTokenTest();
            
            OAuthClientTestCases.RefreshTokenTest();
            
            OAuthClientTestCases.RequestValidationFailureForRefreshTokenTest();
            
            OAuthClientTestCases.RevokeTokenTest();
            
            OAuthClientTestCases.RequestValidationFailureForRevokeTokenTest();
        }
        
        public static void RunAllOAuthPaymentTests(string accessToken)
        {
            PaymentOAuthTestCases.Init(accessToken);

            PaymentOAuthTestCases.GetAllPaymentsTest();

            PaymentOAuthTestCases.GetPaymentById();

            PaymentOAuthTestCases.CapturePayment();
            
            PaymentOAuthTestCases.RefundPayment();
        }
    }
}
