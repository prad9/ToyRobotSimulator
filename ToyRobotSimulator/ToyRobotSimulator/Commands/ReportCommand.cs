namespace ToyRobotSimulator.Console.Commands
{
    using Interfaces;
    using Models;

    public class ReportCommand : ICommand
    {
        public ObjectPosition Execute(IRobot robot, int[,] table)
        {
            return robot.Position;
        }
    }
}