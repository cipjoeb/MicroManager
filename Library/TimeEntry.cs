using System;

namespace Library
{
    public class TimeEntry
    {
        public DateTime Start { get; set; }
        public string Description { get; set; }
        public DateTime Stop { get; set; }

        public int Hours { get { return Elapsed.Hours; }}
        public int Minutes { get { return Elapsed.Minutes; } }
        public int Seconds { get { return Elapsed.Seconds; } }

        public TimeSpan Elapsed
        {
            get
            {
                if (Stop == DateTime.MinValue) return new TimeSpan(0, 0, 0, 0);
                return Stop - Start;
            }
        }
    }
}
