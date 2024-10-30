using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.FeatureDtos;
using MultiShop.WebUI.Services.CatalogServices.FeatureServices;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Feature")]

    public class FeatureController : Controller
    {
        private readonly IFeatureService _featureService;

        public FeatureController(IFeatureService featureService)
        {
            _featureService = featureService;
        }
        void FeatureViewbag(string viewbag3)
        {
            ViewBag.v1 = "AnaSayfa";
            ViewBag.v2 = "Öne Çıkan Alanlar";
            ViewBag.v3 = viewbag3;
            ViewBag.v0 = "Ana Sayfa Öne Çıkan Alan İşlemleri";

        }
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            FeatureViewbag("Öne Çıkan Alan Listesi");
            var values = await _featureService.GetAllFeatureAsync();
            return View(values);
        }
        [Route("CreateFeature")]
        [HttpGet]
        public IActionResult CreateFeature()
        {
            FeatureViewbag("Yeni Öne Çıkan Alan Girişi");
            return View();
        }
        [Route("CreateFeature")]
        [HttpPost]
        public async Task<IActionResult> CreateFeature(CreateFeatureDto createFeatureDto)
        {
            await _featureService.CreateFeatureAsync(createFeatureDto);
            return RedirectToAction("Index", "Feature", new { area = "Admin" });

        }
        [Route("DeleteFeature/{id}")]

        public async Task<IActionResult> DeleteFeature(string id)
        {
            await _featureService.DeleteFeatureAsync(id);
            return RedirectToAction("Index", "Feature", new { area = "Admin" });

        }

        [Route("UpdateFeature/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateFeature(string id)
        {
            FeatureViewbag("Öne Çıkan Alan Güncelleme Sayfası");
            var value = await _featureService.GetByIdFeatureAsync(id);
            return View(value);
        }
        [Route("UpdateFeature/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateFeature(UpdateFeatureDto updateFeatureDto)
        {

            await _featureService.UpdateFeatureAsync(updateFeatureDto);
            return RedirectToAction("Index", "Feature", new { area = "Admin" });


        }
    }
}
