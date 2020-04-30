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
    public partial class Form2 : Form
    {
        int height;
        int width;

        public Form2()
        {
            InitializeComponent();
        }

        public int ReturnHeight()
        {
            return height;
        }

        public int ReturnWidth()
        {
            return width;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            height = Convert.ToInt32(textBox1.Text);
            width = Convert.ToInt32(textBox2.Text);
            if (height > 5 && width > 5)
            {
                if (height % 2 == 0 || width % 2 == 0)
                {
                    if (height % 2 == 0)
                        height++;
                    if (width % 2 == 0)
                        width++;
                }
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Слишком маленькие значения");
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (Char.IsDigit(e.KeyChar) || e.KeyChar == 8 ) return;
            else
                e.Handled = true;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) || e.KeyChar == 8) return;
            else
                e.Handled = true;

        }
    }
}
