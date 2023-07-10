using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace SportClose
{
    class Pitch
    {
         
        public string Name { get; private set; }
        public string Sport { get; private set; }
        public int Duration { get; private set; }
        public bool IsReserved { get; private set; }
        public DateTime ReservedStartTime { get; private set; }
        public DateTime ReservedEndTime { get; private set; }

        public Pitch(string name, string sport, int duration)
        {
            Name = name;
            Sport = sport;
            Duration = duration;
            IsReserved = false;
        }
        public bool IsAvailable(int duration)
        {
            if (IsReserved)
            {
                return DateTime.Now.AddMinutes(duration) > ReservedEndTime;
            }
            return true;
        }

        public void ReservePitch(DateTime startTime, DateTime endTime)
        {
            IsReserved = true;
            ReservedStartTime = startTime;
            ReservedEndTime = endTime;
        }

        public void FreePitch(DateTime startTime, DateTime endTime)
        {
            if (IsReserved && startTime == ReservedStartTime && endTime == ReservedEndTime)
            {
                IsReserved = false;
                ReservedStartTime = DateTime.MinValue;
                ReservedEndTime = DateTime.MinValue;
            }
        }

        public override string ToString()
        {
            return $"{Name} - {Sport} ({Duration} minutes)";
        }
    }
}
