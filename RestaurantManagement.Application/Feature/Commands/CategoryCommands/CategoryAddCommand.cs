using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RestaurantManagement.Domain.Entity;

namespace RestaurantManagement.Application.Feature.Commands.CategoryCommands
{
    public class CategoryAddCommand : IRequest<Category>
    {
        public string CategoryName { get; set; }
    }
}
