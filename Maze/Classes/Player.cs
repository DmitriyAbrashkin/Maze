using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze.Classes
{
    public class Player : Coords
    {
        public Direction Direction { get; set; }


        public void Step(Direction Direction)
        {
            switch (Direction)
            {
                case Direction.lf:
                    X -= 1;
                    break;
                case Direction.rt:
                    X += 1;
                    break;
                case Direction.tp:
                    Y += 1;
                    break;
                case Direction.dw:
                    Y -= 1;
                    break;
                default:
                    break;
            }
        }
    }

}
