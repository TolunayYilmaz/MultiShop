using MultiShop.DtoLayer.CargoDtos.CargoCutomerDtos;

namespace MultiShop.WebUI.Services.CargoServices.CargoCustomersServices
{
    public interface ICargoCustomerService
    {

        Task<GetCargoCustomerByIdDto> GetByIdCargoCustomerInfoAsync(string id);
    }
}
