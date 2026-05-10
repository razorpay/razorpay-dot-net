using System;
using System.Collections.Generic;
using NUnit.Framework;
using Razorpay.Api;

namespace Razorpay.Tests
{
    [TestFixture]
    public class ClientTests
    {
        #region Constructor Tests

        [Test]
        public void Constructor_WithKeyAndSecret_SetsCredentials()
        {
            var client = new RazorpayClient("rzp_test_key123", "secret123");

            Assert.That(RazorpayClient.Key, Is.EqualTo("rzp_test_key123"));
            Assert.That(RazorpayClient.Secret, Is.EqualTo("secret123"));
        }

        [Test]
        public void Constructor_WithAccessToken_SetsToken()
        {
            var client = new RazorpayClient("access_token_123");

            Assert.That(RazorpayClient.AccessToken, Is.EqualTo("access_token_123"));
        }

        [Test]
        public void Constructor_WithBaseUrlKeySecret_SetsAllValues()
        {
            var client = new RazorpayClient("https://custom.api.com", "rzp_key", "rzp_secret");

            Assert.That(RazorpayClient.BaseUrl, Is.EqualTo("https://custom.api.com"));
            Assert.That(RazorpayClient.Key, Is.EqualTo("rzp_key"));
            Assert.That(RazorpayClient.Secret, Is.EqualTo("rzp_secret"));
        }

        #endregion

        #region Version Tests

        [Test]
        public void Version_ReturnsNonEmptyString()
        {
            Assert.That(RazorpayClient.Version, Is.Not.Null.And.Not.Empty);
        }

        [Test]
        public void Version_MatchesSemanticVersionFormat()
        {
            string version = RazorpayClient.Version;
            Assert.That(version, Does.Match(@"^\d+\.\d+\.\d+$"));
        }

        #endregion

        #region BaseUrl Tests

        [Test]
        public void BaseUrl_DefaultValue_ReturnsRazorpayUrl()
        {
            Assert.That(RazorpayClient.BaseUrl, Is.Not.Null.And.Not.Empty);
            Assert.That(RazorpayClient.BaseUrl, Does.Contain("razorpay.com"));
        }

        [Test]
        public void DefaultAuthUrl_ReturnsAuthRazorpayUrl()
        {
            Assert.That(RazorpayClient.DefaultAuthUrl, Is.EqualTo("https://auth.razorpay.com"));
        }

        #endregion

        #region AppDetails Tests

        [Test]
        public void SetAppsDetails_AddsToList()
        {
            var client = new RazorpayClient("key", "secret");
            int initialCount = RazorpayClient.AppsDetails.Count;

            client.setAppsDetails("TestApp", "1.0.0");

            Assert.That(RazorpayClient.AppsDetails.Count, Is.GreaterThan(initialCount));
        }

        [Test]
        public void SetAppsDetails_StoresTitleAndVersion()
        {
            var client = new RazorpayClient("key", "secret");
            client.setAppsDetails("MyApp", "2.5.0");

            var lastApp = RazorpayClient.AppsDetails[RazorpayClient.AppsDetails.Count - 1];
            Assert.That(lastApp["title"], Is.EqualTo("MyApp"));
            Assert.That(lastApp["version"], Is.EqualTo("2.5.0"));
        }

        #endregion

        #region Headers Tests

        [Test]
        public void AddHeader_AddsToHeaders()
        {
            var client = new RazorpayClient("key", "secret");
            string uniqueKey = "X-Custom-Header-" + Guid.NewGuid().ToString().Substring(0, 8);

            client.addHeader(uniqueKey, "test-value");

            Assert.That(RazorpayClient.Headers.ContainsKey(uniqueKey), Is.True);
            Assert.That(RazorpayClient.Headers[uniqueKey], Is.EqualTo("test-value"));
        }

        #endregion

        #region Entity Accessor Tests

        [Test]
        public void Payment_ReturnsPaymentInstance()
        {
            var client = new RazorpayClient("key", "secret");
            Assert.That(client.Payment, Is.Not.Null);
            Assert.That(client.Payment, Is.InstanceOf<Payment>());
        }

        [Test]
        public void Order_ReturnsOrderInstance()
        {
            var client = new RazorpayClient("key", "secret");
            Assert.That(client.Order, Is.Not.Null);
            Assert.That(client.Order, Is.InstanceOf<Order>());
        }

        [Test]
        public void Refund_ReturnsRefundInstance()
        {
            var client = new RazorpayClient("key", "secret");
            Assert.That(client.Refund, Is.Not.Null);
            Assert.That(client.Refund, Is.InstanceOf<Refund>());
        }

        [Test]
        public void Customer_ReturnsCustomerInstance()
        {
            var client = new RazorpayClient("key", "secret");
            Assert.That(client.Customer, Is.Not.Null);
            Assert.That(client.Customer, Is.InstanceOf<Customer>());
        }

        [Test]
        public void Invoice_ReturnsInvoiceInstance()
        {
            var client = new RazorpayClient("key", "secret");
            Assert.That(client.Invoice, Is.Not.Null);
            Assert.That(client.Invoice, Is.InstanceOf<Invoice>());
        }

        [Test]
        public void Card_ReturnsCardInstance()
        {
            var client = new RazorpayClient("key", "secret");
            Assert.That(client.Card, Is.Not.Null);
            Assert.That(client.Card, Is.InstanceOf<Card>());
        }

        [Test]
        public void Transfer_ReturnsTransferInstance()
        {
            var client = new RazorpayClient("key", "secret");
            Assert.That(client.Transfer, Is.Not.Null);
            Assert.That(client.Transfer, Is.InstanceOf<Transfer>());
        }

        [Test]
        public void Addon_ReturnsAddonInstance()
        {
            var client = new RazorpayClient("key", "secret");
            Assert.That(client.Addon, Is.Not.Null);
            Assert.That(client.Addon, Is.InstanceOf<Addon>());
        }

        [Test]
        public void Plan_ReturnsPlanInstance()
        {
            var client = new RazorpayClient("key", "secret");
            Assert.That(client.Plan, Is.Not.Null);
            Assert.That(client.Plan, Is.InstanceOf<Plan>());
        }

        [Test]
        public void Subscription_ReturnsSubscriptionInstance()
        {
            var client = new RazorpayClient("key", "secret");
            Assert.That(client.Subscription, Is.Not.Null);
            Assert.That(client.Subscription, Is.InstanceOf<Subscription>());
        }

        [Test]
        public void VirtualAccount_ReturnsVirtualAccountInstance()
        {
            var client = new RazorpayClient("key", "secret");
            Assert.That(client.VirtualAccount, Is.Not.Null);
            Assert.That(client.VirtualAccount, Is.InstanceOf<VirtualAccount>());
        }

        [Test]
        public void BankTransfer_ReturnsBankTransferInstance()
        {
            var client = new RazorpayClient("key", "secret");
            Assert.That(client.BankTransfer, Is.Not.Null);
            Assert.That(client.BankTransfer, Is.InstanceOf<BankTransfer>());
        }

        [Test]
        public void Token_ReturnsTokenInstance()
        {
            var client = new RazorpayClient("key", "secret");
            Assert.That(client.Token, Is.Not.Null);
            Assert.That(client.Token, Is.InstanceOf<Token>());
        }

        [Test]
        public void FundAccount_ReturnsFundAccountInstance()
        {
            var client = new RazorpayClient("key", "secret");
            Assert.That(client.FundAccount, Is.Not.Null);
            Assert.That(client.FundAccount, Is.InstanceOf<FundAccount>());
        }

        [Test]
        public void Product_ReturnsProductInstance()
        {
            var client = new RazorpayClient("key", "secret");
            Assert.That(client.Product, Is.Not.Null);
            Assert.That(client.Product, Is.InstanceOf<Product>());
        }

        [Test]
        public void Iin_ReturnsIinInstance()
        {
            var client = new RazorpayClient("key", "secret");
            Assert.That(client.Iin, Is.Not.Null);
            Assert.That(client.Iin, Is.InstanceOf<Iin>());
        }

        [Test]
        public void QrCode_ReturnsQrCodeInstance()
        {
            var client = new RazorpayClient("key", "secret");
            Assert.That(client.QrCode, Is.Not.Null);
            Assert.That(client.QrCode, Is.InstanceOf<QrCode>());
        }

        [Test]
        public void PaymentLink_ReturnsPaymentLinkInstance()
        {
            var client = new RazorpayClient("key", "secret");
            Assert.That(client.PaymentLink, Is.Not.Null);
            Assert.That(client.PaymentLink, Is.InstanceOf<PaymentLink>());
        }

        [Test]
        public void Settlement_ReturnsSettlementInstance()
        {
            var client = new RazorpayClient("key", "secret");
            Assert.That(client.Settlement, Is.Not.Null);
            Assert.That(client.Settlement, Is.InstanceOf<Settlement>());
        }

        [Test]
        public void Tnc_ReturnsTncInstance()
        {
            var client = new RazorpayClient("key", "secret");
            Assert.That(client.Tnc, Is.Not.Null);
            Assert.That(client.Tnc, Is.InstanceOf<Tnc>());
        }

        [Test]
        public void Item_ReturnsItemInstance()
        {
            var client = new RazorpayClient("key", "secret");
            Assert.That(client.Item, Is.Not.Null);
            Assert.That(client.Item, Is.InstanceOf<Item>());
        }

        [Test]
        public void Account_ReturnsAccountInstance()
        {
            var client = new RazorpayClient("key", "secret");
            Assert.That(client.Account, Is.Not.Null);
            Assert.That(client.Account, Is.InstanceOf<Account>());
        }

        [Test]
        public void Stakeholder_ReturnsStakeholderInstance()
        {
            var client = new RazorpayClient("key", "secret");
            Assert.That(client.Stakeholder, Is.Not.Null);
            Assert.That(client.Stakeholder, Is.InstanceOf<Stakeholder>());
        }

        [Test]
        public void Webhook_ReturnsWebhookInstance()
        {
            var client = new RazorpayClient("key", "secret");
            Assert.That(client.Webhook, Is.Not.Null);
            Assert.That(client.Webhook, Is.InstanceOf<Webhook>());
        }

        [Test]
        public void OAuthTokenClient_ReturnsOAuthTokenClientInstance()
        {
            var client = new RazorpayClient("key", "secret");
            Assert.That(client.OAuthTokenClient, Is.Not.Null);
            Assert.That(client.OAuthTokenClient, Is.InstanceOf<OAuthTokenClient>());
        }

        [Test]
        public void Method_ReturnsMethodInstance()
        {
            var client = new RazorpayClient("key", "secret");
            Assert.That(client.Method, Is.Not.Null);
            Assert.That(client.Method, Is.InstanceOf<Method>());
        }

        [Test]
        public void Dispute_ReturnsDisputeInstance()
        {
            var client = new RazorpayClient("key", "secret");
            Assert.That(client.Dispute, Is.Not.Null);
            Assert.That(client.Dispute, Is.InstanceOf<Dispute>());
        }

        [Test]
        public void BankAccount_ReturnsBankAccountInstance()
        {
            var client = new RazorpayClient("key", "secret");
            Assert.That(client.BankAccount, Is.Not.Null);
            Assert.That(client.BankAccount, Is.InstanceOf<BankAccount>());
        }

        [Test]
        public void DeviceActivity_ReturnsDeviceActivityInstance()
        {
            var client = new RazorpayClient("key", "secret");
            Assert.That(client.DeviceActivity, Is.Not.Null);
            Assert.That(client.DeviceActivity, Is.InstanceOf<DeviceActivity>());
        }

        #endregion

        #region Lazy Initialization Tests

        [Test]
        public void Payment_ReturnsSameInstance()
        {
            var client = new RazorpayClient("key", "secret");
            var payment1 = client.Payment;
            var payment2 = client.Payment;

            Assert.That(payment1, Is.SameAs(payment2));
        }

        [Test]
        public void Order_ReturnsSameInstance()
        {
            var client = new RazorpayClient("key", "secret");
            var order1 = client.Order;
            var order2 = client.Order;

            Assert.That(order1, Is.SameAs(order2));
        }

        #endregion
    }
}
