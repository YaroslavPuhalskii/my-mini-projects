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
        private Label label;
        private int rI, rJ;
        private int dirX, dirY;
        private int _width = 700;
        private int _height = 600;
        private int _size = 40;
        private int score = 0;
        public Game()
        {
            InitializeComponent();
            this.Width = _width;
            this.Height = _height;
            dirX = 1;
            dirY = 0;
            label = new Label();
            label.Text = "Score: 0";
            label.Location = new Point(610, 10);
            this.Controls.Add(label);
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
            timer.Interval = 200;
            timer.Start();
            this.KeyDown += new KeyEventHandler(OKP);
        }


        private void GenerateFruit()
        {
            Random r = new Random();
            rI = r.Next(0, _height - _size);
            int tempI = rI % _size;
            rI -= tempI;
            rJ = r.Next(0, _height - _size);
            int tempJ = rJ % _size;
            rJ -= tempJ;
            fruit.Location = new Point(rI, rJ);
            this.Controls.Add(fruit);
        }

        private void _chekBoards()
        {
            if(snake[0].Location.X < 0)
            {
                for(int j = 1; j<= score; j++)
                {
                    this.Controls.Remove(snake[j]);
                }
                score = 0;
                label.Text = "Score: " + score;
                dirX = 1;
            }
            if (snake[0].Location.X > _height-60)
            {
                for (int j = 1; j <= score; j++)
                {
                    this.Controls.Remove(snake[j]);
                }
                score = 0;
                label.Text = "Score: " + score;
                dirX = -1;
            }
            if (snake[0].Location.Y < 0)
            {
                for (int j = 1; j <= score; j++)
                {
                    this.Controls.Remove(snake[j]);
                }
                score = 0;
                label.Text = "Score: " + score;
                dirY = 1;
            }
            if (snake[0].Location.Y > _height-60)
            {
                for (int j = 1; j <= score; j++)
                {
                    this.Controls.Remove(snake[j]);
                }
                score = 0;
                label.Text = "Score: " + score;
                dirY =  -1;
            }
        }
        private void _eatItSelf()
        {
            for(int i =1; i< score; i++)
            {
                if(snake[0].Location == snake[i].Location)
                {
                    for(int j =i; j<=score; j++)
                    {
                        this.Controls.Remove(snake[j]);                        
                    }
                    score = score - (score - i + 1);
                }
            }
        }
        private void _eatFruit()
        {
            if(snake[0].Location.X == rI && snake[0].Location.Y == rJ)
            {
                label.Text = "Score: " + ++score;
                snake[score] = new PictureBox();
                snake[score].Location = new Point(snake[score - 1].Location.X + _size * dirX,
                    snake[score - 1].Location.Y - _size * dirY);
                snake[score].Size = new Size(_size, _size);
                snake[score].BackColor = Color.Blue;
                this.Controls.Add(snake[score]);
                GenerateFruit();
            }
        }

        private void MoveSnake()
        {
            for(int i = score; i>=1;i--)
            {
                snake[i].Location = snake[i - 1].Location;
                
            }
            snake[0].Location = new Point(snake[0].Location.X + dirX * _size, snake[0].Location.Y + dirY * _size);
            _eatItSelf();
        }
        private void _update(object sender, EventArgs eventArgs)
        {
            _chekBoards();
            _eatFruit();
            MoveSnake();
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
