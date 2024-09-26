using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Numerics;
using System.Windows.Forms;

namespace Clicker_v2
{
    /// <summary>
    /// Manages the score and timer for the Clicker game.
    /// Tracks scores, applies penalties for missed clicks, and updates the UI elements accordingly.
    /// </summary>
    internal class ScoreManager
    {
        private int totalSeconds;
        private List<int> listScore = new List<int>();
        public int CurrentScore => listScore.Sum(); // The total score

        private PanelTimerIndicator drawPanelTimerIndicator;
        private RichTextBox richTextBoxCountDown;

        /// <summary>
        /// Constructor to initialize the ScoreManager with total time and UI components.
        /// </summary>
        /// <param name="totalSeconds">Total seconds for the game timer.</param>
        /// <param name="drawPanelTimerIndicator">The indicator for the timer display.</param>
        /// <param name="richTextBoxCountDown">The RichTextBox for countdown display.</param>
        public ScoreManager(int totalSeconds, PanelTimerIndicator drawPanelTimerIndicator, RichTextBox richTextBoxCountDown)
        {
            this.totalSeconds = totalSeconds;
            this.drawPanelTimerIndicator = drawPanelTimerIndicator;
            this.richTextBoxCountDown = richTextBoxCountDown;
        }

        #region SCORE METHODS

        /// <summary>
        /// Returns points based on the provided size.
        /// </summary>
        /// <param name="size">The size of the circle, from RandomizersTimers.RandomizedCircleSize.</param>
        /// <returns>The number of points corresponding to the size.</returns>
        public static int ValidateSizeAndPoints(int size)
        {
            return size switch
            {
                >= 10 and < 20 => 25, // Size between 10 - 20: return 25 points
                >= 20 and < 30 => 10, // Size between 20 - 30: return 10 points
                >= 30 and < 50 => 5, // Size between 30 - 50: return 5 points
                >= 50 and < 75 => 4, // Size between 50 - 75: return 4 points
                >= 75 and <= 100 => 2, // Size between 75 - 100: return 2 points
                _ => 0 // Default: return 0 points if outside expected range (miss circle)
            };
        }

        /// <summary>
        /// Applies a penalty when a click misses a target.
        /// Default penalty: minus 10 points from the score.
        /// </summary>
        /// <param name="textBoxDisplayScore">Textbox where the score is displayed.</param>
        public void PenaltyPoints(TextBox textBoxDisplayScore)
        {
            // Default penalty points: 10
            int penaltyPoints = -10;

            // Validate the current total score before applying the penalty
            int currentScore = CurrentScore;

            // Simulate applying the penalty to check if score becomes negative
            int validateScore = currentScore + penaltyPoints;

            if (validateScore < 0) // If score is negative, set it to zero
            {
                listScore.Clear();  // Clear the score list, total score is zero
                DisplayScore(textBoxDisplayScore, 0); // Display total score = zero
            }
            else
            {
                // Apply the penalty
                int totalScore = CatchScore(penaltyPoints);  // Add the negative penaltyPoints
                DisplayScore(textBoxDisplayScore, totalScore);
            }
        }

        /// <summary>
        /// Increments the time when a valid hit occurs. (Method currently unimplemented)
        /// </summary>
        public void ManageTime(int time)
        {
            // When valid hit, time ++ 
        }

        /// <summary>
        /// Adds the points to the score list and returns the total score.
        /// </summary>
        /// <param name="points">Points to add.</param>
        /// <returns>The cumulative total score.</returns>
        public int CatchScore(int points)
        {
            listScore.Add(points); // Add points (which could be negative) to listScore
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
        /// Handles displaying the hit information and updating the score for a valid hit.
        /// </summary>
        /// <param name="circle">The circle that was hit.</param>
        /// <param name="points">The points awarded for hitting the circle.</param>
        /// <param name="textBoxCoords">The TextBox used to display the hit details (color, size, and points).</param>
        /// <param name="drawPanel">The panel containing the circles. The hit circle will be removed from this panel.</param>
        /// <param name="textBoxDisplayScore">The TextBox where the updated total score will be displayed.</param>
        public void HandleMissAndScores(Circle circle, int points, TextBox textBoxCoords, PanelBoardCircles drawPanel, TextBox textBoxDisplayScore)
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
        public void HandleMissAndScores(TextBox textBoxCoords, TextBox textBoxDisplayScore)
        {
            int currentScore = CurrentScore;

            if (currentScore > 0)
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
        /// Displays the current score in the specified TextBox.
        /// </summary>
        /// <param name="textBoxDisplayScore">The TextBox where the score will be displayed.</param>
        /// <param name="score">The score to display.</param>
        public void DisplayScore(TextBox textBoxDisplayScore, int score)
        {
            textBoxDisplayScore.Text = $"YOUR SCORE\r\n[{score}]"; // Display score as string
            textBoxDisplayScore.Refresh(); // Refresh the TextBox
        }

        /// <summary>
        /// Updates the countdown timer display in the UI.
        /// </summary>
        /// <param name="elapsedSeconds">The number of seconds that have elapsed.</param>
        /// <param name="totalSeconds">The total number of seconds for the countdown.</param>
        public void DisplayCountdown(int elapsedSeconds, int totalSeconds)
        {
            // Update the drawPanelTimerIndicator
            drawPanelTimerIndicator.Invalidate();

            // Update the richTextBoxCountdown with the remaining time
            int remainingSeconds = totalSeconds - elapsedSeconds;
            richTextBoxCountDown.SelectionAlignment = HorizontalAlignment.Center;
            richTextBoxCountDown.Text = $"Time left: {remainingSeconds}";
        }
        #endregion
    }
}
