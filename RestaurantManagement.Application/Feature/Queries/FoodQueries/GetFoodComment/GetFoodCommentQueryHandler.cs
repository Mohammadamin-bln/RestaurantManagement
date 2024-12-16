using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RestaurantManagement.infrastructure.DTO;
using RestaurantManagement.infrastructure.Repository.Interfaces;

namespace RestaurantManagement.Application.Feature.Queries.FoodQueries.GetFoodComment
{
    public class GetFoodCommentQueryHandler : IRequestHandler<GetFoodCommentQuery, List<ReviewHistoryDto>>
    {
        IReviewRepository _reviewRepository;
        public GetFoodCommentQueryHandler( IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        public async Task<List<ReviewHistoryDto>> Handle(GetFoodCommentQuery request, CancellationToken cancellationToken)
        {
            return await _reviewRepository.GetFoodComments(request.FoodId);
        }
    }
}
