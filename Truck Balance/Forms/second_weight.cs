using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Truck_Balance.Forms
{
    public partial class second_weight : MetroForm
    {
        public second_weight()
        {
            InitializeComponent();
        }

        private void second_weight_Load(object sender, EventArgs e)
        {

        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            Main main = new Main();
            main.Show();
            this.Hide();
        }

        private void btnSecondWeight_Click(object sender, EventArgs e)
        {
            first_weight first_Weight = new first_weight();
            first_Weight.Show();
            this.Hide();
        }

        private void second_weight_FormClosing(object sender, FormClosingEventArgs e)
        {
            Main main = new Main();
            main.Show();
        }
    }
}
