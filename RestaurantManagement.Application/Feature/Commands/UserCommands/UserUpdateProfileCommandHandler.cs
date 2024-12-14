using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using RestaurantManagement.infrastructure.Repository.Interfaces;

namespace RestaurantManagement.Application.Feature.Commands.UserCommands
{
    public class UserUpdateProfileCommandHandler : IRequestHandler<UserUpdateProfileCommand,bool>
    {
        private readonly IUserRepository _userRepository;
        private readonly IHttpContextAccessor _contextAccessor;
        public UserUpdateProfileCommandHandler(IUserRepository userRepository, IHttpContextAccessor httpContextAccessor)
        {
            _userRepository = userRepository;
            _contextAccessor = httpContextAccessor;
            
        }

        public async Task<bool> Handle(UserUpdateProfileCommand request , CancellationToken cancellationToken)
        {
            var claim = _contextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier);
            var username = claim?.Value;
            if (username == null)
            {
                throw new UnauthorizedAccessException("user not authorized");
            }

            var user = await _userRepository.UserGetByName(username);
            if (user == null)
            {
                throw new KeyNotFoundException("could not find the user");
            }

            if (!string.IsNullOrEmpty(request.Username)&& request.Username!=user.Username)
            {
                user.Username = request.Username;
            }
            bool isPasswordValid= BCrypt.Net.BCrypt.Verify(request.CurrentPassword, user.Password);
            if (!isPasswordValid)
            {
                throw new UnauthorizedAccessException("invalid password");
            }
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(request.NewPassword);
            user.Password = hashedPassword;

             _userRepository.UserUpdateProfile(user);

            return true;



        }
    }
}
