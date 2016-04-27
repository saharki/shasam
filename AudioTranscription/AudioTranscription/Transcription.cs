﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioTranscription
{
    class Transcription
    {
        private static int chosenInstrument = 0;

        private static int windowSizeInMs;
        private static int hopSizeInMs;
        private static float threshold;
        private static int BPM;
        private static string wavFilePath;

        public Transcription()
        {

        }

        public static void Initialize(int windowSize, int hopSize, float thresh, int _BPM, string wavFile, int chosen)
        {
            windowSizeInMs = windowSize;
            hopSizeInMs = hopSize;
            threshold = thresh;
            BPM = _BPM;
            wavFilePath = wavFile;
            chosenInstrument = chosen;
        }
        public static void Transcribe(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            double[] wavData;
            double[] nothing;

            int samplesRate = StreamFromFileSample.WaveFile.openWav(wavFilePath, out wavData, out nothing, 22050);

            //int N = 1024;
            //int h = N / 4;
            //BPM = 80;

            int N = samplesRate * windowSizeInMs / 1000;
            int h = samplesRate * hopSizeInMs / 1000;

            int minFreq = 0;
            int maxFreq = 500;

            double[] window = new double[N];
            for (int i = 0; i < N; i++)
            {
                window[i] = HammingWindow(i, N);
            }

            double[] energyArray = FourierTransform.Energy(wavData, h, window, N, minFreq, maxFreq);
            //transcribeWorker.ReportProgress(80);
            double[] thresholdedEnergyArray = Thresholding.FixedThresholdRelativeNormalize(energyArray, threshold);
            //transcribeWorker.ReportProgress(83);
            List<int> windowPeaks = PeakPicking.FindPeaksWithThreshold(thresholdedEnergyArray, (int)(samplesRate * (double)BPM / 60) / h);
            //transcribeWorker.ReportProgress(90);
            List<int> signalPeaks = new List<int>(windowPeaks.Count);
            for (int i = 0; i < windowPeaks.Count; i++)
            {
                signalPeaks.Add(windowPeaks[i] * h + N / 2);
            }
            double q = 0;
            PitchTracking.PitchDetectionForAllPeaks(wavData, 4096, ref q, samplesRate, signalPeaks);
            //transcribeWorker.ReportProgress(100);
        }

        private static float HammingWindow(int n, int N)
        {
            return 0.54f - 0.46f * (float)Math.Cos((2 * Math.PI * n) / (N - 1));
        }
    }
}