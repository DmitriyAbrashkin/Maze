using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                    pB.Top =  Field.Cells[i, j].Y * Size;
                    pB.Parent = tabPage1;
                    pB.Tag = Field.Cells[i, j];
                    if (Field.Cells[i, j].Tip == Tip.Wall)
                    {
                        pB.BackColor = Color.Black;
                    }
                    else
                    {
                        pB.BackColor = Color.White;
                    }
                }

            }
        }
    }
}
