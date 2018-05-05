namespace ToyRobotSimulator.Console.Commands
{
    using Interfaces;
    using Models;

    public class LeftCommand : ICommand
    {
        public ObjectPosition Execute(IRobot robot, int[,] table)
        {
            if (robot.Position != null)
            {
                switch (robot.Position.Facing)
                {
                    case Facing.East:
                        robot.Position.Facing = Facing.North;
                        break;
                    case Facing.West:
                        robot.Position.Facing = Facing.South;
                        break;
                    case Facing.North:
                        robot.Position.Facing = Facing.West;
                        break;
                    case Facing.South:
                        robot.Position.Facing = Facing.East;
                        break;
                }
            }

            return robot.Position;
        }
    }
}