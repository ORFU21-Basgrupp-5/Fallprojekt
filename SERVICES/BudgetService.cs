using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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


            return true;
        }
    }
}
