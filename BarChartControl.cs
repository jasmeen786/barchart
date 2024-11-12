using System;
using System.Drawing;
using System.Windows.Forms;

namespace BarChartApp
{
    public partial class BarChartControl : UserControl
    {
        private int[] barValues;

        public BarChartControl()
        {
            InitializeComponent();
            barValues = new int[] { 50, 80, 120, 60, 40 }; // Default values
        }

        // Method to set the values for the bar chart
        public void SetBarValues(int[] values)
        {
            barValues = values;
            Invalidate(); // Redraw the control
        }

        // Method to paint the chart
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            int barWidth = 100;
            int spaceBetweenBars = 20;

            // Draw bars
            for (int i = 0; i < barValues.Length; i++)
            {
                // Define each bar's rectangle
                Rectangle barRect = new Rectangle(
                    i * (barWidth + spaceBetweenBars),
                    this.ClientSize.Height - barValues[i],
                    barWidth,
                    barValues[i]
                );

                // Set the color of the bars (you can use different colors for each bar if you want)
                g.FillRectangle(Brushes.Blue, barRect);

                // Draw the value on top of the bar
                g.DrawString(barValues[i].ToString(), this.Font, Brushes.Black, barRect.X + barWidth / 4, barRect.Y - 20);
            }
        }
    }
}

