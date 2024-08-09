using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Clicker
{
    public class Draw : Panel
    {
        private bool _isPositionInitialized = false;
        private List<Circle> _allCircles = new List<Circle>();

        public Draw()
        {
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
            using (SolidBrush brush = new SolidBrush(color))
            {
                graphics.FillEllipse(brush, new Rectangle(x, y, size, size));
            }
        }

        // 
        private void OnTimerTick(object sender, EventArgs e)
        {
            InitializeCirclePositionSize();
            this.Invalidate(); // Redraw drawPanel
            this.DoubleBuffered = true;
        }

        public static void UpdateTimerInterval(int interval)
        {
            Initializations.UpdateTimer(interval);
        }
    }
}
