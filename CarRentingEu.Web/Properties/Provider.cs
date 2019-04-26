using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRentingEu.Web.Properties
{
    public static class Provider
    {
        public static async Task<bool> KeepServerAlive()
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
