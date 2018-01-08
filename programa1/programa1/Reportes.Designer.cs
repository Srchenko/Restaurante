namespace programa1
{
    partial class Reportes
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
            this.pestañas_reportes = new System.Windows.Forms.TabControl();
            this.tab_precio_categoria = new System.Windows.Forms.TabPage();
            this.tab_materia_prima_producto = new System.Windows.Forms.TabPage();
            this.tab_ventas_mozo = new System.Windows.Forms.TabPage();
            this.tab_ventas_diarias = new System.Windows.Forms.TabPage();
            this.pestañas_reportes.SuspendLayout();
            this.SuspendLayout();
            // 
            // pestañas_reportes
            // 
            this.pestañas_reportes.Controls.Add(this.tab_precio_categoria);
            this.pestañas_reportes.Controls.Add(this.tab_materia_prima_producto);
            this.pestañas_reportes.Controls.Add(this.tab_ventas_mozo);
            this.pestañas_reportes.Controls.Add(this.tab_ventas_diarias);
            this.pestañas_reportes.Location = new System.Drawing.Point(13, 13);
            this.pestañas_reportes.Name = "pestañas_reportes";
            this.pestañas_reportes.SelectedIndex = 0;
            this.pestañas_reportes.Size = new System.Drawing.Size(819, 356);
            this.pestañas_reportes.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.pestañas_reportes.TabIndex = 0;
            // 
            // tab_precio_categoria
            // 
            this.tab_precio_categoria.Location = new System.Drawing.Point(4, 22);
            this.tab_precio_categoria.Name = "tab_precio_categoria";
            this.tab_precio_categoria.Padding = new System.Windows.Forms.Padding(3);
            this.tab_precio_categoria.Size = new System.Drawing.Size(811, 330);
            this.tab_precio_categoria.TabIndex = 0;
            this.tab_precio_categoria.Text = "Precio por Categoría de Producto";
            this.tab_precio_categoria.UseVisualStyleBackColor = true;
            // 
            // tab_materia_prima_producto
            // 
            this.tab_materia_prima_producto.Location = new System.Drawing.Point(4, 22);
            this.tab_materia_prima_producto.Name = "tab_materia_prima_producto";
            this.tab_materia_prima_producto.Padding = new System.Windows.Forms.Padding(3);
            this.tab_materia_prima_producto.Size = new System.Drawing.Size(811, 330);
            this.tab_materia_prima_producto.TabIndex = 1;
            this.tab_materia_prima_producto.Text = "Materia Prima Utilizada por Producto";
            this.tab_materia_prima_producto.UseVisualStyleBackColor = true;
            // 
            // tab_ventas_mozo
            // 
            this.tab_ventas_mozo.Location = new System.Drawing.Point(4, 22);
            this.tab_ventas_mozo.Name = "tab_ventas_mozo";
            this.tab_ventas_mozo.Size = new System.Drawing.Size(811, 330);
            this.tab_ventas_mozo.TabIndex = 2;
            this.tab_ventas_mozo.Text = "Ventas por Mozo";
            this.tab_ventas_mozo.UseVisualStyleBackColor = true;
            // 
            // tab_ventas_diarias
            // 
            this.tab_ventas_diarias.Location = new System.Drawing.Point(4, 22);
            this.tab_ventas_diarias.Name = "tab_ventas_diarias";
            this.tab_ventas_diarias.Size = new System.Drawing.Size(811, 330);
            this.tab_ventas_diarias.TabIndex = 3;
            this.tab_ventas_diarias.Text = "Ventas Diarias";
            this.tab_ventas_diarias.UseVisualStyleBackColor = true;
            // 
            // Reportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 381);
            this.Controls.Add(this.pestañas_reportes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Reportes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reportes";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Reportes_FormClosed);
            this.pestañas_reportes.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl pestañas_reportes;
        private System.Windows.Forms.TabPage tab_precio_categoria;
        private System.Windows.Forms.TabPage tab_materia_prima_producto;
        private System.Windows.Forms.TabPage tab_ventas_mozo;
        private System.Windows.Forms.TabPage tab_ventas_diarias;
    }
}