﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Income
    {
        public int IncomeId { get; set; }
        public DateTime IncomeDate { get; set; }
        public string IncomeDescription{ get; set; }
        public int IncomeBalanceChange{ get; set; }
        

        //Navigation Properties
        public int AccountId { get; set; }
        public virtual Account Account { get; set; }
        public CategoryIncome CategoryInc { get; set; }
    }
}
