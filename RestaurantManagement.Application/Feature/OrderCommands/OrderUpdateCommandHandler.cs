using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RestaurantManagement.infrastructure.Repository.Interfaces;

namespace RestaurantManagement.Application.Feature.OrderCommands
{
    public class OrderUpdateCommandHandler : IRequestHandler<OrderUpdateCommand,bool>
    { 
        private readonly IOrderRepository _orderRepository;
        public OrderUpdateCommandHandler( IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
            
        }

        public async Task<bool> Handle(OrderUpdateCommand request,CancellationToken cancellationToken)
        {
            var order= await _orderRepository.OrderById(request.OrderId);
            if (order == null)
            {
                throw new KeyNotFoundException("order not found");
            }

            _orderRepository.OrderUpdate(order);
            return true;
        }
    }
}
