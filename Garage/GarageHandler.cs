using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Garage
{
    public class GarageHandler
    {
        private Garage<Vehicle> garage;

        public void CreateGarageWithSize(int capacity)
        {
            garage = new Garage<Vehicle>(capacity);
        }

        public bool LeaveGarage(string regno)
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

        public bool ParkVehicle(Vehicle vehicle)
        {
            if (garage.Free > 0) // Det måste finnas lediga platser.
            {
                return garage.Park(vehicle);
            }
            else
                return false;
        }

        internal string ListVehicle()
        {
            var builder = new StringBuilder();
            foreach (var vehicle in garage)
            {
                if(vehicle != null)
                    builder.AppendLine(vehicle.Print());
            }
            return builder.ToString();
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
