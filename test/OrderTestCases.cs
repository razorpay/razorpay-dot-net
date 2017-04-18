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
            Helper.Assert(result != null, "No orders retrieved");
        }

        public static void GetOrderByIdTest()
        {
            Order order = Helper.TestGetOrderById();
            Helper.Assert(order != null, "Could not retrieve order by Id");
        }

        public static void TestCreateOrder()
        {
            Order result = Helper.TestCreateOrder();
            Helper.Assert(result != null, "Could not create order");
        }

        public static void TestGetPaymentsByOrder()
        {
            List<Payment> result = Helper.TestGetPaymentByOrderId();
            Helper.Assert(result != null, "Could not get payment by order");
        }
    }
}
