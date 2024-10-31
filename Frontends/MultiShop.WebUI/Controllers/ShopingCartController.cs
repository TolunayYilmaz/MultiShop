using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.BasketDtos;
using MultiShop.WebUI.Services.BasketServices;
using MultiShop.WebUI.Services.CatalogServices.ProductServices;

namespace MultiShop.WebUI.Controllers
{
    public class ShopingCartController : Controller
    {

        private readonly IProductService _productService;
        private readonly IBasketService _basketService;

        public ShopingCartController(IProductService productService, IBasketService basketService)
        {
            _productService = productService;
            _basketService = basketService;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.directory1 = "Ana Sayfa";
            ViewBag.directory2 = "Ürünler";
            ViewBag.directory3 = "Sepetim";
            var value = await _basketService.GetBasket();
            ViewBag.totalPrice = value.TotalPrice;
            var totalPriceWithTax = value.TotalPrice + (value.TotalPrice / 100) * 10;
            var tax = (value.TotalPrice / 100) * 10;
            ViewBag.tax = tax;
            ViewBag.totalPriceWithTax = totalPriceWithTax;

            return View();
        }
        //[HttpPost]
        public async Task<IActionResult> AddBasketItem(string id)
        {
            var values = await _productService.GetByIdProductAsync(id);
            var item = new BasketItemDto
            {
                ProductId = values.ProductId,
                ProductName = values.ProductName,
                Price = values.ProductPrice,
                Quantity = 1,
                ProductImageUrl = values.ProductImageUrl


            };
            await _basketService.AddBasketItem(item);
            return RedirectToAction("Index");

        }
        public async Task<IActionResult> RemoveBasketItem(string id)
        {
            await _basketService.RemoveBasketItem(id);
            return RedirectToAction("Index");
        }
    }
}
