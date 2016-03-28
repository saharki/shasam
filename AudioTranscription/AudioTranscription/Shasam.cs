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
            }

            //byte[] toBytes = Encoding.ASCII.GetBytes(@"C:\Users\abzachshan\Source\Repos\shasam\AudioTranscription\AudioTranscription\Resources\Guitar.wav");
            //System.IO.Stream wavFileStream = new System.IO.MemoryStream(toBytes);
            //WaveFile wav = WaveFile.Parse(wavFileStream);
            //for (int i = 0; i < wav.Data.Length; i++)
            //    Console.WriteLine(wav.Data[i]);

            double[] wavData;
            double[] nothing;
            StreamFromFileSample.WaveFile.openWav(@"F:\Users\Sahar\Source\Repos\shasam\AudioTranscription\AudioTranscription\Resources\Guitar2.wav", out wavData,out nothing);
            //for (int i = 0; i < wavData.Length; i++)
            //    Console.WriteLine(wavData[i]);
            double[] window = new double[100];
            for(int i=0;i<100;i++)
            {
                window[i] = 1;
            }
            FourierTransform.DFTWithPrint(wavData, 500, 100, window, 100);
            Complex c1 = new Complex(12, 6);
            Console.WriteLine(c1.Magnitude);

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
            ResultWindow r = new ResultWindow();
            r.Show();
            AMBox.Visible = false;
            timer1.Enabled = false;
        }
    }
}
