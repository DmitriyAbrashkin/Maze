using Maze.Classes;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Maze
{
    public partial class Form1 : Form
    {
        Player Player;
        Button[,] Buttons;

        public Form1()
        {
            InitializeComponent();
            Render();
        }

        private void Render()
        {
            Player = new Player(1, 1);
            Player.Field.Cells[1, 1] = Player;
            Buttons = new Button[Player.Field.Height, Player.Field.With];

            const int Size = 35;

            for (int i = 0; i < Player.Field.Height; i++)
            {
                for (int j = 0; j < Player.Field.With; j++)
                {
                    Button pB = new Button
                    {
                        Size = new Size(Size, Size),
                        Left = Player.Field.Cells[i, j].X * Size,
                        Top = Player.Field.Cells[i, j].Y * Size,
                        Parent = tabPage1,
                        Tag = Player.Field.Cells[i, j]
                    };
                    if (Player.Field.Cells[i, j] is WallCell)
                        pB.BackColor = Color.Black;
                    else if (Player.Field.Cells[i, j] is FreeCell)
                        pB.BackColor = Color.White;
                    else if (Player.Field.Cells[i, j] is Player)
                        pB.BackColor = Color.Red;
                    else if (Player.Field.Cells[i, j] is ExetCell)
                        pB.BackColor = Color.Green;

                    Buttons[i, j] = pB;
                }
            }
            RenderDark();

        }


        private List<Cell> GetCellAroundPlayer(int x, int y)
        {
            List<Cell> cells = new List<Cell>();
            for (int i = -2; i < 3; i++)
            {
                for (int j = -2; j < 3; j++)
                {
                    Cell cell = new Cell(x + i, y + j);
                    cells.Add(cell);
                }
            }
            return cells;
        }


        private void RenderDark()
        {
            List<Cell> cells = GetCellAroundPlayer(Player.X, Player.Y);

            foreach (var item in Player.Field.Cells)
            {
                if (!(item is ExetCell) && !(item is Player))
                {
                    Buttons[item.X, item.Y].BackColor = Color.Black;
                }

            }

            foreach (var item in cells)
            {
                if (item.X + 1 < Player.Field.Height && item.Y + 1 < Player.Field.With && item.X - 1 >= 0 && item.Y - 1 >= 0)
                {
                    if (Player.Field.Cells[item.X, item.Y] is FreeCell)
                    {
                        Buttons[item.X, item.Y].BackColor = Color.White;
                    }
                    else if (Player.Field.Cells[item.X, item.Y] is ExetCell)
                    {
                        Buttons[item.X, item.Y].BackColor = Color.Green;
                    }
                    else if (Player.Field.Cells[item.X, item.Y] is WallCell)
                    {
                        Buttons[item.X, item.Y].BackColor = Color.Gray;
                    }
                }

            }


        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (tabControl1.SelectedIndex == 0) // проверяем какая текущая страница
            {
                switch (e.KeyCode)
                {
                    case Keys.Up://вверх
                        if (Player.Step(Direction.tp))
                        {
                            RenderDark();
                            Buttons[Player.X, Player.Y].BackColor = Color.Red;
                            Buttons[Player.X, Player.Y + 1].BackColor = Color.White;
                        }
                        break;
                    case Keys.Down: //вниз
                        if (Player.Step(Direction.dw))
                        {
                            RenderDark();
                            Buttons[Player.X, Player.Y].BackColor = Color.Red;
                            Buttons[Player.X, Player.Y - 1].BackColor = Color.White;
                        }
                        break;
                    case Keys.Right:  //вправо
                        if (Player.Step(Direction.rt))
                        {
                            RenderDark();
                            Buttons[Player.X, Player.Y].BackColor = Color.Red;
                            Buttons[Player.X - 1, Player.Y].BackColor = Color.White;

                        }
                        break;
                    case Keys.Left:  //влево
                        if (Player.Step(Direction.lf))
                        {
                            RenderDark();
                            Buttons[Player.X, Player.Y].BackColor = Color.Red;
                            Buttons[Player.X + 1, Player.Y].BackColor = Color.White;

                        }
                        break;
                    default: break;

                }



                if (Player.EndGame())
                {
                    MessageBox.Show("Конец");
                    tabPage1.Controls.Clear();
                    Render();
                    tabPage1.Refresh();
                    this.Refresh();
                }
            }

        }


    }
}
