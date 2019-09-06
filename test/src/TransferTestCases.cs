using Razorpay.Api;
using NUnit.Framework;
using System.Collections.Generic;

namespace RazorpayClientTest
{
    class TransferTestCases
    {
        public static void Init(string key, string secret)
        {
            Helper.client = new RazorpayClient(key, secret);
        }

        public static void CreatePaymentTransferTest()
        {
            List<Transfer> transfers = Helper.CreatePaymentTransferTest();

            Assert.AreNotSame(null, transfers);
        }

        public static void GetPaymentTransfersTest()
        {
            List<Transfer> transfers = Helper.GetPaymentTransfersTest();

            Assert.Greater(transfers.Count, 0);
        }

        public static void CreateTransferTest()
        {
            Transfer transfer = Helper.CreateTransferTest();

            Assert.AreNotSame(null, transfer);
        }

        public static void GetTransferByIdTest()
        {
            Transfer transfer = Helper.GetTransferByIdTest();

            Assert.AreNotSame(null, transfer);
        }

        public static void CreateReversalByTransferIdTest()
        {
            Reversal reversal = Helper.CreateReversalByTransferIdTest();

            Assert.AreNotSame(null, reversal);
        }

        public static void FetchReversalsByTransferIdTest()
        {
            List<Reversal> reversals = Helper.FetchReversalsByTransferIdTest();

            Assert.AreNotSame(null, reversals);
        }

        public static void PatchTransferByIdTest()
        {
            Transfer transfer = Helper.PatchTransferByIdTest();

            Assert.AreNotSame(null, transfer);
        }
    }
}