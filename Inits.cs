using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Clicker_v2
{
    /// <summary>
    /// Contains initialization methods and utility functions for the Clicker game.
    /// Handles timers, randomizers, and path initialization.
    /// </summary>
    public class Inits
    {
        private static System.Windows.Forms.Timer? _boardTimer; // Timer for the game board
        private static System.Windows.Forms.Timer? _indicatorTimer; // Timer for the indicator
        private static Stopwatch? _stopwatch; // Stopwatch to track elapsed time

        private static PanelBoardCircles? drawPanelBoard;

        // Initialize and return root path including directory \Clicker\
        /*
        public static string InitializeRootPath()
        {
            // string directoryPath = Environment.CurrentDirectory;
            string directoryPath = AppDomain.CurrentDomain.BaseDirectory;

            if (string.IsNullOrEmpty(directoryPath))
            {
                Debug.WriteLine("Error: Unable to determine root path.");
                MessageBox.Show("Error: Unable to determine root path.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return string.Empty; // Return an empty string
            }

            string[] directorySplitPath = directoryPath.Split(Path.DirectorySeparatorChar);
            int index = Array.IndexOf(directorySplitPath, "Clicker");

            if (index != -1)
            {
                string rootPath = string.Join(Path.DirectorySeparatorChar.ToString(), directorySplitPath.Take(index + 1));

                if (!rootPath.EndsWith(Path.DirectorySeparatorChar.ToString()))
                {
                    rootPath += Path.DirectorySeparatorChar;
                }
                return rootPath;
            }
            else
            {
                Debug.WriteLine("Error: 'KeepYourFocus' directory not found in path.");
                MessageBox.Show("Error: 'KeepYourFocus' directory not found in path.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return string.Empty; // Return an empty string
            }
        }
        */

        #region RANDOMIZERS

        /// <summary>
        /// Returns randomized coordinates (x, y) for a circle within the specified maximum width and height.
        /// </summary>
        /// <param name="maxWidth">The maximum width for the random x-coordinate.</param>
        /// <param name="maxHeight">The maximum height for the random y-coordinate.</param>
        /// <returns>A tuple containing the randomized x and y coordinates.</returns>
        public static (int, int) RandomizerPositions(int maxWidth, int maxHeight)
        {
            Random randPos = new Random();
            int x = randPos.Next(0, maxWidth);
            int y = randPos.Next(0, maxHeight);

            return (x, y);
        }

        /// <summary>
        /// Returns a randomized size for a circle within a specified range.
        /// </summary>
        /// <returns>A random integer representing the size of the circle.</returns>
        public static int RandomizerCircleSize()
        {
            Random randPixels = new Random();
            int size = randPixels.Next(10, 100); // Size range between 10 and 100 pixels

            return size;
        }

        /// <summary>
        /// Returns a random color from a predefined list of colors.
        /// </summary>
        /// <returns>A Color object representing a randomized color.</returns>
        public static Color RandomizerColor()
        {
            List<Color> colors = new List<Color>
            {
                Color.Red, Color.Blue, Color.Green, Color.Yellow, Color.LightBlue,
                Color.LavenderBlush, Color.Ivory, Color.HotPink, Color.AliceBlue,
                Color.DarkOrange, Color.OrangeRed, Color.Orchid, Color.Aqua, Color.Cyan
            };
            Random rand = new Random();
            return colors[rand.Next(colors.Count)];
        }

        #endregion

        #region TIMER PANELBOARDCIRCLES

        /// <summary>
        /// Initializes the board timer and stopwatch, and starts the timers with the specified interval.
        /// </summary>
        /// <param name="interval">The interval in milliseconds to set for the board timer.</param>
        public static void InitializeBoardTimer(int interval)
        {
            _boardTimer = new System.Windows.Forms.Timer();
            _boardTimer.Interval = interval;
            _boardTimer.Tick += Timer_TickBoard!;
            _stopwatch = new Stopwatch();
            _boardTimer.Start();
            _stopwatch.Start();
        }

        /// <summary>
        /// An event that is triggered on each tick of the board timer.
        /// </summary>
        public static event EventHandler? TimerTickBoard;

        /// <summary>
        /// Invokes the TimerTickBoard event on each tick of the board timer.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Event arguments for the tick event.</param>
        internal static void Timer_TickBoard(object sender, EventArgs e)
        {
            TimerTickBoard?.Invoke(sender, e);
        }

        /// <summary>
        /// Stops both the board timer and the indicator timer, and the stopwatch.
        /// </summary>
        /// <returns>The elapsed time from the stopwatch when stopped.</returns>
        public static TimeSpan StopTimer(PanelBoardCircles drawPanelBoard)
        {
            _boardTimer?.Stop();
            _indicatorTimer?.Stop();
            _stopwatch?.Stop();

            //drawPanelBoard.Enabled = false;
            drawPanelBoard.Visible = false;

            return _stopwatch!.Elapsed;
        }

        #endregion

        #region TIMER PANELTIMERINDICATOR

        /// <summary>
        /// Initializes the indicator timer with a 1-second interval and starts it.
        /// </summary>
        public static void InitializeIndicatorTimer()
        {
            _indicatorTimer = new System.Windows.Forms.Timer();
            _indicatorTimer.Interval = 1000; // 1 second interval
            _indicatorTimer.Tick += Timer_TickIndicator!;
            _indicatorTimer.Start();
        }

        /// <summary>
        /// An event that is triggered on each tick of the indicator timer.
        /// </summary>
        public static event EventHandler? TimerTickIndicator;

        /// <summary>
        /// Invokes the TimerTickIndicator event on each tick of the indicator timer.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Event arguments for the tick event.</param>
        internal static void Timer_TickIndicator(object sender, EventArgs e)
        {
            TimerTickIndicator?.Invoke(sender, e);
        }

        #endregion

        #region SETLEVELS
        /// <summary>
        /// Initializes game levels and quotas. (Currently not implemented)
        /// </summary>
        public void InitLevels()
        {
            // level and quota
        }
        #endregion
    }
}
