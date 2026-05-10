using System;
using System.Collections.Generic;
using NUnit.Framework;
using Razorpay.Api;
using Razorpay.Tests.Fixtures;

namespace Razorpay.Tests.Resources
{
    [TestFixture]
    public class ItemTests
    {
        private RazorpayClient client;

        [SetUp]
        public void Setup()
        {
            client = new RazorpayClient("rzp_test_key", "test_secret");
        }

        #region Item Entity Tests

        [Test]
        public void Item_Constructor_Default()
        {
            var item = new Item();
            Assert.That(item, Is.Not.Null);
        }

        [Test]
        public void Item_IsEntity()
        {
            var item = new Item();
            Assert.That(item, Is.InstanceOf<Entity>());
        }

        [Test]
        public void Item_Indexer_GetSet()
        {
            var item = new Item();
            item["id"] = TestFixtures.Items.ItemId;
            item["name"] = "Test Item";
            item["amount"] = 100;

            Assert.That(item["id"], Is.EqualTo(TestFixtures.Items.ItemId));
            Assert.That(item["name"], Is.EqualTo("Test Item"));
            Assert.That(item["amount"], Is.EqualTo(100));
        }

        #endregion

        #region Item Accessor Tests

        [Test]
        public void Client_Item_ReturnsInstance()
        {
            Assert.That(client.Item, Is.Not.Null);
            Assert.That(client.Item, Is.InstanceOf<Item>());
        }

        [Test]
        public void Client_Item_ReturnsSameInstance()
        {
            var item1 = client.Item;
            var item2 = client.Item;
            Assert.That(item1, Is.SameAs(item2));
        }

        #endregion

        #region Item Create Options Tests

        [Test]
        public void Item_CreateOptions_Basic()
        {
            var options = new Dictionary<string, object>
            {
                { "name", "Test Item" },
                { "amount", 100 },
                { "currency", "INR" }
            };

            Assert.That(options["name"], Is.EqualTo("Test Item"));
            Assert.That(options["amount"], Is.EqualTo(100));
            Assert.That(options["currency"], Is.EqualTo("INR"));
        }

        [Test]
        public void Item_CreateOptions_Description()
        {
            var options = new Dictionary<string, object>
            {
                { "name", "Test Item" },
                { "amount", 100 },
                { "description", "Test item description" }
            };

            Assert.That(options["description"], Is.EqualTo("Test item description"));
        }

        [Test]
        public void Item_CreateOptions_HsnCode()
        {
            var options = new Dictionary<string, object>
            {
                { "name", "Test Item" },
                { "amount", 100 },
                { "hsn_code", "1234" }
            };

            Assert.That(options["hsn_code"], Is.EqualTo("1234"));
        }

        [Test]
        public void Item_CreateOptions_SacCode()
        {
            var options = new Dictionary<string, object>
            {
                { "name", "Test Item" },
                { "amount", 100 },
                { "sac_code", "5678" }
            };

            Assert.That(options["sac_code"], Is.EqualTo("5678"));
        }

        [Test]
        public void Item_CreateOptions_TaxInclusive()
        {
            var options = new Dictionary<string, object>
            {
                { "name", "Test Item" },
                { "amount", 100 },
                { "tax_inclusive", true }
            };

            Assert.That(options["tax_inclusive"], Is.True);
        }

        #endregion

        #region Item Edit Options Tests

        [Test]
        public void Item_EditOptions_Name()
        {
            var options = new Dictionary<string, object>
            {
                { "name", "Updated Item" }
            };

            Assert.That(options["name"], Is.EqualTo("Updated Item"));
        }

        [Test]
        public void Item_EditOptions_Active()
        {
            var options = new Dictionary<string, object>
            {
                { "active", false }
            };

            Assert.That(options["active"], Is.False);
        }

        #endregion
    }
}
