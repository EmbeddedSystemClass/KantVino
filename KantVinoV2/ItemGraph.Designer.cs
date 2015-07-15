namespace KantVinoV2
{
    partial class ItemGraph
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Обязательный метод для поддержки конструктора - не изменяйте 
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ItemGraph));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnContinue = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.dtpLoadData = new System.Windows.Forms.DateTimePicker();
            this.zGraph = new ZedGraph.ZedGraphControl();
            this.timer100ms = new System.Windows.Forms.Timer(this.components);
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnContinue,
            this.toolStripSeparator1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(750, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnContinue
            // 
            this.btnContinue.Image = ((System.Drawing.Image)(resources.GetObject("btnContinue.Image")));
            this.btnContinue.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.Size = new System.Drawing.Size(130, 22);
            this.btnContinue.Text = "Текущие значения";
            this.btnContinue.Click += new System.EventHandler(this.btnContinue_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // dtpLoadData
            // 
            this.dtpLoadData.Location = new System.Drawing.Point(183, 3);
            this.dtpLoadData.Name = "dtpLoadData";
            this.dtpLoadData.Size = new System.Drawing.Size(179, 20);
            this.dtpLoadData.TabIndex = 1;
            this.dtpLoadData.ValueChanged += new System.EventHandler(this.dtpLoadData_ValueChanged);
            // 
            // zGraph
            // 
            this.zGraph.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zGraph.Location = new System.Drawing.Point(0, 25);
            this.zGraph.Name = "zGraph";
            this.zGraph.ScrollGrace = 0D;
            this.zGraph.ScrollMaxX = 0D;
            this.zGraph.ScrollMaxY = 0D;
            this.zGraph.ScrollMaxY2 = 0D;
            this.zGraph.ScrollMinX = 0D;
            this.zGraph.ScrollMinY = 0D;
            this.zGraph.ScrollMinY2 = 0D;
            this.zGraph.Size = new System.Drawing.Size(750, 523);
            this.zGraph.TabIndex = 2;
            // 
            // timer100ms
            // 
            this.timer100ms.Enabled = true;
            this.timer100ms.Tick += new System.EventHandler(this.timer100ms_Tick);
            // 
            // ItemGraph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.zGraph);
            this.Controls.Add(this.dtpLoadData);
            this.Controls.Add(this.toolStrip1);
            this.Name = "ItemGraph";
            this.Size = new System.Drawing.Size(750, 548);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnContinue;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.DateTimePicker dtpLoadData;
        private ZedGraph.ZedGraphControl zGraph;
        private System.Windows.Forms.Timer timer100ms;
    }
}
