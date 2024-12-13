using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RestaurantManagement.Domain.Context;
using RestaurantManagement.Domain.Entity;
using RestaurantManagement.infrastructure.Repository.Interfaces;

namespace RestaurantManagement.infrastructure.Repository.Implements
{
    public class FoodRepository : IFoodRepository
    {
        private readonly ApplicationDbContext _context;
        public FoodRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Food> FoodAdd(Food food)
        {
             await _context.Foods.AddAsync(food);
            _context.SaveChanges();
            return food;
        }
        public  Task<List<Food>> FoodByCategory(int categoryId)
        {
            return _context.Foods
                .Where(x => x.CategoryId == categoryId)
                .ToListAsync();

        }
        public Task<Food?> FoodById(int id)
        {
           return _context.Foods.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
