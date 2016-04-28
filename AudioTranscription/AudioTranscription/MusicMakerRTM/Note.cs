namespace MusicMaker
{

	/// ************************ MUSIC MAKER ********************
	/// By Michael Gold
	/// Copyright 2000.  All Rights Reserved
	/// *********************************************************

    using System;
	using System.Drawing;

    /// <summary>
    ///    This is the base class for drawing notes
    /// </summary>
    public class Note
    {
		protected const int kXRadius = 4;
		protected const int kYRadius = 3;
		protected const int kStem = 15;
		protected bool HasLine = false;
		public const int kNoteSpacing = 20;
		public const int kClefOffset = 50;

		public enum Chromatic
		{
		  Flat,
		  Sharp,
		  Natural
		};

		public enum Timing
		{
		 sixteenth,
		 eighth,
		 quarter,
		 half,
		 third,
		 whole
		};

		public enum Pitch
		{
		  C,
		  D,
		  E,
		  F,
		  G,
		  A,
		  B
		}

		public enum Octave
		{
		  low,
		  middle,
		  high
		}



		public Point Position = new Point(0,0);
		public Chromatic TheChromatic = Chromatic.Natural;
		public Timing TheTiming = Timing.quarter;
		public Pitch ThePitch = Pitch.C;
		public Octave TheOctave = Octave.middle;
		
        public Note()
        {
            // 
	        // TODO: Add Constructor Logic here
	        //
        }


		public int CalcPosition()
		{
		 int n = (int)ThePitch;
		 if (TheOctave == Octave.high)
		 {
			 n += 7;
		 }
		 if (TheOctave == Octave.low)
		 {
			 n -= 7;
		 }

		 if ((n % 2) == 0)
		 {
			 HasLine = true;
		 }
		 n = Staff.kBarSpacing * 5 - (n * Staff.kBarSpacing)/2;
		 Position.X = Form1.CurrentStaffPosition  + kClefOffset;
		 Position.Y = n + Form1.CurrentStaffIndex * Staff.kStaffSpacing  + Staff.kOffset;
		 return n;
		}

		public virtual void Draw (Graphics g, int measureIndex)
		{
			// draw the stem
			if ( (TheTiming == Timing.eighth) ||
				 (TheTiming == Timing.quarter) ||
				 (TheTiming == Timing.sixteenth) ||
				 (TheTiming == Timing.half ) ||
				 (TheTiming == Timing.third) 
				)

			{
				g.DrawLine(Pens.Black, Position.X + kXRadius, Position.Y, Position.X + kXRadius, Position.Y - kStem);
				if ((TheTiming == Timing.eighth) ||
					(TheTiming == Timing.sixteenth ))
				{
					g.DrawBezier(Pens.Black, Position.X + kXRadius, Position.Y - kStem,
						          Position.X + kXRadius + 3, Position.Y - (kStem - 3),
								  Position.X + kXRadius + 5, Position.Y - (kStem - 4),
								  Position.X + kXRadius + 3, Position.Y - (kStem - 6));
				}

				if (TheTiming == Timing.sixteenth)
				{
					g.DrawBezier(Pens.Black, Position.X + kXRadius, Position.Y - (kStem - 3),
						          Position.X + kXRadius + 3, Position.Y - (kStem - 6),
								  Position.X + kXRadius + 5, Position.Y - (kStem - 7),
								  Position.X + kXRadius + 3, Position.Y - (kStem - 9));
				}
			}

			// draw dot for third notes 
			if (TheTiming == Timing.third)
			{
				g.FillEllipse(Brushes.Black, Position.X + kXRadius + 3, Position.Y, 3, 3);
			}


			if ((TheTiming == Timing.eighth) ||
				(TheTiming == Timing.quarter) ||
				(TheTiming == Timing.sixteenth)
				)
			{
				g.FillEllipse(Brushes.Black, Position.X - kXRadius, Position.Y - kYRadius, kXRadius*2, kYRadius*2);
			}
			else
			{
				g.FillEllipse(Brushes.White, Position.X - kXRadius, Position.Y - kYRadius, kXRadius*2, kYRadius*2);
			}

			g.DrawEllipse(Pens.Black, Position.X - kXRadius, Position.Y - kYRadius, kXRadius*2, kYRadius*2);

			// also draw a line through it
			if (HasLine)
			{
				g.DrawLine(Pens.Black, Position.X - (kXRadius + 3), Position.Y, Position.X + (kXRadius + 3), Position.Y); 
			}

			  if (TheOctave == Octave.low)
			  {
			    if (HasLine)
				{
					g.DrawLine(Pens.Black, Position.X - (kXRadius + 3), Position.Y - (kYRadius*2 + 1), Position.X + (kXRadius + 3), Position.Y - (kYRadius*2 + 1)); 			  
					g.DrawLine(Pens.Black, Position.X - (kXRadius + 3), Position.Y - (kYRadius*4 + 2), Position.X + (kXRadius + 3), Position.Y - (kYRadius*4 + 2)); 			  
					g.DrawLine(Pens.Black, Position.X - (kXRadius + 3), Position.Y - (kYRadius*6 + 3), Position.X + (kXRadius + 3), Position.Y - (kYRadius*6 + 3)); 			  
				}
				else
				{
					g.DrawLine(Pens.Black, Position.X - (kXRadius + 3), Position.Y - (kYRadius + 1), Position.X + (kXRadius + 3), Position.Y - (kYRadius+1)); 			  
					g.DrawLine(Pens.Black, Position.X - (kXRadius + 3), Position.Y - (kYRadius*3 + 1), Position.X + (kXRadius + 3), Position.Y - (kYRadius*3 + 1)); 			  
					g.DrawLine(Pens.Black, Position.X - (kXRadius + 3), Position.Y - (kYRadius*5 + 2), Position.X + (kXRadius + 3), Position.Y - (kYRadius*5 + 2)); 			  
					g.DrawLine(Pens.Black, Position.X - (kXRadius + 3), Position.Y - (kYRadius*7 + 3), Position.X + (kXRadius + 3), Position.Y - (kYRadius*7 + 3)); 			  
				}
			  }

			  if (TheOctave == Octave.high)
			  {
				if (HasLine)
				{
					g.DrawLine(Pens.Black, Position.X - (kXRadius + 3), Position.Y + (kYRadius*2 + 1), Position.X + (kXRadius + 3), Position.Y + (kYRadius*2 + 1)); 			  
					g.DrawLine(Pens.Black, Position.X - (kXRadius + 3), Position.Y + (kYRadius*4 + 2), Position.X + (kXRadius + 3), Position.Y + (kYRadius*4 + 2)); 			  
					g.DrawLine(Pens.Black, Position.X - (kXRadius + 3), Position.Y + (kYRadius*6 + 3), Position.X + (kXRadius + 3), Position.Y + (kYRadius*6 + 3)); 			  
				}
				else
				{
					g.DrawLine(Pens.Black, Position.X - (kXRadius + 3), Position.Y + (kYRadius), Position.X + (kXRadius + 3), Position.Y + (kYRadius)); 			  
					g.DrawLine(Pens.Black, Position.X - (kXRadius + 3), Position.Y + (kYRadius*3 + 1), Position.X + (kXRadius + 3), Position.Y + (kYRadius*3 + 1)); 			  
					g.DrawLine(Pens.Black, Position.X - (kXRadius + 3), Position.Y + (kYRadius*5 + 2), Position.X + (kXRadius + 3), Position.Y + (kYRadius*5 + 2)); 			  
				}
			  }


			if (TheChromatic == Chromatic.Flat)
			{
				g.DrawString("b", new Font("Arial", 6), Brushes.Black, 
					Position.X + (kXRadius + 3), Position.Y - kYRadius*7, new StringFormat());
			}

			if (TheChromatic == Chromatic.Sharp)
			{
				g.DrawString("#", new Font("Arial", 6), Brushes.Black, 
					Position.X + (kXRadius + 3), Position.Y - kYRadius*7, new StringFormat());
			}
		}

		/// <summary>
		/// Pitch: range from A-G
		/// Octave: l,m,h default is m (only covers 3 octaves
		/// Flat/Sharp:  f,n,s,  default natural
		/// Timing:   x,e,q,a,t,w (sixteenth, eighth, quarter, half, third, whole), default quarter
		/// </summary>
		/// <param name="NoteInfo"> </param>
		public void Fill (string NoteInfo)
		{
			// here we will interpret a note from a string
			FillChromatic(NoteInfo);
			FillOctave(NoteInfo);
			FillPitch(NoteInfo);
			FillTiming(NoteInfo);
		}

		public void FillOctave (string NoteInfo) 
		{
			if (NoteInfo.IndexOf('l') != -1)
			{
				TheOctave = Octave.low;
			}
			if (NoteInfo.IndexOf('m') != -1)
			{
				TheOctave = Octave.middle;
			}
			if (NoteInfo.IndexOf('h') != -1)
			{
				TheOctave = Octave.high;
			}
		 
		}

		public void FillPitch (string NoteInfo) 
		{
			if (NoteInfo.IndexOf('A') != -1)
			{
				ThePitch = Pitch.A;
			}
			if (NoteInfo.IndexOf('B') != -1)
			{
				ThePitch = Pitch.B;
			}
			if (NoteInfo.IndexOf('C') != -1)
			{
				ThePitch = Pitch.C;
			}
			if (NoteInfo.IndexOf('D') != -1)
			{
				ThePitch = Pitch.D;
			}
			if (NoteInfo.IndexOf('E') != -1)
			{
				ThePitch = Pitch.E;
			}
			if (NoteInfo.IndexOf('F') != -1)
			{
				ThePitch = Pitch.F;
			}
			if (NoteInfo.IndexOf('G') != -1)
			{
				ThePitch = Pitch.G;
			}
		 
		}

		public void FillTiming (string NoteInfo)
		{
			if (NoteInfo.IndexOf('x') != -1)
			{
				TheTiming = Timing.sixteenth;
			}
			if (NoteInfo.IndexOf('e') != -1)
			{
				TheTiming = Timing.eighth;
			}
			if (NoteInfo.IndexOf('q') != -1)
			{
				TheTiming = Timing.quarter;
			}
			if (NoteInfo.IndexOf('a') != -1)
			{
				TheTiming = Timing.half;
			}
			if (NoteInfo.IndexOf('t') != -1)
			{
				TheTiming = Timing.third;
			}
			if (NoteInfo.IndexOf('w') != -1)
			{
				TheTiming = Timing.whole;
			}
		}


		public void FillChromatic (string NoteInfo)
		{
			if (NoteInfo.IndexOf('f') != -1)
			{
				this.TheChromatic = Chromatic.Flat;
			}
			if (NoteInfo.IndexOf('n') != -1)
			{
				this.TheChromatic = Chromatic.Natural;
			}
			if (NoteInfo.IndexOf('s') != -1)
			{
				this.TheChromatic = Chromatic.Sharp;
			}

		}
    }
}
