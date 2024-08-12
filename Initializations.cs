using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Clicker_v2
{
    public class Initializations
    {
        private static System.Windows.Forms.Timer? _timer;
        private static Stopwatch? _stopwatch;

        // Define a static TimerTick event
        public static event EventHandler? TimerTick;

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

            //Debug.WriteLine($"Position = ({x}, {y})");

            return (x, y);
        }

        // Return randomized size circle
        public static int RandomizedCircleSize()
        {
            Random randPixels = new Random();
            int size = randPixels.Next(10, 100);

            //Debug.WriteLine($"pixSize = {size}");

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

        #region TIMER
        // Initialize timer and stopwatch
        public static void InitializeTimer(int interval)
        {
            _timer = new System.Windows.Forms.Timer();
            _timer.Interval = interval; // Timer interval in milliseconds
            _timer.Tick += Timer_Tick!;

            _stopwatch = new Stopwatch();

            // Start the timer and stopwatch
            _timer.Start();
            _stopwatch.Start();
        }

        // Seperate function for 1 Tick == 1000 ms
        public static void InitializeTimerSeconds()
        {
            _timer = new System.Windows.Forms.Timer();
            _timer.Interval = 1000; // 1000 ms = 1 second
            _timer.Tick += Timer_Tick!;

            // Start the timer
            _timer.Start();
        }


        // Timer Tick event handler
        private static void Timer_Tick(object sender, EventArgs e)
        {
            TimerTick?.Invoke(sender, e);
            //Debug.WriteLine($"Elapsed time: {_stopwatch!.Elapsed.TotalSeconds} seconds");
        }

        public static void UpdateTimer(int interval)
        {
            if (_timer != null)
            {
                _timer.Interval = interval;
                Debug.WriteLine($"Timer interval updated to: {interval} ms");
            }
        }

        // Method to stop the timer and stopwatch
        public static TimeSpan StopTimer()
        {
            if (_timer != null)
                _timer.Stop();

            if (_stopwatch != null)
                _stopwatch.Stop();

            return _stopwatch!.Elapsed;
        }
        #endregion
    }
}