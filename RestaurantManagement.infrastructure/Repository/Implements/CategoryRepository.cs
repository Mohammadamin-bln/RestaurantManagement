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
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;
        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<Category> CategoryAdd(Category category)
        {
             await _context.Categories.AddAsync(category);
            _context.SaveChanges();
            return category;
        }
        public Task<List<Category>> CategoryGetAll()
        {
           return _context.Categories.ToListAsync();
            
        }
    }
}
