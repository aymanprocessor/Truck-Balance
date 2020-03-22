using MetroFramework.Forms;

using Microsoft.Reporting.WinForms;
using NumberToWord;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlServerCe;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Truck_Balance.Forms
{
    public partial class second_weight : MetroForm
    {
        private common com;
        private SerialPortReader sp;
        private string driversPath = String.Format("{0}\\data\\drivers.txt", Environment.CurrentDirectory);
        private string goodsPath = String.Format("{0}\\data\\goods.txt", Environment.CurrentDirectory);
        private string trucksPath = String.Format("{0}\\data\\trucks.txt", Environment.CurrentDirectory);
        private string productPath = String.Format("{0}\\data\\product.txt", Environment.CurrentDirectory);

        public second_weight()
        {
            InitializeComponent();
        }

        private void second_weight_Load(object sender, EventArgs e)
        {
            btnPreview.Enabled = false;
            btnPrint.Enabled = false;
            if (Properties.Settings.Default.username == "admin")
            {
                lblWeightReading.ReadOnly = false;
            }
            else
            {
                lblWeightReading.ReadOnly = true;
            }
            com = new common();
            sp = new SerialPortReader(this, lblWeightReading);
            sp.Connect();

            //lblWeightReading.Text = new Random().Next(500, 1000).ToString();
            loadintocombo(driversPath, cbDriverName);
            loadintocombo(goodsPath, cbGoodType);
            loadintocombo(trucksPath, cbCarType);
            loadintocombo(productPath, cbProduct);

            loadIntoComboFromDatabse(cbCustomerName, "select id,name from Customers");
            string sql = "select max(id) from Wieghts";
            using (SqlCeConnection connection = new SqlCeConnection(com.connstr()))
            {
                using (SqlCeCommand command = new SqlCeCommand(sql, connection))
                {
                    connection.Open();
                    var result = command.ExecuteScalar();
                    if (result.Equals(DBNull.Value))
                    {
                        lblCode.Text = "1";
                    }
                    else
                    {
                        lblCode.Text = (Convert.ToInt16(command.ExecuteScalar())).ToString();
                    }
                }
            }
        }

        private void loadIntoComboFromDatabse(ComboBox cb, string sql)
        {
            try
            {
                using (SqlCeConnection conn = new SqlCeConnection(com.connstr()))
                {
                    using (SqlCeCommand cmd = new SqlCeCommand(sql, conn))
                    {
                        conn.Open();
                        SqlCeDataReader reader = cmd.ExecuteReader();

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

        private void loadintocombo(String path, ComboBox cb)
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

        private void btnHome_Click(object sender, EventArgs e)
        {
            {
                // DialogResult res = MessageBox.Show("هل تريد ان تخرج؟", "تأكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                //if (res == DialogResult.Yes)
                // {
                sp.Disconnect();
                Main main = new Main();
                main.Show();
                this.Hide();
                // }
            }
        }

        private void btnSecondWeight_Click(object sender, EventArgs e)
        {
            first_weight first_Weight = new first_weight();
            first_Weight.Show();
            this.Hide();
        }

        private void second_weight_FormClosing(object sender, FormClosingEventArgs e)
        {
            //DialogResult res = MessageBox.Show("هل تريد ان تخرج؟", "تأكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //if (res == DialogResult.Yes)
            //{
            sp.Disconnect();
            Main main = new Main();
            main.Show();
            //}
        }

        private void btnRecordWeight_Click(object sender, EventArgs e)
        {
            record2();
            finalWieght();
        }

        private void record2()
        {
            if (Convert.ToInt32(lblWeightReading.Text) > 0)
            {
                lblCarWeight.Text = lblWeightReading.Text.TrimStart(new char[] { '0' });
            }
            else
            {
                MessageBox.Show("من فضلك تأكد من قراءة الميزان", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            lblTime.Text = DateTime.Now.ToString("hh:mm tt");
            lblDate.Text = DateTime.Now.ToString("dd/MM/yyyy");

            btnSave.Enabled = true;
        }

        private void Save()
        {
            try
            {
                string sql2 = string.Format("select count(*) from Wieghts where id={0}", Convert.ToInt16(lblCode.Text));
                int count;
                using (SqlCeConnection conn = new SqlCeConnection(com.connstr()))
                {
                    using (SqlCeCommand cmd = new SqlCeCommand(sql2, conn))
                    {
                        conn.Open();

                        count = Convert.ToInt16(cmd.ExecuteScalar());
                    }
                }
                //if (count > 0)
                //{
                string sql = string.Format("update Wieghts SET " +
            "customerId = @customerId," +
            "product = @product," +

            "driverName = @driverName," +
            "truckType=@truckType," +
            "payloadType=@payloadType," +
            "export_import=@export_import," +
            "truckNumber=@truckNumber," +
            "containerNumber=@containerNumber," +
            "secondWieght=@secondWieght," +
            "secondTime=@secondTime," +
            "finalWieght=@finalWieght," +
            "note = @note, " +
            "[user] = @user " +
            "WHERE id = {0}", Convert.ToInt16(lblCode.Text));
                int get_custId;
                string sql1 = string.Format("select id from Customers where name=N'{0}'", cbCustomerName.Text);
                using (SqlCeConnection conn = new SqlCeConnection(com.connstr()))
                {
                    using (SqlCeCommand cmd = new SqlCeCommand(sql1, conn))
                    {
                        conn.Open();

                        get_custId = Convert.ToInt16(cmd.ExecuteScalar());
                    }
                }
                using (SqlCeConnection conn = new SqlCeConnection(com.connstr()))
                {
                    using (SqlCeCommand cmd = new SqlCeCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@customerId", get_custId);
                        cmd.Parameters.AddWithValue("@product", cbProduct.Text.Trim());
                        cmd.Parameters.AddWithValue("@driverName", cbDriverName.Text.Trim());
                        cmd.Parameters.AddWithValue("@truckType", cbCarType.Text.Trim());
                        cmd.Parameters.AddWithValue("@payloadType", cbGoodType.Text.Trim());
                        cmd.Parameters.AddWithValue("@export_import", rbExport.Checked ? "صادر" : rbImport.Checked ? "وارد" : "");
                        cmd.Parameters.AddWithValue("@truckNumber", tbCarNumber.Text.Trim());
                        cmd.Parameters.AddWithValue("@containerNumber", tbGoodNumber.Text.Trim());
                        cmd.Parameters.AddWithValue("@secondWieght", lblCarWeight.Text.Trim());
                        cmd.Parameters.AddWithValue("@secondTime", DateTime.ParseExact(lblDate.Text.Trim() + " " + lblTime.Text.Trim(), "dd/MM/yyyy hh:mm tt", CultureInfo.InvariantCulture));
                        cmd.Parameters.AddWithValue("@finalWieght", finalWieght().Trim());
                        cmd.Parameters.AddWithValue("@note", tbNote.Text.Trim());
                        cmd.Parameters.AddWithValue("@user", Properties.Settings.Default.username.Trim());
                        conn.Open();

                        int res = cmd.ExecuteNonQuery();

                        if (res > 0)
                        {
                            //MessageBox.Show("تم الحفظ بالنجاح", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.None);
                            btnPrint.Enabled = true;
                            btnPreview.Enabled = true;
                        }
                    }
                }
                // }
                // else
                // {
                //    string sql = "insert into Wieghts(" +
                //"customerId," +
                //"product," +
                //"date," +
                //"driverName," +
                //"truckType," +
                //"payloadType," +
                //"export_import," +
                //"truckNumber," +
                //"containerNumber," +
                //"firstWieght," +
                // "firstTime," +
                // "firstTime," +
                //"note) " +
                //"VALUES(@customerId," +
                //"@product," +
                //"@date," +
                //"@driverName," +
                //"@truckType," +
                //"@payloadType," +
                //"@export_import," +
                //"@truckNumber," +
                //"@containerNumber," +
                //"@secondWieght," +
                //"@secondTime," +
                //"@finalWieght," +
                //"@note" +
                //")";
                //    int get_custId;
                //    string sql1 = string.Format("select id from Customers where name=N'{0}'", cbCustomerName.Text);
                //    using (SqlCeConnection conn = new SqlCeConnection(com.connstr()))
                //    {
                //        using (SqlCeCommand cmd = new SqlCeCommand(sql1, conn))
                //        {
                //            conn.Open();

                //            get_custId = Convert.ToInt16(cmd.ExecuteScalar());
                //        }
                //    }
                //    using (SqlCeConnection conn = new SqlCeConnection(com.connstr()))
                //    {
                //        using (SqlCeCommand cmd = new SqlCeCommand(sql, conn))
                //        {
                //            cmd.Parameters.AddWithValue("@customerId", get_custId);
                //            cmd.Parameters.AddWithValue("@product", cbProduct.Text);
                //            cmd.Parameters.AddWithValue("@date", DateTime.Now);
                //            cmd.Parameters.AddWithValue("@driverName", cbDriverName.Text);
                //            cmd.Parameters.AddWithValue("@truckType", cbCarType.Text);
                //            cmd.Parameters.AddWithValue("@payloadType", cbGoodType.Text);
                //            cmd.Parameters.AddWithValue("@export_import", rbExport.Checked ? "صادر" : rbImport.Checked ? "وارد" : "");
                //            cmd.Parameters.AddWithValue("@truckNumber", tbCarNumber.Text);
                //            cmd.Parameters.AddWithValue("@containerNumber", tbGoodNumber.Text);
                //            cmd.Parameters.AddWithValue("@firstWieght", DBNull.Value/*lblCarWeight1.Text*/);
                //            cmd.Parameters.AddWithValue("@firstTime", DBNull.Value /*DateTime.ParseExact(lblDate1.Text + " " + lblTime1.Text, "dd/MM/yyyy hh:mm tt", CultureInfo.InvariantCulture)*/);
                //            cmd.Parameters.AddWithValue("@note", tbNote.Text);

                //            conn.Open();

                //            int res = cmd.ExecuteNonQuery();

                //            if (res < 1)
                //            {
                //                MessageBox.Show("تم الحفظ بالنجاح", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.None);

                //            }

                //        }
                //    }
                //}

                // MessageBox.Show(finalWieght(lblCarWeight1.Text, lblCarWeight2.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string finalWieght()
        {
            int wieght1 = !lblCarWieght2.Text.Equals("") ? Convert.ToInt32(lblCarWieght2.Text.All(char.IsDigit) ? lblCarWieght2.Text : "0") : 0;
            int wieght2 = !lblCarWeight.Text.Equals("") ? Convert.ToInt32(lblCarWeight.Text.All(char.IsDigit) ? lblCarWeight.Text : "0") : 0;
            if (wieght1 > 0 && wieght2 > 0)
            {
                if (wieght1 < wieght2)
                {
                    rbExport.Checked = true;
                    rbImport.Checked = false;
                    lblFinalWieght.Text = String.Format("الوزن الصافي {0} كجم", (wieght2 - wieght1).ToString());
                    return (wieght2 - wieght1).ToString();
                }
                else if (wieght1 > wieght2)
                {
                    rbImport.Checked = true;
                    rbExport.Checked = false;
                    lblFinalWieght.Text = String.Format("الوزن الصافي {0} كجم", (wieght1 - wieght2).ToString());
                    return (wieght1 - wieght2).ToString();
                }
            }

            return "0";
        }

        public void loadDataById(int id)
        {
            string sql = string.Format("select * from Wieghts INNER JOIN Customers ON Wieghts.customerId = Customers.Id where Wieghts.id = {0}; ", id);
            using (SqlCeConnection connection = new SqlCeConnection(com.connstr()))
            {
                using (SqlCeCommand command = new SqlCeCommand(sql, connection))
                {
                    connection.Open();
                    SqlCeDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        lblCode.Text = reader["Id"].ToString().Trim();

                        cbProduct.Text = reader["product"].ToString().Trim();
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
                        else if (reader["export_import"].ToString().Trim().Equals(""))
                        {
                            rbImport.Checked = false;
                            rbExport.Checked = false;
                        }
                        lblCarWieght2.Text = reader["firstWieght"].ToString().Trim();

                        lblFinalWieght.Text = String.Format("الوزن الصافي {0} كجم", reader["finalWieght"].ToString().Trim());
                    }
                }
            }
        }

        public void Dis()
        {
            sp.Disconnect();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            ToWord word = new ToWord(Convert.ToDecimal(finalWieght()), new CurrencyInfo(CurrencyInfo.Currencies.Kilo));
            ReportParameterCollection reportParameter = new ReportParameterCollection();
            reportParameter.Add(new ReportParameter("toArabic", word.ConvertToArabic()));
            reportParameter.Add(new ReportParameter("User", Properties.Settings.Default.username));
            LocalReport localReport = new LocalReport();
            localReport.ReportPath = Application.StartupPath + "\\Report1.rdlc";
            Data_Access data_Access = new Data_Access(Convert.ToInt16(lblCode.Text));
            ReportDataSource rds = new ReportDataSource("Wieghts", data_Access.getReportData());
            localReport.DataSources.Clear();
            localReport.DataSources.Add(rds);
            localReport.SetParameters(reportParameter);
            localReport.PrintToPrinter();
        }

        private void btnNewWeight_Click(object sender, EventArgs e)
        {
            Hide();
            sp.Disconnect();
            new first_weight().Show();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {
        }

        private void second_weight_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible == false)
            {
                sp.Disconnect();
            }
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            Save();
            ToWord word = new ToWord(Convert.ToDecimal(finalWieght()), new CurrencyInfo(CurrencyInfo.Currencies.Kilo));

            ReportParameterCollection reportParameter = new ReportParameterCollection();
            reportParameter.Add(new ReportParameter("toArabic", word.ConvertToArabic()));
            reportParameter.Add(new ReportParameter("User", Properties.Settings.Default.username));
            Report report = new Report(Convert.ToInt16(lblCode.Text), reportParameter);
            report.Show();
            Hide();
        }

        private void btnSave_as_fw_Click(object sender, EventArgs e)
        {
        }
    }
}