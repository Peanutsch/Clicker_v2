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
        #region TIMER VALUES
        internal const int totalSeconds = 30; // Total duration of the timer in seconds\
        private int bonusSeconds = 0; // Bonus time in seconds
        private int elapsedSeconds = 0; // Elapsed time in seconds
        internal const int colorChangeInterval = 1; // The interval for color change in seconds
        #endregion

        private bool isBonusActive = false; // Indicates if bonus time is active
        private readonly ClickManager _clickManager; // Reference to ClickManager for managing clicks and bonus time

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
        /// Handles the timer tick event to update the elapsed time and redraw the panel.
        /// Manages the activation and deactivation of bonus time and updates the panel's background color.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Event arguments for the timer tick event.</param>
        internal void OnTimerTick(object sender, EventArgs e)
        {
            elapsedSeconds += colorChangeInterval; // Increment the elapsed time by the interval
            this.Invalidate(); // Redraw the panel

            // Activate bonus time if conditions are met
            if (_clickManager != null && _clickManager.plusTime && !isBonusActive)
            {
                bonusSeconds += 50; // Add bonus seconds
                isBonusActive = true;
                this.BackColor = Color.White; // Change background to green during bonus time
                
                Debug.WriteLine($"Bonus Activated: Bonus Seconds: {bonusSeconds}, Elapsed Time: {elapsedSeconds}");
            }

            // Manage bonus time countdown and deactivation
            if (isBonusActive)
            {
                //bonusSeconds--; // Decrease bonus time
                if (bonusSeconds <= 0)
                {
                    isBonusActive = false; // Deactivate bonus
                    this.BackColor = Color.Red; // Revert background to red
                }
            }

            // Cap elapsed time to total time and handle end state
            if (elapsedSeconds >= totalSeconds)
            {
                elapsedSeconds = totalSeconds;
                this.BackColor = Color.Red; // Final red color when time is up
            }

            Debug.WriteLine($"End OnTimerTick: Is Bonus Active: {isBonusActive}");

            this.Invalidate(); // Request redraw of the panel
        }

        /// <summary>
        /// Overrides the OnPaint method to visually represent the timer's progress.
        /// The panel is filled from right to left, with sections colored red for normal time and green for bonus time.
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
            int normalWidth = Math.Min(elapsedSeconds, totalSeconds) * sectionWidth;
            int bonusWidth = Math.Min(bonusSeconds, totalSeconds - elapsedSeconds) * sectionWidth;

            if (!isBonusActive)
            {
                // Draw the normal time section (red)
                using (var redBrush = new SolidBrush(Color.Red))
                {
                    Debug.WriteLine($"[RED BRUSH] Elapsed Seconds: {elapsedSeconds}");

                    int startX = totalWidth - normalWidth; // Start position for the red section
                    startX = Math.Max(startX, 0); // Ensure startX is not less than 0
                    graphics.FillRectangle(redBrush, new Rectangle(startX, 0, normalWidth, this.ClientRectangle.Height)); // Draw the red rectangle
                }
            }

            // Draw the bonus time section (yellow) if active
            //if (isBonusActive && bonusSeconds > 0)
            else
            {
                Debug.WriteLine($"[YEWLLOWBRUSH] Elapsed Seconds: {elapsedSeconds}, isBonus: {isBonusActive}, Bonus Seconds: {bonusSeconds}");

                using (var yellowBrush = new SolidBrush(Color.Yellow))
                {
                    Debug.WriteLine("YellowBrush active");

                    int bonusStartX = totalWidth - normalWidth - bonusWidth; // Start position for the green section
                    bonusStartX = Math.Max(bonusStartX, 0); // Ensure bonusStartX is not less than 0
                    graphics.FillRectangle(yellowBrush, new Rectangle(bonusStartX, 0, bonusWidth, this.ClientRectangle.Height)); // Draw the green rectangle
                }
            }
        }
    }
}
