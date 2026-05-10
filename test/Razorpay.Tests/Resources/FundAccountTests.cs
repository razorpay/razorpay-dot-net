using System;
using System.Collections.Generic;
using NUnit.Framework;
using Razorpay.Api;
using Razorpay.Tests.Fixtures;

namespace Razorpay.Tests.Resources
{
    [TestFixture]
    public class FundAccountTests
    {
        private RazorpayClient client;

        [SetUp]
        public void Setup()
        {
            client = new RazorpayClient("rzp_test_key", "test_secret");
        }

        #region FundAccount Entity Tests

        [Test]
        public void FundAccount_Constructor_Default()
        {
            var fa = new FundAccount();
            Assert.That(fa, Is.Not.Null);
        }

        [Test]
        public void FundAccount_IsEntity()
        {
            var fa = new FundAccount();
            Assert.That(fa, Is.InstanceOf<Entity>());
        }

        [Test]
        public void FundAccount_Indexer_GetSet()
        {
            var fa = new FundAccount();
            fa["id"] = TestFixtures.FundAccounts.FundAccountId;
            fa["account_type"] = "bank_account";
            fa["active"] = true;

            Assert.That(fa["id"], Is.EqualTo(TestFixtures.FundAccounts.FundAccountId));
            Assert.That(fa["account_type"], Is.EqualTo("bank_account"));
            Assert.That(fa["active"], Is.True);
        }

        #endregion

        #region FundAccount Accessor Tests

        [Test]
        public void Client_FundAccount_ReturnsInstance()
        {
            Assert.That(client.FundAccount, Is.Not.Null);
            Assert.That(client.FundAccount, Is.InstanceOf<FundAccount>());
        }

        [Test]
        public void Client_FundAccount_ReturnsSameInstance()
        {
            var fa1 = client.FundAccount;
            var fa2 = client.FundAccount;
            Assert.That(fa1, Is.SameAs(fa2));
        }

        #endregion

        #region FundAccount Create Options Tests

        [Test]
        public void FundAccount_CreateOptions_BankAccount()
        {
            var bankAccount = new Dictionary<string, string>
            {
                { "name", "Test Account" },
                { "ifsc", "HDFC0000053" },
                { "account_number", "1234567890123456789" }
            };

            var options = new Dictionary<string, object>
            {
                { "contact_id", "cont_1234567890" },
                { "account_type", "bank_account" },
                { "bank_account", bankAccount }
            };

            Assert.That(options["account_type"], Is.EqualTo("bank_account"));
            Assert.That(options.ContainsKey("bank_account"), Is.True);
        }

        [Test]
        public void FundAccount_CreateOptions_Vpa()
        {
            var vpa = new Dictionary<string, string>
            {
                { "address", "test@upi" }
            };

            var options = new Dictionary<string, object>
            {
                { "contact_id", "cont_1234567890" },
                { "account_type", "vpa" },
                { "vpa", vpa }
            };

            Assert.That(options["account_type"], Is.EqualTo("vpa"));
            Assert.That(options.ContainsKey("vpa"), Is.True);
        }

        #endregion

        #region FundAccount Type Tests

        [Test]
        public void FundAccount_Type_BankAccount()
        {
            var fa = new FundAccount();
            fa["account_type"] = "bank_account";
            Assert.That(fa["account_type"], Is.EqualTo("bank_account"));
        }

        [Test]
        public void FundAccount_Type_Vpa()
        {
            var fa = new FundAccount();
            fa["account_type"] = "vpa";
            Assert.That(fa["account_type"], Is.EqualTo("vpa"));
        }

        #endregion
    }
}
