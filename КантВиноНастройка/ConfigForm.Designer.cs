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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnFindAddr = new System.Windows.Forms.Button();
            this.btnNewAddr = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNewAddr = new System.Windows.Forms.TextBox();
            this.txtDeviceAddr = new System.Windows.Forms.TextBox();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.timerGetData = new System.Windows.Forms.Timer(this.components);
            this.lblT1 = new System.Windows.Forms.Label();
            this.lblT2 = new System.Windows.Forms.Label();
            this.lblD1 = new System.Windows.Forms.Label();
            this.lblD2 = new System.Windows.Forms.Label();
            this.chbIsGetData = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtGetErrorTime = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.chbIsGetError = new System.Windows.Forms.CheckBox();
            this.txtGetDataTime = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.zGraph = new ZedGraph.ZedGraphControl();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.timerGetError = new System.Windows.Forms.Timer(this.components);
            this.lblTransferError = new System.Windows.Forms.Label();
            this.chbIsVisiblePacket = new System.Windows.Forms.CheckBox();
            this.lblBadPacket = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Скорость";
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
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnFindAddr);
            this.groupBox2.Controls.Add(this.btnNewAddr);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtNewAddr);
            this.groupBox2.Controls.Add(this.txtDeviceAddr);
            this.groupBox2.Location = new System.Drawing.Point(163, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(217, 77);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Адрес устройства";
            // 
            // btnFindAddr
            // 
            this.btnFindAddr.Location = new System.Drawing.Point(143, 17);
            this.btnFindAddr.Name = "btnFindAddr";
            this.btnFindAddr.Size = new System.Drawing.Size(66, 23);
            this.btnFindAddr.TabIndex = 4;
            this.btnFindAddr.Text = "Найти";
            this.btnFindAddr.UseVisualStyleBackColor = true;
            this.btnFindAddr.Click += new System.EventHandler(this.btnFindAddr_Click);
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Адрес";
            // 
            // txtNewAddr
            // 
            this.txtNewAddr.Location = new System.Drawing.Point(85, 45);
            this.txtNewAddr.Name = "txtNewAddr";
            this.txtNewAddr.Size = new System.Drawing.Size(52, 20);
            this.txtNewAddr.TabIndex = 1;
            // 
            // txtDeviceAddr
            // 
            this.txtDeviceAddr.Location = new System.Drawing.Point(85, 19);
            this.txtDeviceAddr.Name = "txtDeviceAddr";
            this.txtDeviceAddr.Size = new System.Drawing.Size(52, 20);
            this.txtDeviceAddr.TabIndex = 0;
            this.txtDeviceAddr.TextChanged += new System.EventHandler(this.txtDeviceAddr_TextChanged);
            // 
            // txtLog
            // 
            this.txtLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLog.Location = new System.Drawing.Point(6, 72);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(214, 196);
            this.txtLog.TabIndex = 4;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox3.Controls.Add(this.lblBadPacket);
            this.groupBox3.Controls.Add(this.chbIsVisiblePacket);
            this.groupBox3.Controls.Add(this.lblTransferError);
            this.groupBox3.Controls.Add(this.txtLog);
            this.groupBox3.Location = new System.Drawing.Point(12, 94);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(226, 275);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Лог";
            // 
            // timerGetData
            // 
            this.timerGetData.Enabled = true;
            this.timerGetData.Interval = 500;
            this.timerGetData.Tick += new System.EventHandler(this.timerGetData_Tick);
            // 
            // lblT1
            // 
            this.lblT1.AutoSize = true;
            this.lblT1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblT1.Location = new System.Drawing.Point(914, 12);
            this.lblT1.Name = "lblT1";
            this.lblT1.Size = new System.Drawing.Size(53, 20);
            this.lblT1.TabIndex = 6;
            this.lblT1.Text = "label4";
            // 
            // lblT2
            // 
            this.lblT2.AutoSize = true;
            this.lblT2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblT2.Location = new System.Drawing.Point(914, 32);
            this.lblT2.Name = "lblT2";
            this.lblT2.Size = new System.Drawing.Size(53, 20);
            this.lblT2.TabIndex = 7;
            this.lblT2.Text = "label5";
            // 
            // lblD1
            // 
            this.lblD1.AutoSize = true;
            this.lblD1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblD1.Location = new System.Drawing.Point(914, 52);
            this.lblD1.Name = "lblD1";
            this.lblD1.Size = new System.Drawing.Size(53, 20);
            this.lblD1.TabIndex = 8;
            this.lblD1.Text = "label6";
            // 
            // lblD2
            // 
            this.lblD2.AutoSize = true;
            this.lblD2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblD2.Location = new System.Drawing.Point(914, 72);
            this.lblD2.Name = "lblD2";
            this.lblD2.Size = new System.Drawing.Size(53, 20);
            this.lblD2.TabIndex = 9;
            this.lblD2.Text = "label7";
            // 
            // chbIsGetData
            // 
            this.chbIsGetData.AutoSize = true;
            this.chbIsGetData.Location = new System.Drawing.Point(6, 21);
            this.chbIsGetData.Name = "chbIsGetData";
            this.chbIsGetData.Size = new System.Drawing.Size(104, 17);
            this.chbIsGetData.TabIndex = 10;
            this.chbIsGetData.Text = "Чтение данные";
            this.chbIsGetData.UseVisualStyleBackColor = true;
            this.chbIsGetData.CheckedChanged += new System.EventHandler(this.chbIsGetData_CheckedChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtGetErrorTime);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.chbIsGetError);
            this.groupBox4.Controls.Add(this.txtGetDataTime);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.chbIsGetData);
            this.groupBox4.Location = new System.Drawing.Point(386, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(272, 77);
            this.groupBox4.TabIndex = 11;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Опрос";
            // 
            // txtGetErrorTime
            // 
            this.txtGetErrorTime.Location = new System.Drawing.Point(212, 47);
            this.txtGetErrorTime.Name = "txtGetErrorTime";
            this.txtGetErrorTime.Size = new System.Drawing.Size(52, 20);
            this.txtGetErrorTime.TabIndex = 15;
            this.txtGetErrorTime.TextChanged += new System.EventHandler(this.txtGetErrorTime_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(133, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Интервал мс";
            // 
            // chbIsGetError
            // 
            this.chbIsGetError.AutoSize = true;
            this.chbIsGetError.Location = new System.Drawing.Point(6, 49);
            this.chbIsGetError.Name = "chbIsGetError";
            this.chbIsGetError.Size = new System.Drawing.Size(104, 17);
            this.chbIsGetError.TabIndex = 13;
            this.chbIsGetError.Text = "Чтение ошибок";
            this.chbIsGetError.UseVisualStyleBackColor = true;
            this.chbIsGetError.CheckedChanged += new System.EventHandler(this.chbIsGetData_CheckedChanged);
            // 
            // txtGetDataTime
            // 
            this.txtGetDataTime.Location = new System.Drawing.Point(212, 19);
            this.txtGetDataTime.Name = "txtGetDataTime";
            this.txtGetDataTime.Size = new System.Drawing.Size(52, 20);
            this.txtGetDataTime.TabIndex = 12;
            this.txtGetDataTime.TextChanged += new System.EventHandler(this.txtGetDataTime_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(133, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Интервал мс";
            // 
            // zGraph
            // 
            this.zGraph.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.zGraph.Location = new System.Drawing.Point(242, 101);
            this.zGraph.Name = "zGraph";
            this.zGraph.ScrollGrace = 0D;
            this.zGraph.ScrollMaxX = 0D;
            this.zGraph.ScrollMaxY = 0D;
            this.zGraph.ScrollMaxY2 = 0D;
            this.zGraph.ScrollMinX = 0D;
            this.zGraph.ScrollMinY = 0D;
            this.zGraph.ScrollMinY2 = 0D;
            this.zGraph.Size = new System.Drawing.Size(821, 378);
            this.zGraph.TabIndex = 13;
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox5.Controls.Add(this.checkBox4);
            this.groupBox5.Controls.Add(this.checkBox3);
            this.groupBox5.Controls.Add(this.checkBox2);
            this.groupBox5.Controls.Add(this.checkBox1);
            this.groupBox5.Controls.Add(this.button2);
            this.groupBox5.Controls.Add(this.button1);
            this.groupBox5.Location = new System.Drawing.Point(12, 372);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(226, 107);
            this.groupBox5.TabIndex = 14;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Выходы";
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(6, 88);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(63, 17);
            this.checkBox4.TabIndex = 5;
            this.checkBox4.Text = "ALARM";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(6, 65);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(53, 17);
            this.checkBox3.TabIndex = 4;
            this.checkBox3.Text = "CLAP";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(6, 42);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(55, 17);
            this.checkBox2.TabIndex = 3;
            this.checkBox2.Text = "COLD";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(6, 19);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(49, 17);
            this.checkBox1.TabIndex = 2;
            this.checkBox1.Text = "HOT";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(135, 74);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Set";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(135, 15);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Get";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // timerGetError
            // 
            this.timerGetError.Enabled = true;
            this.timerGetError.Interval = 1000;
            this.timerGetError.Tick += new System.EventHandler(this.timerGetError_Tick);
            // 
            // lblTransferError
            // 
            this.lblTransferError.AutoSize = true;
            this.lblTransferError.Location = new System.Drawing.Point(6, 16);
            this.lblTransferError.Name = "lblTransferError";
            this.lblTransferError.Size = new System.Drawing.Size(118, 13);
            this.lblTransferError.TabIndex = 5;
            this.lblTransferError.Text = "Пакетов потеряно = 0";
            // 
            // chbIsVisiblePacket
            // 
            this.chbIsVisiblePacket.AutoSize = true;
            this.chbIsVisiblePacket.Location = new System.Drawing.Point(6, 49);
            this.chbIsVisiblePacket.Name = "chbIsVisiblePacket";
            this.chbIsVisiblePacket.Size = new System.Drawing.Size(181, 17);
            this.chbIsVisiblePacket.TabIndex = 6;
            this.chbIsVisiblePacket.Text = "Показывать принятые пакеты";
            this.chbIsVisiblePacket.UseVisualStyleBackColor = true;
            // 
            // lblBadPacket
            // 
            this.lblBadPacket.AutoSize = true;
            this.lblBadPacket.Location = new System.Drawing.Point(6, 33);
            this.lblBadPacket.Name = "lblBadPacket";
            this.lblBadPacket.Size = new System.Drawing.Size(101, 13);
            this.lblBadPacket.TabIndex = 7;
            this.lblBadPacket.Text = "Пакетов битых = 0";
            // 
            // groupBox6
            // 
            this.groupBox6.Location = new System.Drawing.Point(664, 12);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(244, 77);
            this.groupBox6.TabIndex = 15;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Коэффициенты";
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1069, 487);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.zGraph);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.lblD2);
            this.Controls.Add(this.lblT2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.lblT1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblD1);
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
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
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
        private System.Windows.Forms.Timer timerGetData;
        private System.Windows.Forms.Label lblT1;
        private System.Windows.Forms.Label lblT2;
        private System.Windows.Forms.Label lblD1;
        private System.Windows.Forms.Label lblD2;
        private System.Windows.Forms.CheckBox chbIsGetData;
        private System.Windows.Forms.Button btnFindAddr;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtGetDataTime;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtGetErrorTime;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chbIsGetError;
        private ZedGraph.ZedGraphControl zGraph;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer timerGetError;
        private System.Windows.Forms.Label lblTransferError;
        private System.Windows.Forms.CheckBox chbIsVisiblePacket;
        private System.Windows.Forms.Label lblBadPacket;
        private System.Windows.Forms.GroupBox groupBox6;
    }
}

