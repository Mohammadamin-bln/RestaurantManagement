﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RestaurantManagement.Domain.Entity;
using RestaurantManagement.infrastructure.DTO;

namespace RestaurantManagement.Application.Feature.Commands.FoodCommands.TopRatedFoods
{
    public class FoodTopRatedCommand : IRequest<List<TopRatedFoodDto>>
    {
    }
}
