using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace RestaurantManagement.Application.Feature.Queries.Login
{
    public class LoginUserQuery : IRequest<string>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
