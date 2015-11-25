namespace Razorpay.Api.Errors
{
    public class BadRequestError : BaseError
    {
        public string Field { get; private set; }

        public BadRequestError(string message, string errorCode, int httpStatusCode)
            :base(message, errorCode, httpStatusCode)
        {
        }

        public BadRequestError(string message, string errorCode, int httpStatusCode, string field)
            :base(message, errorCode, httpStatusCode)
        {
            this.Field = field;
        }
    }
}