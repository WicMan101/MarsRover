using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarsRover.Challenge.Logic.Vehicle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarsRover.Challenge.Logic.Vehicle.Interface;
using MarsRover.Challenge.Logic.Terrain.Interface;
using MarsRover.Challenge.Logic.Terrain;

namespace MarsRover.Challenge.Logic.Vehicle.Tests
{
    [TestClass()]
    public class RoverTests
    {
        private IRover _Rover;
        private string _RoverPositionAndDirection;
        private string _MovementCommands;

        [TestInitialize]
        public void InitializeRover()
        {
            ILandingSurface landingSurface = new Surface("8 8");
            _RoverPositionAndDirection = "1 2 E";
            _MovementCommands = "MMLMRMMRRMML";

            _Rover = new Rover(landingSurface, _RoverPositionAndDirection, _MovementCommands);
        }

        [TestMethod()]
        public void RoverTest()
        {
            _Rover.Run();
            int xCoordinate = _Rover.XCoordinate;
            int yCoordinate = _Rover.YCoordinate;
            string directionFacing = _Rover.DirectionFacing;

            Assert.AreEqual(3, xCoordinate);
            Assert.AreEqual(3, yCoordinate);
            Assert.AreEqual("S", directionFacing);
        }
    }
}