using MultiShop.Cargo.EntityLayer;


namespace MultiShop.Cargo.BusinessLayer.Abstract
{
    public interface ICargoCustomerService : IGenericService<CargoCustomer>
    {
        CargoCustomer TGetCargoCustomerById(string id);
    } 

}
