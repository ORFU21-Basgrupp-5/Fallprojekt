using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API.Authentication;
using Microsoft.AspNetCore.Authorization;
using API.DTO;
using SERVICES;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BudgetController : ControllerBase
    {

        [Authorize]
        [HttpPost("Create")]
        public IActionResult CreateBudget(CreateBudgetDTO Budget)
        {
            object value;
            ControllerContext.HttpContext.Items.TryGetValue("Username", out value);
            
            var username = value.ToString();
            string result = BudgetService.Instance.AddBudget(Budget.Name, Budget.TotalSum, Budget.Month, Budget.Year, Budget.CategoriesAndAmount, username);
            if(result == "Added")
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
