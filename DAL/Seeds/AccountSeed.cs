using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Seeds
{
    public class AccountSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .HasData(
                new
                {
                    AccountId = 1,
                    Name = "Lönekonto",
                    Balance = 0,
                }
                );
        }
    }
}
