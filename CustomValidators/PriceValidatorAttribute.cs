using ECommerceOrderApp.Models;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace ECommerceOrderApp.CustomValidators
{
    public class PriceValidatorAttribute : ValidationAttribute
    {
        public string DefaultErrorMessage { get; set; } = "Invoice Price should be equal to the total cost of all products (i.e. {0}) in the order.";
        public PriceValidatorAttribute()
        {
        }


        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null)
            {
                var order = (Order)validationContext.ObjectInstance;
                var products = order.Products;
                double Invoice = (double)value;
                if (products != null)
                {
                    List<Product> productsList = new List<Product>();

                    double totalPrice = 0;
                    foreach (var product in products)
                    {
                        totalPrice += product.Price * product.Quantity;
                    }

                    if (totalPrice > 0)
                    {
                        if (totalPrice != Invoice)
                        {
                            return new ValidationResult(String.Format(ErrorMessage ?? DefaultErrorMessage, totalPrice), new string[] { nameof(validationContext.MemberName) });

                        }
                    }
                    else
                    {
                        return new ValidationResult("No products to validate Invoice price", new string[] { nameof(validationContext.MemberName) });
                    }
                    return ValidationResult.Success;
                }
                return null;
            }
            return null;
        }
    }
}
