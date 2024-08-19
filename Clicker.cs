using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Clicker_v2
{
    public partial class Clicker : Form
    {
        private static System.Windows.Forms.Timer? _indicatorTimer = new System.Windows.Forms.Timer();
        private DrawPanelTimerIndicator _drawPanelTimerIndicator;

        private Dictionary<Color, (int x, int y)> _dictColorsAndCoords;
        private GameElements _gameElements;
        private List<Circle> _listCircles; // Declare the List<Circle>

        private int _elapsedSeconds = 0;
        private int _totalSeconds = DrawPanelTimerIndicator.totalSeconds;

        public static int SelectedInterval { get; set; } = 1000;
        public static int SelectedMaxTime { get; set; } = 2500;

        public Clicker()
        {
            InitializeComponent();

            comboBoxInterval.SelectedIndex = comboBoxInterval.Items.IndexOf("100");
            comboBoxMaxTime.SelectedIndex = comboBoxMaxTime.Items.IndexOf("2500");

            _dictColorsAndCoords = new Dictionary<Color, (int x, int y)>();
            _listCircles = new List<Circle>(); // Initialize the List<Circle>

            // Initialize GameElements with the necessary dependencies
            _gameElements = new GameElements(_dictColorsAndCoords, textBoxHitMiss, _listCircles);

            // Assuming drawPanelTimerIndicator is initialized elsewhere
            drawPanelBoard.MouseClick += CaptureMouseClickPosition!;

            // Initialize the timer with a 1-second interval
            Initializations.TimerTickIndicator -= OnIndicatorTimerTick!; // Unsubscribe first to avoid duplicate subscriptions
            Initializations.InitializeIndicatorTimer();
            Initializations.TimerTickIndicator += OnIndicatorTimerTick!; // Subscribe to the timer event
        }

        public void DisposeTimer(FormClosedEventArgs e)
        {
            if (_indicatorTimer != null)
            {
                // Stop en dispose de timer
                _indicatorTimer?.Stop();
                _indicatorTimer?.Dispose();

                base.Dispose();
            }
        }

        private void OnIndicatorTimerTick(object sender, EventArgs e)
        {
            _elapsedSeconds++;
            DisplayCountdown();

            if (_elapsedSeconds >= _totalSeconds)
            {
                Initializations.StopTimer(); // Stop the timer if the total time has elapsed
                richTextBoxCountDown.Text = $"Countdown completed";
            }
        }

        private void DisplayCountdown()
        {
            // Update the drawPanelTimerIndicator
            drawPanelTimerIndicator.Invalidate();

            // Update the richTextBoxCountdown with the remaining time
            int remainingSeconds = _totalSeconds - _elapsedSeconds;
            richTextBoxCountDown.Text = $"Time left: {remainingSeconds} seconds";
        }

        private void ComboBoxInterval_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (int.TryParse(comboBoxInterval.SelectedItem?.ToString(), out int interval))
            {
                SelectedInterval = interval;
                Debug.WriteLine($"Selected Interval: {SelectedInterval}");
                DrawPanelBoard.UpdateTimerInterval(SelectedInterval);
            }
        }

        private void ComboBoxMaxTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (int.TryParse(comboBoxMaxTime.SelectedItem?.ToString(), out int maxTime))
            {
                SelectedMaxTime = maxTime;
                Debug.WriteLine($"Selected Max Time: {SelectedMaxTime}");
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Capture = false;
        }

        internal void CaptureMouseClickPosition(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Activate();
                int clickX = e.X;
                int clickY = e.Y;

                // Pass the coordinates to the GameElements method
                _gameElements.DisplayClickCoords(clickX, clickY, textBoxCoords);
                _gameElements.ClickInCircleRadius(clickX, clickY, textBoxCoords);
            }
        }
    }
}
