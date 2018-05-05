namespace ToyRobotSimulator.Console.Models
{
    using Interfaces;

    public class Robot : IRobot
    {
        public ObjectPosition Position { get; set; }
    }
}