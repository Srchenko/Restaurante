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

        int id_mozo=0;

        public void cargarGridMozos()
        {
            try
            {
                //se carga una grilla con todos los datos posibles de una tabla en particular de una base de datos
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
            id_mozo = 0;
        }
        //Se evita que se mueva la ventana del formulario
        protected override void WndProc(ref Message mensaje)
        {
            const int WM_SYSCOMMAND = 0x0112;
            const int SC_MOVE = 0xF010;

            switch (mensaje.Msg)
            {
                case WM_SYSCOMMAND:
                    int command = mensaje.WParam.ToInt32() & 0xfff0;
                    if (command == SC_MOVE)
                        return;
                    break;
            }

            base.WndProc(ref mensaje);
        }

        public bool validacion_copada()
        {
            string error = "";
            //primero se verifica si hay textboxs vacios
            if (this.Controls.OfType<TextBox>().Any(t => string.IsNullOrEmpty(t.Text)))

            {
                MessageBox.Show("Faltan completar campos", "Atención");
                return false;
            }
            //si no hay textboxs vacios entonces se pasa por una serie de validaciones para  tratar de tener mas datos correctos
            else
            {

                if (txt_nombre.Text.Length < 3)
                {
                    error += "Nombre muy corto. ";
                }

                if (txt_apellido.Text.Length < 3)
                {
                    error += "Apellido muy corto. ";
                }

                if (txt_dni.Text.Length != 8)
                {
                    error += "El DNI debe tener 8 números. ";
                }

                Regex re = new Regex("(^(((0[1-9]|1[0-9]|2[0-8])[\\/](0[1-9]|1[012]))|((29|30|31)[\\/](0[13578]|1[02]))|((29|30)[\\/](0[4,6,9]|11)))[\\/](19|[2-9][0-9])\\d\\d$)|(^29[\\/]02[\\/](19|[2-9][0-9])(00|04|08|12|16|20|24|28|32|36|40|44|48|52|56|60|64|68|72|76|80|84|88|92|96)$)");

                if (txt_fecha_nacimiento.Text.Length != 10 || !re.IsMatch(txt_fecha_nacimiento.Text))
                {
                    error += "Ingrese fecha válida (dd/mm/aaaa). ";
                }
                else
                {
                    DateTime fechanacimiento = DateTime.Parse(txt_fecha_nacimiento.Text);
                    DateTime hoy = DateTime.Today;
                    int edad = hoy.Year - fechanacimiento.Year;
                    if (edad < 18)
                    {
                        error += "El mozo debe tener más de 18 años. ";
                    }
                }

                if (txt_direccion.Text.Length < 3)
                {
                    error += "Dirección muy corta. ";
                }
                if (txt_telefono.Text.Length < 3)
                {
                    error += "Telefono muy corto.";
                }
                if (error != "")
                {
                    MessageBox.Show(error, "Atención");
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public Mozos()
        {
            InitializeComponent();
            cargarGridMozos();
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

        private void b_agregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (validacion_copada() == false)
                {
                    return;
                }
                conexion.Open();
                //Antes de agregar un mozo, se intenta que no existan dos mozos con el mismo dni
                SqlCommand comando3 = new SqlCommand("SELECT * FROM Mozos WHERE dni=@DNI", conexion);
                comando3.Parameters.Add("@DNI", SqlDbType.Int);
                comando3.Parameters["@DNI"].Value = txt_dni.Text;
                SqlDataReader datos3 = comando3.ExecuteReader();
                if (datos3.Read())
                {
                    MessageBox.Show("Esta persona ya existe.", "Atención");
                    datos3.Close();
                    conexion.Close();
                    return;
                }
                datos3.Close();
                //Si el dni es diferente a todos los mozos de la tabla de la base de datos, se agrega el nuevo mozo
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
                MessageBox.Show("Se ingresó el dato.", "Atención");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
        }

        private void dgv_mozos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //Cada vez que se seleccione una fila, se mostraran los datos correspondientes en los textboxs para luego modificar o eliminar los mozos
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
                    id_mozo = Convert.ToInt32(datos["id_mozo"]);
                }
                datos.Close();

                conexion.Close();
            }
            catch (AccessViolationException Exception)
            {
                Console.WriteLine(Exception.Message);
            }
            
        }

        private void b_modificar_Click(object sender, EventArgs e)
        {
            if (id_mozo!=0)
            {

                try
                {
                    if (validacion_copada() == false)
                    {
                        return;
                    }

                    conexion.Open();
                    //al modificar el dni, se intenta que este no sea el mismo que los otros mozos
                    SqlCommand comando4 = new SqlCommand("SELECT * FROM Mozos WHERE id_mozo=@ID", conexion);
                    comando4.Parameters.Add("@ID", SqlDbType.Int);
                    comando4.Parameters["@ID"].Value = id_mozo;
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
                            MessageBox.Show("Este DNI ya existe.","Atención");
                            datos5.Close();
                            conexion.Close();
                            return;
                        }
                    }
                    datos5.Close();
                    //si todo esta bien con el dni, se modifica el mozo
                    string sql = "UPDATE Mozos SET nombre=@Nombre, apellido=@Apellido,  dni=@DNI, fecha_nac=@Fecha, telefono=@Telefono, direccion=@Direccion WHERE id_mozo=@ID";
                    SqlCommand comando = new SqlCommand(sql, conexion);
                    comando.Parameters.Add("@ID", SqlDbType.Int);
                    comando.Parameters["@ID"].Value = id_mozo;
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
                    MessageBox.Show("Se modificó el dato.", "Atención");
                    limpiarTexto();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {
                MessageBox.Show("Seleccione una fila.", "Atención");
            }
        }

        private void b_eliminar_Click(object sender, EventArgs e)
        {
            if (id_mozo != 0) 
            {
                //Se pregunta si de verdad quiere eliminar a un mozo... caso contrario es muy probable que alguien termine despedido si le pifio a esta opcion
                if (MessageBox.Show("¿Está seguro?", "Eliminar", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        //los mozos eliminados siguen estando en la tabla de la base de datos, pero no se muestran como activos
                        conexion.Open();
                        string sql = "UPDATE Mozos SET baja=1 WHERE id_mozo=@ID";
                        SqlCommand comando = new SqlCommand(sql, conexion);
                        comando.Parameters.Add("@ID", SqlDbType.Int);
                        comando.Parameters["@ID"].Value = id_mozo;
                        comando.ExecuteNonQuery();

                        conexion.Close();
                        cargarGridMozos();
                        limpiarTexto();
                        MessageBox.Show("Se eliminó el mozo.", "Atención");
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Error.", "Atención");
                    }
                }
                else
                {
                    return;
                }
            }
            else
            {
                MessageBox.Show("Seleccione una fila.", "Atención");
            }
        }

        // Otras validaciones para que no ingresen cualquier cosa a los textboxs
        private void txt_nombre_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            char nom = e.KeyChar;
            if (!(Char.IsLetter(nom)) && (e.KeyChar != (char)Keys.Back) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
                return;
            }
        }

        private void txt_apellido_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            char nom = e.KeyChar;
            if (!(Char.IsLetter(nom)) && (e.KeyChar != (char)Keys.Back) && !char.IsWhiteSpace(e.KeyChar))
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

        //se evita que se pongan mas espacios innecesarios si alguien tiene nombre o apellido compuesto... tambien, por las dudas, para el telefono y direccion
        private int contador = 0;

        private void no_mas_espacios(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                contador++;
            }
            else
            {
                contador = 0;
            }

            if (contador > 1)
            {
                e.SuppressKeyPress = true;
            }
        }

        private void txt_nombre_KeyDown(object sender, KeyEventArgs e)
        {

            no_mas_espacios(e);
        }

        private void txt_apellido_KeyDown(object sender, KeyEventArgs e)
        {
            no_mas_espacios(e);
        }
        //al cerrar el formulario hijo, se hacen visibles los botones de la tabla del formulario padre
        private void Mozos_FormClosed(object sender, FormClosedEventArgs e)
        {
            Principal padre = this.MdiParent as Principal;
            padre.cambiar_color_boton();
            padre.tabla_visible_si();
        }

        private void txt_telefono_KeyDown(object sender, KeyEventArgs e)
        {
            no_mas_espacios(e);
        }

        private void txt_direccion_KeyDown(object sender, KeyEventArgs e)
        {
            no_mas_espacios(e);
        }
    }
}
