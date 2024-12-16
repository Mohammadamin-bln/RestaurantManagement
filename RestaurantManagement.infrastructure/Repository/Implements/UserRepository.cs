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
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task <User> AddUser(string username , string password)
        {
            if (await _context.Users.AnyAsync(u => u.Username == username))
                throw new Exception("username allready exists");
            var user = new User
            {
                Username = username,
                Password = password
            };
            var addedUser = _context.Set<User>().Add(user);

           await _context.SaveChangesAsync();
            return addedUser.Entity;
        }

        public Task<User?> UserLogin(string username, string password)
        {
            return  _context.Users.FirstOrDefaultAsync(x => x.Username == username);
        }

        public Task<User?> UserGetByName(string username)
        {
            return _context.Users.FirstOrDefaultAsync(u => u.Username == username);
        }

        public void UserUpdateProfile(User user)
        { 
            _context.Users.Update(user);
            _context.SaveChanges();

            
        }
        public async Task<bool> UserDelete(int userId)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null)
            {
                return false;
            }
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return true;
            
        }




    }
}
