using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.SpecialOfferDtos;
using MultiShop.WebUI.Services.CatalogServices.SpecialOfferServices;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/SpecialOffer")]
    [AllowAnonymous]
    public class SpecialOfferController : Controller
    {
        private readonly ISpecialOfferService _specialOfferService;

        public SpecialOfferController(ISpecialOfferService specialOfferService)
        {
            _specialOfferService = specialOfferService;
        }
        private void SpecialOfferViewbag(string viewbag3)
        {
            ViewBag.v1 = "AnaSayfa";
            ViewBag.v2 = "Özel Teklifler";
            ViewBag.v3 = viewbag3;
            ViewBag.v0 = "Özel Teklif İşlemleri";

        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            SpecialOfferViewbag("Özel Teklifler Listesi");
            var values = await _specialOfferService.GetAllSpecialOfferAsync();
            return View(values);    
            
        }
        [Route("CreateSpecialOffer")]
        [HttpGet]
        public IActionResult CreateSpecialOffer()
        {
            SpecialOfferViewbag("Özel Teklifler Listesi");
            return View();
        }
        [Route("CreateSpecialOffer")]
        [HttpPost]
        public async Task<IActionResult> CreateSpecialOffer(CreateSpecialOfferDto createSpecialOfferDto)
        {
            await _specialOfferService.CreateSpecialOfferAsync(createSpecialOfferDto);
            return RedirectToAction("Index", "SpecialOffer", new { area = "Admin" });
           

        }
        [Route("DeleteSpecialOffer/{id}")]
        public async Task<IActionResult> DeleteSpecialOffer(string id)
        {
            await _specialOfferService.DeleteSpecialOfferAsync(id);
            return RedirectToAction("Index", "SpecialOffer", new { area = "Admin" });

           
        }

        [Route("UpdateSpecialOffer/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateSpecialOffer(string id)
        {
            SpecialOfferViewbag("Özel Teklif Güncelleme Sayfası");

           var value=  await _specialOfferService.GetByIdSpecialOfferAsync(id);
            return View(value);
           
        }
        [Route("UpdateSpecialOffer/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateSpecialOffer(UpdateSpecialOfferDto updateSpecialOfferDto)
        {
           await _specialOfferService.UpdateSpecialOfferAsync(updateSpecialOfferDto);
           return RedirectToAction("Index", "SpecialOffer", new { area = "Admin" });
          
        }
    }
}

