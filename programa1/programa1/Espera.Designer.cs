namespace programa1
{
    partial class Espera
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
            this.lbl_espera = new System.Windows.Forms.Label();
            this.panel_espera = new System.Windows.Forms.Panel();
            this.panel_espera.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_espera
            // 
            this.lbl_espera.AutoSize = true;
            this.lbl_espera.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_espera.Location = new System.Drawing.Point(3, 54);
            this.lbl_espera.Name = "lbl_espera";
            this.lbl_espera.Size = new System.Drawing.Size(293, 39);
            this.lbl_espera.TabIndex = 0;
            this.lbl_espera.Text = "Por favor, espere.\r\n";
            this.lbl_espera.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel_espera
            // 
            this.panel_espera.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_espera.Controls.Add(this.lbl_espera);
            this.panel_espera.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_espera.Location = new System.Drawing.Point(0, 0);
            this.panel_espera.Name = "panel_espera";
            this.panel_espera.Size = new System.Drawing.Size(300, 150);
            this.panel_espera.TabIndex = 1;
            // 
            // Espera
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(300, 150);
            this.Controls.Add(this.panel_espera);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Espera";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.panel_espera.ResumeLayout(false);
            this.panel_espera.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl_espera;
        private System.Windows.Forms.Panel panel_espera;
    }
}