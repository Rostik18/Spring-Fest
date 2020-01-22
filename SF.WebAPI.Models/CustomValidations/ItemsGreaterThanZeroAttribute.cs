using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SF.WebAPI.Models.CustomValidations
{
    public class ItemsGreaterThanZeroAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            if (value == null)
            {
                return ValidationResult.Success;
            }

            if (!(value is List<int> list))
            {
                return new ValidationResult($"{validationContext.DisplayName} must be list of integers");
            }

            var allItemsGreaterThanZero = list.All(item => item > 0);

            if (allItemsGreaterThanZero)
            {
                return ValidationResult.Success;
            }

            return new ValidationResult($"All items of {validationContext.DisplayName} must be greater than zero.");
        }
    }
}
