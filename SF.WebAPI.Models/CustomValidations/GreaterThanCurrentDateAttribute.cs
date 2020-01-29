using System;
using System.ComponentModel.DataAnnotations;

namespace SF.WebAPI.Models.CustomValidations
{
    public class GreaterThanCurrentDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var isDateValid = (value == null ||
                              (DateTimeOffset)value > DateTimeOffset.Now);

            if (isDateValid)
            {
                return ValidationResult.Success;
            }

            return new ValidationResult($"{validationContext.DisplayName} cannot be less than current date.");
        }
    }
}
