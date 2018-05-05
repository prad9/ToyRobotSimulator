namespace ToyRobotSimulator.Console
{
    using System;
    using Commands;
    using Interfaces;
    using Models;

    public class CommandParser
    {
        public ICommand Parse(string input)
        {
            string command;
            var arguments = string.Empty;
            var commandWithArgs = input.Split(' ');
            if (commandWithArgs.Length == 2)
            {
                command = commandWithArgs[0];
                arguments = commandWithArgs[1];
            }
            else if (commandWithArgs.Length == 1)
            {
                command = commandWithArgs[0];
            }
            else
            {
                return new InvalidCommand();
            }


            if (string.Equals(command, Command.Place.ToString(), StringComparison.CurrentCultureIgnoreCase))
            {
                var argumentsSplit = arguments.Split(',');
                if (argumentsSplit.Length == 3 && int.TryParse(argumentsSplit[0], out var xPosition) && int.TryParse(argumentsSplit[1], out var yPosition) &&
                    Enum.IsDefined(typeof(Facing), argumentsSplit[2]))
                {
                    return new PlaceCommand(
                        new ObjectPosition
                        {
                            Facing = (Facing)Enum.Parse(typeof(Facing), argumentsSplit[2], true),
                            XPosition = xPosition,
                            YPosition = yPosition
                        });
                }

                return new InvalidCommand();
            }

            if (string.Equals(command, Command.Left.ToString(), StringComparison.CurrentCultureIgnoreCase) && commandWithArgs.Length == 1)
            {
                return new LeftCommand();
            }

            if (string.Equals(command, Command.Right.ToString(), StringComparison.CurrentCultureIgnoreCase) && commandWithArgs.Length == 1)
            {
                return new RightCommand();
            }

            if (string.Equals(command, Command.Move.ToString(), StringComparison.CurrentCultureIgnoreCase) && commandWithArgs.Length == 1)
            {
                return new MoveCommand();
            }

            if (string.Equals(command, Command.Report.ToString(), StringComparison.CurrentCultureIgnoreCase) && commandWithArgs.Length == 1)
            {
                return new ReportCommand();
            }

            if (string.Equals(command, Command.Help.ToString(), StringComparison.CurrentCultureIgnoreCase) && commandWithArgs.Length == 1)
            {
                return new HelpCommand();
            }

            return new InvalidCommand();
        }
    }
}