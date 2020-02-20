using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Truck_Balance.Forms
{
    public partial class first_weight : MetroForm
    {
        string customersPath = String.Format("data\\customers.txt", Environment.CurrentDirectory);
        string driversPath = String.Format("data\\drivers.txt", Environment.CurrentDirectory);
        string goodsPath = String.Format("data\\goods.txt", Environment.CurrentDirectory);
        string trucksPath = String.Format("data\\trucks.txt", Environment.CurrentDirectory);
        string citysPath = String.Format("data\\citys.txt", Environment.CurrentDirectory);
        bool isTaken1 = false, isTaken2 = false;
        string id_val;
        public first_weight()
        {
            InitializeComponent();
        }

        private void first_weight_Load(object sender, EventArgs e)
        {
            lblFinalWieght.Text = "الوزن الصافي : 0 كجم";
            lblWeightReading.Text = new Random().Next(500, 1000).ToString();
            loadintocombo(driversPath, cbDriverName);
            loadintocombo(goodsPath, cbGoodType);
            loadintocombo(trucksPath, cbCarType);

            loadIntoComboFromDatabse(cbCustomerName, "select id,name from dbo.Customers");
            string sql = "select IDENT_CURRENT('dbo.Wieghts')";
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.dbConnectionString))
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();
                    label12.Text = (Convert.ToInt16(command.ExecuteScalar()) + 1).ToString();
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Main main = new Main();
            main.Show();
            this.Hide();
        }

        private void btnSecondWeight_Click(object sender, EventArgs e)
        {
            prevWieght prevWieght = new prevWieght(this);
            prevWieght.Show();

        }

        void loadintocombo(String path, ComboBox cb)
        {
            if (File.Exists(path))
            {
                const Int32 BufferSize = 1024;
                using (var fileStream = File.OpenRead(path))
                using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize))
                {
                    String line;
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        cb.Items.Add(line);
                    }

                }
            }
        }

        void loadIntoComboFromDatabse(ComboBox cb, string sql)
        {
            try
            {

                using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.dbConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        conn.Open();
                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {

                            cb.Items.Add(reader["name"].ToString().Trim());
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


        }

        private void first_weight_FormClosing(object sender, FormClosingEventArgs e)
        {
            Main main = new Main();
            main.Show();
        }

        private void btnRecordWeight_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                string sql2 = string.Format("select count(*) from dbo.Wieghts where id={0}", label12.Text);
                int count;
                using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.dbConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(sql2, conn))
                    {
                        conn.Open();

                        count = Convert.ToInt16(cmd.ExecuteScalar());
                    }
                }
                if (count > 0)
                {
                    string sql = string.Format("update dbo.Wieghts SET " +
                "customerId = @customerId," +
                "date = @date," +
                "driverName = @driverName," +
                "truckType=@truckType," +
                "payloadType=@payloadType," +
                "export_import=@export_import," +
                "truckNumber=@truckNumber," +
                "containerNumber=@containerNumber," +
                "firstWieght=@firstWieght," +
                "firstTime=@firstTime," +
                "secondWieght=@secondWieght," +
                "secondTime=@secondTime," +
                "finalWieght=@finalWieght," +
                "note = @note " +
                "WHERE id = {0}", label12.Text);
                    int get_custId;
                    string sql1 = string.Format("select id from dbo.Customers where name=N'{0}'", cbCustomerName.Text);
                    using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.dbConnectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand(sql1, conn))
                        {
                            conn.Open();

                            get_custId = Convert.ToInt16(cmd.ExecuteScalar());
                        }
                    }
                    using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.dbConnectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@customerId", get_custId);
                            cmd.Parameters.AddWithValue("@date", DateTime.Now.ToString("dd/MM/yyyy"));
                            cmd.Parameters.AddWithValue("@driverName", cbDriverName.Text);
                            cmd.Parameters.AddWithValue("@truckType", cbCarType.Text);
                            cmd.Parameters.AddWithValue("@payloadType", cbGoodType.Text);
                            cmd.Parameters.AddWithValue("@export_import", rbExport.Checked ? "صادر" : rbImport.Checked ? "وارد" : "");
                            cmd.Parameters.AddWithValue("@truckNumber", tbCarNumber.Text);
                            cmd.Parameters.AddWithValue("@containerNumber", tbGoodNumber.Text);
                            cmd.Parameters.AddWithValue("@firstWieght", lblCarWeight1.Text);
                            cmd.Parameters.AddWithValue("@firstTime", lblTime1.Text);
                            cmd.Parameters.AddWithValue("@secondWieght", lblCarWeight2.Text);
                            cmd.Parameters.AddWithValue("@secondTime", lblTime2.Text);
                            cmd.Parameters.AddWithValue("@finalWieght", "2222");
                            cmd.Parameters.AddWithValue("@note", tbNote.Text);

                            conn.Open();

                            int res = cmd.ExecuteNonQuery();

                            if (res < 1)
                            {
                                MessageBox.Show("فشل", "فشل", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            }

                        }
                    }
                }
                else
                {
                    string sql = "insert into dbo.Wieghts(" +
                "customerId," +
                "date," +
                "driverName," +
                "truckType," +
                "payloadType," +
                "export_import," +
                "truckNumber," +
                "containerNumber," +
                "firstWieght," +
                 "firstTime," +
                "secondWieght," +
                 "secondTime," +
                "finalWieght," +
                "note) " +
                "VALUES(@customerId," +
                "@date," +
                "@driverName," +
                "@truckType," +
                "@payloadType," +
                "@export_import," +
                "@truckNumber," +
                "@containerNumber," +
                "@firstWieght," +
                "@firstTime," +
                "@secondWieght," +
                "@secondTime," +
                "@finalWieght," +
                "@note" +
                ")";
                    int get_custId;
                    string sql1 = string.Format("select id from dbo.Customers where name=N'{0}'", cbCustomerName.Text);
                    using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.dbConnectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand(sql1, conn))
                        {
                            conn.Open();

                            get_custId = Convert.ToInt16(cmd.ExecuteScalar());
                        }
                    }
                    using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.dbConnectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@customerId", get_custId);
                            cmd.Parameters.AddWithValue("@date", DateTime.Now.ToString("dd/MM/yyyy"));
                            cmd.Parameters.AddWithValue("@driverName", cbDriverName.Text);
                            cmd.Parameters.AddWithValue("@truckType", cbCarType.Text);
                            cmd.Parameters.AddWithValue("@payloadType", cbGoodType.Text);
                            cmd.Parameters.AddWithValue("@export_import", rbExport.Checked ? "صادر" : rbImport.Checked ? "وارد" : "");
                            cmd.Parameters.AddWithValue("@truckNumber", tbCarNumber.Text);
                            cmd.Parameters.AddWithValue("@containerNumber", tbGoodNumber.Text);
                            cmd.Parameters.AddWithValue("@firstWieght", lblCarWeight1.Text);
                            cmd.Parameters.AddWithValue("@firstTime", lblTime1.Text);
                            cmd.Parameters.AddWithValue("@secondWieght", lblCarWeight2.Text);
                            cmd.Parameters.AddWithValue("@secondTime", lblTime2.Text);
                            cmd.Parameters.AddWithValue("@finalWieght", "555");
                            cmd.Parameters.AddWithValue("@note", tbNote.Text);

                            conn.Open();

                            int res = cmd.ExecuteNonQuery();

                            if (res < 1)
                            {
                                MessageBox.Show("فشل", "فشل", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            }

                        }
                    }
                }

                // MessageBox.Show(finalWieght(lblCarWeight1.Text, lblCarWeight2.Text));

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnRecordWeight1_Click(object sender, EventArgs e)
        {
            if (!isTaken1)
            {
                record1();
                isTaken1 = true;
            }
            else
            {
                DialogResult res = MessageBox.Show("هل تريد اعادة تسجيل الوزنة الاولى", "تأكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    record1();
                }
            }


        }

        private void btnRecordWeight2_Click(object sender, EventArgs e)
        {
            if (!isTaken2)
            {
                record2();
                isTaken2 = true;
            }
            else
            {
                DialogResult res = MessageBox.Show("هل تريد اعادة تسجيل الوزنة التانية", "تأكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    record2();
                }

            }

        }

        void record1()
        {
            lblCarWeight1.Text = lblWeightReading.Text;

            lblTime1.Text = DateTime.Now.ToString("dd/MM/yyyy hh:mm tt");

           
        }

        void record2()
        {
            if (rbImport.Checked)
            {
                lblCarWeight2.Text = (Convert.ToInt32(lblWeightReading.Text) - 100).ToString();
            }
            else if (rbExport.Checked)
            {
                lblCarWeight2.Text = (Convert.ToInt32(lblWeightReading.Text) + 100).ToString();
            }

            lblTime2.Text = DateTime.Now.ToString("dd/MM/yyyy hh:mm tt");

        }

        string finalWieght(string w1, string w2)
        {
            int ww1 = Convert.ToInt32(w1);
            int ww2 = Convert.ToInt32(w2);
            string final = "";
            if (rbExport.Checked)
            {
                final = (ww2 - ww1).ToString();
            }
            else if (rbImport.Checked)
            {
                final = (ww1 - ww2).ToString();
            }
            return final;
        }
        public void funData(String val)
        {
            id_val = val;
            loadDataById(Convert.ToInt32(val));
        }

        private void btnNewWeight_Click(object sender, EventArgs e)
        {
            loadDataById(2);
        }

        public void loadDataById(int id)
        {
            string sql = string.Format("select * from Wieghts INNER JOIN Customers ON Wieghts.customerId = Customers.Id where Wieghts.id = {0}; ",id);
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.dbConnectionString))
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        label12.Text = reader["Id"].ToString().Trim();
                        cbCustomerName.Text = reader["name"].ToString().Trim();
                        cbDriverName.Text = reader["driverName"].ToString().Trim();
                        cbCarType.Text = reader["truckType"].ToString().Trim();
                        cbGoodType.Text = reader["payloadType"].ToString().Trim();
                        tbNote.Text = reader["note"].ToString().Trim();
                        tbCarNumber.Text = reader["truckNumber"].ToString().Trim();
                        tbGoodNumber.Text = reader["containerNumber"].ToString().Trim();
                        if (reader["export_import"].ToString().Trim().Equals("صادر"))
                        {
                            rbExport.Checked = true;
                            rbImport.Checked = false;
                        }
                        else if (reader["export_import"].ToString().Trim().Equals("وارد"))
                        {
                            rbImport.Checked = true;
                            rbExport.Checked = false;
                        }
                        lblCarWeight1.Text = reader["firstWieght"].ToString().Trim();
                        lblDate1.Text = ((DateTime)reader["firstTime"]).ToString("dd/MM/yyyy").Trim();
                        lblTime1.Text = ((DateTime)reader["firstTime"]).ToString("hh:mm tt").Trim();
                        lblCarWeight2.Text = reader["secondWieght"].ToString().Trim();
                        lblDate2.Text = ((DateTime)reader["secondTime"]).ToString("dd/MM/yyyy").Trim();
                        lblTime2.Text = ((DateTime)reader["secondTime"]).ToString("hh:mm tt").Trim();

                    }
                }
            }
        }
    }
}
