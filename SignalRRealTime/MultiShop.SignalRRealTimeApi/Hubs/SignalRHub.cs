using Microsoft.AspNetCore.SignalR;
using MultiShop.SignalRRealTimeApi.Services.SignalRCommentServices;
using MultiShop.SignalRRealTimeApi.Services.SignalRMessageServices;

namespace MultiShop.SignalRRealTimeApi.Hubs
{
    public class SignalRHub:Hub
    {
        private readonly ISignalRCommentService _signalRCommentService;
        private readonly ISignalRMessageService _signalRMessageService;

        public SignalRHub(ISignalRCommentService signalRCommentService, ISignalRMessageService signalRMessageService)
        {
            _signalRCommentService = signalRCommentService;
            _signalRMessageService = signalRMessageService;
        }

        public async Task SendStatisticCount(string id)
        {
            var getTotalCommentCount=_signalRCommentService.GetTotalCommandCount();
            await Clients.All.SendAsync("ReceiveCommentCount",getTotalCommentCount);

            var getTotalMessageCountbyRecieverId = _signalRMessageService.GetTotalMessageCountbyRecieverId(id);
            await Clients.All.SendAsync("ReceiveMessageCount", getTotalMessageCountbyRecieverId);
        }
    }
}
