using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Clicker_v2
{
    public partial class Clicker : Form
    {
        public static int SelectedInterval { get; private set; } = 500; // Default interval time 
        public static int SelectedMaxTime { get; private set; } = 5000; // Default max time

        public Clicker()
        {
            InitializeComponent();
            comboBoxInterval.SelectedIndex = comboBoxInterval.Items.IndexOf("500"); // Set default value
            comboBoxMaxTime.SelectedIndex = comboBoxMaxTime.Items.IndexOf("5000"); // Set default value

            // Capture mouseclick in drawPanel 
            drawPanelBoard.MouseClick += new MouseEventHandler(CaptureMouseClickPosition);
        }

        private void comboBoxInterval_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (int.TryParse(comboBoxInterval.SelectedItem!.ToString()!, out int interval))
            {
                SelectedInterval = interval;
                Debug.WriteLine($"Selected Interval: {SelectedInterval}");

                // Update the Draw class timer interval if necessary
                DrawPanelBoard.UpdateTimerInterval(SelectedInterval);
            }
        }

        private void comboBoxMaxTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (int.TryParse(comboBoxMaxTime.SelectedItem!.ToString(), out int maxTime))
            {
                SelectedMaxTime = maxTime;
                Debug.WriteLine($"Selected Max Time: {SelectedMaxTime}");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Enable capturing mouse events within drawPanel
            this.Capture = false;
        }

        private void CaptureMouseClickPosition(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {

                // Ensure the form is activated
                this.Activate();

                // Capture the mouse position relative to the screen
                Point screenPosition = this.PointToScreen(new Point(e.X, e.Y));
                string captureMouseClickPosition = screenPosition.ToString();

                // Output the position to the debug console
                Debug.WriteLine($"Mouse clicked at: {captureMouseClickPosition}");

                // Append the captured position to the textBox2

                textBox1.AppendText(captureMouseClickPosition + Environment.NewLine);
                textBox1.SelectAll();
                textBox1.TextAlign = HorizontalAlignment.Center;
                textBox1.DeselectAll();

            }
        }

    }
}
