using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantManagement.Domain.Base;
using RestaurantManagement.Domain.Enum;

namespace RestaurantManagement.Domain.Entity
{
    public class Order : BaseEntities
    {

        public int UserId { get; set; }

        public int FoodId { get; set; }
        public int Quantity { get; set; }
        public User User { get; set; }
        public Food Food { get; set; }
        public decimal TotalPrice => Food.Price * Quantity ;

        

        public OrderStatusEnum.OrderStatus Status { get; set; } = OrderStatusEnum.OrderStatus.Pending;
    }
}
