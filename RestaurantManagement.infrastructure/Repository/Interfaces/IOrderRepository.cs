using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantManagement.Domain.Entity;

namespace RestaurantManagement.infrastructure.Repository.Interfaces
{
    public interface IOrderRepository
    {
        public Task<Order> OrderAdd(Order order);
        public Task<List<Order>>OrderGetAll();
        public Task<Order?> OrderById(int id);
        public void OrderUpdate(Order order);
    }
}
