using System.Drawing;
using System.Windows.Forms;

namespace Clicker_v2
{
    /// <summary>
    /// Represents a timer indicator panel that visually indicates elapsed time.
    /// The panel changes color and fills from right to left as time progresses.
    /// </summary>
    internal class DrawPanelTimerIndicator : Panel
    {
        private int elapsedSeconds = 0; // Keeps track of the elapsed seconds
        internal const int totalSeconds = 500; // Total duration of the timer in seconds
        internal const int colorChangeInterval = 1; // Interval for color change in seconds

        /// <summary>
        /// Initializes a new instance of the DrawPanelTimerIndicator class.
        /// Sets up double buffering to reduce flickering and initializes the timer for updates.
        /// </summary>
        public DrawPanelTimerIndicator()
        {
            // Enable double buffering to reduce flickering
            this.DoubleBuffered = true;

            // Initialize and start the timer with a 1-second interval
            RandomizersTimers.TimerTickIndicator -= OnTimerTick!; // Unsubscribe to avoid duplicate subscriptions
            RandomizersTimers.InitializeIndicatorTimer(); // Initialize the timer
            RandomizersTimers.TimerTickIndicator += OnTimerTick!; // Subscribe to the timer tick event
        }

        /// <summary>
        /// Handles the timer tick event.
        /// Updates the elapsed time and redraws the panel.
        /// If the total time is reached, changes the background color to red.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Event arguments for the timer tick event.</param>
        internal void OnTimerTick(object sender, EventArgs e)
        {
            elapsedSeconds += colorChangeInterval; // Increment elapsed seconds
            this.Invalidate(); // Redraw the panel

            // Check if the total time has been reached
            if (elapsedSeconds >= totalSeconds)
            {
                elapsedSeconds = totalSeconds; // Cap elapsed time to total seconds
                this.BackColor = Color.Red; // Set the background color to red
                this.Invalidate(); // Redraw to show the final state in red
            }
        }

        /// <summary>
        /// Overrides the OnPaint method to draw the timer indicator.
        /// Fills the panel from right to left based on elapsed time.
        /// </summary>
        /// <param name="e">The PaintEventArgs that contains data for the paint event.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics graphics = e.Graphics;

            // Total width of the panel
            int totalWidth = this.ClientRectangle.Width;

            // Calculate the width of each section based on total time
            int sectionWidth = totalWidth / totalSeconds;

            // Calculate the width of the filled red section based on elapsed seconds
            int filledWidth = Math.Min(elapsedSeconds, totalSeconds) * sectionWidth;

            // Define the color for the filled section
            Color redColor = Color.Red;

            using (var redBrush = new SolidBrush(redColor))
            {
                // Draw the red filled section from right to left

                // Calculate the starting x position for the filled rectangle
                int startX = totalWidth - filledWidth;

                // Ensure the starting x position is not less than 0
                startX = Math.Max(startX, 0);

                // Draw the red filled rectangle
                graphics.FillRectangle(redBrush, new Rectangle(startX, 0, filledWidth, this.ClientRectangle.Height));
            }
        }
    }
}
