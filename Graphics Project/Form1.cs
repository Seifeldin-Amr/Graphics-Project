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

                            break;
                        //Circle: Increase Radius of Circle
                        case 2:

                            break;
                        //Curve: Increase Curvature Height
                        case 3:
                            //obj.SetControlPoint(new Point(100,100 ));
                            break;
                    }
                    break;
                case Keys.Down:
                    switch (currentMode)
                    {
                        //DDA: Decrease Length of Line
                        case 1:

                            break;
                        //Circle: Decrease Radius of Circle
                        case 2:

                            break;
                        //Curve: Decrease Curvature Height
                        case 3:

                            break;
                    }
                    break; 
                //Create the selected object
                case Keys.Enter:
                    switch (currentMode)
                    {
                        //Create DDA Line
                        case 1:

                            break;
                        //Create Circle
                        case 2:

                            break;
                        //Create Curve
                        case 3:

                            break;
                    }
                    break;
            }
        }

        private void Form1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            DrawDubb(e.Graphics);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            off = new Bitmap(this.ClientSize.Width, this.ClientSize.Height);
            
            
        }

        void DrawDubb(Graphics g)
        {
            
            Graphics g2 = Graphics.FromImage(off);
            DrawScene(g2);
            g.DrawImage(off, 0, 0);
            
        }
        void DrawScene(Graphics g)
        {
            g.Clear(Color.Green);
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
