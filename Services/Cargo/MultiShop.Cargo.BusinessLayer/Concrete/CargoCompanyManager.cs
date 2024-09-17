using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DataAccessLayer.Abstract;
using MultiShop.Cargo.EntityLayer;


namespace MultiShop.Cargo.BusinessLayer.Concrete
{
    public class CargoCompanyManager : ICargoCompanyService
    {
        private readonly ICargoCompanyDal _cargoCompanydal;

        public CargoCompanyManager(ICargoCompanyDal carCompanydal)
        {
            _cargoCompanydal = carCompanydal;
        }

        public void TDelete(int id)
        {
            _cargoCompanydal.Delete(id);
        }

        public List<CargoCompany> TGetAll()
        {
           return _cargoCompanydal.GetAll();
        }

        public CargoCompany TGetById(int id)
        {
           return _cargoCompanydal.GetById(id);
        }

        public void TInsert(CargoCompany entity)
        {
            _cargoCompanydal.Insert(entity);
        }

        public void TUpdate(CargoCompany entity)
        {
            _cargoCompanydal.Update(entity);
        }
    } 
}
