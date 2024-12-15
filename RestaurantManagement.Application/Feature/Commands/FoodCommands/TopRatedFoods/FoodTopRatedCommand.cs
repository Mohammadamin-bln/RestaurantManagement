using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RestaurantManagement.Domain.Entity;

namespace RestaurantManagement.Application.Feature.Commands.FoodCommands.TopRatedFoods
{
    public class FoodTopRatedCommand : IRequest<List<Food>>
    {
    }
}
