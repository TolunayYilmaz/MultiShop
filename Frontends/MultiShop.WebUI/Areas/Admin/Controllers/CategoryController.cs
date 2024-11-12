using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;
using MultiShop.WebUI.Services.CatalogServices.CategoryServices;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Category")]
  
    public class CategoryController : Controller
    {
    
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            
            _categoryService = categoryService;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            CategoryViewBagList("Kategori Listesi");
            var values = await _categoryService.GetAllCategoryAsync();
            return View(values);
        }
        [Route("CreateCategory")]
        [HttpGet]
        public IActionResult CreateCategory()
        {
            CategoryViewBagList("Yeni Kategori Girişi");
            return View();
        }
        [Route("CreateCategory")]
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
        {

            await _categoryService.CreateCategoryAsync(createCategoryDto);
            return RedirectToAction("Index", "Category", new { area = "Admin" });

        }
        [Route("DeleteCategory/{id}")]

        public async Task<IActionResult> DeleteCategory(string id)
        {
            await _categoryService.DeleteCategoryAsync(id);

            return RedirectToAction("Index", "Category", new { area = "Admin" });

        }

        [Route("UpdateCategory/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateCategory(string id)
        {
            CategoryViewBagList("Kategori Güncelleme Sayfası");
            var value= await _categoryService.GetByIdCategoryAsync(id);
          
            return View(value);
        }
        [Route("UpdateCategory/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {

            await _categoryService.UpdateCategoryAsync(updateCategoryDto);  
            return RedirectToAction("Index", "Category", new { area = "Admin" });
           
          
        }
        private void CategoryViewBagList(string viewBag3)
        {
            ViewBag.v1 = "AnaSayfa";
            ViewBag.v2 = "Kategoriler";
            ViewBag.v3 = viewBag3;
            ViewBag.v0 = "Kategori İşlemleri";
        }
    }
}
