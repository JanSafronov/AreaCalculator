using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics;
using MathNet.Numerics.Differentiation;
using MathNet.Numerics.Integration;

namespace AreaCalculator
{
    /// <summary>
    /// Class <c>Curve</c> models a closed parametric curve.
    /// </summary>
    public class Curve
    {
        public Func<double, Tuple<double, double>> Parametric { get; set; }

        public Tuple<double, double> Domain { get; set; }

        public Curve(Func<double, Tuple<double, double>> parametric, Tuple<double, double> domain)
        {
            Parametric = parametric;
            Domain = domain;
        }

        /// <summary>
        /// Method <c>Area</c> calculates the area of the curve
        /// </summary>
        /// <param name="partitions">Partition of the integration</param>
        /// <returns>Precise area of the curve determined by the number of integral partitions</returns>
        public double Area(int partitions) {
            return SimpsonRule.IntegrateComposite(t => Differentiate.Derivative(s => Parametric(s).Item1, t, 1) * Parametric(t).Item2, Domain.Item1, Domain.Item2, partitions);
        }
    }
}
