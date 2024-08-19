using System.Drawing;
using System.Windows.Forms;

namespace Clicker_v2
{
    internal class DrawPanelTimerIndicator : Panel
    {
        private int elapsedSeconds = 0;
        internal const int totalSeconds = 10;
        internal const int colorChangeInterval = 1; // in seconds

        public DrawPanelTimerIndicator()
        {
            /* Double Buffering (ChatGPT):
             * Performance: Double buffering can improve the visual quality but may have a slight performance impact because 
             *              it uses additional memory for the off-screen buffer.
             * Overriding: In some cases, you may need to override OnPaintBackground as well if you want to ensure that background painting 
             *             is handled properly when double buffering is enabled.
             */
            this.DoubleBuffered = true; // Enable double buffering to reduce flickering

            // Initialize and start the timer with a 1-second interval
            Initializations.TimerTickIndicator -= OnTimerTick!; // Unsubscribe
            Initializations.InitializeIndicatorTimer();
            Initializations.TimerTickIndicator += OnTimerTick!; // Subscribe
        }

        internal void OnTimerTick(object sender, EventArgs e)
        {
            elapsedSeconds += colorChangeInterval;
            this.Invalidate(); // Request to redraw the panel

            if (elapsedSeconds >= totalSeconds)
            {
                //Initializations.StopTimer();
                elapsedSeconds = totalSeconds; // Ensure elapsed time does not exceed total time
                this.BackColor = Color.Red; // Set the background color to red
                this.Invalidate(); // Force redraw to show the final state
            }
        }

        // Changes the panel's color from green to red over x seconds, from right to left
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics graphics = e.Graphics;

            // Total width of the panel
            int totalWidth = this.ClientRectangle.Width;

            // Calculate the width of each section
            int sectionWidth = totalWidth / totalSeconds;

            // Calculate the width of the filled red section
            int filledWidth = Math.Min(elapsedSeconds, totalSeconds) * sectionWidth;

            // Define the colors
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