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
            this.lbl_materia_utilizada_producto = new System.Windows.Forms.Label();
            this.dgv_productos = new System.Windows.Forms.DataGridView();
            this.dgv_materia_productos = new System.Windows.Forms.DataGridView();
            this.Columna_MPUP_Producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID_Producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Columna_Producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Columna_Categoria_Producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Columna_Precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Columna_Materia_Prima = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Columna_Marca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Columna_Costo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Columna_Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pestañas_reportes.SuspendLayout();
            this.tab_precio_categoria.SuspendLayout();
            this.tab_materia_prima_producto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_categoria)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_categoria_producto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_productos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_materia_productos)).BeginInit();
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
            this.pestañas_reportes.Click += new System.EventHandler(this.pestañas_reportes_Click);
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
            this.tab_materia_prima_producto.Controls.Add(this.dgv_materia_productos);
            this.tab_materia_prima_producto.Controls.Add(this.dgv_productos);
            this.tab_materia_prima_producto.Controls.Add(this.lbl_materia_utilizada_producto);
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
            this.dgv_categoria.Location = new System.Drawing.Point(9, 31);
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
            this.dgv_categoria_producto.Location = new System.Drawing.Point(292, 32);
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
            // lbl_materia_utilizada_producto
            // 
            this.lbl_materia_utilizada_producto.AutoSize = true;
            this.lbl_materia_utilizada_producto.Location = new System.Drawing.Point(6, 3);
            this.lbl_materia_utilizada_producto.Name = "lbl_materia_utilizada_producto";
            this.lbl_materia_utilizada_producto.Size = new System.Drawing.Size(171, 13);
            this.lbl_materia_utilizada_producto.TabIndex = 1;
            this.lbl_materia_utilizada_producto.Text = "No existen productos para mostrar.";
            // 
            // dgv_productos
            // 
            this.dgv_productos.AllowUserToAddRows = false;
            this.dgv_productos.AllowUserToDeleteRows = false;
            this.dgv_productos.AllowUserToResizeColumns = false;
            this.dgv_productos.AllowUserToResizeRows = false;
            this.dgv_productos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_productos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Columna_MPUP_Producto,
            this.ID_Producto});
            this.dgv_productos.Location = new System.Drawing.Point(9, 31);
            this.dgv_productos.Name = "dgv_productos";
            this.dgv_productos.ReadOnly = true;
            this.dgv_productos.RowHeadersVisible = false;
            this.dgv_productos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgv_productos.Size = new System.Drawing.Size(216, 293);
            this.dgv_productos.TabIndex = 2;
            this.dgv_productos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_productos_CellClick);
            // 
            // dgv_materia_productos
            // 
            this.dgv_materia_productos.AllowUserToAddRows = false;
            this.dgv_materia_productos.AllowUserToDeleteRows = false;
            this.dgv_materia_productos.AllowUserToResizeColumns = false;
            this.dgv_materia_productos.AllowUserToResizeRows = false;
            this.dgv_materia_productos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_materia_productos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Columna_Materia_Prima,
            this.Columna_Marca,
            this.Columna_Costo,
            this.Columna_Cantidad});
            this.dgv_materia_productos.Location = new System.Drawing.Point(292, 32);
            this.dgv_materia_productos.Name = "dgv_materia_productos";
            this.dgv_materia_productos.ReadOnly = true;
            this.dgv_materia_productos.RowHeadersVisible = false;
            this.dgv_materia_productos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgv_materia_productos.Size = new System.Drawing.Size(513, 292);
            this.dgv_materia_productos.TabIndex = 3;
            // 
            // Columna_MPUP_Producto
            // 
            this.Columna_MPUP_Producto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Columna_MPUP_Producto.HeaderText = "Producto";
            this.Columna_MPUP_Producto.Name = "Columna_MPUP_Producto";
            this.Columna_MPUP_Producto.ReadOnly = true;
            this.Columna_MPUP_Producto.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // ID_Producto
            // 
            this.ID_Producto.HeaderText = "ID_Producto";
            this.ID_Producto.Name = "ID_Producto";
            this.ID_Producto.ReadOnly = true;
            this.ID_Producto.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ID_Producto.Visible = false;
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
            this.Columna_Precio.Width = 80;
            // 
            // Columna_Materia_Prima
            // 
            this.Columna_Materia_Prima.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Columna_Materia_Prima.HeaderText = "Materia Prima";
            this.Columna_Materia_Prima.Name = "Columna_Materia_Prima";
            this.Columna_Materia_Prima.ReadOnly = true;
            this.Columna_Materia_Prima.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Columna_Marca
            // 
            this.Columna_Marca.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Columna_Marca.HeaderText = "Marca";
            this.Columna_Marca.Name = "Columna_Marca";
            this.Columna_Marca.ReadOnly = true;
            this.Columna_Marca.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Columna_Costo
            // 
            this.Columna_Costo.HeaderText = "Costo Individual";
            this.Columna_Costo.Name = "Columna_Costo";
            this.Columna_Costo.ReadOnly = true;
            this.Columna_Costo.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Columna_Costo.Width = 120;
            // 
            // Columna_Cantidad
            // 
            this.Columna_Cantidad.HeaderText = "Cantidad";
            this.Columna_Cantidad.Name = "Columna_Cantidad";
            this.Columna_Cantidad.ReadOnly = true;
            this.Columna_Cantidad.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Columna_Cantidad.Width = 60;
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
            this.tab_materia_prima_producto.ResumeLayout(false);
            this.tab_materia_prima_producto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_categoria)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_categoria_producto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_productos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_materia_productos)).EndInit();
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
        private System.Windows.Forms.DataGridView dgv_materia_productos;
        private System.Windows.Forms.DataGridView dgv_productos;
        private System.Windows.Forms.Label lbl_materia_utilizada_producto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Columna_MPUP_Producto;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID_Producto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Columna_Producto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Columna_Categoria_Producto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Columna_Precio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Columna_Materia_Prima;
        private System.Windows.Forms.DataGridViewTextBoxColumn Columna_Marca;
        private System.Windows.Forms.DataGridViewTextBoxColumn Columna_Costo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Columna_Cantidad;
    }
}