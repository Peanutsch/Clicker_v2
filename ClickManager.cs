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

            if (drawPanel.Circles.Count == 0)
            {
                Debug.WriteLine("_listCircles is empty");
                return;
            }

            foreach (var circle in drawPanel.Circles)
            {
                // Check if the click is within any circle
                if (IsPointInCircle(clickX, clickY, circle))
                {
                    isHit = true;
                    // Validate points based on the size of the circle
                    int points = ScoreManager.ValidateSizeAndPoints(circle.CircleSize);
                    //AdjustTimer(1);

                    if (points == 0)
                    {
                        // Handle the invalid circle size case
                        isHit = false;
                    }
                    else
                    {
                        // Handle when hit
                        scoreManager.HandleMissAndScores(circle, points, textBoxCoords, drawPanel, textBoxDisplayScore);
                    }
                    break;  // Stop loop when a hit is detected
                }
            }

            if (!isHit)
            {
                // Handle when miss
                scoreManager.HandleMissAndScores(textBoxCoords, textBoxDisplayScore);
            }
        }

        public void AdjustTimer(int timeadjustment)
        {
            // if (isHit)
            // {
            // totalSeconds++
            // timerIndicator ++ green
            // countdownBox++ 
            // }
        }
    }
}
