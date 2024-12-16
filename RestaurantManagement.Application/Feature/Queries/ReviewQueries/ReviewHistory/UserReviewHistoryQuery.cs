using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RestaurantManagement.Domain.Entity;
using RestaurantManagement.infrastructure.DTO;

namespace RestaurantManagement.Application.Feature.Queries.ReviewQueries.ReviewHistory
{
    public class UserReviewHistoryQuery : IRequest<List<ReviewHistoryDto>>
    {
    }
}
