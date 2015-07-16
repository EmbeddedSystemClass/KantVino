namespace KantVinoV2
{
    partial class ConfigForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigForm));
            this.cmbPort = new System.Windows.Forms.ComboBox();
            this.cmbBaudRate = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblPortStatus = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkWhoScan = new System.Windows.Forms.CheckedListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.nmrInterval = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblTestStatus = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.btnSetLevel = new System.Windows.Forms.Button();
            this.btnSetPressure = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtLevelMul = new System.Windows.Forms.TextBox();
            this.txtPressureMul = new System.Windows.Forms.TextBox();
            this.txtLevelRaw = new System.Windows.Forms.TextBox();
            this.txtPressureRaw = new System.Windows.Forms.TextBox();
            this.txtLevel = new System.Windows.Forms.TextBox();
            this.txtPressure = new System.Windows.Forms.TextBox();
            this.txtTemper2 = new System.Windows.Forms.TextBox();
            this.txtTemper1 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNumberDevice = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmrInterval)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbPort
            // 
            this.cmbPort.FormattingEnabled = true;
            this.cmbPort.Location = new System.Drawing.Point(93, 16);
            this.cmbPort.Name = "cmbPort";
            this.cmbPort.Size = new System.Drawing.Size(83, 21);
            this.cmbPort.TabIndex = 0;
            this.cmbPort.SelectedIndexChanged += new System.EventHandler(this.cmbPort_SelectedIndexChanged);
            // 
            // cmbBaudRate
            // 
            this.cmbBaudRate.FormattingEnabled = true;
            this.cmbBaudRate.Location = new System.Drawing.Point(93, 43);
            this.cmbBaudRate.Name = "cmbBaudRate";
            this.cmbBaudRate.Size = new System.Drawing.Size(83, 21);
            this.cmbBaudRate.TabIndex = 1;
            this.cmbBaudRate.SelectedIndexChanged += new System.EventHandler(this.cmbPort_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Порт";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Скорость";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Статус";
            // 
            // lblPortStatus
            // 
            this.lblPortStatus.AutoSize = true;
            this.lblPortStatus.Location = new System.Drawing.Point(64, 72);
            this.lblPortStatus.Name = "lblPortStatus";
            this.lblPortStatus.Size = new System.Drawing.Size(35, 13);
            this.lblPortStatus.TabIndex = 5;
            this.lblPortStatus.Text = "label4";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lblPortStatus);
            this.groupBox1.Controls.Add(this.cmbPort);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cmbBaudRate);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(184, 96);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Порт";
            // 
            // chkWhoScan
            // 
            this.chkWhoScan.FormattingEnabled = true;
            this.chkWhoScan.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20"});
            this.chkWhoScan.Location = new System.Drawing.Point(97, 16);
            this.chkWhoScan.Name = "chkWhoScan";
            this.chkWhoScan.Size = new System.Drawing.Size(48, 334);
            this.chkWhoScan.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(6, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 40);
            this.label4.TabIndex = 9;
            this.label4.Text = "Интервал сканирования сек";
            // 
            // nmrInterval
            // 
            this.nmrInterval.Location = new System.Drawing.Point(25, 89);
            this.nmrInterval.Name = "nmrInterval";
            this.nmrInterval.Size = new System.Drawing.Size(48, 20);
            this.nmrInterval.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(65, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Что";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(407, 377);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 12;
            this.btnOK.Text = "ОК";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(488, 377);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblTestStatus);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.textBox10);
            this.groupBox2.Controls.Add(this.btnSetLevel);
            this.groupBox2.Controls.Add(this.btnSetPressure);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.txtLevelMul);
            this.groupBox2.Controls.Add(this.txtPressureMul);
            this.groupBox2.Controls.Add(this.txtLevelRaw);
            this.groupBox2.Controls.Add(this.txtPressureRaw);
            this.groupBox2.Controls.Add(this.txtLevel);
            this.groupBox2.Controls.Add(this.txtPressure);
            this.groupBox2.Controls.Add(this.txtTemper2);
            this.groupBox2.Controls.Add(this.txtTemper1);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtNumberDevice);
            this.groupBox2.Location = new System.Drawing.Point(12, 114);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(389, 177);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Диагностика";
            // 
            // lblTestStatus
            // 
            this.lblTestStatus.AutoSize = true;
            this.lblTestStatus.Location = new System.Drawing.Point(110, 155);
            this.lblTestStatus.Name = "lblTestStatus";
            this.lblTestStatus.Size = new System.Drawing.Size(41, 13);
            this.lblTestStatus.TabIndex = 21;
            this.lblTestStatus.Text = "label14";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 155);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(41, 13);
            this.label13.TabIndex = 20;
            this.label13.Text = "Статус";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(320, 17);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(63, 23);
            this.button3.TabIndex = 19;
            this.button3.Text = "Сменить";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // textBox10
            // 
            this.textBox10.Location = new System.Drawing.Point(251, 19);
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(63, 20);
            this.textBox10.TabIndex = 18;
            // 
            // btnSetLevel
            // 
            this.btnSetLevel.Location = new System.Drawing.Point(320, 124);
            this.btnSetLevel.Name = "btnSetLevel";
            this.btnSetLevel.Size = new System.Drawing.Size(63, 23);
            this.btnSetLevel.TabIndex = 17;
            this.btnSetLevel.Text = "Задать";
            this.btnSetLevel.UseVisualStyleBackColor = true;
            // 
            // btnSetPressure
            // 
            this.btnSetPressure.Location = new System.Drawing.Point(320, 98);
            this.btnSetPressure.Name = "btnSetPressure";
            this.btnSetPressure.Size = new System.Drawing.Size(63, 23);
            this.btnSetPressure.TabIndex = 16;
            this.btnSetPressure.Text = "Задать";
            this.btnSetPressure.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(250, 77);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 13);
            this.label12.TabIndex = 15;
            this.label12.Text = "Множитель";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(197, 77);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 13);
            this.label11.TabIndex = 14;
            this.label11.Text = "Raw";
            // 
            // txtLevelMul
            // 
            this.txtLevelMul.Location = new System.Drawing.Point(251, 126);
            this.txtLevelMul.Name = "txtLevelMul";
            this.txtLevelMul.Size = new System.Drawing.Size(63, 20);
            this.txtLevelMul.TabIndex = 13;
            // 
            // txtPressureMul
            // 
            this.txtPressureMul.Location = new System.Drawing.Point(252, 100);
            this.txtPressureMul.Name = "txtPressureMul";
            this.txtPressureMul.Size = new System.Drawing.Size(63, 20);
            this.txtPressureMul.TabIndex = 12;
            // 
            // txtLevelRaw
            // 
            this.txtLevelRaw.Location = new System.Drawing.Point(182, 126);
            this.txtLevelRaw.Name = "txtLevelRaw";
            this.txtLevelRaw.Size = new System.Drawing.Size(63, 20);
            this.txtLevelRaw.TabIndex = 11;
            // 
            // txtPressureRaw
            // 
            this.txtPressureRaw.Location = new System.Drawing.Point(182, 100);
            this.txtPressureRaw.Name = "txtPressureRaw";
            this.txtPressureRaw.Size = new System.Drawing.Size(63, 20);
            this.txtPressureRaw.TabIndex = 10;
            // 
            // txtLevel
            // 
            this.txtLevel.Location = new System.Drawing.Point(113, 126);
            this.txtLevel.Name = "txtLevel";
            this.txtLevel.Size = new System.Drawing.Size(63, 20);
            this.txtLevel.TabIndex = 9;
            // 
            // txtPressure
            // 
            this.txtPressure.Location = new System.Drawing.Point(113, 100);
            this.txtPressure.Name = "txtPressure";
            this.txtPressure.Size = new System.Drawing.Size(63, 20);
            this.txtPressure.TabIndex = 8;
            // 
            // txtTemper2
            // 
            this.txtTemper2.Location = new System.Drawing.Point(113, 74);
            this.txtTemper2.Name = "txtTemper2";
            this.txtTemper2.Size = new System.Drawing.Size(63, 20);
            this.txtTemper2.TabIndex = 7;
            // 
            // txtTemper1
            // 
            this.txtTemper1.Location = new System.Drawing.Point(113, 48);
            this.txtTemper1.Name = "txtTemper1";
            this.txtTemper1.Size = new System.Drawing.Size(63, 20);
            this.txtTemper1.TabIndex = 6;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 129);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(45, 13);
            this.label10.TabIndex = 5;
            this.label10.Text = "Высота";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 103);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 13);
            this.label9.TabIndex = 4;
            this.label9.Text = "Давление";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 77);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(83, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "Температура 2";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 51);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Температура 1";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Номер устройства";
            // 
            // txtNumberDevice
            // 
            this.txtNumberDevice.Location = new System.Drawing.Point(113, 19);
            this.txtNumberDevice.Name = "txtNumberDevice";
            this.txtNumberDevice.Size = new System.Drawing.Size(63, 20);
            this.txtNumberDevice.TabIndex = 0;
            this.txtNumberDevice.TextChanged += new System.EventHandler(this.txtNumberDevice_TextChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chkWhoScan);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.nmrInterval);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Location = new System.Drawing.Point(412, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(151, 359);
            this.groupBox3.TabIndex = 15;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Сканировать";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 407);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ConfigForm";
            this.Text = "ConfigForm";
            this.Load += new System.EventHandler(this.ConfigForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmrInterval)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbPort;
        private System.Windows.Forms.ComboBox cmbBaudRate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblPortStatus;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckedListBox chkWhoScan;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nmrInterval;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblTestStatus;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.Button btnSetLevel;
        private System.Windows.Forms.Button btnSetPressure;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtLevelMul;
        private System.Windows.Forms.TextBox txtPressureMul;
        private System.Windows.Forms.TextBox txtLevelRaw;
        private System.Windows.Forms.TextBox txtPressureRaw;
        private System.Windows.Forms.TextBox txtLevel;
        private System.Windows.Forms.TextBox txtPressure;
        private System.Windows.Forms.TextBox txtTemper2;
        private System.Windows.Forms.TextBox txtTemper1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtNumberDevice;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Timer timer1;
    }
}