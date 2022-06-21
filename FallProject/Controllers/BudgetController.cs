using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API.Authentication;
using Microsoft.AspNetCore.Authorization;
using API.DTO;
using SERVICES;
using DAL.Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BudgetController : ControllerBase
    {

        [Authorize]
        [HttpGet]
        public IActionResult ShowCurentBudget ()
        {
           
            try
            {
                object value;
                ControllerContext.HttpContext.Items.TryGetValue("Username", out value);

                var username = value.ToString();

                var result = BudgetService.Instance.GetBudget(username);
                Dictionary<string, List<string>> budgetCategories = new Dictionary<string, List<string>>();
                for (int i = 1; i < result.GetLength(1); i++)
                {
                    budgetCategories.Add(result[0,i], new List<string>{result[1,i], result[2,i], result[3, i], result[4, i] } );
                };

                var budgetDTO = new RetrieveBudgetDTO
                {
                    BudgetName = result[0,0],
                    TotalSum =  Convert.ToInt32(result[1,0]),
                    UsedAmount = Convert.ToInt32(result[2,0]),
                    BudgetCategories = budgetCategories

                };

                return Ok(budgetDTO);
            }
            catch
            {
                return BadRequest("Oops");
            }
        }
        [Authorize]
        [HttpPost]
        public IActionResult CreateBudget(CreateBudgetDTO Budget)
        {
            object value;
            ControllerContext.HttpContext.Items.TryGetValue("Username", out value);
            
            var username = value.ToString();
            string result = BudgetService.Instance.AddBudget(Budget.Name, Budget.TotalSum, Budget.Month, Budget.Year, Budget.CategoriesAndAmount, username);
            if(result == "Added")
            {
                return Ok(new
                {
                    message = result,
                    statu = true
                });
            }
            return BadRequest(result);
        }
    }
}
