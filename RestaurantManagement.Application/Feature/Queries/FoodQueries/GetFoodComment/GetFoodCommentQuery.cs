using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RestaurantManagement.infrastructure.DTO;

namespace RestaurantManagement.Application.Feature.Queries.FoodQueries.GetFoodComment
{
    public class GetFoodCommentQuery : IRequest<List<ReviewHistoryDto>>
    {
        public int FoodId { get; set; }
    }
}
