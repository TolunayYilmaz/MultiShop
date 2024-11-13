using MultiShop.Cargo.EntityLayer;


namespace MultiShop.Cargo.DataAccessLayer.Abstract
{
    public interface ICargoCustomerDal:IGenericDal<CargoCustomer>
    {
        CargoCustomer GetCargoCustomerById(string id);
    } 
}
