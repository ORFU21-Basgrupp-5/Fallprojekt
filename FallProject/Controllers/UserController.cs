using API.DTO;
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
        public UserController(ITokenService tokenService,  IConfiguration config)
        {
            _tokenService = tokenService;
            _configuration = config;
        }



        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login(UserLoginDTO userLoginDTO) {

            if (string.IsNullOrEmpty(userLoginDTO.UserName) || string.IsNullOrEmpty(userLoginDTO.Password))
            {
                return RedirectToAction("Error");
            }



            var result = UserService.Instance.Login(userLoginDTO.UserName, userLoginDTO.Password);
            if(result != "")
            {
                var generatedToken = _tokenService.BuildToken(_configuration["Jwt:Key"].ToString(), _configuration["Jwt:Issuer"].ToString(), result);
                return Ok(new
                {
                    token = generatedToken,
                    user = result
                });
            }
            return RedirectToAction("Error");
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
            if(result == "all good")
            {
                return Ok(result);
            } else if(result == "bad email")
            {
               return BadRequest("Bad Email");
            }
                    
            return BadRequest();
         
        }
    }
}
