using System;
using NUnit.Framework;
using Razorpay.Api.Errors;

namespace Razorpay.Tests
{
    [TestFixture]
    public class ErrorTests
    {
        #region SignatureVerificationError Tests

        [Test]
        public void SignatureVerificationError_SetsMessage()
        {
            var error = new SignatureVerificationError("Invalid signature");

            Assert.That(error.Message, Is.EqualTo("Invalid signature"));
        }

        [Test]
        public void SignatureVerificationError_InheritsFromException()
        {
            var error = new SignatureVerificationError("test");

            Assert.That(error, Is.InstanceOf<Exception>());
        }

        [Test]
        public void SignatureVerificationError_CanBeCaughtAsException()
        {
            Exception caught = null;
            try
            {
                throw new SignatureVerificationError("test error");
            }
            catch (Exception ex)
            {
                caught = ex;
            }

            Assert.That(caught, Is.Not.Null);
            Assert.That(caught, Is.InstanceOf<SignatureVerificationError>());
        }

        #endregion

        #region BaseError Tests

        [Test]
        public void BaseError_SetsAllProperties()
        {
            var error = new BaseError("Error message", "ERR_001", 400);

            Assert.That(error.Message, Is.EqualTo("Error message"));
            Assert.That(error.ErrorCode, Is.EqualTo("ERR_001"));
            Assert.That(error.HttpStatusCode, Is.EqualTo(400));
        }

        [Test]
        public void BaseError_InheritsFromException()
        {
            var error = new BaseError("test", "CODE", 500);

            Assert.That(error, Is.InstanceOf<Exception>());
        }

        [Test]
        public void BaseError_400StatusCode()
        {
            var error = new BaseError("Bad request", "BAD_REQUEST", 400);

            Assert.That(error.HttpStatusCode, Is.EqualTo(400));
        }

        [Test]
        public void BaseError_401StatusCode()
        {
            var error = new BaseError("Unauthorized", "UNAUTHORIZED", 401);

            Assert.That(error.HttpStatusCode, Is.EqualTo(401));
        }

        [Test]
        public void BaseError_500StatusCode()
        {
            var error = new BaseError("Server error", "SERVER_ERROR", 500);

            Assert.That(error.HttpStatusCode, Is.EqualTo(500));
        }

        #endregion

        #region BadRequestError Tests

        [Test]
        public void BadRequestError_SetsProperties()
        {
            var error = new BadRequestError("Invalid data", "INVALID", 400);

            Assert.That(error.Message, Is.EqualTo("Invalid data"));
            Assert.That(error.ErrorCode, Is.EqualTo("INVALID"));
            Assert.That(error.HttpStatusCode, Is.EqualTo(400));
        }

        [Test]
        public void BadRequestError_InheritsFromBaseError()
        {
            var error = new BadRequestError("test", "CODE", 400);

            Assert.That(error, Is.InstanceOf<BaseError>());
        }

        #endregion

        #region GatewayError Tests

        [Test]
        public void GatewayError_SetsProperties()
        {
            var error = new GatewayError("Gateway timeout", "GATEWAY_ERROR", 502);

            Assert.That(error.Message, Is.EqualTo("Gateway timeout"));
            Assert.That(error.ErrorCode, Is.EqualTo("GATEWAY_ERROR"));
            Assert.That(error.HttpStatusCode, Is.EqualTo(502));
        }

        [Test]
        public void GatewayError_InheritsFromBaseError()
        {
            var error = new GatewayError("test", "CODE", 502);

            Assert.That(error, Is.InstanceOf<BaseError>());
        }

        #endregion

        #region ServerError Tests

        [Test]
        public void ServerError_SetsProperties()
        {
            var error = new ServerError("Internal error", "INTERNAL_ERROR", 500);

            Assert.That(error.Message, Is.EqualTo("Internal error"));
            Assert.That(error.ErrorCode, Is.EqualTo("INTERNAL_ERROR"));
            Assert.That(error.HttpStatusCode, Is.EqualTo(500));
        }

        [Test]
        public void ServerError_InheritsFromBaseError()
        {
            var error = new ServerError("test", "CODE", 500);

            Assert.That(error, Is.InstanceOf<BaseError>());
        }

        #endregion
    }
}
