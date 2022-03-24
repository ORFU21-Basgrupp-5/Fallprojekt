using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Budget
    {
        public int Id { get; set; }
        public string BudgetName { get; set; }
        public int TotalSum { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        //Navigation Properties
        public virtual List<BudgetEntries> BudgetCategories { get; set; }

    }
}
