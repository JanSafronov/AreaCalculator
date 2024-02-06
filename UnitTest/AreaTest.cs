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
    }
}