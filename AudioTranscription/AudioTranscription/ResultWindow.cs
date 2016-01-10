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
    public partial class ResultWindow : Form
    {
        public ResultWindow()
        {
            InitializeComponent();
        }

        private void ResultWindow_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            AMBox.Visible = false;
        }
    }
}
