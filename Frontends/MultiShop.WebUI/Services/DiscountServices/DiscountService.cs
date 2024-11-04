﻿using MultiShop.DtoLayer.DiscountDtos;

namespace MultiShop.WebUI.Services.DiscountServices
{
    public class DiscountService : IDiscountService
    {
        private readonly HttpClient _httpClient;

        public DiscountService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<GetDiscountCodeDetailByCode> GetDiscountCodeDetailByCodeAsync(string code)
        {
            var responseMessage = await _httpClient.GetAsync($"http://localhost:7071/api/Discounts/GetCodeDetailByCodeAsync?code={code}");
            var values=await responseMessage.Content.ReadFromJsonAsync<GetDiscountCodeDetailByCode>();
            return values;

        }
    }
}