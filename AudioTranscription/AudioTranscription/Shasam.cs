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
        private BackgroundWorker transcribeWorker; 

        private int chosenInstrument = 0;
        private int windowSizeInMs;
        private int hopSizeInMs;
        private float threshold;
        private int BPM;
        private string wavFilePath;

        public MainWindow()
        {
            InitializeComponent();

            ResetToDefaultSettings();

            transcribeWorker = new BackgroundWorker();
            transcribeWorker.DoWork += Transcription.Transcribe;
            transcribeWorker.ProgressChanged += transcribe_ProgressChanged;
            transcribeWorker.WorkerReportsProgress = true;
            transcribeWorker.RunWorkerCompleted += transcribe_Completed;
        }

        private void transcribe_Completed(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            ResultWindow r = new ResultWindow();
            r.Show();
            AMBox.Visible = false;
        }

        private void transcribe_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void ResetToDefaultSettings()
        {
            windowSizeInMs = 40;
            hopSizeInMs = 10;
            threshold = (float)0.2;
            BPM = 80;

            windowSizeTextBox.Text = windowSizeInMs.ToString();
            windowSizeTextBox.ForeColor = Color.Gray;

            hopSizeTextBox.Text = hopSizeInMs.ToString();
            hopSizeTextBox.ForeColor = Color.Gray;

            thresholdTextBox.Text = threshold.ToString();
            thresholdTextBox.ForeColor = Color.Gray;

            BPMTextBox.Text = BPM.ToString();
            BPMTextBox.ForeColor = Color.Gray;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            checkBtnGuitar.Visible = true;
            checkBtnPiano.Visible = false;
            checkBtnUku.Visible = false;
            chosenInstrument = 1;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            checkBtnGuitar.Visible = false;
            checkBtnPiano.Visible = true;
            checkBtnUku.Visible = false;
            chosenInstrument = 2;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            checkBtnGuitar.Visible = false;
            checkBtnPiano.Visible = false;
            checkBtnUku.Visible = true;
            chosenInstrument = 3;
        }

        private void browseBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog folderBrowserDialog = new OpenFileDialog();
            folderBrowserDialog.Filter = "Wav Files(*.wav)|*.wav";
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                this.fileTextBox.Text = folderBrowserDialog.FileName;
            }
        }

        private void transcribeBtn_Click(object sender, EventArgs e)
        {
            if (chosenInstrument == 0)
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
                BtnTranscribe.Enabled = false;
                Transcription.Initialize(windowSizeInMs, hopSizeInMs, threshold, BPM, wavFilePath, chosenInstrument);
                transcribeWorker.RunWorkerAsync();
            }
        }

        private void windowSizeTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                windowSizeInMs = int.Parse(windowSizeTextBox.Text);
                windowSizeTextBox.ForeColor = Color.Black;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error has occurred: {0}", ex.Message);
                windowSizeTextBox.ForeColor = Color.Red;
            }
        }

        private void hopSizeTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                hopSizeInMs = int.Parse(hopSizeTextBox.Text);
                hopSizeTextBox.ForeColor = Color.Black;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error has occurred: {0}", ex.Message);
                hopSizeTextBox.ForeColor = Color.Red;
            }
        }

        private void thresholdTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                threshold = float.Parse(thresholdTextBox.Text);
                thresholdTextBox.ForeColor = Color.Black;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error has occurred: {0}", ex.Message);
                thresholdTextBox.ForeColor = Color.Red;
            }
        }

        private void BPMTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                BPM = int.Parse(BPMTextBox.Text);
                BPMTextBox.ForeColor = Color.Black;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error has occurred: {0}", ex.Message);
                BPMTextBox.ForeColor = Color.Red;
            }
        }

        private void fileTextBox_TextChanged(object sender, EventArgs e)
        {
            wavFilePath = fileTextBox.Text;
        }

        private void resetBtn_Click(object sender, EventArgs e)
        {
            ResetToDefaultSettings();
        }

    }
}
