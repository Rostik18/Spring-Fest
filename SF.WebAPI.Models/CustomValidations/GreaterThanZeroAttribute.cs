using System.ComponentModel.DataAnnotations;

namespace SF.WebAPI.Models.CustomValidations
{
    public class GreaterThanZeroAttribute : RangeAttribute
    {
        public GreaterThanZeroAttribute() : base(1, int.MaxValue)
        {
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return ValidationResult.Success;
            }

            if (!(value is int id))
            {
                return new ValidationResult($"{validationContext.DisplayName} must be integer.");
            }

            if (id >= 1)
            {
                return ValidationResult.Success;
            }

            return new ValidationResult($"{validationContext.DisplayName} must be greater than zero.");
        }
    }
}
