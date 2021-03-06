﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            var expected = 2;

            var actual = handler.OccupiedParkingLots;

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void ComputesCreateGarageWithSizeFree()
        {
            var handler = new GarageHandler();
            handler.CreateGarageWithSize(8);
            handler.ParkVehicle(new Motorcycle("MCA829", 2, "Green", 750));
            handler.ParkVehicle(new Airplane("AAA010", 8, "White", 4));
            var expected = 6;

            var actual = handler.FreeParkingLots;

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void ComputesLeaveGarageTrue()
        {
            var handler = new GarageHandler();
            handler.CreateGarageWithSize(8);
            handler.ParkVehicle(new Motorcycle("MCA829", 2, "Green", 750));
            handler.ParkVehicle(new Airplane("AAA010", 8, "White", 4));
            var expected = true;

            var actual = handler.LeaveGarage("AAA010");

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void ComputesLeaveGarageFalse()
        {
            var handler = new GarageHandler();
            handler.CreateGarageWithSize(8);
            handler.ParkVehicle(new Motorcycle("MCA829", 2, "Green", 750));
            handler.ParkVehicle(new Airplane("AAA010", 8, "White", 4));

            Assert.AreEqual(false, handler.LeaveGarage("AAA011"));
        }
        [TestMethod]
        public void ComputesGarageFull()
        {
            var handler = new GarageHandler();
            handler.CreateGarageWithSize(4);
            handler.ParkVehicle(new Motorcycle("MCA829", 2, "Green", 750));
            handler.ParkVehicle(new Airplane("AAA010", 8, "White", 4));
            handler.ParkVehicle(new Motorcycle("BRM840", 2, "Svart", 754));
            handler.ParkVehicle(new Boat("OOS005", 0, "Green", 12.4));
            
            Assert.AreEqual(false, handler.ParkVehicle(new Bus("MMM888", 6, "Brown", 24)));
        }
    }
}
