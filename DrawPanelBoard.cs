using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Clicker_v2
{
    /// <summary>
    /// Represents a drawing panel that displays circles on the screen.
    /// It handles the drawing of circles, their positions, and colors.
    /// </summary>
    public class DrawPanelBoard : Panel
    {
        private bool _isPositionInitialized = false; // Flag to check if circle positions are initialized
        private List<Circle> _listCircles = new List<Circle>(); // List to hold circles

        // Public property to access Circles
        public List<Circle> Circles => _listCircles;

        /// <summary>
        /// Initializes a new instance of the DrawPanelBoard class.
        /// Sets up double buffering to reduce flickering and initializes the timer for circle updates.
        /// </summary>
        public DrawPanelBoard()
        {
            // Enable double buffering to reduce flickering
            this.DoubleBuffered = true;

            // Unsubscribe from the timer event to avoid duplicate subscriptions
            RandomizersTimers.TimerTickBoard -= OnTimerTick!;
            // Initialize board timer with the selected interval
            RandomizersTimers.InitializeBoardTimer(Clicker.SelectedInterval);
            // Subscribe to the timer tick event
            RandomizersTimers.TimerTickBoard += OnTimerTick!;
        }

        /// <summary>
        /// Overrides the OnPaint method to draw the circles on the panel.
        /// Initializes circle positions and sizes if not already done.
        /// </summary>
        /// <param name="e">The PaintEventArgs that contains data for the paint event.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Initialize circle position and size if not done yet
            if (!_isPositionInitialized)
            {
                InitializeCirclePositionSize();
                _isPositionInitialized = true;
            }

            // Draw each circle in the list
            foreach (var circle in _listCircles)
            {
                DrawCircle(e.Graphics, circle.CircleSize, circle.X, circle.Y, circle.Color);
            }
        }

        /// <summary>
        /// Initializes the position and size of a new circle.
        /// Adds the circle to the list and removes any circles that have expired based on time.
        /// </summary>
        private void InitializeCirclePositionSize()
        {
            int circleSize = RandomizersTimers.RandomizedCircleSize();
            (int x, int y) = RandomizersTimers.RandomizerPositions(this.Width - circleSize, this.Height - circleSize);

            Color circleColor = RandomizersTimers.GetRandomColor();
            _listCircles.Add(new Circle(x, y, circleSize, circleColor, Clicker.SelectedMaxTime));
            // Remove circles that have exceeded their maximum time
            _listCircles.RemoveAll(c => (DateTime.UtcNow - c.InitTime).TotalMilliseconds > Clicker.SelectedMaxTime);
        }

        /// <summary>
        /// Draws a filled circle at the specified position with the specified size and color.
        /// </summary>
        /// <param name="graphics">The Graphics object used for drawing.</param>
        /// <param name="size">The size of the circle.</param>
        /// <param name="x">The x-coordinate of the circle's position.</param>
        /// <param name="y">The y-coordinate of the circle's position.</param>
        /// <param name="color">The color of the circle.</param>
        private void DrawCircle(Graphics graphics, int size, int x, int y, Color color)
        {
            // If size is negative or circle is outside the panel bounds, skip drawing
            if (size <= 0 || x < 0 || y < 0 || x + size > this.Width || y + size > this.Height)
            {
                Debug.WriteLine("Invalid circle parameters.");
                return; // Skip drawing if parameters are invalid
            }

            // Create a solid brush with the specified color and fill the ellipse
            using (SolidBrush brush = new SolidBrush(color))
            {
                graphics.FillEllipse(brush, new Rectangle(x, y, size, size));
            }
        }

        /// <summary>
        /// Handles the timer tick event to initialize a new circle and refresh the panel.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Event arguments for the timer tick event.</param>
        internal void OnTimerTick(object sender, EventArgs e)
        {
            InitializeCirclePositionSize(); // Initialize new circle
            this.Invalidate(); // Refresh the panel to trigger a repaint
        }

        /// <summary>
        /// Updates the timer interval for the board timer.
        /// </summary>
        /// <param name="interval">The new timer interval in milliseconds.</param>
        public static void UpdateTimerInterval(int interval)
        {
            RandomizersTimers.UpdateBoardTimer(interval); // Update the timer with the new interval
        }
    }
}
