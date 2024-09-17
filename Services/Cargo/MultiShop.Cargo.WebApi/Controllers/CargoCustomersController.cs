using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoCustomerDtos;
using MultiShop.Cargo.EntityLayer;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCustomersController : ControllerBase
    {
        public readonly ICargoCustomerService _customerService;

        public CargoCustomersController(ICargoCustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public IActionResult GetAllCargoCustomers()
        {
            var values = _customerService.TGetAll();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public IActionResult GetCargoCustomerById(int id)
        {
            var value = _customerService.TGetById(id);
            return Ok(value);
        }
        [HttpDelete]
        public IActionResult RemoveCargoCustomer(int id)
        {

            _customerService.TDelete(id);
            return Ok("Kargo müşteri başarı ile silindi.");
        }
        [HttpPut]
        public IActionResult UpdateCargoCustomer(UpdateCargoCustomerDto updateCargoCustomerDto )
        {
           CargoCustomer cargoCustomer=new CargoCustomer()
           {
               CargoCustomerId=updateCargoCustomerDto.CargoCustomerId,
               City=updateCargoCustomerDto.City,
               Address=updateCargoCustomerDto.Address,  
               District=updateCargoCustomerDto.District,    
               Email=updateCargoCustomerDto.Email,  
               Name=updateCargoCustomerDto.Name,    
               Phone=updateCargoCustomerDto.Phone,  
               Surname =updateCargoCustomerDto.Surname

           };
            _customerService.TUpdate(cargoCustomer);
            return Ok("Kargo müşteri başarı ile güncellendi.");
        }
        
        [HttpPost]
        public IActionResult CreateCargoCustomer(CreateCargoCustomerDto createCargoCustomerDto )
        {
           CargoCustomer cargoCustomer=new CargoCustomer()
           {
             
               City= createCargoCustomerDto.City,
               Address= createCargoCustomerDto.Address,  
               District= createCargoCustomerDto.District,    
               Email= createCargoCustomerDto.Email,  
               Name= createCargoCustomerDto.Name,    
               Phone= createCargoCustomerDto.Phone,  
               Surname = createCargoCustomerDto.Surname

           };
            _customerService.TInsert(cargoCustomer);
            return Ok("Kargo müşteri başarı ile eklendi.");
        }


    }
}
