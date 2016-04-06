using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioTranscription
{
    class PeakPicking
    {
        public static double[] LPF(double []x, double dt,double RC)
        {
            double[] y = new double[x.Length];
            double a = dt / (RC + dt);
            y[0] = x[0];
            for(int i=1;i<x.Length;i++)
            {
                y[i] = a * x[i] + (1 - a) * y[i - 1];
            }
            return y;
        }
    }
}
