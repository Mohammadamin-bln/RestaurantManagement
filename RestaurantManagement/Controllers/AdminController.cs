using Azure.Core.Extensions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using RestaurantManagement.Application.Feature.Commands.UserCommands.DeleteUser;

namespace RestaurantManagement.presentation.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AdminController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpDelete("user/delete")]
        public async Task<IActionResult> DeleteUser(UserDeleteCommand request)
        {
            var token = await _mediator.Send(request);
            if (!token)
            {
                return NotFound("didnt found any user ");
            }
            return Ok("successfully deleted the user");
        }
    }
}
