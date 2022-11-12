using FluentAssertions;

namespace Rectangles.App.Test
{
    public class RectangleTest
    {
        [TestCase(-1, 0, 1, 1)]
        [TestCase(0, -1, 1, 1)]
        [TestCase(0, 0, 0, 1)]
        [TestCase(0, 0, 1, 0)]
        public void Should_not_create_Rectangle(int x, int y, int width, int height)
        {
            // Arrange
            // Act
            var action = () => new Rectangle(x, y, width, height);

            // Assert
            action.Should().Throw<ArgumentException>()
                .And.Message.Should().StartWith("Invalid value");
        }

        [TestCase(0, 0, 3, 3)]
        [TestCase(0, 0, 100, 300)]
        [TestCase(1, 100, 1000, 3)]
        [TestCase(100, 1000, 3, 3)]
        [TestCase(5, 9, 14, 27)]
        public void Should_create_Rectangle(int x, int y, int width, int height)
        {
            // Arrange
            // Act
            var subject = new Rectangle(x, y, width, height);

            // Assert
            subject.Should().NotBeNull();
            subject.X.Should().Be(x);
            subject.Y.Should().Be(y);
            subject.Width.Should().Be(width);
            subject.Height.Should().Be(height);
        }
    }
}