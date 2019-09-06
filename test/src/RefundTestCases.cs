using Razorpay.Api;
using NUnit.Framework;
using System.Collections.Generic;

namespace RazorpayClientTest
{
    class RefundTestCases
    {
        public static void Init(string key, string secret)
        {
            Helper.client = new RazorpayClient(key, secret);
        }

        public static void FetchAllRefundsTest()
        {
            List<Refund> refund = Helper.TestFetchAllRefunds();

            Assert.AreNotSame(null, refund);
        }

        public static void FetchRefundTest()
        {
            Refund refund = Helper.TestFetchSingleRefund();

            Assert.AreNotSame(null, refund);
        }

        public static void CreateRefundTest()
        {
            Refund refund = Helper.TestCreateDirectRefund();

            Assert.AreNotSame(null, refund);
        }
    }
}