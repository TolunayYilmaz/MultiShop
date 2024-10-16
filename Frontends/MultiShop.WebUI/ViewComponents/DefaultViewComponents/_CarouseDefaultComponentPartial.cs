using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.FeatureSliderDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.DefaultViewComponents
{
    public class _CarouseDefaultComponentPartial:ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public _CarouseDefaultComponentPartial(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			ViewBag.v1 = "AnaSayfa";
			ViewBag.v2 = "Öne Çıkan Görseller";
			ViewBag.v3 = "Slider Öne Çıkan Görsel Listesi";
			ViewBag.v0 = "Öne Çıkan Slider Görsel İşlemleri";
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7070/api/FeatureSliders");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultFeatureSliderDto>>(jsonData);
				return View(values);
			}
			return View();
		}
		
	} 
}
