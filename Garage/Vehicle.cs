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
    class Car : Vehicle
    {
        public string Brand;
        public Car(string regno, int wheels, string color, string brand) : base(regno, wheels, color)
        {
            Brand = brand;
        }
    }
    class Motorcycle : Vehicle
    {
        public bool Offroad;
        public Motorcycle(string regno, int wheels, string color, bool offroad) : base(regno, wheels, color)
        {
            Offroad = offroad;
        }
    }
    class Bus : Vehicle
    {
        public int Passengers;
        public Bus(string regno, int wheels, string color, int passengers) : base(regno, wheels, color)
        {
            Passengers = passengers;
        }
    }
    class Boat : Vehicle
    {
        public bool SailingBoat;
        public bool MotorBoat;
        public Boat(string regno, int wheels, string color, bool sailingboat, bool motorboat) : base(regno, wheels, color)
        {
            SailingBoat = sailingboat;
            MotorBoat = motorboat;
        }
    }
    class Airplane : Vehicle
    {
        public double Wingspan;
        public Airplane(string regno, int wheels, string color, double wingspan) : base(regno, wheels, color)
        {
            Wingspan = wingspan;
        }
    }
}
