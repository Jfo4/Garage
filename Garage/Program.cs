using System;
using System.Collections.Generic;

namespace Garage
{
    class Program
    {
        static void Main(string[] args)
        {
            //InitGarage();
            //Menu();

            // Ett fordon i taget skapas med olika attibut
            var vechicle1 = new Boat("AAA020", 0, "Red", 12.2);
            var vechicle2 = new Car("OOS005", 4, "Blue", "Diesel");
            var vechicle3 = new Airplane("ARN747", 8, "Orange", 4);

            Console.WriteLine($"Length: {vechicle1.Length}");
            Console.WriteLine($"Fuel: {vechicle2.FuelType}");
            Console.WriteLine($"Wheels: {vechicle3.Wheels}");

            //    new Airplane("AAA010", 8, "White", 4),
            //    new Car("CAR321", 4, "Blue", "Diesel"),  // -.. .. . ... . .-..
            //    new Motorcycle("BRM840", 2, "Black", 754),
            //    new Boat("OOS005", 0, "Green", 12.4),
            //    new Bus("MMM888", 6, "Brown", 24)

            Console.ReadLine();
        }

        private static void InitGarage()
        {
            Console.Clear();
            bool exit = false;

            Console.WriteLine("Nytt garage.");
            Console.WriteLine("Hur många parkeringsplatser (1-50)?");
            do
            {
                var parkingInput = int.TryParse(Console.ReadLine(), out int park) ? park : 0;
                if (parkingInput > 1 && parkingInput <= 50)
                {
                    // Skapa Garage med "parkingInput" platser.
                    exit = true;
                }
                else
                {
                    Console.WriteLine("Oops, nu blev det fel. Försök igen.");
                }
            } while (!exit);
        }

        private static void Menu()
        {
            bool exit = false;
            Console.Clear();

            do
            {
                Console.WriteLine("Huvudmeny\n");
                Console.WriteLine("1. Parkera");
                Console.WriteLine("2. Hämta ut");
                Console.WriteLine("3. Sök");
                Console.WriteLine("4. Lista");
                Console.WriteLine("0. Avsluta");
                var menuSelect = Console.ReadLine();
                switch (menuSelect)
                {
                    case "1":
                        Park();
                        break;
                    case "2":
                        break;
                    case "3":
                        break;
                    case "4":
                        break;
                    case "0":
                        exit = true;
                        break;
                    default:
                        break;
                }
            } while (!exit);
        }

        private static void Park()
        {
            Console.WriteLine();
        }
    }
}