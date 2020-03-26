using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Truck_Balance.Forms
{
    public partial class Setting : Form
    {
        private SerialPortReader sp;
        private bool isSaved = false;

        public Setting()
        {
            InitializeComponent();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
        }

        private void Setting_Load(object sender, EventArgs e)
        {
            isSaved = false;
            sp = new SerialPortReader(this, label5);
            loadPort();
            loadPortSetting();
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            loadPort();
        }

        private void loadPortSetting()
        {
            cbPort.Text = Properties.Settings.Default.port;
            cbBaudrate.Text = Properties.Settings.Default.baudrate;
            cbParity.Text = Properties.Settings.Default.parity;
            cbDatabits.Text = Properties.Settings.Default.databits;
            cbStopbits.Text = Properties.Settings.Default.stopbits;
            txtDbConn.Text = Properties.Settings.Default.dbpath;
            txtStart.Text = Properties.Settings.Default.start;
            txtEnd.Text = Properties.Settings.Default.end;
        }

        private void savePortSetting(string port, string baudrate, string parity, string databits, string stopbits)
        {
            Properties.Settings.Default.port = port;
            Properties.Settings.Default.baudrate = baudrate;
            Properties.Settings.Default.parity = parity;
            Properties.Settings.Default.databits = databits;
            Properties.Settings.Default.stopbits = stopbits;
            Properties.Settings.Default.start = txtStart.Text;
            Properties.Settings.Default.end = txtEnd.Text;
            Properties.Settings.Default.Save();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            savePortSetting(cbPort.Text, cbBaudrate.Text, cbParity.Text, cbDatabits.Text, cbStopbits.Text);
            isSaved = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            savePortSetting(cbPort.Text, "9600", "None", "8", "1");
            loadPortSetting();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                sp.Connect();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            try
            {
                sp.Disconnect();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.dbpath = txtDbConn.Text;
            Properties.Settings.Default.Save();
            isSaved = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtDbConn.Text = openFileDialog1.FileName;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (isSaved)
            {
                sp.Disconnect();

                Hide();
            }
            else
            {
                DialogResult res = MessageBox.Show("هل تريد ان تخرج بدون الحفظ؟", "تأكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    sp.Disconnect();

                    Hide();
                }
            }
        }

        private void Setting_FormClosing(object sender, FormClosingEventArgs e)
        {
            sp.Disconnect();

            Hide();
        }
    }
}