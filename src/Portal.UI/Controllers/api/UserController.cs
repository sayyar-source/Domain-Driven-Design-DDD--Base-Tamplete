using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Portal.Application.FoodApplication.Commands.Create;
using Portal.Application.FoodApplication.Models;
using Portal.Application.FoodApplication.Queris.FindAll;
using Portal.Application.FoodApplication.Queris.FindBy;

namespace Portal.UI.Controllers.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("create")]
        
        public async Task<IActionResult> Create(UserAddInfo user)
        {
            try
            {
                UserCreateCommand userCreate = new UserCreateCommand()
                {
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Password = user.Password,
                    Phone = user.Phone,
                    UserName = user.UserName,
                    SocialAddress = new Domain.SocialMedia(instageram: user.Instageram, telegramCanal: user.TelegramCanal, telegramGroup: user.TelegramGroup),
                    Address=new Domain.Address(street:user.Street,city:user.City,state:user.State,country:user.Country,zipcode:user.ZipCode)
                };

                var result =await _mediator.Send(userCreate);
                return Ok(result);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _mediator.Send(new GetAllUserQuery());
            return Ok(result);
        }
        [HttpGet("findbyusername")]
        public async Task<IActionResult> FindByUsername(string username)
        {
            var result =await _mediator.Send(new FindUserByUsernameQuery() { Username = username });
            return Ok(result);
        }
    }
}