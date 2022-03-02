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
        //[HttpGet]

        //[HttpPost]
        [Authorize]
        [HttpPost]
        [Route("AddIncome")]
        public IActionResult AddIncome(AddIncomeDTO addIncomeDTO)
        {
            
            try
            {
                IncomeServices.Instance.InputIncome(addIncomeDTO.IncomeBalanceChange, addIncomeDTO.AccountId, addIncomeDTO.IncomeDescription, addIncomeDTO.IncomeDate, addIncomeDTO.IncomeCategory);
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
