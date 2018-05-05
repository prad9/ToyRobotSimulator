namespace ToyRobotSimulator.Console.Commands
{
    using System;
    using Interfaces;
    using Models;

    public class PlaceCommand : ICommand
    {
        private readonly ObjectPosition _objectPositionToPlace;

        public PlaceCommand(ObjectPosition objectPositionToPlace)
        {
            _objectPositionToPlace = objectPositionToPlace;
        }

        public ObjectPosition Execute(IRobot robot, int[,] table)
        {
            Array.Clear(table, 0, table.Length);

            bool IsValidPosition(int xPosition, int yPosition)
            {
                return xPosition >= table.GetLowerBound(0) && yPosition >= table.GetLowerBound(0) && yPosition <= table.GetUpperBound(0) && xPosition <= table.GetUpperBound(0);
            }

            if (IsValidPosition(_objectPositionToPlace.XPosition, _objectPositionToPlace.YPosition))
            {
                robot.Position = _objectPositionToPlace;
                table.SetValue(1, _objectPositionToPlace.XPosition, _objectPositionToPlace.YPosition);
                return robot.Position;
            }

            return null;
        }
    }
}