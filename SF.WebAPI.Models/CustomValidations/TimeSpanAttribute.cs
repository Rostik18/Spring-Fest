using System;
using System.ComponentModel.DataAnnotations;

namespace SF.WebAPI.Models.CustomValidations
{
    public class TimeSpanAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return ValidationResult.Success;
            }

            if (!(value is TimeSpan timeSpan))
            {
                return new ValidationResult($"{validationContext.DisplayName} must be {nameof(TimeSpan)}");
            }

            if (timeSpan.TotalSeconds <= 1)
            {
                return new ValidationResult("TimeSpan can not be less than 00:00:00.0000000");
            }

            return ValidationResult.Success;
        }
    }
}