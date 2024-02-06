using System;
using System.Collections.Generic;

namespace Razorpay.Api
{
    public class ValidationConfig
    {
        public string FieldName { get; private set; }
        public List<ValidationType> Validations { get; private set; }

        public ValidationConfig(string fieldName, List<ValidationType> validations)
        {
            FieldName = fieldName ?? throw new ArgumentNullException(nameof(fieldName));
            Validations = validations ?? throw new ArgumentNullException(nameof(validations));
        }
    }
}