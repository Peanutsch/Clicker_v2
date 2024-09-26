using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Clicker_v2
{
    /// <summary>
    /// Represents the main game window for the Clicker game.
    /// Initializes the game environment, manages game state, and handles user interactions.
    /// </summary>
    public partial class GameWindow : Form
    {
        private static System.Windows.Forms.Timer? _indicatorTimer = new System.Windows.Forms.Timer();

        private DrawPanelBoard _drawPanelBoard; // The drawing board for the game
        private DrawPanelTimerIndicator _drawPanelTimerIndicator; // Timer indicator to display time remaining
        private ClickManager _clickManager; // Manages click interactions
        private ScoreManager _scoreManager; // Manages scoring and countdown display
        private TextBox? textBoxHitMiss; // Displays hit/miss status

        private List<Circle> _listCircles; // List to hold the circles in the game

        private InitQuota _initQuota; // Manages initial quotas for the game

        private int _elapsedSeconds = 0; // Track elapsed seconds of the game
        private int _totalSeconds = DrawPanelTimerIndicator.totalSeconds; // Total time for the game

        int startQuota = 100; // Starting quota for the game

        bool gameActive = false; // Indicates if the game is currently active
        bool isStartQuota = true; // Indicates if the starting quota is in effect

        public static int SelectedInterval { get; set; } = 1000; // Selected interval for the timer
        public static int SelectedMaxTime { get; set; } = 5000; // Maximum time for the game

        /// <summary>
        /// Initializes a new instance of the <see cref="GameWindow"/> class.
        /// Sets up the game environment, including UI components and event handlers.
        /// </summary>
        public GameWindow()
        {
            InitializeComponent();

            // Initialize InitQuota with the TextBox
            _initQuota = new InitQuota(isStartQuota);

            // Display startQuota in textBoxQuota
            _initQuota.NewPointsQuota(textBoxQuota);

            _drawPanelBoard = new DrawPanelBoard(); // Ensure this instance is correctly initialized
            _listCircles = new List<Circle>(); // Initialize the List<Circle>

            // Create ScoreManager instance
            _scoreManager = new ScoreManager(_totalSeconds, drawPanelTimerIndicator, richTextBoxCountDown);

            // Create the ClickManager instance
            _clickManager = new ClickManager(textBoxHitMiss!, _listCircles, _scoreManager, textBoxDisplayScore);

            // Pass the ClickManager instance to the DrawPanelTimerIndicator constructor
            _drawPanelTimerIndicator = new DrawPanelTimerIndicator(_clickManager); // Initialize timer indicator

            // Mouse click Handler
            drawPanelBoard.MouseClick += CaptureMouseClickPosition!;

            // Initialize the timer with a 1-second interval
            Inits.TimerTickIndicator -= OnIndicatorTimerTick!; // Unsubscribe first to avoid duplicate subscriptions
            Inits.TimerTickIndicator += OnIndicatorTimerTick!; // Subscribe to the timer event

            gameActive = true; // Set the game as active
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
            // Check if bonus time should be added
            if (_clickManager.plusTime)
            {
                _totalSeconds += 2; // Add extra time
                _clickManager.plusTime = false; // Reset the flag after adding the bonus
            }

            _elapsedSeconds++;
            _scoreManager.DisplayCountdown(_elapsedSeconds, _totalSeconds); // Update countdown display

            if (_elapsedSeconds >= _totalSeconds)
            {
                Inits.StopTimer(drawPanelBoard); // Stop the timer if the total time has elapsed
                richTextBoxCountDown.Text = "Countdown complete"; // Notify the user that the countdown is complete
                gameActive = false; // Set the game as inactive
            }
        }

        /// <summary>
        /// Handles the button click event to stop capturing clicks.
        /// Sets the form's capture state to false.
        /// </summary>
        private void Button1_Click(object sender, EventArgs e)
        {
            this.Capture = false; // Release the form capture
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
                _clickManager.ClickInCircleRadius(clickX, clickY, textBoxCoords, drawPanelBoard);
            }
        }
    }
}
