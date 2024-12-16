using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RestaurantManagement.Domain.Context;
using RestaurantManagement.Domain.Entity;
using RestaurantManagement.infrastructure.DTO;
using RestaurantManagement.infrastructure.Repository.Interfaces;

namespace RestaurantManagement.infrastructure.Repository.Implements
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly ApplicationDbContext _context;
        public ReviewRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<Review> ReviewSubmit(Review review)
        {
            var addedReview = await _context.Reviews.AddAsync(review);
            _context.SaveChanges();
            return review;
        }

        public Task<List<ReviewHistoryDto>> UserReviewHistory(int userId)
        {
            return _context.Reviews
                .Where(u => u.UserId == userId)
                .Select(u => new ReviewHistoryDto
                {
                    FoodId = u.FoodId,
                    Comment = u.Comment,
                    Rating = u.Rating,
                    CreatedAt = u.CreatedAt
                })
                .ToListAsync();
        }
        public Task<List<ReviewHistoryDto>> GetFoodComments(int foodId)
        {
            return _context.Reviews
                 .Where(u => u.FoodId == foodId)
                 .Select(u => new ReviewHistoryDto
                 {
                     FoodId = u.FoodId,
                     Comment = u.Comment,
                     Rating = u.Rating,
                     CreatedAt = u.CreatedAt
                 })
                .ToListAsync();
        }

        public Task<List<Review>> GetAllReviews()
        {
            return _context.Reviews.ToListAsync();
        }
        public async Task<bool> ReviewDelete(int reviewId)
        {
            var review = await _context.Reviews.FindAsync(reviewId);
            if (review == null)
            {
                return false;
            }
            _context.Reviews.Remove(review);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
