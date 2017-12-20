namespace programa1
{
    partial class Mozos
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
            this.b_agregar = new System.Windows.Forms.Button();
            this.b_modificar = new System.Windows.Forms.Button();
            this.b_eliminar = new System.Windows.Forms.Button();
            this.b_limpiar_campos = new System.Windows.Forms.Button();
            this.l_nombre = new System.Windows.Forms.Label();
            this.l_apellido = new System.Windows.Forms.Label();
            this.l_DNI = new System.Windows.Forms.Label();
            this.txt_nombre = new System.Windows.Forms.TextBox();
            this.txt_apellido = new System.Windows.Forms.TextBox();
            this.txt_dni = new System.Windows.Forms.TextBox();
            this.l_fecha_nacimiento = new System.Windows.Forms.Label();
            this.l_telefono = new System.Windows.Forms.Label();
            this.l_direccion = new System.Windows.Forms.Label();
            this.txt_fecha_nacimiento = new System.Windows.Forms.TextBox();
            this.txt_direccion = new System.Windows.Forms.TextBox();
            this.txt_telefono = new System.Windows.Forms.TextBox();
            this.dgv_mozos = new System.Windows.Forms.DataGridView();
            this.lbl_fecha_nacimiento_ejemplo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_mozos)).BeginInit();
            this.SuspendLayout();
            // 
            // b_agregar
            // 
            this.b_agregar.Location = new System.Drawing.Point(715, 12);
            this.b_agregar.Name = "b_agregar";
            this.b_agregar.Size = new System.Drawing.Size(112, 22);
            this.b_agregar.TabIndex = 0;
            this.b_agregar.Text = "Agregar";
            this.b_agregar.UseVisualStyleBackColor = true;
            this.b_agregar.Click += new System.EventHandler(this.b_agregar_Click);
            // 
            // b_modificar
            // 
            this.b_modificar.Location = new System.Drawing.Point(715, 49);
            this.b_modificar.Name = "b_modificar";
            this.b_modificar.Size = new System.Drawing.Size(112, 22);
            this.b_modificar.TabIndex = 1;
            this.b_modificar.Text = "Modificar";
            this.b_modificar.UseVisualStyleBackColor = true;
            this.b_modificar.Click += new System.EventHandler(this.b_modificar_Click);
            // 
            // b_eliminar
            // 
            this.b_eliminar.Location = new System.Drawing.Point(715, 86);
            this.b_eliminar.Name = "b_eliminar";
            this.b_eliminar.Size = new System.Drawing.Size(112, 22);
            this.b_eliminar.TabIndex = 2;
            this.b_eliminar.Text = "Eliminar";
            this.b_eliminar.UseVisualStyleBackColor = true;
            this.b_eliminar.Click += new System.EventHandler(this.b_eliminar_Click);
            // 
            // b_limpiar_campos
            // 
            this.b_limpiar_campos.Location = new System.Drawing.Point(715, 125);
            this.b_limpiar_campos.Name = "b_limpiar_campos";
            this.b_limpiar_campos.Size = new System.Drawing.Size(112, 22);
            this.b_limpiar_campos.TabIndex = 3;
            this.b_limpiar_campos.Text = "Limpiar Campos";
            this.b_limpiar_campos.UseVisualStyleBackColor = true;
            this.b_limpiar_campos.Click += new System.EventHandler(this.b_limpiar_campos_Click);
            // 
            // l_nombre
            // 
            this.l_nombre.AutoSize = true;
            this.l_nombre.Location = new System.Drawing.Point(3, 13);
            this.l_nombre.Name = "l_nombre";
            this.l_nombre.Size = new System.Drawing.Size(44, 13);
            this.l_nombre.TabIndex = 4;
            this.l_nombre.Text = "Nombre";
            this.l_nombre.Click += new System.EventHandler(this.label1_Click);
            // 
            // l_apellido
            // 
            this.l_apellido.AutoSize = true;
            this.l_apellido.Location = new System.Drawing.Point(252, 15);
            this.l_apellido.Name = "l_apellido";
            this.l_apellido.Size = new System.Drawing.Size(44, 13);
            this.l_apellido.TabIndex = 5;
            this.l_apellido.Text = "Apellido";
            // 
            // l_DNI
            // 
            this.l_DNI.AutoSize = true;
            this.l_DNI.Location = new System.Drawing.Point(501, 17);
            this.l_DNI.Name = "l_DNI";
            this.l_DNI.Size = new System.Drawing.Size(26, 13);
            this.l_DNI.TabIndex = 6;
            this.l_DNI.Text = "DNI";
            // 
            // txt_nombre
            // 
            this.txt_nombre.Location = new System.Drawing.Point(53, 10);
            this.txt_nombre.MaxLength = 45;
            this.txt_nombre.Name = "txt_nombre";
            this.txt_nombre.Size = new System.Drawing.Size(193, 20);
            this.txt_nombre.TabIndex = 7;
            this.txt_nombre.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_nombre_KeyDown);
            this.txt_nombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_nombre_KeyPress_1);
            // 
            // txt_apellido
            // 
            this.txt_apellido.Location = new System.Drawing.Point(302, 12);
            this.txt_apellido.MaxLength = 45;
            this.txt_apellido.Name = "txt_apellido";
            this.txt_apellido.Size = new System.Drawing.Size(193, 20);
            this.txt_apellido.TabIndex = 8;
            this.txt_apellido.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_apellido_KeyDown);
            this.txt_apellido.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_apellido_KeyPress_1);
            // 
            // txt_dni
            // 
            this.txt_dni.Location = new System.Drawing.Point(533, 12);
            this.txt_dni.MaxLength = 8;
            this.txt_dni.Name = "txt_dni";
            this.txt_dni.Size = new System.Drawing.Size(164, 20);
            this.txt_dni.TabIndex = 9;
            this.txt_dni.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_dni_KeyPress_1);
            // 
            // l_fecha_nacimiento
            // 
            this.l_fecha_nacimiento.AutoSize = true;
            this.l_fecha_nacimiento.Location = new System.Drawing.Point(3, 58);
            this.l_fecha_nacimiento.Name = "l_fecha_nacimiento";
            this.l_fecha_nacimiento.Size = new System.Drawing.Size(108, 13);
            this.l_fecha_nacimiento.TabIndex = 10;
            this.l_fecha_nacimiento.Text = "Fecha de Nacimiento";
            // 
            // l_telefono
            // 
            this.l_telefono.AutoSize = true;
            this.l_telefono.Location = new System.Drawing.Point(501, 58);
            this.l_telefono.Name = "l_telefono";
            this.l_telefono.Size = new System.Drawing.Size(49, 13);
            this.l_telefono.TabIndex = 11;
            this.l_telefono.Text = "Teléfono";
            // 
            // l_direccion
            // 
            this.l_direccion.AutoSize = true;
            this.l_direccion.Location = new System.Drawing.Point(252, 58);
            this.l_direccion.Name = "l_direccion";
            this.l_direccion.Size = new System.Drawing.Size(52, 13);
            this.l_direccion.TabIndex = 12;
            this.l_direccion.Text = "Dirección";
            // 
            // txt_fecha_nacimiento
            // 
            this.txt_fecha_nacimiento.Location = new System.Drawing.Point(117, 55);
            this.txt_fecha_nacimiento.MaxLength = 10;
            this.txt_fecha_nacimiento.Name = "txt_fecha_nacimiento";
            this.txt_fecha_nacimiento.Size = new System.Drawing.Size(129, 20);
            this.txt_fecha_nacimiento.TabIndex = 13;
            // 
            // txt_direccion
            // 
            this.txt_direccion.Location = new System.Drawing.Point(310, 55);
            this.txt_direccion.MaxLength = 45;
            this.txt_direccion.Name = "txt_direccion";
            this.txt_direccion.Size = new System.Drawing.Size(185, 20);
            this.txt_direccion.TabIndex = 14;
            this.txt_direccion.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_direccion_KeyDown);
            // 
            // txt_telefono
            // 
            this.txt_telefono.Location = new System.Drawing.Point(556, 55);
            this.txt_telefono.MaxLength = 45;
            this.txt_telefono.Name = "txt_telefono";
            this.txt_telefono.Size = new System.Drawing.Size(141, 20);
            this.txt_telefono.TabIndex = 15;
            this.txt_telefono.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_telefono_KeyDown);
            // 
            // dgv_mozos
            // 
            this.dgv_mozos.AllowUserToAddRows = false;
            this.dgv_mozos.AllowUserToDeleteRows = false;
            this.dgv_mozos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_mozos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_mozos.Location = new System.Drawing.Point(11, 161);
            this.dgv_mozos.Name = "dgv_mozos";
            this.dgv_mozos.ReadOnly = true;
            this.dgv_mozos.Size = new System.Drawing.Size(815, 209);
            this.dgv_mozos.TabIndex = 16;
            this.dgv_mozos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_mozos_CellClick);
            // 
            // lbl_fecha_nacimiento_ejemplo
            // 
            this.lbl_fecha_nacimiento_ejemplo.AutoSize = true;
            this.lbl_fecha_nacimiento_ejemplo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_fecha_nacimiento_ejemplo.Location = new System.Drawing.Point(114, 78);
            this.lbl_fecha_nacimiento_ejemplo.Name = "lbl_fecha_nacimiento_ejemplo";
            this.lbl_fecha_nacimiento_ejemplo.Size = new System.Drawing.Size(80, 13);
            this.lbl_fecha_nacimiento_ejemplo.TabIndex = 18;
            this.lbl_fecha_nacimiento_ejemplo.Text = "Ej: 30/10/1990";
            // 
            // Mozos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 381);
            this.Controls.Add(this.lbl_fecha_nacimiento_ejemplo);
            this.Controls.Add(this.dgv_mozos);
            this.Controls.Add(this.txt_telefono);
            this.Controls.Add(this.txt_direccion);
            this.Controls.Add(this.txt_fecha_nacimiento);
            this.Controls.Add(this.l_direccion);
            this.Controls.Add(this.l_telefono);
            this.Controls.Add(this.l_fecha_nacimiento);
            this.Controls.Add(this.txt_dni);
            this.Controls.Add(this.txt_apellido);
            this.Controls.Add(this.txt_nombre);
            this.Controls.Add(this.l_DNI);
            this.Controls.Add(this.l_apellido);
            this.Controls.Add(this.l_nombre);
            this.Controls.Add(this.b_limpiar_campos);
            this.Controls.Add(this.b_eliminar);
            this.Controls.Add(this.b_modificar);
            this.Controls.Add(this.b_agregar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Mozos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mozos";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Mozos_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_mozos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button b_agregar;
        private System.Windows.Forms.Button b_modificar;
        private System.Windows.Forms.Button b_eliminar;
        private System.Windows.Forms.Button b_limpiar_campos;
        private System.Windows.Forms.Label l_nombre;
        private System.Windows.Forms.Label l_apellido;
        private System.Windows.Forms.Label l_DNI;
        private System.Windows.Forms.TextBox txt_nombre;
        private System.Windows.Forms.TextBox txt_apellido;
        private System.Windows.Forms.TextBox txt_dni;
        private System.Windows.Forms.Label l_fecha_nacimiento;
        private System.Windows.Forms.Label l_telefono;
        private System.Windows.Forms.Label l_direccion;
        private System.Windows.Forms.TextBox txt_fecha_nacimiento;
        private System.Windows.Forms.TextBox txt_direccion;
        private System.Windows.Forms.TextBox txt_telefono;
        private System.Windows.Forms.DataGridView dgv_mozos;
        private System.Windows.Forms.Label lbl_fecha_nacimiento_ejemplo;
    }
}