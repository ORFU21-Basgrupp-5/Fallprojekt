﻿using API.DTO;
using API.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SERVICES;
using Microsoft.Extensions.Configuration;

namespace API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly ITokenService _tokenService;
        private readonly IConfiguration _configuration;
        public UserController(ITokenService tokenService, IConfiguration config)
        {
            _tokenService = tokenService;
            _configuration = config;
        }



        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login(UserLoginDTO userLoginDTO)
        {

            try
            {
                if (string.IsNullOrEmpty(userLoginDTO.UserName) || string.IsNullOrEmpty(userLoginDTO.Password))
                {
                    throw new Exception("Måste fylla i samtliga fält");
                }



                var result = UserService.Instance.Login(userLoginDTO.UserName, userLoginDTO.Password);
                if (result != "")
                {
                    var generatedToken = _tokenService.BuildToken(_configuration["Jwt:Key"].ToString(), _configuration["Jwt:Issuer"].ToString(), result);
                    return Ok(new
                    {
                        token = generatedToken,
                        user = result
                    });
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpPost("Secret")]
        public ActionResult SecretFunction()
        {
            return Ok("Alright, you are authorized user");
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register(UserDTO newUser)
        {

            var result = UserService.Instance.RegisterNewAccount(newUser.UserName, newUser.Password, newUser.Email);
            if (result == "true")
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
    }
}
