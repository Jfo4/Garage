using System;
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

        internal bool LeaveGarage(string regNo)
        {
            var result = garage.FirstOrDefault(v => v.Regno == regNo);
            if (result == null)
                return false;
             else   
              return  garage.Leave(result);
        }
    }
}
