using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Truck_Balance
{
    class common
    {

        public string connstr()
        {
          
            return string.Format("Data Source={0}",Properties.Settings.Default.dbpath);
        } 
    }
}
