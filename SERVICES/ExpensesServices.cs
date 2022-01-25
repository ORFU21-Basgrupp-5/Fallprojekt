using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICES
{
    public class ExpensesServices
    {
        private static ExpensesServices _instance;
        public static ExpensesServices Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ExpensesServices();
                }
                return _instance;
            }
        }
    }
}
