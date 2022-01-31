using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;
using DAL.Seeds;

namespace DAL
{
    public class BudgetContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            var connectionString = @"Server=.\SQLExpress; Database = BudgetDB; Integrated Security=True";

            builder.UseSqlServer(connectionString).UseLazyLoadingProxies();
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Income> Incomes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region(Keys)
            modelBuilder.Entity<User>().HasKey(x => x.Id);
            modelBuilder.Entity<Account>().HasKey(x => x.AccountId);
            modelBuilder.Entity<Expense>().HasKey(x => x.ExpenseId);
            modelBuilder.Entity<Income>().HasKey(x => x.IncomeId);
            #endregion

            #region(Propertys)
            modelBuilder.Entity<User>().Property(u => u.UserName).HasMaxLength(25);
            modelBuilder.Entity<User>().HasIndex(u => u.UserName).IsUnique();
            modelBuilder.Entity<User>().Property(p => p.Password).HasMaxLength(50);
            //minst 2 siffror minst 2 stora bokstäver minst 1 special tecken.
            modelBuilder.Entity<User>().Property(e => e.Email).HasMaxLength(255);
            #endregion

            #region(Seeds)
            UserSeeder.Seed(modelBuilder);
            AccountSeed.Seed(modelBuilder);
            ExpenseSeed.Seed(modelBuilder);
            IncomeSeed.Seed(modelBuilder);
            #endregion
        }

    }
}
