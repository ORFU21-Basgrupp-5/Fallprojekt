using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Seeds
{
    public class ExpenseSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Expense>().HasData(
                new Expense
                {
                    ExpenseId = 1,
                    ExpenseDate = DateTime.Now,
                    ExpenseDescription = "Laga bil",
                    ExpenseBalanceChange = 2200,
                    AccountId = 1
                },
                new Expense
                {
                    ExpenseId = 2,
                    ExpenseDate = DateTime.Now,
                    ExpenseDescription = "Kläder",
                    ExpenseBalanceChange = 500,
                    AccountId = 1
                },
                new Expense
                {
                    ExpenseId = 3,
                    ExpenseDate = DateTime.Now,
                    ExpenseDescription = "Mat",
                    ExpenseBalanceChange = 300,
                    AccountId = 1
                },
                new Expense
                {
                    ExpenseId = 4,
                    ExpenseDate = DateTime.Now,
                    ExpenseDescription = "Spel",
                    ExpenseBalanceChange = 400,
                    AccountId = 1
                }
                );
        }
    }
}
