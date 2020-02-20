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
    public partial class Users : Form
    {
        public Users()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtConfirm.Text == "" || txtPass.Text == "" || txtUser.Text == "")
            {
                MessageBox.Show("من فضلك ادخل اسم المستخدم او كلمة السر", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtPass.Text != txtConfirm.Text)
            {
                MessageBox.Show("كلمة السر غير متطابقة", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                string sql = "insert into Users(username , password)VALUES(@username,@password)";
                using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.dbConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        conn.Open();
                        cmd.Parameters.AddWithValue("@username", txtUser.Text);
                        cmd.Parameters.AddWithValue("@password", txtConfirm.Text);

                        cmd.ExecuteNonQuery();
                        loadUsers();
                        clear();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void loadUsers()
        {
            try
            {
                string sql = "select id as م , username as 'اسم المستخدم' ,password as 'كلمة السر' from users";
                
                using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.dbConnectionString))
                {
                    conn.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(sql, conn))
                    {
                      
                        DataSet dt = new DataSet();
                        adapter.Fill(dt);
                        dataGridView1.DataSource = dt.Tables[0];
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void Users_Load(object sender, EventArgs e)
        {
            loadUsers();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("من فضلك اختر اسم المستخدم المراد مسحه", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                string sql = string.Format("delete from users where id = {0}",Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value));
                using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.dbConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {

                        conn.Open();
                        cmd.ExecuteNonQuery();
                        loadUsers();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DialogResult result = MessageBox.Show("هل تريد مسح اسم المستخدم الجديد","تأكيد",MessageBoxButtons.YesNo);
            if(result == DialogResult.Yes)
            {
                clear();
                var selected = dataGridView1.Rows[dataGridView1.CurrentRow.Index];

                txtUser.Text = selected.Cells[1].Value.ToString().Trim();
            }
            else
            {
                return;
            }

        }

        private void clear()
        {
            txtUser.Clear();
            txtPass.Clear();
            txtConfirm.Clear();
        }
    }
}
