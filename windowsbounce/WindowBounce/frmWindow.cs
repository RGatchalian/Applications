using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowBounce
{
    public partial class frmWIndow : Form
    {
        private bool balldown=false;
        private int dir_y,dir_x;
        private  int speed=5;
        //UP,DOWN,LEFT,RIGHT
        public frmWIndow()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Random r = new Random();
            int left = r.Next(this.Width-ball.Width);
            int top = r.Next(this.Height-ball.Height);
            ball.Left = left;
            ball.Top = top;
            timer1.Start();
            dir_y = r.Next(2);
            dir_x = r.Next(2);
        }

        private void ball_MouseDown(object sender, MouseEventArgs e)
        {
            balldown = true;
            timer1.Stop();
        }

        private void ball_MouseUp(object sender, MouseEventArgs e)
        {
            balldown = false;
            timer1.Start();
        }

        private void ball_MouseMove(object sender, MouseEventArgs e)
        {
            if (balldown == true)
            {
                ball.Location = new Point(e.X + ball.Left, e.Y + ball.Top);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //if (dir_y == 1)
            //{
            if (ball.Top > 0 && dir_y == 1)
            {
                ball.Top -= speed;
            }
            else
            {
                dir_y = 2;
            }
            if (ball.Top < (this.Height-(ball.Height*2)) && dir_y==2)
            {
                ball.Top += speed;

            }
            else
            {
                dir_y = 1;

            }

            if (ball.Left > 0 && dir_x == 1)
            {
                ball.Left -= speed;
            }
            else
            {
                dir_x = 2;
            }
            if (ball.Left < ((this.Width) - (ball.Width*1.5)) && dir_x == 2)
            {
                ball.Left += speed;

            }
            else
            {
                dir_x = 1;

            }

            this.Refresh();
            //}
        }

    }
}
