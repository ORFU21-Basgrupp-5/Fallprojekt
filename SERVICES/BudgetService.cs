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

                var usersAccount = context.Users.First(a => a.UserName == username);

                var budget = usersAccount.Account.Budgets.First(b => b.Year ==  year && b.Month == month);

                

                var nrOfCategories = Enum.GetValues(typeof(CategoryExpense)).Length;

                string[,] budgetArray = new string [5,nrOfCategories + 1];

               
                budgetArray[0,0] = budget.BudgetName;
                
                budgetArray[1,0] =budget.TotalSum.ToString();
                var allexpenses = context.Expenses.ToList();
                int budgetTotalUse = 0;

                for (var i = 0; i < nrOfCategories; i++)
                {
                    var currentCategoryName = Enum.GetName(typeof(CategoryExpense), i);
                    budgetArray [0,i+1] = currentCategoryName;
                    var expenseamont = allexpenses
                        .Where(e => Convert.ToInt32(e.CategoryExp) == i && e.ExpenseDate.Year == year && e.ExpenseDate.Month == month)
                        .Select(e => e.ExpenseBalanceChange)
                        .Sum();
                    var totalBudgetAmount = budget.BudgetCategories.First(b => b.BudgeeCategory.ToString() == currentCategoryName).CategoryBudgetAmount;
                   
                        budgetArray[1, i + 1] = totalBudgetAmount.ToString();
                        budgetArray[2, i + 1] = expenseamont.ToString();
                        budgetArray[3, i + 1] = (totalBudgetAmount - expenseamont).ToString();
                    if (totalBudgetAmount != 0)
                    {
                        budgetArray[4, i + 1] = (expenseamont * 100 / totalBudgetAmount).ToString() + "%";
                    }
                    else
                    {
                        budgetArray[4, i + 1] = "0";
                    }
                    budgetTotalUse += expenseamont;
                    
                    
                }
                budgetArray[2,0] = budgetTotalUse.ToString();

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
