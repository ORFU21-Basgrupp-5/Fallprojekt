using DAL;
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
    }
}
