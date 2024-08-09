using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Clicker
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
        }

        private void comboBoxInterval_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (int.TryParse(comboBoxInterval.SelectedItem.ToString(), out int interval))
            {
                SelectedInterval = interval;
                Debug.WriteLine($"Selected Interval: {SelectedInterval}");

                // Update the Draw class timer interval if necessary
                Draw.UpdateTimerInterval(SelectedInterval);
            }
        }

        private void comboBoxMaxTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (int.TryParse(comboBoxMaxTime.SelectedItem.ToString(), out int maxTime))
            {
                SelectedMaxTime = maxTime;
                Debug.WriteLine($"Selected Max Time: {SelectedMaxTime}");
            }
        }
    }
}
