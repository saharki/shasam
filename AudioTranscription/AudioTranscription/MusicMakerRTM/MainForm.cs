using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;

/// ************************ MUSIC MAKER ********************
/// By Michael Gold
/// Copyright 2000.  All Rights Reserved
/// *********************************************************

namespace MusicMaker
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class MusicMakerSheet : System.Windows.Forms.Form
	{
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem OpenMenu;
		private System.Windows.Forms.MenuItem menuItem6;
		private System.Windows.Forms.MenuItem SongTitleMenu;
		private System.Windows.Forms.MenuItem menuItem8;
		private System.Windows.Forms.MenuItem ExitMenu;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;

		private NoteReader TheNoteReader = new NoteReader();
		public static int CurrentStaffIndex = 0;
		public static int CurrentMeasureIndex = 0;
		public static int CurrentPageIndex = 0;
		public static int CurrentStaffPosition = 0;
		public static int TopSignature = 8;
		public static int BottomSignature = 4;
		public string SongTitleString = "";
		public ArrayList Pages = new ArrayList();
		private Font TitleFont = new Font("Times New Roman", 16);
		private System.Windows.Forms.MenuItem PrintMenu;
		private System.Windows.Forms.MenuItem PrintPreviewMenu;
		private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
		private System.Drawing.Printing.PrintDocument printDocument1;
        private VScrollBar vScrollBar1;
        private IContainer components;

        public MusicMakerSheet()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			Pages.Add(new Page());
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}



        public void paintByString(string strLine)
        {
            string[] theMeasures = strLine.Split(new char[] { '/' });
            for (int i = 0; i < theMeasures.Length; i++)
            {
                Measure aMeasure = TheNoteReader.CalculateMeasure(theMeasures[i]);
                if(CurrentStaffIndex == ((Page)Pages[CurrentPageIndex]).Staffs.Count)
                {
                    int count = ((Page)Pages[CurrentPageIndex]).Staffs.Count;
                    for (int j = 0; j < count; j++)
                    {
                        ((Page)Pages[CurrentPageIndex]).AddStaff(new Staff());
                    }
                }
                ((Staff)(((Page)Pages[CurrentPageIndex]).Staffs[CurrentStaffIndex])).AddMeasure(aMeasure);
                CurrentMeasureIndex++;
                aMeasure.CalcPosition();
                MusicMakerSheet.CurrentStaffPosition += Note.kNoteSpacing; // add an extra space for the measure
                //if (CurrentStaffPosition > Staff.kStaffInPixels - Note.kNoteSpacing * 7)
                //{
                    CurrentStaffIndex++;
                    CurrentStaffPosition = 0;
                //}
            }
        }

        public string Title
        {
            set
            {
                SongTitleString = value;
            }
            get
            {
                return SongTitleString;
            }
        }
        public int TopMeasure
        {
            set
            {
                TopSignature = value;
            }
            get
            {
                return TopSignature;
            }
        }
        public int ButtomMeasure
        {
            set
            {
                BottomSignature = value;
            }
            get
            {
                return BottomSignature;
            }
        }



        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MusicMakerSheet));
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.OpenMenu = new System.Windows.Forms.MenuItem();
            this.PrintMenu = new System.Windows.Forms.MenuItem();
            this.PrintPreviewMenu = new System.Windows.Forms.MenuItem();
            this.ExitMenu = new System.Windows.Forms.MenuItem();
            this.menuItem6 = new System.Windows.Forms.MenuItem();
            this.SongTitleMenu = new System.Windows.Forms.MenuItem();
            this.menuItem8 = new System.Windows.Forms.MenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem1,
            this.menuItem6});
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 0;
            this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.OpenMenu,
            this.PrintMenu,
            this.PrintPreviewMenu,
            this.ExitMenu});
            this.menuItem1.Text = "File";
            // 
            // OpenMenu
            // 
            this.OpenMenu.Index = 0;
            this.OpenMenu.Text = "Open...";
            this.OpenMenu.Click += new System.EventHandler(this.OpenMenu_Click);
            // 
            // PrintMenu
            // 
            this.PrintMenu.Index = 1;
            this.PrintMenu.Text = "Print...";
            this.PrintMenu.Click += new System.EventHandler(this.PrintMenu_Click);
            // 
            // PrintPreviewMenu
            // 
            this.PrintPreviewMenu.Index = 2;
            this.PrintPreviewMenu.Text = "Print Preview...";
            this.PrintPreviewMenu.Click += new System.EventHandler(this.PrintPreviewMenu_Click);
            // 
            // ExitMenu
            // 
            this.ExitMenu.Index = 3;
            this.ExitMenu.Text = "Exit";
            this.ExitMenu.Click += new System.EventHandler(this.ExitMenu_Click);
            // 
            // menuItem6
            // 
            this.menuItem6.Index = 1;
            this.menuItem6.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.SongTitleMenu,
            this.menuItem8});
            this.menuItem6.Text = "Format";
            // 
            // SongTitleMenu
            // 
            this.SongTitleMenu.Index = 0;
            this.SongTitleMenu.Text = "Song Title";
            this.SongTitleMenu.Click += new System.EventHandler(this.SongTitleMenu_Click);
            // 
            // menuItem8
            // 
            this.menuItem8.Index = 1;
            this.menuItem8.Text = "Measure...";
            this.menuItem8.Click += new System.EventHandler(this.menuItem8_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "*.notes";
            this.openFileDialog1.Filter = "*.notes (Music) | *.* (All Files) ||";
            this.openFileDialog1.Title = "Open Music File";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Document = this.printDocument1;
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.Location = new System.Drawing.Point(687, -5);
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(19, 248);
            this.vScrollBar1.TabIndex = 0;
            // 
            // MusicMakerSheet
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(704, 244);
            this.Controls.Add(this.vScrollBar1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Menu = this.mainMenu1;
            this.Name = "MusicMakerSheet";
            this.Text = "Shasam";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.OnPaint);
            this.ResumeLayout(false);

		}
		#endregion

		private void OpenMenu_Click(object sender, System.EventArgs e)
		{
			try
			{
				//				openFileDialog1 = new OpenFileDialog();
//				openFileDialog1.Reset();
				//				openFileDialog1.InitialDirectory = "c:\\" ;
				//				openFileDialog1.Filter = "song files (*.song)|*.song|All files (*.*)|*.*" ;
				//				openFileDialog1.FilterIndex = 2 ;
				//				openFileDialog1.RestoreDirectory = true ;
				openFileDialog1.FileName = "*.notes"; // do this here because it won't let me do it at design time
				if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
				{
					FileStream fs = new FileStream(openFileDialog1.FileName , FileMode.Open, FileAccess.Read);
					StreamReader m_streamReader = new StreamReader(fs); 
					// Read to the file using StreamReader  class

					m_streamReader.BaseStream.Seek(0, SeekOrigin.Begin);


					// Read  each line of the stream and parse until last line is reached
					InitializeMusic();
					string strLine = m_streamReader.ReadLine();
					while (strLine != null)
					{
						// process the next line
						int keyIndex = strLine.IndexOf(":");
						if (keyIndex != -1) // contains non-note information
						{
							string strKey = strLine.Substring(0, keyIndex);
							strKey = strKey.ToLower();
							switch (strKey)
							{
								case "title":
									SongTitleString = strLine.Substring(keyIndex + 1);
									break;
								case "signature1":
									TopSignature = Convert.ToInt32(strLine.Substring(keyIndex + 1), 10);
									break;
								case "signature2":
									BottomSignature = Convert.ToInt32(strLine.Substring(keyIndex + 1), 10);
									break;
								default:
									break;
							}
						}
						else  // read in notes
						{
							string[] theMeasures = strLine.Split(new char[]{'/'});
							for (int i = 0; i < theMeasures.Length; i++)
							{
								Measure aMeasure = TheNoteReader.CalculateMeasure(theMeasures[i]);
								((Staff)(((Page)Pages[CurrentPageIndex]).Staffs[CurrentStaffIndex])).AddMeasure(aMeasure);
								CurrentMeasureIndex++;
								aMeasure.CalcPosition();
								MusicMakerSheet.CurrentStaffPosition += Note.kNoteSpacing; // add an extra space for the measure
								if (CurrentStaffPosition > Staff.kStaffInPixels - Note.kNoteSpacing * 7)
								{
									CurrentStaffIndex++;
									CurrentStaffPosition = 0;
								}
							}
						}
						strLine = m_streamReader.ReadLine();
					}
					// Close the stream

					m_streamReader.Close();
					Invalidate();
				}   
			}
			catch(Exception em)
			{
				System.Windows.Forms.MessageBox.Show(em.Message.ToString());
				Invalidate();
			}
		}

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
	/*	[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}
        */
		private void ExitMenu_Click(object sender, System.EventArgs e)
		{
			Application.Exit();
		}

		protected void InitializeMusic()
		{
			CurrentPageIndex = 0;
			CurrentStaffIndex = 0;
			CurrentStaffPosition = 0;
			CurrentMeasureIndex = 0;
			Pages.Clear();
			Pages.Add(new Page());
		}

		protected void DrawTitle(Graphics g)
		{
			g.DrawString(SongTitleString, TitleFont, Brushes.Black, ClientRectangle.Width/2 - (int)TitleFont.Size * SongTitleString.Length/2, 5, new StringFormat());
		}


		protected void DrawMusic(Graphics g)
		{
			try
			{
				Rectangle rect = this.ClientRectangle; 
				g.FillRectangle(Brushes.White, rect); 
				DrawTitle(g);
				for (int i = 0; i < Pages.Count; i++)
				{
					((Page)Pages[i]).Draw(g);
				}
			}
			catch(Exception ex)
			{
			 MessageBox.Show(ex.Message.ToString());
			}
			
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{

		}

		private void OnPaint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			Graphics g = e.Graphics; 
			DrawMusic(g);
		}

		private void SongTitleMenu_Click(object sender, System.EventArgs e)
		{
			InputStringForm QuerySong = new InputStringForm();
			QuerySong.QueryLabel = "Enter Title:";
			QuerySong.QueryString = SongTitleString;
			QuerySong.ShowDialog(this);
			if (QuerySong.DialogResult == DialogResult.OK)
			{
				SongTitleString = QuerySong.QueryString;
				Invalidate();
			}

		}

		private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
		{
		
		}

		private void menuItem8_Click(object sender, System.EventArgs e)
		{
		  SignatureInputForm dlg = new SignatureInputForm();
			dlg.numericUpDown1.Value = TopSignature;
			dlg.numericUpDown2.Value = BottomSignature;
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				TopSignature = (int)dlg.numericUpDown1.Value;
				BottomSignature = (int)dlg.numericUpDown2.Value;
				Invalidate();
			}
		}

		private void PrintMenu_Click(object sender, System.EventArgs e)
		{
		  printDocument1.Print();
		}

		private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
		{
		  DrawMusic(e.Graphics);
		}

		private void PrintPreviewMenu_Click(object sender, System.EventArgs e)
		{
			if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
			{
				
			}
		}


	}
}
