using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RestaurantManagement.Domain.Entity;
using RestaurantManagement.infrastructure.Repository.Interfaces;

namespace RestaurantManagement.Application.Feature.Commands.FoodCommands
{
    public class FoodByCategoryCommandHandler : IRequestHandler<FoodByCategoryCommand,List<Food>>
    {
        private readonly IFoodRepository _FoodRepository;
        public FoodByCategoryCommandHandler(IFoodRepository foodRepository)
        {
            _FoodRepository = foodRepository ?? throw new ArgumentNullException(nameof(foodRepository));

        }
        public async Task<List<Food>> Handle(FoodByCategoryCommand request,CancellationToken cancellationToken)
        {
            var foods= await _FoodRepository.FoodByCategory(request.CategoryId);
            if (foods==null)
            {
                throw new KeyNotFoundException("not found any foods");
            }
            return foods;
        }
    }
}
