using API.DTO;
using DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SERVICES;

namespace API.Controllers
{

    [Route("Expenses")]
    [ApiController]
    public class ExpensesController : ControllerBase
    {
        [HttpGet("/ListExpenses")]
        public IActionResult List()
        {
            var service = new ExpensesServices();
            var result = new List<ExpenseDTO>();
            foreach (var expenses in service.ListAllExpenses())
            {
                result.Add(
                    new ExpenseDTO()
                    {
                        ExpenseId = expenses.ExpenseId,
                        ExpenseDate = expenses.ExpenseDate,
                        ExpenseDescription = expenses.ExpenseDescription,
                        ExpenseBalanceChange = expenses.ExpenseBalanceChange,
                        AccountId = expenses.AccountId,
                    }
                    );
            }
            return Ok(result);
        }

        //[HttpPost]

        [HttpPut]
        [Route("AddExpense")]
        public IActionResult AddExpense(int saldo, int AccountId, string description)
        {
            try
            {
                ExpensesServices.Instance.InputExpenses(saldo, AccountId, description);
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest();
            }

        }

        //[HttpDelete]
    }
}
