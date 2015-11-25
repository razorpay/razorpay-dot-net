namespace Razorpay.Api.Errors
{
    public class ServerError : BaseError
    {
        public ServerError(string message, string code, int httpStatusCode)
            :base(message, code, httpStatusCode)
        {

        }
    }
}