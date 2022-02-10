using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Account
    {
        public int AccountId { get; set; }
        public string Name { get; set; }
        public int Balance { get; set; }

        //Navigation Properties
        public virtual List<Income> Incomes  { get; set; }
        public virtual List<Expense> Expenses  { get; set; }
        
    }
}
