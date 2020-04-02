using Maze.Classes;
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
            Player.RenderDark();
            Dark();

        }

        private void Dark()
        {
            foreach (var item in Player.Field.Cells)
            {
                Buttons[item.X, item.Y].BackColor = item.Color;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (tabControl1.SelectedIndex == 0) // проверяем какая текущая страница
            {
                switch (e.KeyCode)
                {
                    case Keys.Up://вверх
                        if (Player.Step(Direction.Top))
                        {
                            Player.RenderDark();
                            Dark();
                            Buttons[Player.X, Player.Y].BackColor = Color.Red;
                            Buttons[Player.X, Player.Y + 1].BackColor = Color.White;
                        }
                        break;
                    case Keys.Down: //вниз
                        if (Player.Step(Direction.Down))
                        {
                            Player.RenderDark();
                            Dark();
                            Buttons[Player.X, Player.Y].BackColor = Color.Red;
                            Buttons[Player.X, Player.Y - 1].BackColor = Color.White;
                        }
                        break;
                    case Keys.Right:  //вправо
                        if (Player.Step(Direction.Right))
                        {
                            Player.RenderDark();
                            Dark();
                            Buttons[Player.X, Player.Y].BackColor = Color.Red;
                            Buttons[Player.X - 1, Player.Y].BackColor = Color.White;

                        }
                        break;
                    case Keys.Left:  //влево
                        if (Player.Step(Direction.Left))
                        {
                            Player.RenderDark();
                            Dark();
                            Buttons[Player.X, Player.Y].BackColor = Color.Red;
                            Buttons[Player.X + 1, Player.Y].BackColor = Color.White;
                        }
                        break;
                    default: break;

                }

                if (Player.EndGame())
                {
                    MessageBox.Show("Готовы к следующему лабиринту?)");
                    tabPage1.Controls.Clear();
                    Render();
                    tabPage1.Refresh();
                    this.Refresh();
                }
            }

        }


    }
}
