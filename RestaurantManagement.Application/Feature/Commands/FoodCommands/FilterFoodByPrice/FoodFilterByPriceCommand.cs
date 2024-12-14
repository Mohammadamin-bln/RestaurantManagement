using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RestaurantManagement.Domain.Entity;

namespace RestaurantManagement.Application.Feature.Commands.FoodCommands.FilterFoodByPrice
{
    public class FoodFilterByPriceCommand : IRequest<(List<Food> Food, int TotalPage)>
    {
        public decimal MinPrice { get; set; }
        public decimal MaxPrice { get; set; }
        public int CategoryId { get; set; }
        public int Page { get; set; }
    }
}
