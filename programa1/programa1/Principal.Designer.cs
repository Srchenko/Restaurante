﻿namespace programa1
{
    partial class Principal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.aBMMozosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mozosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mozosToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tabla_mesas = new System.Windows.Forms.TableLayoutPanel();
            this.mesa1_alpha = new System.Windows.Forms.Button();
            this.mesa2_beta = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.tabla_mesas.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aBMMozosToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1264, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // aBMMozosToolStripMenuItem
            // 
            this.aBMMozosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mozosToolStripMenuItem,
            this.mozosToolStripMenuItem1});
            this.aBMMozosToolStripMenuItem.Name = "aBMMozosToolStripMenuItem";
            this.aBMMozosToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.aBMMozosToolStripMenuItem.Text = "Archivo";
            this.aBMMozosToolStripMenuItem.Click += new System.EventHandler(this.aBMMozosToolStripMenuItem_Click);
            // 
            // mozosToolStripMenuItem
            // 
            this.mozosToolStripMenuItem.Name = "mozosToolStripMenuItem";
            this.mozosToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.mozosToolStripMenuItem.Text = "Mesas";
            this.mozosToolStripMenuItem.Click += new System.EventHandler(this.mozosToolStripMenuItem_Click);
            // 
            // mozosToolStripMenuItem1
            // 
            this.mozosToolStripMenuItem1.Name = "mozosToolStripMenuItem1";
            this.mozosToolStripMenuItem1.Size = new System.Drawing.Size(109, 22);
            this.mozosToolStripMenuItem1.Text = "Mozos";
            this.mozosToolStripMenuItem1.Click += new System.EventHandler(this.mozosToolStripMenuItem1_Click);
            // 
            // tabla_mesas
            // 
            this.tabla_mesas.BackColor = System.Drawing.Color.Transparent;
            this.tabla_mesas.ColumnCount = 5;
            this.tabla_mesas.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tabla_mesas.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tabla_mesas.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tabla_mesas.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tabla_mesas.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tabla_mesas.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tabla_mesas.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tabla_mesas.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tabla_mesas.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tabla_mesas.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tabla_mesas.Controls.Add(this.mesa2_beta, 1, 0);
            this.tabla_mesas.Controls.Add(this.mesa1_alpha, 0, 0);
            this.tabla_mesas.Location = new System.Drawing.Point(12, 27);
            this.tabla_mesas.Name = "tabla_mesas";
            this.tabla_mesas.RowCount = 4;
            this.tabla_mesas.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tabla_mesas.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tabla_mesas.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tabla_mesas.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tabla_mesas.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tabla_mesas.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tabla_mesas.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tabla_mesas.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tabla_mesas.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tabla_mesas.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tabla_mesas.Size = new System.Drawing.Size(1240, 642);
            this.tabla_mesas.TabIndex = 2;
            // 
            // mesa1_alpha
            // 
            this.mesa1_alpha.BackColor = System.Drawing.Color.Transparent;
            this.mesa1_alpha.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mesa1_alpha.Location = new System.Drawing.Point(3, 3);
            this.mesa1_alpha.Name = "mesa1_alpha";
            this.mesa1_alpha.Size = new System.Drawing.Size(242, 154);
            this.mesa1_alpha.TabIndex = 0;
            this.mesa1_alpha.Text = "MESA Nº 1\r\nALPHA\r\n1 Persona";
            this.mesa1_alpha.UseVisualStyleBackColor = false;
            this.mesa1_alpha.Click += new System.EventHandler(this.mesa1_alpha_Click);
            // 
            // mesa2_beta
            // 
            this.mesa2_beta.BackColor = System.Drawing.Color.Transparent;
            this.mesa2_beta.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mesa2_beta.ForeColor = System.Drawing.SystemColors.ControlText;
            this.mesa2_beta.Location = new System.Drawing.Point(251, 3);
            this.mesa2_beta.Name = "mesa2_beta";
            this.mesa2_beta.Size = new System.Drawing.Size(242, 154);
            this.mesa2_beta.TabIndex = 1;
            this.mesa2_beta.Text = "MESA Nº 2\r\nBETA\r\n69 Personas";
            this.mesa2_beta.UseVisualStyleBackColor = false;
            this.mesa2_beta.Click += new System.EventHandler(this.mesa2_beta_Click);
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.tabla_mesas);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Principal";
            this.Text = "Pantalla Principal";
            this.Load += new System.EventHandler(this.Principal_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabla_mesas.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem aBMMozosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mozosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mozosToolStripMenuItem1;
        private System.Windows.Forms.TableLayoutPanel tabla_mesas;
        private System.Windows.Forms.Button mesa1_alpha;
        private System.Windows.Forms.Button mesa2_beta;
    }
}

