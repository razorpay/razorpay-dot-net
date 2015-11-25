namespace Razorpay.Api
{
    public class RazorpayClient
    {
        public const string Version = "1.0.0";
        public const string BaseUrl = "https://api.razorpay.com/v1/";
        public static string Key = null;
        public static string Secret = null;
        private Payment payment = null;

        public RazorpayClient(string key, string secret)
        {
            RazorpayClient.Key = key;
            RazorpayClient.Secret = secret;        
        }

        public Payment Payment
        {
            get
            {
                if(payment == null)
                {
                    payment = new Payment();
                }
                return payment;
            }
        }

    }
}