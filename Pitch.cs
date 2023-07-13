using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace SportClose
{
    public class Pitch
    {
        public string Name { get; private set; }
        public string Sport { get; private set; }
        public bool IsReserved { get; private set; }
        public DateTime ReservedStartTime { get; private set; }
        public DateTime ReservedEndTime { get; private set; }

        public Pitch(string name, string sport)
        {
            Name = name;
            Sport = sport;
            IsReserved = false;
        }

        public bool IsAvailable()
        {
            return !IsReserved;
        }

        public void ReservePitch(DateTime startTime, DateTime endTime)
        {
            IsReserved = true;
            ReservedStartTime = startTime;
            ReservedEndTime = endTime;
        }

        public void FreePitch()
        {
            IsReserved = false;
            ReservedStartTime = DateTime.MinValue;
            ReservedEndTime = DateTime.MinValue;
        }

        public override string ToString()
        {
            return $"{Name} - {Sport}";
        }
    }
}
