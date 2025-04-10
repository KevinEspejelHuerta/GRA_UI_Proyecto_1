namespace FormsFractales
{
    partial class frmFractal01
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
            ptbMandelbrot = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)ptbMandelbrot).BeginInit();
            SuspendLayout();
            // 
            // ptbMandelbrot
            // 
            ptbMandelbrot.Location = new Point(1, 2);
            ptbMandelbrot.Name = "ptbMandelbrot";
            ptbMandelbrot.Size = new Size(550, 550);
            ptbMandelbrot.TabIndex = 0;
            ptbMandelbrot.TabStop = false;
            ptbMandelbrot.Click += ptbMandelbrot_Click;
            // 
            // frmFractal01
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(554, 573);
            Controls.Add(ptbMandelbrot);
            Name = "frmFractal01";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Fractal01";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)ptbMandelbrot).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox ptbMandelbrot;
    }
}
