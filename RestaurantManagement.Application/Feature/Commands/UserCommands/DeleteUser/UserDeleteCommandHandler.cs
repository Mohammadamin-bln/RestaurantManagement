using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RestaurantManagement.infrastructure.Repository.Interfaces;

namespace RestaurantManagement.Application.Feature.Commands.UserCommands.DeleteUser
{
    public class UserDeleteCommandHandler : IRequestHandler<UserDeleteCommand,bool>
    {
        private readonly IUserRepository _userRepository;
        public UserDeleteCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            
        }

        public async Task<bool> Handle(UserDeleteCommand request,CancellationToken cancellationToken)
        {
            return await _userRepository.UserDelete(request.UserId);
        }
    }
}
