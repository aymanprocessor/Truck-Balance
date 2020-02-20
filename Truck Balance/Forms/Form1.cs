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
using Truck_Balance.Forms;

namespace Truck_Balance
{
    public partial class Main : MetroForm
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
    
        }

        private void metroTile3_Click(object sender, EventArgs e)
        {
            Application.Exit();

            
        }

        private void metroTile11_Click(object sender, EventArgs e)
        {
            first_weight first_Weight = new first_weight();
            first_Weight.Show();
            this.Hide();
        }

        private void metroTile12_Click(object sender, EventArgs e)
        {
           //prevWieght second_Weight = new prevWieght(this);
           // second_Weight.Show();

        }

        private void metroTile5_Click(object sender, EventArgs e)
        {
            drivers d = new drivers();
            d.Show();
           
        }

        private void metroTile8_Click(object sender, EventArgs e)
        {
            citys c = new citys();
            c.Show();
        }

        private void metroTile6_Click(object sender, EventArgs e)
        {
            goods g = new goods();
            g.Show();
        }

        private void metroTile7_Click(object sender, EventArgs e)
        {
            trucks t = new trucks();
            t.Show();
        }

        private void metroTile4_Click(object sender, EventArgs e)
        {
            customers c = new customers();
            c.Show();
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void metroTile9_Click(object sender, EventArgs e)
        {
            Review r = new Review();
            r.Show();
        }

        private void metroTile2_Click(object sender, EventArgs e)
        {
            Setting setting = new Setting();
            setting.Show();
            
        }

        private void metroTile1_Click(object sender, EventArgs e)
        {
            Users users = new Users();
            users.Show();
        }
    }
}
