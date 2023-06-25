using System.ComponentModel.DataAnnotations;

namespace ECommerceOrderApp.CustomValidators
{
    public class MinimumYearValidatorAttribute : ValidationAttribute
    {
        public int MinimumYear { get; set; } = 2000;
        public string DefaultErrorMessage { get; set; } = "Order date should not be less than year 1st January, {0}";
        public MinimumYearValidatorAttribute()
        {
        }

        public MinimumYearValidatorAttribute(int minimumYear)
        {
            MinimumYear = minimumYear;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if(value != null)
            {
                DateTime orderDate = (DateTime)value;
                if (orderDate.Year < MinimumYear)
                {
                    return new ValidationResult(String.Format(ErrorMessage ?? DefaultErrorMessage, MinimumYear));
                }
                else
                {
                    return ValidationResult.Success;
                }
            }
            return null;
        }
    }
}
