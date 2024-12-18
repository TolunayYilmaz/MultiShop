﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.BrandDtos;
using MultiShop.WebUI.Services.CatalogServices.BrandServices;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Brand")]

    public class BrandController : Controller
    {
        private readonly IBrandService _brandService;

        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }
        private void BrandViewbag(string viewbag3)
        {
            ViewBag.v1 = "AnaSayfa";
            ViewBag.v2 = "Kategoriler";
            ViewBag.v3 = viewbag3;
            ViewBag.v0 = "Kategori İşlemleri";
        }
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            BrandViewbag("Kategori Listesi");
            var values = await _brandService.GetAllBrandAsync();
            return View(values);
        }
        [Route("CreateBrand")]
        [HttpGet]
        public IActionResult CreateBrand()
        {
            ViewBag.v1 = "AnaSayfa";
            ViewBag.v2 = "Kategoriler";
            ViewBag.v3 = "Yeni Kategori Girişi";
            ViewBag.v0 = "Kategori İşlemleri";
            return View();
        }
        [Route("CreateBrand")]
        [HttpPost]
        public async Task<IActionResult> CreateBrand(CreateBrandDto createBrandDto)
        {
            await _brandService.CreateBrandAsync(createBrandDto);

            return RedirectToAction("Index", "Brand", new { area = "Admin" });

        }
        [Route("DeleteBrand/{id}")]

        public async Task<IActionResult> DeleteBrand(string id)
        {
            await _brandService.DeleteBrandAsync(id);
            return RedirectToAction("Index", "Brand", new { area = "Admin" });

        }

        [Route("UpdateBrand/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateBrand(string id)
        {
            BrandViewbag("Kategori Güncelleme Sayfası");
            var value =await _brandService.GetByIdBrandAsync(id);
            return View(value);

        }
        [Route("UpdateBrand/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateBrand(UpdateBrandDto updateBrandDto)
        {
            await _brandService.UpdateBrandAsync(updateBrandDto);

            return RedirectToAction("Index", "Brand", new { area = "Admin" });

        }
    }
}
