using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace BarChartApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void DrawChartButton_Click(object sender, EventArgs e)
        {
            string[] inputStrings = inputTextBox.Text.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            int[] numbers;

            // Parse the user input into an array of integers
            try
            {
                numbers = inputStrings.Select(int.Parse).ToArray();
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter a valid list of numbers separated by commas.");
                return;
            }

            // Trigger the panel's paint event to draw the chart
            chartPanel.Invalidate();
            chartPanel.Paint += (s, args) => DrawBarChart(args.Graphics, numbers);
        }

        private void DrawBarChart(Graphics g, int[] numbers)
        {
            int panelWidth = chartPanel.Width;
            int panelHeight = chartPanel.Height;

            // Determine the maximum and minimum values for scaling
            int maxValue = numbers.Max();
            int minValue = numbers.Min();
            int maxAbsValue = Math.Max(Math.Abs(maxValue), Math.Abs(minValue));

            // Set the scale for the y-axis (height of the bars)
            float scale = (panelHeight - 60) / (float)maxAbsValue; // 60px padding for axes

            // Set bar properties
            int barWidth = 50;
            int barSpacing = 70;

            // Define an array of different colors to be applied to each bar
            Brush[] barColors = new Brush[] {
                Brushes.Red, Brushes.Green, Brushes.Blue, Brushes.Purple, Brushes.Orange,
                Brushes.Yellow, Brushes.Cyan, Brushes.Magenta, Brushes.Lime, Brushes.Pink
            };

            // Draw Y-axis
            g.DrawLine(Pens.Black, 50, 20, 50, panelHeight - 40); // Y-axis line
            for (int i = 0; i <= maxAbsValue; i += 20)
            {
                int yPos = panelHeight - 40 - (int)(i * scale);
                g.DrawString(i.ToString(), new Font("Arial", 8), Brushes.Black, 10, yPos);
            }

            // Draw X-axis
            g.DrawLine(Pens.Black, 50, panelHeight - 40, panelWidth - 20, panelHeight - 40); // X-axis line

            // Draw bars
            int xPos = 60; // Start drawing the first bar
            for (int i = 0; i < numbers.Length; i++)
            {
                int barHeight = (int)(Math.Abs(numbers[i]) * scale);
                int yPos = (numbers[i] < 0) ? panelHeight - 40 : panelHeight - 40 - barHeight;

                // Use random colors or choose a fixed set
                Brush barBrush = barColors[i % barColors.Length];

                // Draw the bar
                g.FillRectangle(barBrush, xPos, yPos, barWidth, barHeight);

                // Label the bar with its value
                g.DrawString(numbers[i].ToString(), new Font("Arial", 8), Brushes.Black, xPos + 10, (numbers[i] < 0) ? yPos - 15 : yPos + barHeight + 5);

                // Label for X-axis (the number of the bar)
                g.DrawString($"Bar {i + 1}", new Font("Arial", 8), Brushes.Black, xPos + 10, panelHeight - 20 + 5);

                xPos += barWidth + barSpacing;
            }
        }
    }
}


