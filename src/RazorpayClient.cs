using System.Collections.Generic;

namespace Razorpay.Api
{
    public class RazorpayClient
    {
        protected const string Version = "1.2.0";
        protected const string BaseUrl = "https://api.razorpay.com/v1/";
        protected static string Key = null;
        protected static string Secret = null; 
        protected static List<Dictionary<string, string>> appsDetails = new List<Dictionary<string, string>>();
        private Payment payment = null;
        private Order order = null;
        private Utils utils = null;

        public RazorpayClient(string key, string secret)
        {
            RazorpayClient.Key = key;
            RazorpayClient.Secret = secret;
        }

        public static string getKey()
        {
            return Key;
        }

        public static string getSecret()
        {
            return Secret;
        }

        public static void setAppsDetails(string title, string version)
        {
            Dictionary<string, string> appDetail = new Dictionary<string, string>();
            appDetail.Add("title", title);
            appDetail.Add("version", version);

            appsDetails.Add(appDetail);
        }

        public static List<Dictionary<string, string>> getAppsDetails()
        {
            return appsDetails;
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

        public Utils Utils
        {
            get
            {
                if (utils == null)
                {
                    utils = new Utils();
                }
                return utils;
            }
        }
    }
}