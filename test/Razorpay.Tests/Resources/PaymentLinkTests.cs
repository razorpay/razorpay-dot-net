using System;
using System.Collections.Generic;
using NUnit.Framework;
using Razorpay.Api;
using Razorpay.Tests.Fixtures;

namespace Razorpay.Tests.Resources
{
    [TestFixture]
    public class PaymentLinkTests
    {
        private RazorpayClient client;

        [SetUp]
        public void Setup()
        {
            client = new RazorpayClient("rzp_test_key", "test_secret");
        }

        #region PaymentLink Entity Tests

        [Test]
        public void PaymentLink_Constructor_Default()
        {
            var plink = new PaymentLink();
            Assert.That(plink, Is.Not.Null);
        }

        [Test]
        public void PaymentLink_IsEntity()
        {
            var plink = new PaymentLink();
            Assert.That(plink, Is.InstanceOf<Entity>());
        }

        [Test]
        public void PaymentLink_Indexer_GetSet()
        {
            var plink = new PaymentLink();
            plink["id"] = TestFixtures.PaymentLinks.PaymentLinkId;
            plink["amount"] = 1000;
            plink["status"] = "created";

            Assert.That(plink["id"], Is.EqualTo(TestFixtures.PaymentLinks.PaymentLinkId));
            Assert.That(plink["amount"], Is.EqualTo(1000));
            Assert.That(plink["status"], Is.EqualTo("created"));
        }

        #endregion

        #region PaymentLink Accessor Tests

        [Test]
        public void Client_PaymentLink_ReturnsInstance()
        {
            Assert.That(client.PaymentLink, Is.Not.Null);
            Assert.That(client.PaymentLink, Is.InstanceOf<PaymentLink>());
        }

        [Test]
        public void Client_PaymentLink_ReturnsSameInstance()
        {
            var plink1 = client.PaymentLink;
            var plink2 = client.PaymentLink;
            Assert.That(plink1, Is.SameAs(plink2));
        }

        #endregion

        #region PaymentLink Create Options Tests

        [Test]
        public void PaymentLink_CreateOptions_Basic()
        {
            var options = new Dictionary<string, object>
            {
                { "amount", 1000 },
                { "currency", "INR" },
                { "description", "Test Payment Link" }
            };

            Assert.That(options["amount"], Is.EqualTo(1000));
            Assert.That(options["currency"], Is.EqualTo("INR"));
            Assert.That(options["description"], Is.EqualTo("Test Payment Link"));
        }

        [Test]
        public void PaymentLink_CreateOptions_AcceptPartial()
        {
            var options = new Dictionary<string, object>
            {
                { "amount", 1000 },
                { "accept_partial", true },
                { "first_min_partial_amount", 100 }
            };

            Assert.That(options["accept_partial"], Is.True);
            Assert.That(options["first_min_partial_amount"], Is.EqualTo(100));
        }

        [Test]
        public void PaymentLink_CreateOptions_ReferenceId()
        {
            var options = new Dictionary<string, object>
            {
                { "amount", 1000 },
                { "reference_id", "ref_123" }
            };

            Assert.That(options["reference_id"], Is.EqualTo("ref_123"));
        }

        [Test]
        public void PaymentLink_CreateOptions_ExpireBy()
        {
            var options = new Dictionary<string, object>
            {
                { "amount", 1000 },
                { "expire_by", 1580064391 }
            };

            Assert.That(options["expire_by"], Is.EqualTo(1580064391));
        }

        [Test]
        public void PaymentLink_CreateOptions_Customer()
        {
            var customer = new Dictionary<string, string>
            {
                { "name", "Test Customer" },
                { "email", "test@example.com" },
                { "contact", "9876543210" }
            };

            var options = new Dictionary<string, object>
            {
                { "amount", 1000 },
                { "customer", customer }
            };

            Assert.That(options.ContainsKey("customer"), Is.True);
        }

        [Test]
        public void PaymentLink_CreateOptions_Notify()
        {
            var notify = new Dictionary<string, bool>
            {
                { "sms", true },
                { "email", true }
            };

            var options = new Dictionary<string, object>
            {
                { "amount", 1000 },
                { "notify", notify }
            };

            Assert.That(options.ContainsKey("notify"), Is.True);
        }

        [Test]
        public void PaymentLink_CreateOptions_Callback()
        {
            var options = new Dictionary<string, object>
            {
                { "amount", 1000 },
                { "callback_url", "https://example.com/callback" },
                { "callback_method", "get" }
            };

            Assert.That(options["callback_url"], Is.EqualTo("https://example.com/callback"));
            Assert.That(options["callback_method"], Is.EqualTo("get"));
        }

        [Test]
        public void PaymentLink_CreateOptions_ReminderEnable()
        {
            var options = new Dictionary<string, object>
            {
                { "amount", 1000 },
                { "reminder_enable", true }
            };

            Assert.That(options["reminder_enable"], Is.True);
        }

        #endregion

        #region PaymentLink Status Tests

        [Test]
        public void PaymentLink_Status_Created()
        {
            var plink = new PaymentLink();
            plink["status"] = "created";
            Assert.That(plink["status"], Is.EqualTo("created"));
        }

        [Test]
        public void PaymentLink_Status_PartiallyPaid()
        {
            var plink = new PaymentLink();
            plink["status"] = "partially_paid";
            Assert.That(plink["status"], Is.EqualTo("partially_paid"));
        }

        [Test]
        public void PaymentLink_Status_Paid()
        {
            var plink = new PaymentLink();
            plink["status"] = "paid";
            Assert.That(plink["status"], Is.EqualTo("paid"));
        }

        [Test]
        public void PaymentLink_Status_Cancelled()
        {
            var plink = new PaymentLink();
            plink["status"] = "cancelled";
            Assert.That(plink["status"], Is.EqualTo("cancelled"));
        }

        [Test]
        public void PaymentLink_Status_Expired()
        {
            var plink = new PaymentLink();
            plink["status"] = "expired";
            Assert.That(plink["status"], Is.EqualTo("expired"));
        }

        #endregion
    }
}
