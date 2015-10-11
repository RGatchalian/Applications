using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowBouncev2
{
    public partial class frmMain : Form
    {
        private int count = 0;
        private Timer addBallTimer = new Timer();
        private int collisioncount = 0;
        private int tickCounter = 0;
        private int barLeft=0;
        Bar _bar = new Bar();
        bool gameStart = false;
        int lives = 3;
        int gameLevel = 2;
        public frmMain()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            //this.SetStyle(ControlStyles.UserPaint, true);
            //this.WindowState = FormWindowState.Maximized;
           //CreateBricks();
            //addBallTimer.Interval = 100;
            //addBallTimer.Tick += AddBallTimer;
            //addBallTimer.Start();
        }
        private void CreateBricks()
        {
            int brickcount = 12;
            int layercount = gameLevel;
            Brick[] b = new Brick[brickcount];
            int curleft = 6;
            int curtop = 60;
            int weakcount = layercount;
            for(int y=0;y< 3; y++)
            {
                for (int x = 0; x < b.GetUpperBound(0); x++)
                {
                    b[x] = new Brick();
                    b[x].Left = curleft;
                    b[x].Top = curtop;
                    b[x].Width = this.Width / brickcount+3;
                    b[x].Height = 50;
                    b[x].BackColor = Color.Brown;
                    b[x].WeakCount = weakcount;
                    this.Controls.Add(b[x]);
                    curleft += b[x].Width + 6;
                }
                weakcount--;
                curleft = 5;
                curtop += 55;
            }

        }
        private void AddBallTimer(object sender, EventArgs e)
        {
            if (tickCounter < 10)
            {
                tickCounter++;
            }
            else
            {
                Ball b = new Ball(this);
                b.Width = 40;
                b.Height = 40;
                b.Text = ""; count.ToString();
                this.Controls.Add(b);
                Random r = new Random();
                b.LoadBall(new Point(r.Next(this.Width),r.Next(this.Height)));
                b.BallMove += BallMove;
                count++;
                tickCounter = 0;
            }
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            //Ball b = new Ball(this);
            //b.Width = 40;
            //b.Height = 40;
            //b.Text = ""; count.ToString();
            //this.Controls.Add(b);
            //b.LoadBall(new Point(e.X, e.Y));
            //b.BallMove += BallMove;
            //count++;
        }

        private void BallMove(object sender,BallEventArgs bea)
        {
            if (sender is Ball)
            {
                Ball bsender = (Ball)sender;
                if (bsender.Location.Y > _bar.Top)
                {
                    bsender.Stop();
                    this.Controls.Remove(bsender);
                    gameStart = false;
                    lives--;
                    if (lives == 0)
                    {
                        if(MessageBox.Show("Game Over. New Game?", "Window Bounce", MessageBoxButtons.YesNo)== System.Windows.Forms.DialogResult.Yes){
                            lives=3;
                            NewGame();
                        }

                    }
                    return;
                }
                foreach (var b in this.Controls)
                {
                    if (b is Ball)
                    {
                        Ball inball = (Ball)b;
                        if (bsender!= inball)
                        {
                            if (bsender.CollisionDetected(inball) && inball.CollisionDetected(bsender))
                            {
                                bsender.ChangeDirection(false);
                                break;

                            }

                        }
                    }
                    else
                    {
                        if (bsender.CollisionDetected((Control)b))
                        {
                            bsender.ChangeDirection(true);
                            if (b is Brick)
                            {
                                if (((Brick)b).WeakCount == 0)
                                {
                                    this.Controls.Remove(((Control)b));
                                    if (AreBricksGone())
                                    {
                                        //MessageBox.Show("Congratulations");
                                        gameLevel++;
                                        if (gameLevel == 6)
                                        {
                                            MessageBox.Show("Congratulations You beat the Game");
                                        }
                                        else
                                        {
                                            NewGame();
                                        }
                                    }
                                }
                                else
                                {
                                    ((Brick)b).Hit();
                                }

                            }
                            break;

                        }
                    }
                }

            }
        }
        private bool AreBricksGone()
        {
            foreach (var c in this.Controls)
            {
                if (c is Brick)
                {
                    return false;
                }
            }
            return false;
        }
        private void AddController()
        {
            _bar.Width = 200;
            _bar.Height = 30;
            barLeft = this.Width / 2;

            _bar.Location = new Point(barLeft, this.Height - _bar.Height * 3);
            //b.Top = this.Height - b.Height;
            this.Controls.Add(_bar);
        }
        void AddBall()
        {
            Ball b = new Ball(this);
            b.Width = 40;
            b.Height = 40;
            b.Text = ""; count.ToString();
            this.Controls.Add(b);
            b.LoadBall(new Point((_bar.Location.X + _bar.Width / 2), _bar.Location.Y -_bar.Height-10));
            b.BallMove += BallMove;
            count++;
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Space:
                    if (gameStart == false)
                    {
                        gameStart = true;
                        AddBall();
                    }
                    break;
                //case Keys.Down:
                //    MessageBox.Show("Down");
                //    break;
                case Keys.Left:
                    
                    //barLeft-=20;
                    if (_bar.Location.X >0 )
                    {
                        _bar.Location = new Point(_bar.Location.X-30, this.Height - _bar.Height * 3);
                    }

                    break;
                case Keys.Right:
                    if (_bar.Location.X < (this.Width - _bar.Width))
                    {
                        _bar.Location = new Point(_bar.Location.X+30, this.Height - _bar.Height * 3);
                    }
                    
                    break;            
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void frmMain_Resize(object sender, EventArgs e)
        {
            NewGame();  
        }
        void NewGame()
        {
            this.Controls.Clear();
            CreateBricks();
            AddController();
        }

    }
}
