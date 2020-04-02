using Maze.Classes;
using System.Collections.Generic;
using System.Drawing;

namespace Maze
{
    public class Player : Cell
    {
        #region public properties
        public Direction Direction { get; set; }

        public Field Field { get; set; }

        public int RadiusNoDarkCell { get; set; }
        #endregion

        #region constructor
        public Player(int x, int y) : base(x, y)
        {
            X = x;
            Y = y;
            Field = new Field(43, 21);
            RadiusNoDarkCell = 2;

        }
        #endregion

        #region private metods
        private List<Cell> GetCellAroundPlayer(int x, int y)
        {
            List<Cell> cells = new List<Cell>();
            for (int i = -RadiusNoDarkCell; i < RadiusNoDarkCell + 1; i++)
            {
                for (int j = -RadiusNoDarkCell; j < RadiusNoDarkCell + 1; j++)
                {
                    Cell cell = new Cell(x + i, y + j);
                    cells.Add(cell);
                }
            }
            return cells;
        }

        private void Bonus()
        {
            if (X == Field.Bonus.X && Y == Field.Bonus.Y)
            {
                RadiusNoDarkCell += 2;
                Field.Cells[X, Y] = new FreeCell(X, Y);
            }
        }
        #endregion

        #region public metods
        public bool Step(Direction direction)
        {
            switch (direction)
            {
                case Direction.Left:
                    if (X - 1 > 0)
                    {
                        if (!(Field.Cells[X - 1, Y] is WallCell))
                        {
                            X -= 1;
                            Bonus();
                            return true;
                        }
                        return false;
                    }
                    else
                        return false;
                case Direction.Right:
                    if (X + 1 < Field.Height)
                    {
                        if (!(Field.Cells[X + 1, Y] is WallCell))
                        {
                            X += 1;
                            Bonus();
                            return true;
                        }
                        return false;
                    }
                    else
                        return false;
                case Direction.Top:
                    if (Y - 1 > 0)
                    {
                        if (!(Field.Cells[X, Y - 1] is WallCell))
                        {
                            Y -= 1;
                            Bonus();
                            return true;
                        }
                        return false;
                    }
                    else
                        return false;
                case Direction.Down:
                    if (Y + 1 < Field.With)
                    {
                        if (!(Field.Cells[X, Y + 1] is WallCell))
                        {
                            Y += 1;
                            Bonus();
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

        public void RenderDark()
        {
            List<Cell> cells = GetCellAroundPlayer(X, Y);

            foreach (var item in Field.Cells)
            {
                if (!(item is ExetCell) || (!(item is Player)))
                {
                    item.IsDark = true;
                    Field.Cells[item.X, item.Y].Color = Color.Black;
                }
            }

            foreach (var item in cells)
            {
                if (item.X + 1 < Field.Height && item.Y + 1 < Field.With && item.X - 1 >= 0 && item.Y - 1 >= 0)
                {
                    if (Field.Cells[item.X, item.Y] is FreeCell)
                    {
                        Field.Cells[item.X, item.Y].Color = Color.White;
                        Field.Cells[item.X, item.Y].IsDark = false;
                    }
                    else if (Field.Cells[item.X, item.Y] is BonusCell)
                    {
                        Field.Cells[item.X, item.Y].Color = Color.Aqua;
                        Field.Cells[item.X, item.Y].IsDark = false;
                    }
                    else if (Field.Cells[item.X, item.Y] is Player)
                    {
                        Field.Cells[item.X, item.Y].Color = Color.Red;
                        Field.Cells[item.X, item.Y].IsDark = false;
                    }
                    else if (Field.Cells[item.X, item.Y] is ExetCell)
                    {
                        Field.Cells[item.X, item.Y].Color = Color.Green;
                        Field.Cells[item.X, item.Y].IsDark = false;
                    }
                    else if (Field.Cells[item.X, item.Y] is WallCell)
                    {
                        Field.Cells[item.X, item.Y].Color = Color.Gray;
                        Field.Cells[item.X, item.Y].IsDark = false;
                    }
                }
            }
        }

        public bool EndGame()
        {
            if (X == Field.Finish.X && Y == Field.Finish.Y)
                return true;
            else
                return false;
        }
        #endregion
    }
}