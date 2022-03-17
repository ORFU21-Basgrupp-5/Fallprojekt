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
