using System;
using System.Collections.Generic;
using NUnit.Framework;
using Razorpay.Api;
using Razorpay.Tests.Fixtures;

namespace Razorpay.Tests.Resources
{
    [TestFixture]
    public class SettlementTests
    {
        private RazorpayClient client;

        [SetUp]
        public void Setup()
        {
            client = new RazorpayClient("rzp_test_key", "test_secret");
        }

        #region Settlement Entity Tests

        [Test]
        public void Settlement_Constructor_Default()
        {
            var settlement = new Settlement();
            Assert.That(settlement, Is.Not.Null);
        }

        [Test]
        public void Settlement_IsEntity()
        {
            var settlement = new Settlement();
            Assert.That(settlement, Is.InstanceOf<Entity>());
        }

        [Test]
        public void Settlement_Indexer_GetSet()
        {
            var settlement = new Settlement();
            settlement["id"] = TestFixtures.Settlements.SettlementId;
            settlement["amount"] = 9999;
            settlement["status"] = "processed";

            Assert.That(settlement["id"], Is.EqualTo(TestFixtures.Settlements.SettlementId));
            Assert.That(settlement["amount"], Is.EqualTo(9999));
            Assert.That(settlement["status"], Is.EqualTo("processed"));
        }

        #endregion

        #region Settlement Accessor Tests

        [Test]
        public void Client_Settlement_ReturnsInstance()
        {
            Assert.That(client.Settlement, Is.Not.Null);
            Assert.That(client.Settlement, Is.InstanceOf<Settlement>());
        }

        [Test]
        public void Client_Settlement_ReturnsSameInstance()
        {
            var s1 = client.Settlement;
            var s2 = client.Settlement;
            Assert.That(s1, Is.SameAs(s2));
        }

        #endregion

        #region Settlement All Options Tests

        [Test]
        public void Settlement_AllOptions_FromTo()
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
        public void Settlement_AllOptions_CountSkip()
        {
            var options = new Dictionary<string, object>
            {
                { "count", 10 },
                { "skip", 0 }
            };

            Assert.That(options["count"], Is.EqualTo(10));
            Assert.That(options["skip"], Is.EqualTo(0));
        }

        #endregion

        #region Settlement Status Tests

        [Test]
        public void Settlement_Status_Created()
        {
            var settlement = new Settlement();
            settlement["status"] = "created";
            Assert.That(settlement["status"], Is.EqualTo("created"));
        }

        [Test]
        public void Settlement_Status_Processed()
        {
            var settlement = new Settlement();
            settlement["status"] = "processed";
            Assert.That(settlement["status"], Is.EqualTo("processed"));
        }

        [Test]
        public void Settlement_Status_Failed()
        {
            var settlement = new Settlement();
            settlement["status"] = "failed";
            Assert.That(settlement["status"], Is.EqualTo("failed"));
        }

        #endregion
    }
}
