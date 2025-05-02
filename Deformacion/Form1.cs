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

        private float dx = 5f;     // Velocidad horizontal
        private float dy = 0f;     // Velocidad vertical

        private float escalaX = 1.0f;
        private float escalaY = 1.0f;

        private float deformacionTemporalX = 0;
        private float deformacionTemporalY = 0;

        private float gravedad = 0.5f;
        private float reboteFactor = -0.7f;
        private float limiteInferior;

        public Form1()
        {
            InitializeComponent();
            pictureBox1.Paint += pictureBox1_Paint;
            timer1.Tick += timer1_Tick;
            btnStart.Click += btnStart_Click;
            btnReset.Click += btnReset_Click;
            trackEscalaX.Scroll += trackEscalaX_Scroll;
            trackEscalaY.Scroll += trackEscalaY_Scroll;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            limiteInferior = pictureBox1.Height;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (!timer1.Enabled)
            {
                timer1.Start();
                btnStart.Text = "Detener";
            }
            else
            {
                timer1.Stop();
                btnStart.Text = "Iniciar";
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            posX = 50;
            posY = 50;
            dx = 5f;
            dy = 0f;
            escalaX = 1.0f;
            escalaY = 1.0f;
            deformacionTemporalX = 0;
            deformacionTemporalY = 0;

            lblAltura.Text = "Altura: 0";
            lblDistancia.Text = "Distancia: 0";

            trackEscalaX.Value = 100;
            trackEscalaY.Value = 100;
            lblEscalaX.Text = "Escala X: 1.00";
            lblEscalaY.Text = "Escala Y: 1.00";

            pictureBox1.Invalidate();
        }

        private void trackEscalaX_Scroll(object sender, EventArgs e)
        {
            escalaX = trackEscalaX.Value / 100.0f;
            lblEscalaX.Text = $"Escala X: {escalaX:F2}";
        }

        private void trackEscalaY_Scroll(object sender, EventArgs e)
        {
            escalaY = trackEscalaY.Value / 100.0f;
            lblEscalaY.Text = $"Escala Y: {escalaY:F2}";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Simular gravedad
            dy += gravedad;

            posX += dx;
            posY += dy;

            float alturaCirculo = radio * 2 * (escalaY + deformacionTemporalY);

            // Rebote en el suelo
            if (posY + alturaCirculo >= pictureBox1.Height)
            {
                posY = pictureBox1.Height - alturaCirculo;

                float fuerzaImpacto = Math.Abs(dy);

                dy *= reboteFactor;
                dx *= 0.95f; // también reduce la velocidad horizontal

                deformacionTemporalX = fuerzaImpacto * 0.05f;
                deformacionTemporalY = -fuerzaImpacto * 0.03f;

                // Si la energía es baja, detener
                if (Math.Abs(dy) < 0.5f && Math.Abs(dx) < 0.5f)
                {
                    dy = 0;
                    dx = 0;
                    timer1.Stop();
                    btnStart.Text = "Iniciar";
                }
            }

            // Rebote en bordes laterales
            float anchoCirculo = radio * 2 * (escalaX + deformacionTemporalX);
            if (posX <= 0 || posX + anchoCirculo >= pictureBox1.Width)
            {
                dx *= -1;
                posX = Math.Clamp(posX, 0, pictureBox1.Width - anchoCirculo);
            }

            // Disminuir deformación progresivamente
            deformacionTemporalX *= 0.9f;
            deformacionTemporalY *= 0.9f;

            pictureBox1.Invalidate();

            lblDistancia.Text = $"Distancia: {posX:F2}";
            lblAltura.Text = $"Altura: {posY:F2}";
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(Color.White);

            float ancho = radio * 2 * (escalaX + deformacionTemporalX);
            float alto = radio * 2 * (escalaY + deformacionTemporalY);

            g.FillEllipse(Brushes.Orange, posX, posY, ancho, alto);
        }
    }
}
