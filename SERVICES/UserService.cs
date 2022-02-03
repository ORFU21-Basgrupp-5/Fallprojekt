using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICES
{
    public class UserService
    {
        private static UserService _instance;
        public static UserService Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new UserService();
                }
                return _instance;
            }
        }
        private UserService() { }

        public bool Login(string userName, string passWord)
        {
            using(var context = new BudgetContext())
            {
                var users = context.Users;
                foreach(var user in users)
                {
                    if(user.UserName == userName && user.Password == passWord)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public bool RegisterNewAccount(string userName,string password,string mail)
        {
            try
            {
                using (var context = new BudgetContext())
                {
                    var user = context.Users;
                    var newUser = new User() { UserName = userName, Password = password, Email = mail };
                    user.Add(newUser);
                    context.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }
               
      

           
        }


    }
}
