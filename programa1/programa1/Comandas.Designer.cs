﻿namespace programa1
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
            this.lista_mozos = new System.Windows.Forms.ComboBox();
            this.lbl_seleccionar_mozo = new System.Windows.Forms.Label();
            this.bt_modificar_salir = new System.Windows.Forms.Button();
            this.bt_finalizar_comanda = new System.Windows.Forms.Button();
            this.dgv_comandas_detalle = new System.Windows.Forms.DataGridView();
            this.Columna_Producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Columna_Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Columna_Subtotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_comandas_detalle)).BeginInit();
            this.SuspendLayout();
            // 
            // lista_mozos
            // 
            this.lista_mozos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lista_mozos.FormattingEnabled = true;
            this.lista_mozos.Location = new System.Drawing.Point(12, 36);
            this.lista_mozos.Name = "lista_mozos";
            this.lista_mozos.Size = new System.Drawing.Size(317, 21);
            this.lista_mozos.TabIndex = 0;
            // 
            // lbl_seleccionar_mozo
            // 
            this.lbl_seleccionar_mozo.AutoSize = true;
            this.lbl_seleccionar_mozo.Location = new System.Drawing.Point(9, 9);
            this.lbl_seleccionar_mozo.Name = "lbl_seleccionar_mozo";
            this.lbl_seleccionar_mozo.Size = new System.Drawing.Size(103, 13);
            this.lbl_seleccionar_mozo.TabIndex = 1;
            this.lbl_seleccionar_mozo.Text = "Seleccione un mozo";
            // 
            // bt_modificar_salir
            // 
            this.bt_modificar_salir.Location = new System.Drawing.Point(97, 95);
            this.bt_modificar_salir.Name = "bt_modificar_salir";
            this.bt_modificar_salir.Size = new System.Drawing.Size(125, 30);
            this.bt_modificar_salir.TabIndex = 2;
            this.bt_modificar_salir.Text = "Modificar y Salir";
            this.bt_modificar_salir.UseVisualStyleBackColor = true;
            // 
            // bt_finalizar_comanda
            // 
            this.bt_finalizar_comanda.Location = new System.Drawing.Point(97, 149);
            this.bt_finalizar_comanda.Name = "bt_finalizar_comanda";
            this.bt_finalizar_comanda.Size = new System.Drawing.Size(125, 30);
            this.bt_finalizar_comanda.TabIndex = 3;
            this.bt_finalizar_comanda.Text = "Finalizar Comanda";
            this.bt_finalizar_comanda.UseVisualStyleBackColor = true;
            // 
            // dgv_comandas_detalle
            // 
            this.dgv_comandas_detalle.AllowUserToDeleteRows = false;
            this.dgv_comandas_detalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_comandas_detalle.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Columna_Producto,
            this.Columna_Cantidad,
            this.Columna_Subtotal});
            this.dgv_comandas_detalle.Location = new System.Drawing.Point(352, 9);
            this.dgv_comandas_detalle.Name = "dgv_comandas_detalle";
            this.dgv_comandas_detalle.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgv_comandas_detalle.Size = new System.Drawing.Size(480, 360);
            this.dgv_comandas_detalle.TabIndex = 4;
            // 
            // Columna_Producto
            // 
            this.Columna_Producto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Columna_Producto.HeaderText = "Producto";
            this.Columna_Producto.MaxInputLength = 50;
            this.Columna_Producto.Name = "Columna_Producto";
            this.Columna_Producto.Width = 300;
            // 
            // Columna_Cantidad
            // 
            this.Columna_Cantidad.HeaderText = "Cantidad";
            this.Columna_Cantidad.MaxInputLength = 2;
            this.Columna_Cantidad.Name = "Columna_Cantidad";
            this.Columna_Cantidad.Width = 60;
            // 
            // Columna_Subtotal
            // 
            this.Columna_Subtotal.HeaderText = "Subtotal";
            this.Columna_Subtotal.Name = "Columna_Subtotal";
            this.Columna_Subtotal.Width = 77;
            // 
            // Comandas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 381);
            this.Controls.Add(this.dgv_comandas_detalle);
            this.Controls.Add(this.bt_finalizar_comanda);
            this.Controls.Add(this.bt_modificar_salir);
            this.Controls.Add(this.lbl_seleccionar_mozo);
            this.Controls.Add(this.lista_mozos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Comandas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Comandas";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Comandas_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_comandas_detalle)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox lista_mozos;
        private System.Windows.Forms.Label lbl_seleccionar_mozo;
        private System.Windows.Forms.Button bt_modificar_salir;
        private System.Windows.Forms.Button bt_finalizar_comanda;
        private System.Windows.Forms.DataGridView dgv_comandas_detalle;
        private System.Windows.Forms.DataGridViewTextBoxColumn Columna_Producto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Columna_Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Columna_Subtotal;
    }
}