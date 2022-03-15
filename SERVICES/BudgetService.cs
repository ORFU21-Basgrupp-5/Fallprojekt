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
        public bool AddBudget(string Name, int TotalSum, int Month,int Year, Dictionary<CategoryExpense, int> BudgetCategories)
        {
            try
            {
                using (var context = new BudgetContext())
                {
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
                        Month = Month,
                        Year = Year,
                        BudgetCategories = budgetentries
                    };
                    
                    budgets.Add(newBudget);
                    context.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
