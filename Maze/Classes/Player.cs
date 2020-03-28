using Maze.Classes;
using System;

namespace Maze
{
    public class Player : Cell
    {
        public Direction Direction { get; set; }

        public Field Field { get; set; }

        public Player(int x, int y) : base(x, y)
        {
            X = x;
            Y = y;
            Field = new Field(21, 21);

        }



        public bool Step(Direction direction)
        {
            switch (direction)
            {
                case Direction.lf:
                    if (X - 1 > 0)
                    {
                        if (!(Field.Cells[X - 1, Y] is WallCell))
                        {
                            X -= 1;
                            return true;
                        }
                        return false;
                    }
                    else
                        return false;
                case Direction.rt:
                    if (X + 1 < Field.Height)
                    {
                        if (!(Field.Cells[X + 1, Y] is WallCell))
                        {
                            X += 1;
                            return true;
                        }
                        return false;
                    }
                    else
                        return false;
                case Direction.tp:
                    if (Y - 1 > 0)
                    {
                        if (!(Field.Cells[X, Y - 1] is WallCell))
                        {
                            Y -= 1;
                            return true;
                        }
                        return false;
                    }
                    else
                        return false;
                case Direction.dw:
                    if (Y + 1 < Field.With)
                    {
                        if (!(Field.Cells[X, Y + 1] is WallCell))
                        {
                            Y += 1;
                            return true;
                        }
                        return false;
                    }
                    else
                        return false;
                default:
                    return false;
            }
        }

        public bool EndGame()
        {
            if (X == Field.finish.X && Y == Field.finish.Y)
                return true;
            else
                return false;
        }
    }
}