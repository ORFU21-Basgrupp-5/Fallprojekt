using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Models;

namespace SERVICES
{
    public class BudgetService
    {
        private static BudgetService _instance;
        public static BudgetService Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new BudgetService();
                }
                return _instance;
            }
        }
        public string[,] GetBudget(string username)
        {

            using (var context = new BudgetContext())
            {

                
                var currentDate = DateTime.Today;
                var month = currentDate.Month;
                var year = currentDate.Year;

                var budget = context.Budgets.First(b => b.Year ==  year && b.Month == month);

                var usersAccount = context.Users.First(a => a.UserName == username);

                var nrOfCategories = Enum.GetValues(typeof(CategoryExpense)).Length;

                string[,] budgetArray = new string[nrOfCategories+1, 3];

               
                budgetArray[0, 0] = budget.BudgetName;
                
                budgetArray [1,0] =budget.TotalSum.ToString();
                List <string> budgetentries = new List<string>();


                for (var i = 0; i < nrOfCategories; i++)
                {
                    var currentCategoryName = Enum.GetName(typeof(CategoryExpense), i);
                    budgetentries.Add(currentCategoryName);
                    var expenseamont = context.Expenses
                        .Where(e => e.CategoryExp.ToString() == currentCategoryName && e.ExpenseDate.Year == year && e.ExpenseDate.Month == month)
                        .Select(e => e.ExpenseBalanceChange)
                        .Sum();
                    var totalAmount = context.BudgetsEntries.First(be => be.BudgetId == budget.Id);
                
                }
                

                //List<Expense> returnList = new List<Expense>();
                //returnList = context.Expenses.Where(a => a.AccountId == usersAccount.Account.AccountId).ToList();
                //budget namn
                //kategorier
                //expense under perioden
                // summa under perioden

                return budgetArray;
            }
        }
        public string AddBudget(string Name, int TotalSum, int Month,int Year, Dictionary<CategoryExpense, int> BudgetCategories, string username)
        {

            try
            {
                using (var context = new BudgetContext())
                {
                    var user = context.Users.First(a => a.UserName == username);
                    var account = context.Accounts.First(a => a.AccountId == user.Account.AccountId);

                    var budgets = context.Budgets;
                    var budgetentries = new List<BudgetEntries>();
                    foreach (var category in BudgetCategories)
                    {
                        var newBugetEntry = new BudgetEntries()
                        {
                            BudgeeCategory = category.Key,
                            CategoryBudgetAmount = category.Value
                        };
                        context.BudgetsEntries.Add(newBugetEntry);
                        budgetentries.Add(newBugetEntry);
                        context.SaveChanges();
                    }
                    var newBudget = new Budget()
                    {
                        BudgetName = Name,
                        TotalSum = TotalSum,
                        Month = Month + 1,
                        Year = Year,
                        BudgetCategories = budgetentries

                    };
                    account.Budgets.Add(newBudget);
                    budgets.Add(newBudget);
                    context.SaveChanges();
                    return "Added";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
               
           
          
            
            
                
            
        }
    }
}
