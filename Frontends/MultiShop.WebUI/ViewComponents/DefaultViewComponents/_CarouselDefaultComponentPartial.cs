using Microsoft.AspNetCore.Mvc;

using MultiShop.WebUI.Services.CatalogServices.FeatureSliderServices;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.DefaultViewComponents
{
	public class _CarouselDefaultComponentPartial : ViewComponent
	{
		private readonly IFeatureSliderService _featureSliderService;

        public _CarouselDefaultComponentPartial(IFeatureSliderService featureSliderService)
        {
            _featureSliderService = featureSliderService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
		{
			ViewBag.v1 = "AnaSayfa";
			ViewBag.v2 = "Öne Çıkan Görseller";
			ViewBag.v3 = "Slider Öne Çıkan Görsel Listesi";
			ViewBag.v0 = "Öne Çıkan Slider Görsel İşlemleri";
			var values=await _featureSliderService.GetAllFeatureSliderAsync();
			return View(values);


		}
	}
}
