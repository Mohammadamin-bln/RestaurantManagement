using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using RestaurantManagement.Domain.Entity;
using RestaurantManagement.infrastructure.Repository.Implements;
using RestaurantManagement.infrastructure.Repository.Interfaces;
using System.Security.Claims;
using RestaurantManagement.Application.Responses;

namespace RestaurantManagement.Application.Feature.Commands.OrderCommands
{
    public class OrderAddCommandHandler : IRequestHandler<OrderAddCommand, OrderResponse>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserRepository _userRepository;
        private readonly IFoodRepository _foodRepository;

        public OrderAddCommandHandler(IOrderRepository orderRepository, IHttpContextAccessor httpContextAccessor, IUserRepository userRepository, IFoodRepository foodRepository)
        {
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
            _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _foodRepository = foodRepository ?? throw new ArgumentNullException(nameof(foodRepository));


        }

        public async Task<OrderResponse> Handle(OrderAddCommand request, CancellationToken cancellationToken)
        {
            var claim = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier);
            var username = claim?.Value;
            if (username == null)
            {
                throw new UnauthorizedAccessException("user not authorized");
            }
            var user = await _userRepository.UserGetByName(username);
            if (user == null)
            {
                throw new KeyNotFoundException("user not found");
            }
            var food = await _foodRepository.FoodById(request.FoodId);
            if (food == null)
            {
                throw new KeyNotFoundException("food not found");
            }

            var order = new Order
            {
                UserId = user.Id,
                FoodId = request.FoodId,
                Quantity = request.Quantity,
                Food = food
            };

            var addedOrder = await _orderRepository.OrderAdd(order);

            return new OrderResponse
            {
                OrderId = addedOrder.Id,
                UserId = addedOrder.Id,
                FoodId = addedOrder.FoodId,
                FoodName = food.Name,
                Quantity = addedOrder.Quantity,
                TotalPrice = addedOrder.TotalPrice,
                Status = addedOrder.Status.ToString(),
            };

        }

    }
}
