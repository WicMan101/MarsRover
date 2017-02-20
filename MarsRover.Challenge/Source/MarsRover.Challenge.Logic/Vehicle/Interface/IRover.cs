namespace MarsRover.Challenge.Logic.Vehicle.Interface
{
    public interface IRover
    {
        int XCoordinate { get; set; }

        int YCoordinate { get; set; }

        string DirectionFacing { get; set; }

        void Run();
    }
}
