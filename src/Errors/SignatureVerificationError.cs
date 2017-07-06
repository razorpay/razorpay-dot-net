using System;

namespace Razorpay.Api.Errors
{
    public class SignatureVerificationError : Exception
    {
        public SignatureVerificationError(string message) : base(message)
        {
            
        }
    }
}