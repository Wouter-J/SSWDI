using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AS_Core.DomainModel;
using AS_DomainServices.Services;
using Microsoft.AspNetCore.Mvc;

namespace AS_WebService.Controllers
{
    [ApiController]
    [Route("/api/user")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("name")]
        public IActionResult GetUserByName([FromQuery] string username)
        {
            User user = _userService.FindByUsername(username);
            return Ok(user);
        }
    }
}
