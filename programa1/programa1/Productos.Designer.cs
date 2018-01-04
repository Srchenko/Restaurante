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
            this.txt_apellido = new System.Windows.Forms.TextBox();
            this.txt_nombre = new System.Windows.Forms.TextBox();
            this.l_categoria = new System.Windows.Forms.Label();
            this.l_costo = new System.Windows.Forms.Label();
            this.l_descripcion = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.cb_categoria = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.l_materia = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.b_agregarmateria = new System.Windows.Forms.Button();
            this.b_quitar = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
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
            // txt_apellido
            // 
            this.txt_apellido.Location = new System.Drawing.Point(92, 43);
            this.txt_apellido.MaxLength = 45;
            this.txt_apellido.Name = "txt_apellido";
            this.txt_apellido.Size = new System.Drawing.Size(193, 20);
            this.txt_apellido.TabIndex = 14;
            // 
            // txt_nombre
            // 
            this.txt_nombre.Location = new System.Drawing.Point(92, 17);
            this.txt_nombre.MaxLength = 45;
            this.txt_nombre.Name = "txt_nombre";
            this.txt_nombre.Size = new System.Drawing.Size(193, 20);
            this.txt_nombre.TabIndex = 13;
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
            // l_costo
            // 
            this.l_costo.AutoSize = true;
            this.l_costo.Location = new System.Drawing.Point(52, 46);
            this.l_costo.Name = "l_costo";
            this.l_costo.Size = new System.Drawing.Size(34, 13);
            this.l_costo.TabIndex = 11;
            this.l_costo.Text = "Costo";
            // 
            // l_descripcion
            // 
            this.l_descripcion.AutoSize = true;
            this.l_descripcion.Location = new System.Drawing.Point(23, 20);
            this.l_descripcion.Name = "l_descripcion";
            this.l_descripcion.Size = new System.Drawing.Size(63, 13);
            this.l_descripcion.TabIndex = 10;
            this.l_descripcion.Text = "Descripción";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(405, 51);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(57, 17);
            this.checkBox1.TabIndex = 15;
            this.checkBox1.Text = "Simple";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(468, 51);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(79, 17);
            this.checkBox2.TabIndex = 16;
            this.checkBox2.Text = "Compuesto";
            this.checkBox2.UseVisualStyleBackColor = true;
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
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(28, 106);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(257, 141);
            this.dataGridView1.TabIndex = 18;
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
            this.b_agregarmateria.Location = new System.Drawing.Point(308, 131);
            this.b_agregarmateria.Name = "b_agregarmateria";
            this.b_agregarmateria.Size = new System.Drawing.Size(82, 29);
            this.b_agregarmateria.TabIndex = 22;
            this.b_agregarmateria.Text = "Agregar ->";
            this.b_agregarmateria.UseVisualStyleBackColor = true;
            // 
            // b_quitar
            // 
            this.b_quitar.Location = new System.Drawing.Point(308, 180);
            this.b_quitar.Name = "b_quitar";
            this.b_quitar.Size = new System.Drawing.Size(84, 29);
            this.b_quitar.TabIndex = 23;
            this.b_quitar.Text = "<- Quitar";
            this.b_quitar.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(1, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(844, 399);
            this.tabControl1.TabIndex = 24;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.l_descripcion);
            this.tabPage1.Controls.Add(this.b_quitar);
            this.tabPage1.Controls.Add(this.b_agregar);
            this.tabPage1.Controls.Add(this.b_agregarmateria);
            this.tabPage1.Controls.Add(this.b_modificar);
            this.tabPage1.Controls.Add(this.dataGridView2);
            this.tabPage1.Controls.Add(this.b_eliminar);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.b_limpiar_campos);
            this.tabPage1.Controls.Add(this.l_materia);
            this.tabPage1.Controls.Add(this.l_costo);
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Controls.Add(this.l_categoria);
            this.tabPage1.Controls.Add(this.cb_categoria);
            this.tabPage1.Controls.Add(this.txt_nombre);
            this.tabPage1.Controls.Add(this.checkBox2);
            this.tabPage1.Controls.Add(this.txt_apellido);
            this.tabPage1.Controls.Add(this.checkBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(836, 373);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(836, 352);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // Productos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(903, 428);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Productos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Productos";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Productos_FormClosed);
            this.Load += new System.EventHandler(this.Mesas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button b_limpiar_campos;
        private System.Windows.Forms.Button b_eliminar;
        private System.Windows.Forms.Button b_modificar;
        private System.Windows.Forms.Button b_agregar;
        private System.Windows.Forms.TextBox txt_apellido;
        private System.Windows.Forms.TextBox txt_nombre;
        private System.Windows.Forms.Label l_categoria;
        private System.Windows.Forms.Label l_costo;
        private System.Windows.Forms.Label l_descripcion;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.ComboBox cb_categoria;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label l_materia;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button b_agregarmateria;
        private System.Windows.Forms.Button b_quitar;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
    }
}