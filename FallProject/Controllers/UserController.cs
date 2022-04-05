using API.DTO;
using API.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SERVICES;
using Microsoft.Extensions.Configuration;

namespace API.Controllers
{
    [Route("api/[controller]")]
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
                else 
                {
                    Console.WriteLine("test3");
                    throw new Exception("Kunde inte logga in");
                        
                }

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
            if (result == "all good")
            {
                var newUserLoginResult = UserService.Instance.Login(newUser.UserName, newUser.Password);
                if(newUserLoginResult != "")
                {
                    var generatedToken = _tokenService.BuildToken(_configuration["Jwt:Key"].ToString(), _configuration["Jwt:Issuer"].ToString(), newUserLoginResult);
                    return Ok(new
                    {
                        token = generatedToken,
                        user = result
                    });
                }
                return BadRequest("Login Error");
            }
            else if (result == "bad email")
            {
                return BadRequest("Bad Email");
            }

            return BadRequest(result);

        }

        [Authorize]
        [HttpPut("recover")]
        public IActionResult RecoverPassword(NewPasswordDTO newpasswordDTO)
        {
            string id;
            object value;
            ControllerContext.HttpContext.Items.TryGetValue("Username", out value);

            var username = value.ToString();
            var result = UserService.Instance.ChangePassword(newpasswordDTO.NewPassword, newpasswordDTO.ConfirmPassword, username);
            if (result == "Ok")
            {
                return Ok("Changed password");
            }

            return BadRequest(result);
        }
        
        [HttpPost("SendRecoveryEmail")]
        public IActionResult SendEmail(RecoveryDTO recoveryDTO)
        {
            var tokenuser = UserService.Instance.GetUser(recoveryDTO.Email);
            if (tokenuser != null)
            {
                var generatedToken = _tokenService.BuildToken(_configuration["Jwt:Key"].ToString(), _configuration["Jwt:Issuer"].ToString(), tokenuser);
                var result = UserService.Instance.SendRecoverEmail(recoveryDTO.Email, generatedToken);
                if (result == true)
                {
                    return Ok("Sent the email");
                }
            }
            return BadRequest("Did not send the email");

        }
    }
}

