using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantManagement.Domain.Entity;
using RestaurantManagement.infrastructure.DTO;

namespace RestaurantManagement.infrastructure.Repository.Interfaces
{
    public interface IReviewRepository
    {
        public Task<Review> ReviewSubmit(Review review);

        public Task<List<ReviewHistoryDto>> UserReviewHistory(int userId);

        public Task<List<ReviewHistoryDto>> GetFoodComments(int foodId);
        public Task<List<Review>> GetAllReviews();

        public Task<bool> ReviewDelete(int id);
    }
}
