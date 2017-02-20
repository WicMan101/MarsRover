using MarsRover.Challenge.Logic.Terrain;
using MarsRover.Challenge.Logic.Terrain.Interface;
using MarsRover.Challenge.Logic.Vehicle;
using MarsRover.Challenge.Logic.Vehicle.Interface;
using System;

namespace MarsRover.Challenge.Run
{
    class Program
    {
        private static string _SurfaceSize;
        private static string _StartPointAndDirection;
        private static string _MovementCommands;

        static void Main(string[] args)
        {
            SetCommunicationVariables();

            ILandingSurface landingSurface = new Surface(_SurfaceSize);
            IRover rover = new Rover(landingSurface, _StartPointAndDirection, _MovementCommands);

            Console.WriteLine("Type send to send communication to Mars Rover.");
            Console.Write("Input: ");

            string line = Console.ReadLine();

            if (line.ToLower() == "send")
            {
                rover.Run();
                Console.WriteLine($"Rover location is {rover.XCoordinate}:{rover.YCoordinate} facing: {rover.DirectionFacing}");
                Console.ReadKey();
            }
        }

        public static void SetCommunicationVariables()
        {
            int counter = 0;
            string line;

            System.IO.StreamReader file = new System.IO.StreamReader("../../../../CommunicationFile/Communication.txt");
            while ((line = file.ReadLine()) != null)
            {
                switch (counter)
                {
                    case 0:
                        _SurfaceSize = line;
                        break;
                    case 1:
                        _StartPointAndDirection = line;
                        break;
                    case 2:
                        _MovementCommands = line;
                        break;
                    default:
                        break;
                }

                counter++;
            }

            file.Close();
        }
    }
}
