using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RestaurantManagement.Domain.Entity;
using RestaurantManagement.infrastructure.Repository.Interfaces;

namespace RestaurantManagement.Application.Feature.Commands.UserCommands
{
    public class AddUserCommandHandler : IRequestHandler<AddUserCommand, User>
    {

        private readonly IUserRepository _userRepository;
        public AddUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));

        }
        public async Task<User> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(request.Password);
            return await _userRepository.AddUser(request.Username, hashedPassword);
        }
    }
}
