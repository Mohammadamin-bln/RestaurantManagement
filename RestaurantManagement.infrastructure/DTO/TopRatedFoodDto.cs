using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagement.infrastructure.DTO
{
    public class TopRatedFoodDto
    {
        public int FoodId { get; set; }
        public string Name { get; set; }
        public double AvarageRating { get; set; }

    }
}
