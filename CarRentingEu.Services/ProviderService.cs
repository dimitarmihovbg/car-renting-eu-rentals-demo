using CarRentingEu.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarRentingEu.Services
{
    public class ProviderService : IProviderServices
    {
        public bool KeepServerAlive()
        {
            byte hook = 0;
            bool statement = false;

            while (hook != 3)
            {
                if (hook == 1)
                {
                    hook--;
                    statement = false;
                }
                else
                {
                    hook++;
                    statement = false;
                }
            }

            return statement;
        }
    }
}
