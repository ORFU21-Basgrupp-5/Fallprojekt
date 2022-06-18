using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SERVICES
{
    public class ExpenseServices
    {
        private static ExpenseServices _instance;
        public static ExpenseServices Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ExpenseServices();
                }
                return _instance;
            }
        }


        public void InputExpenses(int saldo, string description,DateTime date, CategoryExpense category, string username)

        {
            using (var context = new BudgetContext())
            {
                var expense = context.Expenses;
                var user = context.Users.First(a => a.UserName == username);
                var newExpense = new Expense()
                {
                    ExpenseDate = date,
                    ExpenseDescription = description,
                    AccountId = user.Account.AccountId,
                    ExpenseBalanceChange = saldo,
                    CategoryExp = category
                };
                expense.Add(newExpense);


                var changed = context.Accounts.First(a => a.AccountId == user.Account.AccountId);
                changed.Balance = changed.Balance - saldo;

                context.SaveChanges();
            }
            return;
        }

        public List<Expense> ListAllExpenses(string user)
        {
            using (var context = new BudgetContext())
            {
                var usersAccount = context.Users.First(a => a.UserName == user);
                List<Expense> returnList = new List<Expense>(); 
                returnList = context.Expenses.Where(a => a.AccountId == usersAccount.Account.AccountId).ToList();


                return returnList;
            }
        }
    }
}