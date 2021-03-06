﻿using System;
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
    public partial class Login : Form
    {
        private common com;

        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            com = new common();
            Trial trial = new Trial();
            if (trial.isFirstTime())
            {
                trial.createTrial(10);
            }

            if (trial.getDiffTime() > 10)
            {
                MessageBox.Show("تم انتهاء مدة تجربة البرنامج", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                Application.ExitThread();
            }
            if (trial.getDiffTime() < 8)
            {
                MessageBox.Show("سوف ينتهي تجربة البرنامج بعد " + (10 - Math.Floor(trial.getDiffTime())) + " ايام", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            if (trial.getDiffTime() >= 8)
            {
                MessageBox.Show("سوف ينتهي تجربة البرنامج بعد " + (10 - Math.Floor(trial.getDiffTime())) + " يوم", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            loadIntoComboFromDatabse(cbUser, "select username from users", "username");
        }

        private void label2_Click(object sender, EventArgs e)

        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void loadIntoComboFromDatabse(ComboBox cb, string sql, string col)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(com.connstr()))
                {
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        conn.Open();
                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            cb.Items.Add(reader[col].ToString().Trim());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbUser.Text.Trim().Equals("admin") && txtPass.Text.Trim().Equals(Properties.Settings.Default.adminPass))
                {
                    Properties.Settings.Default.username = cbUser.Text.Trim();
                    Properties.Settings.Default.Save();

                    Main main = new Main();
                    main.Show();
                    this.Hide();
                    return;
                }
                string sql = string.Format("select password from users where username =  N'{0}'", cbUser.Text.Trim());
                using (SqlConnection conn = new SqlConnection(com.connstr()))
                {
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        conn.Open();
                        var pass = cmd.ExecuteScalar();

                        if (txtPass.Text.Trim().Equals(pass.ToString().Trim()))
                        {
                            Properties.Settings.Default.username = cbUser.Text.Trim();
                            Properties.Settings.Default.Save();

                            Main main = new Main();
                            main.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("كلمة السر خطأ", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.ExitThread();
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.ExitThread();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }
    }
}