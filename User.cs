using System;
using System.Collections.Generic;
using System.Text;

namespace SportClose
{
    public class User
     {
        public string Name { get; private set; }
        public List<Booking> Bookings { get; private set; }

        public User(string name)
        {
            Name = name;
            Bookings = new List<Booking>();
        }

        public void AddBooking(Booking booking)
        {
            Bookings.Add(booking);
        }

        public void RemoveBooking(Booking booking)
        {
            Bookings.Remove(booking);
        }

        public override string ToString()
        {
            return $"User: {Name}\nBooked Pitches: {Bookings.Count}";
        }
    }
}
