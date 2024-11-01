using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.BasketServices;
using MultiShop.WebUI.Services.DiscountServices;

namespace MultiShop.WebUI.Controllers
{
    public class DiscountController : Controller
    {
        private readonly IDiscountService _discountService;
        private readonly IBasketService _basketService;

        public DiscountController(IDiscountService discountService, IBasketService basketService)
        {
            _discountService = discountService;
            _basketService = basketService;
        }
        [HttpGet]
        public PartialViewResult ConfirmDiscountCoupon()
        {

            return PartialView();
        }
        [HttpPost]
        public async Task<IActionResult> ConfirmDiscountCoupon(string code)
        {

            var value =await _discountService.GetDiscountCodeDetailByCodeAsync(code);
            var basketValues =await _basketService.GetBasket();
            var totalPriceWithTax = basketValues.TotalPrice + (basketValues.TotalPrice / 100) * 10;
            var totalNewPriceWithDiscount = totalPriceWithTax - (totalPriceWithTax/100*value.Rate);
           
            //var value = await _basketService.GetBasket();
            //ViewBag.totalPrice = value.TotalPrice;
            //var totalPriceWithTax = value.TotalPrice + (value.TotalPrice / 100) * 10;
            //var tax = (value.TotalPrice / 100) * 10;
            //ViewBag.tax = tax;
            return RedirectToAction("Index","ShopingCart",new {code=code,discountRate=value.Rate, totalNewPriceWithDiscount= totalNewPriceWithDiscount });
        }
    }
}
