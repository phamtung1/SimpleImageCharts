namespace WindowsFormsChart
{
    partial class Form1
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnPieChart = new System.Windows.Forms.Button();
            this.btnDonutChart = new System.Windows.Forms.Button();
            this.btnBarChart = new System.Windows.Forms.Button();
            this.btnColumnChart = new System.Windows.Forms.Button();
            this.btnDoubleAxisBar = new System.Windows.Forms.Button();
            this.btnStackedBar = new System.Windows.Forms.Button();
            this.btnRadarChart = new System.Windows.Forms.Button();
            this.btnSingleRangeBarChart = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnStackedBar100Percent = new System.Windows.Forms.Button();
            this.btnStackedColumn100Percent = new System.Windows.Forms.Button();
            this.btnBarGaugeChart = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(22, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1017, 429);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnPieChart
            // 
            this.btnPieChart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPieChart.Location = new System.Drawing.Point(3, 3);
            this.btnPieChart.Name = "btnPieChart";
            this.btnPieChart.Size = new System.Drawing.Size(118, 36);
            this.btnPieChart.TabIndex = 1;
            this.btnPieChart.Text = "Pie Chart";
            this.btnPieChart.UseVisualStyleBackColor = true;
            this.btnPieChart.Click += new System.EventHandler(this.btnPieChart_Click);
            // 
            // btnDonutChart
            // 
            this.btnDonutChart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDonutChart.Location = new System.Drawing.Point(127, 3);
            this.btnDonutChart.Name = "btnDonutChart";
            this.btnDonutChart.Size = new System.Drawing.Size(118, 36);
            this.btnDonutChart.TabIndex = 2;
            this.btnDonutChart.Text = "Donut";
            this.btnDonutChart.UseVisualStyleBackColor = true;
            this.btnDonutChart.Click += new System.EventHandler(this.BtnDonutChart_Click);
            // 
            // btnBarChart
            // 
            this.btnBarChart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBarChart.Location = new System.Drawing.Point(251, 3);
            this.btnBarChart.Name = "btnBarChart";
            this.btnBarChart.Size = new System.Drawing.Size(118, 36);
            this.btnBarChart.TabIndex = 3;
            this.btnBarChart.Text = "Bar Chart";
            this.btnBarChart.UseVisualStyleBackColor = true;
            this.btnBarChart.Click += new System.EventHandler(this.BtnBarChart_Click);
            // 
            // btnColumnChart
            // 
            this.btnColumnChart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnColumnChart.Location = new System.Drawing.Point(747, 3);
            this.btnColumnChart.Name = "btnColumnChart";
            this.btnColumnChart.Size = new System.Drawing.Size(118, 36);
            this.btnColumnChart.TabIndex = 4;
            this.btnColumnChart.Text = "Column Chart";
            this.btnColumnChart.UseVisualStyleBackColor = true;
            this.btnColumnChart.Click += new System.EventHandler(this.BtnColumnChart_Click);
            // 
            // btnDoubleAxisBar
            // 
            this.btnDoubleAxisBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDoubleAxisBar.Location = new System.Drawing.Point(499, 3);
            this.btnDoubleAxisBar.Name = "btnDoubleAxisBar";
            this.btnDoubleAxisBar.Size = new System.Drawing.Size(118, 36);
            this.btnDoubleAxisBar.TabIndex = 5;
            this.btnDoubleAxisBar.Text = "Double Axis Bar Chart";
            this.btnDoubleAxisBar.UseVisualStyleBackColor = true;
            this.btnDoubleAxisBar.Click += new System.EventHandler(this.BtnDoubleAxisBar_Click);
            // 
            // btnStackedBar
            // 
            this.btnStackedBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStackedBar.Location = new System.Drawing.Point(375, 3);
            this.btnStackedBar.Name = "btnStackedBar";
            this.btnStackedBar.Size = new System.Drawing.Size(118, 36);
            this.btnStackedBar.TabIndex = 6;
            this.btnStackedBar.Text = "Stacked Bar Chart";
            this.btnStackedBar.UseVisualStyleBackColor = true;
            this.btnStackedBar.Click += new System.EventHandler(this.BtnStackedBar_Click);
            // 
            // btnRadarChart
            // 
            this.btnRadarChart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRadarChart.Location = new System.Drawing.Point(3, 45);
            this.btnRadarChart.Name = "btnRadarChart";
            this.btnRadarChart.Size = new System.Drawing.Size(118, 36);
            this.btnRadarChart.TabIndex = 7;
            this.btnRadarChart.Text = "Radar Chart";
            this.btnRadarChart.UseVisualStyleBackColor = true;
            this.btnRadarChart.Click += new System.EventHandler(this.BtnRadarChart_Click);
            // 
            // btnSingleRangeBarChart
            // 
            this.btnSingleRangeBarChart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSingleRangeBarChart.Location = new System.Drawing.Point(127, 45);
            this.btnSingleRangeBarChart.Name = "btnSingleRangeBarChart";
            this.btnSingleRangeBarChart.Size = new System.Drawing.Size(118, 36);
            this.btnSingleRangeBarChart.TabIndex = 8;
            this.btnSingleRangeBarChart.Text = "Single Range Bar Chart";
            this.btnSingleRangeBarChart.UseVisualStyleBackColor = true;
            this.btnSingleRangeBarChart.Click += new System.EventHandler(this.BtnSingleRangeBarChart_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.Controls.Add(this.btnPieChart);
            this.flowLayoutPanel1.Controls.Add(this.btnDonutChart);
            this.flowLayoutPanel1.Controls.Add(this.btnBarChart);
            this.flowLayoutPanel1.Controls.Add(this.btnStackedBar);
            this.flowLayoutPanel1.Controls.Add(this.btnDoubleAxisBar);
            this.flowLayoutPanel1.Controls.Add(this.btnStackedBar100Percent);
            this.flowLayoutPanel1.Controls.Add(this.btnColumnChart);
            this.flowLayoutPanel1.Controls.Add(this.btnStackedColumn100Percent);
            this.flowLayoutPanel1.Controls.Add(this.btnRadarChart);
            this.flowLayoutPanel1.Controls.Add(this.btnSingleRangeBarChart);
            this.flowLayoutPanel1.Controls.Add(this.btnBarGaugeChart);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(22, 447);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1017, 142);
            this.flowLayoutPanel1.TabIndex = 9;
            // 
            // btnStackedBar100Percent
            // 
            this.btnStackedBar100Percent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStackedBar100Percent.Location = new System.Drawing.Point(623, 3);
            this.btnStackedBar100Percent.Name = "btnStackedBar100Percent";
            this.btnStackedBar100Percent.Size = new System.Drawing.Size(118, 36);
            this.btnStackedBar100Percent.TabIndex = 9;
            this.btnStackedBar100Percent.Text = "Stacked Bar 100% Chart";
            this.btnStackedBar100Percent.UseVisualStyleBackColor = true;
            this.btnStackedBar100Percent.Click += new System.EventHandler(this.btnStackedBar100Percent_Click);
            // 
            // btnStackedColumn100Percent
            // 
            this.btnStackedColumn100Percent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStackedColumn100Percent.Location = new System.Drawing.Point(871, 3);
            this.btnStackedColumn100Percent.Name = "btnStackedColumn100Percent";
            this.btnStackedColumn100Percent.Size = new System.Drawing.Size(118, 36);
            this.btnStackedColumn100Percent.TabIndex = 10;
            this.btnStackedColumn100Percent.Text = "Stacked Column 100% Chart";
            this.btnStackedColumn100Percent.UseVisualStyleBackColor = true;
            this.btnStackedColumn100Percent.Click += new System.EventHandler(this.btnStackedColumn100Percent_Click);
            // 
            // btnBarGaugeChart
            // 
            this.btnBarGaugeChart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBarGaugeChart.Location = new System.Drawing.Point(251, 45);
            this.btnBarGaugeChart.Name = "btnBarGaugeChart";
            this.btnBarGaugeChart.Size = new System.Drawing.Size(118, 36);
            this.btnBarGaugeChart.TabIndex = 11;
            this.btnBarGaugeChart.Text = "Bar Gauge Chart";
            this.btnBarGaugeChart.UseVisualStyleBackColor = true;
            this.btnBarGaugeChart.Click += new System.EventHandler(this.btnBarGaugeChart_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1051, 601);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnPieChart;
        private System.Windows.Forms.Button btnDonutChart;
        private System.Windows.Forms.Button btnBarChart;
        private System.Windows.Forms.Button btnColumnChart;
        private System.Windows.Forms.Button btnDoubleAxisBar;
        private System.Windows.Forms.Button btnStackedBar;
        private System.Windows.Forms.Button btnRadarChart;
        private System.Windows.Forms.Button btnSingleRangeBarChart;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnStackedBar100Percent;
        private System.Windows.Forms.Button btnStackedColumn100Percent;
        private System.Windows.Forms.Button btnBarGaugeChart;
    }
}

