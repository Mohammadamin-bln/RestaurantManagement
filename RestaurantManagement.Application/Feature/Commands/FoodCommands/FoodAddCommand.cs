using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using RestaurantManagement.Domain.Entity;

namespace RestaurantManagement.Application.Feature.Commands.FoodCommands
{
    public class FoodAddCommand : IRequest<Food>
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public string Description { get; set; }

        public int CategoryId { get; set; }
        public IFormFile Photo { get; set; }
    }
}
