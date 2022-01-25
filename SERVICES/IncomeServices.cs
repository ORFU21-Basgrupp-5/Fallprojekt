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
    }
}
