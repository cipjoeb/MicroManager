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

        public override string ToString()
        {
            return string.Format("{0} - Task: {1} Time Spent: {2}:{3}:{4}", Start.ToShortDateString(), Description, Hours, Minutes, Seconds);
        }
    }
}
