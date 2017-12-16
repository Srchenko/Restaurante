namespace programa1
{
    partial class Comandas
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
            this.lbl_numero_mesa = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_numero_mesa
            // 
            this.lbl_numero_mesa.AutoSize = true;
            this.lbl_numero_mesa.Location = new System.Drawing.Point(23, 8);
            this.lbl_numero_mesa.Name = "lbl_numero_mesa";
            this.lbl_numero_mesa.Size = new System.Drawing.Size(88, 13);
            this.lbl_numero_mesa.TabIndex = 0;
            this.lbl_numero_mesa.Text = "numero_aleatorio";
            // 
            // Comandas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.lbl_numero_mesa);
            this.Name = "Comandas";
            this.Text = "Comandas";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_numero_mesa;
    }
}