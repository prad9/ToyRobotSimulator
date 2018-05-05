namespace ToyRobotSimulator.Console.Interfaces
{
    using Models;

    public interface IRobotActionProcessor
    {
        ObjectPosition Process(ICommand command);
    }
}