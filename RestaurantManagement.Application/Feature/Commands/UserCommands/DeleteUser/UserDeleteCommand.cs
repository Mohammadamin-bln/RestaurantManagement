using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace RestaurantManagement.Application.Feature.Commands.UserCommands.DeleteUser
{
    public class UserDeleteCommand : IRequest<bool>
    {
        public int UserId { get; set; }
    }
}
