using System;
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

namespace Truck_Balance.Forms
{
    public partial class goods : Form
    {
        string fileName = String.Format("data\\goods.txt", Environment.CurrentDirectory);
        public goods()
        {
            InitializeComponent();
        }

        private void drivers_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dbDataSet.driver' table. You can move, or remove it, as needed.
          


            Directory.CreateDirectory(Environment.CurrentDirectory + "\\data");
            if (File.Exists(fileName))
            {
                const Int32 BufferSize = 1024;
                using (var fileStream = File.OpenRead(fileName))
                using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize))
                {
                    String line;
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        listBox1.Items.Add(line);
                    }

                }
            }
            else
            {

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                File.AppendAllText(fileName, textBox1.Text+Environment.NewLine);
                listBox1.Items.Add(textBox1.Text);
                textBox1.Clear();
                textBox1.Focus();
            }
            else
            {
                MessageBox.Show("من فضلك اكتب الحاوية");
            }



        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex > -1)
            {
                List<String> lines = File.ReadAllLines(fileName).ToList();
                lines.RemoveAt(listBox1.SelectedIndex);
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
                File.WriteAllLines(fileName, lines.ToArray());
            }
            else
            {
                MessageBox.Show("من فضلك اختر الحاوية");
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Hide();
        }
    }
}
