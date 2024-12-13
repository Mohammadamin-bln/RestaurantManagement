using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagement.Domain.Enum
{
    public class OrderStatusEnum
    {
        public enum OrderStatus
        {
            Pending=1,
            Shipped=2,
            Delivered=3,
            Cancelled=4
        }
    }
}
