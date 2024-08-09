using System;
using System.Drawing;

namespace Clicker
{
    public class Circle
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int CircleSize { get; set; }
        public DateTime InitTime { get; set; }
        public int MaxTimeDrawn { get; set; }
        public Color Color { get; set; }

        // Constructor to initialize all properties
        public Circle(int x, int y, int circleSize, Color color, int maxTimeDrawn)
        {
            X = x;
            Y = y;
            CircleSize = circleSize;
            InitTime = DateTime.UtcNow;
            MaxTimeDrawn = maxTimeDrawn;
            Color = color;
        }
    }
}
