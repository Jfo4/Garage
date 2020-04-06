using System;
using System.Collections.Generic;
using System.IO;
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
            Console.WriteLine("Hur många parkeringsplatser (1-1000)?");
            do
            {
                var parkingInput = int.TryParse(Console.ReadLine(), out int park) ? park : 0;
                if (parkingInput > 1 && parkingInput <= 1000)
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
            Console.Clear();
            Console.WriteLine("1. Testdata internt, 9 st");
            Console.WriteLine("2. Testdata från fil, >500 st");
            var samples = Console.ReadLine();
            switch (samples)
            {
                case "1":
                    SampleInternal();
                    break;
                case "2":
                    SampleFromFile();
                    break;
                default:
                    SampleInternal();
                    break;
            }

            static void SampleInternal()
            {
                handler.ParkVehicle(new Motorcycle("MCA829", 2, "Green", 750));
                handler.ParkVehicle(new Airplane("AAA010", 8, "White", 4));
                handler.ParkVehicle(new Car("CAR321", 4, "Blue", "Diesel"));
                handler.ParkVehicle(new Motorcycle("BRM840", 2, "Svart", 754));
                handler.ParkVehicle(new Boat("OOS005", 0, "Green", 12.4));
                handler.ParkVehicle(new Bus("MMM888", 6, "Brown", 24));
                handler.ParkVehicle(new Boat("AAA020", 0, "Red", 12.2));
                handler.ParkVehicle(new Car("SOS505", 3, "Yellow", "Diesel"));
                handler.ParkVehicle(new Airplane("ARN747", 8, "Orange", 4));
            }
        }

        private static void SampleFromFile()
        {
            //// Dictionary file: Type -> Extra field
            //var keys = File.ReadAllLines("TypeExtra.csv");
            //Dictionary<string, string> TypeExtra = new Dictionary<string, string>();
            // Skip header
            //for (int i = 1; i < keys.Length; i++)
            //{
            //    var dictionary = keys[i].Split(";");
            //    TypeExtra.Add(dictionary[0], dictionary[1]);
            //}

            var lines = File.ReadAllLines("Garage.csv");
            // Exclude header row:
            // Type;Regno;Wheels;Color;Extra
            for (int i = 1; i < lines.Length; i++)
            {
                var vehicle = lines[i].Split(";");
                switch (vehicle[0])
                {
                    case "Airplane":
                        handler.ParkVehicle(
                            new Airplane(vehicle[1],
                            int.Parse(vehicle[2]),
                            vehicle[3],
                            int.Parse(vehicle[4])));
                        break;
                    case "Boat":
                        handler.ParkVehicle(
                            new Boat(vehicle[1],
                            int.Parse(vehicle[2]),
                            vehicle[3],
                            double.Parse(vehicle[4].Replace(".",","))));
                        break;  
                    case "Bus":
                        handler.ParkVehicle(
                            new Bus(vehicle[1],
                            int.Parse(vehicle[2]),
                            vehicle[3],
                            int.Parse(vehicle[4])));
                        break;
                    case "Car":
                        handler.ParkVehicle(
                            new Car(vehicle[1],
                            int.Parse(vehicle[2]),
                            vehicle[3],
                            vehicle[4]));
                        break;
                    case "Motorcycle":
                        handler.ParkVehicle(
                            new Car(vehicle[1],
                            int.Parse(vehicle[2]),
                            vehicle[3],
                            vehicle[4]));
                        break;
                    default:
                        break;
                }
            }
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
            Console.WriteLine($"Lista på de {handler.OccupiedParkingLots} fordon som är parkerade.\n");
            Console.WriteLine(handler.ListVehicle());
            Console.WriteLine("<enter> för att avsluta");
            Console.ReadLine();
        }

        private static void Search()
        {
            Console.Clear();
            Console.WriteLine($"Sök efter något av de {handler.OccupiedParkingLots} fordon i garaget.");
            Console.WriteLine("Söksträng.");
            Console.WriteLine("Regnr, del av:");
            string regno = Console.ReadLine().ToUpper();
            Console.WriteLine("Färg:");
            string color = Console.ReadLine().ToUpper();
            Console.WriteLine("Antal hjul:");
            int wheels = int.TryParse(Console.ReadLine(), out int w) ? w : 0; 

            var vechicleList = handler.SearchVehicle(regno, color, wheels);
            Console.WriteLine(vechicleList);
            Console.ReadLine();
         
            //var s = Console.ReadLine().ToUpper().Split(" ");
            //var s0 = s[0];
            //var s1 = s[1];
            //int s2 = int.Parse(s[2]);
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