namespace Кант_Вино
{
    partial class FullItemControl
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
            this.temperatureGraph = new ZedGraph.ZedGraphControl();
            this.pressureGraph = new ZedGraph.ZedGraphControl();
            this.levelGraph = new ZedGraph.ZedGraphControl();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.btnCurrent = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // temperatureGraph
            // 
            this.temperatureGraph.Dock = System.Windows.Forms.DockStyle.Fill;
            this.temperatureGraph.Location = new System.Drawing.Point(3, 28);
            this.temperatureGraph.Name = "temperatureGraph";
            this.temperatureGraph.ScrollGrace = 0D;
            this.temperatureGraph.ScrollMaxX = 0D;
            this.temperatureGraph.ScrollMaxY = 0D;
            this.temperatureGraph.ScrollMaxY2 = 0D;
            this.temperatureGraph.ScrollMinX = 0D;
            this.temperatureGraph.ScrollMinY = 0D;
            this.temperatureGraph.ScrollMinY2 = 0D;
            this.temperatureGraph.Size = new System.Drawing.Size(643, 175);
            this.temperatureGraph.TabIndex = 0;
            this.temperatureGraph.ZoomEvent += new ZedGraph.ZedGraphControl.ZoomEventHandler(this.temperatureGraph_ZoomEvent);
            this.temperatureGraph.ScrollEvent += new System.Windows.Forms.ScrollEventHandler(this.temperatureGraph_ScrollEvent);
            // 
            // pressureGraph
            // 
            this.pressureGraph.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pressureGraph.Location = new System.Drawing.Point(3, 209);
            this.pressureGraph.Name = "pressureGraph";
            this.pressureGraph.ScrollGrace = 0D;
            this.pressureGraph.ScrollMaxX = 0D;
            this.pressureGraph.ScrollMaxY = 0D;
            this.pressureGraph.ScrollMaxY2 = 0D;
            this.pressureGraph.ScrollMinX = 0D;
            this.pressureGraph.ScrollMinY = 0D;
            this.pressureGraph.ScrollMinY2 = 0D;
            this.pressureGraph.Size = new System.Drawing.Size(643, 175);
            this.pressureGraph.TabIndex = 1;
            // 
            // levelGraph
            // 
            this.levelGraph.Dock = System.Windows.Forms.DockStyle.Fill;
            this.levelGraph.Location = new System.Drawing.Point(3, 390);
            this.levelGraph.Name = "levelGraph";
            this.levelGraph.ScrollGrace = 0D;
            this.levelGraph.ScrollMaxX = 0D;
            this.levelGraph.ScrollMaxY = 0D;
            this.levelGraph.ScrollMaxY2 = 0D;
            this.levelGraph.ScrollMinX = 0D;
            this.levelGraph.ScrollMinY = 0D;
            this.levelGraph.ScrollMinY2 = 0D;
            this.levelGraph.Size = new System.Drawing.Size(643, 176);
            this.levelGraph.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.temperatureGraph, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.levelGraph, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.pressureGraph, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(649, 569);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCurrent);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dateTimePicker1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(649, 25);
            this.panel1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Просмотреть историю с";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(175, 3);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 0;
            // 
            // btnCurrent
            // 
            this.btnCurrent.Location = new System.Drawing.Point(471, 2);
            this.btnCurrent.Name = "btnCurrent";
            this.btnCurrent.Size = new System.Drawing.Size(175, 23);
            this.btnCurrent.TabIndex = 2;
            this.btnCurrent.Text = "Показывать текущие значения";
            this.btnCurrent.UseVisualStyleBackColor = true;
            this.btnCurrent.Click += new System.EventHandler(this.btnCurrent_Click);
            // 
            // FullItemControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FullItemControl";
            this.Size = new System.Drawing.Size(649, 569);
            this.Load += new System.EventHandler(this.FullItemControl_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ZedGraph.ZedGraphControl temperatureGraph;
        private ZedGraph.ZedGraphControl pressureGraph;
        private ZedGraph.ZedGraphControl levelGraph;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button btnCurrent;
    }
}
