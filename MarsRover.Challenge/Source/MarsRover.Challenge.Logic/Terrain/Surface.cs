using MarsRover.Challenge.Logic.Terrain.Interface;
using System;

namespace MarsRover.Challenge.Logic.Terrain
{
    public class Surface : ILandingSurface
    {
        private static readonly char MsgSeperator = ' ';

        public virtual int Width { get; private set; }

        public virtual int Height { get; private set; }

        public Surface(int xMaxCoordinate, int yMaxCoordinate)
        {
            Width = xMaxCoordinate;
            Height = yMaxCoordinate;
        }

        public Surface(string terrainCoordinates)
        {
            if (string.IsNullOrEmpty(terrainCoordinates))
                throw new ArgumentException();

            SplitMessageCoordinates(terrainCoordinates);
        }

        private void SplitMessageCoordinates(string terrainCoordinates)
        {
            string[] coordinateMessage = terrainCoordinates.Split(Surface.MsgSeperator);

            int noOfMsgValues = 2;
            int xCoordinateIdx = 0;
            int yCoordinateIdx = 1;

            if (coordinateMessage.Length != noOfMsgValues)
                throw new ArgumentOutOfRangeException();

            Width = Convert.ToInt32(coordinateMessage[xCoordinateIdx]);
            Height = Convert.ToInt32(coordinateMessage[yCoordinateIdx]);
        }
    }
}
