using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Clicker_v2
{
    internal class PointsAndDisplays
    {
        //private int _elapsedSeconds = 0;
        private int _totalSeconds;
        private List<int> listScore = new List<int>();

        private DrawPanelTimerIndicator _drawPanelTimerIndicator;
        private RichTextBox _richTextBoxCountDown;
        
        // Constructor initialize _totalSeconds en GUI components
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
                _ => 0 // Default: return 0 points if outside expected range
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
            return listScore.Sum(); // Calculate and return sum listScore
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
            textBoxDisplayScore.Text = score.ToString(); // Display score as string
            textBoxDisplayScore.Refresh(); // Ververs de TextBox
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
