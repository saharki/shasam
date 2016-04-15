using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace AudioTranscription
{
    class FourierTransform
    {
        public static Complex[] DFT(double[] x, int n, int h, double[] window, int N, int minFreq, int maxFreq)
        {
            Complex[] fft = new Complex[maxFreq - minFreq + 1];
            //Complex singleFreqCalc;
            //Complex power = new Complex();
            if (x == null || x.Length == 0)
            {
                return null;
            }
            Parallel.For(minFreq, maxFreq, k =>
              {
                  Complex singleFreqCalc = new Complex();
                  Complex power = new Complex();
                  for (int m = 0; m < N; m++)
                  {
                      if ((n * h + m) >= 0 && (n * h + m) < x.Length)
                      {
                          power = -2;
                          power *= Complex.ImaginaryOne;
                          power *= Math.PI;
                          power *= k;
                          power *= ((double)m) / N;
                          power = Complex.Pow((Complex)Math.E, power);
                          singleFreqCalc += x[n * h + m] * window[m] * power;
                      }
                  }
                  fft[k - minFreq] = singleFreqCalc;
              });

            //for (int k = minFreq; k <= maxFreq; k++)
            //{
            //    singleFreqCalc = new Complex();
            //    for (int m = 0; m < N; m++)
            //    {
            //        if ((n * h + m) >= 0 && (n * h + m) < x.Length)
            //        {
            //            power = -2;
            //            power *= Complex.ImaginaryOne;
            //            power *= Math.PI;
            //            power *= k;
            //            power *= ((double)m) / N;
            //            power = Complex.Pow((Complex)Math.E, power);
            //            singleFreqCalc += x[n * h + m] * window[m] * power;
            //        }
            //    }
            //    fft[k - minFreq] = singleFreqCalc;
            //}
            return fft;
        }

        public static Complex[][] STFT(double[] x, int h, double[] window, int N, int minFreq, int maxFreq)
        {
            Complex[][] stft = new Complex[x.Length / h + 1][];
            if (x == null || x.Length == 0)
            {
                return null;
            }

            Parallel.For(0, (x.Length / h) + 1, n =>
              {
                  stft[n] = DFT(x, n, h, window, N, minFreq, maxFreq);
              });
            //for (int n = 0; n <= x.Length / h; n++)
            //{
            //    stft[n] = DFT(x, n, h, window, N, minFreq, maxFreq);
            //}
            return stft;
        }

        public static double[] Energy(double[] x, int h, double[] window, int N, int minFreq, int maxFreq)
        {
            if (x == null || x.Length == 0)
            {
                return null;
            }
            Complex[][] stft = STFT(x, h, window, N, minFreq, maxFreq);
            double[] weightedEnergyMeasure = new double[x.Length / h + 1];
            Parallel.For(0, (x.Length / h) + 1, n =>
            {
                for (int k = minFreq; k <= maxFreq; k++)
                {
                    weightedEnergyMeasure[n] += k * Math.Pow(stft[n][k].Magnitude, 2);
                }
                weightedEnergyMeasure[n] /= (maxFreq - minFreq + 1);
            });
            //for (int n = 0; n <= x.Length / h; n++)
            //{
            //    for (int k = minFreq; k <= maxFreq; k++)
            //    {
            //        weightedEnergyMeasure[n] += k * Math.Pow(stft[n][k].Magnitude, 2);
            //    }
            //    weightedEnergyMeasure[n] /= (maxFreq - minFreq + 1);
            //}
            return weightedEnergyMeasure;
        }

    }
}
