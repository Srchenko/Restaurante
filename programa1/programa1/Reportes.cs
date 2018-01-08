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
using System.Globalization;

namespace programa1
{
    public partial class Reportes : Form
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

        //se ponen todas las categorias en un datagridview para que despues el usuario pueda seleccionarlas
        public void rellenar_categoria()
        {
            try
            {
                lbl_precio_categoria_producto.Text = "";

                conexion.Open();
                SqlCommand comando = new SqlCommand("SELECT id_categoria, nombre_categoria FROM Categoria WHERE baja=0 ORDER BY nombre_categoria", conexion);
                SqlDataReader datos = comando.ExecuteReader();
                while (datos.Read())
                {
                    dgv_categoria.Rows.Add(datos["nombre_categoria"].ToString(), datos["id_categoria"].ToString());
                }
                datos.Close();

                conexion.Close();
            }
            catch (AccessViolationException Exception)
            {
                Console.WriteLine(Exception.Message);
            }
        }

        //se ponen todos los productos en un datagridview para que despues el usuario pueda seleccionarlos
        public void rellenar_productos()
        {
            try
            {
                lbl_materia_utilizada_producto.Text = "";

                conexion.Open();
                SqlCommand comando = new SqlCommand("SELECT id_producto, descripcion FROM Productos WHERE baja=0 ORDER BY descripcion", conexion);
                SqlDataReader datos = comando.ExecuteReader();
                while (datos.Read())
                {
                    dgv_productos.Rows.Add(datos["descripcion"].ToString(), datos["id_producto"].ToString());
                }
                datos.Close();

                conexion.Close();
            }
            catch (AccessViolationException Exception)
            {
                Console.WriteLine(Exception.Message);
            }
        }

        public Reportes()
        {
            InitializeComponent();
            try
            {
                conexion.Open();

                //el primer command y datareader es para saber si existe algun producto en la base de datos... en el caso de existir, se cargan en una pestaña las categorias con los que se pueden ver los productos con sus precios y en otra pestaña se cargan los productos con los que se pueden ver la materia prima que se utiliza... caso contrario, se muestra el mensaje de que no hay productos y se deshabilitan los datagridview correspondientes
                SqlCommand comando = new SqlCommand("SELECT id_producto FROM Productos WHERE baja=0", conexion);
                SqlDataReader datos = comando.ExecuteReader();
                if (datos.Read())
                {
                    conexion.Close();
                    rellenar_categoria();
                    rellenar_productos();
                }
                else
                {
                    dgv_categoria.Enabled = false;
                    dgv_categoria_producto.Enabled = false;
                    dgv_productos.Enabled = false;
                    dgv_materia_productos.Enabled = false;
                }
                datos.Close();



                conexion.Close();
            }
            catch (AccessViolationException Exception)
            {
                Console.WriteLine(Exception.Message);
            }

        }

        private void Reportes_FormClosed(object sender, FormClosedEventArgs e)
        {
            Principal padre = this.MdiParent as Principal;
            padre.cambiar_color_boton();
            padre.tabla_visible_si();
            padre.menustrip_visible_si();
        }

        //al hacer click en una determinada fila del datagridview de categorias se muestran los productos de esa categoria con los datos correspondientes en otro datagridview
        private void dgv_categoria_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int indice = dgv_categoria.SelectedCells[0].RowIndex;
                DataGridViewRow fila_seleccionada = dgv_categoria.Rows[indice];
                int id_cat = Convert.ToInt32(fila_seleccionada.Cells["ID_Categoria"].Value);

                dgv_categoria_producto.Rows.Clear();

                conexion.Open();

                SqlCommand comando = new SqlCommand("SELECT Productos.descripcion AS descrip, Categoria.nombre_categoria AS categ, Productos.precio AS prec FROM Productos JOIN Categoria ON Productos.id_categoria=Categoria.id_categoria WHERE Productos.baja=0 AND Categoria.id_categoria=@idcategoria AND Categoria.baja=0 ORDER BY descrip", conexion);
                comando.Parameters.Add("@idcategoria", SqlDbType.Int);
                comando.Parameters["@idcategoria"].Value = id_cat;
                SqlDataReader datos = comando.ExecuteReader();
                while (datos.Read())
                {
                    dgv_categoria_producto.Rows.Add(datos["descrip"].ToString(), datos["categ"].ToString(), datos["prec"].ToString());
                }
                datos.Close();

                conexion.Close();
            }
            catch (AccessViolationException Exception)
            {
                Console.WriteLine(Exception.Message);
            }
        }

        //evita que se seleccione la primera fila de los datagridview correspondientes
        private void Reportes_Shown(object sender, EventArgs e)
        {
            dgv_categoria.ClearSelection();
        }

        //al hacer click en una determinada fila del datagridview de productos se muestra la materia prima de ese producto con los datos correspondientes en otro datagridview
        private void dgv_productos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int indice = dgv_productos.SelectedCells[0].RowIndex;
                DataGridViewRow fila_seleccionada = dgv_productos.Rows[indice];
                int id_prod = Convert.ToInt32(fila_seleccionada.Cells["ID_Producto"].Value);

                dgv_materia_productos.Rows.Clear();

                conexion.Open();

                SqlCommand comando = new SqlCommand("SELECT Materia_Prima.descripcion AS descrip, Marca.nombre_marca AS marc, Materia_Prima.costo AS cost, Productos_Materia_Prima.cantidad AS cant FROM Marca JOIN Materia_Prima ON Marca.id_marca=Materia_Prima.id_marca JOIN Productos_Materia_Prima ON Materia_Prima.id_materia_prima = Productos_Materia_Prima.id_materia_prima JOIN Productos ON Productos_Materia_Prima.id_producto = Productos.id_producto WHERE Materia_Prima.baja=0 AND Marca.baja=0 AND Productos.id_producto=@idproducto AND Productos.baja=0 ORDER BY descrip", conexion);
                comando.Parameters.Add("@idproducto", SqlDbType.Int);
                comando.Parameters["@idproducto"].Value = id_prod;
                SqlDataReader datos = comando.ExecuteReader();
                while (datos.Read())
                {
                    dgv_materia_productos.Rows.Add(datos["descrip"].ToString(), datos["marc"].ToString(), datos["cost"].ToString(), datos["cant"].ToString());
                }
                datos.Close();

                conexion.Close();
            }
            catch (AccessViolationException Exception)
            {
                Console.WriteLine(Exception.Message);
            }
        }

        //evita que se seleccione la primera fila de los datagridview correspondientes
        private void pestañas_reportes_Click(object sender, EventArgs e)
        {
            dgv_productos.ClearSelection();
        }
    }
}
