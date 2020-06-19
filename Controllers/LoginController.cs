using Microsoft.AspNetCore.Authorization;    
using Microsoft.AspNetCore.Mvc;    
using Microsoft.Extensions.Configuration;    
using Microsoft.IdentityModel.Tokens;    
using System;    
using System.IdentityModel.Tokens.Jwt;    
using System.Security.Claims;    
using System.Text;    
using DailyExperienceApi.Models;    
using DailyExperienceApi.Services;
namespace DailyExperienceApi.Controllers    
{    
    [Route("api/[controller]")]    
    [ApiController]    
    public class LoginController : Controller    
    {    
        private IConfiguration _config;  
          private readonly UserService _userService;  
    
        public LoginController(IConfiguration config ,UserService userService)    
        {    
            _config = config;    
            _userService = userService;
        }    
        [AllowAnonymous]    
        [HttpPost]    
        public IActionResult Login([FromBody]UserModel login)    
        {    
            IActionResult response = Ok();    
            var user = AuthenticateUser(login);    
    
            if (user != null)    
            {    
                var tokenString = GenerateJSONWebToken(user);    
                response = Ok(new { token = tokenString , email = user.Email});    
            } 
            else{
                  response = Ok(new { error = "Invalid username or password" });  
            }   
    
            return response;    
        }    
    
        private string GenerateJSONWebToken(UserModel userInfo)    
        {    
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));    
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);    
      var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Email, userInfo.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],    
              _config["Jwt:Issuer"],    
              claims,    
              expires: DateTime.Now.AddMinutes(120),    
              signingCredentials: credentials);    
    
            return new JwtSecurityTokenHandler().WriteToken(token);    
        }    
    
        private UserModel AuthenticateUser(UserModel login)    
        {    
            UserModel user = null;    
            var userInfo = _userService.GetByEmail(login.Email,login.Password);
    
            //Validate the User Credentials    
            //Demo Purpose, I have Passed HardCoded User Information    
            if (userInfo!=null)    
            {    
                user = new UserModel { Email = userInfo.Email };    
            }    
            return user;    
        }    
    }    
}   