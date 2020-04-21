using Microsoft.Reporting.WinForms;
using NumberToWord;
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
    public partial class Review : Form
    {
        private common com;
        private DateTimePicker fromDate, toDate;
        private string type;

        public Review()
        {
            InitializeComponent();
            com = new common();
            loadData();
        }

        public Review(DateTimePicker _fromDate, DateTimePicker _toDate, string _type)
        {
            InitializeComponent();
            com = new common();
            btnDelete.Visible = false;
            مسحToolStripMenuItem.Visible = false;
            fromDate = _fromDate;
            toDate = _toDate;
            type = _type;
            loadDataByTwoDate();
        }

        private void Review_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.username == "admin")
            {
                btnDelete.Enabled = true;
                مسحToolStripMenuItem.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Main main = new Main();
            main.Show();
            Hide();
        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0 && e.RowIndex > -1)
            {
                if (e.Button == MouseButtons.Right)
                {
                    dataGridView1.CurrentCell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    // Can leave these here - doesn't hurt
                    dataGridView1.Rows[e.RowIndex].Selected = true;
                    dataGridView1.Focus();
                }
            }
        }

        private void طباعةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            print(dataGridView1);
        }

        private void معاينةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToWord word = new ToWord(Convert.ToDecimal(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[8].Value.Equals(DBNull.Value) ? "0" : dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[8].Value), new CurrencyInfo(CurrencyInfo.Currencies.Kilo));

            ReportParameterCollection reportParameter = new ReportParameterCollection();
            reportParameter.Add(new ReportParameter("toArabic", word.ConvertToArabic()));
            reportParameter.Add(new ReportParameter("User", Properties.Settings.Default.username));
            Report report = new Report(Convert.ToInt16(Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value)), reportParameter);
            report.Show();
            Hide();
        }

        private void print(DataGridView dataGridView1)
        {
            ToWord word = new ToWord(Convert.ToDecimal(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[8].Value.Equals(DBNull.Value) ? "0" : dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[8].Value), new CurrencyInfo(CurrencyInfo.Currencies.Kilo));
            ReportParameterCollection reportParameter = new ReportParameterCollection();
            reportParameter.Add(new ReportParameter("toArabic", word.ConvertToArabic()));
            reportParameter.Add(new ReportParameter("User", Properties.Settings.Default.username));
            LocalReport localReport = new LocalReport();
            localReport.ReportPath = Application.StartupPath + "\\Report1.rdlc";
            Data_Access data_Access = new Data_Access(Convert.ToInt16(Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value)));
            ReportDataSource rds = new ReportDataSource("Wieghts", data_Access.getReportData());
            localReport.DataSources.Clear();
            localReport.DataSources.Add(rds);
            localReport.SetParameters(reportParameter);
            localReport.PrintToPrinter();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0 && e.RowIndex > -1)
            {
                print(dataGridView1);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            delete();
            loadData();
        }

        private void delete()
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                try
                {
                    string sql = string.Format("DELETE FROM Wieghts WHERE id = {0};", Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value));
                    using (SqlConnection conn = new SqlConnection(com.connstr()))
                    {
                        using (SqlCommand cmd = new SqlCommand(sql, conn))
                        {
                            conn.Open();
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("من فضلك اختر الصف ", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void loadData()
        {
            try
            {
                string sql = "SELECT " +
                        "Wieghts.Id as م," +
                        "Wieghts.date as [التاريخ]," +
                        "Customers.name as  [اسم العميل]," +
                        "Wieghts.driverName as [اسم السائق]," +
                        "Wieghts.firstWieght as [الوزنة الاولى]," +
                        "Wieghts.firstTime as [وقت الوزنة الاولى]," +
                        "Wieghts.secondWieght as [الوزنة الثانية]," +
                        "Wieghts.secondTime as [وقت الوزنة الثانية]," +
                        "Wieghts.finalWieght as [الوزن الصافي]," +
                        "Wieghts.truckNumber as [رقم السيارة]," +
                        "Wieghts.truckType as [نوع السيارة]," +
                        "Wieghts.containerNumber as [رقم الحمولة]," +
                        "Wieghts.payloadType as [نوع الحمولة]," +
                        "Wieghts.export_import as [صادر_وارد]," +
                        "Wieghts.note as [ملاحظة]," +
                        "Wieghts.[user] as [القائم بالوزن] " +
                        "FROM Wieghts INNER JOIN Customers ON Wieghts.customerId = Customers.Id";
                using (SqlConnection conn = new SqlConnection(com.connstr()))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(sql, conn))
                    {
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

        private void loadDataByTwoDate()
        {
            try
            {
                string sql = "";
                if (type.Equals("قطاعات الومنيوم"))
                {
                    sql = "SELECT " +
                    "Wieghts.Id as م," +
                    "Wieghts.date as [التاريخ]," +
                    "Customers.name as  [اسم العميل]," +
                    "Wieghts.driverName as [اسم السائق]," +
                    "Wieghts.truckNumber as [رقم السيارة]," +
                    "Wieghts.firstWieght as [الوزنة الاولى]," +
                    "Wieghts.firstTime as [وقت الوزنة الاولى]," +
                    "Wieghts.secondWieght as [الوزنة الثانية]," +
                    "Wieghts.secondTime as [وقت الوزنة الثانية]," +
                    "Wieghts.finalWieght as [الوزن الصافي]," +
                    "Wieghts.note as [ملاحظة]," +
                    "Wieghts.[user] as [القائم بالوزن] " +
                    "FROM Wieghts INNER JOIN Customers ON Wieghts.customerId = Customers.Id " +
                    "WHERE Wieghts.product = 'قطاعات الومنيوم' and Wieghts.date >= CONVERT(datetime,@fromDate,101) and Wieghts.date <=CONVERT(datetime,@toDate,101) ";
                }
                else if (type.Equals("اخرى"))
                {
                    sql = "SELECT " +
                    "Wieghts.Id as م," +
                    "Wieghts.date as [التاريخ]," +
                    "Customers.name as  [اسم العميل]," +
                    "Wieghts.product as [نوع الحمولة]," +
                    "Wieghts.driverName as [اسم السائق]," +
                    "Wieghts.truckNumber as [رقم السيارة]," +
                    "Wieghts.firstWieght as [الوزنة الاولى]," +
                    "Wieghts.firstTime as [وقت الوزنة الاولى]," +
                    "Wieghts.secondWieght as [الوزنة الثانية]," +
                    "Wieghts.secondTime as [وقت الوزنة الثانية]," +
                    "Wieghts.finalWieght as [الوزن الصافي]," +
                    "Wieghts.note as [ملاحظة]," +
                    "Wieghts.[user] as [القائم بالوزن] " +
                    "FROM Wieghts INNER JOIN Customers ON Wieghts.customerId = Customers.Id " +
                    "WHERE Wieghts.product != 'قطاعات الومنيوم' and Wieghts.date between CONVERT(datetime,@fromDate,101) and CONVERT(datetime,@toDate,101)";
                }
                using (SqlConnection conn = new SqlConnection(com.connstr()))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(sql, conn))
                    {
                        DataTable dt = new DataTable();
                        adapter.SelectCommand.Parameters.AddWithValue("@fromDate", fromDate.Value.ToShortDateString() + " 11:59 PM");
                        adapter.SelectCommand.Parameters.AddWithValue("@toDate", toDate.Value.ToShortDateString() + " 11:59 PM");
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

        private void Review_FormClosing(object sender, FormClosingEventArgs e)
        {
            Main main = new Main();
            main.Show();
            Hide();
        }

        private void مسحToolStripMenuItem_Click(object sender, EventArgs e)
        {
            delete();
            loadData();
        }
    }
}