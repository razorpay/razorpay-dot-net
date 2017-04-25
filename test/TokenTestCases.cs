using Razorpay.Api;
using System;
using Newtonsoft.Json;

namespace RazorpayClientTest
{
    public class TokenTestCases
    {
        public static void Init(string key, string secret)
        {
            Helper.client = new RazorpayClient(key, secret);
        }

        // public static void CreateTokenTest()
        // {
        //     Customer customer = Helper.TestCreateCustomer();

        //     Token token = Helper.TestGetCustomerToken(customer);

        //     Token fetchedToken = Helper.TestFetchCustomerToken(token);

        //     Console.Write(fetchedToken["id"]);
        // }
    }
}