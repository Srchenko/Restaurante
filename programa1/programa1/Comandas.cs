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

        int generar_valor = 0;
        public Comandas(int valor)
        {
            InitializeComponent();
            cargarListaMozos();
            cargarListaProductos();
            //el valor de la mesa que viene del form padre
            generar_valor = valor;
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

        private void bt_modificar_salir_Click(object sender, EventArgs e)
        {
            dgv_comandas_detalle.ClearSelection();
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
