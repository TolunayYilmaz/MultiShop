using MediatR;
using MultiShop.Order.Application.Features.Mediator.Results;

namespace MultiShop.Order.Application.Features.Mediator.Queries.OrderingQueries
{
    public class GetOrderingQuery:IRequest<List<GetOrderingQueryResult>>
    {
  
    } 
}
