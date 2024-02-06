namespace AreaCalculator
{

    /// <summary>
    /// Class <c>Triangle</c> models a triangle given it's sides length.
    /// </summary>
    public class Triangle
    {
        public double x; public double y; public double z;

        public Triangle(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public bool isRight() { return Math.Pow(x, 2) + Math.Pow(y, 2) == Math.Pow(z, 2); }
        
        /// <summary>
        /// Method <c>Area</c> calculates the area of the triangle given Heron's formula
        /// </summary>
        /// <returns>Area of the triangle</returns>
        public double Area()
        {
            double semi = (x + y + z) / 2;
            
            return Math.Sqrt(semi*(semi - x)*(semi - y)*(semi - z));
        }
    }
}