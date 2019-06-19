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
            this.btnHorzBarChart = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(20, 21);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(876, 371);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnPieChart
            // 
            this.btnPieChart.Location = new System.Drawing.Point(955, 21);
            this.btnPieChart.Name = "btnPieChart";
            this.btnPieChart.Size = new System.Drawing.Size(118, 36);
            this.btnPieChart.TabIndex = 1;
            this.btnPieChart.Text = "Pie Chart";
            this.btnPieChart.UseVisualStyleBackColor = true;
            this.btnPieChart.Click += new System.EventHandler(this.btnPieChart_Click);
            // 
            // btnDonutChart
            // 
            this.btnDonutChart.Location = new System.Drawing.Point(955, 83);
            this.btnDonutChart.Name = "btnDonutChart";
            this.btnDonutChart.Size = new System.Drawing.Size(118, 36);
            this.btnDonutChart.TabIndex = 2;
            this.btnDonutChart.Text = "Donut";
            this.btnDonutChart.UseVisualStyleBackColor = true;
            this.btnDonutChart.Click += new System.EventHandler(this.BtnDonutChart_Click);
            // 
            // btnHorzBarChart
            // 
            this.btnHorzBarChart.Location = new System.Drawing.Point(955, 147);
            this.btnHorzBarChart.Name = "btnHorzBarChart";
            this.btnHorzBarChart.Size = new System.Drawing.Size(118, 36);
            this.btnHorzBarChart.TabIndex = 3;
            this.btnHorzBarChart.Text = "Horz Bar Chart";
            this.btnHorzBarChart.UseVisualStyleBackColor = true;
            this.btnHorzBarChart.Click += new System.EventHandler(this.BtnHorzBarChart_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1140, 450);
            this.Controls.Add(this.btnHorzBarChart);
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
        private System.Windows.Forms.Button btnHorzBarChart;
    }
}

