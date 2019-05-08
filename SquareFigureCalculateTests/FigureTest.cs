using SquareFigureCalculate;
using System;
using System.Collections.Generic;
using System.Drawing;
using Xunit;

namespace SquareFigureCalculateTests
{
    public class FigureTest
    {
        [Theory]
        [InlineData(5)]
        [InlineData(6)]
        [InlineData(10506)]
        [InlineData(0)]
        [InlineData(0.55)]
        [InlineData(687.64799)]
        [InlineData(-5)]
        public void Circle_TestValues(double radius)
        {
            var circle = new Circle(radius);

            var expected = Math.PI * Math.Pow(radius, 2);

            var actual = circle.Area;

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(10, 5, 2.8)]
        [InlineData(2, 5, 6)]
        [InlineData(7, 8, 13)]
        [InlineData(8, 5, 14)]
        [InlineData(0, 0, 0)]
        [InlineData(0, 1, 100)]
        public void Triangle_TestValues(double side1, double side2, double side3)
        {
            var triangle = new Triangle(side1, side2, side3);

            var halfPerim = (side1 + side2 + side3) / 2;
            var expected = Math.Sqrt(halfPerim * (halfPerim - side1) * (halfPerim - side2) * (halfPerim - side3));

            var actual = triangle.Area;

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(10, 5, 2.8)]
        [InlineData(2, 5, 6)]
        [InlineData(7, 8, 13)]
        [InlineData(8, 5, 14)]
        [InlineData(0, 0, 0)]
        [InlineData(0, 1, 100)]
        [InlineData(0.65, 1.87, 100)]
        public void Triangle_IsRightTriangle(double side1, double side2, double side3)
        {
            var triangle = new Triangle(side1, side2, side3);

            var expected = Math.Acos((side1 * side1 + side2 * side2 - side3 * side3) / (2 * side1 * side2)) * 180 / Math.PI == 90
                        || Math.Acos((side1 * side1 + side3 * side3 - side2 * side2) / (2 * side1 * side3)) * 180 / Math.PI == 90
                        || Math.Acos((side3 * side3 + side2 * side2 - side1 * side1) / (2 * side3 * side2)) * 180 / Math.PI == 90;

            var actual = triangle.IsRightTriangle();

            Assert.Equal(expected, actual);
        }

        public class TestDataProvider
        {
            public static IEnumerable<object[]> Points()
            {
                var squareData = new List<Point>();
                squareData.Add(new Point(0, 0));
                squareData.Add(new Point(0, 5));
                squareData.Add(new Point(5, 5));
                squareData.Add(new Point(5, 0));

                yield return new object[] { squareData, 25 };

                var rectangleData = new List<Point>();
                rectangleData.Add(new Point(0, 0));
                rectangleData.Add(new Point(0, 10));
                rectangleData.Add(new Point(5, 10));
                rectangleData.Add(new Point(5, 0));

                yield return new object[] { rectangleData, 50 };

                var triangleData = new List<Point>();
                triangleData.Add(new Point(0, 0));
                triangleData.Add(new Point(0, 10));
                triangleData.Add(new Point(5, 0));

                yield return new object[] { triangleData, 25 };

                var triangleData2 = new List<Point>();
                triangleData2.Add(new Point(1, 1));
                triangleData2.Add(new Point(11, 3));
                triangleData2.Add(new Point(6, 1));

                yield return new object[] { triangleData2, 4.5 };

                var triangleData3 = new List<Point>();
                triangleData3.Add(new Point(1, 1));
                triangleData3.Add(new Point(1, 5));
                triangleData3.Add(new Point(4, 1));

                yield return new object[] { triangleData3, 4.5 };
            }
        }

        [Theory]
        [MemberData("Points", MemberType = typeof(TestDataProvider))]
        public void Shape_Test(List<Point> points, double expected)
        {
            var shape = new Shape(points);

            var actual = shape.Area;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Shape_TestRightTriangleSquare()
        {
            var triangleData3 = new List<Point>();
            triangleData3.Add(new Point(1, 1));
            triangleData3.Add(new Point(1, 5));
            triangleData3.Add(new Point(4, 1));

            var shape = new Shape(triangleData3);
            var triangle = new Triangle(4, 3, 5);
            var right = triangle.IsRightTriangle();
            var expected = triangle.Area;
            var actual = shape.Area;

            Assert.Equal(expected, actual);
        }
    }
}
