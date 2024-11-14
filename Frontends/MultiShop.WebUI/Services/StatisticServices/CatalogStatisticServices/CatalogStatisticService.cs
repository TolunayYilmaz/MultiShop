namespace MultiShop.WebUI.Services.StatisticServices.CatalogStatisticServices
{
    public class CatalogStatisticService : ICatalogStatisticService
    {
        private readonly HttpClient _httpClient;

        public CatalogStatisticService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<long> GetBrandCount()
        {
            var responseMessage = await _httpClient.GetAsync("Statistics/GetBrandCount");
            var value = await responseMessage.Content.ReadFromJsonAsync<long>();
            return value;
        }

        public async Task<long> GetCategoryCount()
        {
            var responseMessage = await _httpClient.GetAsync("Statistics/GetCategoryCount");
            var value = await responseMessage.Content.ReadFromJsonAsync<long>();
            return value;
        }

        public async Task<string> GetMaxProductPriceName()
        {
            var responseMessage = await _httpClient.GetAsync("Statistics/GetMaxProductPriceName");
            var value = await responseMessage.Content.ReadAsStringAsync();
            return value;
        }

        public async Task<string> GetMinProductPriceName()
        {
            var responseMessage = await _httpClient.GetAsync("Statistics/GetMinProductPriceName");
            var value = await responseMessage.Content.ReadAsStringAsync();
            return value;
        }

        public async Task<decimal> GetProductAvgPrice()
        {
            var responseMessage = await _httpClient.GetAsync("Statistics/GetProductAvgPrice");
            var values = await responseMessage.Content.ReadFromJsonAsync<decimal>();
            return values;
        }

        public async Task<long> GetProductCount()
        {
            var responseMessage = await _httpClient.GetAsync("Statistics/GetProductCount");
            var value = await responseMessage.Content.ReadFromJsonAsync<long>();
            return value;
        }
    }
}
