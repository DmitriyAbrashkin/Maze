using Maze.Classes;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Maze
{
    public class Field
    {
        #region public properties
        public int Height { get; set; }
        public int With { get; set; }
        public ExetCell Finish { get; set; }
        public BonusCell Bonus { get; set; }
        public Cell[,] Cells { get; set; }

        public Player Player { get; set; }
        #endregion

        #region private properties
        private readonly Stack<Cell> path = new Stack<Cell>();
        private readonly List<Cell> neighbords = new List<Cell>();
        private readonly Random Random = new Random();
        #endregion

        #region constructor
        public Field(int height, int with)
        {
            Cells = new Cell[height, with];
            Height = height;
            With = with;
            FillFeld();
            CreateMazeEllersAlghoritm();

            Finish = new ExetCell(height - 2, with - 2);
            Cells[Finish.X, Finish.Y] = Finish;
            Finish.Color = Color.Green;
          

            Player = new Player(1, 1, this);
            Player.Field.Cells[Player.X, Player.Y] = Player;

            Bonus = new BonusCell(Random.Next(0, height-1), Random.Next(0, with-1));
            Cells[Bonus.X, Bonus.Y] = Bonus;

           
        }
        #endregion

        #region private metods
        private void FillFeld()
        {
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < With; j++)
                {
                    if ((i % 2 != 0 && j % 2 != 0) && (i < Height - 1 && j < With - 1))
                    {
                        FreeCell freeCell = new FreeCell(i, j);
                        Cells[i, j] = freeCell;
                    }
                    else
                    {
                        WallCell wall = new WallCell(i, j);
                        Cells[i, j] = wall;
                    }
                }
            }
            path.Push(Cells[1, 1]);
        }

        private void CreateMazeEllersAlghoritm()
        {

            while (path.Count != 0) //пока в стеке есть клетки ищем соседей и строим путь
            {
                neighbords.Clear();
                GetNeighbours(path.Peek());
                if (neighbords.Count != 0)
                {
                    Cell nextCell = ChooseNeighbour(neighbords);
                    RemoveWall(path.Peek(), nextCell);
                    nextCell.Visited = true; //делаем текущую клетку посещенной
                    Cells[nextCell.X, nextCell.Y].Visited = true; //и в общем массиве
                    path.Push(nextCell); //затем добавляем её в стек
                }
                else
                {
                    path.Pop();
                }

            }


        }

        private void RemoveWall(Cell first, Cell second)
        {
            int xDiff = second.X - first.X;
            int yDiff = second.Y - first.Y;
            int addX = (xDiff != 0) ? xDiff / Math.Abs(xDiff) : 0; // Узнаем направление удаления стены
            int addY = (yDiff != 0) ? yDiff / Math.Abs(yDiff) : 0;
            // Координаты удаленной стены
            FreeCell freeCell = new FreeCell(first.X + addX, first.Y + addY);
            Cells[first.X + addX, first.Y + addY] = freeCell; //обращаем стену в клетку
            second.Visited = true; //делаем клетку посещенной
            Cells[second.X, second.Y] = second;
        }

        private Cell ChooseNeighbour(List<Cell> neighbours)
        {
            int r = Random.Next(neighbours.Count);
            return neighbords[r];
        }

        private void GetNeighbours(Cell localcell)
        {
            int x = localcell.X;
            int y = localcell.Y;
            const int distance = 2;
            Cell[] possibleNeighbours = new[] // Список всех возможных соседeй
            {
                new FreeCell (x, y - distance),
                new FreeCell (x + distance, y),
                new FreeCell (x, y + distance),
                new FreeCell (x - distance, y),
            };

            for (int i = 0; i < 4; i++) // Проверяем все 4 направления
            {
                Cell curNeighbour = possibleNeighbours[i];
                if (curNeighbour.X > 0 && curNeighbour.X < Height && curNeighbour.Y > 0 && curNeighbour.Y < With)
                {// Если сосед не выходит за стенки лабиринта
                    if (Cells[curNeighbour.X, curNeighbour.Y] is FreeCell && !Cells[curNeighbour.X, curNeighbour.Y].Visited)
                    { // А также является клеткой и непосещен
                        neighbords.Add(curNeighbour);
                    }// добавляем соседа в Лист соседей
                }
            }
        }
        #endregion
    }
}

