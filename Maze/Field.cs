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

                    if (i % 2 == 0 && j % 2 == 0)
                    {
                        tip = Tip.Cell;
                    }
                    else
                    {
                        tip = Tip.Wall;
                    }
                    Cell cell = new Cell(i, j, tip);
                    Cells[i, j] = cell;
                }
            }

        }

        private void CreateMaze(int height, int with, Cell[,] cells)
        {
            Random rnd = new Random();

            int x = rnd.Next(0, with);
            int y = rnd.Next(0, height);

            Cell StartCell = cells[1, 1];
            Cell CurrentCell = StartCell;
            Cell neighbourCell;
            //do
            //{
            //   // Cell[] Neighbours = GetNeighbours(with, height, 2);

            //    if (Neighbours.Length != 0)
            //    {
            //        int randNum = rnd.Next(0, Neighbours.Length - 1);
            //        neighbourCell = Neighbours[randNum];
                    


            //    }
            //}
            //while ();
            //




        }

        private Cell GetNeighbours(int with, int height, object startPoint, int v)
        {
            throw new NotImplementedException();
        }
    }


}

