namespace BarChartApp
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel chartPanel;
        private System.Windows.Forms.TextBox inputTextBox;
        private System.Windows.Forms.Button drawChartButton;

        private void InitializeComponent()
        {
            this.chartPanel = new System.Windows.Forms.Panel();
            this.inputTextBox = new System.Windows.Forms.TextBox();
            this.drawChartButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // chartPanel
            // 
            this.chartPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.chartPanel.Location = new System.Drawing.Point(12, 65);
            this.chartPanel.Name = "chartPanel";
            this.chartPanel.Size = new System.Drawing.Size(760, 384);
            this.chartPanel.TabIndex = 0;
            // 
            // inputTextBox
            // 
            this.inputTextBox.Location = new System.Drawing.Point(12, 12);
            this.inputTextBox.Name = "inputTextBox";
            this.inputTextBox.Size = new System.Drawing.Size(640, 22);
            this.inputTextBox.TabIndex = 1;
            // 
            // drawChartButton
            // 
            this.drawChartButton.Location = new System.Drawing.Point(658, 10);
            this.drawChartButton.Name = "drawChartButton";
            this.drawChartButton.Size = new System.Drawing.Size(114, 23);
            this.drawChartButton.TabIndex = 2;
            this.drawChartButton.Text = "Draw Chart";
            this.drawChartButton.UseVisualStyleBackColor = true;
            this.drawChartButton.Click += new System.EventHandler(this.DrawChartButton_Click);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.drawChartButton);
            this.Controls.Add(this.inputTextBox);
            this.Controls.Add(this.chartPanel);
            this.Name = "Form1";
            this.Text = "Bar Chart App";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}

