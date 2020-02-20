using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Truck_Balance.Forms
{
    public partial class prevWieght : Form
    {
        public delegate void datapass(String val);
        public first_weight _first;
        public prevWieght(first_weight first)
        {
            InitializeComponent();
            _first = first;
        }

        private void prevWieght_Load(object sender, EventArgs e)
        {
            try
            {
                string sql = "SELECT Wieghts.Id as م,Customers.name as الاسم,Wieghts.date as التاريخ FROM Wieghts INNER JOIN Customers ON Wieghts.customerId = Customers.Id; ";
                using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.dbConnectionString))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(sql, conn))
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
            int selected = Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value);
        
            _first.loadDataById(selected);
           
            this.Hide();

        }
    }
}

