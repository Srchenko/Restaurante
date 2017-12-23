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

namespace programa1
{
    public partial class Comandas : Form
    {
        SqlConnection conexion = new SqlConnection("Data Source=SRCHENKO-PC\\SQLEXPRESS;Initial Catalog=Restaurante;Integrated Security=True");

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

        //se ponen los nombres de todos los mozos en un combobox
        public void cargarListaMozos()
        {
            try
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand("SELECT id_mozo, CONCAT(nombre,' ',apellido) AS NombreCompleto FROM Mozos WHERE baja=0", conexion);
                DataTable tabla_mozos = new DataTable();
                SqlDataAdapter sqldat = new SqlDataAdapter(comando);
                sqldat.Fill(tabla_mozos);
                lista_mozos.DisplayMember = "NombreCompleto";
                lista_mozos.ValueMember = "id_mozo";
                lista_mozos.DataSource = tabla_mozos;
                conexion.Close();
            }
            catch (AccessViolationException Exception)
            {
                Console.WriteLine(Exception.Message);
            }
        }

        //se pone el listado de productos en los combobox de la tabla
        public void cargarListaProductos()
        {
            for (int i = 1; i <= 15; i++)
            {
                dgv_comandas_detalle.Rows.Add();
            }
            try
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand("SELECT id_producto, descripcion FROM Productos WHERE baja=0", conexion);
                DataTable tabla_productos = new DataTable();
                SqlDataAdapter sqldat = new SqlDataAdapter(comando);
                sqldat.Fill(tabla_productos);
                Columna_Producto.DisplayMember = "descripcion";
                Columna_Producto.ValueMember = "id_producto";
                Columna_Producto.DataSource = tabla_productos;
                conexion.Close();
            }
            catch (AccessViolationException Exception)
            {
                Console.WriteLine(Exception.Message);
            }
        }

        int generar_valor = 0;
        int id_comanda_general = 0;
        
        public Comandas(int valor)
        {
            InitializeComponent();
            cargarListaMozos();
            cargarListaProductos();
            //el valor de la mesa que viene del form padre
            generar_valor = valor;
            verificar_comanda_existente();
        }

        //si existe una comanda en curso, se cargan todos los datos necesarios en el combobox de mozos y la tabla de productos
        public void verificar_comanda_existente()
        {
            conexion.Open();
            SqlCommand comando = new SqlCommand("SELECT id_comanda, id_mozo FROM Comandas_Cabecera WHERE numero_mesa=@n_mesa AND estado=0", conexion);
            comando.Parameters.Add("@n_mesa", SqlDbType.Int);
            comando.Parameters["@n_mesa"].Value = generar_valor;
            SqlDataReader datos = comando.ExecuteReader();
            if (datos.Read())
            {
                id_comanda_general = Convert.ToInt32(datos["id_comanda"]);
                lista_mozos.SelectedValue = Convert.ToInt32(datos["id_mozo"]);
            }
            datos.Close();
            conexion.Close();
        }

        //al cerrar el formulario hijo, se hacen visibles los botones de la tabla del formulario padre
        private void Comandas_FormClosed(object sender, FormClosedEventArgs e)
        {
            Principal padre = this.MdiParent as Principal;
            padre.cambiar_color_boton();
            padre.tabla_visible_si();
        }

        private void dgv_comandas_detalle_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
        }

        //los dos metodos de abajo se van a usar cuando se haga click en los botones "modificar y salir" o "finalizar comanda"

        private void comanda_general()
        {
            try
            {
                conexion.Open();
                //si la comanda apenas entra en curso, se agrega a la tabla de comandas de la base de datos
                if (id_comanda_general==0)
                {
                    SqlCommand comando2 = new SqlCommand("INSERT INTO Comandas_Cabecera(id_mozo, numero_mesa, estado, baja) VALUES (@IDmozo,@NumeroMesa,0,0)", conexion);
                    comando2.Parameters.Add("@IDmozo", SqlDbType.Int);
                    comando2.Parameters["@IDmozo"].Value = Convert.ToInt32(lista_mozos.SelectedValue);
                    comando2.Parameters.Add("@NumeroMesa", SqlDbType.Int);
                    comando2.Parameters["@NumeroMesa"].Value = generar_valor;
                    comando2.ExecuteNonQuery();

                    SqlCommand comando3 = new SqlCommand("SELECT id_comanda FROM Comandas_Cabecera WHERE id_mozo=@idmozo AND numero_mesa=@n_mesa AND estado=0", conexion);
                    comando3.Parameters.Add("@idmozo", SqlDbType.Int);
                    comando3.Parameters["@idmozo"].Value = Convert.ToInt32(lista_mozos.SelectedValue);
                    comando3.Parameters.Add("@n_mesa", SqlDbType.Int);
                    comando3.Parameters["@n_mesa"].Value = generar_valor;
                    SqlDataReader datos2 = comando3.ExecuteReader();
                    if (datos2.Read())
                    {
                        id_comanda_general = Convert.ToInt32(datos2["id_comanda"]);
                    }
                    datos2.Close();

                }
                // si la comanda existe y esta en curso, se modifica la misma con los datos nuevos
                else
                {
                    SqlCommand comando4 = new SqlCommand("UPDATE Comandas SET id_mozo=@idmozo WHERE id_comanda=@idcomanda", conexion);
                    comando4.Parameters.Add("@idmozo", SqlDbType.Int);
                    comando4.Parameters["@idmozo"].Value = Convert.ToInt32(lista_mozos.SelectedValue);
                    comando4.Parameters.Add("@id_comanda", SqlDbType.Int);
                    comando4.Parameters["@id_comanda"].Value = id_comanda_general;
                    comando4.ExecuteNonQuery();
                }
                conexion.Close();
            }
            catch (AccessViolationException Exception)
            {
                Console.WriteLine(Exception.Message);
            }
        }

        private void renglones_comanda()
        {
            try
            {
                conexion.Open();
                SqlCommand comando, comando2, comando3;
                foreach (DataGridViewRow fila in dgv_comandas_detalle.Rows)
                {

                    if (!(string.IsNullOrEmpty(fila.Cells["Columna_Producto"].Value.ToString())) && !(string.IsNullOrEmpty(fila.Cells["Columna_Cantidad"].Value.ToString())))
                    {
                        //si la columna id renglon esta vacia, significa que no existe en la base de datos, por lo tanto, se agrega
                        if (string.IsNullOrEmpty(fila.Cells["ID_Renglon"].Value.ToString()))
                        {
                            comando = new SqlCommand("INSERT INTO Comandas_Detalle (id_comanda, id_producto, cantidad, subtotal, baja) VALUES (@IDcomanda,@IDproducto,@cantidad,@subtotal,0)", conexion);
                            comando.Parameters.Add("@IDcomanda", SqlDbType.Int);
                            comando.Parameters["@IDcomanda"].Value = id_comanda_general;
                            comando.Parameters.Add("@IDproducto", SqlDbType.Int);
                            comando.Parameters["@IDproducto"].Value = Convert.ToInt32(fila.Cells["Columna_Producto"].Value);
                            comando.Parameters.Add("@cantidad", SqlDbType.Int);
                            comando.Parameters["@cantidad"].Value = Convert.ToInt32(fila.Cells["Columna_Cantidad"].Value);
                            comando.Parameters.Add("@subtotal", SqlDbType.Int);
                            comando.Parameters["@subtotal"].Value = Convert.ToInt32(fila.Cells["Columna_Subtotal"].Value);
                            comando.ExecuteNonQuery();
                        }
                        //si la columna id renglon no esta vacia, significa que existe en la base de datos, por lo tanto se modifica con los nuevos datos
                        else
                        {
                            comando2 = new SqlCommand("UPDATE Comandas_Detalle SET id_comanda=@IDcomanda, id_producto=@IDproducto, cantidad=@cantidad, subtotal=@subtotal WHERE id_renglon=@IDrenglon", conexion);
                            comando2.Parameters.Add("@IDrenglon", SqlDbType.Int);
                            comando2.Parameters["@IDrenglon"].Value = Convert.ToInt32(fila.Cells["ID_Renglon"].Value);
                            comando2.Parameters.Add("@IDcomanda", SqlDbType.Int);
                            comando2.Parameters["@IDcomanda"].Value = id_comanda_general;
                            comando2.Parameters.Add("@IDproducto", SqlDbType.Int);
                            comando2.Parameters["@IDproducto"].Value = Convert.ToInt32(fila.Cells["Columna_Producto"].Value);
                            comando2.Parameters.Add("@cantidad", SqlDbType.Int);
                            comando2.Parameters["@cantidad"].Value = Convert.ToInt32(fila.Cells["Columna_Cantidad"].Value);
                            comando2.Parameters.Add("@subtotal", SqlDbType.Int);
                            comando2.Parameters["@subtotal"].Value = Convert.ToInt32(fila.Cells["Columna_Subtotal"].Value);
                            comando2.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        //si la columna de producto y cantidad estan vacias pero proviene de un renglon existente, entonces el renglon se elimina
                        if (!(string.IsNullOrEmpty(fila.Cells["ID_Renglon"].Value.ToString())))
                        {
                            comando3 = new SqlCommand("UPDATE Comandas_Detalle SET baja=1 WHERE WHERE id_renglon=@IDrenglon", conexion);
                            comando3.Parameters.Add("@IDrenglon", SqlDbType.Int);
                            comando3.Parameters["@IDrenglon"].Value = Convert.ToInt32(fila.Cells["ID_Renglon"].Value);
                            comando3.ExecuteNonQuery();
                        }
                    }
                }
                conexion.Close();
            }
            catch (AccessViolationException Exception)
            {
                Console.WriteLine(Exception.Message);
            }
        }

        //se revisa que a la tabla no le falten ciertos datos

        private bool revisar_tabla()
        {
            bool dato = true;
            foreach (DataGridViewRow fila in dgv_comandas_detalle.Rows)
            {
                //si se completa la columna producto, es obligatorio completar la columna cantidad y viceversa
                if ((string.IsNullOrEmpty(fila.Cells["Columna_Producto"].Value.ToString()) && !string.IsNullOrEmpty(fila.Cells["Columna_Cantidad"].Value.ToString())) || (!string.IsNullOrEmpty(fila.Cells["Columna_Producto"].Value.ToString()) && string.IsNullOrEmpty(fila.Cells["Columna_Cantidad"].Value.ToString())))
                {
                        dato = false;
                }
                
            }
            return dato;
        }

        //se calculan los subtotales en donde haya una columna producto con su respectiva columna cantidad

        private void calcular_subtotales()
        {

        }

        private void bt_modificar_salir_Click(object sender, EventArgs e)
        {
            dgv_comandas_detalle.ClearSelection();
            if (revisar_tabla() == false)
            {
                //MessageBox.Show("Si usted completa la celda de Producto o de Cantidad, complete la que falta.", "Atención");
                return;
            }
            comanda_general();
            renglones_comanda();
            
        }

        private void bt_finalizar_comanda_Click(object sender, EventArgs e)
        {

        }

        private void bt_calcular_subtotal_productos_Click(object sender, EventArgs e)
        {
            
        }

        private void bt_calcular_total_comanda_Click(object sender, EventArgs e)
        {

        }

        //se ponen varios controles y/o ayudas cuando el usuario quiere poner el producto correcto en los combobox de la tabla
        //tambien se crea un nuevo evento para que en la columna de cantidad se pongan solo numeros
        private void dgv_comandas_detalle_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgv_comandas_detalle.CurrentCell.ColumnIndex == 0)
            {
                ((ComboBox)e.Control).DropDownStyle = ComboBoxStyle.DropDown;
                ((ComboBox)e.Control).AutoCompleteMode = AutoCompleteMode.Suggest;

                if (e.Control is ComboBox)
                {
                    ComboBox comboBox = (ComboBox)e.Control;
                    if (dgv_comandas_detalle.CurrentCell.Value == null
                        || string.IsNullOrEmpty(dgv_comandas_detalle.CurrentCell.Value.ToString())
                        || string.IsNullOrEmpty(comboBox.SelectedText)
                        )
                    {
                        comboBox.SelectedIndex = -1;
                    }
                }
            }
            
            if (dgv_comandas_detalle.CurrentCell.ColumnIndex == 1)
            {
                e.Control.KeyPress -= new KeyPressEventHandler(columna2_cantidad_KeyPress);
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(columna2_cantidad_KeyPress);
                }
            }
        }

        private void columna2_cantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
            }
        }
    }
}
