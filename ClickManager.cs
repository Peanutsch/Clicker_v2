using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Clicker_v2
{
    internal class ClickManager
    {
        private Dictionary<Color, (int x, int y)> _dictColorsAndCoords;
        private TextBox _textBoxHitMiss;
        private List<Circle> _listCircles;

        // Constructor to initialize dependencies
        public ClickManager(Dictionary<Color, (int x, int y)> dictColorsAndCoords, TextBox textBoxHitMiss, List<Circle> listCircles)
        {
            _dictColorsAndCoords = dictColorsAndCoords;
            _textBoxHitMiss = textBoxHitMiss;
            _listCircles = listCircles; // Correctly assign the parameter
        }

        // Method to display and return coordinates
        public void DisplayClickCoords(int clickX, int clickY, TextBox textBoxCoords)
        {
            string coords = $"({clickX}, {clickY})";
            Debug.WriteLine($"Mouse click at {coords}");

            // Update TextBox directly without selecting all text
            textBoxCoords.AppendText(coords + Environment.NewLine);
            //textBoxCoords.SelectAll();
            textBoxCoords.TextAlign = HorizontalAlignment.Center;
            //textBoxCoords.DeselectAll();
        }

        /* ChatGPT:
        * This method uses a GraphicsPath to draw an ellipse (in this case, a circle)
        * and then checks if the click point (clickX, clickY) is within that circle.
        * This is done using the IsVisible method of GraphicsPath.
        */
        public bool IsPointInCircle(int clickX, int clickY, Circle circle)
        {
            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddEllipse(circle.X, circle.Y, circle.CircleSize, circle.CircleSize);
                return path.IsVisible(clickX, clickY);
            }
        }

        /* ChatGPT:
         * This method iterates through all circles in the _listCircles list and checks
         * using the IsPointInCircle method if the click point is within any of the circles.
         * If it is, a "Hit" is registered, and a message is displayed in the textBoxCoords.
         * If no circle is hit, a "Miss!" message is displayed.
         */
        public void ClickInCircleRadius(int clickX, int clickY, TextBox textBoxCoords)
        {
            Debug.WriteLine("Start function ClickInCircleRadius");
            bool isHit = false;

            foreach (var circle in _listCircles)
            {
                Debug.WriteLine($"Circle: {_listCircles}");

                // Use the new IsPointInCircle method to determine if the point is within the circle
                if (IsPointInCircle(clickX, clickY, circle))
                {
                    isHit = true;
                    textBoxCoords.AppendText($"Hit with {circle.Color}" + Environment.NewLine);
                    textBoxCoords.TextAlign = HorizontalAlignment.Center;

                    Debug.WriteLine("End function ClickInCircleRadius with hit");
                    break;  // Stop the loop if a hit is found
                }
            }

            if (!isHit)
            {
                // No hit
                textBoxCoords.AppendText("Miss!" + Environment.NewLine);
                textBoxCoords.TextAlign = HorizontalAlignment.Center;

                Debug.WriteLine("End function ClickInCircleRadius with No Hit");
            }
        }
    }
}
