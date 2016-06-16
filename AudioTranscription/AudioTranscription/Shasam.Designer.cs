namespace AudioTranscription
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.BtnTranscribe = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.AMBox = new System.Windows.Forms.PictureBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.helpTextBox = new System.Windows.Forms.RichTextBox();
            this.Settings = new System.Windows.Forms.TabPage();
            this.notesSettingsGroupBox = new System.Windows.Forms.GroupBox();
            this.isFlatCheckBox = new System.Windows.Forms.CheckBox();
            this.resetBtn = new System.Windows.Forms.Button();
            this.STFTSettingsGroupBox = new System.Windows.Forms.GroupBox();
            this.isDFTCheckBox = new System.Windows.Forms.CheckBox();
            this.hopSizeTextBox = new System.Windows.Forms.TextBox();
            this.windowSizeTextBox = new System.Windows.Forms.TextBox();
            this.hopSizeLabel = new System.Windows.Forms.Label();
            this.windowLabel = new System.Windows.Forms.Label();
            this.detetcionSettingsGroupBox = new System.Windows.Forms.GroupBox();
            this.bpmAutoDetectionCheckBox = new System.Windows.Forms.CheckBox();
            this.BPMLabel = new System.Windows.Forms.Label();
            this.BPMTextBox = new System.Windows.Forms.TextBox();
            this.thresholdTextBox = new System.Windows.Forms.TextBox();
            this.thresholdLabel = new System.Windows.Forms.Label();
            this.General = new System.Windows.Forms.TabPage();
            this.checkBtnUku = new System.Windows.Forms.PictureBox();
            this.checkBtnPiano = new System.Windows.Forms.PictureBox();
            this.checkBtnGuitar = new System.Windows.Forms.PictureBox();
            this.chooseFileLabel = new System.Windows.Forms.Label();
            this.chooseInstrumentLabel = new System.Windows.Forms.Label();
            this.ukulelePictureBox = new System.Windows.Forms.PictureBox();
            this.pianoPictureBox = new System.Windows.Forms.PictureBox();
            this.guitarPictureBox = new System.Windows.Forms.PictureBox();
            this.browseBtn = new System.Windows.Forms.Button();
            this.fileTextBox = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            ((System.ComponentModel.ISupportInitialize)(this.AMBox)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.Settings.SuspendLayout();
            this.notesSettingsGroupBox.SuspendLayout();
            this.STFTSettingsGroupBox.SuspendLayout();
            this.detetcionSettingsGroupBox.SuspendLayout();
            this.General.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkBtnUku)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkBtnPiano)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkBtnGuitar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ukulelePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pianoPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guitarPictureBox)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnTranscribe
            // 
            this.BtnTranscribe.Location = new System.Drawing.Point(167, 235);
            this.BtnTranscribe.Name = "BtnTranscribe";
            this.BtnTranscribe.Size = new System.Drawing.Size(180, 35);
            this.BtnTranscribe.TabIndex = 2;
            this.BtnTranscribe.Text = "Transcribe";
            this.BtnTranscribe.UseVisualStyleBackColor = true;
            this.BtnTranscribe.Click += new System.EventHandler(this.transcribeBtn_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(3, 276);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(507, 23);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.TabIndex = 4;
            // 
            // AMBox
            // 
            this.AMBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.AMBox.Image = global::AudioTranscription.Properties.Resources.tumblr_nnkphfBghk1u64di7o1_500;
            this.AMBox.Location = new System.Drawing.Point(-8, -1);
            this.AMBox.Name = "AMBox";
            this.AMBox.Size = new System.Drawing.Size(529, 232);
            this.AMBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.AMBox.TabIndex = 7;
            this.AMBox.TabStop = false;
            this.AMBox.Visible = false;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.helpTextBox);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(503, 203);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Help";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // helpTextBox
            // 
            this.helpTextBox.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.helpTextBox.Location = new System.Drawing.Point(2, 0);
            this.helpTextBox.Name = "helpTextBox";
            this.helpTextBox.ReadOnly = true;
            this.helpTextBox.Size = new System.Drawing.Size(501, 203);
            this.helpTextBox.TabIndex = 0;
            this.helpTextBox.Text = resources.GetString("helpTextBox.Text");
            // 
            // Settings
            // 
            this.Settings.Controls.Add(this.notesSettingsGroupBox);
            this.Settings.Controls.Add(this.resetBtn);
            this.Settings.Controls.Add(this.STFTSettingsGroupBox);
            this.Settings.Controls.Add(this.detetcionSettingsGroupBox);
            this.Settings.Location = new System.Drawing.Point(4, 22);
            this.Settings.Name = "Settings";
            this.Settings.Padding = new System.Windows.Forms.Padding(3);
            this.Settings.Size = new System.Drawing.Size(503, 203);
            this.Settings.TabIndex = 1;
            this.Settings.Text = "Settings";
            this.Settings.UseVisualStyleBackColor = true;
            // 
            // notesSettingsGroupBox
            // 
            this.notesSettingsGroupBox.Controls.Add(this.isFlatCheckBox);
            this.notesSettingsGroupBox.Location = new System.Drawing.Point(11, 127);
            this.notesSettingsGroupBox.Name = "notesSettingsGroupBox";
            this.notesSettingsGroupBox.Size = new System.Drawing.Size(228, 38);
            this.notesSettingsGroupBox.TabIndex = 6;
            this.notesSettingsGroupBox.TabStop = false;
            this.notesSettingsGroupBox.Text = "Notes Settings";
            this.notesSettingsGroupBox.Enter += new System.EventHandler(this.groupBox3_Enter);
            // 
            // isFlatCheckBox
            // 
            this.isFlatCheckBox.AutoSize = true;
            this.isFlatCheckBox.Location = new System.Drawing.Point(13, 15);
            this.isFlatCheckBox.Name = "isFlatCheckBox";
            this.isFlatCheckBox.Size = new System.Drawing.Size(158, 17);
            this.isFlatCheckBox.TabIndex = 0;
            this.isFlatCheckBox.Text = "Show flats instead of sharps";
            this.isFlatCheckBox.UseVisualStyleBackColor = true;
            this.isFlatCheckBox.CheckedChanged += new System.EventHandler(this.isFlatCheckBox_CheckedChanged);
            // 
            // resetBtn
            // 
            this.resetBtn.Location = new System.Drawing.Point(414, 173);
            this.resetBtn.Name = "resetBtn";
            this.resetBtn.Size = new System.Drawing.Size(83, 24);
            this.resetBtn.TabIndex = 5;
            this.resetBtn.Text = "Reset";
            this.resetBtn.UseVisualStyleBackColor = true;
            this.resetBtn.Click += new System.EventHandler(this.resetBtn_Click);
            // 
            // STFTSettingsGroupBox
            // 
            this.STFTSettingsGroupBox.Controls.Add(this.isDFTCheckBox);
            this.STFTSettingsGroupBox.Controls.Add(this.hopSizeTextBox);
            this.STFTSettingsGroupBox.Controls.Add(this.windowSizeTextBox);
            this.STFTSettingsGroupBox.Controls.Add(this.hopSizeLabel);
            this.STFTSettingsGroupBox.Controls.Add(this.windowLabel);
            this.STFTSettingsGroupBox.Location = new System.Drawing.Point(11, 6);
            this.STFTSettingsGroupBox.Name = "STFTSettingsGroupBox";
            this.STFTSettingsGroupBox.Size = new System.Drawing.Size(228, 115);
            this.STFTSettingsGroupBox.TabIndex = 4;
            this.STFTSettingsGroupBox.TabStop = false;
            this.STFTSettingsGroupBox.Text = "STFT Settings";
            // 
            // isDFTCheckBox
            // 
            this.isDFTCheckBox.AutoSize = true;
            this.isDFTCheckBox.Location = new System.Drawing.Point(13, 83);
            this.isDFTCheckBox.Name = "isDFTCheckBox";
            this.isDFTCheckBox.Size = new System.Drawing.Size(140, 17);
            this.isDFTCheckBox.TabIndex = 5;
            this.isDFTCheckBox.Text = "Use DFT instead of FFT";
            this.isDFTCheckBox.UseVisualStyleBackColor = true;
            this.isDFTCheckBox.CheckedChanged += new System.EventHandler(this.isDFTCheckBox_CheckedChanged);
            // 
            // hopSizeTextBox
            // 
            this.hopSizeTextBox.ForeColor = System.Drawing.SystemColors.GrayText;
            this.hopSizeTextBox.Location = new System.Drawing.Point(85, 58);
            this.hopSizeTextBox.Name = "hopSizeTextBox";
            this.hopSizeTextBox.Size = new System.Drawing.Size(137, 20);
            this.hopSizeTextBox.TabIndex = 4;
            this.hopSizeTextBox.TextChanged += new System.EventHandler(this.hopSizeTextBox_TextChanged);
            // 
            // windowSizeTextBox
            // 
            this.windowSizeTextBox.ForeColor = System.Drawing.SystemColors.GrayText;
            this.windowSizeTextBox.Location = new System.Drawing.Point(85, 28);
            this.windowSizeTextBox.Name = "windowSizeTextBox";
            this.windowSizeTextBox.Size = new System.Drawing.Size(137, 20);
            this.windowSizeTextBox.TabIndex = 3;
            this.windowSizeTextBox.TextChanged += new System.EventHandler(this.windowSizeTextBox_TextChanged);
            // 
            // hopSizeLabel
            // 
            this.hopSizeLabel.AutoSize = true;
            this.hopSizeLabel.Location = new System.Drawing.Point(10, 58);
            this.hopSizeLabel.Name = "hopSizeLabel";
            this.hopSizeLabel.Size = new System.Drawing.Size(72, 13);
            this.hopSizeLabel.TabIndex = 2;
            this.hopSizeLabel.Text = "Hop Size [ms]";
            // 
            // windowLabel
            // 
            this.windowLabel.AutoSize = true;
            this.windowLabel.Location = new System.Drawing.Point(10, 31);
            this.windowLabel.Name = "windowLabel";
            this.windowLabel.Size = new System.Drawing.Size(68, 13);
            this.windowLabel.TabIndex = 1;
            this.windowLabel.Text = "Window [ms]";
            // 
            // detetcionSettingsGroupBox
            // 
            this.detetcionSettingsGroupBox.Controls.Add(this.bpmAutoDetectionCheckBox);
            this.detetcionSettingsGroupBox.Controls.Add(this.BPMLabel);
            this.detetcionSettingsGroupBox.Controls.Add(this.BPMTextBox);
            this.detetcionSettingsGroupBox.Controls.Add(this.thresholdTextBox);
            this.detetcionSettingsGroupBox.Controls.Add(this.thresholdLabel);
            this.detetcionSettingsGroupBox.Location = new System.Drawing.Point(259, 6);
            this.detetcionSettingsGroupBox.Name = "detetcionSettingsGroupBox";
            this.detetcionSettingsGroupBox.Size = new System.Drawing.Size(217, 115);
            this.detetcionSettingsGroupBox.TabIndex = 3;
            this.detetcionSettingsGroupBox.TabStop = false;
            this.detetcionSettingsGroupBox.Text = "Detection Settings";
            // 
            // bpmAutoDetectionCheckBox
            // 
            this.bpmAutoDetectionCheckBox.AutoSize = true;
            this.bpmAutoDetectionCheckBox.Location = new System.Drawing.Point(66, 83);
            this.bpmAutoDetectionCheckBox.Name = "bpmAutoDetectionCheckBox";
            this.bpmAutoDetectionCheckBox.Size = new System.Drawing.Size(83, 17);
            this.bpmAutoDetectionCheckBox.TabIndex = 4;
            this.bpmAutoDetectionCheckBox.Text = "Auto Detect";
            this.bpmAutoDetectionCheckBox.UseVisualStyleBackColor = true;
            this.bpmAutoDetectionCheckBox.CheckedChanged += new System.EventHandler(this.bpmAutoDetectionCheckBox_CheckedChanged);
            // 
            // BPMLabel
            // 
            this.BPMLabel.AutoSize = true;
            this.BPMLabel.Location = new System.Drawing.Point(6, 60);
            this.BPMLabel.Name = "BPMLabel";
            this.BPMLabel.Size = new System.Drawing.Size(30, 13);
            this.BPMLabel.TabIndex = 3;
            this.BPMLabel.Text = "BPM";
            // 
            // BPMTextBox
            // 
            this.BPMTextBox.ForeColor = System.Drawing.SystemColors.GrayText;
            this.BPMTextBox.Location = new System.Drawing.Point(66, 57);
            this.BPMTextBox.Name = "BPMTextBox";
            this.BPMTextBox.Size = new System.Drawing.Size(144, 20);
            this.BPMTextBox.TabIndex = 2;
            this.BPMTextBox.TextChanged += new System.EventHandler(this.BPMTextBox_TextChanged);
            // 
            // thresholdTextBox
            // 
            this.thresholdTextBox.ForeColor = System.Drawing.SystemColors.GrayText;
            this.thresholdTextBox.Location = new System.Drawing.Point(66, 28);
            this.thresholdTextBox.Name = "thresholdTextBox";
            this.thresholdTextBox.Size = new System.Drawing.Size(145, 20);
            this.thresholdTextBox.TabIndex = 1;
            this.thresholdTextBox.TextChanged += new System.EventHandler(this.thresholdTextBox_TextChanged);
            // 
            // thresholdLabel
            // 
            this.thresholdLabel.AutoSize = true;
            this.thresholdLabel.Location = new System.Drawing.Point(6, 31);
            this.thresholdLabel.Name = "thresholdLabel";
            this.thresholdLabel.Size = new System.Drawing.Size(54, 13);
            this.thresholdLabel.TabIndex = 0;
            this.thresholdLabel.Text = "Threshold";
            // 
            // General
            // 
            this.General.Controls.Add(this.checkBtnUku);
            this.General.Controls.Add(this.checkBtnPiano);
            this.General.Controls.Add(this.checkBtnGuitar);
            this.General.Controls.Add(this.chooseFileLabel);
            this.General.Controls.Add(this.chooseInstrumentLabel);
            this.General.Controls.Add(this.ukulelePictureBox);
            this.General.Controls.Add(this.pianoPictureBox);
            this.General.Controls.Add(this.guitarPictureBox);
            this.General.Controls.Add(this.browseBtn);
            this.General.Controls.Add(this.fileTextBox);
            this.General.Location = new System.Drawing.Point(4, 22);
            this.General.Name = "General";
            this.General.Padding = new System.Windows.Forms.Padding(3);
            this.General.Size = new System.Drawing.Size(503, 203);
            this.General.TabIndex = 0;
            this.General.Text = "General";
            this.General.UseVisualStyleBackColor = true;
            // 
            // checkBtnUku
            // 
            this.checkBtnUku.Image = global::AudioTranscription.Properties.Resources.rcLn4qBAi;
            this.checkBtnUku.Location = new System.Drawing.Point(468, 113);
            this.checkBtnUku.Name = "checkBtnUku";
            this.checkBtnUku.Size = new System.Drawing.Size(21, 17);
            this.checkBtnUku.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.checkBtnUku.TabIndex = 9;
            this.checkBtnUku.TabStop = false;
            this.checkBtnUku.Visible = false;
            // 
            // checkBtnPiano
            // 
            this.checkBtnPiano.Image = global::AudioTranscription.Properties.Resources.rcLn4qBAi;
            this.checkBtnPiano.Location = new System.Drawing.Point(304, 113);
            this.checkBtnPiano.Name = "checkBtnPiano";
            this.checkBtnPiano.Size = new System.Drawing.Size(21, 17);
            this.checkBtnPiano.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.checkBtnPiano.TabIndex = 8;
            this.checkBtnPiano.TabStop = false;
            this.checkBtnPiano.Visible = false;
            // 
            // checkBtnGuitar
            // 
            this.checkBtnGuitar.Image = global::AudioTranscription.Properties.Resources.rcLn4qBAi;
            this.checkBtnGuitar.Location = new System.Drawing.Point(138, 113);
            this.checkBtnGuitar.Name = "checkBtnGuitar";
            this.checkBtnGuitar.Size = new System.Drawing.Size(21, 17);
            this.checkBtnGuitar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.checkBtnGuitar.TabIndex = 7;
            this.checkBtnGuitar.TabStop = false;
            this.checkBtnGuitar.Visible = false;
            // 
            // chooseFileLabel
            // 
            this.chooseFileLabel.AutoSize = true;
            this.chooseFileLabel.Location = new System.Drawing.Point(11, 146);
            this.chooseFileLabel.Name = "chooseFileLabel";
            this.chooseFileLabel.Size = new System.Drawing.Size(62, 13);
            this.chooseFileLabel.TabIndex = 6;
            this.chooseFileLabel.Text = "Choose File";
            // 
            // chooseInstrumentLabel
            // 
            this.chooseInstrumentLabel.AutoSize = true;
            this.chooseInstrumentLabel.Location = new System.Drawing.Point(11, 3);
            this.chooseInstrumentLabel.Name = "chooseInstrumentLabel";
            this.chooseInstrumentLabel.Size = new System.Drawing.Size(95, 13);
            this.chooseInstrumentLabel.TabIndex = 5;
            this.chooseInstrumentLabel.Text = "Choose Instrument";
            // 
            // ukulelePictureBox
            // 
            this.ukulelePictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ukulelePictureBox.Image = global::AudioTranscription.Properties.Resources.uku;
            this.ukulelePictureBox.Location = new System.Drawing.Point(341, 19);
            this.ukulelePictureBox.Name = "ukulelePictureBox";
            this.ukulelePictureBox.Size = new System.Drawing.Size(149, 112);
            this.ukulelePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ukulelePictureBox.TabIndex = 4;
            this.ukulelePictureBox.TabStop = false;
            this.ukulelePictureBox.Click += new System.EventHandler(this.ukulelePictureBox_Click);
            // 
            // pianoPictureBox
            // 
            this.pianoPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pianoPictureBox.Image = global::AudioTranscription.Properties.Resources.v_piano_grand_angle_open_full_gal;
            this.pianoPictureBox.Location = new System.Drawing.Point(177, 19);
            this.pianoPictureBox.Name = "pianoPictureBox";
            this.pianoPictureBox.Size = new System.Drawing.Size(149, 112);
            this.pianoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pianoPictureBox.TabIndex = 3;
            this.pianoPictureBox.TabStop = false;
            this.pianoPictureBox.Click += new System.EventHandler(this.pianoPictureBox_Click);
            // 
            // guitarPictureBox
            // 
            this.guitarPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.guitarPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.guitarPictureBox.Image = global::AudioTranscription.Properties.Resources.tak_etn10c_front;
            this.guitarPictureBox.Location = new System.Drawing.Point(11, 19);
            this.guitarPictureBox.Name = "guitarPictureBox";
            this.guitarPictureBox.Size = new System.Drawing.Size(149, 112);
            this.guitarPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guitarPictureBox.TabIndex = 2;
            this.guitarPictureBox.TabStop = false;
            this.guitarPictureBox.Click += new System.EventHandler(this.guitarPictureBox_Click);
            // 
            // browseBtn
            // 
            this.browseBtn.Location = new System.Drawing.Point(375, 162);
            this.browseBtn.Name = "browseBtn";
            this.browseBtn.Size = new System.Drawing.Size(118, 20);
            this.browseBtn.TabIndex = 1;
            this.browseBtn.Text = "Browse";
            this.browseBtn.UseVisualStyleBackColor = true;
            this.browseBtn.Click += new System.EventHandler(this.browseBtn_Click);
            // 
            // fileTextBox
            // 
            this.fileTextBox.Enabled = false;
            this.fileTextBox.Location = new System.Drawing.Point(11, 162);
            this.fileTextBox.Name = "fileTextBox";
            this.fileTextBox.Size = new System.Drawing.Size(360, 20);
            this.fileTextBox.TabIndex = 0;
            this.fileTextBox.TextChanged += new System.EventHandler(this.fileTextBox_TextChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.General);
            this.tabControl1.Controls.Add(this.Settings);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(-3, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(511, 229);
            this.tabControl1.TabIndex = 1;
            // 
            // MainWindow
            // 
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(513, 301);
            this.Controls.Add(this.AMBox);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.BtnTranscribe);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.Text = "Shasam";
            ((System.ComponentModel.ISupportInitialize)(this.AMBox)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.Settings.ResumeLayout(false);
            this.notesSettingsGroupBox.ResumeLayout(false);
            this.notesSettingsGroupBox.PerformLayout();
            this.STFTSettingsGroupBox.ResumeLayout(false);
            this.STFTSettingsGroupBox.PerformLayout();
            this.detetcionSettingsGroupBox.ResumeLayout(false);
            this.detetcionSettingsGroupBox.PerformLayout();
            this.General.ResumeLayout(false);
            this.General.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkBtnUku)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkBtnPiano)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkBtnGuitar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ukulelePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pianoPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guitarPictureBox)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button BtnTranscribe;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.HelpProvider helpProvider1;
        private System.Windows.Forms.PictureBox AMBox;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.RichTextBox helpTextBox;
        private System.Windows.Forms.TabPage Settings;
        private System.Windows.Forms.GroupBox notesSettingsGroupBox;
        private System.Windows.Forms.CheckBox isFlatCheckBox;
        private System.Windows.Forms.Button resetBtn;
        private System.Windows.Forms.GroupBox STFTSettingsGroupBox;
        private System.Windows.Forms.CheckBox isDFTCheckBox;
        private System.Windows.Forms.TextBox hopSizeTextBox;
        private System.Windows.Forms.TextBox windowSizeTextBox;
        private System.Windows.Forms.Label hopSizeLabel;
        private System.Windows.Forms.Label windowLabel;
        private System.Windows.Forms.GroupBox detetcionSettingsGroupBox;
        private System.Windows.Forms.CheckBox bpmAutoDetectionCheckBox;
        private System.Windows.Forms.Label BPMLabel;
        private System.Windows.Forms.TextBox BPMTextBox;
        private System.Windows.Forms.TextBox thresholdTextBox;
        private System.Windows.Forms.Label thresholdLabel;
        private System.Windows.Forms.TabPage General;
        private System.Windows.Forms.PictureBox checkBtnUku;
        private System.Windows.Forms.PictureBox checkBtnPiano;
        private System.Windows.Forms.PictureBox checkBtnGuitar;
        private System.Windows.Forms.Label chooseFileLabel;
        private System.Windows.Forms.Label chooseInstrumentLabel;
        private System.Windows.Forms.PictureBox ukulelePictureBox;
        private System.Windows.Forms.PictureBox pianoPictureBox;
        private System.Windows.Forms.PictureBox guitarPictureBox;
        private System.Windows.Forms.Button browseBtn;
        private System.Windows.Forms.TextBox fileTextBox;
        private System.Windows.Forms.TabControl tabControl1;
    }
}

