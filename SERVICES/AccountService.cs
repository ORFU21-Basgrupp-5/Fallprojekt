using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Models;

namespace SERVICES
{
    public class AccountService
    {
        private static AccountService _instance;
        public static AccountService Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new AccountService();
                }
                return _instance;
            }
        }
        public List<Account> GetAccounts(string username)
        {

            using var context = new BudgetContext();

            var user = context.Users.First(a => a.UserName == username);

            List<Account> returnList = new List<Account>();
            returnList = context.Accounts.Where(a => a.AccountId == user.Account.AccountId).ToList();

            return returnList;
        }
    }
}
