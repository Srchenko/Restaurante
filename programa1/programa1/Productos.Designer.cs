namespace programa1
{
    partial class Productos
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
            this.b_limpiar_campos = new System.Windows.Forms.Button();
            this.b_eliminar = new System.Windows.Forms.Button();
            this.b_modificar = new System.Windows.Forms.Button();
            this.b_agregar = new System.Windows.Forms.Button();
            this.txt_precio = new System.Windows.Forms.TextBox();
            this.txt_descripcion = new System.Windows.Forms.TextBox();
            this.l_categoria = new System.Windows.Forms.Label();
            this.l_precio = new System.Windows.Forms.Label();
            this.l_descripcion = new System.Windows.Forms.Label();
            this.cb_categoria = new System.Windows.Forms.ComboBox();
            this.dgv_materia_prima = new System.Windows.Forms.DataGridView();
            this.l_materia = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.b_agregarmateria = new System.Windows.Forms.Button();
            this.b_quitar = new System.Windows.Forms.Button();
            this.b_agregar2 = new System.Windows.Forms.TabControl();
            this.tp_productos = new System.Windows.Forms.TabPage();
            this.dgv_productos = new System.Windows.Forms.DataGridView();
            this.tp_materia = new System.Windows.Forms.TabPage();
            this.dataGridView4 = new System.Windows.Forms.DataGridView();
            this.l_descripcion2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.b_modificar2 = new System.Windows.Forms.Button();
            this.b_eliminar2 = new System.Windows.Forms.Button();
            this.l_limpiar_campos = new System.Windows.Forms.Button();
            this.l_costo2 = new System.Windows.Forms.Label();
            this.l_marca = new System.Windows.Forms.Label();
            this.cb_marca = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.clb_simple_compuesto = new System.Windows.Forms.CheckedListBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_materia_prima)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.b_agregar2.SuspendLayout();
            this.tp_productos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_productos)).BeginInit();
            this.tp_materia.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).BeginInit();
            this.SuspendLayout();
            // 
            // b_limpiar_campos
            // 
            this.b_limpiar_campos.Location = new System.Drawing.Point(707, 135);
            this.b_limpiar_campos.Name = "b_limpiar_campos";
            this.b_limpiar_campos.Size = new System.Drawing.Size(112, 22);
            this.b_limpiar_campos.TabIndex = 7;
            this.b_limpiar_campos.Text = "Limpiar Campos";
            this.b_limpiar_campos.UseVisualStyleBackColor = true;
            // 
            // b_eliminar
            // 
            this.b_eliminar.Location = new System.Drawing.Point(707, 96);
            this.b_eliminar.Name = "b_eliminar";
            this.b_eliminar.Size = new System.Drawing.Size(112, 22);
            this.b_eliminar.TabIndex = 6;
            this.b_eliminar.Text = "Eliminar";
            this.b_eliminar.UseVisualStyleBackColor = true;
            // 
            // b_modificar
            // 
            this.b_modificar.Location = new System.Drawing.Point(707, 59);
            this.b_modificar.Name = "b_modificar";
            this.b_modificar.Size = new System.Drawing.Size(112, 22);
            this.b_modificar.TabIndex = 5;
            this.b_modificar.Text = "Modificar";
            this.b_modificar.UseVisualStyleBackColor = true;
            // 
            // b_agregar
            // 
            this.b_agregar.Location = new System.Drawing.Point(707, 22);
            this.b_agregar.Name = "b_agregar";
            this.b_agregar.Size = new System.Drawing.Size(112, 22);
            this.b_agregar.TabIndex = 4;
            this.b_agregar.Text = "Agregar";
            this.b_agregar.UseVisualStyleBackColor = true;
            // 
            // txt_precio
            // 
            this.txt_precio.Location = new System.Drawing.Point(80, 41);
            this.txt_precio.MaxLength = 45;
            this.txt_precio.Name = "txt_precio";
            this.txt_precio.Size = new System.Drawing.Size(193, 20);
            this.txt_precio.TabIndex = 14;
            // 
            // txt_descripcion
            // 
            this.txt_descripcion.Location = new System.Drawing.Point(80, 15);
            this.txt_descripcion.MaxLength = 45;
            this.txt_descripcion.Name = "txt_descripcion";
            this.txt_descripcion.Size = new System.Drawing.Size(193, 20);
            this.txt_descripcion.TabIndex = 13;
            // 
            // l_categoria
            // 
            this.l_categoria.AutoSize = true;
            this.l_categoria.Location = new System.Drawing.Point(345, 22);
            this.l_categoria.Name = "l_categoria";
            this.l_categoria.Size = new System.Drawing.Size(54, 13);
            this.l_categoria.TabIndex = 12;
            this.l_categoria.Text = "Categoría";
            // 
            // l_precio
            // 
            this.l_precio.AutoSize = true;
            this.l_precio.Location = new System.Drawing.Point(40, 44);
            this.l_precio.Name = "l_precio";
            this.l_precio.Size = new System.Drawing.Size(37, 13);
            this.l_precio.TabIndex = 11;
            this.l_precio.Text = "Precio";
            // 
            // l_descripcion
            // 
            this.l_descripcion.AutoSize = true;
            this.l_descripcion.Location = new System.Drawing.Point(11, 18);
            this.l_descripcion.Name = "l_descripcion";
            this.l_descripcion.Size = new System.Drawing.Size(63, 13);
            this.l_descripcion.TabIndex = 10;
            this.l_descripcion.Text = "Descripción";
            // 
            // cb_categoria
            // 
            this.cb_categoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_categoria.FormattingEnabled = true;
            this.cb_categoria.Location = new System.Drawing.Point(405, 19);
            this.cb_categoria.Name = "cb_categoria";
            this.cb_categoria.Size = new System.Drawing.Size(145, 21);
            this.cb_categoria.TabIndex = 17;
            // 
            // dgv_materia_prima
            // 
            this.dgv_materia_prima.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_materia_prima.Location = new System.Drawing.Point(30, 106);
            this.dgv_materia_prima.Name = "dgv_materia_prima";
            this.dgv_materia_prima.Size = new System.Drawing.Size(257, 141);
            this.dgv_materia_prima.TabIndex = 18;
            // 
            // l_materia
            // 
            this.l_materia.AutoSize = true;
            this.l_materia.Location = new System.Drawing.Point(89, 86);
            this.l_materia.Name = "l_materia";
            this.l_materia.Size = new System.Drawing.Size(121, 13);
            this.l_materia.TabIndex = 19;
            this.l_materia.Text = "Lista de Materias Primas";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(470, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Materia del Producto";
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(405, 106);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(258, 141);
            this.dataGridView2.TabIndex = 21;
            // 
            // b_agregarmateria
            // 
            this.b_agregarmateria.Location = new System.Drawing.Point(305, 132);
            this.b_agregarmateria.Name = "b_agregarmateria";
            this.b_agregarmateria.Size = new System.Drawing.Size(82, 29);
            this.b_agregarmateria.TabIndex = 22;
            this.b_agregarmateria.Text = "Agregar ->";
            this.b_agregarmateria.UseVisualStyleBackColor = true;
            // 
            // b_quitar
            // 
            this.b_quitar.Location = new System.Drawing.Point(305, 180);
            this.b_quitar.Name = "b_quitar";
            this.b_quitar.Size = new System.Drawing.Size(84, 29);
            this.b_quitar.TabIndex = 23;
            this.b_quitar.Text = "<- Quitar";
            this.b_quitar.UseVisualStyleBackColor = true;
            // 
            // b_agregar2
            // 
            this.b_agregar2.Controls.Add(this.tp_productos);
            this.b_agregar2.Controls.Add(this.tp_materia);
            this.b_agregar2.Location = new System.Drawing.Point(1, 2);
            this.b_agregar2.Name = "b_agregar2";
            this.b_agregar2.SelectedIndex = 0;
            this.b_agregar2.Size = new System.Drawing.Size(844, 427);
            this.b_agregar2.TabIndex = 24;
            // 
            // tp_productos
            // 
            this.tp_productos.Controls.Add(this.clb_simple_compuesto);
            this.tp_productos.Controls.Add(this.dgv_productos);
            this.tp_productos.Controls.Add(this.l_descripcion);
            this.tp_productos.Controls.Add(this.b_quitar);
            this.tp_productos.Controls.Add(this.b_agregar);
            this.tp_productos.Controls.Add(this.b_agregarmateria);
            this.tp_productos.Controls.Add(this.b_modificar);
            this.tp_productos.Controls.Add(this.dataGridView2);
            this.tp_productos.Controls.Add(this.b_eliminar);
            this.tp_productos.Controls.Add(this.label1);
            this.tp_productos.Controls.Add(this.b_limpiar_campos);
            this.tp_productos.Controls.Add(this.l_materia);
            this.tp_productos.Controls.Add(this.l_precio);
            this.tp_productos.Controls.Add(this.dgv_materia_prima);
            this.tp_productos.Controls.Add(this.l_categoria);
            this.tp_productos.Controls.Add(this.cb_categoria);
            this.tp_productos.Controls.Add(this.txt_descripcion);
            this.tp_productos.Controls.Add(this.txt_precio);
            this.tp_productos.Location = new System.Drawing.Point(4, 22);
            this.tp_productos.Name = "tp_productos";
            this.tp_productos.Padding = new System.Windows.Forms.Padding(3);
            this.tp_productos.Size = new System.Drawing.Size(836, 401);
            this.tp_productos.TabIndex = 0;
            this.tp_productos.Text = "Productos";
            this.tp_productos.UseVisualStyleBackColor = true;
            // 
            // dgv_productos
            // 
            this.dgv_productos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_productos.Location = new System.Drawing.Point(30, 268);
            this.dgv_productos.Name = "dgv_productos";
            this.dgv_productos.Size = new System.Drawing.Size(789, 124);
            this.dgv_productos.TabIndex = 24;
            // 
            // tp_materia
            // 
            this.tp_materia.Controls.Add(this.dataGridView4);
            this.tp_materia.Controls.Add(this.l_descripcion2);
            this.tp_materia.Controls.Add(this.button1);
            this.tp_materia.Controls.Add(this.b_modificar2);
            this.tp_materia.Controls.Add(this.b_eliminar2);
            this.tp_materia.Controls.Add(this.l_limpiar_campos);
            this.tp_materia.Controls.Add(this.l_costo2);
            this.tp_materia.Controls.Add(this.l_marca);
            this.tp_materia.Controls.Add(this.cb_marca);
            this.tp_materia.Controls.Add(this.textBox1);
            this.tp_materia.Controls.Add(this.textBox2);
            this.tp_materia.Location = new System.Drawing.Point(4, 22);
            this.tp_materia.Name = "tp_materia";
            this.tp_materia.Padding = new System.Windows.Forms.Padding(3);
            this.tp_materia.Size = new System.Drawing.Size(836, 401);
            this.tp_materia.TabIndex = 1;
            this.tp_materia.Text = "Materia Prima";
            this.tp_materia.UseVisualStyleBackColor = true;
            // 
            // dataGridView4
            // 
            this.dataGridView4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView4.Location = new System.Drawing.Point(16, 171);
            this.dataGridView4.Name = "dataGridView4";
            this.dataGridView4.Size = new System.Drawing.Size(792, 184);
            this.dataGridView4.TabIndex = 28;
            // 
            // l_descripcion2
            // 
            this.l_descripcion2.AutoSize = true;
            this.l_descripcion2.Location = new System.Drawing.Point(13, 43);
            this.l_descripcion2.Name = "l_descripcion2";
            this.l_descripcion2.Size = new System.Drawing.Size(63, 13);
            this.l_descripcion2.TabIndex = 22;
            this.l_descripcion2.Text = "Descripción";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(697, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 22);
            this.button1.TabIndex = 18;
            this.button1.Text = "Agregar";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // b_modificar2
            // 
            this.b_modificar2.Location = new System.Drawing.Point(697, 56);
            this.b_modificar2.Name = "b_modificar2";
            this.b_modificar2.Size = new System.Drawing.Size(112, 22);
            this.b_modificar2.TabIndex = 19;
            this.b_modificar2.Text = "Modificar";
            this.b_modificar2.UseVisualStyleBackColor = true;
            // 
            // b_eliminar2
            // 
            this.b_eliminar2.Location = new System.Drawing.Point(697, 93);
            this.b_eliminar2.Name = "b_eliminar2";
            this.b_eliminar2.Size = new System.Drawing.Size(112, 22);
            this.b_eliminar2.TabIndex = 20;
            this.b_eliminar2.Text = "Eliminar";
            this.b_eliminar2.UseVisualStyleBackColor = true;
            // 
            // l_limpiar_campos
            // 
            this.l_limpiar_campos.Location = new System.Drawing.Point(697, 132);
            this.l_limpiar_campos.Name = "l_limpiar_campos";
            this.l_limpiar_campos.Size = new System.Drawing.Size(112, 22);
            this.l_limpiar_campos.TabIndex = 21;
            this.l_limpiar_campos.Text = "Limpiar Campos";
            this.l_limpiar_campos.UseVisualStyleBackColor = true;
            // 
            // l_costo2
            // 
            this.l_costo2.AutoSize = true;
            this.l_costo2.Location = new System.Drawing.Point(42, 87);
            this.l_costo2.Name = "l_costo2";
            this.l_costo2.Size = new System.Drawing.Size(34, 13);
            this.l_costo2.TabIndex = 23;
            this.l_costo2.Text = "Costo";
            // 
            // l_marca
            // 
            this.l_marca.AutoSize = true;
            this.l_marca.Location = new System.Drawing.Point(347, 43);
            this.l_marca.Name = "l_marca";
            this.l_marca.Size = new System.Drawing.Size(37, 13);
            this.l_marca.TabIndex = 24;
            this.l_marca.Text = "Marca";
            // 
            // cb_marca
            // 
            this.cb_marca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_marca.FormattingEnabled = true;
            this.cb_marca.Location = new System.Drawing.Point(390, 40);
            this.cb_marca.Name = "cb_marca";
            this.cb_marca.Size = new System.Drawing.Size(145, 21);
            this.cb_marca.TabIndex = 27;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(82, 40);
            this.textBox1.MaxLength = 45;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(193, 20);
            this.textBox1.TabIndex = 25;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(82, 84);
            this.textBox2.MaxLength = 45;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(193, 20);
            this.textBox2.TabIndex = 26;
            // 
            // clb_simple_compuesto
            // 
            this.clb_simple_compuesto.FormattingEnabled = true;
            this.clb_simple_compuesto.Items.AddRange(new object[] {
            "Simple",
            "Compuesto"});
            this.clb_simple_compuesto.Location = new System.Drawing.Point(305, 65);
            this.clb_simple_compuesto.Name = "clb_simple_compuesto";
            this.clb_simple_compuesto.Size = new System.Drawing.Size(82, 34);
            this.clb_simple_compuesto.TabIndex = 25;
            this.clb_simple_compuesto.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.clb_simple_compuesto_ItemCheck);
            // 
            // Productos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(903, 428);
            this.Controls.Add(this.b_agregar2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Productos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Productos";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Productos_FormClosed);
            this.Load += new System.EventHandler(this.Mesas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_materia_prima)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.b_agregar2.ResumeLayout(false);
            this.tp_productos.ResumeLayout(false);
            this.tp_productos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_productos)).EndInit();
            this.tp_materia.ResumeLayout(false);
            this.tp_materia.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button b_limpiar_campos;
        private System.Windows.Forms.Button b_eliminar;
        private System.Windows.Forms.Button b_modificar;
        private System.Windows.Forms.Button b_agregar;
        private System.Windows.Forms.TextBox txt_precio;
        private System.Windows.Forms.TextBox txt_descripcion;
        private System.Windows.Forms.Label l_categoria;
        private System.Windows.Forms.Label l_precio;
        private System.Windows.Forms.Label l_descripcion;
        private System.Windows.Forms.ComboBox cb_categoria;
        private System.Windows.Forms.DataGridView dgv_materia_prima;
        private System.Windows.Forms.Label l_materia;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button b_agregarmateria;
        private System.Windows.Forms.Button b_quitar;
        private System.Windows.Forms.TabControl b_agregar2;
        private System.Windows.Forms.TabPage tp_productos;
        private System.Windows.Forms.TabPage tp_materia;
        private System.Windows.Forms.DataGridView dgv_productos;
        private System.Windows.Forms.DataGridView dataGridView4;
        private System.Windows.Forms.Label l_descripcion2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button b_modificar2;
        private System.Windows.Forms.Button b_eliminar2;
        private System.Windows.Forms.Button l_limpiar_campos;
        private System.Windows.Forms.Label l_costo2;
        private System.Windows.Forms.Label l_marca;
        private System.Windows.Forms.ComboBox cb_marca;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.CheckedListBox clb_simple_compuesto;
    }
}