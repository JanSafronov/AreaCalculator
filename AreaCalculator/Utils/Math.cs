using Microsoft.SolverFoundation.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AreaCalculator.Utils
{
    /// <summary>
    /// Class <c>Euclidean</c> models various methods on the Euclidean metric.
    /// </summary>
    public class Euclidean
    {
        /// <summary>
        /// Method <c>Dot</c> calculates the dot product of two vectors
        /// </summary>
        /// <param name="u">First vector of a dot product</param>
        /// <param name="v">Second vector of a dot product</param>
        /// <returns>Dot product of two vectors.</returns>
        public static double Dot(double[] u, double[] v)
        {
            double sum = 0;
            for (int i = 0; i < u.Length; i++)
            {
                sum = u[i] * v[i];
            }
            return sum;
        }

        /// <summary>
        /// Method <c>Length</c> calculates the length of an euclidean vector
        /// </summary>
        /// <param name="u">Vector in euclidean space</param>
        /// <returns>Length of a vector</returns>
        public static double Length(double[] u) => Math.Sqrt(u.Aggregate((sum, e) =>  sum + Math.Pow(e, 2)));

        /// <summary>
        /// Method <c>AbsCross</c> calculates the absolute value of a cross product
        /// </summary>
        /// <param name="u">First vector of a cross product</param>
        /// <param name="v">Second vector of a cross product</param>
        /// <returns>Cross product of two vectors.</returns>
        public static double AbsCross(double[] u, double[] v)
        {
            double sin = Math.Sqrt(1 - Math.Pow(Dot(u, v) / (Length(u) * Length(v)), 2));

            return Length(u) * Length(v) * sin;
        }

        /// <summary>
        /// Method <c>NVolume</c> calculates the volume of an N dimensional polytope spanned by n vectors
        /// </summary>
        /// <param name="U">N dimensional array of N vectors</param>
        /// <returns>Area (volume) spanned by n (N dimensional) vectors</returns>
        public static double NVolume(double[][] U)
        {
            if (U.Length == 2)
            {
                return Math.Abs(U[0][0] * U[1][1] - U[0][1] * U[1][0]);
            }

            double[] kvolumes = new double[U[0].Length];

            U = U[1..];
            double[][] V = U;

            for (int j = 0; j < U[0].Length; j++)
            {
                V[j] = V[j][1..];
            }

            kvolumes[0] = NVolume(V);

            for (int i = 1; i < U[0].Length - 1; i++)
            {
                V = U;
                for (int j = 0; j < U.Length; j++)
                {
                    V[j] = V[j][..i].Concat(V[j][(i+1)..]).ToArray();
                }
                kvolumes[i] = NVolume(U);
            }

            V = U;
            for (int j = 0; j < U.Length; j++)
            {
                V[j] = V[j][..(U[0].Length - 1)];
            }
            kvolumes[kvolumes.Length - 1] = NVolume(V);

            return Dot(U[0], kvolumes);
        }
    }

    /// <summary>
    /// Class <c>Parametric</c> models a parametric function.
    /// </summary>
    public class Parametric
    {
        public Func<double[], double[]> Func { get; set; }

        public int Dimension { get; set; }

        public int Codimension { get; set; }

        public Tuple<double[], double[]> Domain { get; set; }

        public Parametric(Func<double[], double[]> func, int dimension, int codimension, Tuple<double[], double[]> domain)
        {
            Func = func;
            Dimension = dimension;
            Codimension = codimension;
            Domain = domain;
        }
    }
}
