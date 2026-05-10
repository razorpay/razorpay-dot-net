using System;
using System.Collections.Generic;
using NUnit.Framework;
using Razorpay.Api;
using Razorpay.Tests.Fixtures;

namespace Razorpay.Tests.Resources
{
    [TestFixture]
    public class SubscriptionTests
    {
        private RazorpayClient client;

        [SetUp]
        public void Setup()
        {
            client = new RazorpayClient("rzp_test_key", "test_secret");
        }

        #region Subscription Entity Tests

        [Test]
        public void Subscription_Constructor_Default()
        {
            var subscription = new Subscription();
            Assert.That(subscription, Is.Not.Null);
        }

        [Test]
        public void Subscription_Constructor_WithId()
        {
            var subscription = new Subscription(TestFixtures.Subscriptions.SubscriptionId);
            Assert.That(subscription["id"], Is.EqualTo(TestFixtures.Subscriptions.SubscriptionId));
        }

        [Test]
        public void Subscription_IsEntity()
        {
            var subscription = new Subscription();
            Assert.That(subscription, Is.InstanceOf<Entity>());
        }

        [Test]
        public void Subscription_Indexer_GetSet()
        {
            var subscription = new Subscription();
            subscription["plan_id"] = TestFixtures.Plans.PlanId;
            subscription["status"] = "active";
            subscription["quantity"] = 1;

            Assert.That(subscription["plan_id"], Is.EqualTo(TestFixtures.Plans.PlanId));
            Assert.That(subscription["status"], Is.EqualTo("active"));
            Assert.That(subscription["quantity"], Is.EqualTo(1));
        }

        #endregion

        #region Subscription Accessor Tests

        [Test]
        public void Client_Subscription_ReturnsSubscriptionInstance()
        {
            Assert.That(client.Subscription, Is.Not.Null);
            Assert.That(client.Subscription, Is.InstanceOf<Subscription>());
        }

        [Test]
        public void Client_Subscription_ReturnsSameInstance()
        {
            var subscription1 = client.Subscription;
            var subscription2 = client.Subscription;
            Assert.That(subscription1, Is.SameAs(subscription2));
        }

        #endregion

        #region Subscription Create Options Tests

        [Test]
        public void Subscription_CreateOptions_Basic()
        {
            var options = new Dictionary<string, object>
            {
                { "plan_id", TestFixtures.Plans.PlanId },
                { "total_count", 12 }
            };

            Assert.That(options["plan_id"], Is.EqualTo(TestFixtures.Plans.PlanId));
            Assert.That(options["total_count"], Is.EqualTo(12));
        }

        [Test]
        public void Subscription_CreateOptions_WithCustomer()
        {
            var options = new Dictionary<string, object>
            {
                { "plan_id", TestFixtures.Plans.PlanId },
                { "total_count", 12 },
                { "customer_id", TestFixtures.Customers.CustomerId }
            };

            Assert.That(options["customer_id"], Is.EqualTo(TestFixtures.Customers.CustomerId));
        }

        [Test]
        public void Subscription_CreateOptions_StartAt()
        {
            var options = new Dictionary<string, object>
            {
                { "plan_id", TestFixtures.Plans.PlanId },
                { "start_at", 1577385991 }
            };

            Assert.That(options["start_at"], Is.EqualTo(1577385991));
        }

        [Test]
        public void Subscription_CreateOptions_ExpireBy()
        {
            var options = new Dictionary<string, object>
            {
                { "plan_id", TestFixtures.Plans.PlanId },
                { "expire_by", 1580064391 }
            };

            Assert.That(options["expire_by"], Is.EqualTo(1580064391));
        }

        [Test]
        public void Subscription_CreateOptions_Quantity()
        {
            var options = new Dictionary<string, object>
            {
                { "plan_id", TestFixtures.Plans.PlanId },
                { "quantity", 5 }
            };

            Assert.That(options["quantity"], Is.EqualTo(5));
        }

        #endregion

        #region Subscription Status Tests

        [Test]
        public void Subscription_Status_Created()
        {
            var subscription = new Subscription();
            subscription["status"] = "created";
            Assert.That(subscription["status"], Is.EqualTo("created"));
        }

        [Test]
        public void Subscription_Status_Authenticated()
        {
            var subscription = new Subscription();
            subscription["status"] = "authenticated";
            Assert.That(subscription["status"], Is.EqualTo("authenticated"));
        }

        [Test]
        public void Subscription_Status_Active()
        {
            var subscription = new Subscription();
            subscription["status"] = "active";
            Assert.That(subscription["status"], Is.EqualTo("active"));
        }

        [Test]
        public void Subscription_Status_Pending()
        {
            var subscription = new Subscription();
            subscription["status"] = "pending";
            Assert.That(subscription["status"], Is.EqualTo("pending"));
        }

        [Test]
        public void Subscription_Status_Halted()
        {
            var subscription = new Subscription();
            subscription["status"] = "halted";
            Assert.That(subscription["status"], Is.EqualTo("halted"));
        }

        [Test]
        public void Subscription_Status_Cancelled()
        {
            var subscription = new Subscription();
            subscription["status"] = "cancelled";
            Assert.That(subscription["status"], Is.EqualTo("cancelled"));
        }

        [Test]
        public void Subscription_Status_Completed()
        {
            var subscription = new Subscription();
            subscription["status"] = "completed";
            Assert.That(subscription["status"], Is.EqualTo("completed"));
        }

        [Test]
        public void Subscription_Status_Expired()
        {
            var subscription = new Subscription();
            subscription["status"] = "expired";
            Assert.That(subscription["status"], Is.EqualTo("expired"));
        }

        #endregion

        #region Plan Entity Tests

        [Test]
        public void Plan_Constructor_Default()
        {
            var plan = new Plan();
            Assert.That(plan, Is.Not.Null);
        }

        [Test]
        public void Plan_IsEntity()
        {
            var plan = new Plan();
            Assert.That(plan, Is.InstanceOf<Entity>());
        }

        [Test]
        public void Client_Plan_ReturnsPlanInstance()
        {
            Assert.That(client.Plan, Is.Not.Null);
            Assert.That(client.Plan, Is.InstanceOf<Plan>());
        }

        #endregion

        #region Plan Create Options Tests

        [Test]
        public void Plan_CreateOptions_Monthly()
        {
            var item = new Dictionary<string, object>
            {
                { "name", "Test Plan" },
                { "amount", 99900 },
                { "currency", "INR" }
            };

            var options = new Dictionary<string, object>
            {
                { "period", "monthly" },
                { "interval", 1 },
                { "item", item }
            };

            Assert.That(options["period"], Is.EqualTo("monthly"));
            Assert.That(options["interval"], Is.EqualTo(1));
        }

        [Test]
        public void Plan_CreateOptions_Weekly()
        {
            var options = new Dictionary<string, object>
            {
                { "period", "weekly" },
                { "interval", 2 }
            };

            Assert.That(options["period"], Is.EqualTo("weekly"));
            Assert.That(options["interval"], Is.EqualTo(2));
        }

        [Test]
        public void Plan_CreateOptions_Daily()
        {
            var options = new Dictionary<string, object>
            {
                { "period", "daily" },
                { "interval", 7 }
            };

            Assert.That(options["period"], Is.EqualTo("daily"));
        }

        [Test]
        public void Plan_CreateOptions_Yearly()
        {
            var options = new Dictionary<string, object>
            {
                { "period", "yearly" },
                { "interval", 1 }
            };

            Assert.That(options["period"], Is.EqualTo("yearly"));
        }

        #endregion
    }
}
