using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICES
{
    public class AccountService
    {
        private static AccountService _instance;
        public static AccountService Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new AccountService();
                }
                return _instance;
            }
        }
    }
}
