using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze.Classes
{
    public class Coords
    {
        #region public properties
        public int X { get; set; }
        public int Y { get; set; }
        #endregion

        #region constructor
        public Coords(int x, int y)
        {
            X = x;
            Y = y;
        }
        #endregion
    }
}
