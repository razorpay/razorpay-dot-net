using System;

namespace Razorpay.Api.Errors
{
    public class BaseError : Exception
    {
        public string ErrorCode { get; private set; }
        public int HttpStatusCode { get; private set; }

        public BaseError(string message, string errorCode, int httpStatusCode)
            : base(message)
        {
            this.ErrorCode = errorCode;
            this.HttpStatusCode = httpStatusCode;
        }
    }
}