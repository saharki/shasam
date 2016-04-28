namespace MusicMaker
{

	/// ************************ MUSIC MAKER ********************
	/// By Michael Gold
	/// Copyright 2000.  All Rights Reserved
	/// *********************************************************

    using System;

    /// <summary>
    ///    reads notes from a text music file
    /// </summary>
    public class NoteReader
    {
        public NoteReader()
        {
            // 
	        // TODO: Add Constructor Logic here
	        //
        }

		public Measure CalculateMeasure (string aMeasureString)
		{
			Measure aMeasure = new Measure();
			string[] noteStrings = aMeasureString.Split(new char[]{' '});
			for (int i = 0; i < noteStrings.Length; i++)
			{
				Note aNote = new Note();
				aNote.Fill(noteStrings[i]);
				aNote.CalcPosition();
				aMeasure.AddNote(aNote);
				MusicMakerSheet.CurrentStaffPosition += Note.kNoteSpacing;
			}

			return aMeasure;
		}
    }
}
