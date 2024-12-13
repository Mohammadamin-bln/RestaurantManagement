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
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _context;
        public OrderRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Order> OrderAdd(Order order)
        {
            var addedOrder= await _context.Orders.AddAsync(order);
            _context.SaveChanges();
            return order;
        }

        public Task<List<Order>> OrderGetAll()
        {
             return  _context.Orders.Include(x=>x.Food).ToListAsync();
        }
        public async Task<Order?> OrderById(int id)
        {
            return await _context.Orders.FindAsync(id);
        }

        public void OrderUpdate(Order order)
        {
            _context.Orders.Update(order);
            _context.SaveChangesAsync();
            
        }
    }
}
