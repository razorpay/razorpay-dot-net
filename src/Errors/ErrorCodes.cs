using System;
using System.Globalization;

namespace Razorpay.Api.Errors
{
    public enum ErrorCodes
    {
        BAD_REQUEST_ERROR,
        SERVER_ERROR,
        GATEWAY_ERROR
    };


    public class ErrorCodeHelper
    {
        public static BaseError Get(string message, string code, int httpStatusCode, string field)
        {
            string className = string.Join(" ", code.Split('_'));
            className = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(className.ToLower());
            className = string.Join("", className.Split(' '));
            className = "Razorpay.Api.Errors." + className;

            Type type = Type.GetType(className);

            BaseError error = null;
            if(!string.IsNullOrWhiteSpace(field))
            {
                error = (BaseError)Activator.CreateInstance(type, message, code, httpStatusCode, field);
            }
            else
            {
                error = (BaseError)Activator.CreateInstance(type, message, code, httpStatusCode);
            }

            return error;
        }
    }
}