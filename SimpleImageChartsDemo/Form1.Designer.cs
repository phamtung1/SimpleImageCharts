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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(20, 21);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(966, 522);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnPieChart
            // 
            this.btnPieChart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPieChart.Location = new System.Drawing.Point(1045, 21);
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
            this.btnDonutChart.Location = new System.Drawing.Point(1045, 79);
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
            this.btnBarChart.Location = new System.Drawing.Point(1045, 137);
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
            this.btnColumnChart.Location = new System.Drawing.Point(1045, 311);
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
            this.btnDoubleAxisBar.Location = new System.Drawing.Point(1045, 253);
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
            this.btnStackedBar.Location = new System.Drawing.Point(1045, 195);
            this.btnStackedBar.Name = "btnStackedBar";
            this.btnStackedBar.Size = new System.Drawing.Size(118, 36);
            this.btnStackedBar.TabIndex = 6;
            this.btnStackedBar.Text = "Stacked Bar Chart";
            this.btnStackedBar.UseVisualStyleBackColor = true;
            this.btnStackedBar.Click += new System.EventHandler(this.BtnStackedBar_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1230, 601);
            this.Controls.Add(this.btnStackedBar);
            this.Controls.Add(this.btnDoubleAxisBar);
            this.Controls.Add(this.btnColumnChart);
            this.Controls.Add(this.btnBarChart);
            this.Controls.Add(this.btnDonutChart);
            this.Controls.Add(this.btnPieChart);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
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
    }
}

