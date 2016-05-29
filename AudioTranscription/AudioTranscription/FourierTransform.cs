using System;
using System.ComponentModel;
using System.Numerics;
using System.Threading.Tasks;

namespace AudioTranscription
{
    class FourierTransform
    {
        public static Complex[] DFT(double[] x, int n, int h, double[] window, int N, int minFreq, int maxFreq)
        {
            Complex[] dft = new Complex[maxFreq - minFreq + 1];
            Complex singleFreqCalc;
            Complex power = new Complex();
            Complex powerBase = new Complex();
            Complex powerBaseK = new Complex();
            if (x == null || x.Length == 0)
            {
                return null;
            }

            powerBase = -2/(double)N;
            powerBase *= Complex.ImaginaryOne;
            powerBase *= Math.PI;

            for (int k = minFreq; k <= maxFreq; k++)
            {
                singleFreqCalc = new Complex();
                powerBaseK = powerBase * k;
                for (int m = 0; m < N; m++)
                {
                    if ((n * h + m) >= 0 && (n * h + m) < x.Length)
                    {

                        power = powerBaseK;                       
                        power *= m;
                        power = Complex.Pow((Complex)Math.E, power);
                        singleFreqCalc += x[n * h + m] * window[m] * power;
                    }
                }
                dft[k - minFreq] = singleFreqCalc;
            }
            return dft;
        }

        public static Complex[][] STFT(double[] x, int h, double[] window, int N, int minFreq, int maxFreq)
        {
            Complex[][] stft = new Complex[x.Length / h + 1][];
            if (x == null || x.Length == 0)
            {
                return null;
            }
            int numOfCompletedThreads = 0;
            Parallel.For(0, (x.Length / h) + 1, n =>
              {
                  stft[n] = DFT(x, n, h, window, N, minFreq, maxFreq);
                  
                 Transcription.completedThreadsPercentage= (int)((((double)(++numOfCompletedThreads)) / ((x.Length / h) + 1)) * 100);

              });
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
            for (int n = 0; n <= x.Length / h; n++)
            {
                for (int k = minFreq; k <= maxFreq; k++)
                {
                    weightedEnergyMeasure[n] += k * Math.Pow(stft[n][k].Magnitude, 2);
                }
                weightedEnergyMeasure[n] /= (maxFreq - minFreq + 1);
            }
            return weightedEnergyMeasure;
        }

    }
}
