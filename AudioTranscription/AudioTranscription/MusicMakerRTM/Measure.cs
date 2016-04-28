namespace MusicMaker
{

	/// ************************ MUSIC MAKER ********************
	/// By Michael Gold
	/// Copyright 2000.  All Rights Reserved
	/// *********************************************************

    using System;
	using System.Drawing;
	using System.Collections;

    /// <summary>
    ///    Measure of Notes on the Staff
    /// </summary>
    public class Measure
    {
		ArrayList Notes = new ArrayList();
		public int XPosition = 0;
		public int YPosition = 0;
		const int MeasureHeight = Staff.kBarSpacing * 4;
		const int MeasureWidth = 3;


		public void CalcPosition()
		{
 		 XPosition = MusicMakerSheet.CurrentStaffPosition + Note.kClefOffset;
		 YPosition = MusicMakerSheet.CurrentStaffIndex * Staff.kStaffSpacing  + Staff.kOffset;
		}

        public Measure()
        {
            // 
	        // TODO: Add Constructor Logic here
	        //
        }

		public void AddNote(Note aNote)
		{
			Notes.Add(aNote);
		}

		public void Draw (Graphics g)
		{
			for (int i=0; i < Notes.Count; i++)
			{
				((Note)Notes[i]).Draw(g, i);
			}

			g.FillRectangle(Brushes.Black, XPosition, YPosition, MeasureWidth, MeasureHeight);
		}
    }
}
