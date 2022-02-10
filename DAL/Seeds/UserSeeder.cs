using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace DAL.Seeds
{
    public class UserSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new
                {
                    Id = 1,
                    UserName = "TestKonto1",
                    Password = "rm/sAiqLgg4nwxJ20sht7IuoLJESlJ54I6QksDKmiQk=@jB1fjqC/s+7s+frCkBnQnw==", //Admin2Lösen**
                    Email = "Test@test.se",
                    AccountId = 1
                  
                    
                });
        }
    }
}
