using System;
using System.ComponentModel.DataAnnotations;

namespace MKS.WebAPI.Models.CustomValidations
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

            if (timeSpan.Days != 0)
            {
                return new ValidationResult("TimeSpan can not be greater, than 23:59:59.9999999");
            }

            return ValidationResult.Success;
        }
    }
}