using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SportClose
{
    class Program
    {
        private const string FilePath = "TextFile1.txt";
        static List<Pitch> availablePitches;
        static List<Booking> bookings;

        static void Main(string[] args)
        {
          
            availablePitches = new List<Pitch>();
            bookings = new List<Booking>();

            LoadPitchesFromDatabase(FilePath);

            bool running = true;
            while (running)
            {
                Console.WriteLine("Welcome to the Sport Pitch Booking App!");
                Console.WriteLine("1. View available pitches");
                Console.WriteLine("2. Book a pitch");
                Console.WriteLine("3. View bookings");
                Console.WriteLine("4. Cancel a booking");
                Console.WriteLine("5. Exit");

                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                Console.Clear();

                switch (choice)
                {
                    case "1":
                        ViewAvailablePitches();
                        break;
                    case "2":
                        BookPitch();
                        break;
                    case "3":
                        ViewBookings();
                        break;
                    case "4":
                        CancelBooking();
                        break;
                    case "5":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                Console.WriteLine();
            }
        }

        static void LoadPitchesFromDatabase(string filePath)
        {
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
                            int duration = int.Parse(parts[2]);

                            availablePitches.Add(new Pitch(name, sport, duration));
                        }
                    }
                    Console.WriteLine("Pitches loaded successfully from the database.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error loading pitches from the database: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("Pitches database file not found.");
            }
        }

        static void ViewAvailablePitches()
          {
            Console.WriteLine("Select a sport:");
            Console.WriteLine("1. Football");
            Console.WriteLine("2. Basketball");
            Console.WriteLine("3. Tennis");
            Console.WriteLine("4. Cricket");

            Console.Write("Enter your choice: ");
            string sportChoice = Console.ReadLine();

            string selectedSport;
            switch (sportChoice)
            {
                case "1":
                    selectedSport = "Football";
                    break;
                case "2":
                    selectedSport = "Basketball";
                    break;
                case "3":
                    selectedSport = "Tennis";
                    break;
                case "4":
                    selectedSport = "Cricket";
                    break;
                default:
                    Console.WriteLine("Invalid sport choice. Returning to main menu.");
                    return;
            }

            var availablePitchesForSport = availablePitches.Where(p => p.Sport == selectedSport).ToList();
            if (availablePitchesForSport.Any())
            {
                Console.WriteLine($"Available {selectedSport} pitches:");
                foreach (Pitch pitch in availablePitchesForSport)
                {
                    Console.WriteLine(pitch);
                }
            }
            else
            {
                Console.WriteLine($"No available {selectedSport} pitches.");
            }
        }


        static void BookPitch()
        {
            Console.Write("Enter the name of the pitch you want to book: ");
            string pitchName = Console.ReadLine();

            Console.Write("Enter the duration (in minutes): ");
            int duration = int.Parse(Console.ReadLine());

            Pitch selectedPitch = availablePitches.Find(p => p.Name == pitchName);

            if (selectedPitch != null && selectedPitch.IsAvailable(duration))
            {
                DateTime startTime = DateTime.Now;
                DateTime endTime = startTime.AddMinutes(duration);

                Booking newBooking = new Booking(selectedPitch, startTime, endTime);
                bookings.Add(newBooking);

                selectedPitch.ReservePitch(startTime, endTime);

                Console.WriteLine("Pitch booked successfully!");
                Console.WriteLine(newBooking);
            }
            else
            {
                Console.WriteLine("Invalid pitch name or duration. Please try again.");
            }
        }

        static void ViewBookings()
        {
            Console.WriteLine("Booked pitches:");
            foreach (Booking booking in bookings)
            {
                Console.WriteLine(booking);
            }
        }

        static void CancelBooking()
        {
            Console.Write("Enter the name of the pitch you want to cancel: ");
            string pitchName = Console.ReadLine();

            Booking bookingToRemove = bookings.Find(b => b.Pitch.Name == pitchName);

            if (bookingToRemove != null)
            {
                bookingToRemove.Pitch.FreePitch(bookingToRemove.StartTime, bookingToRemove.EndTime);
                bookings.Remove(bookingToRemove);

                Console.WriteLine("Booking canceled successfully!");
            }
            else
            {
                Console.WriteLine("No booking found for the specified pitch name. Please try again.");
            }
        }
        }

    }
