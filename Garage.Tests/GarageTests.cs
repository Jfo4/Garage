using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Garage.Tests
{
    [TestClass]
    public class GarageTests
    {
        [TestMethod]
        public void ComputesCreateGarageWithSizeOccupied()
        {
            var handler = new GarageHandler();
            handler.CreateGarageWithSize(5);
            handler.ParkVehicle(new Motorcycle("MCA829", 2, "Green", 750));
            handler.ParkVehicle(new Airplane("AAA010", 8, "White", 4));
            
            Assert.AreEqual(2, handler.OccupiedParkingLots);
        }
        [TestMethod]
        public void ComputesCreateGarageWithSizeFree()
        {
            var handler = new GarageHandler();
            handler.CreateGarageWithSize(8);
            handler.ParkVehicle(new Motorcycle("MCA829", 2, "Green", 750));
            handler.ParkVehicle(new Airplane("AAA010", 8, "White", 4));

            Assert.AreEqual(6, handler.FreeParkingLots);
        }

    }
}
