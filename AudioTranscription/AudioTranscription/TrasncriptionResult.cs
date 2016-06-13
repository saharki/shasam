namespace AudioTranscription
{
    class TrasncriptionResult
    {
        public Note[] Notes;
        public int BPM;
        
        public TrasncriptionResult(int numberOfNotes,int BPM)
        {
            this.Notes = new Note[numberOfNotes];
            for(int i =0;i<Notes.Length;i++)
            {
                Notes[i] = new Note();
            }

            this.BPM = BPM;
        }
    }
}