﻿using MediatR;
using MultiShop.Order.Application.Features.Mediator.Queries.OrderingQueries;
using MultiShop.Order.Application.Features.Mediator.Results.OrderingResults;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entitites;

namespace MultiShop.Order.Application.Features.Mediator.Handlers.OrderingHandlers
{
    public class GetOrderingByUserIdQueryHandler : IRequestHandler<GetOrderingByUserIdQuery, List<GetOrderingByUserIdQueryResult>>
    {
        private readonly IOrderingRepository _repository;

        public GetOrderingByUserIdQueryHandler(IOrderingRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetOrderingByUserIdQueryResult>> Handle(GetOrderingByUserIdQuery request, CancellationToken cancellationToken)
        {
            var values =  _repository.GetOrderingsByUserId(request.Id);

            return values.Select(x=>new GetOrderingByUserIdQueryResult
            {
                OrderDate = x.OrderDate,
                UserId = x.UserId,  
                OrderingId = x.OrderingId,  
                TotalPrice = x.TotalPrice
            }).ToList();
        }

    }
}
