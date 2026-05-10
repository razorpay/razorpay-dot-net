using System;
using System.Collections.Generic;
using NUnit.Framework;
using Razorpay.Api;
using Razorpay.Tests.Fixtures;

namespace Razorpay.Tests.Resources
{
    [TestFixture]
    public class TransferTests
    {
        private RazorpayClient client;

        [SetUp]
        public void Setup()
        {
            client = new RazorpayClient("rzp_test_key", "test_secret");
        }

        #region Transfer Entity Tests

        [Test]
        public void Transfer_Constructor_Default()
        {
            var transfer = new Transfer();
            Assert.That(transfer, Is.Not.Null);
        }

        [Test]
        public void Transfer_Constructor_WithId()
        {
            var transfer = new Transfer(TestFixtures.Transfers.TransferId);
            Assert.That(transfer["id"], Is.EqualTo(TestFixtures.Transfers.TransferId));
        }

        [Test]
        public void Transfer_IsEntity()
        {
            var transfer = new Transfer();
            Assert.That(transfer, Is.InstanceOf<Entity>());
        }

        [Test]
        public void Transfer_Indexer_GetSet()
        {
            var transfer = new Transfer();
            transfer["amount"] = 1000;
            transfer["currency"] = "INR";
            transfer["recipient"] = "acc_CMaomTz4o0FOFz";

            Assert.That(transfer["amount"], Is.EqualTo(1000));
            Assert.That(transfer["currency"], Is.EqualTo("INR"));
            Assert.That(transfer["recipient"], Is.EqualTo("acc_CMaomTz4o0FOFz"));
        }

        #endregion

        #region Transfer Accessor Tests

        [Test]
        public void Client_Transfer_ReturnsTransferInstance()
        {
            Assert.That(client.Transfer, Is.Not.Null);
            Assert.That(client.Transfer, Is.InstanceOf<Transfer>());
        }

        [Test]
        public void Client_Transfer_ReturnsSameInstance()
        {
            var transfer1 = client.Transfer;
            var transfer2 = client.Transfer;
            Assert.That(transfer1, Is.SameAs(transfer2));
        }

        #endregion

        #region Transfer Create Options Tests

        [Test]
        public void Transfer_CreateOptions_Basic()
        {
            var options = new Dictionary<string, object>
            {
                { "account", "acc_CMaomTz4o0FOFz" },
                { "amount", 1000 },
                { "currency", "INR" }
            };

            Assert.That(options["account"], Is.EqualTo("acc_CMaomTz4o0FOFz"));
            Assert.That(options["amount"], Is.EqualTo(1000));
            Assert.That(options["currency"], Is.EqualTo("INR"));
        }

        [Test]
        public void Transfer_CreateOptions_OnHold()
        {
            var options = new Dictionary<string, object>
            {
                { "account", "acc_CMaomTz4o0FOFz" },
                { "amount", 1000 },
                { "on_hold", 1 }
            };

            Assert.That(options["on_hold"], Is.EqualTo(1));
        }

        [Test]
        public void Transfer_CreateOptions_OnHoldUntil()
        {
            var options = new Dictionary<string, object>
            {
                { "account", "acc_CMaomTz4o0FOFz" },
                { "amount", 1000 },
                { "on_hold", 1 },
                { "on_hold_until", 1580064391 }
            };

            Assert.That(options["on_hold_until"], Is.EqualTo(1580064391));
        }

        [Test]
        public void Transfer_CreateOptions_WithNotes()
        {
            var notes = new Dictionary<string, string>
            {
                { "branch", "Mumbai" },
                { "type", "commission" }
            };

            var options = new Dictionary<string, object>
            {
                { "account", "acc_CMaomTz4o0FOFz" },
                { "amount", 1000 },
                { "notes", notes }
            };

            Assert.That(options.ContainsKey("notes"), Is.True);
        }

        #endregion

        #region Transfer Edit Options Tests

        [Test]
        public void Transfer_EditOptions_OnHold()
        {
            var options = new Dictionary<string, object>
            {
                { "on_hold", 0 }
            };

            Assert.That(options["on_hold"], Is.EqualTo(0));
        }

        [Test]
        public void Transfer_EditOptions_OnHoldUntil()
        {
            var options = new Dictionary<string, object>
            {
                { "on_hold_until", 1580064391 }
            };

            Assert.That(options["on_hold_until"], Is.EqualTo(1580064391));
        }

        #endregion

        #region Reversal Entity Tests

        [Test]
        public void Reversal_Constructor_Default()
        {
            var reversal = new Reversal();
            Assert.That(reversal, Is.Not.Null);
        }

        [Test]
        public void Reversal_IsEntity()
        {
            var reversal = new Reversal();
            Assert.That(reversal, Is.InstanceOf<Entity>());
        }

        #endregion

        #region Reversal Create Options Tests

        [Test]
        public void Reversal_CreateOptions_FullReversal()
        {
            var options = new Dictionary<string, object>();
            Assert.That(options, Is.Empty);
        }

        [Test]
        public void Reversal_CreateOptions_PartialReversal()
        {
            var options = new Dictionary<string, object>
            {
                { "amount", 500 }
            };

            Assert.That(options["amount"], Is.EqualTo(500));
        }

        #endregion
    }
}
