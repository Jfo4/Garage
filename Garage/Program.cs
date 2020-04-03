using System;
using System.Collections.Generic;
using System.Linq;

namespace Garage
{
    class Program
    {
        private static GarageHandler handler;

        static void Main(string[] args)
        {
            InitGarage();
            SampleData();
            Menu();
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
                    handler = new GarageHandler();
                    handler.CreateGarageWithSize(parkingInput);
                    exit = true;
                }
                else
                {
                    Console.WriteLine("Oops, nu blev det fel. Försök igen.");
                }
            } while (!exit);
        }

        private static void SampleData()
        {
            handler.ParkVehicle(new Motorcycle("MCA829", 2, "Green", 750));
            handler.ParkVehicle(new Airplane("AAA010", 8, "White", 4));
            handler.ParkVehicle(new Car("CAR321", 4, "Blue", "Diesel"));  // -.. .. . ... . .-..
            handler.ParkVehicle(new Motorcycle("BRM840", 2, "Svart", 754));
            handler.ParkVehicle(new Boat("OOS005", 0, "Green", 12.4));
            handler.ParkVehicle(new Bus("MMM888", 6, "Brown", 24));
            handler.ParkVehicle(new Boat("AAA020", 0, "Red", 12.2));
            handler.ParkVehicle(new Car("SOS505", 3, "Yellow", "Diesel"));
            handler.ParkVehicle(new Airplane("ARN747", 8, "Orange", 4));
            handler.ListVehicle();
            Console.ReadLine();
        }
        
        private static void Menu()
        {
            bool exit = false;

            do
            {
                Console.Clear();
                Console.WriteLine("Huvudmeny");
                Console.WriteLine("1. Parkera");
                Console.WriteLine("2. Hämta ut");
                Console.WriteLine("3. Sök");
                Console.WriteLine("4. Lista");
                Console.WriteLine("9. Avsluta");

                var menuSelect = Console.ReadLine();
                switch (menuSelect)
                {
                    case "1":
                        Park();
                        break;
                    case "2":
                        Leave();
                        break;
                    case "3":
                        Search();
                        break;
                    case "4":
                        List();
                        break;
                    case "9":
                        //Environment.Exit(0);
                        exit = true;
                        break;
                    default:
                        break;
                }
            } while (!exit);
        }

        private static void List()
        {
            Console.Clear();
            Console.WriteLine("Lista alla fordon i garaget.");
            
            Console.ReadKey();
        }

        private static void Search()
        {
            Console.Clear();
            Console.WriteLine("Sök efter fordon i garaget.");
            Console.WriteLine("Regnr, Färg, Antal hjul.");

            Console.ReadKey();
        }

        private static void Leave()
        {
            Console.Clear();
            Console.WriteLine("Hämta ut fordon.");
            Console.WriteLine("Regnr:");

            string regnr = Console.ReadLine().ToUpper();
            var ok = handler.LeaveGarage(regnr);

            if (!ok)
            {
                Console.WriteLine($"Fordon med regnr {regnr} finns inte i garaget.");
            }
            else
            {
                Console.WriteLine($"Fordon med regnr {regnr} har hämtats ut.");
            }
            Console.ReadKey();
        }

        private static void Park()
        {
            Console.Clear();
            Console.WriteLine($"Parkera\n");
            Console.WriteLine("Fordonstyp?");
            Console.WriteLine("1. Flygplan");
            Console.WriteLine("2. Båt");
            Console.WriteLine("3. Buss");
            Console.WriteLine("4. Bil");
            Console.WriteLine("5. MC");
            Console.WriteLine("Allt annat avbryter");

            string vehicleType = Console.ReadLine();
            switch (vehicleType)
            {
                case "1":
                    ParkPlane();
                    break;
                case "2":
                    ParkBoat();
                    break;
                case "3":
                    ParkBus();
                    break;
                case "4":
                    ParkCar();
                    break;
                case "5":
                    ParkMC();
                    break;
                default:
                    break;
            }
        }

        private static void ParkCar()
        {
            ParkVehicleHeader("bil", out string regnr, out string color, out int wheels);

            Console.Write("Bränsle: ");
            string fuel = Console.ReadLine();
            Vehicle v = new Car(regnr, wheels, color, fuel);

            ParkVehicle(v);
        }

        private static void ParkBus()
        {
            ParkVehicleHeader("buss", out string regnr, out string color, out int wheels);
            
            Console.Write("Antal sittplatser: ");
            int seats = int.TryParse(Console.ReadLine(), out int s) ? s : 0;
            Vehicle v = new Bus(regnr, wheels, color, seats);

            ParkVehicle(v);
        }

        private static void ParkBoat()
        {
            ParkVehicleHeader("båt", out string regnr, out string color, out int wheels);
            
            Console.Write("Antal sittplatser: ");
            double len = double.TryParse(Console.ReadLine(), out double d) ? d : 0;
            Vehicle v = new Boat(regnr, wheels, color, len);

            ParkVehicle(v);
        }

        private static void ParkPlane()
        {
            ParkVehicleHeader("flygplan", out string regnr, out string color, out int wheels);

            Console.Write("Antal sittplatser: ");
            int engines = int.TryParse(Console.ReadLine(), out int i) ? i : 0;
            Vehicle v = new Airplane(regnr, wheels, color, engines);
            
            ParkVehicle(v);
        }
        private static void ParkMC()
        {
            ParkVehicleHeader("MC", out string regnr, out string color, out int wheels);

            Console.Write("Cylindervolym: ");
            int cylvol = int.TryParse(Console.ReadLine(), out int i) ? i : 0;
            Vehicle v = new Motorcycle(regnr, wheels, color, cylvol);
            
            ParkVehicle(v);
        }

        // Leta upp en ledig parkeringsplats för fordonet
        private static void ParkVehicle(Vehicle v)
        {
            var ok = handler.ParkVehicle(v);
            if (ok == true)
                Console.WriteLine("Ok");
            else
                Console.WriteLine("Nåt gick fel");
            Console.ReadKey();
        }

        // Gemensamma egenskaper "header"
        private static void ParkVehicleHeader
            (string type,
             out string regnr,
             out string color,
             out int wheels)
        {
            Console.Clear();
            Console.WriteLine("Parkera " + type);
            Console.Write("Regnr: ");
            regnr = Console.ReadLine().ToUpper();
            Console.Write("Färg: ");
            color = Console.ReadLine();
            Console.Write("Antal hjul: ");
            wheels = int.TryParse(Console.ReadLine(), out int w) ? w : 0;
        }
    }
}