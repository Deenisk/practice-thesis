using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SportClose
{
  public static  class Program
  {
        private static List<Pitch> availablePitches;
        private static List<Booking> bookings;

        public static void Main()
        {
            availablePitches = new List<Pitch>();
            bookings = new List<Booking>();

            LoadAvailablePitches();

            PerformBookingOperations();
        }

        private static void LoadAvailablePitches()
        {
            string filePath = @"C:\Users\zala2\Documents\10z\SportClose\TextFile1.txt";
            if (File.Exists(filePath))
            {
                try
                {
                    string[] lines = File.ReadAllLines(filePath);
                    foreach (string line in lines)
                    {
                        string[] parts = line.Split(',');
                        if (parts.Length == 3)
                        {
                            string name = parts[0];
                            string sport = parts[1];

                            if (int.TryParse(parts[2], out int duration))
                            {
                                availablePitches.Add(new Pitch(name, sport));
                            }
                        }
                    }
                    Console.WriteLine("Available pitches loaded successfully.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error loading available pitches: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("Pitches database file not found.");
            }
        }
     

        private static void PerformBookingOperations()
       
        {
            Console.WriteLine("----- SportClose-----");

            while (true)
            {
                Console.WriteLine("\nSelect an option:");
                Console.WriteLine("1. View available pitches");
                Console.WriteLine("2. Book a pitch");
                Console.WriteLine("3. View booked pitches");
                Console.WriteLine("4. Exit");

                Console.Write("Enter your choice: ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        ViewAvailablePitches();
                        break;
                    case "2":
                        BookPitch();
                        break;
                    case "3":
                        ViewBookedPitches();
                        break;
                    case "4":
                        Console.WriteLine("-----------Thank you for using the SportClose. Goodbye!-----------");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        private static void ViewAvailablePitches()
        {
            Console.WriteLine("\nSelect the sport:");
            Console.WriteLine("1. Football");
            Console.WriteLine("2. Tennis");
            Console.WriteLine("3. Basketball");
            Console.WriteLine("4. Volleyball");

            Console.Write("Enter your choice: ");
            string input = Console.ReadLine();

            string selectedSport;
            switch (input)
            {
                case "1":
                    selectedSport = "Football";
                    break;
                case "2":
                    selectedSport = "Tennis";
                    break;
                case "3":
                    selectedSport = "Basketball";
                    break;
                case "4":
                    selectedSport = "Volleyball";
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    return;
            }

            var availablePitchesForSport = availablePitches.Where(p => p.Sport == selectedSport).ToList();
            if (availablePitchesForSport.Any())
            {
                Console.WriteLine($"\nAvailable {selectedSport} pitches:");
                foreach (Pitch pitch in availablePitchesForSport)
                {
                    Console.WriteLine(pitch.ToString());
                }
            }
            else
            {
                Console.WriteLine($"\nNo available {selectedSport} pitches.");
            }
        }

        private static void BookPitch()
        {
            Console.WriteLine("\nSelect the sport:");
            Console.WriteLine("1. Football");
            Console.WriteLine("2. Tennis");
            Console.WriteLine("3. Basketball");
            Console.WriteLine("4. Volleyball");

            Console.Write("Enter your choice: ");
            string input = Console.ReadLine();

            string selectedSport;
            switch (input)
            {
                case "1":
                    selectedSport = "Football";
                    break;
                case "2":
                    selectedSport = "Tennis";
                    break;
                case "3":
                    selectedSport = "Basketball";
                    break;
                case "4":
                    selectedSport = "Volleyball";
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    return;
            }

            var availablePitchesForSport = availablePitches.Where(p => p.Sport == selectedSport && p.IsAvailable()).ToList();
            if (availablePitchesForSport.Any())
            {
               
                Pitch selectedPitch = availablePitchesForSport.First();
                DateTime reservedTime = DateTime.Now;
                selectedPitch.ReservePitch(reservedTime, reservedTime); 

                Booking newBooking = new Booking(selectedPitch, reservedTime);
                bookings.Add(newBooking);

                Console.WriteLine("\nPitch booked successfully!");
                Console.WriteLine(newBooking.ToString());
            }
            else
            {
                Console.WriteLine($"\nNo available {selectedSport} pitches.");
            }
        }
        private static void ViewBookedPitches()
        {
            if (bookings.Any())
            {
                Console.WriteLine("\nBooked pitches:");
                foreach (Booking booking in bookings)
                {
                    Console.WriteLine(booking.ToString());
                }
            }
            else
            {
                Console.WriteLine("\nNo pitches booked yet.");
            }
        }
    }
}