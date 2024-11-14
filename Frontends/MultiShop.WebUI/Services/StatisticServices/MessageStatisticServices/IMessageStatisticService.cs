using System.Net.Http;

namespace MultiShop.WebUI.Services.StatisticServices.MessageStatisticServices
{
    public interface IMessageStatisticService
    {
        Task<int> GetTotalMessageCount();
    }
}
