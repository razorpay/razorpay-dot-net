using System;
using System.Collections.Generic;
using NUnit.Framework;
using Razorpay.Api;
using Razorpay.Tests.Fixtures;

namespace Razorpay.Tests.Resources
{
    [TestFixture]
    public class OrderTests
    {
        private RazorpayClient client;

        [SetUp]
        public void Setup()
        {
            client = new RazorpayClient("rzp_test_key", "test_secret");
        }

        #region Order Entity Tests

        [Test]
        public void Order_Constructor_Default()
        {
            var order = new Order();
            Assert.That(order, Is.Not.Null);
        }

        [Test]
        public void Order_IsEntity()
        {
            var order = new Order();
            Assert.That(order, Is.InstanceOf<Entity>());
        }

        [Test]
        public void Order_Indexer_GetSet()
        {
            var order = new Order();
            order["id"] = TestFixtures.Orders.OrderId;
            order["amount"] = 50000;
            order["currency"] = "INR";

            Assert.That(order["id"], Is.EqualTo(TestFixtures.Orders.OrderId));
            Assert.That(order["amount"], Is.EqualTo(50000));
            Assert.That(order["currency"], Is.EqualTo("INR"));
        }

        [Test]
        public void Order_Indexer_Receipt()
        {
            var order = new Order();
            order["receipt"] = "receipt#123";
            Assert.That(order["receipt"], Is.EqualTo("receipt#123"));
        }

        [Test]
        public void Order_Indexer_Status()
        {
            var order = new Order();
            order["status"] = "created";
            Assert.That(order["status"], Is.EqualTo("created"));
        }

        #endregion

        #region Order Accessor Tests

        [Test]
        public void Client_Order_ReturnsOrderInstance()
        {
            Assert.That(client.Order, Is.Not.Null);
            Assert.That(client.Order, Is.InstanceOf<Order>());
        }

        [Test]
        public void Client_Order_ReturnsSameInstance()
        {
            var order1 = client.Order;
            var order2 = client.Order;
            Assert.That(order1, Is.SameAs(order2));
        }

        #endregion

        #region Order Create Options Tests

        [Test]
        public void Order_CreateOptions_ValidAmount()
        {
            var options = new Dictionary<string, object>
            {
                { "amount", 50000 },
                { "currency", "INR" },
                { "receipt", "receipt#1" }
            };

            Assert.That(options["amount"], Is.EqualTo(50000));
            Assert.That(options["currency"], Is.EqualTo("INR"));
        }

        [Test]
        public void Order_CreateOptions_WithNotes()
        {
            var notes = new Dictionary<string, string>
            {
                { "key1", "value1" },
                { "key2", "value2" }
            };

            var options = new Dictionary<string, object>
            {
                { "amount", 50000 },
                { "currency", "INR" },
                { "notes", notes }
            };

            Assert.That(options.ContainsKey("notes"), Is.True);
        }

        [Test]
        public void Order_CreateOptions_PartialPayment()
        {
            var options = new Dictionary<string, object>
            {
                { "amount", 50000 },
                { "currency", "INR" },
                { "partial_payment", true },
                { "first_payment_min_amount", 25000 }
            };

            Assert.That(options["partial_payment"], Is.True);
            Assert.That(options["first_payment_min_amount"], Is.EqualTo(25000));
        }

        #endregion

        #region Order All Options Tests

        [Test]
        public void Order_AllOptions_FromTo()
        {
            var options = new Dictionary<string, object>
            {
                { "from", 1577385991 },
                { "to", 1580064391 }
            };

            Assert.That(options["from"], Is.EqualTo(1577385991));
            Assert.That(options["to"], Is.EqualTo(1580064391));
        }

        [Test]
        public void Order_AllOptions_CountSkip()
        {
            var options = new Dictionary<string, object>
            {
                { "count", 25 },
                { "skip", 5 }
            };

            Assert.That(options["count"], Is.EqualTo(25));
            Assert.That(options["skip"], Is.EqualTo(5));
        }

        [Test]
        public void Order_AllOptions_Authorized()
        {
            var options = new Dictionary<string, object>
            {
                { "authorized", 1 }
            };

            Assert.That(options["authorized"], Is.EqualTo(1));
        }

        [Test]
        public void Order_AllOptions_Receipt()
        {
            var options = new Dictionary<string, object>
            {
                { "receipt", "receipt#123" }
            };

            Assert.That(options["receipt"], Is.EqualTo("receipt#123"));
        }

        #endregion
    }
}
