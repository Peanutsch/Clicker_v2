﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Clicker_v2
{
    internal class PointsAndDisplays
    {
        private int _totalSeconds;
        private List<int> listScore = new List<int>();
        public int CurrentScore => listScore.Sum(); // The total score

        private DrawPanelTimerIndicator _drawPanelTimerIndicator;
        private RichTextBox _richTextBoxCountDown;

        // Constructor to initialize _totalSeconds, _drawPanelTimerIndicator, _richTextBoxCountDown
        public PointsAndDisplays(int totalSeconds, DrawPanelTimerIndicator drawPanelTimerIndicator, RichTextBox richTextBoxCountDown)
        {
            _totalSeconds = totalSeconds;
            _drawPanelTimerIndicator = drawPanelTimerIndicator;
            _richTextBoxCountDown = richTextBoxCountDown;
        }

        #region SET POINTS

        /// <summary>
        /// Returns points based on the provided size.
        /// </summary>
        /// <param name="size">The size of the circle, from RandomizersTimers.RandomizedCircleSize.</param>
        /// <returns>The number of points corresponding to the size.</returns>
        public static int ValidateSizeAndPoints(int size)
        {
            return size switch
            {
                >= 10 and < 20 => 50, // Size between 10 - 20: return 50 points
                >= 20 and < 30 => 40, // Size between 20 - 30: return 40 points
                >= 30 and < 50 => 30, // Size between 30 - 50: return 30 points
                >= 50 and < 75 => 20, // Size between 50 - 75: return 20 points
                >= 75 and <= 100 => 10, // Size between 75 - 100: return 10 points
                _ => -5 // Default: return -5 points if outside expected range (miss circle)
            };
        }

        /// <summary>
        /// Penalty when click is miss:
        /// Default: minus 10 points from score
        /// </summary>
        /// <param name="textBoxDisplayScore">Textbox where display the score</param>
        public void PenaltyPoints(TextBox textBoxDisplayScore)
        {
            // Default penalty points: -10
            int penaltyPoints = -10;

            // Check the current total score before applying the penalty
            int currentScore = CurrentScore;

            if (currentScore >= 10)
            {
                // Apply the penalty of -10 points for missing all circles
                int totalScore = CatchScore(penaltyPoints);
                DisplayScore(textBoxDisplayScore, totalScore);

                Debug.WriteLine("End function ClickInCircleRadius with No Hit, penalty applied");
            }
            else
            {
                Debug.WriteLine("End function ClickInCircleRadius with No Hit, penalty not applied");
            }
        }

        /// <summary>
        /// Adds the points to the score list and returns the total score.
        /// </summary>
        /// <param name="points">Points to add.</param>
        /// <returns>The cumulative total score.</returns>
        public int CatchScore(int points)
        {
            listScore.Add(points); // Add points to listScore
            Debug.WriteLine($"Added points: {points}");

            return listScore.Sum(); // Calculate and return sum of listScore
        }

        #endregion

        #region DISPLAY BOXES

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

            textBoxCoords.AppendText(coords + Environment.NewLine);
        }

        /// <summary>
        /// Handles displaying the hit information and updating the score.
        /// </summary>
        /// <param name="circle">The circle that was hit.</param>
        /// <param name="points">The points awarded for hitting the circle.</param>
        /// <param name="textBoxCoords">The TextBox used to display the hit details (color, size, and points).</param>
        /// <param name="drawPanel">The panel containing the circles. The hit circle will be removed from this panel.</param>
        /// <param name="textBoxDisplayScore">The TextBox where the updated total score will be displayed.</param>
        public void DisplayHitAndScores(Circle circle, int points, TextBox textBoxCoords, DrawPanelBoard drawPanel, TextBox textBoxDisplayScore)
        {
            // Handle the valid case (hit)
            textBoxCoords.AppendText(Environment.NewLine + $"{circle.Color}");
            textBoxCoords.AppendText(Environment.NewLine + $"Size: {circle.CircleSize}");
            textBoxCoords.AppendText(Environment.NewLine + $"{points} points" + Environment.NewLine);
            textBoxCoords.TextAlign = HorizontalAlignment.Center;

            // Update the total score by adding the valid points
            int totalScore = CatchScore(points);
            DisplayScore(textBoxDisplayScore, totalScore);

            // Remove the hit circle from the board
            drawPanel.Circles.Remove(circle);
            drawPanel.Refresh();

            Debug.WriteLine("End function ClickInCircleRadius with hit");
        }

        /// <summary>
        /// Handles the case where no circle is hit:
        /// Adjusts the text color for the message and applies a penalty to the score if applicable.
        /// </summary>
        /// <param name="textBoxCoords">The TextBox used to display the "Miss!" message.</param>
        /// <param name="textBoxDisplayScore">The TextBox where the updated total score will be displayed.</param>
        public void DisplayNoHitAndScores(TextBox textBoxCoords, TextBox textBoxDisplayScore)
        {
            int currentScore = CurrentScore;

            if (currentScore >= 5)
            {
                textBoxCoords.ForeColor = Color.DarkRed;
                textBoxCoords.AppendText(Environment.NewLine + "Miss!\r\nPenalty 10 points" + Environment.NewLine);
                textBoxCoords.TextAlign = HorizontalAlignment.Center;
                textBoxCoords.ForeColor = Color.Black;

                // Apply penalty to score
                PenaltyPoints(textBoxDisplayScore);
            }
            else
            {
                textBoxCoords.ForeColor = Color.DarkRed;
                textBoxCoords.AppendText(Environment.NewLine + "Miss!" + Environment.NewLine);
                textBoxCoords.TextAlign = HorizontalAlignment.Center;
                textBoxCoords.ForeColor = Color.Black;
            }
        }

        /// <summary>
        /// Displays the score in the given TextBox.
        /// </summary>
        /// <param name="textBoxDisplayScore">The TextBox where the score will be displayed.</param>
        /// <param name="score">The score to display.</param>
        public void DisplayScore(TextBox textBoxDisplayScore, int score)
        {
            textBoxDisplayScore.DeselectAll();
            textBoxDisplayScore.Text = $"YOUR SCORE\n[{score}]"; // Display score as string
            textBoxDisplayScore.Refresh(); // Refresh the TextBox
        }

        /// <summary>
        /// Updates the countdown timer display.
        /// </summary>
        public void DisplayCountdown(int elapsedSeconds, int totalSeconds)
        {
            // Update the drawPanelTimerIndicator
            _drawPanelTimerIndicator.Invalidate();

            // Update the richTextBoxCountdown with the remaining time
            int remainingSeconds = totalSeconds - elapsedSeconds;
            _richTextBoxCountDown.Text = $"Time left: {remainingSeconds} seconds";
        }
        #endregion
    }
}
