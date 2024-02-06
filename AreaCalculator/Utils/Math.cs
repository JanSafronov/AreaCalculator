using Microsoft.SolverFoundation.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AreaCalculator.Utils
{
    public class Euclidean
    {
        public static double Dot(double[] u, double[] v)
        {
            double sum = 0;
            for (int i = 0; i < u.Length; i++)
            {
                sum = u[i] * v[i];
            }
            return sum;
        }

        public static double Length(double[] u) => Math.Sqrt(u.Aggregate((sum, e) =>  sum + Math.Pow(e, 2)));

        public static double AbsCross(double[] u, double[] v)
        {
            double sin = Math.Sqrt(1 - Math.Pow(Dot(u, v) / (Length(u) * Length(v)), 2));

            return Length(u) * Length(v) * sin;
        }
    }
}
