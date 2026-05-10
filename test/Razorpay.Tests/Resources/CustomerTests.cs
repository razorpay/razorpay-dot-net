using System;
using System.Collections.Generic;
using NUnit.Framework;
using Razorpay.Api;
using Razorpay.Tests.Fixtures;

namespace Razorpay.Tests.Resources
{
    [TestFixture]
    public class CustomerTests
    {
        private RazorpayClient client;

        [SetUp]
        public void Setup()
        {
            client = new RazorpayClient("rzp_test_key", "test_secret");
        }

        #region Customer Entity Tests

        [Test]
        public void Customer_Constructor_Default()
        {
            var customer = new Customer();
            Assert.That(customer, Is.Not.Null);
        }

        [Test]
        public void Customer_Constructor_WithId()
        {
            var customer = new Customer(TestFixtures.Customers.CustomerId);
            Assert.That(customer["id"], Is.EqualTo(TestFixtures.Customers.CustomerId));
        }

        [Test]
        public void Customer_IsEntity()
        {
            var customer = new Customer();
            Assert.That(customer, Is.InstanceOf<Entity>());
        }

        [Test]
        public void Customer_Indexer_GetSet()
        {
            var customer = new Customer();
            customer["name"] = "Test Customer";
            customer["email"] = "test@example.com";
            customer["contact"] = "9876543210";

            Assert.That(customer["name"], Is.EqualTo("Test Customer"));
            Assert.That(customer["email"], Is.EqualTo("test@example.com"));
            Assert.That(customer["contact"], Is.EqualTo("9876543210"));
        }

        #endregion

        #region Customer Accessor Tests

        [Test]
        public void Client_Customer_ReturnsCustomerInstance()
        {
            Assert.That(client.Customer, Is.Not.Null);
            Assert.That(client.Customer, Is.InstanceOf<Customer>());
        }

        [Test]
        public void Client_Customer_ReturnsSameInstance()
        {
            var customer1 = client.Customer;
            var customer2 = client.Customer;
            Assert.That(customer1, Is.SameAs(customer2));
        }

        #endregion

        #region Customer Create Options Tests

        [Test]
        public void Customer_CreateOptions_Basic()
        {
            var options = new Dictionary<string, object>
            {
                { "name", "Test Customer" },
                { "email", "test@example.com" },
                { "contact", "9876543210" }
            };

            Assert.That(options["name"], Is.EqualTo("Test Customer"));
            Assert.That(options["email"], Is.EqualTo("test@example.com"));
            Assert.That(options["contact"], Is.EqualTo("9876543210"));
        }

        [Test]
        public void Customer_CreateOptions_WithGstin()
        {
            var options = new Dictionary<string, object>
            {
                { "name", "Business Customer" },
                { "email", "business@example.com" },
                { "contact", "9876543210" },
                { "gstin", "29ABCDE1234F1Z5" }
            };

            Assert.That(options["gstin"], Is.EqualTo("29ABCDE1234F1Z5"));
        }

        [Test]
        public void Customer_CreateOptions_WithNotes()
        {
            var notes = new Dictionary<string, string>
            {
                { "source", "website" },
                { "category", "premium" }
            };

            var options = new Dictionary<string, object>
            {
                { "name", "Test Customer" },
                { "notes", notes }
            };

            Assert.That(options.ContainsKey("notes"), Is.True);
        }

        [Test]
        public void Customer_CreateOptions_FailOnDuplicate()
        {
            var options = new Dictionary<string, object>
            {
                { "name", "Test Customer" },
                { "email", "test@example.com" },
                { "fail_existing", "1" }
            };

            Assert.That(options["fail_existing"], Is.EqualTo("1"));
        }

        #endregion

        #region Customer Edit Options Tests

        [Test]
        public void Customer_EditOptions_Name()
        {
            var options = new Dictionary<string, object>
            {
                { "name", "Updated Name" }
            };

            Assert.That(options["name"], Is.EqualTo("Updated Name"));
        }

        [Test]
        public void Customer_EditOptions_Email()
        {
            var options = new Dictionary<string, object>
            {
                { "email", "updated@example.com" }
            };

            Assert.That(options["email"], Is.EqualTo("updated@example.com"));
        }

        [Test]
        public void Customer_EditOptions_Contact()
        {
            var options = new Dictionary<string, object>
            {
                { "contact", "9999999999" }
            };

            Assert.That(options["contact"], Is.EqualTo("9999999999"));
        }

        #endregion

        #region Customer All Options Tests

        [Test]
        public void Customer_AllOptions_CountSkip()
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
