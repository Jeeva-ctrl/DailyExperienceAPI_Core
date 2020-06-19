using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DailyExperienceApi.Services;
using DailyExperienceApi.Models;

namespace DailyExperienceApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegisterController : ControllerBase
    {

        private readonly UserService _userService;

        public RegisterController(UserService userService)
        {
            _userService = userService;
        }





        [HttpGet]
        public IEnumerable<User> Index()
        {
            var users = _userService.Get().ToList();
            return users;
        }

        [HttpPost]
        public IActionResult Index(User user)
        {
            var users = _userService.Get().ToList();
            var result = new Result();
            if (users.Any(x => x.Email == user.Email))
            {
                result.IsSuccess = false;
                result.Error = "Email already registered";
                return Ok(result);
            }
            if (users.Any(x => x.Username == user.Username))
            {
                result.IsSuccess = false;
                result.Error = "User name already exists";
                return Ok(result);
            }
            var userInfo = _userService.Create(user);
            return Ok(result);
        }
    }
}
