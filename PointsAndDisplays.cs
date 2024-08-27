using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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
        /// Displays the score in the given TextBox.
        /// </summary>
        /// <param name="textBoxDisplayScore">The TextBox where the score will be displayed.</param>
        /// <param name="score">The score to display.</param>
        public void DisplayScore(TextBox textBoxDisplayScore, int score)
        {
            textBoxDisplayScore.DeselectAll();
            textBoxDisplayScore.Text = $"\r\n\r\nYOUR SCORE\r\n[{score.ToString()}]"; // Display score as string
            textBoxDisplayScore.Refresh(); // Refresh the TextBox

            //Debug.WriteLine($"listScore: {score}");
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
