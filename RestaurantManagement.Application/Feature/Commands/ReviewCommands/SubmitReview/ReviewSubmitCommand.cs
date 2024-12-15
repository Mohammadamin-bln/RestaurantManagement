using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RestaurantManagement.Application.Responses;
using RestaurantManagement.Domain.Entity;

namespace RestaurantManagement.Application.Feature.Commands.ReviewCommands.SubmitReview
{
    public class ReviewSubmitCommand : IRequest<ReviewSubmitResponse>
    {
        public int FoodId { get; set; }
        public string Comment { get; set; }
        public int Rate { get; set; }
    }
}
