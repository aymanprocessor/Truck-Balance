using Microsoft.Reporting.WinForms;
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
    public partial class Report : Form
    {
        private common com;
        private Data_Access data_Access;
        private int iid = 0;
        private ReportParameterCollection reports;

        public Report(int iid, ReportParameterCollection reports)
        {
            InitializeComponent();
            btnBack.Visible = false;
            com = new common();
            data_Access = new Data_Access(iid);
            reportViewer1.LocalReport.DataSources.Clear();
            ReportDataSource rds = new ReportDataSource("Wieghts", data_Access.getReportData());
            reportViewer1.LocalReport.DataSources.Add(rds);
            this.reportViewer1.LocalReport.ReportPath = "Reports\\Rep_weight.rdlc";
            this.reportViewer1.LocalReport.SetParameters(reports);
            this.reportViewer1.RefreshReport();
        }

        public Report(DateTimePicker fromDate, DateTimePicker toDate, string type)
        {
            InitializeComponent();
            com = new common();
            data_Access = new Data_Access(iid);
            reportViewer1.LocalReport.DataSources.Clear();
            ReportDataSource rds = new ReportDataSource("DataSet1", data_Access.getReportBetweenTwoDate(fromDate, toDate, type.Equals("الصادرة") ? "قطاعات الومنيوم" : type.Equals("الواردة") ? "اخرى" : ""));
            reportViewer1.LocalReport.DataSources.Add(rds);
            ReportParameterCollection reportParameter = new ReportParameterCollection();
            reportParameter.Add(new ReportParameter("type", type));
            reportParameter.Add(new ReportParameter("fromDate", fromDate.Value.ToString("dd/MM/yyyy")));
            reportParameter.Add(new ReportParameter("toDate", toDate.Value.ToString("dd/MM/yyyy")));
            if (type.Equals("الصادرة"))
            {
                this.reportViewer1.LocalReport.ReportPath = "Reports\\Rep_alum.rdlc";
            }
            else if (type.Equals("الواردة"))
            {
                this.reportViewer1.LocalReport.ReportPath = "Reports\\Rep_Other.rdlc";
            }
            this.reportViewer1.LocalReport.SetParameters(reportParameter);
            this.reportViewer1.RefreshReport();
        }

        private void Report_Load(object sender, EventArgs e)
        {
            //com = new common();
            //data_Access = new Data_Access(iid);
            //reportViewer1.LocalReport.DataSources.Clear();
            //ReportDataSource rds = new ReportDataSource("DataSet1", data_Access.getReportBetweenTwoDate());
            //reportViewer1.LocalReport.DataSources.Add(rds);
            ////this.reportViewer1.LocalReport.SetParameters(reports);
            //this.reportViewer1.RefreshReport();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Hide();
            Main main = new Main();
            main.Show();
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            reportViewer1.LocalReport.setCopy(Convert.ToInt16(txtCopy.Text));
            reportViewer1.LocalReport.PrintToPrinter();
        }

        private void Report_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            new Main().Show();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txtCopy.Enabled = true;
            }
            else
            {
                txtCopy.Enabled = false;
                txtCopy.Text = "1";
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            prompt_reportByDatecs prompt = new prompt_reportByDatecs();
            prompt.Show();
            Hide();
        }
    }
}