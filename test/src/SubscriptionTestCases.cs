using Razorpay.Api;
using NUnit.Framework;
using System.Collections.Generic;

namespace RazorpayClientTest
{
    class SubscriptionTestCases
    {
        public static void Init(string key, string secret)
        {
            Helper.client = new RazorpayClient(key, secret);
        }

        public static void CreateSubscriptionTest()
        {
            Subscription subscription = Helper.TestCreateSubscription();

            Assert.NotNull(subscription);
        }

        public static void FetchSubscriptionTest()
        {
            Subscription subscription = Helper.TestFetchSubscription();

            Assert.NotNull(subscription);
        }

        public static void FetchAllSubscriptionTest()
        {
            List<Subscription> subscriptions = Helper.TestFetchSubscriptions();

            Assert.NotNull(subscriptions);
        }

        public static void CancelCreatedSubscriptionTest()
        {
            Subscription subscription = Helper.TestCancelSubscription();

            Assert.NotNull(subscription);
        }
    }
}