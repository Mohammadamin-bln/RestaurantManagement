using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RestaurantManagement.Domain.Entity;
using RestaurantManagement.infrastructure.Repository.Implements;
using RestaurantManagement.infrastructure.Repository.Interfaces;

namespace RestaurantManagement.Application.Feature.Commands.FoodCommands
{
    public class FoodAddCommandHandler : IRequestHandler<FoodAddCommand, Food>
    {
        private readonly IFoodRepository _FoodRepository;
        public FoodAddCommandHandler(IFoodRepository foodRepository)
        {
            _FoodRepository = foodRepository ?? throw new ArgumentNullException(nameof(foodRepository));

        }

        public async Task<Food> Handle(FoodAddCommand request, CancellationToken cancellationToken)
        {
            string photoUrl = null;

            if (request.Photo != null)
            {
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(request.Photo.FileName);
                var uploadsFolder = Path.Combine("uploads", "foodPhotos");
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }
                var filePath = Path.Combine(uploadsFolder, fileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await request.Photo.CopyToAsync(stream);
                }
                photoUrl = $"/uploads/foodPhotos/{fileName}";
            }
            var food = new Food
            {
                Name = request.Name,
                Description = request.Description,
                Price = request.Price,
                CategoryId = request.CategoryId,
                PhotoUrl = photoUrl
            };

            var addedFood = await _FoodRepository.FoodAdd(food);
            if (addedFood == null)
            {
                throw new InvalidOperationException("failed to add the food item.");
            }
            return addedFood;


        }
    }
}
