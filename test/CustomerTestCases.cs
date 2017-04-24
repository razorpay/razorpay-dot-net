using Razorpay.Api;
using NUnit.Framework;

namespace RazorpayClientTest
{
    public class CustomerTestCases
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
    }
}