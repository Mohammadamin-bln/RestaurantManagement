using RestaurantManagement.Domain.Entity;

namespace RestaurantManagement.infrastructure.Repository.Interfaces
{
    public interface IUserRepository
    {
        public Task<User> AddUser(string username, string password);

        public Task<User?> UserLogin(string username, string password);

        public Task<User?> UserGetByName(string username);
    }
}
