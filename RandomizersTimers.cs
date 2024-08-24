using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Clicker_v2
{
    public class RandomizersTimers {
        private static System.Windows.Forms.Timer? _boardTimer;
        private static System.Windows.Forms.Timer? _indicatorTimer;
        private static Stopwatch? _stopwatch;

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
        // Return randomized coords (x, y) for circle
        public static (int, int) RandomizerPositions(int maxWidth, int maxHeight)
        {
            Random randPos = new Random();
            int x = randPos.Next(0, maxWidth);
            int y = randPos.Next(0, maxHeight);

            return (x, y);
        }

        // Return randomized size circle
        public static int RandomizedCircleSize()
        {
            Random randPixels = new Random();
            int size = randPixels.Next(10, 100);

            return size;
        }

        // Return randomized circle colour
        public static Color GetRandomColor()
        {
            List<Color> colors = new List<Color> { Color.Red, Color.Blue, Color.Green, Color.Yellow, Color.LightBlue, 
                                                   Color.LavenderBlush, Color.Ivory, Color.HotPink, Color.AliceBlue, Color.DarkOrange,
                                                   Color.OrangeRed, Color.Orchid, Color.Aqua, Color.Cyan
                                                 };
            Random rand = new Random();
            return colors[rand.Next(colors.Count)];
        }
        #endregion
        #region SET TIMERS
        #region BOARD TIMER
        /// <summary>
        /// Init board timer and stopwatch and start timers
        /// </summary>
        /// <param name="interval">Interval is set in Clickers.SelectedInterval</param>
        public static void InitializeBoardTimer(int interval)
        {
            _boardTimer = new System.Windows.Forms.Timer();
            _boardTimer.Interval = interval;
            _boardTimer.Tick += Timer_TickBoard!;
            _stopwatch = new Stopwatch();
            _boardTimer.Start();
            _stopwatch.Start();
        }

        public static event EventHandler? TimerTickBoard;
        internal static void Timer_TickBoard(object sender, EventArgs e)
        {
            TimerTickBoard?.Invoke(sender, e);
        }

        /// <summary>
        /// Init board timer and stopwatch and start timers
        /// </summary>
        /// <param name="interval">Interval is set in Clickers.SelectedInterval</param>
        public static void UpdateBoardTimer(int interval)
        {
            if (_boardTimer != null)
            {
                _boardTimer.Interval = interval;
                Debug.WriteLine($"Board Timer interval updated to: {interval} ms");
            }
        }

        public static TimeSpan StopTimer()
        {
            _boardTimer?.Stop();
            _indicatorTimer?.Stop();
            _stopwatch?.Stop();
            return _stopwatch!.Elapsed;
        }
        #endregion

        #region INDICATOR TIMER
        public static void InitializeIndicatorTimer()
        {
            _indicatorTimer = new System.Windows.Forms.Timer();
            _indicatorTimer.Interval = 1000; // 1 second interval
            _indicatorTimer.Tick += Timer_TickIndicator!;
            _indicatorTimer.Start();
        }

        public static event EventHandler? TimerTickIndicator;
        internal static void Timer_TickIndicator(object sender, EventArgs e)
        {
            TimerTickIndicator?.Invoke(sender, e);
        }
        #endregion
        #endregion
    }
}