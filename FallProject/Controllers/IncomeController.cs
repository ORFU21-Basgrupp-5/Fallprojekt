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
        public IActionResult AddIncome(int saldo, int AccountId, string description)
        {
            try
            {
                IncomeServices.Instance.InputIncome(saldo, AccountId, description);
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest();
            }

        }S

        //[HttpDelete]

    }
}
