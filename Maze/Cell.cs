namespace Maze
{
    public class Cell
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Tip Tip { get; set; }
        public Vis Vis { get; set; }


        public Cell(int x, int y, Tip tip, Vis vis)
        {
            X = x;
            Y = y;
            Tip = tip;
            Vis = vis;
        }
    }
}