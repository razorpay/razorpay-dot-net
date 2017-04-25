using System.Collections.Generic;

namespace Razorpay.Api
{
    public class RazorpayClient
    {
        protected const string Version = "1.2.0";
        protected const string BaseUrl = "https://api.razorpay.com/v1/";
        protected static string key = null;
        protected static string secret = null; 
        protected static List<Dictionary<string, string>> appsDetails = new List<Dictionary<string, string>>();
        private Payment payment = null;
        private Order order = null;
        private Customer customer = null;
        private Invoice invoice = null;
        private Token token = null;

        public RazorpayClient(string key, string secret)
        {
            RazorpayClient.Key = key;
            RazorpayClient.Secret = secret;
        }

        public static string Key
        {
            get
            {
                return key;
            }
            set 
            {
                key = value;
            }
        }

        public static string Secret
        {
            get
            {
                return secret;
            }
            set 
            {
                secret = value;
            }
        }

        public static void setAppsDetails(string title, string version)
        {
            Dictionary<string, string> appDetail = new Dictionary<string, string>();
            appDetail.Add("title", title);
            appDetail.Add("version", version);

            appsDetails.Add(appDetail);
        }

        public static List<Dictionary<string, string>> AppsDetails
        {
            get
            {
                return appsDetails;
            }
        }

        public static string getBaseUrl()
        {
            return BaseUrl;
        }

        public static string getVersion()
        {
            return Version;
        }

        public Payment Payment
        {
            get
            {
                if (payment == null)
                {
                    payment = new Payment();
                }
                return payment;
            }
        }

        public Order Order
        {
            get
            {
                if (order == null)
                {
                    order = new Order();
                }
                return order;
            }
        }

        public Customer Customer
        {
            get
            {
                if (customer == null)
                {
                    customer = new Customer();
                }
                return customer;
            }
        }

        public Invoice Invoice
        {
            get
            {
                if (invoice == null)
                {
                    invoice = new Invoice();
                }
                return invoice;
            }
        }

        public Token Token
        {
            get
            {
                if (token == null)
                {
                    token = new Token();
                }
                return token;
            }
        }
    }
}