namespace ToyRobotSimulator.Console.Commands
{
    using System;
    using Interfaces;
    using Models;

    public class MoveCommand : ICommand
    {
        public ObjectPosition Execute(IRobot robot, int[,] table)
        {
            if (robot.Position != null)
            {
                Array.Clear(table, 0, table.Length);
                var newXPosition = robot.Position.XPosition;
                var newYPosition = robot.Position.YPosition;
                switch (robot.Position.Facing)
                {
                    case Facing.East:
                        newXPosition = robot.Position.XPosition + 1;
                        break;
                    case Facing.West:
                        newXPosition = robot.Position.XPosition - 1;
                        break;
                    case Facing.North:
                        newYPosition = robot.Position.YPosition + 1;
                        break;
                    case Facing.South:
                        newYPosition = robot.Position.YPosition - 1;
                        break;
                }

                bool IsValidPosition(int xPosition, int yPosition)
                {
                    return xPosition >= table.GetLowerBound(0) && yPosition >= table.GetLowerBound(0) && yPosition <= table.GetUpperBound(0) && xPosition <= table.GetUpperBound(0);
                }

                if (IsValidPosition(newXPosition, newYPosition))
                {
                    table.SetValue(1, newXPosition, newYPosition);
                    robot.Position.XPosition = newXPosition;
                    robot.Position.YPosition = newYPosition;
                }
            }

            return robot.Position;
        }
    }
}