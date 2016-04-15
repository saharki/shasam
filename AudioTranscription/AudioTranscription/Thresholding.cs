using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioTranscription
{
    class Thresholding
    {
        public static double[] FixedThreshold( double[] arr, double threshold)
        {
            double[] result = new double[arr.Length];
            for(int i=0;i<arr.Length;i++)
            {
                if (arr[i] < threshold)
                    result[i] = 0;
                else
                    result[i] = arr[i];
            }
            return result;
        }

        public static double[] FixedThresholdRelative(double[] arr, double threshold)
        {
            double relativeThreshold = arr.Max() * threshold;
            double[] result = new double[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] < relativeThreshold)
                    result[i] = 0;
                else
                    result[i] = arr[i];
            }
            return result;
        }
        
        public static double[] FixedThresholdRelativeNormalize(double[] arr, double threshold)
        {
            double max = arr.Max();
            double[] result = new double[arr.Length];

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i]/max < threshold)
                    result[i] = 0;
                else
                    result[i] = arr[i]/max;
            }
            return result;
        }
    }
}
