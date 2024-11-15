namespace MultiShop.SignalRRealTimeApi.Services.SignalRCommentServices
{
    public class SignalRCommentService:ISignalRCommentService
    {
        private readonly HttpClient _httpClient;

        public SignalRCommentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<int> GetTotalCommandCount()
        {
            var responseMessage = await _httpClient.GetAsync("Comments/GetTotalCommandCount");
            var value = await responseMessage.Content.ReadFromJsonAsync<int>();
            return value;
        }
    }
}
