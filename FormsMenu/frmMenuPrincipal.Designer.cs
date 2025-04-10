namespace FormsMenu
{
    partial class frmMenuPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            Menu1 = new Button();
            Fractales = new Button();
            Graficos = new Button();
            Matrices = new Button();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Yu Gothic", 25.8000011F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(12, 76);
            label1.Name = "label1";
            label1.Size = new Size(416, 56);
            label1.TabIndex = 0;
            label1.Text = "MENU PRINCIPAL";
            // 
            // Menu1
            // 
            Menu1.BackColor = Color.Transparent;
            Menu1.FlatAppearance.BorderSize = 0;
            Menu1.FlatStyle = FlatStyle.System;
            Menu1.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Menu1.Location = new Point(47, 241);
            Menu1.Name = "Menu1";
            Menu1.Size = new Size(347, 48);
            Menu1.TabIndex = 1;
            Menu1.Text = "Aceptar";
            Menu1.UseVisualStyleBackColor = false;
            // 
            // Fractales
            // 
            Fractales.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Fractales.Location = new Point(47, 588);
            Fractales.Name = "Fractales";
            Fractales.Size = new Size(351, 50);
            Fractales.TabIndex = 2;
            Fractales.Text = "Aceptar";
            Fractales.UseVisualStyleBackColor = true;
            // 
            // Graficos
            // 
            Graficos.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Graficos.Location = new Point(47, 348);
            Graficos.Name = "Graficos";
            Graficos.Size = new Size(347, 57);
            Graficos.TabIndex = 3;
            Graficos.Text = "Aceptar";
            Graficos.UseVisualStyleBackColor = true;
            // 
            // Matrices
            // 
            Matrices.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Matrices.Location = new Point(47, 469);
            Matrices.Name = "Matrices";
            Matrices.Size = new Size(347, 59);
            Matrices.TabIndex = 4;
            Matrices.Text = "Aceptar";
            Matrices.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Yu Gothic", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(47, 202);
            label2.Name = "label2";
            label2.Size = new Size(125, 36);
            label2.TabIndex = 5;
            label2.Text = "Menu 1:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Yu Gothic", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(47, 309);
            label3.Name = "label3";
            label3.Size = new Size(146, 36);
            label3.TabIndex = 6;
            label3.Text = "Graficos: ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Yu Gothic", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.White;
            label4.Location = new Point(47, 430);
            label4.Name = "label4";
            label4.Size = new Size(143, 36);
            label4.TabIndex = 7;
            label4.Text = "Matrices:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Yu Gothic", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.White;
            label5.Location = new Point(47, 549);
            label5.Name = "label5";
            label5.Size = new Size(149, 36);
            label5.TabIndex = 8;
            label5.Text = "Fractales:";
            // 
            // frmMenuPrincipal
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.fon_aplica;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(438, 706);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(Matrices);
            Controls.Add(Graficos);
            Controls.Add(Fractales);
            Controls.Add(Menu1);
            Controls.Add(label1);
            Name = "frmMenuPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmMenuPrincipal";
            Load += frmMenuPrincipal_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button Menu1;
        private Button Fractales;
        private Button Graficos;
        private Button Matrices;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
    }
}