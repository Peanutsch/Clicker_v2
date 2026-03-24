using System;
using System.Collections.Generic;
using System.Drawing;

namespace Clicker_v2
{
    /// <summary>
    /// Service for generating randomized game elements.
    /// Provides methods for generating random positions, sizes, and colors for circles.
    /// </summary>
    public static class RandomizerService
    {
        /// <summary>
        /// List of available colors for circles.
        /// </summary>
        private static readonly List<Color> AvailableColors = new List<Color>
        {
            Color.Red, Color.Blue, Color.Green, Color.Yellow, Color.LightBlue,
            Color.LavenderBlush, Color.Ivory, Color.HotPink, Color.AliceBlue,
            Color.DarkOrange, Color.OrangeRed, Color.Orchid, Color.Aqua, Color.Cyan
        };

        /// <summary>
        /// Returns randomized coordinates (x, y) for a circle within the specified maximum width and height.
        /// Uses Random.Shared for thread-safe randomization (available in .NET 8+).
        /// </summary>
        /// <param name="maxWidth">The maximum width for the random x-coordinate.</param>
        /// <param name="maxHeight">The maximum height for the random y-coordinate.</param>
        /// <returns>A tuple containing the randomized x and y coordinates.</returns>
        public static (int, int) GetRandomPosition(int maxWidth, int maxHeight)
        {
            int x = Random.Shared.Next(0, maxWidth);
            int y = Random.Shared.Next(0, maxHeight);

            return (x, y);
        }

        /// <summary>
        /// Returns a randomized size for a circle within the configured range.
        /// </summary>
        /// <returns>A random integer representing the size of the circle.</returns>
        public static int GetRandomCircleSize()
        {
            return Random.Shared.Next(GameConfiguration.CircleSizeMin, GameConfiguration.CircleSizeMax);
        }

        /// <summary>
        /// Returns a random color from the predefined list of colors.
        /// </summary>
        /// <returns>A Color object representing a randomized color.</returns>
        public static Color GetRandomColor()
        {
            return AvailableColors[Random.Shared.Next(AvailableColors.Count)];
        }
    }
}
