using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Clicker_v2
{
    /// <summary>
    /// Represents a panel that visually indicates the progress of a timer, including a bonus time feature.
    /// The panel fills from right to left and changes color based on the active bonus time.
    /// </summary>
    internal class PanelTimerIndicator : Panel
    {
        #region INDICATOR VALUES
        private int totalSeconds = Inits.totalSeconds; // Total duration of the timer in seconds
        private int colorChangeInterval = Inits.colorChangeInterval; // The interval for color change in seconds
        private int timerInterval = Inits.timerInterval; // The interval for the timer
        private int additionalTime = Inits.additionalTimeIndicator; // Additional time in seconds

        private int elapsedSeconds = Inits.elapsedSeconds; // Elapsed time in seconds
        private int bonusTimeRemaining = Inits.bonusTimeRemaining; // Bonus time in seconds
        private int bonusTimeLimit = Inits.bonusTimeLimit; // Limit for time countdown
        #endregion

        private readonly ClickManager _clickManager; // Reference to ClickManager for managing clicks and bonus time
        private bool isBonusActive; // Indicates if bonus time is active

        /// <summary>
        /// Initializes a new instance of the <see cref="PanelTimerIndicator"/> class.
        /// Sets up double buffering to reduce flickering and initializes the timer for updates.
        /// </summary>
        /// <param name="clickManager">Reference to the <see cref="ClickManager"/> to manage bonus time events.</param>
        public PanelTimerIndicator(ClickManager clickManager)
        {
            _clickManager = clickManager;

            this.DoubleBuffered = true;

            // Subscribe and initialize the timer for regular updates
            Inits.TimerTickIndicator -= OnTimerTick!;
            Inits.InitializeIndicatorTimer();
            Inits.TimerTickIndicator += OnTimerTick!;
        }

        /// <summary>
        /// Activates or deactivates the bonus time feature and updates the panel's background color.
        /// When activated, it adds additional bonus time to the remaining time and changes the panel color to yellow.
        /// </summary>
        /// <param name="value">True to activate bonus time; False to deactivate it.</param>
        public void BoolBonusTime(bool value)
        {
            isBonusActive = value; // Update the status of bonus time

            if (isBonusActive)
            {
                bonusTimeRemaining += additionalTime; // Add additional time for the bonus
                this.BackColor = Color.Yellow; // Change the panel's background color to yellow
                Debug.WriteLine($"[BoolBonusTime] Bonus Activated: Bonus Seconds: {bonusTimeRemaining}, Elapsed Time: {elapsedSeconds}");
            }
        }

        /// <summary>
        /// Handles the timer tick event to update the elapsed time and redraw the panel.
        /// This method manages the activation and deactivation of bonus time, updates
        /// the panel's background color, and ensures the timer does not exceed the total time.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Event arguments for the timer tick event.</param>
        internal void OnTimerTick(object sender, EventArgs e)
        {
            elapsedSeconds += colorChangeInterval;

            // Handle bonus time logic first
            if (isBonusActive)
            {
                bonusTimeRemaining--;  // Decrease the bonus time only if it is active
                Debug.WriteLine($"Bonus Time Remaining: {bonusTimeRemaining}");

                // Deactivate the bonus if the time is up
                if (bonusTimeRemaining <= 0)
                {
                    isBonusActive = false; // Set bonus to inactive
                    Debug.WriteLine($"Bonus Time Deactivated: Elapsed Time: {elapsedSeconds}");
                    this.BackColor = Color.Red; // Change background to red
                }
            }

            // Cap elapsed time to total time and handle end state
            if (elapsedSeconds >= totalSeconds)
            {
                elapsedSeconds = totalSeconds;
                this.BackColor = Color.Red; // Final red color when time is up
            }

            // Invalidate the panel to trigger a redraw
            Invalidate(); // Always request redraw after changes
        }


        /// <summary>
        /// Overrides the OnPaint method to visually represent the timer's progress.
        /// The panel is filled from right to left, with sections colored red for normal time and yellow for bonus time.
        /// </summary>
        /// <param name="e">PaintEventArgs that contains data for the paint event.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Debug.WriteLine($"[OnPaint called] isBonus: {isBonusActive}, Elapsed Seconds: {elapsedSeconds}");

            Graphics graphics = e.Graphics;
            int totalWidth = this.ClientRectangle.Width; // Total width of the panel
            int sectionWidth = totalWidth / totalSeconds; // Width of each section based on total time

            // Calculate filled width for normal time and bonus time
            int normalWidth = Math.Min(elapsedSeconds, totalSeconds) * sectionWidth; // Normal time width
            int bonusWidth = (isBonusActive ? Math.Min(additionalTime, totalSeconds - elapsedSeconds) : 0) * sectionWidth; // Bonus time width

            // Draw normal time section (red)
            using (var redBrush = new SolidBrush(Color.Red))
            {
                Debug.WriteLine("[RED BRUSH]");
                int startX = Math.Max(totalWidth - normalWidth, 0); // Ensure startX is not less than 0
                graphics.FillRectangle(redBrush, new Rectangle(startX, 0, normalWidth, this.ClientRectangle.Height)); // Draw the red rectangle
            }

            // Draw bonus time section (yellow) if active
            if (isBonusActive && bonusWidth > 0)
            {
                Debug.WriteLine("isBonus = true");

                using (var yellowBrush = new SolidBrush(Color.Yellow))
                {
                    Debug.WriteLine("[YELLOW BRUSH");
                    int bonusStartX = Math.Max(totalWidth - normalWidth - bonusWidth, 0); // Start position for the yellow section
                    graphics.FillRectangle(yellowBrush, new Rectangle(bonusStartX, 0, bonusWidth, this.ClientRectangle.Height)); // Draw the yellow rectangle
                }
            }
        }
    }
}
