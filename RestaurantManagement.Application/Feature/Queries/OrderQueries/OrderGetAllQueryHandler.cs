using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RestaurantManagement.Application.Responses;
using RestaurantManagement.infrastructure.Repository.Interfaces;

namespace RestaurantManagement.Application.Feature.Queries.OrderQueries
{
    public class OrderGetAllQueryHandler : IRequestHandler<OrderGetAllQuery, List<OrderResponse>>
    {

        private readonly IOrderRepository _orderRepository;

        public OrderGetAllQueryHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
        }

        public async Task<List<OrderResponse>> Handle(OrderGetAllQuery request, CancellationToken cancellationToken)
        {
            var orders = await _orderRepository.OrderGetAll();
            return orders.Select(order => new OrderResponse
            {
                OrderId = order.Id,
                UserId = order.UserId,
                FoodId = order.FoodId,
                FoodName = order.Food.Name,
                Quantity = order.Quantity,
                TotalPrice = order.TotalPrice,
                Status = order.Status.ToString(),

            }).ToList();
        }
    }
}
