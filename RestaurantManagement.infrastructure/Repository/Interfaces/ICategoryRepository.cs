using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using RestaurantManagement.Domain.Entity;

namespace RestaurantManagement.infrastructure.Repository.Interfaces
{
    public interface ICategoryRepository
    {
        public Task<Category> CategoryAdd(Category category);

        public Task<List<Category>> CategoryGetAll();
    }
}
