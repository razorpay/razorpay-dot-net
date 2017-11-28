using Razorpay.Api;
using NUnit.Framework;
using System.Collections.Generic;

namespace RazorpayClientTest
{
    class VirtualAccountTestCases
    {
        public static void Init(string key, string secret)
        {
            Helper.client = new RazorpayClient(key, secret);
        }

        public static void CreateVirtualAccountTest()
        {
            VirtualAccount va = Helper.VirtualAccountCreateTest();

            Assert.NotNull(va);
        }

        public static void FetchVirtualAccountTest()
        {
            VirtualAccount va = Helper.VirtualAccountFetchTest();

            Assert.NotNull(va);
        }

        public static void EditVirtualAccountTest()
        {
            VirtualAccount va = Helper.VirtualAccountEditTest();

            Assert.NotNull(va);
        }

        public static void CloseVirtualAccountTest()
        {
            VirtualAccount va = Helper.VirtualAccountCloseTest();

            Assert.NotNull(va);
        }

        public static void VirtualAccountPaymentsTest()
        {
            List<Payment> payments = Helper.FetchAllPaymentsFromVa();

            Assert.NotNull(payments);
        }

        public static void FetchAllVirtualAccountTest()
        {
            List<VirtualAccount> va = Helper.FetchAllVirtualAccountTest();

            Assert.NotNull(va);
        }
    }
}