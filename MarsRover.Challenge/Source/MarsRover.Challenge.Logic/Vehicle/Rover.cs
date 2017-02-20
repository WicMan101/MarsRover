using MarsRover.Challenge.Logic.Common;
using MarsRover.Challenge.Logic.Terrain.Interface;
using MarsRover.Challenge.Logic.Vehicle.Interface;
using System;

namespace MarsRover.Challenge.Logic.Vehicle
{
    public class Rover : IRover
    {
        public int XCoordinate { get; set; }

        public int YCoordinate { get; set; }

        public string DirectionFacing { get; set; }

        private ILandingSurface _LandingSurface;

        private static readonly char MessageSeperator = ' ';

        private string _RoverCommands;

        public Rover(ILandingSurface landingSurface, string roverPosition, string roverCommands)
        {
            _LandingSurface = landingSurface;
            SetRoverPosition(roverPosition);

            if (!RoverIsWithinLandingCoordinates())
                return;

            _RoverCommands = roverCommands;
        }

        public void Run()
        {
            SetRoverCommands(_RoverCommands);
        }

        private void SetRoverPosition(string roverPosition)
        {
            string[] roverPositionMsgSplit = roverPosition.Split(Rover.MessageSeperator);

            int xCoordinateIdx = 0;
            int yCoordinateIdx = 1;
            int facingDirectionIdx = 2;

            XCoordinate = Convert.ToInt32(roverPositionMsgSplit[xCoordinateIdx]);
            YCoordinate = Convert.ToInt32(roverPositionMsgSplit[yCoordinateIdx]);
            DirectionFacing = roverPositionMsgSplit[facingDirectionIdx];
        }

        private void SetRoverCommands(string roverCommands)
        {
            char[] commands = roverCommands.ToCharArray();

            foreach (char command in commands)
            {
                switch (command.ToString())
                {
                    case Commands.MoveForward:
                        MoveRoverForward();
                        break;

                    default:
                        RotateRover(command.ToString());
                        break;
                }
            }
        }

        private bool RoverIsWithinLandingCoordinates()
        {
            return (XCoordinate >= 0) && (XCoordinate < _LandingSurface.Width) &&
                (YCoordinate >= 0) && (YCoordinate < _LandingSurface.Height);
        }

        public void MoveRoverForward()
        {
            switch (DirectionFacing)
            {
                case Direction.North:
                    if (YCoordinate >= _LandingSurface.Height)
                    {
                        Console.WriteLine("Invalid input parameter. Proceeding to next step...");
                        break;
                    }
                    YCoordinate++;
                    break;

                case Direction.East:
                    if (XCoordinate >= _LandingSurface.Width)
                    {
                        Console.WriteLine("Invalid input parameter. Proceeding to next step...");
                        break;
                    }
                    XCoordinate++;
                    break;

                case Direction.South:
                    if (YCoordinate <= 0)
                    {
                        Console.WriteLine("Invalid input parameter. Proceeding to next step...");
                        break;
                    }

                    YCoordinate--;
                    break;

                case Direction.West:
                    if (XCoordinate <= 0)
                    {
                        Console.WriteLine("Invalid input parameter. Proceeding to next step...");
                        break;
                    }
                    XCoordinate--;
                    break;
            }
        }

        public void RotateRover(string directionCommand)
        {
            switch (directionCommand.ToUpper())
            {
                case Commands.RotateLeft:
                    TurnRoverLeft();
                    break;

                case Commands.RotateRight:
                    TurnRoverRight();
                    break;

                default:
                    throw new ArgumentException();
            }
        }

        private void TurnRoverLeft()
        {
            switch (DirectionFacing)
            {
                case Direction.North:
                    DirectionFacing = Direction.West;
                    break;

                case Direction.West:
                    DirectionFacing = Direction.South;
                    break;

                case Direction.South:
                    DirectionFacing = Direction.East;
                    break;

                case Direction.East:
                    DirectionFacing = Direction.North;
                    break;
            }
        }

        private void TurnRoverRight()
        {
            switch (DirectionFacing)
            {
                case Direction.North:
                    DirectionFacing = Direction.East;
                    break;

                case Direction.East:
                    DirectionFacing = Direction.South;
                    break;

                case Direction.South:
                    DirectionFacing = Direction.West;
                    break;

                case Direction.West:
                    DirectionFacing = Direction.North;
                    break;
            }
        }
    }
}
