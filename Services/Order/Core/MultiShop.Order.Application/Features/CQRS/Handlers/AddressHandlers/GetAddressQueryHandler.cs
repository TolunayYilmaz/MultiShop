﻿using MultiShop.Order.Application.Features.CQRS.Results.AddressResults;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entitites;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class GetAddressQueryHandler
    {
        private IRepository<Address> _repository;

        private GetAddressQueryHandler(IRepository<Address> reposity)
        {
            _repository = reposity;
        }

        public async Task<List<GetAddressQueryResult>> Handle()
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetAddressQueryResult
            {
                AddressId = x.AddressId,
                City = x.City,
                Detail = x.Detail,
                District = x.District,
                UserId = x.UserId

            }).ToList();
        }
    }
}
