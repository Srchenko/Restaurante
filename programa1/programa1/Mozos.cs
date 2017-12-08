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
    public partial class Mozos : Form
    {
        SqlConnection conexion = new SqlConnection("Data Source=SRCHENKO-PC\\SQLEXPRESS;Initial Catalog=Restaurante;Integrated Security=True");

        public void cargarGridMozos()
        {
            try
            {
                conexion.Open();
                string sql = "SELECT id_mozo, nombre, apellido, dni, fecha_nac, telefono, direccion FROM Mozos WHERE baja=0";
                DataTable lista = new DataTable("lista");
                SqlCommand comando = new SqlCommand(sql, conexion);
                SqlDataAdapter sqldat = new SqlDataAdapter(comando);
                sqldat.Fill(lista);
                this.dgv_mozos.DataSource = lista;
                conexion.Close();
            }
            catch (AccessViolationException Exception)
            {
                Console.WriteLine(Exception.Message);
            }
        }

        public void limpiarTexto()
        {
            txt_nombre.Text = "";
            txt_apellido.Text = "";
            txt_dni.Text = "";
            txt_fecha_nacimiento.Text = "";
            txt_direccion.Text = "";
            txt_telefono.Text = "";
            idmozo.Text = "";
        }

        public bool validacion()
        {
            int cont = 0;

            if (txt_nombre.Text.Length < 3)
            {
                MessageBox.Show("Nombre muy corto.");
                cont++;
            }

            if (txt_apellido.Text.Length < 3)
            {
                MessageBox.Show("Apellido muy corto.");
                cont++;
            }

            if (txt_dni.Text.Length != 8)
            {
                MessageBox.Show("El DNI debe tener 8 números.");
                cont++;
            }

            Regex re = new Regex("(^(((0[1-9]|1[0-9]|2[0-8])[\\/](0[1-9]|1[012]))|((29|30|31)[\\/](0[13578]|1[02]))|((29|30)[\\/](0[4,6,9]|11)))[\\/](19|[2-9][0-9])\\d\\d$)|(^29[\\/]02[\\/](19|[2-9][0-9])(00|04|08|12|16|20|24|28|32|36|40|44|48|52|56|60|64|68|72|76|80|84|88|92|96)$)");

            if (txt_fecha_nacimiento.Text.Length != 10 || !re.IsMatch(txt_fecha_nacimiento.Text))
            {
                MessageBox.Show("Ingrese fecha válida dd/mm/yyyy");
                cont++;
            }

            if (txt_direccion.Text.Length < 3)
            {
                MessageBox.Show("Dirección muy corta.");
                cont++;
            }
            if (txt_telefono.Text.Length < 3)
            {
                MessageBox.Show("Teléfono muy corto.");
                cont++;
            }
            if (cont == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Mozos()
        {
            InitializeComponent();
            cargarGridMozos();
            idmozo.Visible = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void l_DNI_Click(object sender, EventArgs e)
        {

        }

        private void b_limpiar_campos_Click(object sender, EventArgs e)
        {
            limpiarTexto();
        }

        private void dgv_mozos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void b_agregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (validacion() == false)
                {
                    return;
                }
                conexion.Open();

                SqlCommand comando3 = new SqlCommand("SELECT * FROM Mozos WHERE dni=@DNI", conexion);
                comando3.Parameters.Add("@DNI", SqlDbType.Int);
                comando3.Parameters["@DNI"].Value = txt_dni.Text;
                SqlDataReader datos3 = comando3.ExecuteReader();
                if (datos3.Read())
                {
                    MessageBox.Show("Esta persona ya existe.");
                    datos3.Close();
                    conexion.Close();
                    return;
                }
                datos3.Close();

                string sql = "INSERT INTO Mozos(nombre, apellido, dni, fecha_nac, telefono, direccion, baja) VALUES (@Nombre,@Apellido,@DNI,@Fecha,@Telefono,@Direccion,0)";
                SqlCommand comando = new SqlCommand(sql, conexion);
                comando.Parameters.Add("@Nombre", SqlDbType.VarChar);
                comando.Parameters["@Nombre"].Value = txt_nombre.Text;
                comando.Parameters.Add("@Apellido", SqlDbType.VarChar);
                comando.Parameters["@Apellido"].Value = txt_apellido.Text;
                comando.Parameters.Add("@Fecha", SqlDbType.Date);
                comando.Parameters["@Fecha"].Value = txt_fecha_nacimiento.Text;
                comando.Parameters.Add("@DNI", SqlDbType.Int);
                comando.Parameters["@DNI"].Value = txt_dni.Text;
                comando.Parameters.Add("@Telefono", SqlDbType.VarChar);
                comando.Parameters["@Telefono"].Value = txt_telefono.Text;
                comando.Parameters.Add("@Direccion", SqlDbType.VarChar);
                comando.Parameters["@Direccion"].Value = txt_direccion.Text;
                comando.ExecuteNonQuery();

                conexion.Close();
                cargarGridMozos();
                limpiarTexto();
                MessageBox.Show("Se ingresó el dato.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
        }

        private void dgv_mozos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int campa = Convert.ToInt32(this.dgv_mozos.CurrentRow.Cells["id_mozo"].Value);
            conexion.Open();
            SqlCommand comando = new SqlCommand("SELECT * FROM Mozos WHERE id_mozo=@ID ", conexion);
            comando.Parameters.Add("@ID", SqlDbType.VarChar);
            comando.Parameters["@ID"].Value = campa;
            SqlDataReader datos = comando.ExecuteReader();
            if (datos.Read())
            {
                txt_nombre.Text = datos["nombre"].ToString();
                txt_apellido.Text = datos["apellido"].ToString();
                txt_dni.Text = datos["dni"].ToString();
                txt_telefono.Text = datos["telefono"].ToString();
                txt_direccion.Text = datos["direccion"].ToString();
                String cadena = datos["fecha_nac"].ToString();
                String[] linea = cadena.Split(' ');
                txt_fecha_nacimiento.Text = linea[0];
                idmozo.Text = datos["id_mozo"].ToString();
            }
            datos.Close();

            conexion.Close();
        }

        private void b_modificar_Click(object sender, EventArgs e)
        {
            if (idmozo.Text.Length != 0)
            {

                try
                {
                    if (validacion() == false)
                    {
                        return;
                    }

                    conexion.Open();

                    SqlCommand comando4 = new SqlCommand("SELECT * FROM Mozos WHERE id_mozo=@ID", conexion);
                    comando4.Parameters.Add("@ID", SqlDbType.Int);
                    comando4.Parameters["@ID"].Value = idmozo.Text;
                    SqlDataReader datos4 = comando4.ExecuteReader();
                    int dnior = 0;
                    if (datos4.Read())
                    {
                        dnior = Convert.ToInt32(datos4["dni"]);
                    }
                    datos4.Close();

                    SqlCommand comando5 = new SqlCommand("SELECT * FROM Mozos WHERE dni<>@DNI", conexion);
                    comando5.Parameters.Add("@DNI", SqlDbType.Int);
                    comando5.Parameters["@DNI"].Value = dnior;
                    SqlDataReader datos5 = comando5.ExecuteReader();
                    String dniref = "";
                    while (datos5.Read())
                    {
                        dniref = datos5["dni"].ToString();
                        if (txt_dni.Text.Equals(dniref))
                        {
                            MessageBox.Show("Este DNI ya existe.");
                            datos5.Close();
                            conexion.Close();
                            return;
                        }
                    }
                    datos5.Close();

                    string sql = "UPDATE Mozos SET nombre=@Nombre, apellido=@Apellido,  dni=@DNI, fecha_nac=@Fecha, telefono=@Telefono, direccion=@Direccion WHERE id_mozo=@ID";
                    SqlCommand comando = new SqlCommand(sql, conexion);
                    comando.Parameters.Add("@ID", SqlDbType.Int);
                    comando.Parameters["@ID"].Value = idmozo.Text;
                    comando.Parameters.Add("@Nombre", SqlDbType.VarChar);
                    comando.Parameters["@Nombre"].Value = txt_nombre.Text;
                    comando.Parameters.Add("@Apellido", SqlDbType.VarChar);
                    comando.Parameters["@Apellido"].Value = txt_apellido.Text;
                    comando.Parameters.Add("@Fecha", SqlDbType.Date);
                    comando.Parameters["@Fecha"].Value = txt_fecha_nacimiento.Text;
                    comando.Parameters.Add("@DNI", SqlDbType.Int);
                    comando.Parameters["@DNI"].Value = txt_dni.Text;
                    comando.Parameters.Add("@Telefono", SqlDbType.VarChar);
                    comando.Parameters["@Telefono"].Value = txt_telefono.Text;
                    comando.Parameters.Add("@Direccion", SqlDbType.VarChar);
                    comando.Parameters["@Direccion"].Value = txt_direccion.Text;

                    comando.ExecuteNonQuery();

                    conexion.Close();
                    cargarGridMozos();
                    MessageBox.Show("Se modificó el dato.");
                    limpiarTexto();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {
                MessageBox.Show("Seleccione una fila.");
            }
        }

        private void b_eliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro?", "Eliminar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                if (idmozo.Text.Length != 0)
                {
                    try
                    {
                        conexion.Open();
                        string sql = "UPDATE Mozos SET baja=1 WHERE id_mozo=@ID";
                        SqlCommand comando = new SqlCommand(sql, conexion);
                        comando.Parameters.Add("@ID", SqlDbType.Int);
                        comando.Parameters["@ID"].Value = idmozo.Text;
                        comando.ExecuteNonQuery();

                        conexion.Close();
                        cargarGridMozos();
                        limpiarTexto();
                        MessageBox.Show("Se eliminó el mozo.");
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Error.");
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione una fila.");
                }
            }
        }

        private void txt_nombre_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            char nom = e.KeyChar;
            if (!(Char.IsLetter(nom)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void txt_apellido_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            char nom = e.KeyChar;
            if (!(Char.IsLetter(nom)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void txt_dni_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            char nom = e.KeyChar;
            if (!(Char.IsDigit(nom)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }
    }
}
