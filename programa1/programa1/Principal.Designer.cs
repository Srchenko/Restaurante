namespace programa1
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
            this.mesa18_kruger = new System.Windows.Forms.Button();
            this.mesa17_neptuno = new System.Windows.Forms.Button();
            this.mesa20_alba = new System.Windows.Forms.Button();
            this.mesa19_dragon = new System.Windows.Forms.Button();
            this.mesa2_beta = new System.Windows.Forms.Button();
            this.mesa1_alpha = new System.Windows.Forms.Button();
            this.mesa3_gamma = new System.Windows.Forms.Button();
            this.mesa4_delta = new System.Windows.Forms.Button();
            this.mesa5_epsilon = new System.Windows.Forms.Button();
            this.mesa6_theta = new System.Windows.Forms.Button();
            this.mesa7_kappa = new System.Windows.Forms.Button();
            this.mesa8_lambda = new System.Windows.Forms.Button();
            this.mesa9_sigma = new System.Windows.Forms.Button();
            this.mesa10_omega = new System.Windows.Forms.Button();
            this.mesa11_minerva = new System.Windows.Forms.Button();
            this.mesa12_bravo = new System.Windows.Forms.Button();
            this.mesa13_charlie = new System.Windows.Forms.Button();
            this.mesa14_zeta = new System.Windows.Forms.Button();
            this.mesa15_cobra = new System.Windows.Forms.Button();
            this.mesa16_saturno = new System.Windows.Forms.Button();
            this.reportesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.preciosPorCategoríasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.preciosPorCategoríasToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ventasDiariasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ventasPorMozoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.tabla_mesas.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aBMMozosToolStripMenuItem,
            this.reportesToolStripMenuItem});
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
            this.mozosToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.mozosToolStripMenuItem.Text = "Productos";
            this.mozosToolStripMenuItem.Click += new System.EventHandler(this.mozosToolStripMenuItem_Click);
            // 
            // mozosToolStripMenuItem1
            // 
            this.mozosToolStripMenuItem1.Name = "mozosToolStripMenuItem1";
            this.mozosToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.mozosToolStripMenuItem1.Text = "Mozos";
            this.mozosToolStripMenuItem1.Click += new System.EventHandler(this.mozosToolStripMenuItem1_Click);
            // 
            // tabla_mesas
            // 
            this.tabla_mesas.BackColor = System.Drawing.Color.Transparent;
            this.tabla_mesas.ColumnCount = 4;
            this.tabla_mesas.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tabla_mesas.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tabla_mesas.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tabla_mesas.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tabla_mesas.Controls.Add(this.mesa18_kruger, 0, 4);
            this.tabla_mesas.Controls.Add(this.mesa17_neptuno, 0, 4);
            this.tabla_mesas.Controls.Add(this.mesa20_alba, 0, 4);
            this.tabla_mesas.Controls.Add(this.mesa19_dragon, 0, 4);
            this.tabla_mesas.Controls.Add(this.mesa2_beta, 1, 0);
            this.tabla_mesas.Controls.Add(this.mesa1_alpha, 0, 0);
            this.tabla_mesas.Controls.Add(this.mesa3_gamma, 2, 0);
            this.tabla_mesas.Controls.Add(this.mesa4_delta, 3, 0);
            this.tabla_mesas.Controls.Add(this.mesa5_epsilon, 0, 1);
            this.tabla_mesas.Controls.Add(this.mesa6_theta, 1, 1);
            this.tabla_mesas.Controls.Add(this.mesa7_kappa, 2, 1);
            this.tabla_mesas.Controls.Add(this.mesa8_lambda, 3, 1);
            this.tabla_mesas.Controls.Add(this.mesa9_sigma, 0, 2);
            this.tabla_mesas.Controls.Add(this.mesa10_omega, 1, 2);
            this.tabla_mesas.Controls.Add(this.mesa11_minerva, 2, 2);
            this.tabla_mesas.Controls.Add(this.mesa12_bravo, 3, 2);
            this.tabla_mesas.Controls.Add(this.mesa13_charlie, 0, 3);
            this.tabla_mesas.Controls.Add(this.mesa14_zeta, 1, 3);
            this.tabla_mesas.Controls.Add(this.mesa15_cobra, 2, 3);
            this.tabla_mesas.Controls.Add(this.mesa16_saturno, 3, 3);
            this.tabla_mesas.Location = new System.Drawing.Point(12, 36);
            this.tabla_mesas.Name = "tabla_mesas";
            this.tabla_mesas.RowCount = 5;
            this.tabla_mesas.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tabla_mesas.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tabla_mesas.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tabla_mesas.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tabla_mesas.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tabla_mesas.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tabla_mesas.Size = new System.Drawing.Size(1240, 633);
            this.tabla_mesas.TabIndex = 2;
            // 
            // mesa18_kruger
            // 
            this.mesa18_kruger.Font = new System.Drawing.Font("Lucida Sans", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mesa18_kruger.Location = new System.Drawing.Point(313, 507);
            this.mesa18_kruger.Name = "mesa18_kruger";
            this.mesa18_kruger.Size = new System.Drawing.Size(304, 120);
            this.mesa18_kruger.TabIndex = 17;
            this.mesa18_kruger.Text = "MESA Nº 18\r\nKRUGER\r\n8 Personas";
            this.mesa18_kruger.UseVisualStyleBackColor = true;
            this.mesa18_kruger.Click += new System.EventHandler(this.mesa18_kruger_Click);
            // 
            // mesa17_neptuno
            // 
            this.mesa17_neptuno.Font = new System.Drawing.Font("Lucida Sans", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mesa17_neptuno.Location = new System.Drawing.Point(3, 507);
            this.mesa17_neptuno.Name = "mesa17_neptuno";
            this.mesa17_neptuno.Size = new System.Drawing.Size(304, 120);
            this.mesa17_neptuno.TabIndex = 16;
            this.mesa17_neptuno.Text = "MESA Nº 17\r\nNEPTUNO\r\n6 Personas";
            this.mesa17_neptuno.UseVisualStyleBackColor = true;
            this.mesa17_neptuno.Click += new System.EventHandler(this.mesa17_neptuno_Click);
            // 
            // mesa20_alba
            // 
            this.mesa20_alba.Font = new System.Drawing.Font("Lucida Sans", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mesa20_alba.Location = new System.Drawing.Point(933, 507);
            this.mesa20_alba.Name = "mesa20_alba";
            this.mesa20_alba.Size = new System.Drawing.Size(304, 120);
            this.mesa20_alba.TabIndex = 19;
            this.mesa20_alba.Text = "MESA Nº 20\r\nALBA\r\n4 Personas";
            this.mesa20_alba.UseVisualStyleBackColor = true;
            this.mesa20_alba.Click += new System.EventHandler(this.mesa20_alba_Click);
            // 
            // mesa19_dragon
            // 
            this.mesa19_dragon.Font = new System.Drawing.Font("Lucida Sans", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mesa19_dragon.Location = new System.Drawing.Point(623, 507);
            this.mesa19_dragon.Name = "mesa19_dragon";
            this.mesa19_dragon.Size = new System.Drawing.Size(304, 120);
            this.mesa19_dragon.TabIndex = 18;
            this.mesa19_dragon.Text = "MESA Nº 19\r\nDRAGON\r\n6 Personas";
            this.mesa19_dragon.UseVisualStyleBackColor = true;
            this.mesa19_dragon.Click += new System.EventHandler(this.mesa19_dragon_Click);
            // 
            // mesa2_beta
            // 
            this.mesa2_beta.Font = new System.Drawing.Font("Lucida Sans", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mesa2_beta.Location = new System.Drawing.Point(313, 3);
            this.mesa2_beta.Name = "mesa2_beta";
            this.mesa2_beta.Size = new System.Drawing.Size(304, 120);
            this.mesa2_beta.TabIndex = 1;
            this.mesa2_beta.Text = "MESA Nº 2\r\nBETA\r\n69 Personas";
            this.mesa2_beta.UseVisualStyleBackColor = true;
            this.mesa2_beta.Click += new System.EventHandler(this.mesa2_beta_Click_1);
            // 
            // mesa1_alpha
            // 
            this.mesa1_alpha.Font = new System.Drawing.Font("Lucida Sans", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mesa1_alpha.Location = new System.Drawing.Point(3, 3);
            this.mesa1_alpha.Name = "mesa1_alpha";
            this.mesa1_alpha.Size = new System.Drawing.Size(304, 120);
            this.mesa1_alpha.TabIndex = 0;
            this.mesa1_alpha.Text = "MESA Nº 1\r\nALPHA\r\n1 Persona";
            this.mesa1_alpha.UseVisualStyleBackColor = true;
            this.mesa1_alpha.Click += new System.EventHandler(this.mesa1_alpha_Click_1);
            // 
            // mesa3_gamma
            // 
            this.mesa3_gamma.Font = new System.Drawing.Font("Lucida Sans", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mesa3_gamma.Location = new System.Drawing.Point(623, 3);
            this.mesa3_gamma.Name = "mesa3_gamma";
            this.mesa3_gamma.Size = new System.Drawing.Size(304, 120);
            this.mesa3_gamma.TabIndex = 2;
            this.mesa3_gamma.Text = "MESA Nº 3\r\nGAMMA\r\n3 Personas";
            this.mesa3_gamma.UseVisualStyleBackColor = true;
            this.mesa3_gamma.Click += new System.EventHandler(this.mesa3_gamma_Click);
            // 
            // mesa4_delta
            // 
            this.mesa4_delta.Font = new System.Drawing.Font("Lucida Sans", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mesa4_delta.Location = new System.Drawing.Point(933, 3);
            this.mesa4_delta.Name = "mesa4_delta";
            this.mesa4_delta.Size = new System.Drawing.Size(304, 120);
            this.mesa4_delta.TabIndex = 3;
            this.mesa4_delta.Text = "MESA Nº 4\r\nDELTA\r\n9 Personas";
            this.mesa4_delta.UseVisualStyleBackColor = true;
            this.mesa4_delta.Click += new System.EventHandler(this.mesa4_delta_Click);
            // 
            // mesa5_epsilon
            // 
            this.mesa5_epsilon.Font = new System.Drawing.Font("Lucida Sans", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mesa5_epsilon.Location = new System.Drawing.Point(3, 129);
            this.mesa5_epsilon.Name = "mesa5_epsilon";
            this.mesa5_epsilon.Size = new System.Drawing.Size(304, 120);
            this.mesa5_epsilon.TabIndex = 4;
            this.mesa5_epsilon.Text = "MESA Nº 5\r\nEPSILON\r\n5 Personas";
            this.mesa5_epsilon.UseVisualStyleBackColor = true;
            this.mesa5_epsilon.Click += new System.EventHandler(this.mesa5_epsilon_Click);
            // 
            // mesa6_theta
            // 
            this.mesa6_theta.Font = new System.Drawing.Font("Lucida Sans", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mesa6_theta.Location = new System.Drawing.Point(313, 129);
            this.mesa6_theta.Name = "mesa6_theta";
            this.mesa6_theta.Size = new System.Drawing.Size(304, 120);
            this.mesa6_theta.TabIndex = 5;
            this.mesa6_theta.Text = "MESA Nº 6\r\nTHETA\r\n4 Personas";
            this.mesa6_theta.UseVisualStyleBackColor = true;
            this.mesa6_theta.Click += new System.EventHandler(this.mesa6_theta_Click);
            // 
            // mesa7_kappa
            // 
            this.mesa7_kappa.Font = new System.Drawing.Font("Lucida Sans", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mesa7_kappa.Location = new System.Drawing.Point(623, 129);
            this.mesa7_kappa.Name = "mesa7_kappa";
            this.mesa7_kappa.Size = new System.Drawing.Size(304, 120);
            this.mesa7_kappa.TabIndex = 6;
            this.mesa7_kappa.Text = "MESA Nº 7\r\nKAPPA\r\n15 Personas";
            this.mesa7_kappa.UseVisualStyleBackColor = true;
            this.mesa7_kappa.Click += new System.EventHandler(this.mesa7_kappa_Click);
            // 
            // mesa8_lambda
            // 
            this.mesa8_lambda.Font = new System.Drawing.Font("Lucida Sans", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mesa8_lambda.Location = new System.Drawing.Point(933, 129);
            this.mesa8_lambda.Name = "mesa8_lambda";
            this.mesa8_lambda.Size = new System.Drawing.Size(304, 120);
            this.mesa8_lambda.TabIndex = 7;
            this.mesa8_lambda.Text = "MESA Nº 8\r\nLAMBDA\r\n2 Personas";
            this.mesa8_lambda.UseVisualStyleBackColor = true;
            this.mesa8_lambda.Click += new System.EventHandler(this.mesa8_lambda_Click);
            // 
            // mesa9_sigma
            // 
            this.mesa9_sigma.Font = new System.Drawing.Font("Lucida Sans", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mesa9_sigma.Location = new System.Drawing.Point(3, 255);
            this.mesa9_sigma.Name = "mesa9_sigma";
            this.mesa9_sigma.Size = new System.Drawing.Size(304, 120);
            this.mesa9_sigma.TabIndex = 8;
            this.mesa9_sigma.Text = "MESA Nº 9\r\nSIGMA\r\n7 Personas";
            this.mesa9_sigma.UseVisualStyleBackColor = true;
            this.mesa9_sigma.Click += new System.EventHandler(this.mesa9_sigma_Click);
            // 
            // mesa10_omega
            // 
            this.mesa10_omega.Font = new System.Drawing.Font("Lucida Sans", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mesa10_omega.Location = new System.Drawing.Point(313, 255);
            this.mesa10_omega.Name = "mesa10_omega";
            this.mesa10_omega.Size = new System.Drawing.Size(304, 120);
            this.mesa10_omega.TabIndex = 9;
            this.mesa10_omega.Text = "MESA Nº 10\r\nOMEGA\r\n11 Personas";
            this.mesa10_omega.UseVisualStyleBackColor = true;
            this.mesa10_omega.Click += new System.EventHandler(this.mesa10_omega_Click);
            // 
            // mesa11_minerva
            // 
            this.mesa11_minerva.Font = new System.Drawing.Font("Lucida Sans", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mesa11_minerva.Location = new System.Drawing.Point(623, 255);
            this.mesa11_minerva.Name = "mesa11_minerva";
            this.mesa11_minerva.Size = new System.Drawing.Size(304, 120);
            this.mesa11_minerva.TabIndex = 10;
            this.mesa11_minerva.Text = "MESA Nº 11\r\nMINERVA\r\n6 Personas";
            this.mesa11_minerva.UseVisualStyleBackColor = true;
            this.mesa11_minerva.Click += new System.EventHandler(this.mesa11_minerva_Click);
            // 
            // mesa12_bravo
            // 
            this.mesa12_bravo.Font = new System.Drawing.Font("Lucida Sans", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mesa12_bravo.Location = new System.Drawing.Point(933, 255);
            this.mesa12_bravo.Name = "mesa12_bravo";
            this.mesa12_bravo.Size = new System.Drawing.Size(304, 120);
            this.mesa12_bravo.TabIndex = 11;
            this.mesa12_bravo.Text = "MESA Nº 12\r\nBRAVO\r\n8 Personas";
            this.mesa12_bravo.UseVisualStyleBackColor = true;
            this.mesa12_bravo.Click += new System.EventHandler(this.mesa12_bravo_Click);
            // 
            // mesa13_charlie
            // 
            this.mesa13_charlie.Font = new System.Drawing.Font("Lucida Sans", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mesa13_charlie.Location = new System.Drawing.Point(3, 381);
            this.mesa13_charlie.Name = "mesa13_charlie";
            this.mesa13_charlie.Size = new System.Drawing.Size(304, 120);
            this.mesa13_charlie.TabIndex = 12;
            this.mesa13_charlie.Text = "MESA Nº 13\r\nCHARLIE\r\n4 Personas";
            this.mesa13_charlie.UseVisualStyleBackColor = true;
            this.mesa13_charlie.Click += new System.EventHandler(this.mesa13_charlie_Click);
            // 
            // mesa14_zeta
            // 
            this.mesa14_zeta.Font = new System.Drawing.Font("Lucida Sans", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mesa14_zeta.Location = new System.Drawing.Point(313, 381);
            this.mesa14_zeta.Name = "mesa14_zeta";
            this.mesa14_zeta.Size = new System.Drawing.Size(304, 120);
            this.mesa14_zeta.TabIndex = 13;
            this.mesa14_zeta.Text = "MESA Nº 14\r\nZETA\r\n2 Personas";
            this.mesa14_zeta.UseVisualStyleBackColor = true;
            this.mesa14_zeta.Click += new System.EventHandler(this.mesa14_zeta_Click);
            // 
            // mesa15_cobra
            // 
            this.mesa15_cobra.Font = new System.Drawing.Font("Lucida Sans", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mesa15_cobra.Location = new System.Drawing.Point(623, 381);
            this.mesa15_cobra.Name = "mesa15_cobra";
            this.mesa15_cobra.Size = new System.Drawing.Size(304, 120);
            this.mesa15_cobra.TabIndex = 14;
            this.mesa15_cobra.Text = "MESA Nº 15\r\nCOBRA\r\n2 Personas";
            this.mesa15_cobra.UseVisualStyleBackColor = true;
            this.mesa15_cobra.Click += new System.EventHandler(this.mesa15_cobra_Click);
            // 
            // mesa16_saturno
            // 
            this.mesa16_saturno.Font = new System.Drawing.Font("Lucida Sans", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mesa16_saturno.Location = new System.Drawing.Point(933, 381);
            this.mesa16_saturno.Name = "mesa16_saturno";
            this.mesa16_saturno.Size = new System.Drawing.Size(304, 120);
            this.mesa16_saturno.TabIndex = 15;
            this.mesa16_saturno.Text = "MESA Nº 16\r\nSATURNO\r\n2 Personas";
            this.mesa16_saturno.UseVisualStyleBackColor = true;
            this.mesa16_saturno.Click += new System.EventHandler(this.mesa16_saturno_Click);
            // 
            // reportesToolStripMenuItem
            // 
            this.reportesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.preciosPorCategoríasToolStripMenuItem,
            this.preciosPorCategoríasToolStripMenuItem1,
            this.ventasDiariasToolStripMenuItem,
            this.ventasPorMozoToolStripMenuItem});
            this.reportesToolStripMenuItem.Name = "reportesToolStripMenuItem";
            this.reportesToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.reportesToolStripMenuItem.Text = "Reportes";
            // 
            // preciosPorCategoríasToolStripMenuItem
            // 
            this.preciosPorCategoríasToolStripMenuItem.Name = "preciosPorCategoríasToolStripMenuItem";
            this.preciosPorCategoríasToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.preciosPorCategoríasToolStripMenuItem.Text = "Materia Prima Utilizada";
            // 
            // preciosPorCategoríasToolStripMenuItem1
            // 
            this.preciosPorCategoríasToolStripMenuItem1.Name = "preciosPorCategoríasToolStripMenuItem1";
            this.preciosPorCategoríasToolStripMenuItem1.Size = new System.Drawing.Size(196, 22);
            this.preciosPorCategoríasToolStripMenuItem1.Text = "Precios por Categorías";
            // 
            // ventasDiariasToolStripMenuItem
            // 
            this.ventasDiariasToolStripMenuItem.Name = "ventasDiariasToolStripMenuItem";
            this.ventasDiariasToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.ventasDiariasToolStripMenuItem.Text = "Ventas Diarias";
            // 
            // ventasPorMozoToolStripMenuItem
            // 
            this.ventasPorMozoToolStripMenuItem.Name = "ventasPorMozoToolStripMenuItem";
            this.ventasPorMozoToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.ventasPorMozoToolStripMenuItem.Text = "Ventas por Mozo";
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
        private System.Windows.Forms.Button mesa2_beta;
        private System.Windows.Forms.Button mesa1_alpha;
        private System.Windows.Forms.Button mesa3_gamma;
        private System.Windows.Forms.Button mesa4_delta;
        private System.Windows.Forms.Button mesa5_epsilon;
        private System.Windows.Forms.Button mesa6_theta;
        private System.Windows.Forms.Button mesa7_kappa;
        private System.Windows.Forms.Button mesa8_lambda;
        private System.Windows.Forms.Button mesa9_sigma;
        private System.Windows.Forms.Button mesa10_omega;
        private System.Windows.Forms.Button mesa18_kruger;
        private System.Windows.Forms.Button mesa17_neptuno;
        private System.Windows.Forms.Button mesa20_alba;
        private System.Windows.Forms.Button mesa19_dragon;
        private System.Windows.Forms.Button mesa11_minerva;
        private System.Windows.Forms.Button mesa12_bravo;
        private System.Windows.Forms.Button mesa13_charlie;
        private System.Windows.Forms.Button mesa14_zeta;
        private System.Windows.Forms.Button mesa15_cobra;
        private System.Windows.Forms.Button mesa16_saturno;
        private System.Windows.Forms.ToolStripMenuItem reportesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem preciosPorCategoríasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem preciosPorCategoríasToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem ventasDiariasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ventasPorMozoToolStripMenuItem;
    }
}

