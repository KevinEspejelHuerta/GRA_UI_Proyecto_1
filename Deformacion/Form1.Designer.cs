namespace Deformacion
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            pictureBox1 = new PictureBox();
            btnStart = new Button();
            lblAltura = new Label();
            lblDistancia = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            btnReset = new Button();
            trackEscalaX = new TrackBar();
            trackEscalaY = new TrackBar();
            lblEscalaX = new Label();
            lblEscalaY = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackEscalaX).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackEscalaY).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(797, 400);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // btnStart
            // 
            btnStart.Location = new Point(15, 427);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(94, 29);
            btnStart.TabIndex = 1;
            btnStart.Text = "Iniciar";
            btnStart.UseVisualStyleBackColor = true;
            // 
            // lblAltura
            // 
            lblAltura.AutoSize = true;
            lblAltura.Location = new Point(815, 12);
            lblAltura.Name = "lblAltura";
            lblAltura.Size = new Size(68, 20);
            lblAltura.TabIndex = 2;
            lblAltura.Text = "Altura: 0 ";
            // 
            // lblDistancia
            // 
            lblDistancia.AutoSize = true;
            lblDistancia.Location = new Point(724, 446);
            lblDistancia.Name = "lblDistancia";
            lblDistancia.Size = new Size(85, 20);
            lblDistancia.TabIndex = 3;
            lblDistancia.Text = "Distancia: 0";
            // 
            // btnReset
            // 
            btnReset.Location = new Point(112, 427);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(94, 29);
            btnReset.TabIndex = 4;
            btnReset.Text = "Reiniciar";
            btnReset.UseVisualStyleBackColor = true;
            // 
            // trackEscalaX
            // 
            trackEscalaX.Location = new Point(12, 505);
            trackEscalaX.Maximum = 300;
            trackEscalaX.Minimum = 1;
            trackEscalaX.Name = "trackEscalaX";
            trackEscalaX.Size = new Size(130, 56);
            trackEscalaX.TabIndex = 5;
            trackEscalaX.Value = 100;
            // 
            // trackEscalaY
            // 
            trackEscalaY.Location = new Point(200, 505);
            trackEscalaY.Maximum = 300;
            trackEscalaY.Minimum = 1;
            trackEscalaY.Name = "trackEscalaY";
            trackEscalaY.Size = new Size(130, 56);
            trackEscalaY.TabIndex = 6;
            trackEscalaY.Value = 100;
            // 
            // lblEscalaX
            // 
            lblEscalaX.AutoSize = true;
            lblEscalaX.Location = new Point(12, 469);
            lblEscalaX.Name = "lblEscalaX";
            lblEscalaX.Size = new Size(97, 20);
            lblEscalaX.TabIndex = 7;
            lblEscalaX.Text = "Escala X: 1.00";
            // 
            // lblEscalaY
            // 
            lblEscalaY.AutoSize = true;
            lblEscalaY.Location = new Point(200, 469);
            lblEscalaY.Name = "lblEscalaY";
            lblEscalaY.Size = new Size(96, 20);
            lblEscalaY.TabIndex = 8;
            lblEscalaY.Text = "Escala Y: 1.00";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(895, 592);
            Controls.Add(lblEscalaY);
            Controls.Add(lblEscalaX);
            Controls.Add(trackEscalaY);
            Controls.Add(trackEscalaX);
            Controls.Add(btnReset);
            Controls.Add(lblDistancia);
            Controls.Add(lblAltura);
            Controls.Add(btnStart);
            Controls.Add(pictureBox1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackEscalaX).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackEscalaY).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Button btnStart;
        private Label lblAltura;
        private Label lblDistancia;
        private System.Windows.Forms.Timer timer1;
        private Button btnReset;
        private TrackBar trackEscalaX;
        private TrackBar trackEscalaY;
        private Label lblEscalaX;
        private Label lblEscalaY;
    }
}
