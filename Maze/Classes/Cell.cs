using Maze.Classes;

namespace Maze
{
    public class Cell : Coords
    {
        public Tip Tip { get; set; }
        public bool Visited { get; set; }


        public Cell(int x, int y, Tip tip, bool visited)
        {
            X = x;
            Y = y;
            Tip = tip;
            Visited = visited;
        }
    }
}