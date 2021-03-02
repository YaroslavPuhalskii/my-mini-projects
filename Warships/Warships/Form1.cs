using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Warships
{
    public partial class Form1 : Form
    {
        public const int mapSize = 10;
        public int cellSize = 30;
        public String str = "АБВГДЕЁЖЗИ";

        bool isPlaying = false;

        public int[,] myMap = new int[mapSize, mapSize];
        public int[,] enemyMap = new int[mapSize, mapSize];

        public Button[,] myButtons = new Button[mapSize, mapSize];
        public Button[,] enemyButtons = new Button[mapSize, mapSize];

        public Bot bot;
 
        public Form1()
        {
            InitializeComponent();
            this.Height = 400;
            this.Width = 700;
            this.Text = "Морской бой";
            Init();
        }
        public void Init()
        {            
            MapCreate();
            bot = new Bot(enemyMap, myMap, enemyButtons, myButtons);
            enemyMap = bot.ConfigureShips();

        }

        private void MapCreate()
        {
            for(int i =0; i<mapSize;i++)
            {
                for(int j =0; j< mapSize; j++)
                {
                    myMap[i, j] = 0;
                    Button button = new Button();
                    button.Location = new Point(j * cellSize, i * cellSize);
                    button.Size = new Size(cellSize, cellSize);
                    button.BackColor = Color.White;
                    if (i == 0 || j == 0)
                    {
                        button.BackColor = Color.Gray;
                        if (i == 0 && j > 0)
                        {
                            button.Text = str[j - 1].ToString();
                        }
                        if (j == 0 && i > 0)
                        {
                            button.Text = i.ToString();
                        }
                    }
                    else { button.Click += new EventHandler(ConfigureShips); }
                    myButtons[i, j] = button;
                    this.Controls.Add(button);
                }
            }
            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    enemyMap[i, j] = 0;
                    Button button = new Button();
                    button.Location = new Point(j * cellSize +350, i * cellSize);
                    button.Size = new Size(cellSize, cellSize);
                    button.BackColor = Color.White;
                    if (i == 0 || j == 0)
                    {
                        button.BackColor = Color.Gray;
                        if (i == 0 && j > 0)
                        {
                            button.Text = str[j - 1].ToString();
                        }
                        if (j == 0 && i > 0)
                        {
                            button.Text = i.ToString();
                        }
                    }
                    else
                    {
                        button.Click += new EventHandler(PlayerShoot);
                    }
                    myButtons[i, j] = button;
                    this.Controls.Add(button);
                }
            }
            Label map1 = new Label();
            map1.Text = "Карта игрока";
            map1.Location = new Point((mapSize * cellSize / 2)-40,mapSize*cellSize+10);
            this.Controls.Add(map1);
            Label map2 = new Label();
            map2.Text = "Карта противника";
            map2.Location = new Point(mapSize * cellSize+150, mapSize * cellSize + 10);
            this.Controls.Add(map2);

            Button startButton = new Button();
            startButton.Text = "Начать";
            startButton.Location = new Point(302, cellSize* mapSize+5);
            startButton.Click += new EventHandler(Start);
            this.Controls.Add(startButton);
        }
        
        private void Start(object sender,EventArgs e)
        {
            isPlaying = true;
        }

        private void ConfigureShips(object sender, EventArgs e)
        {
            Button pressedButton = sender as Button;
            if(!isPlaying)
            {
                if (myMap[pressedButton.Location.Y / cellSize, pressedButton.Location.X / cellSize] == 0)
                {
                    pressedButton.BackColor = Color.Red;
                    myMap[pressedButton.Location.Y / cellSize, pressedButton.Location.X / cellSize] = 1;
                }
                else 
                {
                    pressedButton.BackColor = Color.White;
                    myMap[pressedButton.Location.Y / cellSize, pressedButton.Location.X / cellSize] = 0;
                }
            }
        }

        private void PlayerShoot(object sender, EventArgs e)
        {
            Button pressedButton = sender as Button;
            bool playerTurn = Shoot(enemyMap, pressedButton);
            if (!playerTurn)
            { bot.Shoot(); }

            if (!CheckIfMapIsNotEmpty())
            {
                this.Controls.Clear();
                Init();
            }
        }

        public bool CheckIfMapIsNotEmpty()
        {
            bool isEmpty1 = true;
            bool isEmpty2 = true;
            for (int i = 1; i < mapSize; i++)
            {
                for (int j = 1; j < mapSize; j++)
                {
                    if (myMap[i, j] != 0)
                        isEmpty1 = false;
                    if (enemyMap[i, j] != 0)
                        isEmpty2 = false;
                }
            }
            if (isEmpty1 || isEmpty2)
                return false;
            else return true;
        }

        private bool Shoot(int[,] map, Button pressedButton)
        {
            bool hit = false;
            if(isPlaying)
            {
                int delta = 0;
                if(pressedButton.Location.X >350)
                { delta = 350; }
                if (map[pressedButton.Location.Y / cellSize, (pressedButton.Location.X - delta)/ cellSize] != 0)
                {
                    hit = true;

                    pressedButton.BackColor = Color.Blue;
                    pressedButton.Text = "X";
                }
                else
                {
                    hit = false;
                    pressedButton.BackColor = Color.Black;
                }
            }
           
            return hit;
        }
    }
}
