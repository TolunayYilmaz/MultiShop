using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoDetailDtos;
using MultiShop.Cargo.EntityLayer;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoDetailsController : ControllerBase
    {
        private readonly ICargoDetailService _cargoDetailService;

        public CargoDetailsController(ICargoDetailService cargoDetailService)
        {
            _cargoDetailService = cargoDetailService;
        }

        [HttpGet]
        public IActionResult GetAllCargoDetails()
        {
            var values = _cargoDetailService.TGetAll();
            return Ok(values);  
        } 
        
        [HttpGet("{id}")]
        public IActionResult GetCargoDetailById(int id)
        {
            var value = _cargoDetailService.TGetById(id);
            return Ok(value);  
        }
        [HttpDelete]
        public IActionResult RemoveCargoDetail(int id)
        {
            _cargoDetailService.TDelete(id);
            return Ok("Kargo detayı başarı ile silindi.");
        }    
        
        [HttpPut]
        public IActionResult UpdateCargoDetail(UpdateCargoDetailDto updateCargoDetailDto)
        {
            CargoDetail cargoDetail = new CargoDetail()
            {
                Barcode = updateCargoDetailDto.Barcode,
                CargoCompanyId=updateCargoDetailDto.CargoCompanyId,
                CargoDetailId=updateCargoDetailDto.CargoDetailId,
                ReceiverCustomer=updateCargoDetailDto.ReceiverCustomer,
                SenderCustomer=updateCargoDetailDto.SenderCustomer
               
            };
            _cargoDetailService.TUpdate(cargoDetail);
            return Ok("Kargo detayı başarı ile silindi.");
        }   
        
        [HttpPost]
        public IActionResult CreateCargoDetail(CreateCargoDetailDto createCargoDetailDto)
        {
            CargoDetail cargoDetail = new CargoDetail() 
            { SenderCustomer=createCargoDetailDto.SenderCustomer,
            CargoCompanyId=createCargoDetailDto.CargoCompanyId,
            ReceiverCustomer=createCargoDetailDto.ReceiverCustomer,
            Barcode=createCargoDetailDto.Barcode  
            
            };
            _cargoDetailService.TInsert(cargoDetail);
            return Ok("Kargo detayı başarı ile eklendi.");
        }    
    }
}
