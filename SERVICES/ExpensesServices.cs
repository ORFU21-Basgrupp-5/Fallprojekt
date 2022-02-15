using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SERVICES
{
    public class ExpensesServices
    {
        private static ExpensesServices _instance;
        public static ExpensesServices Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ExpensesServices();
                }
                return _instance;
            }
        }

        public void InputExpenses(int saldo, int accountId, string description, string date, CategoryExpense category)
        {
            using (var context = new BudgetContext())
            {
                var expense = context.Expenses;
                var newExpense = new Expense()
                {
                    ExpenseDate = DateTime.Parse(date),
                    ExpenseDescription = description,
                    AccountId = accountId,
                    ExpenseBalanceChange = saldo,
                    CategoryExp = category
                };
                expense.Add(newExpense);


                var changed = context.Accounts.First(a => a.AccountId == accountId);
                changed.Balance = changed.Balance - saldo;

                context.SaveChanges();
            }
            return;
        }

        public List<Expense> ListAllExpenses()
        {
            using (var context = new BudgetContext())
            {
                return context.Expenses.ToList()
                    ;
            }
        }
    }
}