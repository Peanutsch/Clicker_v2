using System;
using System.Drawing;

namespace Clicker_v2
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
            this.CircleSize = circleSize;
            this.InitTime = DateTime.UtcNow;
            this.MaxTimeDrawn = maxTimeDrawn;
            this.Color = color;
        }
    }
}
