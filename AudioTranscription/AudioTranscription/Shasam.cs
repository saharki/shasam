using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;
//using StreamFromFileSample;

namespace AudioTranscription
{ 
    public partial class MainWindow : Form
    {
        int choosen = 0;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Shasam_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if(choosen==0)
            {
                System.Windows.Forms.MessageBox.Show("Please choose instrument.");
            }
            else if (fileTextBox.Text.Trim() == "")
            {
                System.Windows.Forms.MessageBox.Show("File missing.");
            }
            else
            {
                AMBox.Visible = true;
                timer1.Enabled = true;
                BackgroundWorker transcribeWorker = new BackgroundWorker();
                transcribeWorker.DoWork += transcribe;
                transcribeWorker.RunWorkerAsync();
                transcribeWorker.ProgressChanged += transcribe_ProgressChanged;
                transcribeWorker.WorkerReportsProgress = true;
                transcribeWorker.RunWorkerCompleted += transcribe_Completed;
            }

           
        }
        private void transcribe_Completed(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            ResultWindow r = new ResultWindow();
            r.Show();
            AMBox.Visible = false;
        }

        private void transcribe_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            //progressBar1.Value = e.ProgressPercentage;
        }
        private void transcribe(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            //byte[] toBytes = Encoding.ASCII.GetBytes(@"C:\Users\abzachshan\Source\Repos\shasam\AudioTranscription\AudioTranscription\Resources\Guitar.wav");
            //System.IO.Stream wavFileStream = new System.IO.MemoryStream(toBytes);
            //WaveFile wav = WaveFile.Parse(wavFileStream);
            //for (int i = 0; i < wav.Data.Length; i++)
            //    Console.WriteLine(wav.Data[i]);

            double[] wavData;
            double[] nothing;
            //StreamFromFileSample.WaveFile.openWav("Resources/Guitar2.wav", out wavData,out nothing);
            //for (int i = 0; i < wavData.Length; i++)
            //    Console.WriteLine(wavData[i]);
            int samplesRate =  StreamFromFileSample.WaveFile.openWav("Resources/Guitar.wav", out wavData,out nothing, 22050);
            int BPM = 80;
            int N = 1024;
            int h = N / 4;
            int minFreq = 0;
            int maxFreq = 500;

            double[] window = new double[N];
            for (int i = 0; i < N; i++)
            {
                window[i] = 1;
            }

            double[] arr = FourierTransform.Energy(wavData, h, window, N, minFreq, maxFreq);
            double[] thresh = Thresholding.FixedThresholdRelativeNormalize(arr, 0.2);
            List<int> windowPeaks = PeakPicking.FindPeaksWithThreshold(thresh, (int)(samplesRate*(double)BPM/60)/h);
            List<int> signalPeaks = new List<int>(windowPeaks.Count);
            for (int i = 0; i < windowPeaks.Count; i++)
            {
                signalPeaks.Add(windowPeaks[i] * h + N/2);
            }
            double q = 0;
            PitchTracking.PitchDetectionForAllPeaks(wavData, 4096, ref q, samplesRate, signalPeaks);

        }


        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            checkBtnGuitar.Visible = true;
            checkBtnPiano.Visible = false;
            checkBtnUku.Visible = false;
            choosen = 1;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            checkBtnGuitar.Visible = false;
            checkBtnPiano.Visible = true;
            checkBtnUku.Visible = false;
            choosen = 2;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            checkBtnGuitar.Visible = false;
            checkBtnPiano.Visible = false;
            checkBtnUku.Visible = true;
            choosen = 3;
        }

        private void browseBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog folderBrowserDialog1 = new OpenFileDialog();
            folderBrowserDialog1.Filter = "Wav Files(*.wav)|*.wav";
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                this.fileTextBox.Text = folderBrowserDialog1.FileName;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            timer1.Enabled = false;
        }

        private void AMBox_Click(object sender, EventArgs e)
        {

        }
    }
}
