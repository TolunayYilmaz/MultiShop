using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.FeatureSliderDtos;
using MultiShop.WebUI.Services.CatalogServices.FeatureSliderServices;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/FeatureSlider")]
    public class FeatureSliderController : Controller
    {
        private readonly IFeatureSliderService _featureSliderService;

        public FeatureSliderController(IFeatureSliderService featureSliderService)
        {
            _featureSliderService = featureSliderService;
        }

        private void FeatureSliderViewbag(string viewbag3)
        {
            ViewBag.v1 = "AnaSayfa";
            ViewBag.v2 = "Öne Çıkan Görseller";
            ViewBag.v3 = viewbag3;
            ViewBag.v0 = "Öne Çıkan Slider Görsel İşlemleri";

        }
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            FeatureSliderViewbag("Slider Öne Çıkan Görsel Listesi");
            var values = await _featureSliderService.GetAllFeatureSliderAsync();
            return View(values); 
        }
        [HttpGet]
        [Route("CreateFeatureSlider")]
        public IActionResult CreateFeatureSlider()
        {
            FeatureSliderViewbag("Slider Öne Çıkan Görsel Listesi");
            return View();
        }
        [HttpPost]
        [Route("CreateFeatureSlider")]
        public async Task<IActionResult> CreateFeatureSlider(CreateFeatureSliderDto createFeatureSliderDto)
        {
            createFeatureSliderDto.Status = false;
            await _featureSliderService.CreateFeatureSliderAsync(createFeatureSliderDto);


            return RedirectToAction("Index", "FeatureSlider", new { area = "Admin" });

        }


        [Route("DeleteFeatureSlider/{id}")]
        public async Task<IActionResult> DeleteFeatureSlider(string id)
        {
            await _featureSliderService.DeleteFeatureSliderAsync(id);

            return RedirectToAction("Index", "FeatureSlider", new { area = "Admin" });


        }


        [HttpGet]
        [Route("UpdateFeatureSlider/{id}")]
        public async Task<IActionResult> UpdateFeatureSlider(string id)
        {
            FeatureSliderViewbag("Slider Öne Çıkan Görsel Listesi");
            var value= await _featureSliderService.GetByIdFeatureSliderAsync(id);
            return View(value);
        }

        [HttpPost]
        [Route("UpdateFeatureSlider/{id}")]
        public async Task<IActionResult> UpdateFeatureSlider(UpdateFeatureSliderDto updateFeatureSliderDto)
        {

            await _featureSliderService.UpdateFeatureSliderAsync(updateFeatureSliderDto);
            return RedirectToAction("Index", "FeatureSlider", new { area = "Admin" });
          
        }
    }
}

