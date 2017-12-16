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

        private void Principal_Load(object sender, EventArgs e)
        {
            
        }

        private void mozosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MdiChildren.OfType<Mesas>().Count() == 0)
            {
                Mesas hijo = new Mesas();
                hijo.MdiParent = this;
                hijo.Show();
            }
        }

        private void mozosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (this.MdiChildren.OfType<Mozos>().Count() == 0)
            {
                Mozos hijo = new Mozos();
                hijo.MdiParent = this;
                hijo.Show();
            }
        }

        private void aBMMozosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void mesa1_alpha_Click(object sender, EventArgs e)
        {

        }

        private void mesa2_beta_Click(object sender, EventArgs e)
        {

        }
    }
}
