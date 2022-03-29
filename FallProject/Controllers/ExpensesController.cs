using API.DTO;
using DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SERVICES;
using System.Net;
using System.Web.Http.Results;

namespace API.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class ExpensesController : ControllerBase
    {
        [Authorize]
        [HttpGet]
        public IActionResult List()
        {
            try {
            var service = new ExpensesServices();
            var result = new List<ExpenseDTO>();
            string id;
            object value;
            ControllerContext.HttpContext.Items.TryGetValue("Username", out value);

            var username = value.ToString();
            Console.WriteLine(username);
            foreach (var expenses in service.ListAllExpenses(username))
            {
                result.Add(
                    new ExpenseDTO()
                    {
                        ExpenseDate = expenses.ExpenseDate,
                        ExpenseDescription = expenses.ExpenseDescription,
                        ExpenseBalanceChange = expenses.ExpenseBalanceChange,
                    }
                    );
            }
            return Ok(result);
            
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //[HttpPost]
        [Authorize]
        [HttpPost]
        public IActionResult AddExpense(AddExpenseDTO addExpenseDTO)
        {
            
            try
            {
                ExpensesServices.Instance.InputExpenses(addExpenseDTO.ExpenseBalanceChange, addExpenseDTO.AccountId, addExpenseDTO.ExpenseDescription, addExpenseDTO.ExpenseDate, addExpenseDTO.ExpenseCategory);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("Categories")]

        public IActionResult GetCategories()
        {
            try
            {
                List<string> categories = new List<string>();
                categories = Enum.GetNames(typeof(CategoryExpense)).ToList();
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
