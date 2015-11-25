namespace Razorpay.Api.Errors
{
    public class GatewayError : BaseError
    {
        public GatewayError(string message, string code, int httpStatusCode)
            :base(message, code, httpStatusCode)
        {

        }
    }
}