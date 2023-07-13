using System;
using System.Collections.Generic;
using System.Text;

namespace SportClose
{
   public class Booking
    {
        public Pitch Pitch { get; private set; }
        public DateTime ReservedTime { get; private set; }

        public Booking(Pitch pitch, DateTime reservedTime)
        {
            Pitch = pitch;
            ReservedTime = reservedTime;
        }

        public override string ToString()
        {
            return $"{Pitch.Name} - {Pitch.Sport} - Reserved at: {ReservedTime}";
        }

    }
}
