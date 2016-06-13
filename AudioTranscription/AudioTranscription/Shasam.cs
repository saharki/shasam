using MusicMaker;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace AudioTranscription
{
    public partial class MainWindow : Form
    {
        private BackgroundWorker transcribeWorker; 

        private Instrument chosenInstrument = 0;
        private int windowSizeInMs;
        private int hopSizeInMs;
        private float threshold;
        private int BPM;
        private string wavFilePath;
        private bool isDFT;
        private bool isFlat;

        private bool isWindowValid;
        private bool isHopValid;
        private bool isThresholdValid;
        private bool isBPMValid;

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
            MusicMakerSheet r = new MusicMakerSheet();
            TrasncriptionResult result = ((TrasncriptionResult)e.Result);
            string[] midiNotes = new string[result.Notes.Length];
            int[] noteOctaves = new int[result.Notes.Length];
            string outputNotes = "";

            r.ButtomMeasure = 4;
            r.TopMeasure = 4;

            const int numOfNotesInLine = 29;

            for (int i = 0; i < result.Notes.Length; i++)
            {
                midiNotes[i] = PitchToNoteConverter.GetNoteName((int)PitchToNoteConverter.PitchToMidiNote(result.Notes[i].Frequency), !isFlat, false, out noteOctaves[i]);
                midiNotes[i] += Transcription.OctaveLetter(noteOctaves[i]);
                midiNotes[i] += Transcription.DurationLetter(result.Notes[i].Duration);

                if (result.Notes[i].Frequency <= 0)
                    midiNotes[i] = "";

            }
            int count = 0;
            for(int i = 0; i < midiNotes.Length; i++)
            {
                if(result.Notes[i].Frequency <= 0)
                {
                    continue;
                }
                outputNotes += midiNotes[i];
                outputNotes += " ";
                count++;
                if (count % numOfNotesInLine == 0 && count != 0)
                {
                    outputNotes = outputNotes.Trim(); // remove last " "
                    r.paintByString(outputNotes);
                    outputNotes = "";
                }
            }
            outputNotes = outputNotes.Trim(); // remove last " "
            r.paintByString(outputNotes);

            r.Show();
            AMBox.Visible = false;
            if(bpmAutoDetectionCheckBox.Checked)
                System.Windows.Forms.MessageBox.Show("BPM detected = "+result.BPM);
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

            isDFTCheckBox.Checked =  false;
            isDFT = false;

            isFlatCheckBox.Checked = false;
            isFlat = false;

            isWindowValid=true;
            isHopValid = true;
            isThresholdValid = true;
            isBPMValid = true;
    }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            checkBtnGuitar.Visible = true;
            checkBtnPiano.Visible = false;
            checkBtnUku.Visible = false;
            chosenInstrument = Instrument.GUITAR;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            checkBtnGuitar.Visible = false;
            checkBtnPiano.Visible = true;
            checkBtnUku.Visible = false;
            chosenInstrument = Instrument.PIANO;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            checkBtnGuitar.Visible = false;
            checkBtnPiano.Visible = false;
            checkBtnUku.Visible = true;
            chosenInstrument = Instrument.UKULELE;
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
            else if(isBPMValid && isWindowValid && isHopValid && isThresholdValid)
            {
                AMBox.Visible = true;
                BtnTranscribe.Enabled = false;
                Transcription.Initialize(windowSizeInMs, hopSizeInMs, threshold, BPM, wavFilePath,bpmAutoDetectionCheckBox.Checked, chosenInstrument,CompletedThreadsHandler,isDFT);
                transcribeWorker.RunWorkerAsync();
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Some of the parameters are inavlid.\nPlease change them and try again.");
            }
        }

        private void CompletedThreadsHandler(int completedThreads)
        {
            transcribeWorker.ReportProgress(completedThreads);
        }

        private void windowSizeTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                
                windowSizeInMs = int.Parse(windowSizeTextBox.Text);
                windowSizeTextBox.ForeColor = Color.Black;
                if (windowSizeInMs <= 0)
                    throw new Exception();
                isWindowValid = true;
                //***********************************//
                //(sender as TextBox).ForeColor = Color.Black;
                //***********************************//
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error has occurred: {0}", ex.Message);
                windowSizeTextBox.ForeColor = Color.Red;
                isWindowValid = false;
            }
        }

        private void hopSizeTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                hopSizeInMs = int.Parse(hopSizeTextBox.Text);
                if (hopSizeInMs <= 0)
                    throw new Exception();
                hopSizeTextBox.ForeColor = Color.Black;
                isHopValid = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error has occurred: {0}", ex.Message);
                hopSizeTextBox.ForeColor = Color.Red;
                isHopValid = false;
            }
        }

        private void thresholdTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                threshold = float.Parse(thresholdTextBox.Text);
                if (threshold <= 0 || threshold > 1)
                    throw new Exception();
                thresholdTextBox.ForeColor = Color.Black;
                isThresholdValid = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error has occurred: {0}", ex.Message);
                thresholdTextBox.ForeColor = Color.Red;
                isThresholdValid = false;
            }
        }

        private void BPMTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                BPM = int.Parse(BPMTextBox.Text);
                if (BPM <= 0)
                    throw new Exception();
                BPMTextBox.ForeColor = Color.Black;
                isBPMValid = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error has occurred: {0}", ex.Message);
                BPMTextBox.ForeColor = Color.Red;
                isBPMValid = false;
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

        private void bpmAutoDetectionCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            BPMTextBox.Enabled = (bpmAutoDetectionCheckBox.Checked) ? false : true;
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void isDFTCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            isDFT = isDFTCheckBox.Checked;
        }

        private void isFlatCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            isFlat = isFlatCheckBox.Checked;
        }
    }
}
