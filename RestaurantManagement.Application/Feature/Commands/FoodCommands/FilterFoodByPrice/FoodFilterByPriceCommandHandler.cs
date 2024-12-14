using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RestaurantManagement.Domain.Entity;
using RestaurantManagement.infrastructure.Repository.Interfaces;

namespace RestaurantManagement.Application.Feature.Commands.FoodCommands.FilterFoodByPrice
{
    public class FoodFilterByPriceCommandHandler : IRequestHandler<FoodFilterByPriceCommand, (List<Food> Food, int TotalPage)>
    {
        private readonly IFoodRepository _foodRepository;
        public FoodFilterByPriceCommandHandler(IFoodRepository foodRepository)
        {
            _foodRepository = foodRepository;
        }

        public async Task<(List<Food> Food, int TotalPage)> Handle(FoodFilterByPriceCommand request, CancellationToken cancellationToken)
        {

            int pageSize = 5;
            var foodQuery = _foodRepository.FoodFilterByPrice();

            foodQuery = foodQuery.Where(f => f.CategoryId == request.CategoryId)
                                 .Where(f => f.Price >= request.MinPrice)
                                 .Where(f => f.Price <= request.MaxPrice);

            int totalCount = await foodQuery.CountAsync();

            int totalPages = totalCount / pageSize;

            var foodList = await foodQuery.Skip((request.Page - 1) * pageSize)

                .Take(pageSize).ToListAsync();

            return (foodList, totalPages);
        }
    }
}
