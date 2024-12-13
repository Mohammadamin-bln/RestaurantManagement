using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RestaurantManagement.Application.Responses;

namespace RestaurantManagement.Application.Feature.Queries.OrderQueries
{
    public class OrderGetAllQuery : IRequest<List<OrderResponse>>
    {
    }
}
