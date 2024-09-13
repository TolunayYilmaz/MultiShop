using MultiShop.Order.Application.Features.CQRS.Commands.AddressCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entitites;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class CreateAddressCommandHandler
    {
        private readonly IRepository<Address> _repository;

        public CreateAddressCommandHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }
        public async Task Handle(CreatedAddressCommand createdAddressCommand)
        {
            await _repository.CreateAsync(new Address()
            {
                City = createdAddressCommand.City,
                Detail=createdAddressCommand.Detail,
                District = createdAddressCommand.District,
                UserId = createdAddressCommand.UserId  
            });
        }
    }
}
