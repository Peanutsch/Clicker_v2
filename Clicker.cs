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

        private DrawPanelBoard _drawPanelBoard;
        private ClickManager _clickManager;
        private PointsAndDisplays _pointsAndDisplays;

        private List<Circle> _listCircles; // Declare the List<Circle>

        private int _elapsedSeconds = 0;
        private int _totalSeconds = DrawPanelTimerIndicator.totalSeconds; // value from DrawPanelTimerIndicator.totalSeconds

        bool gameActive = false;

        public static int SelectedInterval { get; set; } = 1000;
        public static int SelectedMaxTime { get; set; } = 2500;

        /// <summary>
        /// Initializes a new instance of the <see cref="Clicker"/> class.
        /// Sets up GUI components, initializes managers, and sets event handlers.
        /// </summary>
        public Clicker()
        {
            InitializeComponent();

            comboBoxInterval.SelectedIndex = comboBoxInterval.Items.IndexOf("100");
            comboBoxMaxTime.SelectedIndex = comboBoxMaxTime.Items.IndexOf("2500");

            _drawPanelBoard = new DrawPanelBoard(); // Zorg ervoor dat deze instantie correct is
            _clickManager = new ClickManager(textBoxHitMiss, _drawPanelBoard.Circles);

            _listCircles = new List<Circle>(); // Initialize the List<Circle>

            // Initialize ClickManager with the necessary dependencies
            _clickManager = new ClickManager(textBoxHitMiss, _listCircles);

            // Initialize PointsAndDisplays
            _pointsAndDisplays = new PointsAndDisplays(_totalSeconds, drawPanelTimerIndicator, richTextBoxCountDown);

            // Mouseclick Handler
            drawPanelBoard.MouseClick += CaptureMouseClickPosition!;

            // Initialize the timer with a 1-second interval
            RandomizersTimers.TimerTickIndicator -= OnIndicatorTimerTick!; // Unsubscribe first to avoid duplicate subscriptions
            RandomizersTimers.TimerTickIndicator += OnIndicatorTimerTick!; // Subscribe to the timer event

            gameActive = true;
        }

        /// <summary>
        /// Disposes the timer and cleans up resources when the form is closed.
        /// </summary>
        /// <param name="e">Event arguments for the form closing event.</param>
        public void DisposeTimer(FormClosedEventArgs e)
        {
            if (_indicatorTimer != null)
            {
                // Stop and dispose timer
                _indicatorTimer?.Stop();
                _indicatorTimer?.Dispose();

                base.Dispose();
            }
        }

        /// <summary>
        /// Handles the timer tick event.
        /// Updates the elapsed time, displays the countdown, and checks if the time limit has been reached.
        /// </summary>
        private void OnIndicatorTimerTick(object sender, EventArgs e)
        {
            _elapsedSeconds++;
            _pointsAndDisplays.DisplayCountdown(_elapsedSeconds, _totalSeconds); // Call the new DisplayCountdown method

            if (_elapsedSeconds >= _totalSeconds)
            {
                RandomizersTimers.StopTimer(); // Stop the timer if the total time has elapsed
                richTextBoxCountDown.Text = $"Countdown complete";
                gameActive = false;
            }
        }

        /// <summary>
        /// Handles changes in the interval selection combo box.
        /// Updates the selected interval and adjusts the timer accordingly.
        /// </summary>
        private void ComboBoxInterval_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (int.TryParse(comboBoxInterval.SelectedItem?.ToString(), out int interval))
            {
                SelectedInterval = interval;
                Debug.WriteLine($"Selected Interval: {SelectedInterval}");
                DrawPanelBoard.UpdateTimerInterval(SelectedInterval);
            }
        }

        /// <summary>
        /// Handles changes in the maximum time selection combo box.
        /// Updates the selected maximum time.
        /// </summary>
        private void ComboBoxMaxTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (int.TryParse(comboBoxMaxTime.SelectedItem?.ToString(), out int maxTime))
            {
                SelectedMaxTime = maxTime;
                Debug.WriteLine($"Selected Max Time: {SelectedMaxTime}");
            }
        }

        /// <summary>
        /// Handles the button click event to stop capturing clicks.
        /// </summary>
        private void Button1_Click(object sender, EventArgs e)
        {
            this.Capture = false;
        }

        /// <summary>
        /// Captures the mouse click position on the draw panel.
        /// Processes the click if the game is active and updates the score accordingly.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The mouse event arguments.</param>
        internal void CaptureMouseClickPosition(object sender, MouseEventArgs e)
        {
            // Block register mouseclicks
            if (!gameActive)
                return;

            if (e.Button == MouseButtons.Left)
            {
                this.Activate();
                int clickX = e.X;
                int clickY = e.Y;

                // Pass the coordinates to the GameElements method
                //_clickManager.DisplayClickCoords(clickX, clickY, textBoxCoords);
                _clickManager.ClickInCircleRadius(clickX, clickY, textBoxCoords, drawPanelBoard);
            }
        }
    }
}
