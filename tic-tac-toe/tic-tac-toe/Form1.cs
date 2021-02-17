using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tic_tac_toe
{
    public partial class Form1 : Form
    {
        Button[,] button = new Button[3, 3];

        int Player = 1;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Width = 500;
            this.Height = 500;


            for (int i =0; i<3;i++)
            {
                for(int j =0; j<3; j++)
                {
                    button[i, j] = new Button();
                    button[i, j].Size = new Size(120, 120);
                }
            }
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    button[i, j].Location = new Point(58+j * 120, 100+ i*120);
                    button[i, j].Click += button_Click;
                    this.Controls.Add(button[i,j]);
                }
            }

        }

        private void button_Click(object sender, EventArgs e)
        {
            switch(Player)
            {
                case 1:
                    sender.GetType().GetProperty("Text").SetValue(sender, "X");
                    Player = 0;
                    break;
                case 0:
                    sender.GetType().GetProperty("Text").SetValue(sender, "O");
                    Player = 1;
                    break;
            }

            sender.GetType().GetProperty("Enabled").SetValue(sender, false);

        }
    }
}
