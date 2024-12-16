using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using RestaurantManagement.Domain.Entity;
using RestaurantManagement.infrastructure.DTO;
using RestaurantManagement.infrastructure.Repository.Interfaces;

namespace RestaurantManagement.Application.Feature.Queries.ReviewQueries.ReviewHistory
{
    public class UserReviewHistoryQueryHandler : IRequestHandler<UserReviewHistoryQuery,List<ReviewHistoryDto>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IReviewRepository _reviewRepository;
        private readonly IHttpContextAccessor _contextAccessor;
        public UserReviewHistoryQueryHandler(IUserRepository userRepository, IReviewRepository reviewRepository, IHttpContextAccessor httpContextAccessor)
        {
            _contextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _reviewRepository = reviewRepository ?? throw new ArgumentNullException(nameof(reviewRepository));
        }
        public async Task<List<ReviewHistoryDto>> Handle(UserReviewHistoryQuery command, CancellationToken cancellationToken)
        {
            var claim = _contextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier);
            var username = claim?.Value;
            if(username == null)
            {
                throw new UnauthorizedAccessException("user not authorized");
            }
            var user= await _userRepository.UserGetByName(username);
            if(user == null)
            {
                throw new KeyNotFoundException("user not found");
            }
            return await _reviewRepository.UserReviewHistory(user.Id);
        }
    }
}
