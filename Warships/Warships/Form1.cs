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
        private const int mapSize = 11;
        public int cellSize = 30;
        public String str = "АБВГДЕЁЖЗИ";

        public int[,] myMap = new int[mapSize, mapSize];
        public int[,] enemyMap = new int[mapSize, mapSize];

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
                    if(i == 0 || j == 0)
                    {
                        button.BackColor = Color.Gray;
                        if(i == 0 && j>0)
                        {
                            button.Text = str[j-1].ToString();
                        }
                        if(j == 0 && i>0)
                        {
                            button.Text = i.ToString();
                        }
                    }
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
        }
        
    }
}
