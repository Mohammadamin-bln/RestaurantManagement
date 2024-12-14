using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace RestaurantManagement.Application.Feature.Commands.UserCommands.UpdateUserProfile
{
    public class UserUpdateProfileCommand : IRequest<bool>
    {
        public string Username { get; set; }
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
