using System;
using System.Collections.Generic;
using NUnit.Framework;
using Razorpay.Api;
using Razorpay.Tests.Fixtures;

namespace Razorpay.Tests.Resources
{
    [TestFixture]
    public class PaymentTests
    {
        private RazorpayClient client;

        [SetUp]
        public void Setup()
        {
            client = new RazorpayClient("rzp_test_key", "test_secret");
        }

        #region Payment Entity Tests

        [Test]
        public void Payment_Constructor_Default()
        {
            var payment = new Payment();
            Assert.That(payment, Is.Not.Null);
        }

        [Test]
        public void Payment_Constructor_WithId()
        {
            var payment = new Payment(TestFixtures.Payments.PaymentId);
            Assert.That(payment["id"], Is.EqualTo(TestFixtures.Payments.PaymentId));
        }

        [Test]
        public void Payment_IsEntity()
        {
            var payment = new Payment();
            Assert.That(payment, Is.InstanceOf<Entity>());
        }

        [Test]
        public void Payment_Indexer_GetSet()
        {
            var payment = new Payment();
            payment["id"] = TestFixtures.Payments.PaymentId;
            payment["amount"] = 50000;
            payment["status"] = "captured";

            Assert.That(payment["id"], Is.EqualTo(TestFixtures.Payments.PaymentId));
            Assert.That(payment["amount"], Is.EqualTo(50000));
            Assert.That(payment["status"], Is.EqualTo("captured"));
        }

        #endregion

        #region Payment Accessor Tests

        [Test]
        public void Client_Payment_ReturnsPaymentInstance()
        {
            Assert.That(client.Payment, Is.Not.Null);
            Assert.That(client.Payment, Is.InstanceOf<Payment>());
        }

        [Test]
        public void Client_Payment_ReturnsSameInstance()
        {
            var payment1 = client.Payment;
            var payment2 = client.Payment;
            Assert.That(payment1, Is.SameAs(payment2));
        }

        #endregion

        #region Payment Capture Options Tests

        [Test]
        public void Payment_CaptureOptions_Amount()
        {
            var options = new Dictionary<string, object>
            {
                { "amount", 50000 }
            };

            Assert.That(options["amount"], Is.EqualTo(50000));
        }

        [Test]
        public void Payment_CaptureOptions_Currency()
        {
            var options = new Dictionary<string, object>
            {
                { "amount", 50000 },
                { "currency", "INR" }
            };

            Assert.That(options["currency"], Is.EqualTo("INR"));
        }

        #endregion

        #region Payment All Options Tests

        [Test]
        public void Payment_AllOptions_FromTo()
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
        public void Payment_AllOptions_CountSkip()
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

        #region Payment Status Tests

        [Test]
        public void Payment_Status_Created()
        {
            var payment = new Payment(TestFixtures.Payments.PaymentId);
            payment["status"] = "created";
            Assert.That(payment["status"], Is.EqualTo("created"));
        }

        [Test]
        public void Payment_Status_Authorized()
        {
            var payment = new Payment(TestFixtures.Payments.PaymentId);
            payment["status"] = "authorized";
            Assert.That(payment["status"], Is.EqualTo("authorized"));
        }

        [Test]
        public void Payment_Status_Captured()
        {
            var payment = new Payment(TestFixtures.Payments.PaymentId);
            payment["status"] = "captured";
            Assert.That(payment["status"], Is.EqualTo("captured"));
        }

        [Test]
        public void Payment_Status_Refunded()
        {
            var payment = new Payment(TestFixtures.Payments.PaymentId);
            payment["status"] = "refunded";
            Assert.That(payment["status"], Is.EqualTo("refunded"));
        }

        [Test]
        public void Payment_Status_Failed()
        {
            var payment = new Payment(TestFixtures.Payments.PaymentId);
            payment["status"] = "failed";
            Assert.That(payment["status"], Is.EqualTo("failed"));
        }

        #endregion

        #region Payment Methods Tests

        [Test]
        public void Payment_Method_Card()
        {
            var payment = new Payment(TestFixtures.Payments.PaymentId);
            payment["method"] = "card";
            Assert.That(payment["method"], Is.EqualTo("card"));
        }

        [Test]
        public void Payment_Method_Netbanking()
        {
            var payment = new Payment(TestFixtures.Payments.PaymentId);
            payment["method"] = "netbanking";
            Assert.That(payment["method"], Is.EqualTo("netbanking"));
        }

        [Test]
        public void Payment_Method_Wallet()
        {
            var payment = new Payment(TestFixtures.Payments.PaymentId);
            payment["method"] = "wallet";
            Assert.That(payment["method"], Is.EqualTo("wallet"));
        }

        [Test]
        public void Payment_Method_Upi()
        {
            var payment = new Payment(TestFixtures.Payments.PaymentId);
            payment["method"] = "upi";
            Assert.That(payment["method"], Is.EqualTo("upi"));
        }

        [Test]
        public void Payment_Method_Emi()
        {
            var payment = new Payment(TestFixtures.Payments.PaymentId);
            payment["method"] = "emi";
            Assert.That(payment["method"], Is.EqualTo("emi"));
        }

        #endregion
    }
}
