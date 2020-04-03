﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Garage
{
    class GarageHandler
    {
        private Garage<Vehicle> garage;

        internal void CreateGarageWithSize(int capacity)
        {
            garage = new Garage<Vehicle>(capacity);
        }

        internal bool LeaveGarage(string regno)
        {
            if (garage.Occupied > 0) // Det måste finnas fordon parkerade.
            {
                var result = garage.FirstOrDefault(v => v.Regno == regno);
                if (result == null)
                    return false;
                else
                    return garage.Leave(result);
            }
            else
                return false;
        }
        internal bool ParkVehicle(Vehicle vehicle)
        {
          
            if (garage.Free > 0) // Det måste finnas lediga platser.
            {
                return garage.Park(vehicle);
            }
            else
                return false;
        }
        internal void ListVehicle()
        {
            foreach (var vehicle in garage)
            {
                Console.WriteLine($"{vehicle}, {vehicle.Regno}");
            }
            Console.WriteLine($"Free: {garage.Free}");
        } 
        //internal IEnumerable<Vehicle> ListVehicle()
        //{
        //    foreach (var vehicle in garage)
        //    {
        //        yield return vehicle;
        //    }
        //} 
        public int FreeParkingLots => garage.Free;

        public int OccupiedParkingLots => garage.Occupied;
    }
}
