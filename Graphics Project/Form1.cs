using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graphics_Project
{
    public partial class Form1 : Form
    {
        BezierCurve obj = new BezierCurve();
        float my_t_inForm = 0.01f;//Ball
        PointF carPoint;
        Bitmap off;
        Timer tt = new Timer();
        List<Circle> Circles = new List<Circle>();
        List<DDA> Lines = new List<DDA>();
        List<BezierCurve> Curves = new List<BezierCurve>();
        int currentMode = 1;
        PointF currentStart;
        int li=-1, ci=-1, bi=-1;
        int lastEnter = -1;
        public Form1()
        {
            InitializeComponent();
            this.Paint += Form1_Paint;
            this.WindowState = FormWindowState.Maximized;
            this.KeyDown += Form1_KeyDown;
            this.MouseDown += Form1_MouseDown;
            tt.Start();
            tt.Tick += Tt_Tick;
        }

        private void Tt_Tick(object sender, EventArgs e)
        {
            
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                //DDA 
                case Keys.Q:
                    currentMode = 1;
                    break;
                //Circle
                case Keys.W:
                    currentMode = 2;
                    break;
                //Curve
                case Keys.E:
                    currentMode = 3;
                    break;
                //Customization
                case Keys.Up:
                    switch (currentMode)
                    {
                        //DDA: Increase Length of Line
                        case 1:
                            if (Lines.Count > 0)
                            {
                                if (lastEnter == 1)
                                {
                                    Lines[li].Xe += 5;
                                    currentStart.X += 5;
                                }
                            }
                            break;
                        //Circle: Increase Radius of Circle
                        case 2:
                            if (Circles.Count > 0)
                            {
                                if (lastEnter == 2)
                                {
                                   
                                  

                                    Circles[ci].YC -= 5;
                                    Circles[ci].Rad += 5;
                                  
                                }
                            }
                            break;
                        //Curve: Increase Curvature Height
                        case 3:
                            if (Curves.Count > 0)
                            {
                                if (lastEnter == 3)
                                {
                                    Point p = new Point();
                                    p.X = Curves[bi].ControlPoints[2].X ;
                                    p.Y = Curves[bi].ControlPoints[2].Y - 5;
                                    Curves[bi].ControlPoints[2] = p;
                                    //Point p = new Point();
                                    //p.X = Curves[bi].ControlPoints[2].X+2;
                                    //p.Y = Curves[bi].ControlPoints[2].Y - 5;
                                    //Curves[bi].ControlPoints[2] = p;

                                    //p.X = Curves[bi].ControlPoints[1].X+1;
                                    //p.Y = Curves[bi].ControlPoints[1].Y ;
                                    //Curves[bi].ControlPoints[1] = p;

                                    //p.X = Curves[bi].ControlPoints[3].X+3;
                                    //p.Y = Curves[bi].ControlPoints[3].Y ;
                                    //Curves[bi].ControlPoints[3] = p;

                                    //p.X = Curves[bi].ControlPoints[4].X+4;
                                    //p.Y = Curves[bi].ControlPoints[4].Y;
                                    //Curves[bi].ControlPoints[4] = p;
                                    //currentStart.X += 4;


                                }
                            }
                            break;
                    }
                    break;
                case Keys.Down:
                    switch (currentMode)
                    {
                        //DDA: Decrease Length of Line
                        case 1:
                            if(Lines.Count>0)
                            {
                                if (lastEnter == 1)
                                {
                                    Lines[li].Xe -= 5;
                                    currentStart.X -= 5;
                                }
                            }
                            break;
                        //Circle: Decrease Radius of Circle
                        case 2:
                            if (Circles.Count > 0)
                            {
                                if (lastEnter == 2)
                                {
                                  

                                    Circles[ci].YC += 5;
                                    Circles[ci].Rad -= 5;
                                   
                                }
                            }
                            break;
                        //Curve: Decrease Curvature Height
                        case 3:
                            if (Curves.Count > 0)
                            {
                                if (lastEnter == 3)
                                {
                                    Point p = new Point();
                                    p.X = Curves[bi].ControlPoints[2].X;
                                    p.Y = Curves[bi].ControlPoints[2].Y+5;
                                    Curves[bi].ControlPoints[2]=p ;
                                    //Point p = new Point();
                                    //p.X = Curves[bi].ControlPoints[2].X-2;
                                    //p.Y = Curves[bi].ControlPoints[2].Y + 5;
                                    //Curves[bi].ControlPoints[2] = p;

                                    //p.X = Curves[bi].ControlPoints[1].X-1;
                                    //p.Y = Curves[bi].ControlPoints[1].Y ;
                                    //Curves[bi].ControlPoints[1] = p;

                                    //p.X = Curves[bi].ControlPoints[3].X-3;
                                    //p.Y = Curves[bi].ControlPoints[3].Y ;
                                    //Curves[bi].ControlPoints[3] = p;

                                    //p.X = Curves[bi].ControlPoints[4].X-4;
                                    //p.Y = Curves[bi].ControlPoints[4].Y;
                                    //Curves[bi].ControlPoints[4] = p;
                                    //currentStart.X -= 4;

                                }
                            }
                            break;
                    }
                    break; 
                //Create the selected object
                case Keys.Enter:
                    switch (currentMode)
                    {
                        //Create DDA Line
                        case 1:
                            DDA l1 = new DDA();
                            l1.X = currentStart.X;
                            l1.Y = currentStart.Y;
                            l1.Xe = currentStart.X + 100;
                            l1.Ye = currentStart.Y;
                            l1.calc();
                            currentStart.X += 100;
                            Lines.Add(l1);
                            li++;
                            lastEnter = 1;
                            break;
                        //Create Circle
                        case 2:
                            l1 = new DDA();
                            l1.X = currentStart.X;
                            l1.Y = currentStart.Y;
                            l1.Xe = currentStart.X + 100;
                            l1.Ye = currentStart.Y;
                            l1.calc();
                            currentStart.X += 100;
                            Lines.Add(l1);
                            Circle c1 = new Circle();
                            c1.Rad = 100;
                            c1.XC= (int)currentStart.X;
                            c1.YC = (int)currentStart.Y - c1.Rad-5; 
                            Circles.Add(c1);
                            l1 = new DDA();
                            l1.X = currentStart.X;
                            l1.Y = currentStart.Y;
                            l1.Xe = currentStart.X + 150;
                            l1.Ye = currentStart.Y;
                            l1.calc();
                            currentStart.X += 150;
                            Lines.Add(l1);
                            li += 2;
                            ci++;
                            lastEnter = 2;
                            break;
                        //Create Curve
                        case 3:
                            BezierCurve b1 = new BezierCurve();
                            b1.SetControlPoint(new Point((int)currentStart.X, (int)currentStart.Y));
                            b1.SetControlPoint(new Point((int)currentStart.X+50, (int)currentStart.Y));
                            b1.SetControlPoint(new Point((int)currentStart.X+100, (int)currentStart.Y-290));
                            b1.SetControlPoint(new Point((int)currentStart.X+150,(int)currentStart.Y));
                            b1.SetControlPoint(new Point((int)currentStart.X+200, (int)currentStart.Y ));
                            currentStart.X += 200;
                            Curves.Add(b1);
                            bi++;
                            lastEnter = 3;
                            break;
                    }
                    break;
            }
            DrawDubb(this.CreateGraphics());
        }

        private void Form1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            DrawDubb(e.Graphics);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            off = new Bitmap(this.ClientSize.Width, this.ClientSize.Height);
            currentStart.X = 100;
            currentStart.Y = 700;
            
        }

        void DrawDubb(Graphics g)
        {
            
            Graphics g2 = Graphics.FromImage(off);
            DrawScene(g2);
            g.DrawImage(off, 0, 0);
            
        }
        void DrawScene(Graphics g)
        {
            g.Clear(Color.White);
            carPoint = obj.CalcCurvePointAtTime(my_t_inForm);
            for (int i = 0; i < Curves.Count; i++)
            {
                Curves[i].DrawCurve(g);
            }
            for (int i = 0; i < Lines.Count; i++)
            {
                g.DrawLine(Pens.Black, Lines[i].X, Lines[i].Y, Lines[i].Xe, Lines[i].Ye);
            }
            for (int i = 0; i < Circles.Count; i++)
            {
                Circles[i].Drawcircle(g);
            }
        }
    }
}
