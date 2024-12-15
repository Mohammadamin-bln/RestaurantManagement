using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using RestaurantManagement.Application.Responses;
using RestaurantManagement.Domain.Entity;
using RestaurantManagement.infrastructure.Repository.Implements;
using RestaurantManagement.infrastructure.Repository.Interfaces;

namespace RestaurantManagement.Application.Feature.Commands.ReviewCommands.SubmitReview
{
    public class ReviewSubmitCommandHandler : IRequestHandler<ReviewSubmitCommand, ReviewSubmitResponse>
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IUserRepository _userRepository;
        public ReviewSubmitCommandHandler(IReviewRepository reviewRepository,IHttpContextAccessor httpContextAccessor , IUserRepository userRepository)
        {
            _reviewRepository = reviewRepository ?? throw new ArgumentNullException(nameof(reviewRepository));
            _contextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        public async Task<ReviewSubmitResponse> Handle(ReviewSubmitCommand request,CancellationToken cancellationToken)
        {
            var claim = _contextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier);
            var username = claim?.Value;

            if (username == null)
            {
                throw new UnauthorizedAccessException("user not authorized");
            }
            var user= await _userRepository.UserGetByName(username);
            if (user == null)
            {
                throw new KeyNotFoundException("could not find the user");
            }
            if(request.Rate>5 || request.Rate < 0)
            {
                throw new Exception("rate should be 1to5");
            }
            var review = new Review
            {
                UserId = user.Id,
                FoodId = request.FoodId,
                Comment = request.Comment,
                Rating = request.Rate,
            };

            var addedReview= await _reviewRepository.ReviewSubmit(review);

            return new ReviewSubmitResponse
            {
                ReviewId=review.Id,
                FoodId=request.FoodId,
                UserId=user.Id,
                Comment=request.Comment,
                Rate=request.Rate,
            } ;

        }
    }
}
