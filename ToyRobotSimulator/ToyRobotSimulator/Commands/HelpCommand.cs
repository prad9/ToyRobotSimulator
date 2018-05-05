namespace ToyRobotSimulator.Console.Commands
{
    using System;
    using Interfaces;
    using Models;

    public class HelpCommand : ICommand
    {
        public ObjectPosition Execute(IRobot robot, int[,] table)
        {
            Console.WriteLine("Commands available");
            Console.WriteLine("----------------------");
            Console.WriteLine("PLACE arg0,arg1,arg2 -- Place will put the topy on the table in position x(arg0), y(arg1), and direction North, South, East, or West (arg2)");
            Console.WriteLine("Note: arg2 - Direction is case sensitive");
            Console.WriteLine("MOVE -- Will move robot one unit forward in the direction it is currently facing");
            Console.WriteLine("LEFT -- Rotates robot 90 degress without changing position of the robot");
            Console.WriteLine("RIGHT -- Rotates robot 90 degress without changing position of the robot");
            Console.WriteLine("REPORT -- Will announce the current position of the robot");
            Console.WriteLine("HELP -- Will print out all the valid commands");
            Console.WriteLine("----------------------");
            return null;
        }
    }
}
