using Microsoft.AspNetCore.Authorization;
using DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SERVICES;
using API.DTO;
using System.Linq;

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
        [AllowAnonymous]
        [HttpGet]
        [Route("Categorys")]

        public IActionResult GetCategorys()
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
