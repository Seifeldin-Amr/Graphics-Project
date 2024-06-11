using System;

namespace Graphics_Project
{
    public class DDA
    {
        public float X, Y, Xe, Ye;
        float dy, dx, m;
        public float cx, cy;
        public int speed = 10;
        public void calc()
        {
            dy = Ye - Y;
            dx = Xe - X;
            m = dy / dx;
            cx = X;
            cy = Y;
        }
        public bool CalcNextPoint()
        {
            if (Math.Abs(dx) > Math.Abs(dy))
            {
                if (X < Xe)
                {
                    cx += speed;
                    cy += m * speed;
                    if (cx >= Xe)
                    {
                        return false;
                    }

                }
                
            }
           
            return true;
        }

    }
}
