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
        #region VALUES
        public static int SelectedInterval { get; set; } = 500; // Selected interval for the timer
        public static int SelectedMaxTime { get; set; } = 2000; // Maximum time for the game

        private int bonusTimeLimit = Inits.bonusTimeLimit;
        private int additionalTime = Inits.additionalTimeCountdown;
        private int totalSeconds = Inits.totalSeconds; // Total time Countdown from Timer Values PanelTimerIndicator
        private int elapsedSeconds = Inits.elapsedSeconds; // Track elapsed seconds of the game
        private int startQuota = Inits.startQuota; // Starting quota for the game
        #endregion

        private static System.Windows.Forms.Timer? indicatorTimer = new System.Windows.Forms.Timer();

        private PanelBoardCircles _drawPanelBoard; // The drawing board for the game
        private PanelTimerIndicator _drawPanelTimerIndicator; // Timer indicator to display time remaining
        private ClickManager clickManager; // Manages click interactions
        private ScoreManager _scoreManager; // Manages scoring and countdown display
        private TextBox? textBoxHitMiss; // Displays hit/miss status

        private List<Circle> _listCircles; // List to hold the circles in the game

        private InitQuota initQuota; // Manages initial quotas for the game

        bool gameActive = false; // Indicates if the game is currently active
        bool isStartQuota = true; // Indicates if the starting quota is in effect

        /// <summary>
        /// Initializes a new instance of the <see cref="GameWindow"/> class.
        /// Sets up the game environment, including UI components and event handlers.
        /// </summary>
        public GameWindow()
        {
            InitializeComponent();

            // Initialize InitQuota with the TextBox
            initQuota = new InitQuota(isStartQuota);

            // Display startQuota in textBoxQuota
            initQuota.NewPointsQuota(textBoxQuota);

            _drawPanelBoard = new PanelBoardCircles(); // Ensure this instance is correctly initialized
            _listCircles = new List<Circle>(); // Initialize the List<Circle>

            // Create ScoreManager instance
            _scoreManager = new ScoreManager(totalSeconds, drawPanelTimerIndicator, richTextBoxCountDown);

            // Initialize the timer indicator first
            _drawPanelTimerIndicator = new PanelTimerIndicator(clickManager); // Initialize timer indicator

            // Create the ClickManager instance after initializing the timer indicator
            clickManager = new ClickManager(textBoxHitMiss!, _listCircles, _scoreManager, textBoxDisplayScore, _drawPanelTimerIndicator);

            // Mouse click Handler
            drawPanelBoard.MouseClick += CaptureMouseClickPosition!;

            // Initialize the countdown timer with a 1-second interval
            Inits.TimerTickIndicator -= OnIndicatorTimerTick!; // Unsubscribe first to avoid duplicate subscriptions
            Inits.TimerTickIndicator += OnIndicatorTimerTick!; // Subscribe to the timer event

            gameActive = true; // Set the game as active
        }


        /// <summary>
        /// Handles the timer tick event.
        /// Updates the elapsed time, displays the countdown, and checks if the time limit has been reached.
        /// </summary>
        private void OnIndicatorTimerTick(object sender, EventArgs e)
        {
            // Check if bonus time should be added; only when remaining time < bonusTimeLimit
            if (clickManager.plusTime && (totalSeconds - elapsedSeconds) < bonusTimeLimit)
            {
                totalSeconds += additionalTime; // Add 2 sec bonustime: 1 sec current tick, 1 sec bonus tick

                Debug.WriteLine($"[COUNTDOWN TIMER] Added time: {additionalTime}");

                clickManager.plusTime = false; // Reset the flag after adding the bonus
            }

            elapsedSeconds++;
            _scoreManager.DisplayCountdown(elapsedSeconds, totalSeconds); // Update countdown display

            if (elapsedSeconds >= totalSeconds)
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
                clickManager.ClickInCircleRadius(clickX, clickY, textBoxCoords, drawPanelBoard);
            }
        }
    }
}
