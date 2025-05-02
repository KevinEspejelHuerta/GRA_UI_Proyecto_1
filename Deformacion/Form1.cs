using System;
using System.Drawing;
using System.Windows.Forms;

namespace Deformacion
{
    public partial class Form1 : Form
    {
        private float posX;
        private float posY;
        private float radio = 10;
        private float dx;
        private float dy;

        // Escala dentro del picture Box
        private float escala = 25f; 
        private float gravedad = 9.8f * 0.1f; // simulación con pasos de 0.1s
        private float reboteFactor = -0.7f;

        private float deformacionX = 0;
        private float deformacionY = 0;

        private float tiempo = 0;

        public Form1()
        {
            InitializeComponent();
            pictureBox1.Paint += pictureBox1_Paint;
            timer1.Interval = 100; // 0.1 segundos
            timer1.Tick += timer1_Tick;

            btnStart.Click += btnStart_Click;
            btnReset.Click += btnReset_Click;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            // Configurar condiciones iniciales
            float alturaInicial = (float)numAltura.Value;
            float velocidadInicial = (float)numVelocidad.Value;

            posX = 0;
            posY = pictureBox1.Height - alturaInicial * escala - radio * 2;

            dx = velocidadInicial * 0.1f * escala; // convertir a px/intervalo
            dy = 0;

            deformacionX = 0;
            deformacionY = 0;
            tiempo = 0;

            timer1.Start();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            posX = 0;
            posY = 0;
            dx = 0;
            dy = 0;
            lblAltura.Text = "Altura: 0 m";
            lblDistancia.Text = "Distancia: 0 m";
            pictureBox1.Invalidate();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            tiempo += 0.1f;

            // Aplicar gravedad
            dy += gravedad;

            // Actualizar posición
            posX += dx;
            posY += dy;

            float limiteInferior = pictureBox1.Height - radio * 2;

            // Rebote
            if (posY >= limiteInferior)
            {
                posY = limiteInferior;
                dy *= reboteFactor;
                dx *= 0.95f;

                float fuerza = Math.Abs(dy);
                deformacionX = fuerza * 0.2f;
                deformacionY = -fuerza * 0.1f;

                if (Math.Abs(dy) < 1f && Math.Abs(dx) < 1f)
                {
                    dy = 0;
                    dx = 0;
                    timer1.Stop();
                }
            }

            // Reducir deformación
            deformacionX *= 0.9f;
            deformacionY *= 0.9f;

            // Mostrar resultados
            float alturaReal = (pictureBox1.Height - posY - radio * 2) / escala;
            float distanciaReal = posX / escala;
            lblAltura.Text = $"Altura: {alturaReal:F2} m";
            lblDistancia.Text = $"Distancia: {distanciaReal:F2} m";

            pictureBox1.Invalidate();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(Color.White);

            // Dibujar ejes
            using (Pen ejePen = new Pen(Color.Gray, 1))
            {
                // eje Y
                g.DrawLine(ejePen, 20, 0, 20, pictureBox1.Height);
                for (int i = 0; i <= pictureBox1.Height / escala; i++)
                {
                    int y = pictureBox1.Height - (int)(i * escala);
                    g.DrawLine(Pens.LightGray, 15, y, pictureBox1.Width, y);
                    g.DrawString(i.ToString() + "", DefaultFont, Brushes.Black, 0, y - 10);
                }

                // eje X
                g.DrawLine(ejePen, 0, pictureBox1.Height - 1, pictureBox1.Width, pictureBox1.Height - 1);
                for (int i = 0; i <= pictureBox1.Width / escala; i++)
                {
                    int x = (int)(i * escala);
                    g.DrawLine(Pens.LightGray, x, pictureBox1.Height - 5, x, 0);
                    g.DrawString(i.ToString() + " ", DefaultFont, Brushes.Black, x, pictureBox1.Height - 20);
                }
            }

            // Dibujar pelota
            float ancho = radio * 2 * (1 + deformacionX);
            float alto = radio * 2 * (1 + deformacionY);

            g.FillEllipse(Brushes.Orange, posX, posY, ancho, alto);
        }
    }
}
