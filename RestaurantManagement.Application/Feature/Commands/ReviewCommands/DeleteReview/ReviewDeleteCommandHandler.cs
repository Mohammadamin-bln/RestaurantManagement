using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RestaurantManagement.infrastructure.Repository.Interfaces;

namespace RestaurantManagement.Application.Feature.Commands.ReviewCommands.DeleteReview
{
    public class ReviewDeleteCommandHandler : IRequestHandler<ReviewDeleteCommand, bool>
    {
        private readonly IReviewRepository _reviewRepository;

        public ReviewDeleteCommandHandler(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;

        }

        public async Task<bool> Handle(ReviewDeleteCommand request,CancellationToken cancellationToken)
        {
            return await _reviewRepository.ReviewDelete(request.ReviewId);
        }
    }
}
