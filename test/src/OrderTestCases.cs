using NUnit.Framework;
using Razorpay.Api;
using System.Collections.Generic;

namespace RazorpayClientTest
{
    public class OrderTestCases
    {
        public static void Init(string key, string secret)
        {
            Helper.client = new RazorpayClient(key, secret);
        }

        public static void GetAllOrdersTest()
        {
            List<Order> result = Helper.TestGetAllOrders();
            Assert.AreNotSame(null, result);
        }

        public static void GetOrderByIdTest()
        {
            Order order = Helper.TestGetOrderById();
            Assert.AreNotSame(null, order);
        }

        public static void TestCreateOrder()
        {
            Order result = Helper.TestCreateOrder();
            Assert.AreNotSame(null, result);
        }

        public static void TestGetPaymentsByOrder()
        {
            List<Payment> result = Helper.TestGetPaymentByOrderId();
            Assert.AreNotSame(null, result);
        }
    }
}
