namespace ToyRobotSimulator.Console.Interfaces
{
    using Models;

    public interface ICommand
    {
        ObjectPosition Execute(IRobot robot, int[,] table);
    }
}