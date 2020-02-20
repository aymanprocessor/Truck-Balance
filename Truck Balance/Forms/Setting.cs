using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Truck_Balance.Forms
{
    public partial class Setting : Form
    {
        public Setting()
        {
            InitializeComponent();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void Setting_Load(object sender, EventArgs e)
        {
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
        }

        private void savePortSetting(string port, string baudrate, string parity, string databits, string stopbits)
        {
            Properties.Settings.Default.port = port;
            Properties.Settings.Default.baudrate = baudrate;
            Properties.Settings.Default.parity = parity;
            Properties.Settings.Default.databits = databits;
            Properties.Settings.Default.stopbits = stopbits;
            Properties.Settings.Default.Save();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            savePortSetting(cbPort.Text, cbBaudrate.Text, cbParity.Text, cbDatabits.Text, cbStopbits.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            savePortSetting(cbPort.Text, "9600", "None", "8", "1");
            loadPortSetting();
        }
    }
}
