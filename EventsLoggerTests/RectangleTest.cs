using System;
using FluentAssertions;
using Xunit;

namespace EventsLoggerTests
{
    public class RectangleTest
    {
        [Fact]
        public void IsRectangle()
        {

            Rectanglable rectangle = new Square
            {
                Width = 5
            };

            rectangle.CalculateSurface().Should().Be(30);
        }
    }



    public abstract class Rectanglable
    {
        public virtual int Width { get; set; }
        public abstract int CalculateSurface();
    }


    public class Rectangle : Rectanglable
    {
        public virtual int Height { get; set; }

        public override int CalculateSurface()
        {
            return Width * Height;
        }
    }



    public class Square : Rectanglable
    {
        public override int CalculateSurface()
        {
            return Width * Width;
        }
    }
}
