﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantManagement.Application.Feature.Commands.CategoryCommands;
using RestaurantManagement.Application.Feature.Commands.FoodCommands.FilterFoodByPrice;
using RestaurantManagement.Application.Feature.Commands.FoodCommands.GetFoodByCategory;
using RestaurantManagement.Application.Feature.Commands.FoodCommands.TopRatedFoods;
using RestaurantManagement.Application.Feature.Commands.OrderCommands;
using RestaurantManagement.Application.Feature.Commands.ReviewCommands.SubmitReview;
using RestaurantManagement.Application.Feature.Commands.UserCommands.AddUser;
using RestaurantManagement.Application.Feature.Commands.UserCommands.UpdateUserProfile;
using RestaurantManagement.Application.Feature.Queries.FoodQueries.GetFoodComment;
using RestaurantManagement.Application.Feature.Queries.Login;
using RestaurantManagement.Application.Feature.Queries.ReviewQueries.ReviewHistory;

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
        [Authorize]
        [HttpPut("Profile/Update")]
        public async Task<IActionResult> ChangeProfile(UserUpdateProfileCommand request)
        {
            var token = await _mediator.Send(request);
            if (!token)
            {
                return BadRequest("could not change profile");
            }
            return Ok(token);
        }

        [HttpGet("filter/food")]
        public async Task<IActionResult> FilterFood([FromQuery] FoodFilterByPriceCommand request)
        {
            var token = await _mediator.Send(request);
            if (token.Food==null)
            {
                return NotFound("didnt found any food");
            }
            return Ok(new {Foods=token.Food,TotalPage=token.TotalPage});
            
        }
        [Authorize]
        [HttpPost("Review/Submit")]
        public async Task<IActionResult> SubmitReview(ReviewSubmitCommand request)
        {
            var token = await _mediator.Send(request);
            if(token == null)
            {
                return BadRequest("could not submit");
            }
            return Ok(token);
        }
        [HttpGet("Food/Top/Rated")]
        public async Task<IActionResult> GetTopRatedFoods([FromQuery] FoodTopRatedCommand request)
        {
            var token= await _mediator.Send(request);
            if(token == null)
            {
                return NotFound("no foods with reviews found.");
            }
            return Ok(token);
        }
        [HttpGet("Review/Hisotry")]
        public async Task<IActionResult> GetReviewHistory([FromQuery]UserReviewHistoryQuery request)
        {
            var token= await _mediator.Send(request);
            if( token == null)
            {
                return NotFound("didnt found any reviews");
            }
            return Ok(token);
        }

        [HttpGet("Food/Comments")]
        public async Task<IActionResult> GetFoodComments([FromQuery] GetFoodCommentQuery request)
        {
            var token= await _mediator.Send(request);
            if(token == null)
            {
                return NotFound("no comments yet");
            }
            return Ok(token);
        }





    }
}
