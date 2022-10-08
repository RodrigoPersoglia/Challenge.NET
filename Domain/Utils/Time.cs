using System;

namespace Domain.Utils
{
    public class Time
    {
        public Time(int days, int hours, int minutes, int seconds)
        {
            Days = days;
            Hours = hours;
            Minutes = minutes;
            Seconds = seconds;

        }
        public int Days { get; set; }
        public int Hours { get; set; }
        public int Minutes { get; set; }
        public int Seconds { get; set; }

        public TimeSpan ToTimeSpan()
        {
            return new TimeSpan(Days, Hours, Minutes, Seconds);
        }

    }
}
