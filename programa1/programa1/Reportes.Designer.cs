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
            this.lbl_precio_categoria_producto = new System.Windows.Forms.Label();
            this.dgv_categoria = new System.Windows.Forms.DataGridView();
            this.dgv_categoria_producto = new System.Windows.Forms.DataGridView();
            this.Columna_Categoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID_Categoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Columna_Producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Columna_Categoria_Producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Columna_Precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pestañas_reportes.SuspendLayout();
            this.tab_precio_categoria.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_categoria)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_categoria_producto)).BeginInit();
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
            this.tab_precio_categoria.Controls.Add(this.dgv_categoria_producto);
            this.tab_precio_categoria.Controls.Add(this.dgv_categoria);
            this.tab_precio_categoria.Controls.Add(this.lbl_precio_categoria_producto);
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
            // lbl_precio_categoria_producto
            // 
            this.lbl_precio_categoria_producto.AutoSize = true;
            this.lbl_precio_categoria_producto.Location = new System.Drawing.Point(6, 3);
            this.lbl_precio_categoria_producto.Name = "lbl_precio_categoria_producto";
            this.lbl_precio_categoria_producto.Size = new System.Drawing.Size(171, 13);
            this.lbl_precio_categoria_producto.TabIndex = 0;
            this.lbl_precio_categoria_producto.Text = "No existen productos para mostrar.";
            // 
            // dgv_categoria
            // 
            this.dgv_categoria.AllowUserToAddRows = false;
            this.dgv_categoria.AllowUserToDeleteRows = false;
            this.dgv_categoria.AllowUserToResizeColumns = false;
            this.dgv_categoria.AllowUserToResizeRows = false;
            this.dgv_categoria.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_categoria.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Columna_Categoria,
            this.ID_Categoria});
            this.dgv_categoria.Location = new System.Drawing.Point(10, 31);
            this.dgv_categoria.Name = "dgv_categoria";
            this.dgv_categoria.ReadOnly = true;
            this.dgv_categoria.RowHeadersVisible = false;
            this.dgv_categoria.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgv_categoria.Size = new System.Drawing.Size(216, 293);
            this.dgv_categoria.TabIndex = 1;
            this.dgv_categoria.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_categoria_CellClick);
            // 
            // dgv_categoria_producto
            // 
            this.dgv_categoria_producto.AllowUserToAddRows = false;
            this.dgv_categoria_producto.AllowUserToDeleteRows = false;
            this.dgv_categoria_producto.AllowUserToResizeColumns = false;
            this.dgv_categoria_producto.AllowUserToResizeRows = false;
            this.dgv_categoria_producto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_categoria_producto.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Columna_Producto,
            this.Columna_Categoria_Producto,
            this.Columna_Precio});
            this.dgv_categoria_producto.Location = new System.Drawing.Point(287, 31);
            this.dgv_categoria_producto.Name = "dgv_categoria_producto";
            this.dgv_categoria_producto.ReadOnly = true;
            this.dgv_categoria_producto.RowHeadersVisible = false;
            this.dgv_categoria_producto.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgv_categoria_producto.Size = new System.Drawing.Size(513, 292);
            this.dgv_categoria_producto.TabIndex = 2;
            // 
            // Columna_Categoria
            // 
            this.Columna_Categoria.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Columna_Categoria.HeaderText = "Categoria";
            this.Columna_Categoria.Name = "Columna_Categoria";
            this.Columna_Categoria.ReadOnly = true;
            this.Columna_Categoria.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // ID_Categoria
            // 
            this.ID_Categoria.HeaderText = "ID_Categoria";
            this.ID_Categoria.Name = "ID_Categoria";
            this.ID_Categoria.ReadOnly = true;
            this.ID_Categoria.Visible = false;
            // 
            // Columna_Producto
            // 
            this.Columna_Producto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Columna_Producto.HeaderText = "Producto";
            this.Columna_Producto.Name = "Columna_Producto";
            this.Columna_Producto.ReadOnly = true;
            this.Columna_Producto.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Columna_Categoria_Producto
            // 
            this.Columna_Categoria_Producto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Columna_Categoria_Producto.HeaderText = "Categoria";
            this.Columna_Categoria_Producto.Name = "Columna_Categoria_Producto";
            this.Columna_Categoria_Producto.ReadOnly = true;
            this.Columna_Categoria_Producto.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Columna_Precio
            // 
            this.Columna_Precio.HeaderText = "Precio";
            this.Columna_Precio.Name = "Columna_Precio";
            this.Columna_Precio.ReadOnly = true;
            this.Columna_Precio.Resizable = System.Windows.Forms.DataGridViewTriState.False;
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
            this.Shown += new System.EventHandler(this.Reportes_Shown);
            this.pestañas_reportes.ResumeLayout(false);
            this.tab_precio_categoria.ResumeLayout(false);
            this.tab_precio_categoria.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_categoria)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_categoria_producto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl pestañas_reportes;
        private System.Windows.Forms.TabPage tab_precio_categoria;
        private System.Windows.Forms.TabPage tab_materia_prima_producto;
        private System.Windows.Forms.TabPage tab_ventas_mozo;
        private System.Windows.Forms.TabPage tab_ventas_diarias;
        private System.Windows.Forms.DataGridView dgv_categoria_producto;
        private System.Windows.Forms.DataGridView dgv_categoria;
        private System.Windows.Forms.Label lbl_precio_categoria_producto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Columna_Categoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID_Categoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn Columna_Producto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Columna_Categoria_Producto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Columna_Precio;
    }
}