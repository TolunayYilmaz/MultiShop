using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoOperationDtos;
using MultiShop.Cargo.EntityLayer;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoOperationsController : ControllerBase
    {

        private readonly ICargoOperationService _cargoOperationService;

        public CargoOperationsController(ICargoOperationService cargoOperationService)
        {
            _cargoOperationService = cargoOperationService;
        }

        [HttpGet] 
        public IActionResult GetAllList()
        {
            var values = _cargoOperationService.TGetAll();
            return Ok(values);    
        } 
        
        [HttpGet("{id}")] 
        public IActionResult GetCargoOperationById(int id)
        {
            var value = _cargoOperationService.TGetById(id);
            return Ok(value);    
        }
        
        [HttpDelete] 
        public IActionResult RemoveCargoOperation(int id)
        {
            _cargoOperationService.TDelete(id);
            return Ok("Kargo işlemi başarı ile silindi.");    
        } 
        
        [HttpPut] 
        public IActionResult UpdateCargoOperation(UpdateCargoOperationDto updateCargoOperationDto )
        {
           CargoOperation value= new CargoOperation()
           {
               Barcode = updateCargoOperationDto.Barcode,   
               CargoOperationId=updateCargoOperationDto.CargoOperationId,
               Description = updateCargoOperationDto.Description,   
               OperationDate = updateCargoOperationDto.OperationDate
           };
            _cargoOperationService.TUpdate(value);
            return Ok("Kargo işlemi başarı ile güncellendi.");    
        } 
        
        [HttpPost] 
        public IActionResult CreateCargoOperation(CreateCargoOperationDto createCargoOperationDto)
        {
            CargoOperation value=new CargoOperation()
            {
                Barcode=createCargoOperationDto.Barcode,
                Description=createCargoOperationDto.Description,    
                OperationDate=createCargoOperationDto.OperationDate
            };
            _cargoOperationService.TInsert(value);
            return Ok("Kargo işlemi başarı ile eklendi.");    
        }
    }
}
