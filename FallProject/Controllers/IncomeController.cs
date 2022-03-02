using Microsoft.AspNetCore.Authorization;
using DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SERVICES;
using API.DTO;

namespace API.Controllers
{
    [Route("Income")]
    [ApiController]
    public class IncomeController : ControllerBase
    {
        [HttpGet("/ListIncome")]
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
        [HttpPut]
        [Route("AddIncome")]
        public IActionResult AddIncome(int saldo, int AccountId, string description, string date, CategoryIncome category)
        {
            try
            {
                DateTime.Parse(date);
            }
            catch (Exception)
            {

                return BadRequest("Invalid Date-format");
            }
            try
            {
                IncomeServices.Instance.InputIncome(saldo, AccountId, description, date, category);
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
