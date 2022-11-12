using Rectangles.App;
using FluentAssertions;

namespace Rectangles.App.Test
{
    public class GridTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase(5, 5)]
        [TestCase(10, 5)]
        [TestCase(10, 25)]
        [TestCase(15, 15)]
        [TestCase(25, 25)]
        public void Should_create_grid(int width, int height)
        {
            // Arrange
            // Act
            var grid = new Grid(width, height);

            // Assert
            grid.Should().NotBeNull();
        }

        [TestCase(4, 25)]
        [TestCase(5, 26)]
        [TestCase(-5, 5)]
        [TestCase(-5, 100)]
        public void Should_not_create_grid(int width, int height)
        {
            // Arrange
            // Act
            var action = () => new Grid(width, height);

            // Assert
            action.Should().Throw<ArgumentException>()
                .Where(e => e.ParamName == "width" || e.ParamName == "height")
                .Where(e => e.Message.Contains(" should not be less than 5 and greater than 25"));
        }

        [TestCase(1, 1, 26, 6)]
        [TestCase(100, 1, 100, 100)]
        public void Should_not_add_beyond_the_grid(int x, int y, int width, int height)
        {
            // Arrange
            var grid = new Grid(25, 5);

            // Act
            var rect = new Rectangle(x, y, width, height);
            var action = () => grid.AddRectangle(rect);

            // Assert
            action.Should().Throw<Exception>()
                .And.Message.Should().Be("Cannot add rectangle beyond the grid.");
        }

        [TestCaseSource(nameof(OverlappingRectangles))]
        public void Should_throw_exception_when_overlaps(int width, int height, Rectangle[] rectangles)
        {
            // Arrange
            var subject = new Grid(width, height);

            // Act
            var action = () =>
            {
                foreach (var rectangle in rectangles)
                {
                    subject.AddRectangle(rectangle);
                }
            };

            // Assert
            action.Should().Throw<Exception>()
                .And.Message.Should().Be("Rectangles cannot overlap each other.");
        }

        private static IEnumerable<object> OverlappingRectangles()
        {
            yield return new object[] { 25, 25, new[] { new Rectangle(0, 0, 5, 5), new Rectangle(4, 4, 5, 5) } };
            yield return new object[] { 5, 5, new[] { new Rectangle(0, 0, 1, 1), new Rectangle(0, 0, 5, 5) } };
        }

        [Test]
        public void Should_remove_rectangle()
        {
            // Arrange
            var target = new Grid(25, 25);
            target.AddRectangle(new Rectangle(0, 0, 5, 5));
            target.AddRectangle(new Rectangle(5, 0, 10, 10));

            // Act
            target.RemoveRectangle(5,5);

            // Assert
            target.Rectangles.Should().HaveCount(1);
        }

        [TestCaseSource(nameof(ValidData))]
        public void Should_succesfully_add_rectangles(int width, int height, params Rectangle[] rectangles)
        {
            // Arrange
            var target = new Grid(width, height);

            // Act
            foreach (var rectangle in rectangles)
            {
                target.AddRectangle(rectangle);
            }

            // Assert
            target.Rectangles.Should().HaveCount(rectangles.Length);
        }

        private static IEnumerable<object> ValidData()
        {
            yield return new object[] { 25, 25, new[] { new Rectangle(1, 1, 2, 2), new Rectangle(4, 4, 3, 3) } };
            yield return new object[] { 5, 5, new[] { new Rectangle(1, 1, 2, 2), new Rectangle(3, 3, 2, 2) } };
            yield return new object[] { 25, 5, new[] { new Rectangle(0, 0, 5, 5), new Rectangle(5, 0, 2, 2) } };
            yield return new object[] { 5, 15, new[] { new Rectangle(0, 0, 1, 1), new Rectangle(3, 1, 2, 2), new Rectangle(0, 7, 5, 5) } };
            yield return new object[] { 20, 15, new[] { new Rectangle(1, 1, 2, 2), new Rectangle(3, 3, 2, 2) } };
        }
    }
}