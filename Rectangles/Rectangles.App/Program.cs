// See https://aka.ms/new-console-template for more information
using Rectangles.App;

Console.WriteLine("Initialized the grid (6x6)");
var grid = new Grid(6, 6);
grid.DisplayGrid();

Console.WriteLine("\n\nAdded a rectangle");
grid.AddRectangle(new Rectangle(1, 1, 1, 1));
grid.DisplayGrid();

Console.WriteLine("\n\nAdded another rectangle");
grid.AddRectangle(new Rectangle(3, 0, 2, 2));

grid.DisplayGrid();
Console.WriteLine("\n\nRemove a rectangle from (1,1) position");

grid.RemoveRectangle(1, 1);

grid.DisplayGrid();
Console.WriteLine("\n\nPress any key to exit..");

Console.ReadLine();
