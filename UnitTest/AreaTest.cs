using AreaCalculator;

namespace UnitTest
{
    public class AreaTest
    {
        [Fact]
        public void TriangleAreaTest()
        {
            Triangle triangle1 = new Triangle(6, 5, 3);
            Triangle triangle2 = new Triangle(2.6, 6.2, 7.9);

            Assert.Equal(7.483, triangle1.Area());
            Assert.Equal(6.816, triangle2.Area());
        }

        [Fact]
        public void CircleAreaTest()
        {
            Circle circle1 = new Circle(3.14);
            Circle circle2 = new Circle(5);

            Assert.Equal(3.14 * Math.Pow(Math.PI, 2), circle1.Area());
            Assert.Equal(5 * Math.Pow(Math.PI, 2), circle2.Area());
        }

        [Fact]
        public void CurveAreaTest()
        {
            Curve curve1 = new Curve(s => new Tuple<double, double>(Math.Pow(s, 2) + 3 * s - 5, 5 * s + Math.Cos(s)), new Tuple<double, double>(-7, 7));
            Curve curve2 = new Curve(s => new Tuple<double, double>(5 * Math.Cos(s), 2 * Math.Sin(s)), new Tuple<double, double>(0, 2 * Math.PI));

            Assert.Equal(1438.323, curve1.Area(100));
            Assert.Equal(31.41, curve2.Area(100));
        }
    }
}