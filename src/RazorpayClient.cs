using System.Collections.Generic;

namespace Razorpay.Api
{
    public class RazorpayClient
    {
        protected const string version = "2.0.0";
        protected const string baseUrl = "https://api.razorpay.com/v1/";
        protected static string key = null;
        protected static string secret = null; 
        protected static List<Dictionary<string, string>> appsDetails = new List<Dictionary<string, string>>();
        private Payment payment = null;
        private Order order = null;
        private Refund refund = null;
        private Customer customer = null;
        private Invoice invoice = null;
        private Card card = null;
        private Transfer transfer = null;
        private Addon addon = null;
        private Plan plan = null;
        private Subscription subscription = null;
        private VirtualAccount virtualaccount = null;

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
            private set 
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
            private set 
            {
                secret = value;
            }
        }

        public static List<Dictionary<string, string>> AppsDetails
        {
            get
            {
                return appsDetails;
            }
        }

        public static void setAppsDetails(string title, string version)
        {
            Dictionary<string, string> appDetail = new Dictionary<string, string>();
            appDetail.Add("title", title);
            appDetail.Add("version", version);

            appsDetails.Add(appDetail);
        }

        public static string BaseUrl
        {
            get
            {
                return baseUrl;
            }
        }

        public static string Version
        {
            get
            {
                return version;
            }
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

        public Refund Refund
        {
            get
            {
                if (refund == null)
                {
                    refund = new Refund();
                }
                return refund;
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

        public Card Card
        {
            get
            {
                if (card == null)
                {
                    card = new Card();
                }
                return card;
            }
        }

        public Transfer Transfer
        {
            get
            {
                if (transfer == null)
                {
                    transfer = new Transfer();
                }
                return transfer;
            }
        }

        public Addon Addon
        {
            get 
            {
                if (addon == null)
                {
                    addon = new Addon();
                }
                return addon;
            }
        }

        public Plan Plan 
        {
            get 
            {
                if (plan == null)
                {
                    plan = new Plan();
                }
                return plan;
            }
        }

        public Subscription Subscription
        {
            get 
            {
                if (subscription == null)
                {
                    subscription = new Subscription();
                }
                return subscription;
            }
        }

        public VirtualAccount VirtualAccount
        {
            get 
            {
                if (virtualaccount == null)
                {
                    virtualaccount = new VirtualAccount();
                }
                return virtualaccount;
            }
        }
    }
}