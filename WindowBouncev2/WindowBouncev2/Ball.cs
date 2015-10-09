using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
namespace WindowBouncev2
{
    public delegate void MoveEventHandler(object sender,BallEventArgs bea);
    public class Ball: Control
    {
        public event MoveEventHandler BallMove;
        protected virtual void OnMove(BallEventArgs e)
        {
            if (BallMove != null)
            {
                BallMove(this,e);
            }
        } 
        private Timer Timer;
        private int dir_y = 0;
        private int dir_x = 0;
        public int Speed = 5;
        public string Text { get; set; }
        public bool RandomSpeed { get; set; }
        public Control Container { get; set; }
        public Color BallColor { get; set; }
        public bool RandomColor { get; set; }
        public Ball(Control c)
        {
            this.Container = c;
//            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

        }

        public void LoadBall()
        {
            SetStyle(ControlStyles.UserPaint, true);
            if (this.Container != null)
            {
                LoadBall(this.Container);
            }
        }
        public void LoadBall(Point p)
        {
            this.Location = p;
            if (this.Container != null)
            {
                LoadBall(this.Container);
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
           // e.Graphics.Clear(Container.BackColor);
            Graphics g = e.Graphics;
            int offset = 2;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            //g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.FillEllipse(new SolidBrush(this.BallColor), new Rectangle(0, 0, this.Width, this.Height - offset));

            g.DrawString(this.Text, new Font("Arial", 10f, FontStyle.Bold), new SolidBrush(Color.Black), this.Width/5, this.Height / 5);
           // g.DrawEllipse(new Pen(Color.Black,1f), new Rectangle(0, 0, this.Width- offset, this.Height - offset));
           // this.Update();

            //e.Graphics.DrawRectangle(new Pen(Color.Black, 5f), new Rectangle(this.Location.X, this.Location.Y, this.Width, this.Height));
            base.OnPaint(e);

        }
        public void LoadBall(Control c)
        {
            this.Timer = new Timer();
            this.Timer.Interval = 10;
            this.BallColor = (this.RandomColor == true ? GetRandomColor() : Color.Blue); ;
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            //this.SetStyle(ControlStyles.UserPaint, true);
            this.BackColor = Color.Transparent;
            //this.BackColor = System.Drawing.Color.Red;
            Random r = new Random();
            int left = r.Next(Container.Width - this.Width);
            int top = r.Next(Container.Height - this.Height);
//            this.Location = new Point(0, 0);
            //this.Left = left;
            //this.Top = top;
            this.Timer.Tick += Timer_Tick;
            if (this.RandomSpeed == true)
            {
                Speed = r.Next(5, 10);
            }
            dir_y = r.Next(2);
            dir_x = r.Next(2);
           this.Timer.Start();

        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            GetDirection();
            OnMove(new BallEventArgs(this.Location.X, this.Location.Y, this.Text));
            //this.Invalidate(new Rectangle(this.Location.X,this.Location.Y,this.Width,this.Height));
            //this.Refresh();
            //this.Invalidate();
        }
        private void GetDirection()
        {
            if (this.Top > 0 && dir_y == 0)
            {
                this.Top -= Speed;
            }
            else
            {
                dir_y = 1;
            }
            if (this.Top < (Container.Height - (this.Height * 2)) && dir_y == 1)
            {
                this.Top += Speed;

            }
            else
            {
                dir_y = 0;

            }

            if (this.Left > 0 && dir_x == 0)
            {
                this.Left -= Speed;
            }
            else
            {
                dir_x = 1;
            }
            if (this.Left < ((Container.Width) - (this.Width * 2)) && dir_x == 1)
            {
                this.Left += Speed;

            }
            else
            {
                dir_x = 0;

            }

        }
        Color GetRandomColor()
        {
            Random randomGen = new Random();
            KnownColor[] names = (KnownColor[])Enum.GetValues(typeof(KnownColor));
            KnownColor randomColorName = names[randomGen.Next(names.Length)];
            Color randomColor = Color.FromKnownColor(randomColorName);
            return randomColor;
        }
        public bool CollisionDetected(Control c)
        {
            int b1_x = this.Location.X;
            int b1_y = this.Location.Y;
            int b1_w = this.Width;
            int b1_h = this.Height;
            Rectangle b1_rec = new Rectangle(b1_x, b1_y, b1_w, b1_h);

            int b2_x = c.Location.X;
            int b2_y = c.Location.Y;
            int b2_w = c.Width;
            int b2_h = c.Height;
            Rectangle b2_rec = new Rectangle(b2_x, b2_y, b2_w, b2_h);

            if (b1_rec.IntersectsWith(b2_rec))
            {
                return true;
            }
            return false;
        }
        public void Stop()
        {
            this.Timer.Stop();
        }
        public void ChangeDirection(bool bar)
        {
            if (bar == false)
            {
                dir_y = (dir_y == 0 ? 1 : 0);
                dir_x = (dir_x == 0 ? 1 : 0);
            }
            else
            {
                dir_y = (dir_y == 0 ? 1 : 0);
            }
        }

    }

    public class BallEventArgs : EventArgs
    {
        public Point Point { get; set; }
        public string Text { get; set; }
        public BallEventArgs(int x, int y,string text)
        {
            this.Point = new Point(x, y);
            this.Text = text;
        }
    }

}
