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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigForm));
            this.cmbPort = new System.Windows.Forms.ComboBox();
            this.cmbBaudRate = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblPortStatus = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblDataBaseStatus = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.prgBackup = new System.Windows.Forms.ProgressBar();
            this.btnStartBackup = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.txtBackupPath = new System.Windows.Forms.TextBox();
            this.btnBackupPath = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.txtDbPath = new System.Windows.Forms.TextBox();
            this.btnDbPath = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvCoefItem = new System.Windows.Forms.DataGridView();
            this.Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isEnable = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.coeffPressure = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coeffLevel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTimeSaveCache = new KantVinoV2.CustomTextBox();
            this.txtTimeSaveBackup = new KantVinoV2.CustomTextBox();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCoefItem)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbPort
            // 
            this.cmbPort.FormattingEnabled = true;
            this.cmbPort.Location = new System.Drawing.Point(144, 16);
            this.cmbPort.Name = "cmbPort";
            this.cmbPort.Size = new System.Drawing.Size(119, 21);
            this.cmbPort.TabIndex = 0;
            this.cmbPort.DropDown += new System.EventHandler(this.cmbPort_DropDown);
            this.cmbPort.SelectedIndexChanged += new System.EventHandler(this.cmbPort_SelectedIndexChanged);
            // 
            // cmbBaudRate
            // 
            this.cmbBaudRate.FormattingEnabled = true;
            this.cmbBaudRate.Location = new System.Drawing.Point(144, 43);
            this.cmbBaudRate.Name = "cmbBaudRate";
            this.cmbBaudRate.Size = new System.Drawing.Size(119, 21);
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
            this.lblPortStatus.Location = new System.Drawing.Point(141, 72);
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
            this.groupBox1.Location = new System.Drawing.Point(8, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(269, 96);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Порт";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(124, 300);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 12;
            this.btnOK.Text = "ОК";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(205, 300);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(404, 486);
            this.tabControl1.TabIndex = 16;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.groupBox4);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.btnCancel);
            this.tabPage1.Controls.Add(this.btnOK);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(396, 460);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Порт и БД";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtTimeSaveBackup);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.txtTimeSaveCache);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.lblDataBaseStatus);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.prgBackup);
            this.groupBox4.Controls.Add(this.btnStartBackup);
            this.groupBox4.Controls.Add(this.label17);
            this.groupBox4.Controls.Add(this.txtBackupPath);
            this.groupBox4.Controls.Add(this.btnBackupPath);
            this.groupBox4.Controls.Add(this.label16);
            this.groupBox4.Controls.Add(this.txtDbPath);
            this.groupBox4.Controls.Add(this.btnDbPath);
            this.groupBox4.Controls.Add(this.label15);
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Location = new System.Drawing.Point(8, 108);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(269, 177);
            this.groupBox4.TabIndex = 14;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "БД";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(233, 100);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(28, 13);
            this.label13.TabIndex = 16;
            this.label13.Text = "сек.";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(233, 48);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(28, 13);
            this.label12.TabIndex = 15;
            this.label12.Text = "сек.";
            // 
            // lblDataBaseStatus
            // 
            this.lblDataBaseStatus.AutoSize = true;
            this.lblDataBaseStatus.Location = new System.Drawing.Point(141, 156);
            this.lblDataBaseStatus.Name = "lblDataBaseStatus";
            this.lblDataBaseStatus.Size = new System.Drawing.Size(35, 13);
            this.lblDataBaseStatus.TabIndex = 14;
            this.lblDataBaseStatus.Text = "label4";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 156);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Статус";
            // 
            // prgBackup
            // 
            this.prgBackup.Location = new System.Drawing.Point(95, 122);
            this.prgBackup.Name = "prgBackup";
            this.prgBackup.Size = new System.Drawing.Size(168, 23);
            this.prgBackup.TabIndex = 12;
            // 
            // btnStartBackup
            // 
            this.btnStartBackup.Location = new System.Drawing.Point(6, 122);
            this.btnStartBackup.Name = "btnStartBackup";
            this.btnStartBackup.Size = new System.Drawing.Size(75, 23);
            this.btnStartBackup.TabIndex = 11;
            this.btnStartBackup.Text = "Бэкап";
            this.btnStartBackup.UseVisualStyleBackColor = true;
            this.btnStartBackup.Click += new System.EventHandler(this.btnStartBackup_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(6, 100);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(79, 13);
            this.label17.TabIndex = 10;
            this.label17.Text = "Время бэкапа";
            // 
            // txtBackupPath
            // 
            this.txtBackupPath.Location = new System.Drawing.Point(95, 71);
            this.txtBackupPath.Name = "txtBackupPath";
            this.txtBackupPath.ReadOnly = true;
            this.txtBackupPath.Size = new System.Drawing.Size(132, 20);
            this.txtBackupPath.TabIndex = 8;
            // 
            // btnBackupPath
            // 
            this.btnBackupPath.Location = new System.Drawing.Point(233, 69);
            this.btnBackupPath.Name = "btnBackupPath";
            this.btnBackupPath.Size = new System.Drawing.Size(30, 23);
            this.btnBackupPath.TabIndex = 7;
            this.btnBackupPath.Text = "...";
            this.btnBackupPath.UseVisualStyleBackColor = true;
            this.btnBackupPath.Click += new System.EventHandler(this.btnBackupPath_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(6, 74);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(70, 13);
            this.label16.TabIndex = 6;
            this.label16.Text = "Путь бэкапа";
            // 
            // txtDbPath
            // 
            this.txtDbPath.Location = new System.Drawing.Point(95, 19);
            this.txtDbPath.Name = "txtDbPath";
            this.txtDbPath.ReadOnly = true;
            this.txtDbPath.Size = new System.Drawing.Size(132, 20);
            this.txtDbPath.TabIndex = 4;
            // 
            // btnDbPath
            // 
            this.btnDbPath.Location = new System.Drawing.Point(233, 17);
            this.btnDbPath.Name = "btnDbPath";
            this.btnDbPath.Size = new System.Drawing.Size(30, 23);
            this.btnDbPath.TabIndex = 3;
            this.btnDbPath.Text = "...";
            this.btnDbPath.UseVisualStyleBackColor = true;
            this.btnDbPath.Click += new System.EventHandler(this.btnDbPath_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 48);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(69, 13);
            this.label15.TabIndex = 1;
            this.label15.Text = "Время кэша";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 22);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(50, 13);
            this.label14.TabIndex = 0;
            this.label14.Text = "Путь БД";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Controls.Add(this.dgvCoefItem);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(396, 460);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Калибровка и отключение";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(8, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(384, 39);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "???";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(189, 13);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(100, 20);
            this.textBox5.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(144, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Интервал опроса датчиков";
            // 
            // dgvCoefItem
            // 
            this.dgvCoefItem.AllowUserToAddRows = false;
            this.dgvCoefItem.AllowUserToDeleteRows = false;
            this.dgvCoefItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCoefItem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Number,
            this.isEnable,
            this.coeffPressure,
            this.coeffLevel});
            this.dgvCoefItem.Location = new System.Drawing.Point(8, 51);
            this.dgvCoefItem.Name = "dgvCoefItem";
            this.dgvCoefItem.RowHeadersVisible = false;
            this.dgvCoefItem.Size = new System.Drawing.Size(384, 372);
            this.dgvCoefItem.TabIndex = 16;
            // 
            // Number
            // 
            this.Number.HeaderText = "N";
            this.Number.Name = "Number";
            this.Number.ReadOnly = true;
            this.Number.Width = 40;
            // 
            // isEnable
            // 
            this.isEnable.HeaderText = "Опрашивать";
            this.isEnable.Name = "isEnable";
            this.isEnable.Width = 80;
            // 
            // coeffPressure
            // 
            this.coeffPressure.HeaderText = "Коэф. давления";
            this.coeffPressure.Name = "coeffPressure";
            this.coeffPressure.Width = 120;
            // 
            // coeffLevel
            // 
            this.coeffLevel.HeaderText = "Коэф. уровня";
            this.coeffLevel.Name = "coeffLevel";
            this.coeffLevel.Width = 120;
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage3.Controls.Add(this.label11);
            this.tabPage3.Controls.Add(this.label10);
            this.tabPage3.Controls.Add(this.label9);
            this.tabPage3.Controls.Add(this.label8);
            this.tabPage3.Controls.Add(this.label7);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(396, 460);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Интерфейс";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(31, 83);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(128, 13);
            this.label11.TabIndex = 4;
            this.label11.Text = "Интервал постзагрузки";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(31, 70);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(123, 13);
            this.label10.TabIndex = 3;
            this.label10.Text = "Интервал презагрузки";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(31, 57);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(126, 13);
            this.label9.TabIndex = 2;
            this.label9.Text = "Интервал отображения";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(31, 44);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(203, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "Время возобновления после загрузки";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(31, 31);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(188, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Время возобновления после паузы";
            // 
            // txtTimeSaveCache
            // 
            this.txtTimeSaveCache.Location = new System.Drawing.Point(144, 45);
            this.txtTimeSaveCache.Name = "txtTimeSaveCache";
            this.txtTimeSaveCache.Size = new System.Drawing.Size(83, 20);
            this.txtTimeSaveCache.TabIndex = 15;
            this.txtTimeSaveCache.TextEndEdit += new System.EventHandler(this.txtTimeSaveCache_TextEndEdit);
            // 
            // txtTimeSaveBackup
            // 
            this.txtTimeSaveBackup.Location = new System.Drawing.Point(144, 97);
            this.txtTimeSaveBackup.Name = "txtTimeSaveBackup";
            this.txtTimeSaveBackup.Size = new System.Drawing.Size(83, 20);
            this.txtTimeSaveBackup.TabIndex = 16;
            this.txtTimeSaveBackup.TextChanged += new System.EventHandler(this.txtTimeSaveBackup_TextChanged);
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 486);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ConfigForm";
            this.Text = "ConfigForm";
            this.Load += new System.EventHandler(this.ConfigForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCoefItem)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
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
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtBackupPath;
        private System.Windows.Forms.Button btnBackupPath;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtDbPath;
        private System.Windows.Forms.Button btnDbPath;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ProgressBar prgBackup;
        private System.Windows.Forms.Button btnStartBackup;
        private System.Windows.Forms.DataGridView dgvCoefItem;
        private System.Windows.Forms.Label lblDataBaseStatus;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Number;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isEnable;
        private System.Windows.Forms.DataGridViewTextBoxColumn coeffPressure;
        private System.Windows.Forms.DataGridViewTextBoxColumn coeffLevel;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private CustomTextBox txtTimeSaveBackup;
        private CustomTextBox txtTimeSaveCache;
    }
}