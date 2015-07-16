namespace КантВиноНастройка
{
    partial class ConfigForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigForm));
            this.cmbPort = new System.Windows.Forms.ComboBox();
            this.cmbBaudRate = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtDeviceAddr = new System.Windows.Forms.TextBox();
            this.txtNewAddr = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnNewAddr = new System.Windows.Forms.Button();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.timer900ms = new System.Windows.Forms.Timer(this.components);
            this.lblT1 = new System.Windows.Forms.Label();
            this.lblT2 = new System.Windows.Forms.Label();
            this.lblD1 = new System.Windows.Forms.Label();
            this.lblD2 = new System.Windows.Forms.Label();
            this.chbIsGetData = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbPort
            // 
            this.cmbPort.FormattingEnabled = true;
            this.cmbPort.Location = new System.Drawing.Point(73, 19);
            this.cmbPort.Name = "cmbPort";
            this.cmbPort.Size = new System.Drawing.Size(64, 21);
            this.cmbPort.TabIndex = 0;
            this.cmbPort.SelectedIndexChanged += new System.EventHandler(this.cmbPort_SelectedIndexChanged);
            // 
            // cmbBaudRate
            // 
            this.cmbBaudRate.FormattingEnabled = true;
            this.cmbBaudRate.Location = new System.Drawing.Point(73, 46);
            this.cmbBaudRate.Name = "cmbBaudRate";
            this.cmbBaudRate.Size = new System.Drawing.Size(64, 21);
            this.cmbBaudRate.TabIndex = 1;
            this.cmbBaudRate.SelectedIndexChanged += new System.EventHandler(this.cmbPort_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmbPort);
            this.groupBox1.Controls.Add(this.cmbBaudRate);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(145, 77);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Порт";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Порт";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Скорость";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnNewAddr);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtNewAddr);
            this.groupBox2.Controls.Add(this.txtDeviceAddr);
            this.groupBox2.Location = new System.Drawing.Point(163, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(145, 79);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Адрес устройства";
            // 
            // txtDeviceAddr
            // 
            this.txtDeviceAddr.Location = new System.Drawing.Point(85, 19);
            this.txtDeviceAddr.Name = "txtDeviceAddr";
            this.txtDeviceAddr.Size = new System.Drawing.Size(52, 20);
            this.txtDeviceAddr.TabIndex = 0;
            this.txtDeviceAddr.TextChanged += new System.EventHandler(this.txtDeviceAddr_TextChanged);
            // 
            // txtNewAddr
            // 
            this.txtNewAddr.Location = new System.Drawing.Point(85, 45);
            this.txtNewAddr.Name = "txtNewAddr";
            this.txtNewAddr.Size = new System.Drawing.Size(52, 20);
            this.txtNewAddr.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Адрес";
            // 
            // btnNewAddr
            // 
            this.btnNewAddr.Location = new System.Drawing.Point(9, 43);
            this.btnNewAddr.Name = "btnNewAddr";
            this.btnNewAddr.Size = new System.Drawing.Size(66, 23);
            this.btnNewAddr.TabIndex = 3;
            this.btnNewAddr.Text = "Сменить";
            this.btnNewAddr.UseVisualStyleBackColor = true;
            this.btnNewAddr.Click += new System.EventHandler(this.btnNewAddr_Click);
            // 
            // txtLog
            // 
            this.txtLog.Location = new System.Drawing.Point(6, 19);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.Size = new System.Drawing.Size(282, 296);
            this.txtLog.TabIndex = 4;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtLog);
            this.groupBox3.Location = new System.Drawing.Point(12, 97);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(296, 321);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Лог";
            // 
            // timer900ms
            // 
            this.timer900ms.Enabled = true;
            this.timer900ms.Interval = 50;
            this.timer900ms.Tick += new System.EventHandler(this.timer900ms_Tick);
            // 
            // lblT1
            // 
            this.lblT1.AutoSize = true;
            this.lblT1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblT1.Location = new System.Drawing.Point(336, 31);
            this.lblT1.Name = "lblT1";
            this.lblT1.Size = new System.Drawing.Size(53, 20);
            this.lblT1.TabIndex = 6;
            this.lblT1.Text = "label4";
            // 
            // lblT2
            // 
            this.lblT2.AutoSize = true;
            this.lblT2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblT2.Location = new System.Drawing.Point(336, 58);
            this.lblT2.Name = "lblT2";
            this.lblT2.Size = new System.Drawing.Size(53, 20);
            this.lblT2.TabIndex = 7;
            this.lblT2.Text = "label5";
            // 
            // lblD1
            // 
            this.lblD1.AutoSize = true;
            this.lblD1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblD1.Location = new System.Drawing.Point(354, 87);
            this.lblD1.Name = "lblD1";
            this.lblD1.Size = new System.Drawing.Size(53, 20);
            this.lblD1.TabIndex = 8;
            this.lblD1.Text = "label6";
            // 
            // lblD2
            // 
            this.lblD2.AutoSize = true;
            this.lblD2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblD2.Location = new System.Drawing.Point(354, 116);
            this.lblD2.Name = "lblD2";
            this.lblD2.Size = new System.Drawing.Size(53, 20);
            this.lblD2.TabIndex = 9;
            this.lblD2.Text = "label7";
            // 
            // chbIsGetData
            // 
            this.chbIsGetData.AutoSize = true;
            this.chbIsGetData.Location = new System.Drawing.Point(357, 186);
            this.chbIsGetData.Name = "chbIsGetData";
            this.chbIsGetData.Size = new System.Drawing.Size(121, 17);
            this.chbIsGetData.TabIndex = 10;
            this.chbIsGetData.Text = "Считывать данные";
            this.chbIsGetData.UseVisualStyleBackColor = true;
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 430);
            this.Controls.Add(this.chbIsGetData);
            this.Controls.Add(this.lblD2);
            this.Controls.Add(this.lblD1);
            this.Controls.Add(this.lblT2);
            this.Controls.Add(this.lblT1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ConfigForm";
            this.Text = "Настройка";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ConfigForm_FormClosing);
            this.Load += new System.EventHandler(this.ConfigForm_Load);
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

        private System.Windows.Forms.ComboBox cmbPort;
        private System.Windows.Forms.ComboBox cmbBaudRate;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnNewAddr;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNewAddr;
        private System.Windows.Forms.TextBox txtDeviceAddr;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Timer timer900ms;
        private System.Windows.Forms.Label lblT1;
        private System.Windows.Forms.Label lblT2;
        private System.Windows.Forms.Label lblD1;
        private System.Windows.Forms.Label lblD2;
        private System.Windows.Forms.CheckBox chbIsGetData;
    }
}

