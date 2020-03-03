using System.Drawing;
using System.Windows.Forms;
using Maze.Classes;

namespace Maze
{
    public partial class Form1 : Form
    {


        Player Player;
        Button[,] Buttons;


        public Form1()
        {
            InitializeComponent();
            Player = new Player();
            Buttons = new Button[Player.Field.Height, Player.Field.With];
            Render();

        }

        private void Render()

        {
            const int Size = 35;



            for (int i = 0; i < Player.Field.Height; i++)
            {
                for (int j = 0; j < Player.Field.With; j++)
                {
                    Button pB = new Button();
                    pB.Size = new Size(Size, Size);
                    pB.Left = Player.Field.Cells[i, j].X * Size;
                    pB.Top = Player.Field.Cells[i, j].Y * Size;
                    pB.Parent = tabPage1;
                    pB.Tag = Player.Field.Cells[i, j];
                    if (Player.Field.Cells[i, j].Tip == Tip.Wall)
                    {
                        pB.BackColor = Color.Black;
                    }
                    else if (Player.Field.Cells[i, j].Tip == Tip.Cell)
                    {
                        pB.BackColor = Color.White;
                    }
                    else if (Player.Field.Cells[i, j].Tip == Tip.Player)
                    {
                        pB.BackColor = Color.Red;
                    }
                    else if (Player.Field.Cells[i, j].Tip == Tip.Exit)
                    {
                        pB.BackColor = Color.Green;
                    }
                    else if (Player.Field.Cells[i, j].Tip == Tip.Dark)
                    {
                        pB.BackColor = Color.Blue;
                    }
                    Buttons[i, j] = pB;
                }

            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            Player.Direction = Direction.dw;
            if (tabControl1.SelectedIndex == 0) // проверяем какая текущая страница
            {
                switch (e.KeyCode)
                {
                    case Keys.Up://вверх
                        if (Player.Step(Direction.tp))
                        {
                            Buttons[Player.X, Player.Y].BackColor = Color.Red;
                            Buttons[Player.X, Player.Y + 1].BackColor = Color.White;
                        }
                        break;
                    case Keys.Down: //вниз
                        if (Player.Step(Direction.dw))
                        {
                            Buttons[Player.X, Player.Y].BackColor = Color.Red;
                            Buttons[Player.X, Player.Y - 1].BackColor = Color.White;
                        }
                        break;
                    case Keys.Right:  //вправо
                        if (Player.Step(Direction.rt))
                        {
                            Buttons[Player.X, Player.Y].BackColor = Color.Red;
                            Buttons[Player.X - 1, Player.Y].BackColor = Color.White;
                        }
                        break;
                    case Keys.Left:  //влево
                        if (Player.Step(Direction.lf))
                        {
                            Buttons[Player.X, Player.Y].BackColor = Color.Red;
                            Buttons[Player.X + 1, Player.Y].BackColor = Color.White;
                        }
                        break;
                    default: break;

                }
                if (Player.EndGame())
                {
                    MessageBox.Show("Конец");
                    Player.Field = new Field(43, 21);
                    Render();
                    tabPage1.Refresh();
                    this.Refresh();
                }
            }

        }


    }
}
