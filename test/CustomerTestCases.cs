using System;
using Newtonsoft.Json;
using Razorpay.Api;
using NUnit.Framework;

namespace RazorpayClientTest
{
    class CustomerTestCases
    {
        public static void Init(string key, string secret)
        {
            Helper.client = new RazorpayClient(key, secret);
        }

        public static void CreateCustomerTest()
        {
            Customer customer = Helper.TestCreateCustomer();

            Assert.AreNotSame(null, customer);
            Assert.AreEqual("customer", (string)customer["entity"]);
        }

        public static void FetchCustomerTest()
        {
            Customer customer = Helper.TestCreateCustomer();

            Customer fetchedCustomer = Helper.TestFetchCustomer(customer);

            Assert.IsTrue(customer["id"] == fetchedCustomer["id"]);
        }

        public static void EditCustomerTest()
        {
            Customer customer = Helper.TestCreateCustomer();

            Customer editedCustomer = Helper.TestEditCustomer(customer);

            Assert.AreNotSame(null, editedCustomer);
            Assert.IsFalse(customer == editedCustomer);
        }

        public static void GetCustomerTokenTest()
        {
            Customer customer = Helper.TestCreateCustomer();

            Token token = Helper.TestGetCustomerToken(customer);

            Assert.AreNotSame(null, token);
        }
    }
}