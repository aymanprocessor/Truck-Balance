﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using System.Data.SqlClient;

namespace Truck_Balance.Forms
{
    public partial class customers : Form
    {
        //string fileName = String.Format("data\\customers.txt", Environment.CurrentDirectory);
        public customers()
        {
            InitializeComponent();
        }

        private void drivers_Load(object sender, EventArgs e)
        {





        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (validate())
            {
                string sql = "insert into dbo.Customers(name,address,government) VALUES(@name,@address,@government)";
                using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.dbConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", tbName.Text);
                        cmd.Parameters.AddWithValue("@address", tbAddress.Text);
                        cmd.Parameters.AddWithValue("@government", cbGovernment.Text);
                        conn.Open();
                        int result = cmd.ExecuteNonQuery();

                        if (result > 0)
                        {

                            load();
                        }
                        else
                        {
                            MessageBox.Show("خطأ");
                        }

                    }
                }
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            int selectedRow = Convert.ToInt16(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value);
            string sql = string.Format("delete from dbo.Customers where id={0}",selectedRow);
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.dbConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    try
                    {
                        conn.Open();
                        int result = cmd.ExecuteNonQuery();

                        if (result > 0)
                        {

                            load();
                        }
                        else
                        {
                            MessageBox.Show("خطأ");
                        }
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                   

                }
            }

        }

        private void customers_Load(object sender, EventArgs e)
        {
            string[] government = {
                    "الإسماعيلية",
                    "أسوان",
                    "أسيوط",
                    "الأقصر",
                    "البحر الأحمر",
                    "البحيرة",
                    "بني سويف",
                    "بورسعيد",
                    "جنوب سيناء",
                    "الجيزة",
                    "الدقهلية",
                    "دمياط",
                    "سوهاج",
                    "السويس",
                    "الشرقية",
                    "شمال سيناء",
                    "الغربية",
                    "الفيوم",
                    "القاهرة",
                    "القليوبية",
                    "قنا",
                    "كفر الشيخ",
                    "مطروح",
                    "المنوفية",
                    "المنيا",
                    "الوادي الجديد"
            };
            foreach (string i in government)
            {
                cbGovernment.Items.Add(i);

            }
            load();
        }

        void load()
        {

            string sql = "select id as م ,name as الاسم , address as العنوان , government as المحافظة from dbo.Customers";
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

        bool validate()
        {

            if (tbName.Text == "")
            {
                MessageBox.Show("من فضلك اكتب الاسم", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (cbGovernment.Text == "")
            {
                MessageBox.Show("من فضلك اختار المحافظة", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
    }
}
