using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlServerCe;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Truck_Balance.Forms
{
    public partial class prevWieght : Form
    {
        common com;
       
        public second_weight _second;
        public first_weight _first;
        public prevWieght(first_weight first)
        {
            InitializeComponent();
            _first = first;
        }

        public prevWieght(second_weight second)
        {
            InitializeComponent();
            _second = second;
        }

        public prevWieght()
        {
            InitializeComponent();

        }
        private void prevWieght_Load(object sender, EventArgs e)
        {
            com = new common();
            try
            {
                string sql = string.Format("SELECT Wieghts.Id as م,Wieghts.truckNumber as السيارة, Customers.name as  العميل, Wieghts.firstWieght as [الوزنة الاولى],Wieghts.date as التاريخ FROM Wieghts INNER JOIN Customers ON Wieghts.customerId = Customers.Id Where Wieghts.secondWieght IS NULL",String.Empty);
                using (SqlCeConnection conn = new SqlCeConnection(com.connstr()))
                {
                    using (SqlCeDataAdapter adapter = new SqlCeDataAdapter(sql, conn))
                    {
                        conn.Open();
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dataGridView1.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                int selected = (int)dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value;
                _second.loadDataById(selected);
                _second.Show();
                this.Hide();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

            new Main().Show();
            second_weight second = _second;
            second.Dis();
            second.Hide();
            this.Hide();

        }

        private void prevWieght_FormClosing(object sender, FormClosingEventArgs e)
        {
            new Main().Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.btnOk_Click(null, null);
        }
    }
}

