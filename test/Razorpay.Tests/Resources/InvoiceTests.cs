using System;
using System.Collections.Generic;
using NUnit.Framework;
using Razorpay.Api;
using Razorpay.Tests.Fixtures;

namespace Razorpay.Tests.Resources
{
    [TestFixture]
    public class InvoiceTests
    {
        private RazorpayClient client;

        [SetUp]
        public void Setup()
        {
            client = new RazorpayClient("rzp_test_key", "test_secret");
        }

        #region Invoice Entity Tests

        [Test]
        public void Invoice_Constructor_Default()
        {
            var invoice = new Invoice();
            Assert.That(invoice, Is.Not.Null);
        }

        [Test]
        public void Invoice_IsEntity()
        {
            var invoice = new Invoice();
            Assert.That(invoice, Is.InstanceOf<Entity>());
        }

        [Test]
        public void Invoice_Indexer_GetSet()
        {
            var invoice = new Invoice();
            invoice["id"] = TestFixtures.Invoices.InvoiceId;
            invoice["type"] = "invoice";
            invoice["status"] = "issued";

            Assert.That(invoice["id"], Is.EqualTo(TestFixtures.Invoices.InvoiceId));
            Assert.That(invoice["type"], Is.EqualTo("invoice"));
            Assert.That(invoice["status"], Is.EqualTo("issued"));
        }

        #endregion

        #region Invoice Accessor Tests

        [Test]
        public void Client_Invoice_ReturnsInvoiceInstance()
        {
            Assert.That(client.Invoice, Is.Not.Null);
            Assert.That(client.Invoice, Is.InstanceOf<Invoice>());
        }

        [Test]
        public void Client_Invoice_ReturnsSameInstance()
        {
            var invoice1 = client.Invoice;
            var invoice2 = client.Invoice;
            Assert.That(invoice1, Is.SameAs(invoice2));
        }

        #endregion

        #region Invoice Create Options Tests

        [Test]
        public void Invoice_CreateOptions_Basic()
        {
            var lineItem = new Dictionary<string, object>
            {
                { "name", "Test Item" },
                { "amount", 100 }
            };

            var options = new Dictionary<string, object>
            {
                { "type", "invoice" },
                { "customer_id", TestFixtures.Customers.CustomerId },
                { "line_items", new[] { lineItem } }
            };

            Assert.That(options["type"], Is.EqualTo("invoice"));
            Assert.That(options["customer_id"], Is.EqualTo(TestFixtures.Customers.CustomerId));
        }

        [Test]
        public void Invoice_CreateOptions_WithDescription()
        {
            var options = new Dictionary<string, object>
            {
                { "type", "invoice" },
                { "description", "Invoice for services" }
            };

            Assert.That(options["description"], Is.EqualTo("Invoice for services"));
        }

        [Test]
        public void Invoice_CreateOptions_DraftFalse()
        {
            var options = new Dictionary<string, object>
            {
                { "type", "invoice" },
                { "draft", "0" }
            };

            Assert.That(options["draft"], Is.EqualTo("0"));
        }

        [Test]
        public void Invoice_CreateOptions_DraftTrue()
        {
            var options = new Dictionary<string, object>
            {
                { "type", "invoice" },
                { "draft", "1" }
            };

            Assert.That(options["draft"], Is.EqualTo("1"));
        }

        [Test]
        public void Invoice_CreateOptions_SmsNotify()
        {
            var options = new Dictionary<string, object>
            {
                { "type", "invoice" },
                { "sms_notify", "1" }
            };

            Assert.That(options["sms_notify"], Is.EqualTo("1"));
        }

        [Test]
        public void Invoice_CreateOptions_EmailNotify()
        {
            var options = new Dictionary<string, object>
            {
                { "type", "invoice" },
                { "email_notify", "1" }
            };

            Assert.That(options["email_notify"], Is.EqualTo("1"));
        }

        [Test]
        public void Invoice_CreateOptions_ExpireBy()
        {
            var options = new Dictionary<string, object>
            {
                { "type", "invoice" },
                { "expire_by", 1580064391 }
            };

            Assert.That(options["expire_by"], Is.EqualTo(1580064391));
        }

        #endregion

        #region Invoice Status Tests

        [Test]
        public void Invoice_Status_Draft()
        {
            var invoice = new Invoice();
            invoice["status"] = "draft";
            Assert.That(invoice["status"], Is.EqualTo("draft"));
        }

        [Test]
        public void Invoice_Status_Issued()
        {
            var invoice = new Invoice();
            invoice["status"] = "issued";
            Assert.That(invoice["status"], Is.EqualTo("issued"));
        }

        [Test]
        public void Invoice_Status_PartiallyPaid()
        {
            var invoice = new Invoice();
            invoice["status"] = "partially_paid";
            Assert.That(invoice["status"], Is.EqualTo("partially_paid"));
        }

        [Test]
        public void Invoice_Status_Paid()
        {
            var invoice = new Invoice();
            invoice["status"] = "paid";
            Assert.That(invoice["status"], Is.EqualTo("paid"));
        }

        [Test]
        public void Invoice_Status_Cancelled()
        {
            var invoice = new Invoice();
            invoice["status"] = "cancelled";
            Assert.That(invoice["status"], Is.EqualTo("cancelled"));
        }

        [Test]
        public void Invoice_Status_Expired()
        {
            var invoice = new Invoice();
            invoice["status"] = "expired";
            Assert.That(invoice["status"], Is.EqualTo("expired"));
        }

        #endregion

        #region Invoice Type Tests

        [Test]
        public void Invoice_Type_Invoice()
        {
            var invoice = new Invoice();
            invoice["type"] = "invoice";
            Assert.That(invoice["type"], Is.EqualTo("invoice"));
        }

        [Test]
        public void Invoice_Type_Link()
        {
            var invoice = new Invoice();
            invoice["type"] = "link";
            Assert.That(invoice["type"], Is.EqualTo("link"));
        }

        #endregion
    }
}
