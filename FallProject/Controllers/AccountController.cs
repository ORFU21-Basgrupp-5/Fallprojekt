using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API.Authentication;
using Microsoft.AspNetCore.Authorization;
using SERVICES;
using API.DTO;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        [Authorize]
        [HttpGet]
        public IActionResult ShowAccounts()
        {

            try
            {
                var service = new AccountService();
                var result = new List<AccountDTO>();
                ControllerContext.HttpContext.Items.TryGetValue("Username", out object value);

                var username = value?.ToString();

                foreach (var account in service.GetAccounts(username))
                {
                    result.Add(
                        new AccountDTO()
                        {
                            Id = account.AccountId,
                            Name = account.Name,
                            Balance = account.Balance,
                        });
                }

                return Ok(result);
            }
            catch
            {
                return BadRequest("Can't gett accounts");
            }
        }
    }
}
