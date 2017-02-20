using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarsRover.Challenge.Logic.Terrain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarsRover.Challenge.Logic.Terrain.Interface;

namespace MarsRover.Challenge.Logic.Terrain.Tests
{
    [TestClass()]
    public class SurfacesTest
    {
        private ILandingSurface _StaticCoordinatesSurface;
        private ILandingSurface _TerrainSurface;

        [TestInitialize]
        public void InitializeTest()
        {
            _StaticCoordinatesSurface = new Surface(8, 8);
        }

        [TestMethod()]
        public void SurfaceTest()
        {
            int height = _StaticCoordinatesSurface.Height;
            int width = _StaticCoordinatesSurface.Width;

            Assert.AreEqual(8, height);
            Assert.AreEqual(8, width);
            Assert.AreEqual(height, width);

        }
    }
}