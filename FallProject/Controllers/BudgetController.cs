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
            if (BudgetService.Instance.AddBudget(Budget.Name,Budget.TotalSum,Budget.Month,Budget.Year,Budget.CategoriesAndAmount))
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
