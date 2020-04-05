using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Garage
{
    public class Vehicle
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

        public virtual string Print()
        {
            return $"Typ:{this.GetType().Name} Regnr:{Regno} Antal hjul:{Wheels} Färg:{Color} ";

            //var builder = new StringBuilder().Append($"Type:{this.GetType().Name}");
            //var props = this.GetType().GetProperties();
            //foreach (var prop in props)
            //{
            //    builder.Append($"{prop.Name}:{prop.GetValue(this, null)?.ToString()}");
            //}

            //Array.ForEach(this.GetType().GetProperties().ToArray(), p => builder.Append($"{p.Name}:{p.GetValue(this, null)?.ToString()}"));
            
            //return builder.ToString();
        }
    }
    public class Airplane : Vehicle
    {
        public int NumberOfEngines;
        public Airplane(string regno, int wheels, string color, int numberofengines) : base(regno, wheels, color)
        {
            NumberOfEngines = numberofengines;
        }
        public override string Print()
        {
            return base.Print() + $"Antal motorer:{NumberOfEngines}";
        }
    }
    public class Boat : Vehicle
    {
        public double Length;
        public Boat(string regno, int wheels, string color, double length) : base(regno, wheels, color)
        {
            Length = length;
        }
        public override string Print()
        {
            return base.Print() + $"Längd:{Length}";
        }
    }

    public class Bus : Vehicle
    {
        public int NumberOfSeats;

        public Bus(string regno, int wheels, string color, int numberofseats) : base(regno, wheels, color)
        {
            NumberOfSeats = numberofseats;
        }
        public override string Print()
        {
            return base.Print() + $"Antal säten:{NumberOfSeats}";
        }
    }
    public class Car : Vehicle
    {
        public string FuelType;
        public Car(string regno, int wheels, string color, string fueltype) : base(regno, wheels, color)
        {
            FuelType = fueltype;
        }
        public override string Print()
        {
            return base.Print() + $"Bränsle:{FuelType}";
        }
    }
    public class Motorcycle : Vehicle
    {
        public int CylinderVolume;
        public Motorcycle(string regno, int wheels, string color, int cylindervolume) : base(regno, wheels, color)
        {
            CylinderVolume = cylindervolume;
        }
        public override string Print()
        {
            return base.Print() + $"Cylindervolym:{CylinderVolume}";
        }
    }
}