using ECommerceOrderApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceOrderApp.Controllers
{
    public class OrdersController : Controller
    {
        [Route("/order")]
        public IActionResult Index([Bind(nameof(Order.OrderDate), nameof(Order.InvoicePrice), nameof(Order.Products))] Order order)
        {
            if (!ModelState.IsValid)
            {
                string errors = string.Join("\n", ModelState.Values.SelectMany(value => value.Errors).Select(err => err.ErrorMessage));

                return BadRequest(errors);
            }

            Random randomKey = new Random();
            int randomOrderN0 = randomKey.Next(1, 99999);
            return Json(new {OrderNo = randomOrderN0});
        }
    }
}
