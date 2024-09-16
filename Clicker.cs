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
        private ScoreManager _pointsAndDisplays;
        private TextBox textBoxHitMiss;

        private List<Circle> _listCircles; // Declare the List<Circle>

        private InitQuota _initQuota;

        private int _elapsedSeconds = 0;
        private int _totalSeconds = DrawPanelTimerIndicator.totalSeconds; // Value from DrawPanelTimerIndicator.totalSeconds

        int startQuota = 100;

        bool gameActive = false;
        bool isStartQuota = true;

        public static int SelectedInterval { get; set; } = 1000;
        public static int SelectedMaxTime { get; set; } = 5000;

        /// <summary>
        /// Initializes a new instance of the Clicker class.
        /// Sets up the game environment, including UI components and event handlers.
        /// </summary>
        public Clicker()
        {
            InitializeComponent();

            // Initialize InitQuota with the TextBox
            _initQuota = new InitQuota(isStartQuota);

            // Display startQuota in textBoxQuota
            _initQuota.NewPointsQuota(textBoxQuota);


            // Set default values for combo boxes
            comboBoxInterval.SelectedIndex = comboBoxInterval.Items.IndexOf("2000");
            comboBoxMaxTime.SelectedIndex = comboBoxMaxTime.Items.IndexOf("2500");


            _drawPanelBoard = new DrawPanelBoard(); // Ensure this instance is correctly initialized
            _listCircles = new List<Circle>(); // Initialize the List<Circle>

            // Initialize PointsAndDisplays
            _pointsAndDisplays = new ScoreManager(_totalSeconds, drawPanelTimerIndicator, richTextBoxCountDown);

            // Initialize ClickManager with the necessary dependencies
            _clickManager = new ClickManager(textBoxHitMiss!, _listCircles, _pointsAndDisplays, textBoxDisplayScore);

            // Mouse click Handler
            drawPanelBoard.MouseClick += CaptureMouseClickPosition!;

            // Initialize the timer with a 1-second interval
            Inits.TimerTickIndicator -= OnIndicatorTimerTick!; // Unsubscribe first to avoid duplicate subscriptions
            Inits.TimerTickIndicator += OnIndicatorTimerTick!; // Subscribe to the timer event

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
                Inits.StopTimer(); // Stop the timer if the total time has elapsed
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
        /// Sets the form's capture state to false.
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
            // Block register mouse clicks if the game is not active
            if (!gameActive)
                return;

            if (e.Button == MouseButtons.Left)
            {
                this.Activate(); // Ensure the form is active
                int clickX = e.X;
                int clickY = e.Y;

                // Pass the coordinates to the ClickManager method
                //_clickManager.DisplayClickCoords(clickX, clickY, textBoxCoords);
                _clickManager.ClickInCircleRadius(clickX, clickY, textBoxCoords, drawPanelBoard);
            }
        }
    }
}
