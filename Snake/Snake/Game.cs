using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    public partial class Game : Form
    {
        PictureBox fruit;
        PictureBox[] snake = new PictureBox[500];
        private int rI, rJ;
        private int dirX, dirY;
        private int _width = 700;
        private int _height = 600;
        private int _size = 40;
        public Game()
        {
            InitializeComponent();
            this.Width = _width;
            this.Height = _height;
            dirX = 1;
            dirY = 0;
            fruit = new PictureBox();
            fruit.BackColor = Color.Green;
            fruit.Size = new Size(_size, _size);
            snake[0] = new PictureBox();
            snake[0].Location = new Point(200, 200);
            snake[0].Size = new Size(_size, _size);
            snake[0].BackColor = Color.Blue;
            this.Controls.Add(snake[0]);
            CreateMap();
            GenerateFruit();
            timer.Tick += new EventHandler(_update);
            timer.Interval = 400;
            timer.Start();
            this.KeyDown += new KeyEventHandler(OKP);
        }


        private void GenerateFruit()
        {
            Random r = new Random();
            rI = r.Next(0, _width - _size);
            int tempI = rI % _size;
            rI -= tempI;
            rJ = r.Next(0, _height - _size);
            int tempJ = rJ % _size;
            rJ -= tempJ;
            fruit.Location = new Point(rI, rJ);
            this.Controls.Add(fruit);
        }
        private void _update(object sender, EventArgs eventArgs)
        {
            cube.Location = new Point(cube.Location.X + dirX * _size, cube.Location.Y + dirY * _size);
        }
        private void CreateMap()
        {
            for(int i =0;i <= _width/_size; i++)
            {
                PictureBox pic = new PictureBox();
                pic.BackColor = Color.Black;
                pic.Location = new Point(0,_size*i);
                pic.Size = new Size(_width-100 , 1);
                this.Controls.Add(pic);

            }
            for (int i = 0; i<= _height/_size; i++)
            {
                PictureBox pic = new PictureBox();
                pic.BackColor = Color.Black;
                pic.Location = new Point(_size*i,0);
                pic.Size = new Size(1, _width);
                this.Controls.Add(pic);
            }
        }

        private void OKP(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode.ToString())
            {
                case "Right":
                    dirX = 1;
                    dirY = 0;
                    break;
                case "Left":
                    dirX = -1;
                    dirY = 0;
                    break;
                case "Up":
                    dirX = 0;
                    dirY = -1;
                    break;
                case "Down":
                    dirX = 0;
                    dirY = 1;
                    break;
            }
        }



    }
}
