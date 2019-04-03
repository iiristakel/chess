namespace Domain
{
    
    public class Square
    {
        
        public bool IsBlocked { get; set; }
        public bool IsEndPosition { get; set; }
        public bool IsStartPosition { get; set; }
        public bool IsVisited { get; set; }

        // Number of moves from start position.
        public int Dist { get; set; }

        // Previous square on path finding the solution. Every square can have only one previous square.
        public Square Previous { get; set; }

        // Square's x coordinate.
        public int X { get; set; }
        
        // Square's y coordinate.
        public int Y { get; set; }
    }
}