using System;
using System.Drawing;
using System.Windows.Forms;
using Truck_Balance.Forms;

namespace Truck_Balance
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
        }

        private void metroTile3_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            Hide();
        }

        private void metroTile12_Click(object sender, EventArgs e)
        {
            second_weight second_Weight = new second_weight();
            prevWieght prevwieght = new prevWieght(second_Weight);
            prevwieght.Show();
            second_Weight.Show();
            this.Hide();
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
        }

        private void metroTile9_Click(object sender, EventArgs e)
        {
            Review r = new Review();
            r.Show();
            Hide();
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

        private void Main_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.username == "admin")
            {
                metroTile1.Enabled = true;
                metroTile2.Enabled = true;
            }
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.ExitThread();
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            lblDate.Text = DateTime.Now.ToString("dd-MM-yyyy  \t  hh:mm:ss tt");
        }

        private void metroTile11_Click_1(object sender, EventArgs e)
        {
            passwordChanger changer = new passwordChanger();
            changer.Show();
        }

        private void metroTile10_Click(object sender, EventArgs e)
        {
            prompt_reportByDatecs prompt = new prompt_reportByDatecs();
            prompt.Show();
            Hide();
        }

        private void metroTile11_Click(object sender, EventArgs e)
        {
            first_weight first_weight = new first_weight();
            first_weight.Show();
            // first_weight.TopMost = true;
            this.Hide();
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.Honeydew;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = Color.Honeydew;
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackColor = Color.LightGreen;
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            button2.BackColor = Color.LightGreen;
        }
    }
}