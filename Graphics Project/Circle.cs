using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Graphics_Project
{
    public class Circle
    {
        public int Rad;
        public int XC;
        public int YC;
        public float thRadian, stth = 0, enth = 0;
        public float x, y;
        public void Drawcircle(Graphics g)
        {

            for (float th = 0; th < 360; th++)
            {


                thRadian = (float)(th * Math.PI / 180);
                x = (float)(Rad * Math.Cos(thRadian) + XC);
                y = (float)(Rad * Math.Sin(thRadian) + YC);


               
                g.FillEllipse(Brushes.Black, x, y, 5, 5);
            }
            

        }
        public PointF Getnextpoint(int theta)
        {

            PointF p = new PointF();

            thRadian = (float)(theta * Math.PI / 180);

            p.X = (float)(Rad * Math.Cos(thRadian)) + XC;
            p.Y = (float)(Rad * Math.Sin(thRadian)) + YC;
            return p;
        }
    }
}
