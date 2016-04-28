namespace MusicMaker
{
    using System;
	using System.Windows.Forms;
	using System.Collections;
	using System.Drawing;

	/// ************************ MUSIC MAKER ********************
	/// By Michael Gold
	/// Copyright 2000.  All Rights Reserved
	/// *********************************************************
	

    /// <summary>
    ///    Page of Music
    /// </summary>
    public class Page
    {
		public ArrayList Staffs = new ArrayList();

		const int kNumStaffsOnAPage = 5;

		public void AddStaff(Staff aStaff)
		{
			Staffs.Add(aStaff);
		}

        public Page()
        {
            // 
	        // TODO: Add Constructor Logic here
	        //
			for (int i = 0; i < kNumStaffsOnAPage; i++)
			{
				Staff aStaff = new Staff();
				AddStaff(aStaff);
			}
        }

		public void Draw (Graphics g)
		{
			for (int i = 0; i < Staffs.Count; i++)
			{
				Staff aStaff = (Staff)Staffs[i];
				try
				{
					aStaff.Draw(g, i);
				}
				catch(Exception ex)
				{
				  MessageBox.Show(ex.Message.ToString());
				}
			}
		}
    }
}
