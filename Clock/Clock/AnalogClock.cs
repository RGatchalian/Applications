using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
namespace Clock
{
    public class AnalogClock:Control
    {
        float centerX;
        float centerY;
        float radius;
        const float PI = (float) Math.PI;

        DateTime dateTime = new DateTime();

        Timer timer = new Timer();
        int seconds = 0;
        int minutes = 0;
        int hours = 0;
        public AnalogClock()
        {
            //Init Datetime

            dateTime = DateTime.Now;
            seconds = dateTime.TimeOfDay.Seconds;
            minutes = dateTime.TimeOfDay.Minutes;
            hours = dateTime.TimeOfDay.Hours;

            //init timers
            timer.Interval = 1000;
            timer.Start();
            timer.Tick += SecondsTick;
            timer.Start();
        }

        private void SecondsTick(object sender, EventArgs e)
        {
            this.dateTime = DateTime.Now;
            this.Refresh();
        }
        private void DrawLine(float fThickness, float fLength, Color color, float fRadians, System.Windows.Forms.PaintEventArgs e)
        {
            e.Graphics.DrawLine(new Pen(color, fThickness),
                centerX - (float)(fLength / 9 * System.Math.Sin(fRadians)),
                centerY + (float)(fLength / 9 * System.Math.Cos(fRadians)),
                centerX + (float)(fLength * System.Math.Sin(fRadians)),
                centerY - (float)(fLength * System.Math.Cos(fRadians)));
        }
       
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode=System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            //Digital
            g.DrawString(dateTime.Hour.ToString("D2") + ":" + dateTime.Minute.ToString("D2") + ":" + dateTime.Second.ToString("D2"), new Font("Arial", 12f),new SolidBrush(Color.Black), 10f, 10f);


            centerX = this.Width / 2;
            centerY = this.Height / 2;
            radius = this.Height/2;

            //g.FillEllipse(new SolidBrush(Color.Black), centerX, centerY, 1, 1);

            float fRadHr = (dateTime.Hour % 12 + dateTime.Minute / 60F) * (360/12) * PI / 180;
            float fRadMin = (dateTime.Minute) * (360 / 60) * PI / 180;
            float fRadSec = (dateTime.Second) * (360 / 60) * PI / 180;

            DrawLine(3.0F, (float)this.Height / 2.8F / 1.65F, Color.Blue, fRadHr, e);
            DrawLine(3.0F, (float)this.Height / 2.8F / 1.20F, Color.Red, fRadMin, e);
            DrawLine(1.0F, (float)this.Height / 2.8F / 1.15F, Color.Black, fRadSec, e);

            for (int i = 0; i < 60; i++)
            {

                if (i % 5 == 0)
                {
                    float x1 = centerX + (float)(radius / 1.5F * System.Math.Sin(i * 6 * PI / 180));
                    float y1= centerY - (float)(radius / 1.5F * System.Math.Cos(i * 6 * PI / 180));
                    float x2 = centerX + (float)(radius / 1.65F * System.Math.Sin(i * 6 * PI / 180));
                    float y2 = centerY - (float)(radius / 1.65F * System.Math.Cos(i * 6 * PI / 180));
                    e.Graphics.DrawLine(new Pen(Color.Black, 2f),
                            x1,
                            y1,
                            x2,
                            y2);
                }
                else
                {

                    e.Graphics.DrawLine(new Pen(Color.Black, 1f),
                            centerX + (float)(radius / 1.50F * System.Math.Sin(i * 6 * PI / 180)),
                            centerY - (float)(radius / 1.50F * System.Math.Cos(i * 6 * PI / 180)),
                            centerX + (float)(radius / 1.55F * System.Math.Sin(i * 6 * PI / 180)),
                            centerY - (float)(radius / 1.55F * System.Math.Cos(i * 6 * PI / 180)));
                }
            }
        }

    }
}
