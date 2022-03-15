using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class BudgetEntries
    {
        public int Id { get; set; }
        public CategoryExpense BudgeeCategory{ get; set; }
        public int CategoryBudgetAmount { get; set; }
    }
}
