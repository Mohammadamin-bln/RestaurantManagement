﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantManagement.Application.Feature.Commands.CategoryCommands;
using RestaurantManagement.Application.Feature.Commands.FoodCommands;
using RestaurantManagement.Application.Feature.Commands.UserCommands;
using RestaurantManagement.Application.Feature.OrderCommands;
using RestaurantManagement.Application.Feature.Queries.Login;

namespace RestaurantManagement.presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("singup")]
        public async Task<IActionResult> AddUser(AddUserCommand request)
        {
            var token = await _mediator.Send(request);

            if (token == null)
            {
                return BadRequest("cant add user");
            }
            return Ok("successfully registered");
        }
        [HttpPost("SingIn")]
        public async Task<IActionResult> UserLogin(LoginUserQuery request)
        {
            var token = await _mediator.Send(request);
            if (token == null)
            {
                return BadRequest("cant add user");
            }
            return Ok(token);
        }
        
        [HttpPost("Category/All")]
        public async Task<IActionResult> CategoryGetAll([FromQuery] CategoryGetAllCommand request)
        {
            var token= await _mediator.Send(request);
            if (token == null)
            {
                return BadRequest("not found any category");
            }
            return Ok(token);

        }
        
        [HttpGet("foods/by/category")]
        public async Task<IActionResult> FoodByCategory([FromQuery] FoodByCategoryCommand request)
        {
            var token = await _mediator.Send(request);
            if (token == null)
            {
                return BadRequest("didnt found any food");
            }
            return Ok(token);
        }

        [HttpPost("Order/submit")]
        public async Task<IActionResult> SendOrder(OrderAddCommand request)
        {
            var token=await _mediator.Send(request);
            if (token == null)
            {
                return BadRequest("could not submit order");
            }
            return Ok(token);
        }



    }
}