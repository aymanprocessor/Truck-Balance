using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Truck_Balance
{
    internal class Trial
    {
        private DateTime startDate;
        private RegistryKey key;

        public Trial()
        {
            key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\TB", true);
        }

        public bool isFirstTime()
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\TB", true);
            if (key != null)
            {
                return bool.Parse(key.GetValue("firstTime").ToString());
            }
            return true;
        }

        public void createTrial(int Days)
        {
            DateTime startTime = DateTime.Now.AddDays(Days);

            if (key == null)
            {
                RegistryKey soft = Registry.CurrentUser.OpenSubKey("SOFTWARE", true);
                key = soft.CreateSubKey("TB", RegistryKeyPermissionCheck.ReadWriteSubTree);
            }

            key.SetValue("startTime", DateTime.Now);
            key.SetValue("firstTime", false);
        }

        public double getDiffTime()
        {
            DateTime startTime = DateTime.Parse(key.GetValue("startTime").ToString());
            DateTime nowTime = DateTime.Now;
            double diff = (nowTime - startTime).TotalDays;
            return diff;
        }
    }
}