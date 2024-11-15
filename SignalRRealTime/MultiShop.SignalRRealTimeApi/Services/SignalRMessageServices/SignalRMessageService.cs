using System.Net.Http;

namespace MultiShop.SignalRRealTimeApi.Services.SignalRMessageServices
{
    public class SignalRMessageService:ISignalRMessageService
    {
        private readonly HttpClient _httpClient;

        public SignalRMessageService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<int> GetTotalMessageCountbyRecieverId(string id)
        {
            var responseMessage = await _httpClient.GetAsync("UserMessage/GetTotalMessageCountbyRecieverId?id=" + id);
            var value = await responseMessage.Content.ReadFromJsonAsync<int>();
            return value;
        }
    }
}
