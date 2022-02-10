using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Expense
    {
        
        public int ExpenseId { get; set; }
        public DateTime ExpenseDate { get; set; }
        public string ExpenseDescription { get; set; }
        public int ExpenseBalanceChange { get; set; }

        //Navigation Properties
        public int AccountId { get; set; }
        public virtual Account Account { get; set; }
        [ForeignKey("User")]
        public virtual int Id { get; set; }

        public virtual User User { get; set; }
    }
}
