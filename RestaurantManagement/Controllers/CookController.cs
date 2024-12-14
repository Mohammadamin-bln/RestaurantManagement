using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantManagement.Application.Feature.Commands.CategoryCommands;
using RestaurantManagement.Application.Feature.Commands.FoodCommands.AddFood;
using RestaurantManagement.Application.Feature.Commands.OrderCommands;
using RestaurantManagement.Application.Feature.Queries.OrderQueries;

namespace RestaurantManagement.presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CookController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CookController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Food/Add")]
        public async Task<IActionResult> FoodAdd(FoodAddCommand request)
        {
            var token = await _mediator.Send(request);
            if (token==null)
            {
                return BadRequest("coult not add food");
            }

            return Ok(token);
        }


        [HttpPost("Category/Add")]
        public async Task<IActionResult> CategoryAdd(CategoryAddCommand request)
        {
            var token = await _mediator.Send(request);
            if (token==null)
            {
                return BadRequest("could not add category");
            }
            return Ok(token);
        }

        [HttpGet("All/Orders")]
        public async Task<IActionResult> OrderList([FromQuery]OrderGetAllQuery request)
        {
            var token= await _mediator.Send(request);
            if (token==null)
            {
                return NotFound("not found any orders");
            }
            return Ok(token);
        }

        [HttpPut("update/order/status")]
        public async Task<IActionResult> OrderUpdateStatus(OrderUpdateCommand request)
        {
            var token = await _mediator.Send(request);
            if (!token)
            {
                return BadRequest("could not update order");
            }
            return Ok("successfully updated");
        }
    }
}
