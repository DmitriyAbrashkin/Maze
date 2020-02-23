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
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < With; j++)
                {
                    Tip tip;
                    Vis vis = Vis.UnVisited;

                    if ((i % 2 != 0 && j % 2 != 0) && (i < Height - 1 && j < With - 1))
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
            Cell startCell = cells[1, 1];
            Cell currentCell = startCell;
            Cell neighbourCell;
            Stack<Cell> neigh = new Stack<Cell>();
            List<Cell> cellStringUnvisited = new List<Cell>();
            cellStringUnvisited = getUnvisitedCells(with, height, cells);
            do
            {
                List<Cell> Neighbours = getNeighbours(with, height, cells, startCell, 2);
                if (Neighbours.Count != 0)
                { //если у клетки есть непосещенные соседи
                    int random = rnd.Next(0, Neighbours.Count - 1);
                    neighbourCell = Neighbours[random]; //выбираем случайного соседа
                    neigh.Push(startCell); //заносим текущую точку в стек
                    removeWall(currentCell, neighbourCell, cells); //убираем стену между текущей и сосендней точками
                    currentCell = neighbourCell; //делаем соседнюю точку текущей и отмечаем ее посещенной
                    cells[neighbourCell.X, neighbourCell.Y].Vis = Vis.Visted;

                }
                else if (neigh.Count > 0)
                { //если нет соседей, возвращаемся на предыдущую точку
                    startCell = neigh.Pop();
                }
                else
                { //если нет соседей и точек в стеке, но не все точки посещены, выбираем случайную из непосещенных
                    cellStringUnvisited = getUnvisitedCells(with, height, cells);
                    int random = rnd.Next(0, cellStringUnvisited.Count - 1);
                    currentCell = cellStringUnvisited[random];
                }
            }
            while (cellStringUnvisited.Count > 0);




        }

        private List<Cell> getNeighbours(int with, int height, Cell[,] cells, Cell startCell, int distance)
        {
            List<Cell> cells1 = new List<Cell>();
            try
            {
                Cell up = cells[startCell.X, startCell.Y - distance];
                Cell rt = cells[startCell.X + distance, startCell.Y];
                Cell dw = cells[startCell.X, startCell.Y + distance];
                Cell lt = cells[startCell.X - distance, startCell.Y];

               

                Cell[] d = new Cell[4] { dw, rt, up, lt };

                for (int i = 0; i < 4; i++)
                { //для каждого направдения
                    if (d[i].X > 0 && d[i].X < with && d[i].Y > 0 && d[i].Y < height)
                    { //если не выходит за границы лабиринта
                        Cell cellCurrent = d[i];
                        if (cellCurrent.Tip != Tip.Wall && cellCurrent.Vis != Vis.Visted)
                        { //и не посещена\является стеной
                            cells1.Add(cellCurrent); //записать в массив;
                        }
                    }
                }
                return cells1;
            }

            catch
            {
                return cells1;
            }
        }

        private void removeWall(Cell currentCell, Cell neighbourCell, Cell[,] cells)
        {
            int xDiff = neighbourCell.X - currentCell.X;
            int yDiff = neighbourCell.Y - currentCell.Y;
            int addX, addY;
            Cell target = currentCell;

            addX = (xDiff != 0) ? (xDiff / Math.Abs(xDiff)) : 0;
            addY = (yDiff != 0) ? (yDiff / Math.Abs(yDiff)) : 0;


            target.X = currentCell.X + addX; //координаты стенки
            target.Y = currentCell.Y + addY;

            cells[target.X, target.Y].Tip = Tip.Cell;
            cells[target.X, target.Y].Vis = Vis.Visted;


        }

        private List<Cell> getUnvisitedCells(int with, int height, Cell[,] cells)
        {
            List<Cell> cells1 = new List<Cell>();
            foreach (Cell cell in cells)
            {
                if (cell.Vis == Vis.UnVisited)
                {
                    cells1.Add(cell);
                }
            }

            return cells1;
        }






    }
}

