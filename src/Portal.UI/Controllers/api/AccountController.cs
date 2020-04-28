using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Portal.Domain;
using Portal.Infrastructure.Persistance.Repositories;

namespace Portal.UI.Controllers.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        IUserRepository _userRepository;
        public AccountController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        [HttpPost("login")]
        public JsonResult Login(User user)
        {
            try
            {
                var token = _userRepository.Login(user);
                return new JsonResult(token);
            }
            catch (Exception)
            {

                throw;
            }


        }

    }
}