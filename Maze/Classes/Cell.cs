using Maze.Classes;

namespace Maze
{
    public class Cell : Coords
    {
        public bool Visited { get; set; }

        public Cell(int x, int y) : base(x, y)
        {
            Visited = Visited;
        }
    }
}