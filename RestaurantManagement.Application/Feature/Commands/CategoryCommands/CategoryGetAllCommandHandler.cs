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
    public class CategoryGetAllCommandHandler : IRequestHandler<CategoryGetAllCommand,List<Category>>
    {
        private readonly ICategoryRepository _CategoryRepository;
        public CategoryGetAllCommandHandler(ICategoryRepository categoryRepository)
        {
            _CategoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));

        }
        public async Task<List<Category>> Handle(CategoryGetAllCommand request, CancellationToken cancellationToken)
        {
            return await _CategoryRepository.CategoryGetAll();
        }
    }
}
