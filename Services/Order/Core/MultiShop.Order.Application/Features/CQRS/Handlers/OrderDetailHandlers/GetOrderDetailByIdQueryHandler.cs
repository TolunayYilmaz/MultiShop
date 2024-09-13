﻿using MultiShop.Order.Application.Features.CQRS.Queries.OrderDetailQueries;
using MultiShop.Order.Application.Features.CQRS.Results.OrderDetailResults;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entitites;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class GetOrderDetailByIdQueryHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public GetOrderDetailByIdQueryHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }

        public async Task<GetOrderDetailByIdQueryResult> Handle(GetOrderDetailByIdQuery query)
        {
            var value = await _repository.GetByIdAsync(query.Id);
            return  new GetOrderDetailByIdQueryResult()
            {
                OrderDetailId = value.OrderDetailId,
                ProductAmount = value.ProductAmount,
                ProductName = value.ProductName,
                OrderingId = value.OrderingId,
                ProductId = value.ProductId,
                ProductPrice = value.ProductPrice,
                ProductTotalPrice = value.ProductTotalPrice

            };
        }
    }
}
