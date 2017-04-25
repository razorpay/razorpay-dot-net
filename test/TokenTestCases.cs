using System;
using Razorpay.Api;
using NUnit.Framework;
using System.Collections.Generic;

namespace RazorpayClientTest
{
    class TokenTestCases
    {
        public static void Init(string key, string secret)
        {
            Helper.client = new RazorpayClient(key, secret);
        }

        public static void FetchAllTokenTest()
        {
            Customer customer = Helper.TestCreateCustomer();

            Token token = Helper.TestGetCustomerToken(customer);

            List<Token> fetchedTokens = Helper.TestFetchAllCustomerToken(token);

            Assert.Greater(fetchedTokens.Count, 0);
        }

        public static void FetchTokenByIdTest()
        {
            Customer customer = Helper.TestCreateCustomer();

            Token token = Helper.TestGetCustomerToken(customer);

            Token fetchedTokenById = Helper.TestFetchCustomerTokenById(token);

            Assert.AreNotSame(null, fetchedTokenById);
        }
    }
}