using API.DTO;
using Microsoft.AspNetCore.Mvc;
using SERVICES;

namespace API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        [HttpGet("Login")]
        public IActionResult Login(string userName, string passWord) {
            var result = UserService.Instance.Login(userName, passWord);
            if(result == true)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpPost("register")]
        public IActionResult Register(UserDTO newUser)
        {
            
                var result = UserService.Instance.RegisterNewAccount(newUser.UserName, newUser.Password, newUser.Email);
                if(result)
                return Ok(result);
                return BadRequest();
         
        }
    }
}
