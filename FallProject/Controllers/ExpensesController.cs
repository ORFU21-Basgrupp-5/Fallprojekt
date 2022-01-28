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
        public List<ExpenseDTO> List()
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
            return result;
        }

        //[HttpPost]

        [HttpPut]
        public void AddExpense(int saldo, int AccountId, string description)
        {
            ExpensesServices.Instance.InputExpenses(saldo, AccountId, description);
            return;
        }

        //[HttpDelete]
    }
}
