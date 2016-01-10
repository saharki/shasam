using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AudioTranscription
{
    public partial class MainWindow : Form
    {
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
            ResultWindow r = new ResultWindow();
            r.Show();
         
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            checkBtnGuitar.Visible = true;
            checkBtnPiano.Visible = false;
            checkBtnUku.Visible = false;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            checkBtnGuitar.Visible = false;
            checkBtnPiano.Visible = true;
            checkBtnUku.Visible = false;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            checkBtnGuitar.Visible = false;
            checkBtnPiano.Visible = false;
            checkBtnUku.Visible = true;
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
    }
}
