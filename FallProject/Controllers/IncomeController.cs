using Microsoft.AspNetCore.Authorization;
using DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SERVICES;
using API.DTO;
using System.Linq;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncomeController : ControllerBase
    {
        [Authorize]
        [HttpGet]
        public IActionResult List()
        {
            var service = new IncomeServices();
            var result = new List<IncomeDTO>();
            string id;
            object value;
            ControllerContext.HttpContext.Items.TryGetValue("Username", out value);

            var username = value.ToString();
            Console.WriteLine(username);
            foreach (var incomes in service.ListAllIncomes(username))
            {
                result.Add(
                    new IncomeDTO()
                    {
                        IncomeId = incomes.IncomeId,
                        IncomeDate = incomes.IncomeDate,
                        IncomeDescription = incomes.IncomeDescription,
                        IncomeBalanceChange = incomes.IncomeBalanceChange,

                     }
                    );
            }
            return Ok(result);
        }

        //[HttpPost]
        [Authorize]
        [HttpPost]
        public IActionResult AddIncome(AddIncomeDTO addIncomeDTO)
        {
            
            try
            {
                IncomeServices.Instance.InputIncome(addIncomeDTO.IncomeBalanceChange, addIncomeDTO.AccountId, addIncomeDTO.IncomeDescription, addIncomeDTO.IncomeDate, addIncomeDTO.IncomeCategory);
                return Ok(new
                {
                    message = "Income Added",
                    statu = true
                });
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }
        [AllowAnonymous]
        [HttpGet]
        [Route("categories")]
        public IActionResult GetCategories()
        { 
            try
            {
                List<string> categories = new List<string>();
                categories = Enum.GetNames(typeof(CategoryIncome)).ToList();
                return Ok(categories);
            }
            catch
            {
                return NotFound();
            }
            
            
        }
        //[HttpDelete]

    }
}
