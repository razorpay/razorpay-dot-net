using System.Collections.Generic;

namespace Razorpay.Api
{
    public class RazorpayClient
    {
        protected const string Version = "1.2.0";
        protected const string BaseUrl = "https://api.razorpay.com/v1/";
        protected static string Key = null;
        protected static string Secret = null; 
        protected static Dictionary<string, string> appsDetails = new Dictionary<string, string>();
        private Payment payment = null;
        private Order order = null;

        public RazorpayClient(string key, string secret)
        {
            RazorpayClient.Key = key;
            RazorpayClient.Secret = secret;
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
            appsDetails.Add(title, version);
        }

        public static Dictionary<string, string> getAppsDetails()
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
    }
}