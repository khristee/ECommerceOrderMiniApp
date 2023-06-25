using ECommerceOrderApp.CustomValidators;
using System.ComponentModel.DataAnnotations;


namespace ECommerceOrderApp.Models
{
    public class Order
    {
        public int OrderNo { get; set; }
        [Required(ErrorMessage ="{0} cannot be empty")]
        [Display(Name = "Order Date")]
        [MinimumYearValidator(2000, ErrorMessage ="Order date should not be less than year 1st January, {0}")]
        public DateTime OrderDate { get; set; }
        [Required(ErrorMessage = "{0} cannot be empty")]
        [Display(Name = "Invoice Price")]
        [Range(1, double.MaxValue, ErrorMessage = "{0} should be between a valid number")]
        [PriceValidator]
        public double InvoicePrice { get; set; }
        [Required(ErrorMessage = "Order should have at least one product")]
        public List<Product>? Products { get; set; }
    }
}
