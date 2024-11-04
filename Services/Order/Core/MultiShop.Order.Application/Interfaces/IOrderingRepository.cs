using MultiShop.Order.Domain.Entitites;

namespace MultiShop.Order.Application.Interfaces
{
    public interface IOrderingRepository
    {  
        public List<Ordering> GetOrderingsByUserId(string id);
    } 
}
