using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CheckInBD
{
    public partial class Authorization : Form
    {
        public Authorization()
        {
            InitializeComponent();

            this.loginButton.AutoSize = false;
            this.loginButton.Size = new Size(this.loginButton.Size.Width, 64);
            this.passwordButton.AutoSize = false;
            this.passwordButton.Size = new Size(this.passwordButton.Size.Width, 64);
        }

        private void X_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void X_MouseEnter(object sender, EventArgs e)
        {
            X.ForeColor = Color.Red;
        }

        private void X_MouseLeave(object sender, EventArgs e)
        {
            X.ForeColor = Color.White;
        }

        Point lastPoint;
        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string loginUser = loginButton.Text;
            string passwordUser = passwordButton.Text;

            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `login` = @UL AND `pass` = @uP", db.getConnection());
            command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = loginUser;
            command.Parameters.Add("@uP", MySqlDbType.VarChar).Value = passwordUser;

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                MessageBox.Show("YES");
            }
            else
            {
                MessageBox.Show("NO");
            }



        }
    }
}
