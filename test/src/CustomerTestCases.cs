using Razorpay.Api;
using NUnit.Framework;
using System.Collections.Generic;

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
            Customer customer = Helper.TestCreateCustomerEntity();

            Customer fetchedCustomer = Helper.TestFetchCustomer(customer);

            Assert.IsTrue(customer["id"] == (string)fetchedCustomer["id"]);
        }

        public static void EditCustomerTest()
        {
            Customer customer = Helper.TestCreateCustomer();
            string name = customer["name"];

            Customer editedCustomer = Helper.TestEditCustomer(customer);

            Assert.AreNotSame(null, editedCustomer);
            Assert.IsFalse(name == (string)editedCustomer["name"]);
        }

        public static void GetCustomerTokenTest()
        {
            Customer customer = Helper.TestCreateCustomerEntity();

            Token token = Helper.TestFetchCustomerTokenById(customer);

            Assert.AreNotSame(null, token);
        }

        public static void GetAllCustomerTokens()
        {
            Customer customer = Helper.TestCreateCustomerEntity();

            List<Token> tokens = Helper.TestFetchAllCustomerToken(customer);

            Assert.AreNotSame(null, tokens);
        }

        public static void DeleteTokenByIdTest()
        {
            Customer customer = Helper.TestCreateCustomerEntity();

            // Throws exception if delete failed
            Helper.TestDeleteCustomerTokenById(customer);

            Assert.IsTrue(true);
        }
    }
}