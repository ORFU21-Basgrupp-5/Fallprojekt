using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICES
{
    public class IncomeServices
    {
        private static IncomeServices _instance;
        public static IncomeServices Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new IncomeServices();
                }
                return _instance;
            }
        }

        public void InputIncome(int saldo, int accountId, string description,string date)
        {


            using (var context = new BudgetContext())
            {
                var income = context.Incomes;
                var newIncome = new Income()
                {
                    IncomeDate = DateTime.Parse(date),
                    IncomeDescription = description,
                    AccountId = accountId,
                    IncomeBalanceChange = saldo
                };
                income.Add(newIncome);


                var changed = context.Accounts.First(a => a.AccountId == accountId);
                changed.Balance = changed.Balance + saldo;

                context.SaveChanges();
            }

            return;
        }

    }

}
