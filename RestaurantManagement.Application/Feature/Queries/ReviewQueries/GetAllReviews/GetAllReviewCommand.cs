using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RestaurantManagement.Domain.Entity;

namespace RestaurantManagement.Application.Feature.Queries.ReviewQueries.GetAllReviews
{
    public class GetAllReviewCommand : IRequest<List<Review>>
    {
    }
}
