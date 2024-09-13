﻿using MultiShop.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entitites;


namespace MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class UpdateOrderDetailCommandHandler
    {
      
            private readonly IRepository<OrderDetail> _repository;

            public UpdateOrderDetailCommandHandler(IRepository<OrderDetail> repository)
            {
                _repository = repository;
            }
            public async Task Handle(UpdateOrderDetailCommand command)
            {
                var value = await _repository.GetByIdAsync(command.OrderDetailId);
                value.OrderingId = command.OrderingId;
                value.ProductId = command.ProductId;
                value.ProductPrice = command.ProductPrice;
                value.ProductName = command.ProductName;
                value.ProductTotalPrice = command.ProductTotalPrice;
                value.ProductAmount = command.ProductAmount;
                await _repository.UpdateAsync(value);
            }
        }
    
}
