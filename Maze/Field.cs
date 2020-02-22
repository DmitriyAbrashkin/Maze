using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze
{
    public class Field
    {
        public int Height { get; set; }
        public int With { get; set; }

        public Cell[,] Cells { get; set; }



        public Field(int height, int with)
        {
            Height = height;
            With = with;
            Cells = new Cell[Height, With];


            FillFeld();
            CreateMaze(height, with, Cells);

        }


        public void FillFeld()
        {
            for (int i = 0; i < With; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    Tip tip;
                    Vis vis = Vis.UnVisited;

                    if (i % 2 == 0 && j % 2 == 0)
                    {
                        tip = Tip.Cell;
                    }
                    else
                    {
                        tip = Tip.Wall;
                    }
                    Cell cell = new Cell(i, j, tip, vis);
                    Cells[i, j] = cell;
                }
            }

        }

        private void CreateMaze(int height, int with, Cell[,] cells)
        {
            Random rnd = new Random();

            //int x = rnd.Next(0, with - 1);
            //int y = rnd.Next(0, height - 1);

            Cell StartCell = cells[0, 0];
            Cell CurrentCell = StartCell;

            int a;
            int n = 0;
            while (n < 10000)
            {
                n++;
                int Dist = rnd.Next(0, 2);
                if (Dist == 0)
                {
                    if (CurrentCell.X + 2 > with)
                    {
                        a = 1;
                    }
                    else
                    {
                        a = 0;
                    }
                }
                else
                {
                    a = 1;
                }
   
                switch (a)
                {
                    case 0:
                        if (CurrentCell.X + 2 < with)
                        {
                            for (int i = 1; i <= 2; i++)
                            {
                                cells[CurrentCell.X + i, CurrentCell.X].Vis = Vis.Visted;
                                cells[CurrentCell.X + i, CurrentCell.Y].Tip = Tip.Cell;
                            }
                            CurrentCell = cells[CurrentCell.X + 2, CurrentCell.Y];
                        }
                        break;
                    case 1:
                        if (CurrentCell.Y - 2 > height)
                        {
                            for (int i = 1; i <= 2; i++)
                            {
                                cells[CurrentCell.X - i, CurrentCell.Y].Vis = Vis.Visted;
                                cells[CurrentCell.X - i, CurrentCell.Y].Tip = Tip.Cell;
                            }
                            CurrentCell = cells[CurrentCell.X - 2, CurrentCell.Y];
                        }
                        break;
                    #region
                    //case 2:
                    //    if (CurrentCell.Y + 2 < height)
                    //    {
                    //        for (int i = 1; i <= 2; i++)
                    //        {
                    //            cells[CurrentCell.X, CurrentCell.Y + i].Vis = Vis.Visted;
                    //            cells[CurrentCell.X, CurrentCell.Y + i].Tip = Tip.Cell;
                    //        }
                    //        CurrentCell = cells[CurrentCell.X, CurrentCell.Y + 2];
                    //    }
                    //    break;
                    //case 3:
                    //    if (CurrentCell.Y - 2 > 0)
                    //    {
                    //        for (int i = 1; i <= 2; i++)
                    //        {
                    //            cells[CurrentCell.X, CurrentCell.Y - i].Vis = Vis.Visted;
                    //            cells[CurrentCell.X, CurrentCell.Y - i].Tip = Tip.Cell;
                    //        }
                    //        CurrentCell = cells[CurrentCell.X, CurrentCell.Y - 2];
                    //    }
                    //    break;
                    #endregion
                    default:
                        break;
                }
            }






        }

        private bool AllCellsVisited(Cell[,] cells)
        {
            foreach (var cell in cells)
            {
                if (cell.Vis == Vis.UnVisited)
                {
                    return true;
                }
            }
            return false;
        }
    }


}

