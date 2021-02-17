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
                    button[i, j].Size = new Size(50, 50);
                }
            }
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    //button[i, j].Location.X = 100;
                    button[i, j].Location = new Point(15+j * 50, 15+ i*50);
                    button[i, j].Click += button_Click;
                    this.Controls.Add(button[i,j]);
                }
            }

        }

        private void button_Click(object sender, EventArgs e)
        {

        }
    }
}
