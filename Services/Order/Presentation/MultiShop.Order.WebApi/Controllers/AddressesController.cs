using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Order.Application.Features.CQRS.Commands.AddressCommands;
using MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers;
using MultiShop.Order.Application.Features.CQRS.Queries.AddressQueries;

namespace MultiShop.Order.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {   //CQRS Tasaraım deseni ile yazılan kod çağırıldı
        private readonly GetAddressQueryHandler _getAddressQueryHandler;
        private readonly GetAddressByIdQueryHandler _getAddressByIdQueryHandler;
        private readonly CreateAddressCommandHandler _createAddressCommandHanler;
        private readonly UpdateAddressCommandHandler _updateAddressCommandHandler;
        private readonly RemoveAddressCommandHandler _removeAddressCommandHandler;

        public AddressesController(GetAddressQueryHandler getAddressQueryHandler, 
            GetAddressByIdQueryHandler getAddressByIdQueryHandler, 
            CreateAddressCommandHandler createAddressCommandHanler, 
            UpdateAddressCommandHandler updateAddressCommandHandler, 
            RemoveAddressCommandHandler removeAddressCommandHandler)
        {
            _getAddressQueryHandler = getAddressQueryHandler;
            _getAddressByIdQueryHandler = getAddressByIdQueryHandler;
            _createAddressCommandHanler = createAddressCommandHanler;
            _updateAddressCommandHandler = updateAddressCommandHandler;
            _removeAddressCommandHandler = removeAddressCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> AddressList()
        {
            var values = await _getAddressQueryHandler.Handle();
            
            return Ok(values);  
        } 
        
        [HttpGet("{id}")]
        public async Task<IActionResult> AddressListById(int id)
        {
            var values =await _getAddressByIdQueryHandler.Handle(new GetAddressByIdQuery(id));
            return Ok(values);  
        }

        [HttpPost]
         public async Task<IActionResult> CreateAddress(CreatedAddressCommand command)
        {
            await _createAddressCommandHanler.Handle(command);  
            return Ok("Adress Bilgisi Başarı ile eklendi."); 
        }
        [HttpPut]
         public async Task<IActionResult> UpdateAddress(UpdateAddressCommand command)
        {
            await _updateAddressCommandHandler.Handle(command);  
            return Ok("Adress Bilgisi Başarı ile güncellendi."); 
        }
        [HttpDelete]
         public async Task<IActionResult> RemoveAddress(int id)
        {
            await _removeAddressCommandHandler.Handle(new RemoveAddressCommand(id));  
            return Ok("Adress Bilgisi Başarı ile silindi."); 
        }
    }
}
