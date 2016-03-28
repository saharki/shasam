using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using Histograma;
namespace AudioTranscription
{
    class FourierTransform
    {
        public static Complex[] DFTWithPrint(Double[] x, double k, int N, double[] window, int h)
        {
            HistogramaDesenat histo = new HistogramaDesenat();
            Complex[] sums = new Complex[x.Length / h];
            long[] draw = new long[x.Length / h];
            if (x == null || x.Length == 0)
            {
                return null;
            }
            for (int n = 0; n < x.Length / h; n++)//last window may be ignored, in case of incomplete number of windows that can be appllied on the signal.
            {
                for (int t = -N / 2; t < N / 2; t++)
                {
                    sums[n] = new Complex();

                    Complex temp = new Complex(0, 1);
                    temp = (-1) * temp * 2 * Math.PI * t * k / N;
                    temp = Complex.Pow(Math.E, temp);
                    if (t + N / 2 + n * h < x.Length)
                    {
                        sums[n] = sums[n] + x[t + N / 2 + n * h] * temp * window[t + N / 2];
                    }
                }
                draw[n] = (long)(sums[n].Magnitude*1000);
            }
            //histo.DrawHistogram(draw);
            //histo.Visible = true;
            //histo.Show();
            for(int j=0; j < x.Length / h; j++)
            {
                  StringBuilder ab = new StringBuilder(draw[j].ToString());
                  for(int i=0; i< draw[j]; i++)
                  {
                      ab.Append("*");
                  }

                  Console.WriteLine("Window {0} has grade {1} : {2}", j, draw[j], ab.ToString());
            }
            return sums;
        }
        public static Complex[] DFT(Double []x,double k,int N,double []window,int h)
        {
            Complex []sums= new Complex[x.Length/h];
            if (x==null|| x.Length==0 )
            {
                return null; 
            }
            for (int n = 0; n < x.Length / h; n++)//last window may be ignored, in case of incomplete number of windows that can be appllied on the signal.
            {
                for (int t = -N / 2; t < N / 2; t++)
                {
                    sums[n] = new Complex();
                    Complex temp = new Complex(0, 1);
                    temp = (-1) * temp * 2 * Math.PI * t * k / N;
                    temp = Complex.Pow(Math.E, temp);
                    sums[n] = sums[n] + x[t + N / 2 + n * h ] * temp * window[t + N / 2];
                }
            }
            return sums;
        }

        public static Complex[][] STFT(Double[] x, int N, double[] window, int h,int minFreq,int maxFreq)
        {
            Complex[][] result = new Complex[maxFreq][];
            if (x == null || x.Length == 0)
            {
                return null;
            }
            for (int k = 0; k < minFreq ; k++)
            {
                result[k] = null;
            }
            for (int k =minFreq; k <= maxFreq; k ++)
            {
                result[k] = DFT(x, k, N, window, h);
            }
            return result;
        }

     }
}
