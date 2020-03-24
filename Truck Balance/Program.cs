using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Truck_Balance.Forms;

namespace Truck_Balance
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (Properties.Settings.Default.firstTime)
            {
                Application.Run(new Initial());
            }
            else
            {
                Application.Run(new Login());
            }
        }
    }
}