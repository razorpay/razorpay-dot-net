using System;
using System.Text;
using Razorpay.Api;
using NUnit.Framework;
using System.Collections.Generic;

namespace RazorpayClientTest
{
    public class CustomerTestCases
    {
        private static string alphaNum = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        private static string num = "0123456789";

        public static void Init(string key, string secret)
        {
            Helper.client = new RazorpayClient(key, secret);
        }

        public static void CreateCustomerTest()
        {
            Dictionary<string, object> data = new Dictionary<string, object>();

            string name = generateRandomString(10, true);
            string number = generateRandomString(10, false);

            data.Add("name", name);
            data.Add("email", string.Format("{0}@gmail.com", name));
            data.Add("contact", number);

            Customer customer = Helper.client.Customer.Create(data);

            Assert.AreNotSame(null, customer);
        }

        public static string generateRandomString(int length, bool alphaNumeric)
        {
            Random random = new Random();
            string characters = string.Empty;

            characters = (alphaNumeric == true) ? alphaNum : num;
            
            StringBuilder result = new StringBuilder(length);

            for (int i = 0; i < length; i++) {
                result.Append(characters[random.Next(characters.Length)]);
            }
            return result.ToString();
        }   
    }
}