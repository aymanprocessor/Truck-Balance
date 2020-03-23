using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Truck_Balance
{
    internal class SerialPortReader : IDisposable
    {
        private SerialPort sp;
        private TextBox lblWeightReading;
        private Label lblWeightReading_label;
        private Form form;

        public SerialPortReader(Form _form, Label _lblWeightReading)
        {
            sp = new SerialPort();
            lblWeightReading_label = _lblWeightReading;
            form = _form;
            sp.PortName = Properties.Settings.Default.port;
            sp.BaudRate = Convert.ToInt16(Properties.Settings.Default.baudrate);
            sp.Parity = Parity.None;
            sp.StopBits = StopBits.One;
            sp.DataBits = 8;
            sp.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandlerII);
        }

        public SerialPortReader(Form _form, TextBox _lblWeightReading)
        {
            sp = new SerialPort();
            lblWeightReading = _lblWeightReading;
            form = _form;
            sp.PortName = Properties.Settings.Default.port;
            sp.BaudRate = Convert.ToInt16(Properties.Settings.Default.baudrate);
            sp.Parity = Parity.None;
            sp.StopBits = StopBits.One;
            sp.DataBits = 8;
            sp.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
        }

        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort ssp = (SerialPort)sender;
            string data = "";

            data = ssp.ReadExisting();

            Thread.Sleep(300);
            if (lblWeightReading.InvokeRequired)
            {
                form.BeginInvoke(new EventHandler(DisplayData), data, EventArgs.Empty);
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

        private void DataReceivedHandlerII(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort ssp = (SerialPort)sender;
            string data = "";

            data = ssp.ReadExisting();

            Thread.Sleep(300);
            if (lblWeightReading_label.InvokeRequired)
            {
                form.BeginInvoke(new EventHandler(DisplayDataII), data, EventArgs.Empty);
            }
            else
            {
                DisplayDataII(data, EventArgs.Empty);
            }
        }

        private void DisplayDataII(object sender, EventArgs e)
        {
            lblWeightReading_label.Text = "";
            string data = (string)sender;
            if (data.Length > 7)
            {
                lblWeightReading_label.Text = data.Substring(Convert.ToInt16(Properties.Settings.Default.start), Convert.ToInt16(Properties.Settings.Default.end));
            }
        }

        public void Connect()
        {
            try
            {
                if (!sp.IsOpen)
                {
                    sp.Open();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Disconnect()
        {
            try
            {
                if (sp.IsOpen)
                {
                    sp.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Dispose()
        {
            sp.Dispose();
        }
    }
}