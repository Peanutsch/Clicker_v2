using System.Drawing;
using System.Windows.Forms;

namespace Clicker_v2
{
    /// <summary>
    /// Represents a timer indicator panel that visually indicates elapsed time.
    /// The panel changes color and fills from right to left as time progresses.
    /// It also supports bonus time that modifies the visual representation.
    /// </summary>
    internal class DrawPanelTimerIndicator : Panel
    {
        internal const int totalSeconds = 31; // Total duration of the timer in seconds
        private int elapsedSeconds = 0; // Keeps track of the elapsed seconds
        private int bonusSeconds = 0; // Track bonus seconds
        private bool isBonusActive = false; // Track if the bonus time is active

        private readonly ClickManager _clickManager; // Reference to the ClickManager

        internal const int colorChangeInterval = 1; // Interval for color change in seconds

        /// <summary>
        /// Initializes a new instance of the <see cref="DrawPanelTimerIndicator"/> class.
        /// Sets up double buffering to reduce flickering and initializes the timer for updates.
        /// </summary>
        /// <param name="clickManager">The <see cref="ClickManager"/> instance used to manage click events and bonus time.</param>
        public DrawPanelTimerIndicator(ClickManager clickManager)
        {
            _clickManager = clickManager;

            this.DoubleBuffered = true;

            Inits.TimerTickIndicator -= OnTimerTick!; // Unsubscribe to avoid duplicate subscriptions
            Inits.InitializeIndicatorTimer(); // Initialize the timer
            Inits.TimerTickIndicator += OnTimerTick!; // Subscribe to the timer tick event
        }

        /// <summary>
        /// Handles the timer tick event. Updates the elapsed time and redraws the panel.
        /// If bonus time is activated, changes the background color to green during bonus time.
        /// Resets the bonus after the defined duration.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Event arguments for the timer tick event.</param>
        internal void OnTimerTick(object sender, EventArgs e)
        {
            // Check if we need to add bonus time
            if (_clickManager != null && _clickManager.plusTime && !isBonusActive)
            {
                bonusSeconds += 2; // Add 2 bonus seconds
                isBonusActive = true; // Set bonus active
                this.BackColor = Color.Green; // Change color to green during bonus time
            }

            elapsedSeconds += colorChangeInterval; // Increment elapsed seconds
            this.Invalidate(); // Redraw the panel

            // Reset the bonus after 2 seconds of green
            if (isBonusActive && bonusSeconds <= 0)
            {
                isBonusActive = false;
                this.BackColor = Color.Red; // Revert color back to red
            }

            // Decrease bonusSeconds only when active
            if (isBonusActive)
            {
                bonusSeconds--;
            }

            // Cap elapsed time to total seconds
            if (elapsedSeconds >= totalSeconds)
            {
                elapsedSeconds = totalSeconds; // Ensure elapsed time does not exceed total
                this.BackColor = Color.Red; // Final red color when time is up
                this.Invalidate(); // Redraw to show the final state in red
            }
        }

        /// <summary>
        /// Overrides the OnPaint method to draw the timer indicator.
        /// Fills the panel from right to left based on elapsed time and bonus time.
        /// </summary>
        /// <param name="e">The PaintEventArgs that contains data for the paint event.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics graphics = e.Graphics;

            int totalWidth = this.ClientRectangle.Width; // Total width of the panel
            int sectionWidth = totalWidth / totalSeconds; // Calculate the width of each section

            // Calculate width based on total elapsed + bonus seconds
            int filledWidth = Math.Min(elapsedSeconds + bonusSeconds, totalSeconds) * sectionWidth;

            Color fillColor = isBonusActive ? Color.Green : Color.Red; // Choose color based on bonus time
            using (var brush = new SolidBrush(fillColor))
            {
                int startX = totalWidth - filledWidth; // Calculate the starting x position for the filled rectangle
                startX = Math.Max(startX, 0); // Ensure the starting x position is not less than 0
                graphics.FillRectangle(brush, new Rectangle(startX, 0, filledWidth, this.ClientRectangle.Height)); // Draw the filled rectangle
            }
        }
    }
}
