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
            this.dgv_materia_producto = new System.Windows.Forms.DataGridView();
            this.b_agregarmateria = new System.Windows.Forms.Button();
            this.b_quitar = new System.Windows.Forms.Button();
            this.tc_formulario = new System.Windows.Forms.TabControl();
            this.tp_productos = new System.Windows.Forms.TabPage();
            this.clb_simple_compuesto = new System.Windows.Forms.CheckedListBox();
            this.dgv_productos = new System.Windows.Forms.DataGridView();
            this.tp_materia = new System.Windows.Forms.TabPage();
            this.dgv_materias = new System.Windows.Forms.DataGridView();
            this.l_descripcion2 = new System.Windows.Forms.Label();
            this.b_agregar2 = new System.Windows.Forms.Button();
            this.b_modificar2 = new System.Windows.Forms.Button();
            this.b_eliminar2 = new System.Windows.Forms.Button();
            this.b_limpiar_campos2 = new System.Windows.Forms.Button();
            this.l_costo = new System.Windows.Forms.Label();
            this.l_marca = new System.Windows.Forms.Label();
            this.cb_marca = new System.Windows.Forms.ComboBox();
            this.txt_descripcion2 = new System.Windows.Forms.TextBox();
            this.txt_costo = new System.Windows.Forms.TextBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgv_categoria = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.b_agregar4 = new System.Windows.Forms.Button();
            this.b_modificar4 = new System.Windows.Forms.Button();
            this.b_eliminar4 = new System.Windows.Forms.Button();
            this.b_limpiar_campos4 = new System.Windows.Forms.Button();
            this.txt_categoria = new System.Windows.Forms.TextBox();
            this.dgv_marca = new System.Windows.Forms.DataGridView();
            this.l_marca2 = new System.Windows.Forms.Label();
            this.b_agregar3 = new System.Windows.Forms.Button();
            this.b_modificar3 = new System.Windows.Forms.Button();
            this.b_eliminar3 = new System.Windows.Forms.Button();
            this.b_limpiar_campos3 = new System.Windows.Forms.Button();
            this.txt_marca = new System.Windows.Forms.TextBox();
            this.id_materia_producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcion_materia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.marca_materia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costo_materia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidad_materia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_materia_prima)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_materia_producto)).BeginInit();
            this.tc_formulario.SuspendLayout();
            this.tp_productos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_productos)).BeginInit();
            this.tp_materia.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_materias)).BeginInit();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_categoria)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_marca)).BeginInit();
            this.SuspendLayout();
            // 
            // b_limpiar_campos
            // 
            this.b_limpiar_campos.Location = new System.Drawing.Point(707, 51);
            this.b_limpiar_campos.Name = "b_limpiar_campos";
            this.b_limpiar_campos.Size = new System.Drawing.Size(112, 22);
            this.b_limpiar_campos.TabIndex = 7;
            this.b_limpiar_campos.Text = "Limpiar Campos";
            this.b_limpiar_campos.UseVisualStyleBackColor = true;
            this.b_limpiar_campos.Click += new System.EventHandler(this.b_limpiar_campos_Click);
            // 
            // b_eliminar
            // 
            this.b_eliminar.Location = new System.Drawing.Point(707, 19);
            this.b_eliminar.Name = "b_eliminar";
            this.b_eliminar.Size = new System.Drawing.Size(112, 22);
            this.b_eliminar.TabIndex = 6;
            this.b_eliminar.Text = "Eliminar";
            this.b_eliminar.UseVisualStyleBackColor = true;
            this.b_eliminar.Click += new System.EventHandler(this.b_eliminar_Click);
            // 
            // b_modificar
            // 
            this.b_modificar.Location = new System.Drawing.Point(578, 51);
            this.b_modificar.Name = "b_modificar";
            this.b_modificar.Size = new System.Drawing.Size(112, 22);
            this.b_modificar.TabIndex = 5;
            this.b_modificar.Text = "Modificar";
            this.b_modificar.UseVisualStyleBackColor = true;
            // 
            // b_agregar
            // 
            this.b_agregar.Location = new System.Drawing.Point(578, 18);
            this.b_agregar.Name = "b_agregar";
            this.b_agregar.Size = new System.Drawing.Size(112, 22);
            this.b_agregar.TabIndex = 4;
            this.b_agregar.Text = "Agregar";
            this.b_agregar.UseVisualStyleBackColor = true;
            // 
            // txt_precio
            // 
            this.txt_precio.Location = new System.Drawing.Point(80, 48);
            this.txt_precio.MaxLength = 7;
            this.txt_precio.Name = "txt_precio";
            this.txt_precio.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txt_precio.Size = new System.Drawing.Size(193, 20);
            this.txt_precio.TabIndex = 14;
            this.txt_precio.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_precio_KeyDown);
            // 
            // txt_descripcion
            // 
            this.txt_descripcion.Location = new System.Drawing.Point(80, 15);
            this.txt_descripcion.MaxLength = 50;
            this.txt_descripcion.Name = "txt_descripcion";
            this.txt_descripcion.Size = new System.Drawing.Size(193, 20);
            this.txt_descripcion.TabIndex = 13;
            this.txt_descripcion.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_descripcion_KeyDown);
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
            this.l_precio.Location = new System.Drawing.Point(37, 51);
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
            this.dgv_materia_prima.AllowUserToAddRows = false;
            this.dgv_materia_prima.AllowUserToDeleteRows = false;
            this.dgv_materia_prima.AllowUserToResizeColumns = false;
            this.dgv_materia_prima.AllowUserToResizeRows = false;
            this.dgv_materia_prima.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_materia_prima.Location = new System.Drawing.Point(7, 117);
            this.dgv_materia_prima.Name = "dgv_materia_prima";
            this.dgv_materia_prima.ReadOnly = true;
            this.dgv_materia_prima.RowHeadersVisible = false;
            this.dgv_materia_prima.Size = new System.Drawing.Size(366, 141);
            this.dgv_materia_prima.TabIndex = 18;
            this.dgv_materia_prima.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_materia_prima_CellClick);
            // 
            // l_materia
            // 
            this.l_materia.AutoSize = true;
            this.l_materia.Location = new System.Drawing.Point(115, 101);
            this.l_materia.Name = "l_materia";
            this.l_materia.Size = new System.Drawing.Size(121, 13);
            this.l_materia.TabIndex = 19;
            this.l_materia.Text = "Lista de Materias Primas";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(616, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Materia del Producto";
            // 
            // dgv_materia_producto
            // 
            this.dgv_materia_producto.AllowUserToAddRows = false;
            this.dgv_materia_producto.AllowUserToDeleteRows = false;
            this.dgv_materia_producto.AllowUserToResizeColumns = false;
            this.dgv_materia_producto.AllowUserToResizeRows = false;
            this.dgv_materia_producto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_materia_producto.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_materia_producto,
            this.descripcion_materia,
            this.marca_materia,
            this.costo_materia,
            this.cantidad_materia});
            this.dgv_materia_producto.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgv_materia_producto.Location = new System.Drawing.Point(469, 117);
            this.dgv_materia_producto.Name = "dgv_materia_producto";
            this.dgv_materia_producto.RowHeadersVisible = false;
            this.dgv_materia_producto.Size = new System.Drawing.Size(361, 141);
            this.dgv_materia_producto.TabIndex = 21;
            // 
            // b_agregarmateria
            // 
            this.b_agregarmateria.Location = new System.Drawing.Point(381, 152);
            this.b_agregarmateria.Name = "b_agregarmateria";
            this.b_agregarmateria.Size = new System.Drawing.Size(82, 29);
            this.b_agregarmateria.TabIndex = 22;
            this.b_agregarmateria.Text = "Agregar ->";
            this.b_agregarmateria.UseVisualStyleBackColor = true;
            this.b_agregarmateria.Click += new System.EventHandler(this.b_agregarmateria_Click);
            // 
            // b_quitar
            // 
            this.b_quitar.Location = new System.Drawing.Point(379, 197);
            this.b_quitar.Name = "b_quitar";
            this.b_quitar.Size = new System.Drawing.Size(84, 29);
            this.b_quitar.TabIndex = 23;
            this.b_quitar.Text = "<- Quitar";
            this.b_quitar.UseVisualStyleBackColor = true;
            this.b_quitar.Click += new System.EventHandler(this.b_quitar_Click);
            // 
            // tc_formulario
            // 
            this.tc_formulario.Controls.Add(this.tp_productos);
            this.tc_formulario.Controls.Add(this.tp_materia);
            this.tc_formulario.Controls.Add(this.tabPage1);
            this.tc_formulario.Location = new System.Drawing.Point(1, 2);
            this.tc_formulario.Name = "tc_formulario";
            this.tc_formulario.SelectedIndex = 0;
            this.tc_formulario.Size = new System.Drawing.Size(844, 427);
            this.tc_formulario.TabIndex = 24;
            this.tc_formulario.Click += new System.EventHandler(this.tc_formulario_Click);
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
            this.tp_productos.Controls.Add(this.dgv_materia_producto);
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
            // clb_simple_compuesto
            // 
            this.clb_simple_compuesto.CheckOnClick = true;
            this.clb_simple_compuesto.FormattingEnabled = true;
            this.clb_simple_compuesto.Items.AddRange(new object[] {
            "Simple",
            "Compuesto"});
            this.clb_simple_compuesto.Location = new System.Drawing.Point(381, 77);
            this.clb_simple_compuesto.Name = "clb_simple_compuesto";
            this.clb_simple_compuesto.Size = new System.Drawing.Size(82, 34);
            this.clb_simple_compuesto.TabIndex = 25;
            this.clb_simple_compuesto.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.clb_simple_compuesto_ItemCheck);
            // 
            // dgv_productos
            // 
            this.dgv_productos.AllowUserToAddRows = false;
            this.dgv_productos.AllowUserToDeleteRows = false;
            this.dgv_productos.AllowUserToResizeColumns = false;
            this.dgv_productos.AllowUserToResizeRows = false;
            this.dgv_productos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_productos.Location = new System.Drawing.Point(7, 268);
            this.dgv_productos.Name = "dgv_productos";
            this.dgv_productos.ReadOnly = true;
            this.dgv_productos.RowHeadersVisible = false;
            this.dgv_productos.Size = new System.Drawing.Size(823, 124);
            this.dgv_productos.TabIndex = 24;
            this.dgv_productos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_productos_CellClick);
            // 
            // tp_materia
            // 
            this.tp_materia.Controls.Add(this.dgv_materias);
            this.tp_materia.Controls.Add(this.l_descripcion2);
            this.tp_materia.Controls.Add(this.b_agregar2);
            this.tp_materia.Controls.Add(this.b_modificar2);
            this.tp_materia.Controls.Add(this.b_eliminar2);
            this.tp_materia.Controls.Add(this.b_limpiar_campos2);
            this.tp_materia.Controls.Add(this.l_costo);
            this.tp_materia.Controls.Add(this.l_marca);
            this.tp_materia.Controls.Add(this.cb_marca);
            this.tp_materia.Controls.Add(this.txt_descripcion2);
            this.tp_materia.Controls.Add(this.txt_costo);
            this.tp_materia.Location = new System.Drawing.Point(4, 22);
            this.tp_materia.Name = "tp_materia";
            this.tp_materia.Padding = new System.Windows.Forms.Padding(3);
            this.tp_materia.Size = new System.Drawing.Size(836, 401);
            this.tp_materia.TabIndex = 1;
            this.tp_materia.Text = "Materia Prima";
            this.tp_materia.UseVisualStyleBackColor = true;
            // 
            // dgv_materias
            // 
            this.dgv_materias.AllowUserToAddRows = false;
            this.dgv_materias.AllowUserToDeleteRows = false;
            this.dgv_materias.AllowUserToResizeColumns = false;
            this.dgv_materias.AllowUserToResizeRows = false;
            this.dgv_materias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_materias.Location = new System.Drawing.Point(16, 171);
            this.dgv_materias.Name = "dgv_materias";
            this.dgv_materias.ReadOnly = true;
            this.dgv_materias.RowHeadersVisible = false;
            this.dgv_materias.Size = new System.Drawing.Size(792, 184);
            this.dgv_materias.TabIndex = 28;
            this.dgv_materias.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_materias_CellClick_1);
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
            // b_agregar2
            // 
            this.b_agregar2.Location = new System.Drawing.Point(697, 19);
            this.b_agregar2.Name = "b_agregar2";
            this.b_agregar2.Size = new System.Drawing.Size(112, 22);
            this.b_agregar2.TabIndex = 18;
            this.b_agregar2.Text = "Agregar";
            this.b_agregar2.UseVisualStyleBackColor = true;
            this.b_agregar2.Click += new System.EventHandler(this.b_agregar2_Click);
            // 
            // b_modificar2
            // 
            this.b_modificar2.Location = new System.Drawing.Point(697, 56);
            this.b_modificar2.Name = "b_modificar2";
            this.b_modificar2.Size = new System.Drawing.Size(112, 22);
            this.b_modificar2.TabIndex = 19;
            this.b_modificar2.Text = "Modificar";
            this.b_modificar2.UseVisualStyleBackColor = true;
            this.b_modificar2.Click += new System.EventHandler(this.b_modificar2_Click);
            // 
            // b_eliminar2
            // 
            this.b_eliminar2.Location = new System.Drawing.Point(697, 93);
            this.b_eliminar2.Name = "b_eliminar2";
            this.b_eliminar2.Size = new System.Drawing.Size(112, 22);
            this.b_eliminar2.TabIndex = 20;
            this.b_eliminar2.Text = "Eliminar";
            this.b_eliminar2.UseVisualStyleBackColor = true;
            this.b_eliminar2.Click += new System.EventHandler(this.b_eliminar2_Click);
            // 
            // b_limpiar_campos2
            // 
            this.b_limpiar_campos2.Location = new System.Drawing.Point(697, 132);
            this.b_limpiar_campos2.Name = "b_limpiar_campos2";
            this.b_limpiar_campos2.Size = new System.Drawing.Size(112, 22);
            this.b_limpiar_campos2.TabIndex = 21;
            this.b_limpiar_campos2.Text = "Limpiar Campos";
            this.b_limpiar_campos2.UseVisualStyleBackColor = true;
            this.b_limpiar_campos2.Click += new System.EventHandler(this.b_limpiar_campos2_Click);
            // 
            // l_costo
            // 
            this.l_costo.AutoSize = true;
            this.l_costo.Location = new System.Drawing.Point(42, 87);
            this.l_costo.Name = "l_costo";
            this.l_costo.Size = new System.Drawing.Size(34, 13);
            this.l_costo.TabIndex = 23;
            this.l_costo.Text = "Costo";
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
            // txt_descripcion2
            // 
            this.txt_descripcion2.Location = new System.Drawing.Point(82, 40);
            this.txt_descripcion2.MaxLength = 50;
            this.txt_descripcion2.Name = "txt_descripcion2";
            this.txt_descripcion2.Size = new System.Drawing.Size(193, 20);
            this.txt_descripcion2.TabIndex = 25;
            this.txt_descripcion2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_descripcion2_KeyDown);
            // 
            // txt_costo
            // 
            this.txt_costo.Location = new System.Drawing.Point(82, 84);
            this.txt_costo.MaxLength = 6;
            this.txt_costo.Name = "txt_costo";
            this.txt_costo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txt_costo.Size = new System.Drawing.Size(193, 20);
            this.txt_costo.TabIndex = 26;
            this.txt_costo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_costo_KeyDown);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgv_categoria);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.b_agregar4);
            this.tabPage1.Controls.Add(this.b_modificar4);
            this.tabPage1.Controls.Add(this.b_eliminar4);
            this.tabPage1.Controls.Add(this.b_limpiar_campos4);
            this.tabPage1.Controls.Add(this.txt_categoria);
            this.tabPage1.Controls.Add(this.dgv_marca);
            this.tabPage1.Controls.Add(this.l_marca2);
            this.tabPage1.Controls.Add(this.b_agregar3);
            this.tabPage1.Controls.Add(this.b_modificar3);
            this.tabPage1.Controls.Add(this.b_eliminar3);
            this.tabPage1.Controls.Add(this.b_limpiar_campos3);
            this.tabPage1.Controls.Add(this.txt_marca);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(836, 401);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Marcas y Categorías";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgv_categoria
            // 
            this.dgv_categoria.AllowUserToAddRows = false;
            this.dgv_categoria.AllowUserToDeleteRows = false;
            this.dgv_categoria.AllowUserToResizeColumns = false;
            this.dgv_categoria.AllowUserToResizeRows = false;
            this.dgv_categoria.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_categoria.Location = new System.Drawing.Point(448, 190);
            this.dgv_categoria.Name = "dgv_categoria";
            this.dgv_categoria.ReadOnly = true;
            this.dgv_categoria.RowHeadersVisible = false;
            this.dgv_categoria.Size = new System.Drawing.Size(360, 139);
            this.dgv_categoria.TabIndex = 39;
            this.dgv_categoria.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_categoria_CellClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(428, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 37;
            this.label3.Text = "Categoría";
            // 
            // b_agregar4
            // 
            this.b_agregar4.Location = new System.Drawing.Point(697, 22);
            this.b_agregar4.Name = "b_agregar4";
            this.b_agregar4.Size = new System.Drawing.Size(112, 22);
            this.b_agregar4.TabIndex = 33;
            this.b_agregar4.Text = "Agregar";
            this.b_agregar4.UseVisualStyleBackColor = true;
            this.b_agregar4.Click += new System.EventHandler(this.b_agregar4_Click);
            // 
            // b_modificar4
            // 
            this.b_modificar4.Location = new System.Drawing.Point(697, 59);
            this.b_modificar4.Name = "b_modificar4";
            this.b_modificar4.Size = new System.Drawing.Size(112, 22);
            this.b_modificar4.TabIndex = 34;
            this.b_modificar4.Text = "Modificar";
            this.b_modificar4.UseVisualStyleBackColor = true;
            this.b_modificar4.Click += new System.EventHandler(this.b_modificar4_Click);
            // 
            // b_eliminar4
            // 
            this.b_eliminar4.Location = new System.Drawing.Point(697, 96);
            this.b_eliminar4.Name = "b_eliminar4";
            this.b_eliminar4.Size = new System.Drawing.Size(112, 22);
            this.b_eliminar4.TabIndex = 35;
            this.b_eliminar4.Text = "Eliminar";
            this.b_eliminar4.UseVisualStyleBackColor = true;
            this.b_eliminar4.Click += new System.EventHandler(this.b_eliminar4_Click);
            // 
            // b_limpiar_campos4
            // 
            this.b_limpiar_campos4.Location = new System.Drawing.Point(697, 135);
            this.b_limpiar_campos4.Name = "b_limpiar_campos4";
            this.b_limpiar_campos4.Size = new System.Drawing.Size(112, 22);
            this.b_limpiar_campos4.TabIndex = 36;
            this.b_limpiar_campos4.Text = "Limpiar Campos";
            this.b_limpiar_campos4.UseVisualStyleBackColor = true;
            this.b_limpiar_campos4.Click += new System.EventHandler(this.b_limpiar4_campos_Click);
            // 
            // txt_categoria
            // 
            this.txt_categoria.Location = new System.Drawing.Point(488, 46);
            this.txt_categoria.MaxLength = 50;
            this.txt_categoria.Name = "txt_categoria";
            this.txt_categoria.Size = new System.Drawing.Size(190, 20);
            this.txt_categoria.TabIndex = 38;
            this.txt_categoria.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_categoria_KeyDown);
            // 
            // dgv_marca
            // 
            this.dgv_marca.AllowUserToAddRows = false;
            this.dgv_marca.AllowUserToDeleteRows = false;
            this.dgv_marca.AllowUserToResizeColumns = false;
            this.dgv_marca.AllowUserToResizeRows = false;
            this.dgv_marca.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_marca.Location = new System.Drawing.Point(18, 190);
            this.dgv_marca.Name = "dgv_marca";
            this.dgv_marca.ReadOnly = true;
            this.dgv_marca.RowHeadersVisible = false;
            this.dgv_marca.Size = new System.Drawing.Size(360, 139);
            this.dgv_marca.TabIndex = 32;
            this.dgv_marca.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_marca_CellClick);
            // 
            // l_marca2
            // 
            this.l_marca2.AutoSize = true;
            this.l_marca2.Location = new System.Drawing.Point(15, 49);
            this.l_marca2.Name = "l_marca2";
            this.l_marca2.Size = new System.Drawing.Size(37, 13);
            this.l_marca2.TabIndex = 30;
            this.l_marca2.Text = "Marca";
            // 
            // b_agregar3
            // 
            this.b_agregar3.Location = new System.Drawing.Point(267, 22);
            this.b_agregar3.Name = "b_agregar3";
            this.b_agregar3.Size = new System.Drawing.Size(112, 22);
            this.b_agregar3.TabIndex = 26;
            this.b_agregar3.Text = "Agregar";
            this.b_agregar3.UseVisualStyleBackColor = true;
            this.b_agregar3.Click += new System.EventHandler(this.b_agregar3_Click);
            // 
            // b_modificar3
            // 
            this.b_modificar3.Location = new System.Drawing.Point(267, 59);
            this.b_modificar3.Name = "b_modificar3";
            this.b_modificar3.Size = new System.Drawing.Size(112, 22);
            this.b_modificar3.TabIndex = 27;
            this.b_modificar3.Text = "Modificar";
            this.b_modificar3.UseVisualStyleBackColor = true;
            this.b_modificar3.Click += new System.EventHandler(this.b_modificar3_Click);
            // 
            // b_eliminar3
            // 
            this.b_eliminar3.Location = new System.Drawing.Point(267, 96);
            this.b_eliminar3.Name = "b_eliminar3";
            this.b_eliminar3.Size = new System.Drawing.Size(112, 22);
            this.b_eliminar3.TabIndex = 28;
            this.b_eliminar3.Text = "Eliminar";
            this.b_eliminar3.UseVisualStyleBackColor = true;
            this.b_eliminar3.Click += new System.EventHandler(this.b_eliminar3_Click);
            // 
            // b_limpiar_campos3
            // 
            this.b_limpiar_campos3.Location = new System.Drawing.Point(267, 135);
            this.b_limpiar_campos3.Name = "b_limpiar_campos3";
            this.b_limpiar_campos3.Size = new System.Drawing.Size(112, 22);
            this.b_limpiar_campos3.TabIndex = 29;
            this.b_limpiar_campos3.Text = "Limpiar Campos";
            this.b_limpiar_campos3.UseVisualStyleBackColor = true;
            this.b_limpiar_campos3.Click += new System.EventHandler(this.b_limpiar_campos3_Click);
            // 
            // txt_marca
            // 
            this.txt_marca.Location = new System.Drawing.Point(58, 46);
            this.txt_marca.MaxLength = 50;
            this.txt_marca.Name = "txt_marca";
            this.txt_marca.Size = new System.Drawing.Size(190, 20);
            this.txt_marca.TabIndex = 31;
            this.txt_marca.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_marca_KeyDown);
            // 
            // id_materia_producto
            // 
            this.id_materia_producto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.id_materia_producto.HeaderText = "ID";
            this.id_materia_producto.Name = "id_materia_producto";
            this.id_materia_producto.ReadOnly = true;
            this.id_materia_producto.Visible = false;
            // 
            // descripcion_materia
            // 
            this.descripcion_materia.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.descripcion_materia.HeaderText = "Descripción";
            this.descripcion_materia.Name = "descripcion_materia";
            this.descripcion_materia.ReadOnly = true;
            this.descripcion_materia.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // marca_materia
            // 
            this.marca_materia.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.marca_materia.HeaderText = "Marca";
            this.marca_materia.Name = "marca_materia";
            this.marca_materia.ReadOnly = true;
            this.marca_materia.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // costo_materia
            // 
            this.costo_materia.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.costo_materia.HeaderText = "Costo";
            this.costo_materia.Name = "costo_materia";
            this.costo_materia.ReadOnly = true;
            this.costo_materia.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.costo_materia.Width = 59;
            // 
            // cantidad_materia
            // 
            this.cantidad_materia.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.cantidad_materia.HeaderText = "Cantidad";
            this.cantidad_materia.MaxInputLength = 2;
            this.cantidad_materia.Name = "cantidad_materia";
            this.cantidad_materia.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.cantidad_materia.Width = 74;
            // 
            // Productos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(903, 428);
            this.Controls.Add(this.tc_formulario);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Productos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Productos";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Productos_FormClosed);
            this.Load += new System.EventHandler(this.Mesas_Load);
            this.Shown += new System.EventHandler(this.Productos_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_materia_prima)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_materia_producto)).EndInit();
            this.tc_formulario.ResumeLayout(false);
            this.tp_productos.ResumeLayout(false);
            this.tp_productos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_productos)).EndInit();
            this.tp_materia.ResumeLayout(false);
            this.tp_materia.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_materias)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_categoria)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_marca)).EndInit();
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
        private System.Windows.Forms.DataGridView dgv_materia_producto;
        private System.Windows.Forms.Button b_agregarmateria;
        private System.Windows.Forms.Button b_quitar;
        private System.Windows.Forms.TabControl tc_formulario;
        private System.Windows.Forms.TabPage tp_productos;
        private System.Windows.Forms.TabPage tp_materia;
        private System.Windows.Forms.DataGridView dgv_productos;
        private System.Windows.Forms.DataGridView dgv_materias;
        private System.Windows.Forms.Label l_descripcion2;
        private System.Windows.Forms.Button b_agregar2;
        private System.Windows.Forms.Button b_modificar2;
        private System.Windows.Forms.Button b_eliminar2;
        private System.Windows.Forms.Button b_limpiar_campos2;
        private System.Windows.Forms.Label l_costo;
        private System.Windows.Forms.Label l_marca;
        private System.Windows.Forms.ComboBox cb_marca;
        private System.Windows.Forms.TextBox txt_descripcion2;
        private System.Windows.Forms.TextBox txt_costo;
        private System.Windows.Forms.CheckedListBox clb_simple_compuesto;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dgv_categoria;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button b_agregar4;
        private System.Windows.Forms.Button b_modificar4;
        private System.Windows.Forms.Button b_eliminar4;
        private System.Windows.Forms.Button b_limpiar_campos4;
        private System.Windows.Forms.TextBox txt_categoria;
        private System.Windows.Forms.DataGridView dgv_marca;
        private System.Windows.Forms.Label l_marca2;
        private System.Windows.Forms.Button b_agregar3;
        private System.Windows.Forms.Button b_modificar3;
        private System.Windows.Forms.Button b_eliminar3;
        private System.Windows.Forms.Button b_limpiar_campos3;
        private System.Windows.Forms.TextBox txt_marca;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_materia_producto;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcion_materia;
        private System.Windows.Forms.DataGridViewTextBoxColumn marca_materia;
        private System.Windows.Forms.DataGridViewTextBoxColumn costo_materia;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidad_materia;
    }
}