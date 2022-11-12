namespace Rectangles.App
{
    public class Rectangle
    {
        public Rectangle(int x, int y, int width, int height)
        {
            if (x < 0)
            {
                throw new ArgumentException("Invalid value", nameof(x));
            }

            if (y < 0)
            {
                throw new ArgumentException("Invalid value", nameof(y));
            }

            if (width <= 0)
            {
                throw new ArgumentException("Invalid value", nameof(width));
            }

            if (height <= 0)
            {
                throw new ArgumentException("Invalid value", nameof(height));
            }

            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        public int X { get; }
        public int Y { get; }
        public int Width { get; }
        public int Height { get; }
    }
}
