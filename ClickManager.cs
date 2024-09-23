using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Clicker_v2
{
    internal class ClickManager
    {
        private TextBox textBoxHitMiss;
        private List<Circle> listCircles;
        private ScoreManager scoreManager;
        private TextBox textBoxDisplayScore;

        public bool AddBonusTime { get; set; } = false; // New flag to indicate bonus time

        public ClickManager(TextBox textBoxHitMiss, List<Circle> circles, ScoreManager scoreManager, TextBox textBoxDisplayScore)
        {
            this.textBoxHitMiss = textBoxHitMiss;
            this.listCircles = circles;
            this.scoreManager = scoreManager;
            this.textBoxDisplayScore = textBoxDisplayScore;
        }

        /// <summary>
        /// Checks if a point (clickX, clickY) is within the specified circle.
        /// </summary>
        /// <param name="clickX">The x-coordinate of the mouse click.</param>
        /// <param name="clickY">The y-coordinate of the mouse click.</param>
        /// <param name="circle">The circle to check against.</param>
        /// <returns>True if the point is within the circle, otherwise false.</returns>
        public bool IsPointInCircle(int clickX, int clickY, Circle circle)
        {
            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddEllipse(circle.X, circle.Y, circle.CircleSize, circle.CircleSize);
                return path.IsVisible(clickX, clickY);
            }
        }

        /// <summary>
        /// Handles a mouse click event to check if the click is within any circles.
        /// Displays hit/miss results and updates the score accordingly.
        /// </summary>
        /// <param name="clickX">The x-coordinate of the mouse click.</param>
        /// <param name="clickY">The y-coordinate of the mouse click.</param>
        /// <param name="textBoxCoords">The TextBox to display the results.</param>
        /// <param name="drawPanel">The panel that contains the circles.</param>
        public void ClickInCircleRadius(int clickX, int clickY, TextBox textBoxCoords, DrawPanelBoard drawPanel)
        {
            bool isHit = false;

            foreach (var circle in drawPanel.Circles)
            {
                if (IsPointInCircle(clickX, clickY, circle))
                {
                    isHit = true;
                    AddBonusTime = true; // Set bonus time flag when hit
                    int points = ScoreManager.ValidateSizeAndPoints(circle.CircleSize);
                    scoreManager.HandleMissAndScores(circle, points, textBoxCoords, drawPanel, textBoxDisplayScore);
                    break;
                }
            }

            if (!isHit)
            {
                AddBonusTime = false; // Reset the flag when missed
                scoreManager.HandleMissAndScores(textBoxCoords, textBoxDisplayScore);
            }
        }
    }
}
