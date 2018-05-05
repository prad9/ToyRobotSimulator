namespace ToyRobotSimulator.Console
{
    using System;
    using Commands;

    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Toy Robot Simulator.");
            var robot = new Robot();
            Console.WriteLine("Robot initiated.");
            var table = new int[5, 5];
            Console.WriteLine("Robot is now ready to move on table (5 units x 5 units) as per instructions.");

            var commandParser = new CommandParser();
            string input;
            while ((input = Console.ReadLine()) != null)
            {
                var command = commandParser.Parse(input);
                var robotActionProcessor = new RobotActionProcessor(robot, table);
                var objectPosition = robotActionProcessor.Process(command);
                if (command.GetType() == typeof(ReportCommand))
                {
                    Console.WriteLine(objectPosition == null 
                        ? "Invalid moves" : $"Current robot position X:{objectPosition.XPosition} Y:{objectPosition.YPosition} Direction:{objectPosition.Facing.ToString()}");
                }
            }
        }
    }
}