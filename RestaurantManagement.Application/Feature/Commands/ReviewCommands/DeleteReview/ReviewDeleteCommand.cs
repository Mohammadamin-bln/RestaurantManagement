using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace RestaurantManagement.Application.Feature.Commands.ReviewCommands.DeleteReview
{
    public class ReviewDeleteCommand : IRequest<bool>
    {
        public int ReviewId { get; set; }
    }
}
