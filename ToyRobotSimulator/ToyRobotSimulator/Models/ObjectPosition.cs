namespace ToyRobotSimulator.Console.Models
{
    public class ObjectPosition
    {
        public int XPosition { get; set; } = -1;
        public int YPosition { get; set; } = -1;
        public Facing Facing { get; set; } = Facing.Invalid;    
    }
}