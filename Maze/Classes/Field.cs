using Maze.Classes;
using System;

namespace Maze
{
    public class Field
    {
        public int Height { get; set; }
        public int With { get; set; }

        public Cell[,] Cells { get; set; }

        public Player Player { get; set; }



        public Field(int height, int with)
        {
            Height = height;
            With = with;
            Cells = new Cell[Height, With];
            FillFeld();
            CreateMaze();

        }

      


        public void FillFeld()
        {
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < With; j++)
                {
                    Tip tip;
                    if ((i % 2 != 0 && j % 2 != 0) && (i < Height - 1 && j < With - 1))
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
            Player player = new Player();
            player.X = 1;
            player.Y = 1;
            Cells[player.X, player.Y].Tip = Tip.Player;

        }

        private void CreateMaze()
        {
            Random rnd = new Random();
            for (int j = 1; j < Height; j += 2)
            {
                for (int i = 1; i < With; i += 2)
                {
                    int nap = rnd.Next(2);
                    if (nap == 0)
                    {
                        if (j + 1 < Height)
                        {
                            Cells[j, i + 1].Tip = Tip.Cell;
                        }
                        else
                        {
                            Cells[j + 1, i].Tip = Tip.Cell;
                        }
                    }
                    else
                    {
                        if (i + 1 < With)
                        {
                            Cells[j + 1, i].Tip = Tip.Cell;
                        }
                    }
                }
            }
        }
    }
}

