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

        public static List<int> FindPeaksWithThreshold(double[] data, int threshold)
        {
            List<int> maxIndexes = new List<int>();

            int sideLength = threshold / 2;

            for (int i = 0; i < data.Length; i++)
            {
                List<double> IndexesInRange = new List<double>();
                int left = (i >= sideLength) ? i - sideLength : 0;
                int right = (i + sideLength) < data.Length ? i + sideLength : data.Length-1;
                int max = i;

                for (int j = left; j < right; j++)
                {
                    if (data[i] < data[j])
                    {
                        max = j;
                    }
                }
                if (max == i && data[i] !=0)
                    maxIndexes.Add(max);
            }
            return maxIndexes;
        }

        static List<int> FindPeaksWithThresholdOneSide(double[] data, int threshold)
        {
            List<int> maxIndexes = new List<int>();

            int sideLength = threshold;

            for (int i = 0; i < data.Length; i++)
            {
                List<double> IndexesInRange = new List<double>();
                int right = (i + sideLength) < data.Length ? i + sideLength : data.Length - 1;
                int max = i;

                for (int j = i; j < right; j++)
                {
                    if (data[i] < data[j])
                    {
                        max = j;
                    }
                }
                if (max == i && data[i] != 0)
                { 
                    maxIndexes.Add(max);
                    for (int j = i+1; j < right; j++)
                    {
                        data[j] = 0;
                    }
                }
            }
            return maxIndexes;
        }

    }
}
