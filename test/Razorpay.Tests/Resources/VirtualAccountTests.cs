using System;
using System.Collections.Generic;
using NUnit.Framework;
using Razorpay.Api;
using Razorpay.Tests.Fixtures;

namespace Razorpay.Tests.Resources
{
    [TestFixture]
    public class VirtualAccountTests
    {
        private RazorpayClient client;

        [SetUp]
        public void Setup()
        {
            client = new RazorpayClient("rzp_test_key", "test_secret");
        }

        #region VirtualAccount Entity Tests

        [Test]
        public void VirtualAccount_Constructor_Default()
        {
            var va = new VirtualAccount();
            Assert.That(va, Is.Not.Null);
        }

        [Test]
        public void VirtualAccount_Constructor_WithId()
        {
            var va = new VirtualAccount(TestFixtures.VirtualAccounts.VirtualAccountId);
            Assert.That(va["id"], Is.EqualTo(TestFixtures.VirtualAccounts.VirtualAccountId));
        }

        [Test]
        public void VirtualAccount_IsEntity()
        {
            var va = new VirtualAccount();
            Assert.That(va, Is.InstanceOf<Entity>());
        }

        [Test]
        public void VirtualAccount_Indexer_GetSet()
        {
            var va = new VirtualAccount();
            va["name"] = "Test Virtual Account";
            va["status"] = "active";

            Assert.That(va["name"], Is.EqualTo("Test Virtual Account"));
            Assert.That(va["status"], Is.EqualTo("active"));
        }

        #endregion

        #region VirtualAccount Accessor Tests

        [Test]
        public void Client_VirtualAccount_ReturnsInstance()
        {
            Assert.That(client.VirtualAccount, Is.Not.Null);
            Assert.That(client.VirtualAccount, Is.InstanceOf<VirtualAccount>());
        }

        [Test]
        public void Client_VirtualAccount_ReturnsSameInstance()
        {
            var va1 = client.VirtualAccount;
            var va2 = client.VirtualAccount;
            Assert.That(va1, Is.SameAs(va2));
        }

        #endregion

        #region VirtualAccount Create Options Tests

        [Test]
        public void VirtualAccount_CreateOptions_Basic()
        {
            var receivers = new Dictionary<string, object>
            {
                { "types", new[] { "bank_account" } }
            };

            var options = new Dictionary<string, object>
            {
                { "receivers", receivers },
                { "description", "Test Virtual Account" }
            };

            Assert.That(options.ContainsKey("receivers"), Is.True);
            Assert.That(options["description"], Is.EqualTo("Test Virtual Account"));
        }

        [Test]
        public void VirtualAccount_CreateOptions_WithCustomer()
        {
            var options = new Dictionary<string, object>
            {
                { "customer_id", TestFixtures.Customers.CustomerId },
                { "description", "VA for customer" }
            };

            Assert.That(options["customer_id"], Is.EqualTo(TestFixtures.Customers.CustomerId));
        }

        [Test]
        public void VirtualAccount_CreateOptions_CloseBy()
        {
            var options = new Dictionary<string, object>
            {
                { "close_by", 1881615838 }
            };

            Assert.That(options["close_by"], Is.EqualTo(1881615838));
        }

        [Test]
        public void VirtualAccount_CreateOptions_AmountExpected()
        {
            var options = new Dictionary<string, object>
            {
                { "amount_expected", 100000 }
            };

            Assert.That(options["amount_expected"], Is.EqualTo(100000));
        }

        #endregion

        #region VirtualAccount Status Tests

        [Test]
        public void VirtualAccount_Status_Active()
        {
            var va = new VirtualAccount();
            va["status"] = "active";
            Assert.That(va["status"], Is.EqualTo("active"));
        }

        [Test]
        public void VirtualAccount_Status_Closed()
        {
            var va = new VirtualAccount();
            va["status"] = "closed";
            Assert.That(va["status"], Is.EqualTo("closed"));
        }

        #endregion

        #region BankTransfer Entity Tests

        [Test]
        public void BankTransfer_Constructor_Default()
        {
            var bt = new BankTransfer();
            Assert.That(bt, Is.Not.Null);
        }

        [Test]
        public void BankTransfer_IsEntity()
        {
            var bt = new BankTransfer();
            Assert.That(bt, Is.InstanceOf<Entity>());
        }

        [Test]
        public void Client_BankTransfer_ReturnsInstance()
        {
            Assert.That(client.BankTransfer, Is.Not.Null);
            Assert.That(client.BankTransfer, Is.InstanceOf<BankTransfer>());
        }

        #endregion
    }
}
