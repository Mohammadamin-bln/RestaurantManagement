using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RestaurantManagement.Domain.Entity;

namespace RestaurantManagement.Application.Feature.Commands.UserCommands
{
    public class AddUserCommand : IRequest<User>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
