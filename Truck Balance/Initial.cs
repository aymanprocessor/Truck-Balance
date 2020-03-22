using System;
using System.IO.Ports;
using System.Windows.Forms;
using Truck_Balance.Forms;

namespace Truck_Balance
{
    public partial class Initial : Form
    {
        private SerialPortReader sp;

        public Initial()
        {
            InitializeComponent();
            panel1.Visible = true;
            panel2.Visible = false;
        }

        private void Initial_Load(object sender, EventArgs e)
        {
            LoadPortSetting();
            loadPort();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (btnNext.Text.Equals("التالي") && panel1.Visible == true)
            {
                ShowPanel2();
                savePortSetting();
            }
            else if (btnNext.Text.Equals("التالي") && panel2.Visible == true)
            {
                ShowPanel3();
                savePortSetting();
            }
            else if (btnNext.Text.Equals("انتهاء"))
            {
                Properties.Settings.Default.firstTime = false;
                savePortSetting();
                Login login = new Login();
                login.Show();
                Hide();
            }
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            ShowPanel1();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            sp = new SerialPortReader(this, lblWeightReading);
            sp.Connect();
            btnDisconnect.Enabled = true;
            btnConnect.Enabled = false;
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            sp.Disconnect();
            btnDisconnect.Enabled = false;
            btnConnect.Enabled = true;
        }

        private void ShowPanel1()
        {
            panel1.Visible = true;
            panel2.Visible = false;
            panel3.Visible = false;
            btnNext.Text = "التالي";
            btnPrev.Enabled = false;
        }

        private void ShowPanel2()
        {
            panel1.Visible = false;
            panel2.Visible = true;
            panel3.Visible = false;
            btnNext.Text = "التالي";
            btnPrev.Enabled = true;
        }

        private void ShowPanel3()
        {
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = true;
            btnNext.Text = "انتهاء";
            btnPrev.Enabled = true;
        }

        private void savePortSetting()
        {
            if (cbPort.SelectedIndex == -1)
            {
                MessageBox.Show("من فضلك اختر المنفذ", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cbBaudrate.SelectedIndex == -1)
            {
                MessageBox.Show("من فضلك اختر الباود", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtDbConn.TextLength <= 0)
            {
                MessageBox.Show("من فضلك اختر ملف قاعدة البيانات", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Properties.Settings.Default.port = cbPort.Text.Trim();
            Properties.Settings.Default.baudrate = cbBaudrate.Text.Trim();
            Properties.Settings.Default.parity = cbParity.Text.Trim();
            Properties.Settings.Default.databits = cbDatabits.Text.Trim();
            Properties.Settings.Default.stopbits = cbStopbits.Text.Trim();
            Properties.Settings.Default.start = txtStart.Text.Trim();
            Properties.Settings.Default.end = txtEnd.Text.Trim();
            Properties.Settings.Default.dbpath = txtDbConn.Text.Trim();
            Properties.Settings.Default.Save();
        }

        private void savePositionSetting()
        {
            Properties.Settings.Default.start = txtStart.Text.Trim();
            Properties.Settings.Default.end = txtEnd.Text.Trim();
            Properties.Settings.Default.Save();
        }

        private void LoadPortSetting()
        {
            cbBaudrate.Text = Properties.Settings.Default.baudrate;

            cbParity.Text = Properties.Settings.Default.parity;
            cbDatabits.Text = Properties.Settings.Default.databits;
            cbStopbits.Text = Properties.Settings.Default.stopbits;
            txtStart.Text = Properties.Settings.Default.start;
            txtEnd.Text = Properties.Settings.Default.end;
            txtDbConn.Text = Properties.Settings.Default.dbpath;
        }

        private void loadPort()
        {
            string[] ports = SerialPort.GetPortNames();
            if (cbPort.Items.Count > 0)
            {
                cbPort.Items.Clear();
            }
            foreach (string port in ports)
            {
                cbPort.Items.Add(port);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtDbConn.Text = openFileDialog1.FileName;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.ExitThread();
        }

        private void txtStart_TextChanged(object sender, EventArgs e)
        {
            savePositionSetting();
        }

        private void txtEnd_TextChanged(object sender, EventArgs e)
        {
            savePositionSetting();
        }
    }
}