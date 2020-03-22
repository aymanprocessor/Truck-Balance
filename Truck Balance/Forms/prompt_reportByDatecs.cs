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
    public partial class prompt_reportByDatecs : Form
    {
        public prompt_reportByDatecs()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Main main = new Main();
            main.Show();
            Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!radioButton1.Checked && !radioButton2.Checked)
            {
                MessageBox.Show("من فضلك اختر نوع الحمولة", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Report report = new Report(dateTimePicker1, dateTimePicker2, radioButton1.Checked ? "الصادرة" : radioButton2.Checked ? "الواردة" : "");
            report.Show();
            //Review review = new Review(dateTimePicker1, dateTimePicker2, radioButton1.Checked ? "قطاعات الومنيوم" : radioButton2.Checked ? "اخرى" : "");
            //review.Show();
            Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
        }
    }
}