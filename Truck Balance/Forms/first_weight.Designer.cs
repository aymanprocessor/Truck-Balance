namespace Truck_Balance.Forms
{
    partial class first_weight
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(first_weight));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbCustomerName = new System.Windows.Forms.ComboBox();
            this.cbDriverName = new System.Windows.Forms.ComboBox();
            this.cbCarType = new System.Windows.Forms.ComboBox();
            this.rbExport = new System.Windows.Forms.RadioButton();
            this.rbImport = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.tbNote = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbCarNumber = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbGoodNumber = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.cbProduct = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.lblTime1 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lblCarWeight1 = new System.Windows.Forms.Label();
            this.lblDate1 = new System.Windows.Forms.Label();
            this.btnRecordWeight = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.btnNewWeight = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnSecondWeight = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblWeightReading = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Teal;
            this.label1.Location = new System.Drawing.Point(598, 41);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(90, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "اسم العميل :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Teal;
            this.label2.Location = new System.Drawing.Point(597, 90);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(95, 24);
            this.label2.TabIndex = 0;
            this.label2.Text = "اسم السائق :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Teal;
            this.label3.Location = new System.Drawing.Point(210, 90);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(101, 24);
            this.label3.TabIndex = 0;
            this.label3.Text = "نوع السيارة :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label3.Click += new System.EventHandler(this.label2_Click);
            // 
            // cbCustomerName
            // 
            this.cbCustomerName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbCustomerName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbCustomerName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbCustomerName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCustomerName.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCustomerName.ForeColor = System.Drawing.Color.Teal;
            this.cbCustomerName.FormattingEnabled = true;
            this.cbCustomerName.Location = new System.Drawing.Point(373, 41);
            this.cbCustomerName.Margin = new System.Windows.Forms.Padding(2, 5, 2, 5);
            this.cbCustomerName.Name = "cbCustomerName";
            this.cbCustomerName.Size = new System.Drawing.Size(221, 32);
            this.cbCustomerName.TabIndex = 2;
            // 
            // cbDriverName
            // 
            this.cbDriverName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbDriverName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbDriverName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbDriverName.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDriverName.ForeColor = System.Drawing.Color.Teal;
            this.cbDriverName.FormattingEnabled = true;
            this.cbDriverName.Location = new System.Drawing.Point(373, 82);
            this.cbDriverName.Margin = new System.Windows.Forms.Padding(2, 5, 2, 5);
            this.cbDriverName.Name = "cbDriverName";
            this.cbDriverName.Size = new System.Drawing.Size(221, 32);
            this.cbDriverName.TabIndex = 2;
            // 
            // cbCarType
            // 
            this.cbCarType.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbCarType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbCarType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbCarType.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCarType.ForeColor = System.Drawing.Color.Teal;
            this.cbCarType.FormattingEnabled = true;
            this.cbCarType.Location = new System.Drawing.Point(48, 82);
            this.cbCarType.Margin = new System.Windows.Forms.Padding(2, 5, 2, 5);
            this.cbCarType.Name = "cbCarType";
            this.cbCarType.Size = new System.Drawing.Size(158, 32);
            this.cbCarType.TabIndex = 2;
            // 
            // rbExport
            // 
            this.rbExport.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.rbExport.AutoSize = true;
            this.rbExport.Enabled = false;
            this.rbExport.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbExport.Location = new System.Drawing.Point(230, 221);
            this.rbExport.Margin = new System.Windows.Forms.Padding(2, 5, 2, 5);
            this.rbExport.Name = "rbExport";
            this.rbExport.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rbExport.Size = new System.Drawing.Size(64, 28);
            this.rbExport.TabIndex = 4;
            this.rbExport.Text = "صادر";
            this.rbExport.UseVisualStyleBackColor = true;
            this.rbExport.Visible = false;
            // 
            // rbImport
            // 
            this.rbImport.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.rbImport.AutoSize = true;
            this.rbImport.Enabled = false;
            this.rbImport.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbImport.Location = new System.Drawing.Point(213, 210);
            this.rbImport.Margin = new System.Windows.Forms.Padding(2, 5, 2, 5);
            this.rbImport.Name = "rbImport";
            this.rbImport.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rbImport.Size = new System.Drawing.Size(57, 28);
            this.rbImport.TabIndex = 4;
            this.rbImport.Text = "وارد";
            this.rbImport.UseVisualStyleBackColor = true;
            this.rbImport.Visible = false;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.SaddleBrown;
            this.label6.Location = new System.Drawing.Point(227, 128);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label6.Size = new System.Drawing.Size(70, 24);
            this.label6.TabIndex = 0;
            this.label6.Text = "ملاحظة :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label6.Click += new System.EventHandler(this.label2_Click);
            // 
            // tbNote
            // 
            this.tbNote.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tbNote.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNote.Location = new System.Drawing.Point(30, 128);
            this.tbNote.Margin = new System.Windows.Forms.Padding(2, 5, 2, 5);
            this.tbNote.Name = "tbNote";
            this.tbNote.Size = new System.Drawing.Size(191, 30);
            this.tbNote.TabIndex = 5;
            this.tbNote.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.SaddleBrown;
            this.label7.Location = new System.Drawing.Point(227, 30);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label7.Size = new System.Drawing.Size(98, 24);
            this.label7.TabIndex = 0;
            this.label7.Text = "رقم السيارة :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label7.Click += new System.EventHandler(this.label2_Click);
            // 
            // tbCarNumber
            // 
            this.tbCarNumber.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tbCarNumber.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCarNumber.Location = new System.Drawing.Point(30, 30);
            this.tbCarNumber.Margin = new System.Windows.Forms.Padding(2, 5, 2, 5);
            this.tbCarNumber.Name = "tbCarNumber";
            this.tbCarNumber.Size = new System.Drawing.Size(191, 30);
            this.tbCarNumber.TabIndex = 5;
            this.tbCarNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbCarNumber.TextChanged += new System.EventHandler(this.tbCarNumber_TextChanged);
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.SaddleBrown;
            this.label8.Location = new System.Drawing.Point(227, 79);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label8.Size = new System.Drawing.Size(109, 24);
            this.label8.TabIndex = 0;
            this.label8.Text = "رقم المقطورة :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label8.Click += new System.EventHandler(this.label2_Click);
            // 
            // tbGoodNumber
            // 
            this.tbGoodNumber.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tbGoodNumber.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbGoodNumber.Location = new System.Drawing.Point(30, 79);
            this.tbGoodNumber.Margin = new System.Windows.Forms.Padding(2, 5, 2, 5);
            this.tbGoodNumber.Name = "tbGoodNumber";
            this.tbGoodNumber.Size = new System.Drawing.Size(191, 30);
            this.tbGoodNumber.TabIndex = 5;
            this.tbGoodNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.groupBox1.Controls.Add(this.button5);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.cbProduct);
            this.groupBox1.Controls.Add(this.cbCustomerName);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.rbImport);
            this.groupBox1.Controls.Add(this.rbExport);
            this.groupBox1.Controls.Add(this.cbDriverName);
            this.groupBox1.Controls.Add(this.cbCarType);
            this.groupBox1.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.DarkGreen;
            this.groupBox1.Location = new System.Drawing.Point(213, 125);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 5, 2, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 5, 2, 5);
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(704, 142);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "بيانات العميل";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Location = new System.Drawing.Point(12, 80);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(34, 34);
            this.button5.TabIndex = 5;
            this.button5.Text = "+";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.Color.Teal;
            this.button4.Location = new System.Drawing.Point(337, 80);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(34, 34);
            this.button4.TabIndex = 5;
            this.button4.Text = "+";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.Teal;
            this.button3.Location = new System.Drawing.Point(338, 41);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(34, 34);
            this.button3.TabIndex = 5;
            this.button3.Text = "+";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(12, 41);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(34, 34);
            this.button2.TabIndex = 5;
            this.button2.Text = "+";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // cbProduct
            // 
            this.cbProduct.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbProduct.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbProduct.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbProduct.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbProduct.ForeColor = System.Drawing.Color.Teal;
            this.cbProduct.FormattingEnabled = true;
            this.cbProduct.Location = new System.Drawing.Point(48, 41);
            this.cbProduct.Margin = new System.Windows.Forms.Padding(2, 5, 2, 5);
            this.cbProduct.Name = "cbProduct";
            this.cbProduct.Size = new System.Drawing.Size(158, 32);
            this.cbProduct.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Teal;
            this.label4.Location = new System.Drawing.Point(210, 41);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label4.Size = new System.Drawing.Size(103, 24);
            this.label4.TabIndex = 0;
            this.label4.Text = "نوع الحمولة :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label12.BackColor = System.Drawing.Color.Black;
            this.label12.Font = new System.Drawing.Font("Arial", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Lime;
            this.label12.Location = new System.Drawing.Point(-2, 5);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label12.Size = new System.Drawing.Size(104, 63);
            this.label12.TabIndex = 0;
            this.label12.Text = "000";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label10.BackColor = System.Drawing.Color.Black;
            this.label10.Font = new System.Drawing.Font("Arial", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Lime;
            this.label10.Location = new System.Drawing.Point(100, 5);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label10.Size = new System.Drawing.Size(336, 63);
            this.label10.TabIndex = 0;
            this.label10.Text = "رقم التذكرة :";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.lblTime1);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.lblCarWeight1);
            this.groupBox2.Controls.Add(this.lblDate1);
            this.groupBox2.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.groupBox2.Location = new System.Drawing.Point(209, 282);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox2.Size = new System.Drawing.Size(316, 188);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "بيانات الوزن";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.Color.Purple;
            this.textBox1.Location = new System.Drawing.Point(32, 30);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(40, 25);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "كجم";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Purple;
            this.label11.Location = new System.Drawing.Point(215, 30);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label11.Size = new System.Drawing.Size(61, 24);
            this.label11.TabIndex = 0;
            this.label11.Text = "الوزن :";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label11.Click += new System.EventHandler(this.label2_Click);
            // 
            // label16
            // 
            this.label16.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.Purple;
            this.label16.Location = new System.Drawing.Point(215, 128);
            this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label16.Name = "label16";
            this.label16.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label16.Size = new System.Drawing.Size(67, 24);
            this.label16.TabIndex = 0;
            this.label16.Text = "التاريخ :";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label16.Click += new System.EventHandler(this.label2_Click);
            // 
            // lblTime1
            // 
            this.lblTime1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTime1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTime1.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime1.Location = new System.Drawing.Point(32, 79);
            this.lblTime1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTime1.Name = "lblTime1";
            this.lblTime1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblTime1.Size = new System.Drawing.Size(179, 30);
            this.lblTime1.TabIndex = 0;
            this.lblTime1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTime1.Click += new System.EventHandler(this.label2_Click);
            // 
            // label15
            // 
            this.label15.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Purple;
            this.label15.Location = new System.Drawing.Point(215, 79);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label15.Size = new System.Drawing.Size(60, 24);
            this.label15.TabIndex = 0;
            this.label15.Text = "الوقت :";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label15.Click += new System.EventHandler(this.label2_Click);
            // 
            // lblCarWeight1
            // 
            this.lblCarWeight1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCarWeight1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCarWeight1.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCarWeight1.Location = new System.Drawing.Point(77, 30);
            this.lblCarWeight1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCarWeight1.Name = "lblCarWeight1";
            this.lblCarWeight1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblCarWeight1.Size = new System.Drawing.Size(134, 30);
            this.lblCarWeight1.TabIndex = 0;
            this.lblCarWeight1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCarWeight1.Click += new System.EventHandler(this.label2_Click);
            // 
            // lblDate1
            // 
            this.lblDate1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDate1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDate1.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate1.Location = new System.Drawing.Point(32, 128);
            this.lblDate1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDate1.Name = "lblDate1";
            this.lblDate1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblDate1.Size = new System.Drawing.Size(179, 30);
            this.lblDate1.TabIndex = 0;
            this.lblDate1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblDate1.Click += new System.EventHandler(this.label2_Click);
            // 
            // btnRecordWeight
            // 
            this.btnRecordWeight.BackColor = System.Drawing.Color.Silver;
            this.btnRecordWeight.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRecordWeight.Location = new System.Drawing.Point(381, 75);
            this.btnRecordWeight.Name = "btnRecordWeight";
            this.btnRecordWeight.Size = new System.Drawing.Size(187, 42);
            this.btnRecordWeight.TabIndex = 1;
            this.btnRecordWeight.Text = "تسجيل الوزنة الاولى";
            this.btnRecordWeight.UseVisualStyleBackColor = false;
            this.btnRecordWeight.Click += new System.EventHandler(this.btnRecordWeight1_Click);
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(765, 80);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label9.Size = new System.Drawing.Size(134, 32);
            this.label9.TabIndex = 0;
            this.label9.Text = "قراءة الميزان";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label9.Visible = false;
            this.label9.Click += new System.EventHandler(this.label2_Click);
            // 
            // btnNewWeight
            // 
            this.btnNewWeight.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnNewWeight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnNewWeight.Enabled = false;
            this.btnNewWeight.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewWeight.Image = ((System.Drawing.Image)(resources.GetObject("btnNewWeight.Image")));
            this.btnNewWeight.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNewWeight.Location = new System.Drawing.Point(19, 324);
            this.btnNewWeight.Margin = new System.Windows.Forms.Padding(2);
            this.btnNewWeight.Name = "btnNewWeight";
            this.btnNewWeight.Size = new System.Drawing.Size(154, 60);
            this.btnNewWeight.TabIndex = 8;
            this.btnNewWeight.Text = "وزن جديد";
            this.btnNewWeight.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnNewWeight.UseVisualStyleBackColor = false;
            this.btnNewWeight.Click += new System.EventHandler(this.btnNewWeight_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnSave.Enabled = false;
            this.btnSave.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.Location = new System.Drawing.Point(19, 194);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(154, 60);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "حفظ";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnSecondWeight
            // 
            this.btnSecondWeight.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnSecondWeight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnSecondWeight.Enabled = false;
            this.btnSecondWeight.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSecondWeight.Image = ((System.Drawing.Image)(resources.GetObject("btnSecondWeight.Image")));
            this.btnSecondWeight.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSecondWeight.Location = new System.Drawing.Point(19, 393);
            this.btnSecondWeight.Margin = new System.Windows.Forms.Padding(2);
            this.btnSecondWeight.Name = "btnSecondWeight";
            this.btnSecondWeight.Size = new System.Drawing.Size(154, 60);
            this.btnSecondWeight.TabIndex = 8;
            this.btnSecondWeight.Text = "الوزنة الثانية";
            this.btnSecondWeight.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnSecondWeight.UseVisualStyleBackColor = false;
            this.btnSecondWeight.Click += new System.EventHandler(this.btnSecondWeight_Click);
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button1.BackColor = System.Drawing.Color.Maroon;
            this.button1.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(19, 125);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(154, 60);
            this.button1.TabIndex = 8;
            this.button1.Text = " الرئيسية";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.groupBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.groupBox3.Controls.Add(this.tbCarNumber);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.tbGoodNumber);
            this.groupBox3.Controls.Add(this.tbNote);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.Color.Maroon;
            this.groupBox3.Location = new System.Drawing.Point(546, 281);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox3.Size = new System.Drawing.Size(371, 189);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "بيانات السيارة";
            // 
            // lblWeightReading
            // 
            this.lblWeightReading.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblWeightReading.BackColor = System.Drawing.Color.Black;
            this.lblWeightReading.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lblWeightReading.Font = new System.Drawing.Font("Arial", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWeightReading.ForeColor = System.Drawing.Color.Lime;
            this.lblWeightReading.Location = new System.Drawing.Point(636, 5);
            this.lblWeightReading.Multiline = true;
            this.lblWeightReading.Name = "lblWeightReading";
            this.lblWeightReading.Size = new System.Drawing.Size(314, 63);
            this.lblWeightReading.TabIndex = 18;
            this.lblWeightReading.Text = "00000";
            this.lblWeightReading.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.lblWeightReading.TextChanged += new System.EventHandler(this.lblWeightReading_TextChanged);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.BackColor = System.Drawing.Color.Black;
            this.label5.Font = new System.Drawing.Font("Arial", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(301, 5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(346, 63);
            this.label5.TabIndex = 19;
            this.label5.Text = "الوزنة الاولى";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // first_weight
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(5F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(948, 501);
            this.Controls.Add(this.btnRecordWeight);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblWeightReading);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.btnSecondWeight);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnNewWeight);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(2, 5, 2, 5);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(720, 440);
            this.Name = "first_weight";
            this.Padding = new System.Windows.Forms.Padding(17, 85, 17, 28);
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.AeroShadow;
            this.Style = MetroFramework.MetroColorStyle.Purple;
            this.TextAlign = MetroFramework.Forms.MetroFormTextAlign.Center;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.first_weight_FormClosing);
            this.Load += new System.EventHandler(this.first_weight_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbCustomerName;
        private System.Windows.Forms.ComboBox cbDriverName;
        private System.Windows.Forms.ComboBox cbCarType;
        private System.Windows.Forms.RadioButton rbExport;
        private System.Windows.Forms.RadioButton rbImport;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbNote;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbCarNumber;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbGoodNumber;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblTime1;
        private System.Windows.Forms.Label lblCarWeight1;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnNewWeight;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnSecondWeight;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label lblDate1;
        private System.Windows.Forms.ComboBox cbProduct;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox lblWeightReading;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnRecordWeight;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}