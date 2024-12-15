using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagement.Application.Responses
{
    public class TopRatedFoodResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double AverageRating { get; set; }
    }
}
