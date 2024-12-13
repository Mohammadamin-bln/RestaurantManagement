﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RestaurantManagement.Domain.Enum;

namespace RestaurantManagement.Application.Feature.OrderCommands
{
    public class OrderUpdateCommand : IRequest<bool>
    {
        public int OrderId { get; set; }

        public OrderStatusEnum.OrderStatus NewStatus { get; set; }
    }
}
