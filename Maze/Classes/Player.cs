using Maze.Classes;

namespace Maze
{
    public class Player : Coords
    {
        public Direction Direction { get; set; }

        public Field Field { get; set; }

        public Player()
        {
            Field = new Field(41, 41);
            SetPlayer();
        }

        private void SetPlayer()
        {
            X = 1;
            Y = 1;
            Field.Cells[X, Y].Tip = Tip.Player;
        }

        public bool Step(Direction direction)
        {
            switch (direction)
            {
                case Direction.lf:
                    if (X - 1 > 0)
                    {
                        if (Field.Cells[X - 1, Y].Tip != Tip.Wall)
                        {
                            Field.Cells[X, Y].Tip = Tip.Cell;
                            Field.Cells[X - 1, Y].Tip = Tip.Player;
                            X -= 1;
                            return true;
                        }
                        return false;
                    }
                    else
                    {
                        return false;
                    }
                case Direction.rt:
                    if (X + 1 < Field.With)
                    {
                        if (Field.Cells[X + 1, Y].Tip != Tip.Wall)
                        {
                            Field.Cells[X, Y].Tip = Tip.Cell;
                            Field.Cells[X + 1, Y].Tip = Tip.Player;
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
                        if (Field.Cells[X, Y - 1].Tip != Tip.Wall)
                        {
                            Field.Cells[X, Y].Tip = Tip.Cell;
                            Field.Cells[X, Y - 1].Tip = Tip.Player;
                            Y -= 1;
                            return true;
                        }
                        return false;
                    }
                    else
                        return false;
                case Direction.dw:
                    if (Y + 1 < Field.Height)
                    {
                        if (Field.Cells[X, Y + 1].Tip != Tip.Wall)
                        {
                            Field.Cells[X, Y].Tip = Tip.Cell;
                            Field.Cells[X, Y + 1].Tip = Tip.Player;
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

    }
}