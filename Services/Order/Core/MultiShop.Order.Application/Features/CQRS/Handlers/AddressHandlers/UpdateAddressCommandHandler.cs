﻿using MultiShop.Order.Application.Features.CQRS.Commands.AddressCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entitites;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class UpdateAddressCommandHandler
    {
        private IRepository<Address> _repository;

        private UpdateAddressCommandHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateAddressCommand command) 
        { 
            var value= await _repository.GetByIdAsync(command.AddressId);
            value.Detail=command.Detail;
            value.District=command.District;
            value.City=command.City;
            value.UserId=command.UserId;
            await _repository.UpdateAsync(value);
        }
    }
}