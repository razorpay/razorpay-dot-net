using System;
using Razorpay.Api;
using NUnit.Framework;

namespace RazorpayClientTest
{
    class InvoiceTestCases
    {
        public static void Init(string key, string secret, string baseUrl)
        {
            Helper.client = new RazorpayClient(key, secret, baseUrl);
        }

        public static void CreateInvoiceTest()
        {
            Invoice invoice = Helper.TestCreateInvoice();

            Assert.AreNotSame(null, invoice);
        }

        public static void FetchInvoiceTest()
        {
            Invoice invoice = Helper.TestCreateInvoice();

            Invoice fetchedInvoice = Helper.TestFetchInvoice(invoice);

            Assert.IsTrue(invoice["id"] == fetchedInvoice["id"]);
        }
    }
}