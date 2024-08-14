using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Clicker_v2
{
    public partial class Clicker : Form
    {
        public static int SelectedInterval { get; set; } = 1000;
        public static int SelectedMaxTime { get; set; } = 2500;

        public Clicker()
        {
            InitializeComponent();
            comboBoxInterval.SelectedIndex = comboBoxInterval.Items.IndexOf("100"); // Set Default Interval Drawing Circles
            comboBoxMaxTime.SelectedIndex = comboBoxMaxTime.Items.IndexOf("2500"); // Set Default MaxTime Display Circles
            drawPanelBoard.MouseClick += new MouseEventHandler(CaptureMouseClickPosition!);
        }

        private void comboBoxInterval_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (int.TryParse(comboBoxInterval.SelectedItem?.ToString()!, out int interval))
            {
                SelectedInterval = interval;
                Debug.WriteLine($"Selected Interval: {SelectedInterval}");
                DrawPanelBoard.UpdateTimerInterval(SelectedInterval);
            }
        }

        private void comboBoxMaxTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (int.TryParse(comboBoxMaxTime.SelectedItem?.ToString(), out int maxTime))
            {
                SelectedMaxTime = maxTime;
                Debug.WriteLine($"Selected Max Time: {SelectedMaxTime}");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Capture = false;
        }

        private void CaptureMouseClickPosition(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Activate();
                int clickX = e.X;
                int clickY = e.Y;
                Point screenPosition = this.PointToScreen(new Point(e.X, e.Y));
                string captureMouseClickPosition = screenPosition.ToString();
                
                Debug.WriteLine($"Mouse click at ({clickX}, {clickY})");
                textBox1.AppendText(captureMouseClickPosition + Environment.NewLine);
                textBox1.SelectAll();
                textBox1.TextAlign = HorizontalAlignment.Center;
                textBox1.DeselectAll();
                // Handle the click event
            }
        }
    }
}
