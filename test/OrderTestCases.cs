using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Razorpay.Api;
using System.Collections.Generic;
using System.Diagnostics;

namespace RazorpayClientTest
{
    [TestClass]
    public class OrderTestCases
    {
        [ClassInitialize]
        public static void Init(TestContext testcontext)
        {
            Helper.client = new RazorpayClient("<api-key>", "<api-secret>");
        }

        [TestMethod]
        public void GetAllOrdersTest()
        {
            List<Order> result = Helper.TestGetAllOrders();
            Debug.Assert(result != null);
        }

        [TestMethod]
        public void GetOrderByIdTest()
        {
            Order order = Helper.TestGetOrderById();
            Debug.Assert(order != null);
        }

        [TestMethod]
        public void TestCreateOrder()
        {
            Order result = Helper.TestCreateOrder();
            Debug.Assert(result != null);
        }

        [TestMethod]
        public void TestGetPaymentsByOrder()
        {
            List<Payment> result = Helper.TestGetPaymentByOrderId();
            Debug.Assert(result != null);
        }
    }
}
