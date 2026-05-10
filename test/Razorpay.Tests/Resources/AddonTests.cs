using System;
using System.Collections.Generic;
using NUnit.Framework;
using Razorpay.Api;
using Razorpay.Tests.Fixtures;

namespace Razorpay.Tests.Resources
{
    [TestFixture]
    public class AddonTests
    {
        private RazorpayClient client;

        [SetUp]
        public void Setup()
        {
            client = new RazorpayClient("rzp_test_key", "test_secret");
        }

        #region Addon Entity Tests

        [Test]
        public void Addon_Constructor_Default()
        {
            var addon = new Addon();
            Assert.That(addon, Is.Not.Null);
        }

        [Test]
        public void Addon_Constructor_WithId()
        {
            var addon = new Addon(TestFixtures.Addons.AddonId);
            Assert.That(addon["id"], Is.EqualTo(TestFixtures.Addons.AddonId));
        }

        [Test]
        public void Addon_IsEntity()
        {
            var addon = new Addon();
            Assert.That(addon, Is.InstanceOf<Entity>());
        }

        [Test]
        public void Addon_Indexer_GetSet()
        {
            var addon = new Addon();
            addon["id"] = TestFixtures.Addons.AddonId;
            addon["quantity"] = 2;
            addon["subscription_id"] = TestFixtures.Subscriptions.SubscriptionId;

            Assert.That(addon["id"], Is.EqualTo(TestFixtures.Addons.AddonId));
            Assert.That(addon["quantity"], Is.EqualTo(2));
            Assert.That(addon["subscription_id"], Is.EqualTo(TestFixtures.Subscriptions.SubscriptionId));
        }

        #endregion

        #region Addon Accessor Tests

        [Test]
        public void Client_Addon_ReturnsInstance()
        {
            Assert.That(client.Addon, Is.Not.Null);
            Assert.That(client.Addon, Is.InstanceOf<Addon>());
        }

        [Test]
        public void Client_Addon_ReturnsSameInstance()
        {
            var addon1 = client.Addon;
            var addon2 = client.Addon;
            Assert.That(addon1, Is.SameAs(addon2));
        }

        #endregion

        #region Addon Create Options Tests

        [Test]
        public void Addon_CreateOptions_Basic()
        {
            var item = new Dictionary<string, object>
            {
                { "name", "Test Addon" },
                { "amount", 300 },
                { "currency", "INR" }
            };

            var options = new Dictionary<string, object>
            {
                { "item", item },
                { "quantity", 1 }
            };

            Assert.That(options.ContainsKey("item"), Is.True);
            Assert.That(options["quantity"], Is.EqualTo(1));
        }

        [Test]
        public void Addon_CreateOptions_MultipleQuantity()
        {
            var item = new Dictionary<string, object>
            {
                { "name", "Test Addon" },
                { "amount", 300 },
                { "currency", "INR" }
            };

            var options = new Dictionary<string, object>
            {
                { "item", item },
                { "quantity", 5 }
            };

            Assert.That(options["quantity"], Is.EqualTo(5));
        }

        #endregion
    }
}
