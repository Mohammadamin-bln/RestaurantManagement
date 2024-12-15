using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RestaurantManagement.Domain.Entity;
using RestaurantManagement.infrastructure.Repository.Interfaces;

namespace RestaurantManagement.Application.Feature.Commands.FoodCommands.TopRatedFoods
{
    public class FoodTopRatedCommandHandler :  IRequestHandler<FoodTopRatedCommand,List<Food>>
    {
        private readonly IFoodRepository _foodRepository;
        public FoodTopRatedCommandHandler(IFoodRepository foodRepository)
        {
            _foodRepository = foodRepository ?? throw new ArgumentNullException(nameof(foodRepository));

        }
        public async Task<List<Food>> Handle(FoodTopRatedCommand request,CancellationToken cancellationToken)
        {
            return await _foodRepository.GetTopRatedFood();
        }
    }
}
