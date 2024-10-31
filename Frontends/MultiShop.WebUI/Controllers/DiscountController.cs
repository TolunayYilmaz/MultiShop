using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.BasketServices;
using MultiShop.WebUI.Services.DiscountServices;

namespace MultiShop.WebUI.Controllers
{
    public class DiscountController : Controller
    {
        private IDiscountService _discountService;
       
        public DiscountController(IDiscountService discountService )
        {
            _discountService = discountService;
         
        }
        [HttpGet]
        public PartialViewResult ConfirmDiscountCoupon()
        {
            
            return PartialView();
        }  
        [HttpPost]
        public IActionResult ConfirmDiscountCoupon(string code)
        {
           
            var value=_discountService.GetDiscountCodeDetailByCodeAsync(code);
            return View(value);
        }
    }
}
