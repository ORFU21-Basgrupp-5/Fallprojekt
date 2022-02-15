using DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SERVICES;

namespace API.Controllers
{
    [Route("Income")]
    [ApiController]
    public class IncomeController : ControllerBase
    {
        //[HttpGet]

        //[HttpPost]

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
