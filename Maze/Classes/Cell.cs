using Maze.Classes;
using System.Drawing;

namespace Maze
{
    public class Cell : Coords
    {
        #region public properties
        public bool Visited { get; set; }
        public bool IsDark { get; set; }
        public Color Color { get; set; }
        #endregion

        #region constructor
        public Cell(int x, int y) : base(x, y)
        {
            Visited = Visited;
            IsDark = IsDark;
            Color = Color;
        }
        #endregion
    }
}