using MetroFramework.Forms;
using Microsoft.Reporting.WinForms;
using NumberToWord;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
    public partial class first_weight : MetroForm
    {
        private SerialPort sp;

        //string customersPath = String.Format("{0}\\data\\customers.txt", Environment.CurrentDirectory);
        private string driversPath = String.Format("{0}\\data\\drivers.txt", Environment.CurrentDirectory);

        private string goodsPath = String.Format("{0}\\data\\goods.txt", Environment.CurrentDirectory);
        private string trucksPath = String.Format("{0}\\data\\trucks.txt", Environment.CurrentDirectory);
        private string productPath = String.Format("{0}\\data\\product.txt", Environment.CurrentDirectory);
        private common com;
        private string id_val;
        private SerialPortReader serial;

        public first_weight()
        {
            InitializeComponent();
        }

        public void first_weight_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.username == "admin")
            {
                lblWeightReading.ReadOnly = false;
            }
            else
            {
                lblWeightReading.ReadOnly = true;
            }
            btnSave.Enabled = false;
            com = new common();
            serial = new SerialPortReader(this, lblWeightReading);

            serial.Connect();

            foreach (Control c in this.Controls)
            {
                if (c is TextBox)
                {
                    ((TextBox)c).TextChanged += new EventHandler(c_ControlChanged);
                }
            }

            //lblWeightReading.Text = new Random().Next(500, 1000).ToString();
            loadintocombo(driversPath, cbDriverName);
            loadintocombo(goodsPath, cbProduct);
            loadintocombo(trucksPath, cbCarType);
            //loadintocombo(productPath, cbProduct);

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
                        label12.Text = "1";
                        resetId();
                    }
                    else
                    {
                        label12.Text = (Convert.ToInt32(command.ExecuteScalar()) + 1).ToString();
                    }
                }
            }
        }

        private void c_ControlChanged(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        { //DialogResult res = MessageBox.Show("هل تريد ان تخرج؟", "تأكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
          //    if (res == DialogResult.Yes)
          //    {
            Main main = new Main();
            main.Show();
            this.Hide();
            //disconnect();
            serial.Disconnect();
            //}
        }

        private void btnSecondWeight_Click(object sender, EventArgs e)
        {
            // prevWieght prevWieght = new prevWieght(new second_weight());
            //prevWieght.Show();
            serial.Disconnect();
            second_weight second_Weight = new second_weight();
            second_Weight.Show();
            second_Weight.loadDataById(Convert.ToInt32(label12.Text));
            this.Hide();
        }

        private void loadintocombo(String path, ComboBox cb)
        {
            if (File.Exists(path))
            {
                if (cb.Items.Count > 0)
                {
                    cb.Items.Clear();
                }
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

        private void loadIntoComboFromDatabse(ComboBox cb, string sql)
        {
            try
            {
                if (cb.Items.Count > 0)
                {
                    cb.Items.Clear();
                }

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

        private void first_weight_FormClosing(object sender, FormClosingEventArgs e)
        {
            {
                // DialogResult res = MessageBox.Show("هل تريد ان تخرج؟", "تأكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                //if (res == DialogResult.Yes)
                //{
                Main main = new Main();
                main.Show();
                this.Hide();
                //disconnect();
                serial.Disconnect();
                //}
            }
        }

        private void btnRecordWeight_Click(object sender, EventArgs e)
        {
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void btnRecordWeight1_Click(object sender, EventArgs e)
        {
            record1();
        }

        private void record1()
        {
            if (Convert.ToInt64(lblWeightReading.Text) > 0)
            {
                lblCarWeight1.Text = lblWeightReading.Text.TrimStart(new char[] { '0' });
            }
            else
            {
                MessageBox.Show("من فضلك تأكد من قراءة الميزان", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            lblTime1.Text = DateTime.Now.ToString("hh:mm tt");
            lblDate1.Text = DateTime.Now.ToString("dd/MM/yyyy");
            btnSave.Enabled = true;
            //if (!lblCarWeight1.Text.All(char.IsDigit) || !lblWeightReading.Text.All(char.IsDigit))
            //{
            //    return;
            //}
            //if (isTaken1)
            //{
            //    if (Convert.ToInt32(lblWeightReading.Text) == Convert.ToInt32(lblCarWeight1.Text))
            //    {
            //        finalWieght();
            //        return;
            //    }
            //}
            //else
            //{
            //    lblCarWeight1.Text = lblWeightReading.Text.TrimStart(new char[] { '0' }).Equals("")?"0": lblWeightReading.Text.TrimStart(new char[] { '0' });
            //    lblTime1.Text = DateTime.Now.ToString("hh:mm tt");
            //    lblDate1.Text = DateTime.Now.ToString("dd/MM/yyyy");
            //    finalWieght();

            //}

            //lblWeightReading.Text = new Random().Next(500, 1000).ToString();
        }

        /* private string finalWieght()
         {
             int wieght1 = !lblCarWeight1.Text.Equals("") ? Convert.ToInt32(lblCarWeight1.Text.All(char.IsDigit) ? lblCarWeight1.Text : "0"):0;
            // int wieght2 = !lblCarWeight2.Text.Equals("") ? Convert.ToInt32(lblCarWeight2.Text.All(char.IsDigit) ? lblCarWeight2.Text : "0"):0;
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
         }*/

        private void btnNewWeight_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("هل تريد وزنة جديدة؟", "تأكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                string sql = "select max(id) from Wieghts";
                using (SqlCeConnection connection = new SqlCeConnection(com.connstr()))
                {
                    using (SqlCeCommand command = new SqlCeCommand(sql, connection))
                    {
                        connection.Open();
                        var result = command.ExecuteScalar();
                        if (result.Equals(DBNull.Value))
                        {
                            label12.Text = "1";
                        }
                        else
                        {
                            label12.Text = (Convert.ToInt32(command.ExecuteScalar()) + 1).ToString();
                        }
                    }
                }

                cbCarType.SelectedIndex = -1;
                cbCustomerName.SelectedIndex = -1;
                cbDriverName.SelectedIndex = -1;
                // cbGoodType.SelectedIndex = -1;
                cbProduct.SelectedIndex = -1;
                rbExport.Checked = false;
                rbImport.Checked = false;

                tbCarNumber.Text = "";
                tbGoodNumber.Text = "";
                tbNote.Text = "";
                lblCarWeight1.Text = "";
                //lblCarWeight2.Text = "";
                lblDate1.Text = "";
                //lblDate2.Text = "";
                lblTime1.Text = "";
                //lblTime2.Text = "";
            }
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
                        label12.Text = reader["Id"].ToString().Trim();

                        cbProduct.Text = reader["product"].ToString().Trim();
                        cbCustomerName.Text = reader["name"].ToString().Trim();
                        cbDriverName.Text = reader["driverName"].ToString().Trim();
                        cbCarType.Text = reader["truckType"].ToString().Trim();
                        //cbGoodType.Text = reader["payloadType"].ToString().Trim();
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
                        lblCarWeight1.Text = reader["firstWieght"].ToString().Trim();
                        lblDate1.Text = ((DateTime)reader["firstTime"]).ToString("dd/MM/yyyy").Trim();
                        lblTime1.Text = ((DateTime)reader["firstTime"]).ToString("hh:mm tt").Trim();
                    }
                }
            }
        }

        private void connect()
        {
            try
            {
                sp = new SerialPort(Properties.Settings.Default.port);
                sp.BaudRate = Convert.ToInt16(Properties.Settings.Default.baudrate);
                sp.Parity = Parity.None;
                sp.StopBits = StopBits.One;
                sp.DataBits = 8;
                sp.Handshake = Handshake.None;
                sp.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);

                if (!sp.IsOpen) { sp.Open(); }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DataReceivedHandler(object senderrr, SerialDataReceivedEventArgs e)
        {
            SerialPort ssp = (SerialPort)senderrr;
            string data = "";

            data = ssp.ReadExisting();

            Thread.Sleep(300);
            if (lblWeightReading.InvokeRequired)
            {
                BeginInvoke(new EventHandler(DisplayData), data, EventArgs.Empty);
            }
            else
            {
                DisplayData(data, EventArgs.Empty);
            }
        }

        private void DisplayData(object sender, EventArgs e)
        {
            lblWeightReading.Text = "";
            string data = (string)sender;
            if (data.Length > 7)
            {
                lblWeightReading.Text = data.Substring(Convert.ToInt16(Properties.Settings.Default.start), Convert.ToInt16(Properties.Settings.Default.end));
            }
        }

        private void disconnect()
        {
            try
            {
                sp.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Save()
        {
            try
            {
                if (tbCarNumber.Text.Length == 0)
                {
                    MessageBox.Show("من فضلك ادحل رقم السيارة", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tbCarNumber.Focus();
                    return;
                }

                string sql2 = string.Format("select count(*) from Wieghts where id={0}", label12.Text);
                int count;
                using (SqlCeConnection conn = new SqlCeConnection(com.connstr()))
                {
                    using (SqlCeCommand cmd = new SqlCeCommand(sql2, conn))
                    {
                        conn.Open();

                        count = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
                if (count > 0)
                {
                    string sql = string.Format("update Wieghts SET " +
                "customerId = @customerId," +
                "product = @product," +
                "date = @date," +
                "driverName = @driverName," +
                "truckType=@truckType," +
                //"payloadType=@payloadType," +
                "export_import=@export_import," +
                "truckNumber=@truckNumber," +
                "containerNumber=@containerNumber," +
                "firstWieght=@firstWieght," +
                "firstTime=@firstTime," +
                "note = @note, " +
                "[user] = @user " +
                "WHERE id = {0}", Convert.ToInt32(label12.Text));
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
                            cmd.Parameters.AddWithValue("@date", DateTime.Now);
                            cmd.Parameters.AddWithValue("@driverName", cbDriverName.Text.Trim());
                            cmd.Parameters.AddWithValue("@truckType", cbCarType.Text.Trim());
                            //cmd.Parameters.AddWithValue("@payloadType", cbGoodType.Text.Trim());
                            cmd.Parameters.AddWithValue("@export_import", rbExport.Checked ? "صادر" : rbImport.Checked ? "وارد" : "");
                            cmd.Parameters.AddWithValue("@truckNumber", tbCarNumber.Text.Trim());
                            cmd.Parameters.AddWithValue("@containerNumber", tbGoodNumber.Text.Trim());
                            cmd.Parameters.AddWithValue("@firstWieght", lblCarWeight1.Text.Trim());
                            cmd.Parameters.AddWithValue("@firstTime", DateTime.ParseExact(lblDate1.Text.Trim() + " " + lblTime1.Text.Trim(), "dd/MM/yyyy hh:mm tt", CultureInfo.InvariantCulture));
                            cmd.Parameters.AddWithValue("@note", tbNote.Text.Trim());
                            cmd.Parameters.AddWithValue("@user", Properties.Settings.Default.username.Trim());

                            conn.Open();

                            int res = cmd.ExecuteNonQuery();

                            if (res > 0)
                            {
                                //MessageBox.Show("تم الحفظ بالنجاح", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.None);
                                btnSecondWeight.Enabled = true;
                                btnNewWeight.Enabled = true;
                            }
                        }
                    }
                }
                else
                {
                    string sql = "insert into Wieghts(" +
                "customerId," +
                "product," +
                "date," +
                "driverName," +
                "truckType," +
                //"payloadType," +
                "export_import," +
                "truckNumber," +
                "containerNumber," +
                "firstWieght," +
                "firstTime," +
                "[user]," +
                "note) " +
                "VALUES(@customerId," +
                "@product," +
                "@date," +
                "@driverName," +
                "@truckType," +
                //"@payloadType," +
                "@export_import," +
                "@truckNumber," +
                "@containerNumber," +
                "@firstWieght," +
                "@firstTime," +
                "@user," +

                "@note" +

                ")";
                    int get_custId;
                    string sql1 = string.Format("select id from Customers where name=N'{0}'", cbCustomerName.Text);
                    using (SqlCeConnection conn = new SqlCeConnection(com.connstr()))
                    {
                        using (SqlCeCommand cmd = new SqlCeCommand(sql1, conn))
                        {
                            conn.Open();

                            get_custId = Convert.ToInt32(cmd.ExecuteScalar());
                        }
                    }
                    using (SqlCeConnection conn = new SqlCeConnection(com.connstr()))
                    {
                        using (SqlCeCommand cmd = new SqlCeCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@customerId", get_custId);
                            cmd.Parameters.AddWithValue("@product", cbProduct.Text.Trim());
                            cmd.Parameters.AddWithValue("@date", DateTime.Now);
                            cmd.Parameters.AddWithValue("@driverName", cbDriverName.Text.Trim());
                            cmd.Parameters.AddWithValue("@truckType", cbCarType.Text.Trim());
                            //cmd.Parameters.AddWithValue("@payloadType", cbGoodType.Text.Trim());
                            cmd.Parameters.AddWithValue("@export_import", rbExport.Checked ? "صادر" : rbImport.Checked ? "وارد" : "");
                            cmd.Parameters.AddWithValue("@truckNumber", tbCarNumber.Text.Trim());
                            cmd.Parameters.AddWithValue("@containerNumber", tbGoodNumber.Text.Trim());
                            cmd.Parameters.AddWithValue("@firstWieght", lblCarWeight1.Text.Trim());
                            cmd.Parameters.AddWithValue("@firstTime", DateTime.ParseExact(lblDate1.Text + " " + lblTime1.Text, "dd/MM/yyyy hh:mm tt", CultureInfo.InvariantCulture));
                            cmd.Parameters.AddWithValue("@note", tbNote.Text.Trim());
                            cmd.Parameters.AddWithValue("@user", Properties.Settings.Default.username.Trim());

                            conn.Open();

                            int res = cmd.ExecuteNonQuery();

                            if (res > 0)
                            {
                                //MessageBox.Show("تم الحفظ بالنجاح", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.None);
                                btnNewWeight.Enabled = true;
                                btnSecondWeight.Enabled = true;
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

        private void label10_Click(object sender, EventArgs e)
        {
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void groupBox1_Enter_1(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            goods g = new goods();
            DialogResult dialogResult = g.ShowDialog();
            if (dialogResult == DialogResult.Cancel)
            {
                loadintocombo(goodsPath, cbProduct);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            customers c = new customers();

            DialogResult dialogResult = c.ShowDialog();
            if (dialogResult == DialogResult.Cancel)
            {
                loadIntoComboFromDatabse(cbCustomerName, "select id,name from Customers");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            drivers d = new drivers();
            DialogResult dialogResult = d.ShowDialog();
            if (dialogResult == DialogResult.Cancel)
            {
                loadintocombo(driversPath, cbDriverName);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            trucks t = new trucks();

            DialogResult dialogResult = t.ShowDialog();
            if (dialogResult == DialogResult.Cancel)
            {
                loadintocombo(trucksPath, cbCarType);
            }
        }

        private void resetId()
        {
            using (SqlCeConnection connection = new SqlCeConnection(com.connstr()))
            {
                using (SqlCeCommand command = new SqlCeCommand(" ALTER TABLE [Wieghts] ALTER COLUMN [Id] IDENTITY (1,1) ", connection))
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        private void loadDataById1(int id)
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
                        cbProduct.Text = reader["product"].ToString().Trim();
                        cbDriverName.Text = reader["driverName"].ToString().Trim();
                        cbCarType.Text = reader["truckType"].ToString().Trim();
                        tbCarNumber.Text = reader["truckNumber"].ToString().Trim();
                        tbGoodNumber.Text = reader["containerNumber"].ToString().Trim();
                    }
                }
            }
        }
    }
}