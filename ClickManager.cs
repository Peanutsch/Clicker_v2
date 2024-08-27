using Clicker_v2;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using static System.Formats.Asn1.AsnWriter;

namespace Clicker_v2
{
    internal class ClickManager
    {
        private TextBox _textBoxHitMiss;
        private List<Circle> _listCircles;
        private PointsAndDisplays _pointsAndDisplays;

        TextBox textBoxDisplayScore;

        // Constructor to initialize dependencies
        /// <summary>
        /// Initializes a new instance of the ClickManager class.
        /// </summary>
        /// <param name="textBoxHitMiss">TextBox for displaying hit/miss messages.</param>
        /// <param name="circles">List of circles to manage clicks against.</param>
        /// <param name="pointsAndDisplays">Object for handling score and display logic.</param>
        /// <param name="textBoxDisplayScore">TextBox for displaying the current score.</param>
        public ClickManager(TextBox textBoxHitMiss, List<Circle> circles, PointsAndDisplays pointsAndDisplays, TextBox textBoxDisplayScore)
        {
            _textBoxHitMiss = textBoxHitMiss;
            _listCircles = circles;
            _pointsAndDisplays = pointsAndDisplays;
            this.textBoxDisplayScore = textBoxDisplayScore;
        }

        // Method to display and return coordinates in textBoxCoords
        /// <summary>
        /// Displays the coordinates of a mouse click in the specified TextBox.
        /// </summary>
        /// <param name="clickX">The x-coordinate of the mouse click.</param>
        /// <param name="clickY">The y-coordinate of the mouse click.</param>
        /// <param name="textBoxCoords">The TextBox to update with coordinates.</param>
        public void DisplayClickCoords(int clickX, int clickY, TextBox textBoxCoords)
        {
            string coords = $"({clickX}, {clickY})";
            Debug.WriteLine($"Mouse click at {coords}");

            // Update TextBox directly without selecting all text
            // textBoxCoords.AppendText(coords + Environment.NewLine);
            // textBoxCoords.TextAlign = HorizontalAlignment.Center;
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
                Debug.WriteLine($"Checking circle at [X={circle.X}, Y={circle.Y}, Size={circle.CircleSize}]");

                // Check if the click is within any circle
                if (IsPointInCircle(clickX, clickY, circle))
                {
                    isHit = true;

                    // Validate points based on the size of the circle
                    int points = PointsAndDisplays.ValidateSizeAndPoints(circle.CircleSize);

                    if (points == -5)
                    {
                        // Handle the invalid circle size case
                        textBoxCoords.ForeColor = Color.DarkRed;
                        textBoxCoords.AppendText(Environment.NewLine + "Miss!" + Environment.NewLine);
                        textBoxCoords.TextAlign = HorizontalAlignment.Center;
                        textBoxCoords.ForeColor = Color.Black;
                    }
                    else
                    {
                        // Handle the valid case (hit)
                        textBoxCoords.AppendText(Environment.NewLine + $"{circle.Color}");
                        textBoxCoords.AppendText(Environment.NewLine + $"Size: {circle.CircleSize}");
                        textBoxCoords.AppendText(Environment.NewLine + $"{points} points" + Environment.NewLine);
                        textBoxCoords.TextAlign = HorizontalAlignment.Center;

                        // Update the total score by adding the valid points
                        int totalScore = _pointsAndDisplays.CatchScore(points);
                        _pointsAndDisplays.DisplayScore(textBoxDisplayScore, totalScore);

                        // Remove the hit circle from the board
                        drawPanel.Circles.Remove(circle);

                        Debug.WriteLine("End function ClickInCircleRadius with hit");
                    }
                    break;  // Stop loop when a hit is detected
                }
            }

            if (!isHit)
            {
                // Handle the case where no circle is hit
                textBoxCoords.ForeColor = Color.DarkRed;
                textBoxCoords.AppendText(Environment.NewLine + "Miss!" + Environment.NewLine);
                textBoxCoords.TextAlign = HorizontalAlignment.Center;
                textBoxCoords.ForeColor = Color.Black;

                // Check the current total score before applying the penalty
                int currentScore = _pointsAndDisplays.CurrentScore; // Assuming CurrentScore is a property that returns the total score.

                if (currentScore >= 5)
                {
                    // Apply the penalty of -10 points for missing all circles
                    int totalScore = _pointsAndDisplays.CatchScore(-10);
                    _pointsAndDisplays.DisplayScore(textBoxDisplayScore, totalScore);

                    Debug.WriteLine("End function ClickInCircleRadius with No Hit, penalty applied");
                }
                else
                {
                    Debug.WriteLine("End function ClickInCircleRadius with No Hit, penalty not applied");
                }
            }
        }
    }
}
