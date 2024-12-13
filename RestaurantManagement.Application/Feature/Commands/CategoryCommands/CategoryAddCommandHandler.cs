using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RestaurantManagement.Domain.Entity;
using RestaurantManagement.infrastructure.Repository.Interfaces;

namespace RestaurantManagement.Application.Feature.Commands.CategoryCommands
{
    public class CategoryAddCommandHandler : IRequestHandler<CategoryAddCommand,Category>
    {
        private readonly ICategoryRepository _CategoryRepository;
        public CategoryAddCommandHandler(ICategoryRepository categoryRepository)
        {
            _CategoryRepository =  categoryRepository?? throw new ArgumentNullException(nameof(categoryRepository));

        }
        public async Task<Category> Handle(CategoryAddCommand request , CancellationToken cancellationToken)
        {
            var category = new Category
            {
                Name = request.CategoryName
            };
            if (category == null)
            {
                throw new InvalidOperationException("Failed to add the food item.");
            }
            await _CategoryRepository.CategoryAdd(category);
            return category;
        }
    }
}
