using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace programa1
{
    public partial class Principal : Form
    {
        SqlConnection conexion = new SqlConnection("Data Source=SRCHENKO-PC\\SQLEXPRESS;Initial Catalog=Restaurante;Integrated Security=True");

        public Principal()
        {
            InitializeComponent();
            cambiar_color_boton();
        }

        private void abrir_comanda(int valor)
        {
            string error = "Faltan datos de: ";
            int contador = 0;
            conexion.Open();
            SqlCommand comando = new SqlCommand("SELECT id_mozo FROM Mozos WHERE baja=0", conexion);
            SqlDataReader datos = comando.ExecuteReader();
            if (!datos.Read())
            {
                contador = contador + 1;
                error += "mozos ";
            }
            datos.Close();

            SqlCommand comando2 = new SqlCommand("SELECT id_producto FROM Productos WHERE baja=0", conexion);
            SqlDataReader datos2 = comando2.ExecuteReader();
            if (!datos2.Read())
            {
                if (contador == 1)
                {
                    error += "y ";
                }
                contador = contador + 1;
                error += "productos";
            }
            datos2.Close();

            conexion.Close();

            if (contador > 0)
            {
                MessageBox.Show(error, "Atención");
                return;
            }

            if (this.MdiChildren.OfType<Comandas>().Count() == 0)
            {
                Comandas hijo = new Comandas(valor);
                hijo.MdiParent = this;
                tabla_mesas.Visible = false;
                menuStrip1.Enabled = false;
                hijo.Show();
            }
        }

        //se cambian los colores de los botones de la tabla para indicar si estan libres u ocupados, de color verde o rojo respectivamente
        public void cambiar_color_boton()
        {
            foreach (Control c in this.tabla_mesas.Controls)
            {
                if (c is Button)
                {
                    conexion.Open();
                    SqlCommand comando = new SqlCommand("SELECT estado FROM Comandas_Cabecera WHERE numero_mesa=@n_mesa AND estado=0", conexion);
                    comando.Parameters.Add("@n_mesa", SqlDbType.Int);
                    comando.Parameters["@n_mesa"].Value = c.TabIndex + 1;
                    SqlDataReader datos = comando.ExecuteReader();
                    if (datos.Read())
                    {
                       c.BackColor = Color.Firebrick;
                    }
                    else
                    {
                       c.BackColor = Color.ForestGreen;
                    }
                    datos.Close();
                    conexion.Close();
                }
            }
        }

        //metodo que se va a usar en un formulario hijo al cerrarlo para hacer visibles los botones de la tabla del formulario padre
        public void tabla_visible_si()
        {
            tabla_mesas.Visible = true;
        }

        public void menustrip_visible_si()
        {
            menuStrip1.Enabled = true;
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            
        }

        private void mozosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MdiChildren.OfType<Productos>().Count() == 0)
            {
                tabla_mesas.Visible = false;
                menuStrip1.Enabled = false;
                Productos hijo = new Productos();
                hijo.MdiParent = this;
                hijo.Show();
            }
        }
        //no se puede abrir mas de un mismo formulario hijo... al abrirlo se esconde la tabla de botones
        private void mozosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (this.MdiChildren.OfType<Mozos>().Count() == 0)
            {
                tabla_mesas.Visible = false;
                menuStrip1.Enabled = false;
                Mozos hijo = new Mozos();
                hijo.MdiParent = this;
                hijo.Show();
            }
        }

        private void aBMMozosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        

        private void mesa1_alpha_Click_1(object sender, EventArgs e)
        {
            abrir_comanda(mesa1_alpha.TabIndex + 1);
        }

        private void mesa2_beta_Click_1(object sender, EventArgs e)
        {
            abrir_comanda(mesa2_beta.TabIndex + 1);
        }

        private void mesa3_gamma_Click(object sender, EventArgs e)
        {
            abrir_comanda(mesa3_gamma.TabIndex + 1);
        }

        private void mesa4_delta_Click(object sender, EventArgs e)
        {
            abrir_comanda(mesa4_delta.TabIndex + 1);
        }

        private void mesa5_epsilon_Click(object sender, EventArgs e)
        {
            abrir_comanda(mesa5_epsilon.TabIndex + 1);
        }

        private void mesa6_theta_Click(object sender, EventArgs e)
        {
            abrir_comanda(mesa6_theta.TabIndex + 1);
        }

        private void mesa7_kappa_Click(object sender, EventArgs e)
        {
            abrir_comanda(mesa7_kappa.TabIndex + 1);
        }

        private void mesa8_lambda_Click(object sender, EventArgs e)
        {
            abrir_comanda(mesa8_lambda.TabIndex + 1);
        }

        private void mesa9_sigma_Click(object sender, EventArgs e)
        {
            abrir_comanda(mesa9_sigma.TabIndex + 1);
        }

        private void mesa10_omega_Click(object sender, EventArgs e)
        {
            abrir_comanda(mesa10_omega.TabIndex + 1);
        }

        private void mesa11_minerva_Click(object sender, EventArgs e)
        {
            abrir_comanda(mesa11_minerva.TabIndex + 1);
        }

        private void mesa12_bravo_Click(object sender, EventArgs e)
        {
            abrir_comanda(mesa12_bravo.TabIndex + 1);
        }

        private void mesa13_charlie_Click(object sender, EventArgs e)
        {
            abrir_comanda(mesa13_charlie.TabIndex + 1);
        }

        private void mesa14_zeta_Click(object sender, EventArgs e)
        {
            abrir_comanda(mesa14_zeta.TabIndex + 1);
        }

        private void mesa15_cobra_Click(object sender, EventArgs e)
        {
            abrir_comanda(mesa15_cobra.TabIndex + 1);
        }

        private void mesa16_saturno_Click(object sender, EventArgs e)
        {
            abrir_comanda(mesa16_saturno.TabIndex + 1);
        }

        private void mesa17_neptuno_Click(object sender, EventArgs e)
        {
            abrir_comanda(mesa17_neptuno.TabIndex + 1);
        }

        private void mesa18_kruger_Click(object sender, EventArgs e)
        {
            abrir_comanda(mesa18_kruger.TabIndex + 1);
        }

        private void mesa19_dragon_Click(object sender, EventArgs e)
        {
            abrir_comanda(mesa19_dragon.TabIndex + 1);
        }

        private void mesa20_alba_Click(object sender, EventArgs e)
        {
            abrir_comanda(mesa20_alba.TabIndex + 1);
        }

        private void preciosPorCategoríasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MdiChildren.OfType<Reportes>().Count() == 0)
            {
                tabla_mesas.Visible = false;
                menuStrip1.Enabled = false;
                Reportes hijo = new Reportes();
                hijo.MdiParent = this;
                hijo.Show();
            }
        }
    }
}
