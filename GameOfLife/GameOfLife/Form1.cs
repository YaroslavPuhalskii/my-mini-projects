using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameOfLife
{
    public partial class Form1 : Form
    {
        private Graphics graphics;
        private int resolution;
        private bool[,] field;
        private int rows;
        private int cols;

        public Form1()
        {
            InitializeComponent();
        }

        private void StartGame()
        {
            if (timer1.Enabled)
                return;

            numResolution.Enabled = false;
            numDensity.Enabled = false;
            resolution = (int)numResolution.Value;
            rows = pictureBox1.Height / resolution;
            cols = pictureBox1.Width / resolution;
            field = new bool[cols, rows];

            Random rnd = new Random();
            for (int x = 0; x < cols; x++)
            {
                for (int y = 0; y < rows; y++)
                {
                    field[x, y] = rnd.Next((int)numDensity.Value) == 0;
                }
            }

            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            graphics = Graphics.FromImage(pictureBox1.Image);
            timer1.Start();
        }

        private void bStart_Click(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.Black;
            StartGame();
        }

        private void StopGame()
        {
            if (!timer1.Enabled)
                return;

            timer1.Stop();
            numResolution.Enabled = true;
            numDensity.Enabled = true;
        }

        private void bStop_Click(object sender, EventArgs e)
        {
            StopGame();
        }

        private int CountNeighbours(int x, int y)
        {
            int count = 0;

            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    var col = (x + i + cols) % cols;
                    var row = (y + j + rows) % rows;

                    var isSelfCheck = col == x && row == y;
                    var hasLife = field[col, row];

                    if (hasLife && !isSelfCheck)
                        count++;
                }
            }

            return count;
        }

        private void NextGeneretion()
        {
            graphics.Clear(Color.Black);
            var newfield = new bool[cols, rows];

            for (int x = 0; x < cols; x++)
            {
                for (int y = 0; y < rows; y++)
                {
                    var neighboursCount = CountNeighbours(x, y);
                    var haslife = field[x, y];

                    if (!haslife && neighboursCount == 3)
                        newfield[x, y] = true;
                    else if (haslife && (neighboursCount < 2 || neighboursCount > 3))
                        newfield[x, y] = false;
                    else
                        newfield[x, y] = field[x, y];

                    if (field[x, y])
                        graphics.FillRectangle(Brushes.Red, x * resolution, y * resolution, resolution, resolution);

                }
            }
            field = newfield;
            pictureBox1.Refresh();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            NextGeneretion();
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (!timer1.Enabled)
                return;

            if (e.Button == MouseButtons.Left)
            {
                var x = e.Location.X / resolution;
                var y = e.Location.Y / resolution;
                var validate = ValidateMouse(x, y);
                
                if (validate)
                    field[x, y] = true;
            }

            if (e.Button == MouseButtons.Right)
            {
                var x = e.Location.X / resolution;
                var y = e.Location.Y / resolution;
                var validate = ValidateMouse(x, y);

                if (validate)
                    field[x, y] = false;
            }
        }

        private bool ValidateMouse(int x, int y)
        {
            return x >= 0 && y >= 0 && x < cols && y < rows;
        }
    }
}
