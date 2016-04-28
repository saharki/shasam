namespace MusicMaker
{

	/// ************************ MUSIC MAKER ********************
	/// By Michael Gold
	/// Copyright 2000.  All Rights Reserved
	/// *********************************************************

    using System;
	using System.Windows.Forms;
	using System.Drawing;
	using System.Drawing.Drawing2D;
	using System.Drawing.Imaging;
	using System.Collections;

    /// <summary>
    ///    This is the class for drawing the staff
    /// </summary>
    public class Staff
    {
		public const int kOffset = 30;
		public const int kSignatureOffset = 25;
		public const int kStaffSpacing = 70;
		public const int kBarSpacing = 7;
		const int kNumMeasuresOnAStaff = 4;
		public const int kStaffInPixels = 800;
		private Font SignatureFont = new Font("Times New Roman", 14);
		private Image aPic = new Bitmap("MusicMakerRTM\\clef1.gif");

		ArrayList Measures = new ArrayList();

        public Staff()
        {
			try
			{
			}
			catch(Exception e)
			{
				MessageBox.Show(e.Message.ToString());
			}
            // 
	        // TODO: Add Constructor Logic here
	        //
//			for (int i = 0; i < kNumMeasuresOnAStaff; i ++)
//		{
//				Measures.Add(new Measure());
//		}

        }

		public void AddMeasure(Measure aMeasure)
		{
			Measures.Add(aMeasure);
		}

		public void DrawClef(Graphics g, int staffIndex)
		{
			g.DrawImage(aPic, 0, kOffset + staffIndex * kStaffSpacing, aPic.Width, kBarSpacing * 4);
		}

		protected void DrawSignature(Graphics g, int staffIndex)
		{
			g.DrawString(MusicMakerSheet.TopSignature.ToString(), SignatureFont, Brushes.Black, kSignatureOffset, kOffset + staffIndex * kStaffSpacing - 3,  new StringFormat());
			g.DrawString(MusicMakerSheet.BottomSignature.ToString(), SignatureFont, Brushes.Black, kSignatureOffset, kOffset + staffIndex * kStaffSpacing + SignatureFont.Size - 3,  new StringFormat());
		}


		public void Draw (Graphics g, int staffIndex)
		{
			DrawClef(g, staffIndex);
			DrawSignature(g, staffIndex);
			int yPos = kOffset + staffIndex * kStaffSpacing;
			for (int bars = 0; bars < 5; bars++)
				{
				 g.DrawLine(Pens.Black, 0, yPos, kStaffInPixels, yPos);
				 yPos += kBarSpacing;
				}

			for (int i = 0; i < Measures.Count; i++)
			{
				((Measure)Measures[i]).Draw(g);
			}
		}

    }
}
