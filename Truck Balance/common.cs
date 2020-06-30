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
            return $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={Properties.Settings.Default.dbpath};Integrated Security=True;Connect Timeout=30";

            //return Properties.Settings.Default.dbConnectionString;
        }
    }
}