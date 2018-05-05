namespace ToyRobotSimulator.Console.Commands
{
    using System;
    using Interfaces;
    using Models;

    public class InvalidCommand : ICommand
    {
        public ObjectPosition Execute(IRobot robot, int[,] table)
        {
            Console.WriteLine("Invalid command");
            return null;
        }
    }
}