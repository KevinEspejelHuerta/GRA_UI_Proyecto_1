namespace FormsFractales
{
    public partial class frmFractal01 : Form
    {
        public frmFractal01()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //MandelbrotSet();
            //SierpinskiTriangle();
            //KochSnowflake();
            DrawSpirograph();
        }

        private void MandelbrotSet()
        {
            int width = ptbMandelbrot.Width;
            int heigth = ptbMandelbrot.Height;

            Bitmap bmp = new Bitmap(width, heigth);

            for (int row = 0; row < width; row++)
            {
                for (int col = 0; col < heigth; col++)
                {
                    double c_re = (col - width / 2) * 4.0 / width;
                    double c_im = (row - heigth / 2) * 4.0 / heigth;

                    int iteraciones = 0;
                    double x = 0, y = 0;

                    while (iteraciones < 1000 && ((x * x) + (y * y)) < 4.0)
                    {
                        double x_temporal = (x * x) - (y * y) + c_re;
                        y = 2 * x * y + c_im;
                        x = x_temporal;
                        iteraciones++;
                    }
                    if (iteraciones < 1000)
                    {
                        bmp.SetPixel(col, row, Color.FromArgb(iteraciones % 128, iteraciones % 50 * 5, iteraciones % 10));

                    }
                    else
                    {
                        bmp.SetPixel(col, row, Color.Black);
                    }
                }
            }
            ptbMandelbrot.Image = bmp;
        }

        private void SierpinskiTriangle()
        {
            int width = ptbMandelbrot.Width;
            int height = ptbMandelbrot.Height;
            Bitmap bmp = new Bitmap(width, height);

            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.White); // Fondo blanco
                PointF p1 = new PointF(width / 2, 0);
                PointF p2 = new PointF(0, height);
                PointF p3 = new PointF(width, height);

                DrawSierpinski(g, p1, p2, p3, 6); // Nivel de recursión
            }

            ptbMandelbrot.Image = bmp;
        }

        private void DrawSierpinski(Graphics g, PointF p1, PointF p2, PointF p3, int depth)
        {
            if (depth == 0)
            {
                PointF[] points = { p1, p2, p3 };
                g.FillPolygon(Brushes.Black, points);
            }
            else
            {
                PointF mid1 = MidPoint(p1, p2);
                PointF mid2 = MidPoint(p2, p3);
                PointF mid3 = MidPoint(p3, p1);

                DrawSierpinski(g, p1, mid1, mid3, depth - 1);
                DrawSierpinski(g, mid1, p2, mid2, depth - 1);
                DrawSierpinski(g, mid3, mid2, p3, depth - 1);
            }
        }

        private PointF MidPoint(PointF p1, PointF p2)
        {
            return new PointF((p1.X + p2.X) / 2, (p1.Y + p2.Y) / 2);
        }


        private void KochSnowflake()
        {
            int width = ptbMandelbrot.Width;
            int height = ptbMandelbrot.Height;
            Bitmap bmp = new Bitmap(width, height);

            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.White); // Fondo blanco

                // Definir los tres vértices iniciales del triángulo equilátero
                PointF p1 = new PointF(width / 4, height * 3 / 4);
                PointF p2 = new PointF(width * 3 / 4, height * 3 / 4);
                PointF p3 = new PointF(width / 2, height / 4);

                DrawKochCurve(g, p1, p2, 5); // Lado 1
                DrawKochCurve(g, p2, p3, 5); // Lado 2
                DrawKochCurve(g, p3, p1, 5); // Lado 3
            }

            ptbMandelbrot.Image = bmp;
        }

        private void DrawKochCurve(Graphics g, PointF p1, PointF p2, int depth)
        {
            if (depth == 0)
            {
                g.DrawLine(Pens.Brown, p1, p2); // Dibuja línea base
            }
            else
            {
                // Calcula los puntos intermedios
                PointF a = new PointF((2 * p1.X + p2.X) / 3, (2 * p1.Y + p2.Y) / 3);
                PointF c = new PointF((p1.X + 2 * p2.X) / 3, (p1.Y + 2 * p2.Y) / 3);

                // Rotar 60° para formar el "pico"
                double angle = Math.PI / 3;
                float bx = (float)(a.X + (c.X - a.X) * Math.Cos(angle) - (c.Y - a.Y) * Math.Sin(angle));
                float by = (float)(a.Y + (c.X - a.X) * Math.Sin(angle) + (c.Y - a.Y) * Math.Cos(angle));
                PointF b = new PointF(bx, by);

                // Llamadas recursivas
                DrawKochCurve(g, p1, a, depth - 1);
                DrawKochCurve(g, a, b, depth - 1);
                DrawKochCurve(g, b, c, depth - 1);
                DrawKochCurve(g, c, p2, depth - 1);
            }
        }


        private void DrawSpirograph()
        {
            int width = ptbMandelbrot.Width;
            int height = ptbMandelbrot.Height;
            Bitmap bmp = new Bitmap(width, height);

            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.Black); // Fondo negro

                // Dibujar múltiples patrones para mayor densidad
                DrawSpirographPattern(g, width / 2, height / 2, 140, 60, 20, 5000, 0.05);
                DrawSpirographPattern(g, width / 2, height / 2, 130, 55, 25, 5000, 0.05);
                DrawSpirographPattern(g, width / 2, height / 2, 120, 50, 30, 5000, 0.05);
            }

            ptbMandelbrot.Image = bmp;
        }

        private void DrawSpirographPattern(Graphics g, int centerX, int centerY, int R, int r, int d, int points, double step)
        {
            List<PointF> pointsList = new List<PointF>();

            for (int i = 0; i < points; i++)
            {
                double t = i * step;
                double x = (R - r) * Math.Cos(t) + d * Math.Cos((R - r) * t / r);
                double y = (R - r) * Math.Sin(t) - d * Math.Sin((R - r) * t / r);

                pointsList.Add(new PointF((float)(centerX + x), (float)(centerY + y)));
            }

            // Dibujar líneas con colores degradados
            for (int i = 1; i < pointsList.Count; i++)
            {
                Pen pen = new Pen(ColorFromGradient(i, pointsList.Count), 1);
                g.DrawLine(pen, pointsList[i - 1], pointsList[i]);
            }
        }

        private Color ColorFromGradient(int step, int maxSteps)
        {
            int r = (int)(255 * (Math.Sin(0.1 * step) * 0.5 + 0.5));
            int g = (int)(255 * (Math.Sin(0.1 * step + 2) * 0.5 + 0.5));
            int b = (int)(255 * (Math.Sin(0.1 * step + 4) * 0.5 + 0.5));
            return Color.FromArgb(r, g, b);
        }

        private void ptbMandelbrot_Click(object sender, EventArgs e)
        {

        }
    }
}
