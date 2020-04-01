using System;
using System.Collections.Generic;
using System.Text;

namespace Garage
{
    class Vehicle
    {
        public string Regno;
        public int Wheels;
        public string Color;

        public Vehicle(string regno, int wheels, string color)
        {
            Regno = regno;
            Wheels = wheels;
            Color = color;
        }
    }
    class Airplane : Vehicle
    {
        public int NumberOfEngines;
        public Airplane(string regno, int wheels, string color, int numberofengines) : base(regno, wheels, color)
        {
            NumberOfEngines = numberofengines;
        }
    }
    class Boat : Vehicle
    {
        public double Length;
        public Boat(string regno, int wheels, string color, double length) : base(regno, wheels, color)
        {
            Length = length;
        }
    }

    class Bus : Vehicle
    {
        public int NumberOfSeats;

        public Bus(string regno, int wheels, string color, int numberofseats) : base(regno, wheels, color)
        {
            NumberOfSeats = numberofseats;
        }
    }
    class Car : Vehicle
    {
        public string FuelType;
        public Car(string regno, int wheels, string color, string fueltype) : base(regno, wheels, color)
        {
            FuelType = fueltype;
        }
    }
    class Motorcycle : Vehicle
    {
        public int CylinderVolume;
        public Motorcycle(string regno, int wheels, string color, int cylindervolume) : base(regno, wheels, color)
        {
            CylinderVolume = cylindervolume;
        }
    }
}