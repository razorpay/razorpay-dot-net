using System;
using System.Collections.Generic;
using NUnit.Framework;
using Razorpay.Api;
using Razorpay.Tests.Fixtures;

namespace Razorpay.Tests.Resources
{
    [TestFixture]
    public class RefundTests
    {
        private RazorpayClient client;

        [SetUp]
        public void Setup()
        {
            client = new RazorpayClient("rzp_test_key", "test_secret");
        }

        #region Refund Entity Tests

        [Test]
        public void Refund_Constructor_Default()
        {
            var refund = new Refund();
            Assert.That(refund, Is.Not.Null);
        }

        [Test]
        public void Refund_IsEntity()
        {
            var refund = new Refund();
            Assert.That(refund, Is.InstanceOf<Entity>());
        }

        [Test]
        public void Refund_Indexer_GetSet()
        {
            var refund = new Refund();
            refund["id"] = TestFixtures.Refunds.RefundId;
            refund["amount"] = 50000;
            refund["status"] = "processed";

            Assert.That(refund["id"], Is.EqualTo(TestFixtures.Refunds.RefundId));
            Assert.That(refund["amount"], Is.EqualTo(50000));
            Assert.That(refund["status"], Is.EqualTo("processed"));
        }

        #endregion

        #region Refund Accessor Tests

        [Test]
        public void Client_Refund_ReturnsRefundInstance()
        {
            Assert.That(client.Refund, Is.Not.Null);
            Assert.That(client.Refund, Is.InstanceOf<Refund>());
        }

        [Test]
        public void Client_Refund_ReturnsSameInstance()
        {
            var refund1 = client.Refund;
            var refund2 = client.Refund;
            Assert.That(refund1, Is.SameAs(refund2));
        }

        #endregion

        #region Refund Create Options Tests

        [Test]
        public void Refund_CreateOptions_FullRefund()
        {
            var options = new Dictionary<string, object>
            {
                { "payment_id", TestFixtures.Payments.PaymentId }
            };

            Assert.That(options["payment_id"], Is.EqualTo(TestFixtures.Payments.PaymentId));
        }

        [Test]
        public void Refund_CreateOptions_PartialRefund()
        {
            var options = new Dictionary<string, object>
            {
                { "payment_id", TestFixtures.Payments.PaymentId },
                { "amount", 25000 }
            };

            Assert.That(options["amount"], Is.EqualTo(25000));
        }

        [Test]
        public void Refund_CreateOptions_WithNotes()
        {
            var notes = new Dictionary<string, string>
            {
                { "reason", "customer_request" }
            };

            var options = new Dictionary<string, object>
            {
                { "payment_id", TestFixtures.Payments.PaymentId },
                { "notes", notes }
            };

            Assert.That(options.ContainsKey("notes"), Is.True);
        }

        [Test]
        public void Refund_CreateOptions_SpeedNormal()
        {
            var options = new Dictionary<string, object>
            {
                { "payment_id", TestFixtures.Payments.PaymentId },
                { "speed", "normal" }
            };

            Assert.That(options["speed"], Is.EqualTo("normal"));
        }

        [Test]
        public void Refund_CreateOptions_SpeedOptimum()
        {
            var options = new Dictionary<string, object>
            {
                { "payment_id", TestFixtures.Payments.PaymentId },
                { "speed", "optimum" }
            };

            Assert.That(options["speed"], Is.EqualTo("optimum"));
        }

        #endregion

        #region Refund Status Tests

        [Test]
        public void Refund_Status_Pending()
        {
            var refund = new Refund();
            refund["status"] = "pending";
            Assert.That(refund["status"], Is.EqualTo("pending"));
        }

        [Test]
        public void Refund_Status_Processed()
        {
            var refund = new Refund();
            refund["status"] = "processed";
            Assert.That(refund["status"], Is.EqualTo("processed"));
        }

        [Test]
        public void Refund_Status_Failed()
        {
            var refund = new Refund();
            refund["status"] = "failed";
            Assert.That(refund["status"], Is.EqualTo("failed"));
        }

        #endregion

        #region Refund All Options Tests

        [Test]
        public void Refund_AllOptions_FromTo()
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
        public void Refund_AllOptions_CountSkip()
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
    }
}
