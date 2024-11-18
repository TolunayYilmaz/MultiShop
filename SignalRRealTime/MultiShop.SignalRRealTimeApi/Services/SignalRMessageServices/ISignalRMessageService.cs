using System.Threading.Tasks;

namespace MultiShop.SignalRRealTimeApi.Services.SignalRMessageServices
{
    public interface ISignalRMessageService
    {
        Task<int> GetTotalMessageCount();
    }
}
