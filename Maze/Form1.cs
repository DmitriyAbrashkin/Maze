using System;
using System.Drawing;
using System.Windows.Forms;

namespace Maze
{
    public partial class Form1 : Form
    {
        Field Field = new Field(31, 31);
        public Form1()
        {
            InitializeComponent();
            Render();
        }

        private void Render()
        {

            const int Size = 15;

            for (int i = 0; i < Field.Height; i++)
            {
                for (int j = 0; j < Field.With; j++)
                {
                    Button pB = new Button();
                    pB.Size = new Size(Size, Size);
                    pB.Left = Field.Cells[i, j].X * Size;
                    pB.Top = Field.Cells[i, j].Y * Size;
                    pB.Parent = tabPage1;
                    pB.Tag = Field.Cells[i, j];
                    pB.TabStop = false;
                    if (Field.Cells[i, j].Tip == Tip.Wall)
                    {
                        pB.BackColor = Color.Black;
                    }
                    else if (Field.Cells[i, j].Tip == Tip.Wall)
                    {
                        pB.BackColor = Color.White;
                    }
                    else if (Field.Cells[i, j].Tip == Tip.Player)
                    {
                        pB.BackColor = Color.Red;
                    }
                }

            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //Button btn = (sender as Button);
            //object pO = btn.Tag;
            //Cell pF = pO as Cell;

            switch (e.KeyCode)
            {
                case Keys.Up://вверх
                    Field.Player.Step(Classes.Direction.tp);
                    Render();
                    break;
                case Keys.Down: //вниз
                    Field.Player.Step(Classes.Direction.dw);
                    Render();
                    break;
                case Keys.Right:  //вправо
                    Field.Player.Step(Classes.Direction.rt);
                    Render();
                    break;
                case Keys.Left:  //влево
                    Field.Player.Step(Classes.Direction.lf);
                    Render();
                    break;
                default: break;

            }
        }


    }
}
