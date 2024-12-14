using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RestaurantManagement.Application.Responses;
using RestaurantManagement.Domain.Entity;

namespace RestaurantManagement.Application.Feature.Commands.OrderCommands
{
    public class OrderAddCommand : IRequest<OrderResponse>
    {
        public int FoodId { get; set; }
        public int Quantity { get; set; }
    }
}
