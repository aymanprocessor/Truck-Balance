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
    public partial class passwordChanger : Form
    {
        private common com;

        public passwordChanger()
        {
            InitializeComponent();
        }

        private void passwordChanger_Load(object sender, EventArgs e)
        {
            com = new common();
            txtOldPassword.Focus();
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            try
            {
                string username = Properties.Settings.Default.username;
                string sql = $"select password from Users where username = '{username}'";
                using (SqlConnection conn = new SqlConnection(com.connstr()))
                {
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        conn.Open();
                        var res = cmd.ExecuteScalar();

                        if (txtOldPassword.Text == res.ToString().Trim())
                        {
                            try
                            {
                                if (txtNewPassword.Text != txtConfirmPassword.Text)
                                {
                                    MessageBox.Show("كلمة المرور غير متطابقة", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                                string sql1 = $"update Users Set password = '{txtNewPassword.Text}' where username = '{username}'";
                                using (SqlConnection conn1 = new SqlConnection(com.connstr()))
                                {
                                    using (SqlCommand cmd1 = new SqlCommand(sql1, conn1))
                                    {
                                        conn1.Open();
                                        int result = cmd1.ExecuteNonQuery();
                                        if (result > 0)
                                        {
                                            MessageBox.Show("تم التغيير بنجاح", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.None);
                                            Clear();
                                        }
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void Clear()
        {
            txtOldPassword.Clear();
            txtNewPassword.Clear();
            txtConfirmPassword.Clear();
        }
    }
}