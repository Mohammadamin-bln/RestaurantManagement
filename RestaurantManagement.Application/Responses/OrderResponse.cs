using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagement.Application.Responses
{
    public class OrderResponse
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public int FoodId { get; set; }
        public string? FoodName { get; set; } 
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public string? Status { get; set; }
    }
}
