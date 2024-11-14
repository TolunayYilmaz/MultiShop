﻿using Newtonsoft.Json;

namespace MultiShop.WebUI.Services.StatisticServices.UserStaticServices
{
    public class UserStatisticService : IUserStatisticService
    {
        private readonly HttpClient _httpClient;

        public UserStatisticService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<int> GetUserCount()
        {
            var responseMessage = await _httpClient.GetAsync("http://localhost:5001/api/Statistics");
            var jsonData=await responseMessage.Content.ReadAsStringAsync();
            var value= JsonConvert.DeserializeObject<int>(jsonData);    
            return value;
        }
    }
}
