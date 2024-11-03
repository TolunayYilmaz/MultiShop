using MultiShop.DtoLayer.OrderDtos.OrderAddressDtos;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace MultiShop.WebUI.Services.OrderServices.OrderAddressServices
{
	public class OrderAddressService : IOrderAddressService
	{
		private readonly HttpClient _httpClient;

		public OrderAddressService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task CreateOrderAddressAsync(CreateOrderAddressDto createOrderAddressDto)
		{
			await _httpClient.PostAsJsonAsync<CreateOrderAddressDto>("addresses", createOrderAddressDto);
		}

		//public async Task DeleteAboutAsync(string id)
		//{
		//	await _httpClient.DeleteAsync("abouts?id=" + id);
		//}

		//public async Task<List<ResultAboutDto>> GetAllAboutAsync()
		//{
		//	var responseMessage = await _httpClient.GetAsync("abouts");
		//	var jsonData = await responseMessage.Content.ReadAsStringAsync();
		//	var values = JsonConvert.DeserializeObject<List<ResultAboutDto>>(jsonData);
		//	return values;
		//}

		//public async Task<UpdateAboutDto> GetByIdAboutAsync(string id)
		//{
		//	var responseMessage = await _httpClient.GetAsync("abouts/" + id);

		//	var value = await responseMessage.Content.ReadFromJsonAsync<UpdateAboutDto>();
		//	return value;

		//}

		//public async Task UpdateAboutAsync(UpdateAboutDto updateAboutDto)
		//{
		//	await _httpClient.PutAsJsonAsync<UpdateAboutDto>("abouts", updateAboutDto);
		//}
	}
}
