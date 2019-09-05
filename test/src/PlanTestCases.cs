using Razorpay.Api;
using NUnit.Framework;
using System.Collections.Generic;

namespace RazorpayClientTest
{
    class PlanTestCases
    {
        public static void Init(string key, string secret, string baseUrl)
        {
            Helper.client = new RazorpayClient(key, secret, baseUrl);
        }

        public static void PlanFetchTest()
        {
            Plan plan = Helper.TestFetchPlan();

            Assert.NotNull(plan);
        }

        public static void PlanCreateTest()
        {
            Plan plan = Helper.TestCreatePlan();

            Assert.NotNull(plan);
        }

        public static void PlanFetchAllTest()
        {
            List<Plan> plans = Helper.TestFetchAllPlans();

            Assert.NotNull(plans);
        }
    }
}