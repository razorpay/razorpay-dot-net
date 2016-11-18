using Razorpay.Api;
using System.Collections.Generic;
using System.Diagnostics;

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
            Debug.Assert(result != null);
        }

        public static void GetOrderByIdTest()
        {
            Order order = Helper.TestGetOrderById();
            Debug.Assert(order != null);
        }

        public static void TestCreateOrder()
        {
            Order result = Helper.TestCreateOrder();
            Debug.Assert(result != null);
        }

        public static void TestGetPaymentsByOrder()
        {
            List<Payment> result = Helper.TestGetPaymentByOrderId();
            Debug.Assert(result != null);
        }
    }
}
