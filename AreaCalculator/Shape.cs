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
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;

namespace AreaCalculator
{
    /// <summary>
    /// Class <c>Shape</c> models a closed shape (curve, surface, etc...) given by parametric function.
    /// </summary>
    public class Shape
    {
        public Parametric Parametric { get; set; }

        public Shape(Func<double[], double[]> parametric, Tuple<double[], double[]> domain, int codimension)
        {
            Parametric = new Parametric(parametric, domain.Item1.Length, codimension, domain);
        }

        /// <summary>
        /// Method <c>Area</c> calculates the area of the shape
        /// </summary>
        /// <param name="partitions">Partition of the integration</param>
        /// <returns>Precise area of the shape determined by the number of integral partitions</returns>
        public double Area(int partitions)
        {
            Func<double[], int, double[]> partial = (t, id) =>
            {
                double[] full = new double[Parametric.Codimension];
                for (int i = 0; i < Parametric.Codimension; i++)
                {
                    full[i] = Differentiate.FirstPartialDerivative(s => Parametric.Func(s)[i], t, id);
                }
                return full;
            };

            Func<double[], double> dvolume = (u) =>
            {
                double[][] U = new double[u.Length][];

                for (int i = 0; i < u.Length; i++)
                {
                    U[i] = partial(u, i);
                }

                return Euclidean.NVolume(U);
            };

            Func<double[], double> volume = u => SimpsonRule.IntegrateComposite(t => dvolume(u.Prepend(t).ToArray()), Parametric.Domain.Item1[0], Parametric.Domain.Item2[0], partitions);

            for (int i = 1; i <  Parametric.Domain.Item1.Length; i++)
            {
                volume = u => SimpsonRule.IntegrateComposite(t => volume(u[..i].Append(t).Concat(u[(i+1)..]).ToArray()), Parametric.Domain.Item1[i], Parametric.Domain.Item2[i], partitions);
            }

            double[] vector = new double[Parametric.Dimension];

            for (int i = 0; i < Parametric.Dimension; i++)
            {
                vector[i] = 0;
            }
            
            return volume(vector);
        }
    }
}
