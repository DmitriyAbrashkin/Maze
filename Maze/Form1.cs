using Maze.Classes;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Maze
{
    public partial class Form1 : Form
    {
        Button[,] Buttons;
        Field Field;
        Form2 secondForm;
        public Form1()
        {
            InitializeComponent();
            Render();
        }

        private void Render()
        {
            secondForm = new Form2();
            secondForm.ShowDialog();
            if (secondForm.DialogResult == DialogResult.OK)
            {
                Field = new Field(secondForm.ReturnHeight(), secondForm.ReturnWidth());
            }
            else
            {
                Field = new Field(7, 7);
            }

            Buttons = new Button[Field.Height, Field.With];
            const int Size = 35;
            this.Size = new Size(Field.Height * Size + 25, Field.With * Size + 30);

            for (int i = 0; i < Field.Height; i++)
            {
                for (int j = 0; j < Field.With; j++)
                {
                    Button pB = new Button
                    {
                        Size = new Size(Size, Size),
                        Left = Field.Cells[i, j].X * Size,
                        Top = Field.Cells[i, j].Y * Size,
                        Parent = tabPage1,
                        Tag = Field.Cells[i, j]
                    };
                    Buttons[i, j] = pB;
                }
            }
            Field.Player.RenderDark();
            Dark();

        }

        private void Dark()
        {
            foreach (var item in Field.Cells)
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
                        if (Field.Player.Step(Direction.Top))
                        {
                            Field.Player.RenderDark();
                            Dark();
                            Buttons[Field.Player.X, Field.Player.Y].BackColor = Color.Red;
                            Buttons[Field.Player.X, Field.Player.Y + 1].BackColor = Color.White;
                            Field.Cells[Field.Player.X, Field.Player.Y] = new Player(Field.Player.X, Field.Player.Y, Field);
                            Field.Cells[Field.Player.X, Field.Player.Y+1] = new FreeCell(Field.Player.X, Field.Player.Y+1);
                        }
                        break;
                    case Keys.Down: //вниз
                        if (Field.Player.Step(Direction.Down))
                        {
                            Field.Player.RenderDark();
                            Dark();
                            Buttons[Field.Player.X, Field.Player.Y].BackColor = Color.Red;
                            Buttons[Field.Player.X, Field.Player.Y - 1].BackColor = Color.White;
                            Field.Cells[Field.Player.X, Field.Player.Y] = new Player(Field.Player.X, Field.Player.Y, Field);
                            Field.Cells[Field.Player.X, Field.Player.Y - 1] = new FreeCell(Field.Player.X, Field.Player.Y - 1);
                        }
                        break;
                    case Keys.Right:  //вправо
                        if (Field.Player.Step(Direction.Right))
                        {
                            Field.Player.RenderDark();
                            Dark();
                            Buttons[Field.Player.X, Field.Player.Y].BackColor = Color.Red;
                            Buttons[Field.Player.X - 1, Field.Player.Y].BackColor = Color.White;
                            Field.Cells[Field.Player.X, Field.Player.Y] = new Player(Field.Player.X, Field.Player.Y, Field);
                            Field.Cells[Field.Player.X-1, Field.Player.Y ] = new FreeCell(Field.Player.X-1, Field.Player.Y);

                        }
                        break;
                    case Keys.Left:  //влево
                        if (Field.Player.Step(Direction.Left))
                        {
                            Field.Player.RenderDark();
                            Dark();
                            Buttons[Field.Player.X, Field.Player.Y].BackColor = Color.Red;
                            Buttons[Field.Player.X + 1, Field.Player.Y].BackColor = Color.White;
                            Field.Cells[Field.Player.X, Field.Player.Y] = new Player(Field.Player.X, Field.Player.Y, Field);
                            Field.Cells[Field.Player.X + 1, Field.Player.Y] = new FreeCell(Field.Player.X + 1, Field.Player.Y);
                        }
                        break;
                    default: break;

                }

                if (Field.Player.EndGame())
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
