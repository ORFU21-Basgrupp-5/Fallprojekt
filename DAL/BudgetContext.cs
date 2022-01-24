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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region(Keys)
            modelBuilder.Entity<User>().HasKey(x => x.Id);
            #endregion

            #region(Propertys)
            modelBuilder.Entity<User>().Property(u => u.UserName).HasMaxLength(25);
            modelBuilder.Entity<User>().Property(p => p.Password).HasMaxLength(50);
            //minst 2 siffror minst 2 stora bokstäver minst 1 special tecken.
            modelBuilder.Entity<User>().Property(e => e.Email).HasMaxLength(255);
            #endregion

            #region(Seeds)
            UserSeeder.Seed(modelBuilder);
            #endregion

        }

    }
}
