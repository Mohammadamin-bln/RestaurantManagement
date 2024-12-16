using Azure.Core.Extensions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using RestaurantManagement.Application.Feature.Commands.ReviewCommands.DeleteReview;
using RestaurantManagement.Application.Feature.Commands.UserCommands.DeleteUser;
using RestaurantManagement.Application.Feature.Queries.ReviewQueries.GetAllReviews;

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
        [Authorize(Roles = "admin")]
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
        [Authorize(Roles = "admin")]
        [HttpGet("review/get/all")]
        public async Task<IActionResult> GetAllReviews([FromQuery]GetAllReviewCommand request)
        {

            var token = await _mediator.Send(request);
            if (token == null)
            {
                return NotFound("didnt found any reviews");
            }
            return Ok(token);
        }
        [Authorize(Roles ="admin")]
        [HttpDelete("Review/Delete")]
        public async Task<IActionResult> DeleteReview([FromQuery] ReviewDeleteCommand request)
        {
            var token = await _mediator.Send(request);
            if (!token)
            {
                return BadRequest("could not delete review");
            }
            return Ok("successfully deleted the Review");
        }

    }
}
