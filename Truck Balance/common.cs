using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Truck_Balance
{
    internal class common
    {
        public string connstr()
        {
            return Properties.Settings.Default.dbConnectionString;
        }
    }
}