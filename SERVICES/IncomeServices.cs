﻿using DAL;
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

        public void InputIncome(int saldo,string description,DateTime date, CategoryIncome category, string username)
        {


            using (var context = new BudgetContext())
            {
                var income = context.Incomes;
                var user = context.Users.First(a => a.UserName == username);
                
                var newIncome = new Income()
                {
                    IncomeDate = date,
                    IncomeDescription = description,
                    AccountId = user.Account.AccountId,
                    IncomeBalanceChange = saldo,
                    CategoryInc = category
                    
                };
                income.Add(newIncome);

                var changed = context.Accounts.First(a => a.AccountId == user.Account.AccountId);
                changed.Balance = changed.Balance + saldo;

                context.SaveChanges();
            }

            return;
        }
        public List<Income> ListAllIncomes(string user)
        {
            using (var context = new BudgetContext())
            {
                var usersAccount = context.Users.First(a => a.UserName == user);
                List<Income> returnList = new List<Income>();
                returnList = context.Incomes.Where(a => a.AccountId == usersAccount.Account.AccountId).ToList();


                return returnList;
            }
        }
    }

}
