using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace AudioTranscription
{
    class Transcription
    {
        private static Instrument chosenInstrument = 0;

        private static int windowSizeInMs;
        private static int hopSizeInMs;
        private static float threshold;
        private static int BPM;
        private static string wavFilePath;
        private static bool bpmAutoDetect;
        private static int completedThreads;
        private static bool isDFT;
        public static int completedThreadsPercentage
        {
            get { return completedThreads; }
            set
            {
                completedThreads = value;
                if (CompletedThreadsHandler != null) CompletedThreadsHandler(value);
            }
        }

        public delegate void valueChanged(int completedThreads );
        private static valueChanged CompletedThreadsHandler;
        public Transcription()
        {

        }

        public static void Initialize(int windowSize, int hopSize, float thresh, int _BPM, string wavFile, bool bpmAutoDetection, Instrument chosen,valueChanged CompletedThreadsH,bool DFT)
        {
            windowSizeInMs = windowSize;
            hopSizeInMs = hopSize;
            threshold = thresh;
            BPM = _BPM;
            wavFilePath = wavFile;
            chosenInstrument = chosen;
            bpmAutoDetect = bpmAutoDetection;
            completedThreads = 0;
            CompletedThreadsHandler = CompletedThreadsH;
            isDFT = DFT;
        }
        public static void Transcribe(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            double[] wavData;
            double[] nothing;

            //int samplesRate = StreamFromFileSample.WaveFile.openWav(wavFilePath, out wavData, out nothing, 22050);
            int samplesRate = 44100;
            StreamFromFileSample.WaveFile.openWav(wavFilePath, out wavData, out nothing);
            //int N = 1024;
            //int h = N / 4;
            //BPM = 80;

            //************* Automatic BPM detection - START ****************************//
            if (bpmAutoDetect)
            {
                BPMDetect.BPMDetection bpmDetector = new BPMDetect.BPMDetection();
                for (int i = 0; i < wavData.Length; i++)
                {
                    bpmDetector.AddSample((float)wavData[i]);
                }
                BPM = (int)bpmDetector.getParameter(BPMDetect.BPMDetection.BPMParam.BPMFOUNDBPM);
            }
            //************* Automatic BPM detection - END ****************************//

            int N = samplesRate * windowSizeInMs / 1000;
            int h = samplesRate * hopSizeInMs / 1000;

            int minFreq = 0;
            int maxFreq = 500;

            double[] window = new double[N];
            for (int i = 0; i < N; i++)
            {
                window[i] = HammingWindow(i, N);
            }
            double[] energyArray;
            if (isDFT)
            {
                energyArray = FourierTransform.Energy(wavData, h, window, N, minFreq, maxFreq);
            }
            else
            {
                energyArray = FourierTransform.EnergyFFT(wavData, h, window, N, minFreq, maxFreq);
            }

            double[] thresholdedEnergyArray = Thresholding.FixedThresholdRelativeNormalize(energyArray, threshold);
            List<int> windowPeaks = PeakPicking.FindPeaksWithThreshold(thresholdedEnergyArray, (int)((samplesRate) * (double)60/BPM/4 ) / h);

            List<int> signalPeaks = new List<int>(windowPeaks.Count);
            for (int i = 0; i < windowPeaks.Count; i++)
            {
                signalPeaks.Add(windowPeaks[i] * h + N / 2);
            }
            double q = 0;
            double [] signalFrequencies = PitchTracking.PitchDetectionForAllPeaks(wavData, 4096, ref q, samplesRate, signalPeaks);

            float[][] result = new float[3][];
            result[0] = new float[signalPeaks.Count]; //Peak location
            result[1] = new float[signalPeaks.Count]; //Peak frequency
            result[2] = new float[signalPeaks.Count]; //Peak duration

            for (int i=0;i<signalPeaks.Count;i++)
            {
                result[0][ i] = signalPeaks[i]; 
                result[1][ i] = (int)Math.Round(signalFrequencies[i], 0);
                if (i != signalPeaks.Count - 1)
                    result[2][i] = SamplesToDurationUsingBPM(signalPeaks[i + 1] - signalPeaks[i], samplesRate);
                else
                    result[2][i] = SamplesToDurationUsingBPM(wavData.Length - signalPeaks[i], samplesRate);
            }

            e.Result = result;
            (sender as BackgroundWorker).ReportProgress(100);
        }

        private static float HammingWindow(int n, int N)
        {
            return 0.54f - 0.46f * (float)Math.Cos((2 * Math.PI * n) / (N - 1));
        }

        private static float SamplesToDurationUsingBPM(int durationInSamples, int samplesRate)
        {
            List<float> distances = new List<float>(6);

            float quarterInSamples = ((float)60 / BPM) * samplesRate;
            float eighthInSamples = (float)0.5 * quarterInSamples;
            float sixteenthInSamples = (float)0.25 * quarterInSamples;
            float halfInSamples = 2 * quarterInSamples;
            float threeQuarterInSamples = 3 * quarterInSamples;
            float wholeInSamples = 4 * quarterInSamples;

            float distanceFromQuarter = Math.Abs(durationInSamples - quarterInSamples);
            float distanceFromEighth = Math.Abs(durationInSamples - eighthInSamples);
            float distanceFromSixteenth = Math.Abs(durationInSamples - sixteenthInSamples);
            float distanceFromHalf = Math.Abs(durationInSamples - halfInSamples);
            float distanceFromThreeQuarters = Math.Abs(durationInSamples - threeQuarterInSamples);
            float distanceFromWhole = Math.Abs(durationInSamples - wholeInSamples);

            distances.Add(distanceFromSixteenth);
            distances.Add(distanceFromEighth);
            distances.Add(distanceFromQuarter);
            distances.Add(distanceFromHalf);
            distances.Add(distanceFromThreeQuarters);
            distances.Add(distanceFromWhole);

            int index = distances.IndexOf(distances.Min());
            if (index == 0)
                return (float)1 / 16;
            if (index == 1)
                return (float)1 / 8;
            if (index == 2)
                return (float)1 / 4;
            if (index == 3)
                return (float)1 / 2;
            if (index == 4)
                return (float)3 / 4;
            if (index == 5)
                return 1;

            return 0;
        }

        public static string DurationLetter(float durationFraq)
        {
            if (durationFraq == (float)1 / 16)
                return "x";
            if (durationFraq == (float)1 / 8)
                return "e";
            if (durationFraq == (float)1 / 2)
                return "a";
            if (durationFraq == (float)3 / 4)
                return "t";
            if (durationFraq == 1)
                return "w";

            return "";  //default is quarter;
        }


        internal static string OctaveLetter(int octave) // m: default octace, l: lower octave, h: higher octave.
        {
            switch((int)chosenInstrument)
            {
                case (int)Instrument.PIANO:
                case (int)Instrument.GUITAR:
                case (int)Instrument.UKULELE:
                    if (octave == 2)
                        return "l";
                    else if (octave == 3)
                        return "m";
                    else if (octave == 4)
                        return "h";
                    else
                        return (octave - 3).ToString("+#;-#");
                    break;
                
                default:
                    return "m";
            }
            return "m";
        }
    }
}
