namespace AreaCalculator
{

    /// <summary>
    /// Class <c>Circle</c> models a circle given it's radius.
    /// </summary>
    public class Circle
    {
        public int r;
        
        public Circle(int r) { this.r = r; }

        /// <summary>
        /// Method <c>Area</c> calculates the area of the circle
        /// </summary>
        /// <returns>Area of the circle</returns>
        public double Area() => r * Math.Pow(Math.PI, 2);
    }
}
