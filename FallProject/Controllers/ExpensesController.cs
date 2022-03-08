using API.DTO;
using DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SERVICES;

namespace API.Controllers
{
    
    [Route("Expenses")]
    [ApiController]
    public class ExpensesController : ControllerBase
    {
        [Authorize]
        [HttpGet("/ListExpenses")]
        public IActionResult List()
        {
            var service = new ExpensesServices();
            var result = new List<ExpenseDTO>();
            string id;
            object value;
            ControllerContext.HttpContext.Items.TryGetValue("Username", out value);

            var username = value.ToString();
            Console.WriteLine(username);
            foreach (var expenses in service.ListAllExpenses())
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

        //[HttpPost]
        [Authorize]
        [HttpPost]
        [Route("AddExpense")]
        public IActionResult AddExpense(AddExpenseDTO addExpenseDTO)
        {
            //try
            //{
            //    DateTime.Parse(date);
            //}
            //catch (Exception)
            //{

            //    return BadRequest("Invalid Date-format");
            //}
            try
            {

                ExpensesServices.Instance.InputExpenses(addExpenseDTO.ExpenseBalanceChange, addExpenseDTO.AccountId, addExpenseDTO.ExpenseDescription, addExpenseDTO.ExpenseDate, addExpenseDTO.ExpenseCategory);

                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest();
            }

        }
        [AllowAnonymous]
        [HttpGet]
        [Route("Categorys")]

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
