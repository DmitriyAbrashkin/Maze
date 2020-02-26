using Maze.Classes;

namespace Maze
{
    public class Cell : Coords
    {
        public Tip Tip { get; set; }


        public Cell(int x, int y, Tip tip)
        {
            X = x;
            Y = y;
            Tip = tip;
        }
    }
}