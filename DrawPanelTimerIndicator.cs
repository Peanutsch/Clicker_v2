using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Clicker_v2
{
    internal class DrawPanelTimerIndicator : Panel
    {
        private int elapsedSeconds = 0;
        private const int totalSeconds = 30;
        private const int colorChangeInterval = 1; // in seconds

        public DrawPanelTimerIndicator()
        {
            InitializeComponent();
            this.DoubleBuffered = true; // Rendering panel in off-screen buffering to reduce flickering

            Initializations.InitializeTimer(colorChangeInterval * 1000);
            Initializations.TimerTick += OnTimerTick;
        }

        private void InitializeComponent()
        {
            // Set default properties for the panel
            this.BackColor = Color.DarkRed;
            this.BorderStyle = BorderStyle.Fixed3D;
            this.Size = new Size(535, 110);
        }

        private void OnTimerTick(object sender, EventArgs e)
        {
            /*
             * Double Buffering (ChatGPT):
             * Performance: Double buffering can improve the visual quality but may have a slight performance impact because 
             *              it uses additional memory for the off-screen buffer.
             * Overriding: In some cases, you may need to override OnPaintBackground as well if you want to ensure that background painting 
             *             is handled properly when double buffering is enabled.
             */

            elapsedSeconds += colorChangeInterval;
            this.Invalidate(); // Redraw the panel
            this.DoubleBuffered = true; // Rendering panel in off-screen buffering to reduce flickering

            if (elapsedSeconds >= totalSeconds)
            {
                Initializations.StopTimer();
                elapsedSeconds = totalSeconds; // Clamp to total seconds to avoid exceeding the range
                this.Invalidate(); // Force redraw to show final color
            }
        }

        // Paint Event
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using (var graphics = e.Graphics)
            {
                // Calculate the percentage of color transition
                float percentage = (float)elapsedSeconds / totalSeconds;
                percentage = Math.Clamp(percentage, 0f, 1f); // Ensure percentage is between 0 and 1

                // Define the colors for the gradient transition from green to red
                Color startColor = Color.FromArgb(0, 255, 0); // Green
                Color endColor = Color.FromArgb(255, 0, 0); // Red

                // Calculate intermediate color based on the percentage
                int redValue = (int)(startColor.R + (endColor.R - startColor.R) * percentage);
                int greenValue = (int)(startColor.G + (endColor.G - startColor.G) * (1 - percentage));
                int blueValue = (int)(startColor.B + (endColor.B - startColor.B) * (1 - percentage));

                // Define the colors for the gradient
                Color gradientColor = Color.FromArgb(redValue, greenValue, blueValue);

                // Draw a gradient from left to right
                using (var brush = new LinearGradientBrush(
                    this.ClientRectangle,
                    gradientColor, // Intermediate color
                    endColor, // End color
                    LinearGradientMode.Horizontal))
                {
                    graphics.FillRectangle(brush, this.ClientRectangle);
                }
            }
        }

    }
}
