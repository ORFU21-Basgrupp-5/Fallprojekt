using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SERVICES;

namespace API.Controllers
{
    [Route("Expenses")]
    [ApiController]
    public class ExpensesController : ControllerBase
    {
        //[HttpGet]

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
