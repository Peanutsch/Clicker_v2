using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Clicker_v2
{
    public class DrawPanelBoard : Panel
    {
        private bool _isPositionInitialized = false;
        private List<Circle> _allCircles = new List<Circle>();

        public DrawPanelBoard()
        {
            this.DoubleBuffered = true; // Rendering panel in off-screen buffering to reduce flickering

            Initializations.InitializeTimer(Clicker.SelectedInterval);
            Initializations.TimerTick += OnTimerTick;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (!_isPositionInitialized)
            {
                InitializeCirclePositionSize();
                _isPositionInitialized = true;
            }

            foreach (var circle in _allCircles)
            {
                DrawCircle(e.Graphics, circle.CircleSize, circle.X, circle.Y, circle.Color);
            }
        }

        private void InitializeCirclePositionSize()
        {
            int circleSize = Initializations.RandomizedCircleSize();
            (int x, int y) = Initializations.RandomizerPositions(this.Width - circleSize, this.Height - circleSize);

            Color circleColor = Initializations.GetRandomColor();
            _allCircles.Add(new Circle(x, y, circleSize, circleColor, Clicker.SelectedMaxTime));

            _allCircles.RemoveAll(c => (DateTime.UtcNow - c.InitTime).TotalMilliseconds > Clicker.SelectedMaxTime);
        }

        // Draw colour filled circle
        private void DrawCircle(Graphics graphics, int size, int x, int y, Color color)
        {
            // If negative sizes or outside the panel bounds
            if (size <= 0 || x < 0 || y < 0 || x + size > this.Width || y + size > this.Height)
            {
                Debug.WriteLine("Invalid circle parameters.");
                return; // Skip drawing if parameters are invalid
            }

            using (SolidBrush brush = new SolidBrush(color))
            {
                graphics.FillEllipse(brush, new Rectangle(x, y, size, size));
            }
        }

        // 
        private void OnTimerTick(object sender, EventArgs e)
        {
            /*
             * Double Buffering (ChatGPT):
             * Performance: Double buffering can improve the visual quality but may have a slight performance impact because 
             *              it uses additional memory for the off-screen buffer.
             * Overriding: In some cases, you may need to override OnPaintBackground as well if you want to ensure that background painting 
             *             is handled properly when double buffering is enabled.
             */
            InitializeCirclePositionSize();
            this.Invalidate(); // Redraw drawPanel
        }

        public static void UpdateTimerInterval(int interval)
        {
            Initializations.UpdateTimer(interval);
        }
    }
}
