﻿using Microsoft.AspNetCore.Http;
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
        public void AddIncome(int saldo, int AccountId, string description)
        {
            IncomeServices.Instance.InputIncome(saldo, AccountId, description);
            return;
        }

        //[HttpDelete]

    }
}