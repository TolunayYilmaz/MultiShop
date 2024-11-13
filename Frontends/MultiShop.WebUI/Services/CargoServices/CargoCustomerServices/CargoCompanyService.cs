using MultiShop.DtoLayer.CargoDtos.CargoCompanyDtos;
using MultiShop.DtoLayer.CargoDtos.CargoCutomerDtos;
using MultiShop.WebUI.Services.CargoServices.CargoCompanyServices;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace MultiShop.WebUI.Services.CargoServices.CargoCustomersServices
{
    public class CargoCustomerService : ICargoCustomerService
    {
        private readonly HttpClient _httpClient;

        public CargoCustomerService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<GetCargoCustomerByIdDto> GetByIdCargoCustomerInfoAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("CargoCustomers/GetCargoCustomerById?id=" + id);
            var value = await responseMessage.Content.ReadFromJsonAsync<GetCargoCustomerByIdDto>();
            return value;
        }


    }
}
