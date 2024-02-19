using System.Collections.Generic;
using Razorpay.Api.Errors;

namespace Razorpay.Api
{
    public class PayloadValidator
    {
        public void Validate(Dictionary<string, object> request, List<ValidationConfig> validationConfig)
        {
            foreach (var config in validationConfig)
            {
                string fieldName = config.FieldName;
                foreach (var validationType in config.Validations)
                {
                    ApplyValidation(request, fieldName, validationType);
                }
            }
        }

        private void ApplyValidation(Dictionary<string, object> payload, string field, ValidationType validationType)
        {
            switch (validationType)
            {
                case ValidationType.NON_NULL:
                    ValidateNonNull(payload, field);
                    break;
                case ValidationType.NON_EMPTY_STRING:
                    ValidateNonEmptyString(payload, field);
                    break;
                case ValidationType.URL:
                    ValidateUrl(payload, field);
                    break;
                case ValidationType.ID:
                    ValidateId(payload, field);
                    break;
                case ValidationType.MODE:
                    ValidateMode(payload, field);
                    break;
                case ValidationType.TOKEN_GRANT:
                    ValidateTokenType(payload, field);
                    break;
                default:
                    break;
            }
        }

        private void ValidateMode(Dictionary<string, object> payload, string field)
        {
            if (!payload.ContainsKey(field))
            {
                return;
            }
            string mode = (string)payload[field];
            if (!new List<string> { "test", "live" }.Contains(mode))
            {
                string errorMessage = "Invalid value provided for field {0}";
                throw new BadRequestError(string.Format(errorMessage, field), "BAD_REQUEST_ERROR", 400);
            }
        }

        private void ValidateTokenType(Dictionary<string, object> payload, string field)
        {
            ValidateNonNull(payload, field);
            string grantType = (string)payload[field];
            switch (grantType)
            {
                case "authorization_code":
                    ValidateNonNull(payload, "code");
                    ValidateNonNull(payload, "redirect_uri");
                    break;
                case "refresh_token":
                    ValidateNonNull(payload, "refresh_token");
                    break;
                default:
                    break;
            }
        }

        private void ValidateNonNull(Dictionary<string, object> payload, string field)
        {
            if (!payload.ContainsKey(field) || payload[field] == null)
            {
                string errorMessage = "Field {0} cannot be null";
                throw new BadRequestError(string.Format(errorMessage, field), "BAD_REQUEST_ERROR", 400);
            }
        }

        private void ValidateNonEmptyString(Dictionary<string, object> payload, string field)
        {
            if (payload.ContainsKey(field) && string.IsNullOrWhiteSpace((string)payload[field]))
            {
                string errorMessage = "Field {0} cannot be empty";
                throw new BadRequestError(string.Format(errorMessage, field), "BAD_REQUEST_ERROR", 400);
            }
        }

        private void ValidateUrl(Dictionary<string, object> payload, string field)
        {
            string url = (string)payload[field];
            string urlRegex = "^(http[s]?):\\/\\/[^\\s/$.?#].[^\\s]*$";
            if (!System.Text.RegularExpressions.Regex.IsMatch(url, urlRegex))
            {
                string errorMessage = "Field {0} is not a valid URL";
                throw new BadRequestError(string.Format(errorMessage, field), "BAD_REQUEST_ERROR", 400);
            }
        }

        private void ValidateId(Dictionary<string, object> payload, string field)
        {
            ValidateNonNull(payload, field);
            ValidateNonEmptyString(payload, field);
            string value = (string)payload[field];
            string idRegex = "[A-Za-z0-9]{1,14}";
            if (!System.Text.RegularExpressions.Regex.IsMatch(value, idRegex))
            {
                string errorMessage = "Field {0} is not a valid ID";
                throw new BadRequestError(string.Format(errorMessage, field), "BAD_REQUEST_ERROR", 400);
            }
        }
    }
}