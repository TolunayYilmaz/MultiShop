using MultiShop.DtoLayer.OrderDtos.OrderOrderingDtos;

namespace MultiShop.WebUI.Services.OrderServices.OrderOrderingService
{
    public interface IOrderOrderingService
    {
        public Task<List<ResultOrderingByUserIdDto>> GetOrderingByUserId(string id);
    }
}
