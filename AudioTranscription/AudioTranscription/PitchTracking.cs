using System;
using System.Collections.Generic;
using System.Diagnostics;


namespace AudioTranscription
{
    public static class PitchTracking
    {

        // ===================================================================
        //  EstimatePeriod
        //
        //  Returns best estimate of period.
        // ===================================================================
        // ===================================================================
        //  PeriodEstimator demo
        //
        //  Demonstrates use of period estimator algorithm based on 
        //  normalized autocorrelation. Other neat tricks include sub-sample
        //  accuracy of the period estimate, and avoidance of octave errors.
        //
        //  Released under the MIT License
        //
        //  The MIT License (MIT)
        //
        //  Copyright (c) 2009 Gerald T Beauregard
        //
        //  Permission is hereby granted, free of charge, to any person obtaining a copy
        //  of this software and associated documentation files (the "Software"), to deal
        //  in the Software without restriction, including without limitation the rights
        //  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
        //  copies of the Software, and to permit persons to whom the Software is
        //  furnished to do so, subject to the following conditions:
        //
        //  The above copyright notice and this permission notice shall be included in
        //  all copies or substantial portions of the Software.
        //
        //  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
        //  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
        //  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
        //  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
        //  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
        //  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
        //  THE SOFTWARE.
        // ===================================================================



        public static double EstimatePeriod(double[] x, int n, int minP, int maxP, ref double q)
        {
            Debug.Assert(minP > 1);
            Debug.Assert(maxP > minP);
            Debug.Assert(n >= 2 * maxP);
            Debug.Assert(x != null);

            q = 0;

            //  --------------------------------
            //  Compute the normalized autocorrelation (NAC).  The normalization is such that
            //  if the signal is perfectly periodic with (integer) period p, the NAC will be
            //  exactly 1.0.  (Bonus: NAC is also exactly 1.0 for periodic signal
            //  with exponential decay or increase in magnitude).

            List<double> nac = new List<double>(new double[maxP + 2]); // Size is maxP+2 (not maxP+1!) because we need up to element maxP+1 to  check
                                                           // whether element at maxP is a peak. Thanks to Les Cargill for spotting the bug.

            for (int p = minP - 1; p <= maxP + 1; p++)
            {
                double ac = 0.0; // Standard auto-correlation
                double sumSqBeg = 0.0; // Sum of squares of beginning part
                double sumSqEnd = 0.0; // Sum of squares of ending part

                for (int i = 0; i < n - p; i++)
                {
                    ac += x[i] * x[i + p];
                    sumSqBeg += x[i] * x[i];
                    sumSqEnd += x[i + p] * x[i + p];
                }
                nac[p] = ac / Math.Sqrt(sumSqBeg * sumSqEnd);
            }

            //  ---------------------------------------
            //  Find the highest peak in the range of interest.

            //  Get the highest value
            int bestP = minP;
            for (int p = minP; p <= maxP; p++)
            {
                if (nac[p] > nac[bestP])
                {
                    bestP = p;
                }
            }

            //  Give up if it's highest value, but not actually a peak.
            //  This can happen if the period is outside the range [minP, maxP]
            if (nac[bestP] < nac[bestP - 1] && nac[bestP] < nac[bestP + 1])
            {
                return 0.0;
            }

            //  "Quality" of periodicity is the normalized autocorrelation
            //  at the best period (which may be a multiple of the actual
            //  period).
            q = nac[bestP];


            //  --------------------------------------
            //  Interpolate based on neighboring values
            //  E.g. if value to right is bigger than value to the left,
            //  real peak is a bit to the right of discretized peak.
            //  if left  == right, real peak = mid;
            //  if left  == mid,   real peak = mid-0.5
            //  if right == mid,   real peak = mid+0.5

            double mid = nac[bestP];
            double left = nac[bestP - 1];
            double right = nac[bestP + 1];

            Debug.Assert(2 * mid - left - right > 0.0);

            double shift = 0.5 * (right - left) / (2 * mid - left - right);

            double pEst = bestP + shift;

            //  -----------------------------------------------
            //  If the range of pitches being searched is greater
            //  than one octave, the basic algo above may make "octave"
            //  errors, in which the period identified is actually some
            //  integer multiple of the real period.  (Makes sense, as
            //  a signal that's periodic with period p is technically
            //  also period with period 2p).
            //
            //  Algorithm is pretty simple: we hypothesize that the real
            //  period is some "submultiple" of the "bestP" above.  To
            //  check it, we see whether the NAC is strong at each of the
            //  hypothetical subpeak positions.  E.g. if we think the real
            //  period is at 1/3 our initial estimate, we check whether the
            //  NAC is strong at 1/3 and 2/3 of the original period estimate.

            const double k_subMulThreshold = 0.90; //  If strength at all submultiple of peak pos are
                                                   //  this strong relative to the peak, assume the
                                                   //  submultiple is the real period.

            //  For each possible multiple error (starting with the biggest)
            int maxMul = bestP / minP;
            bool found = false;
            for (int mul = maxMul; !found && mul >= 1; mul--)
            {
                //  Check whether all "submultiples" of original
                //  peak are nearly as strong.
                bool subsAllStrong = true;

                //  For each submultiple
                for (int k = 1; k < mul; k++)
                {
                    int subMulP = (int)(k * pEst / mul + 0.5);
                    //  If it's not strong relative to the peak NAC, then
                    //  not all submultiples are strong, so we haven't found
                    //  the correct submultiple.
                    if (nac[subMulP] < k_subMulThreshold * nac[bestP])
                    {
                        subsAllStrong = false;
                    }

                    //  TODO: Use spline interpolation to get better estimates of nac
                    //  magnitudes for non-integer periods in the above comparison
                }

                //  If yes, then we're done.   New estimate of
                //  period is "submultiple" of original period.
                if (subsAllStrong == true)
                {
                    found = true;
                    pEst = pEst / mul;
                }
            }

            return pEst;
        }

        public static double PitchDetection(double[] x, int n,double sr, ref double q)
        {
                                     //const double minF = 27.5; //  Lowest pitch of interest (27.5 = A0, lowest note on piano.)
                                     //const double maxF = 4186.0; //  Highest pitch of interest(4186 = C8, highest note on piano.)
            const double minF = 27.5; //  Lowest pitch of interest (27.5 = A0, lowest note on piano.)
            const double maxF = 4186.0; //  Highest pitch of interest(4186 = C8, highest note on piano.)

            int minP = (int)(sr / maxF - 1); //  Minimum period
            int maxP = (int)(sr / minF + 1); //  Maximum period

            //  Generate a test signal

            //const double A440 = 440.0; //  A440
            //double f = A440 * Math.Pow(2.0, -9.0 / 12.0); //  Middle C (9 semitones below A440)

            //double p = sr / f;
            //double q=0;
            //int n = 2 * maxP;
            //double[] x = new double[n];

            //  TODO: Add low-pass filter to remove very high frequency 
            //  energy. Harmonics above about 1/4 of Nyquist tend to mess
            //  things up, as their periods are often nowhere close to 
            //  integer numbers of samples.

            //  Estimate the period
            double pEst = EstimatePeriod(x, n, minP, maxP, ref q);

            //  Compute the fundamental frequency (reciprocal of period)
            double fEst = 0;
            if (pEst > 0)
            {
                fEst = sr / pEst;
            }

            Console.Write("Estimated freq:      {0,8:f3}\n", sr / pEst);
            Console.Write("Periodicity quality: {0,8:f3}\n", q);

            return sr / pEst;
        }

        public static double PitchDetectionFromIndex(double[] x, int n, ref double q, double sr, int startIndex)
        {
            double[] sub_x = new double[n];
            Array.Copy(x, startIndex, sub_x, 0, n);
            return PitchDetection(sub_x, n,sr , ref q);
        }

        public static double[] PitchDetectionForAllPeaks(double[] x, int n, ref double q, double sr, List<int> peaks)
        {
            double[] freqs = new double[peaks.Count];
            for(int i=0;i<peaks.Count;i++)
            {
                freqs[i] = PitchDetectionFromIndex(x, n, ref q, sr, peaks[i]);
                q = 0;
            }
            return freqs;
        }

    }
}