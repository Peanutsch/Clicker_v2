using System.Drawing;
using System.Windows.Forms;

namespace Clicker_v2
{
    internal class DrawPanelTimerIndicator : Panel
    {
        private int elapsedSeconds = 0;
        private const int totalSeconds = 60;
        private const int colorChangeInterval = 1; // in seconds

        public DrawPanelTimerIndicator()
        {
            InitializeComponent();

            /* Double Buffering (ChatGPT):
             * Performance: Double buffering can improve the visual quality but may have a slight performance impact because 
             *              it uses additional memory for the off-screen buffer.
             * Overriding: In some cases, you may need to override OnPaintBackground as well if you want to ensure that background painting 
             *             is handled properly when double buffering is enabled.
             */
            this.DoubleBuffered = true; // Enable double buffering to reduce flickering

            // Initialize and start the timer with a 1-second interval
            Initializations.InitializeTimerSeconds();
            Initializations.TimerTick += OnTimerTick!;
        }

        private void InitializeComponent()
        {
            // Set default properties for the panel
            this.BackColor = Color.Green;
            this.BorderStyle = BorderStyle.Fixed3D;
            this.Size = new Size(535, 110);
        }

        private void OnTimerTick(object sender, EventArgs e)
        {
            elapsedSeconds += colorChangeInterval;
            this.Invalidate(); // Request to redraw the panel

            if (elapsedSeconds >= totalSeconds)
            {
                //Initializations.StopTimer();
                elapsedSeconds = totalSeconds; // Ensure elapsed time does not exceed total time
                this.Invalidate(); // Force redraw to show the final state
            }
        }

        // Paint Event: changes the panel's color from green to red over 60 seconds
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics graphics = e.Graphics;

            int totalWidth = this.ClientRectangle.Width;
            int sectionWidth = totalWidth / totalSeconds;
            int sectionsToChange = Math.Min(elapsedSeconds, totalSeconds); // Limit to a maximum of 60 sections

            // Define the green and red colors
            Color redColor = Color.FromArgb(255, 0, 0);

            // Draw the red sections, from right to left
            using (var redBrush = new SolidBrush(redColor))
            {
                for (int index = 0; index < sectionsToChange; index++)
                {
                    int xPosition = totalWidth - ((index + 1) * sectionWidth);
                    Rectangle redSection = new Rectangle(xPosition, 0, sectionWidth, this.ClientRectangle.Height);
                    graphics.FillRectangle(redBrush, redSection);
                }
            }
        }
    }
}
