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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            this.Width = 800;
            this.Height = 600;
            this.BackgroundImage = Image.FromFile(@"C:\Users\User\source\repos\my-mini-projects\Snake\start.jpg");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
    }
}
