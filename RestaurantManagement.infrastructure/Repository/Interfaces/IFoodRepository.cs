using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantManagement.Domain.Entity;

namespace RestaurantManagement.infrastructure.Repository.Interfaces
{
    public interface IFoodRepository
    {

        public  Task<Food> FoodAdd(Food food);

        public Task<List<Food>> FoodByCategory(int categoryId);

        public IQueryable<Food> FoodFilterByPrice();

        public Task<Food?> FoodById(int id);
        public Task<List<Food>> GetTopRatedFood();
    }
}
