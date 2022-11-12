namespace Rectangles.App
{
    /// <summary>
    /// The two dimensional grid
    /// </summary>
    public class Grid
    {
        private readonly int width;
        private readonly int height;
        private string[,] data;
        private IList<Rectangle> rectangles;
        private int counter = 0;

        /// <summary>
        /// Initializes a new instance of <see cref="Grid"/> class
        /// </summary>
        /// <param name="width">The width of the Grid. Not more than 25 and not less than 5.</param>
        /// <param name="height">The height of the Grid. Not more than 25 and not less than 5.</param>
        public Grid(int width, int height)
        {
            if (width > 25 || width < 5)
            {
                throw new ArgumentException("Width should not be less than 5 and greater than 25", nameof(width));
            }

            if (height > 25 || height < 5)
            {
                throw new ArgumentException("Height should not be less than 5 and greater than 25", nameof(height));
            }

            this.width = width;
            this.height = height;
            counter = 0;
            data = new string[height, width];
            DrawData("_", 0, 0, width, height);
            rectangles = new List<Rectangle>();
        }

        public IList<Rectangle> Rectangles
        {
            get
            {
                return rectangles;
            }
        }

        /// <summary>
        /// Adds new rectangle in the grid.
        /// </summary>
        /// <param name="rect">The rectangle to add</param>
        /// <exception cref="Exception"></exception>
        public void AddRectangle(Rectangle rect)
        {
            if (rect.X + rect.Width > width ||
                rect.Y + rect.Height > height ||
                rect.X < 0 || rect.Y < 0)
            {
                throw new Exception("Cannot add rectangle beyond the grid.");
            }

            foreach (var item in rectangles)
            {
                if ((item.X > rect.X || item.Width + item.X > rect.X) &&
                    (item.Y > rect.Y || item.Height + item.Y > rect.Y))
                {
                    throw new Exception("Rectangles cannot overlap each other.");
                }
            }

            Rectangles.Add(rect);
            DrawData(((char)(42 + counter)).ToString(), rect.X, rect.Y, rect.Width, rect.Height);
            counter++;
        }

        /// <summary>
        /// Remove a rectangle from the grid by specifying any coordinates within the bound of a rectangle
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void RemoveRectangle(int x, int y)
        {
            foreach (var item in rectangles)
            {
                if ((x >= item.X && x <= item.X + item.Width) ||
                    (y >= item.Y && y <= item.Y + item.Height))
                {
                    rectangles.Remove(item);
                    DrawData("_", item.X, item.Y, item.Width, item.Height);
                    break;
                }
            }
        }

        /// <summary>
        /// Assign a string to represent a rectangle in the grid matrix
        /// </summary>
        /// <param name="character"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="w"></param>
        /// <param name="h"></param>
        public void DrawData(string character, int x, int y, int w, int h)
        {
            for (int _y = 0; _y < height; _y++)
            {
                for (int _x = 0; _x < width; _x++)
                {
                    if (_x >= x && _x <= w + x - 1 &&
                        _y >= y && _y <= h + y - 1)
                    {
                        data[_y, _x] = character;
                    }
                }
            }
        }

        /// <summary>
        /// Draw the grid in console, including the rectangles
        /// </summary>
        public void DisplayGrid()
        {
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Console.Write(data[y, x]);
                }
                Console.WriteLine();
            }
        }
    }
}
