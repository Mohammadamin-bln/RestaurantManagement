using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagement.infrastructure.DTO
{
    public class ReviewHistoryDto
    {
        public int FoodId { get; set; }
        public string Comment { get; set; }
        public double Rating { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
