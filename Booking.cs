using System;
using System.Collections.Generic;
using System.Text;

namespace SportClose
{
    class Booking
    {
        private Pitch selectedPitch;

        public Pitch Pitch { get; private set; }
    public User User { get; private set; }
    public DateTime StartTime { get; private set; }
    public DateTime EndTime { get; private set; }

    public Booking(Pitch pitch, User user, DateTime startTime, DateTime endTime)
    {
        Pitch = pitch;
        User = user;
        StartTime = startTime;
        EndTime = endTime;
    }

        public Booking(Pitch selectedPitch, DateTime startTime, DateTime endTime)
        {
            this.selectedPitch = selectedPitch;
            StartTime = startTime;
            EndTime = endTime;
        }

        public override string ToString()
    {
        return $"{Pitch.Name} - {Pitch.Sport} ({Pitch.Duration} minutes) - Booked by: {User.Username} - From: {StartTime} to: {EndTime}";
    }
    }
}
