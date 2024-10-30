using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.OfferDiscountDtos;
using MultiShop.WebUI.Services.CatalogServices.OfferDiscountServices;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/OfferDiscount")]

    public class OfferDiscountController : Controller
    {

        private readonly IOfferDiscountService _offerDiscountService;

        public OfferDiscountController(IOfferDiscountService offerDiscountService)
        {
            _offerDiscountService = offerDiscountService;
        }
        private void OfferDiscountViewbag(string viewbag3)
        {
            ViewBag.v1 = "AnaSayfa";
            ViewBag.v2 = "İndirim Teklifleri";
            ViewBag.v3 = viewbag3;
            ViewBag.v0 = "İndirim Teklif İşlemleri";
        }
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            OfferDiscountViewbag("İndirim Teklifler Listesi");

            var values = await _offerDiscountService.GetAllOfferDiscountAsync();
            return View(values);

        }
        [Route("CreateOfferDiscount")]
        [HttpGet]
        public IActionResult CreateOfferDiscount()
        {
            OfferDiscountViewbag("Yeni İndirim Teklif Girişi");
            return View();
        }
        [Route("CreateOfferDiscount")]
        [HttpPost]
        public async Task<IActionResult> CreateOfferDiscount(CreateOfferDiscountDto createOfferDiscountDto)
        {
            await _offerDiscountService.CreateOfferDiscountAsync(createOfferDiscountDto);

            return RedirectToAction("Index", "OfferDiscount", new { area = "Admin" });


        }
        [Route("DeleteOfferDiscount/{id}")]

        public async Task<IActionResult> DeleteOfferDiscount(string id)
        {
            await _offerDiscountService.DeleteOfferDiscountAsync(id);

            return RedirectToAction("Index", "OfferDiscount", new { area = "Admin" });

        }

        [Route("UpdateOfferDiscount/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateOfferDiscount(string id)
        {
            OfferDiscountViewbag("İndirim Teklif Güncelleme Sayfası");

            var value = await _offerDiscountService.GetByIdOfferDiscountAsync(id);
            return View(value);

        }
        [Route("UpdateOfferDiscount/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateOfferDiscount(UpdateOfferDiscountDto updateOfferDiscountDto)
        {
            await _offerDiscountService.UpdateOfferDiscountAsync(updateOfferDiscountDto);

            return RedirectToAction("Index", "OfferDiscount", new { area = "Admin" });

        }
    }
}

