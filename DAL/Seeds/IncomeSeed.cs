using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Seeds
{
    public class IncomeSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Income>().HasData(
                new Income
                {
                    IncomeId = 1,
                    IncomeDate = DateTime.Today,
                    IncomeDescription = "Lön",
                    IncomeBalanceChange = 20000,
                    AccountId = 1
                },
                new Income
                {
                    IncomeId = 2,
                    IncomeDate = DateTime.Today,
                    IncomeDescription = "Skatteåterbäring",
                    IncomeBalanceChange = 8,
                    AccountId = 1
                });
        }
    }
}
