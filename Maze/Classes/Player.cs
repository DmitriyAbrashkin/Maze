using Maze.Classes;

namespace Maze
{
    public class Player : Coords
    {
        public Direction Direction { get; set; }

        public Field Field { get; set; }

        public Player()
        {
            Field = new Field(43, 21);
            //Field = new Field(19, 19);
            SetPlayer();
        }

        private void SetPlayer()
        {
            X = 1;
            Y = 1;
            Field.Cells[X, Y].Tip = Tip.Player;
           // DarkMaze(X, Y);
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
                    if (X + 1 < Field.Height)
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
                    if (Y + 1 < Field.With)
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

        public bool EndGame()
        {
            if (X == Field.finish.X && Y == Field.finish.Y)
                return true;
            else
                return false;
        }

        public void DarkMaze(int x, int y)
        {
            for (int i = x; i < Field.Height - 2; i++)
            {
                Field.Cells[i+2, y].Tip = Tip.Dark;
            }

            for (int i = x; i < 0; i--)
            {
                Field.Cells[i+2, y].Tip = Tip.Dark;
            }

            for (int i = y; i < Field.With - 2; i++)
            {
                Field.Cells[x, i+2].Tip = Tip.Dark;
            }

            for (int i = y; i < 0; i--)
            {
                Field.Cells[x, i+2].Tip = Tip.Dark;
            }

            
        }

    }
}