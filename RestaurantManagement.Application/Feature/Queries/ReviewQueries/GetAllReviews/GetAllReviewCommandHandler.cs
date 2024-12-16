using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RestaurantManagement.Domain.Entity;
using RestaurantManagement.infrastructure.Repository.Interfaces;

namespace RestaurantManagement.Application.Feature.Queries.ReviewQueries.GetAllReviews
{
    public class GetAllReviewCommandHandler : IRequestHandler<GetAllReviewCommand,List<Review>>
    {
        IReviewRepository _reviewRepository;
        public GetAllReviewCommandHandler(IReviewRepository reviewRepository)
        {
            
            _reviewRepository = reviewRepository;
        }
        public async Task<List<Review>> Handle(GetAllReviewCommand request,CancellationToken cancellationToken)
        {
            return await  _reviewRepository.GetAllReviews();
        }
    }
}
