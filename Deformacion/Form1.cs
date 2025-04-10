using System;
using System.Drawing;
using System.Windows.Forms;

namespace Deformacion
{
    public partial class Form1 : Form
    {
        private float posX = 50;
        private float posY = 50;
        private float radio = 30;
        private float dx = 5f;
        private float dy = 2f;

        private float escalaX = 1.0f;
        private float escalaY = 1.0f;

        public Form1()
        {
            InitializeComponent();

            pictureBox1.Paint += pictureBox1_Paint;
            timer1.Tick += timer1_Tick;
            btnStart.Click += btnStart_Click;
            btnReset.Click += btnReset_Click;
            trackEscalaX.Scroll += trackEscalaX_Scroll;
            trackEscalaY.Scroll += trackEscalaY_Scroll;

            trackEscalaX.Value = 100;
            trackEscalaY.Value = 100;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            posX += dx;
            posY += dy;

            pictureBox1.Invalidate();

            lblDistancia.Text = $"Distancia: {posX:F2}";
            lblAltura.Text = $"Altura: {posY:F2}";
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(Color.White);

            float ancho = radio * 2 * escalaX;
            float alto = radio * 2 * escalaY;

            g.FillEllipse(Brushes.Blue, posX, posY, ancho, alto);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled)
            {
                timer1.Stop();
                btnStart.Text = "Iniciar";
            }
            else
            {
                timer1.Start();
                btnStart.Text = "Pausar";
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            btnStart.Text = "Iniciar";

            posX = 50;
            posY = 50;
            trackEscalaX.Value = 100;
            trackEscalaY.Value = 100;

            escalaX = 1.0f;
            escalaY = 1.0f;

            pictureBox1.Invalidate();
            lblDistancia.Text = "Distancia: 0";
            lblAltura.Text = "Altura: 0";
        }

        private void trackEscalaX_Scroll(object sender, EventArgs e)
        {
            escalaX = trackEscalaX.Value / 100f;
            lblEscalaX.Text = $"Escala X: {escalaX:F2}";
        }

        private void trackEscalaY_Scroll(object sender, EventArgs e)
        {
            escalaY = trackEscalaY.Value / 100f;
            lblEscalaY.Text = $"Escala Y: {escalaY:F2}";
        }
    }
}
