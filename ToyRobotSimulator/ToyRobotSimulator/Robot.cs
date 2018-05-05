namespace ToyRobotSimulator.Console
{
    using Interfaces;
    using Models;

    public class Robot : IRobot
    {
        public ObjectPosition Position { get; set; }
    }
}