using System;
using System.Collections.Generic;
using NUnit.Framework;
using Razorpay.Api;
using Razorpay.Tests.Fixtures;

namespace Razorpay.Tests.Resources
{
    [TestFixture]
    public class QrCodeTests
    {
        private RazorpayClient client;

        [SetUp]
        public void Setup()
        {
            client = new RazorpayClient("rzp_test_key", "test_secret");
        }

        #region QrCode Entity Tests

        [Test]
        public void QrCode_Constructor_Default()
        {
            var qrCode = new QrCode();
            Assert.That(qrCode, Is.Not.Null);
        }

        [Test]
        public void QrCode_IsEntity()
        {
            var qrCode = new QrCode();
            Assert.That(qrCode, Is.InstanceOf<Entity>());
        }

        [Test]
        public void QrCode_Indexer_GetSet()
        {
            var qrCode = new QrCode();
            qrCode["id"] = TestFixtures.QrCodes.QrCodeId;
            qrCode["type"] = "upi_qr";
            qrCode["status"] = "active";

            Assert.That(qrCode["id"], Is.EqualTo(TestFixtures.QrCodes.QrCodeId));
            Assert.That(qrCode["type"], Is.EqualTo("upi_qr"));
            Assert.That(qrCode["status"], Is.EqualTo("active"));
        }

        #endregion

        #region QrCode Accessor Tests

        [Test]
        public void Client_QrCode_ReturnsInstance()
        {
            Assert.That(client.QrCode, Is.Not.Null);
            Assert.That(client.QrCode, Is.InstanceOf<QrCode>());
        }

        [Test]
        public void Client_QrCode_ReturnsSameInstance()
        {
            var qr1 = client.QrCode;
            var qr2 = client.QrCode;
            Assert.That(qr1, Is.SameAs(qr2));
        }

        #endregion

        #region QrCode Create Options Tests

        [Test]
        public void QrCode_CreateOptions_Basic()
        {
            var options = new Dictionary<string, object>
            {
                { "type", "upi_qr" },
                { "name", "Test QR" },
                { "usage", "single_use" },
                { "fixed_amount", true },
                { "payment_amount", 300 }
            };

            Assert.That(options["type"], Is.EqualTo("upi_qr"));
            Assert.That(options["name"], Is.EqualTo("Test QR"));
            Assert.That(options["usage"], Is.EqualTo("single_use"));
        }

        [Test]
        public void QrCode_CreateOptions_MultipleUse()
        {
            var options = new Dictionary<string, object>
            {
                { "type", "upi_qr" },
                { "usage", "multiple_use" },
                { "fixed_amount", false }
            };

            Assert.That(options["usage"], Is.EqualTo("multiple_use"));
            Assert.That(options["fixed_amount"], Is.False);
        }

        [Test]
        public void QrCode_CreateOptions_CloseBy()
        {
            var options = new Dictionary<string, object>
            {
                { "type", "upi_qr" },
                { "close_by", 1681615838 }
            };

            Assert.That(options["close_by"], Is.EqualTo(1681615838));
        }

        [Test]
        public void QrCode_CreateOptions_WithCustomer()
        {
            var options = new Dictionary<string, object>
            {
                { "type", "upi_qr" },
                { "customer_id", TestFixtures.Customers.CustomerId }
            };

            Assert.That(options["customer_id"], Is.EqualTo(TestFixtures.Customers.CustomerId));
        }

        [Test]
        public void QrCode_CreateOptions_Description()
        {
            var options = new Dictionary<string, object>
            {
                { "type", "upi_qr" },
                { "description", "QR for store payment" }
            };

            Assert.That(options["description"], Is.EqualTo("QR for store payment"));
        }

        #endregion

        #region QrCode Type Tests

        [Test]
        public void QrCode_Type_UpiQr()
        {
            var qrCode = new QrCode();
            qrCode["type"] = "upi_qr";
            Assert.That(qrCode["type"], Is.EqualTo("upi_qr"));
        }

        [Test]
        public void QrCode_Type_BharatQr()
        {
            var qrCode = new QrCode();
            qrCode["type"] = "bharat_qr";
            Assert.That(qrCode["type"], Is.EqualTo("bharat_qr"));
        }

        #endregion

        #region QrCode Status Tests

        [Test]
        public void QrCode_Status_Active()
        {
            var qrCode = new QrCode();
            qrCode["status"] = "active";
            Assert.That(qrCode["status"], Is.EqualTo("active"));
        }

        [Test]
        public void QrCode_Status_Closed()
        {
            var qrCode = new QrCode();
            qrCode["status"] = "closed";
            Assert.That(qrCode["status"], Is.EqualTo("closed"));
        }

        #endregion

        #region QrCode Usage Tests

        [Test]
        public void QrCode_Usage_SingleUse()
        {
            var qrCode = new QrCode();
            qrCode["usage"] = "single_use";
            Assert.That(qrCode["usage"], Is.EqualTo("single_use"));
        }

        [Test]
        public void QrCode_Usage_MultipleUse()
        {
            var qrCode = new QrCode();
            qrCode["usage"] = "multiple_use";
            Assert.That(qrCode["usage"], Is.EqualTo("multiple_use"));
        }

        #endregion
    }
}
