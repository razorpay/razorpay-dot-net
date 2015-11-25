using Razorpay.Api;
using System;
using System.Collections.Generic;

namespace RPTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string key = "rzp_test_1DP5mmOlF5G5ag";
            string secret = "thisissupersecret";
            RazorpayClient api = new RazorpayClient(key, secret);

            
            Dictionary<string, object> paymentFilters = new Dictionary<string, object>();
            paymentFilters.Add("from", "1400826740");
            paymentFilters.Add("to", "2400826740");
            paymentFilters.Add("skip", "100");


            dynamic payments = api.Payment.All(paymentFilters);
            dynamic onePayment = null;

            foreach(dynamic payment in payments["items"])
            {
                if (payment["status"].ToString().Equals("authorized"))
                {
                    onePayment = payment;
                    break;
                }
            }
            
            dynamic onePay = api.Payment.Fetch(onePayment["id"].ToString());

            Dictionary<string, object> capturePostData = new Dictionary<string, object>();
            capturePostData.Add("amount", onePay["amount"]);
            string id = onePay["id"].ToString();

            dynamic capturedPayment = api.Payment.Capture(id, capturePostData);
            dynamic refundedPayment = api.Payment.Refund(id);
            

            id = "pay_4PWh7dn94hYYzf";
            dynamic refunds = api.Payment[id].All();
            dynamic oneRefund = refunds["items"][0];
            dynamic refund = api.Payment[id].Fetch(oneRefund["id"].ToString());
            
            
        }
    }
}
