using MathNet.Numerics;
using MathNet.Numerics.Integration;
using MathNet.Numerics.LinearAlgebra.Complex;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AreaCalculator.Utils;

namespace AreaCalculator
{
    /// <summary>
    /// Class <c>Shape</c> models a closed shape (curve, surface, etc...) given by parametric function.
    /// </summary>
    public class Shape
    {
        public Func<double[], double[]> Parametric { get; set; }

        public Tuple<double[], double[]> Domain { get; set; }

        public Shape(Func<double[], double[]> parametric, Tuple<double[], double[]> domain)
        {
            Parametric = parametric;
            Domain = domain;
        }

        /// <summary>
        /// Method <c>Area</c> calculates the area of the shape
        /// </summary>
        /// <param name="partitions">Partition of the integration</param>
        /// <returns>Precise area of the shape determined by the number of integral partitions</returns>
        public double Area(int partitions)
        {
            int rangeL = Domain.Item2.Length;

            Func<double[], double[], double> abscross = (u, v) => Euclidean.AbsCross(u, v);
            
            double[] area = SimpsonRule.IntegrateComposite(t => Differentiate.PartialDerivative(s => Parametric(s)[0], t, 0, 1), Domain.Item1[0], Domain.Item2[0], partitions);

            return SimpsonRule.IntegrateComposite(t => Differentiate.Derivative(s => Parametric(s)[0], t, 1), Domain.Item1, Domain.Item2, partitions);
        }
    }
}
