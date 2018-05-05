namespace ToyRobotSimulator.Console
{
    using Interfaces;
    using Models;

    public class RobotActionProcessor : IRobotActionProcessor
    {
        private readonly IRobot _robot;
        private readonly int[,] _table;

        public RobotActionProcessor(IRobot robot, int[,] table)
        {
            _robot = robot;
            _table = table;
        }

        public ObjectPosition Process(ICommand command)
        {
            return command.Execute(_robot, _table);
        }
    }
}