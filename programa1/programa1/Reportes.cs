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
                lbl_precio_categoria_producto.Text = "Seleccione una categoría.";

                conexion.Open();
                SqlCommand comando = new SqlCommand("SELECT DISTINCT Categoria.id_categoria as ID, Categoria.nombre_categoria AS Nombre FROM Categoria JOIN Productos ON Categoria.id_categoria = Productos.id_categoria WHERE Categoria.baja=0 AND Productos.baja=0 ORDER BY Nombre", conexion);
                SqlDataReader datos = comando.ExecuteReader();
                while (datos.Read())
                {
                    dgv_categoria.Rows.Add(datos["Nombre"].ToString(), datos["ID"].ToString());
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
                lbl_materia_utilizada_producto.Text = "Seleccione un producto.";

                conexion.Open();
                SqlCommand comando = new SqlCommand("SELECT DISTINCT Productos.id_producto AS ID, Productos.descripcion AS descrip FROM Marca JOIN Materia_Prima ON Marca.id_marca=Materia_Prima.id_marca JOIN Productos_Materia_Prima ON Materia_Prima.id_materia_prima = Productos_Materia_Prima.id_materia_prima JOIN Productos ON Productos_Materia_Prima.id_producto = Productos.id_producto WHERE Materia_Prima.baja=0 AND Marca.baja=0 AND Productos.baja=0 ORDER BY descrip", conexion);
                SqlDataReader datos = comando.ExecuteReader();
                while (datos.Read())
                {
                    dgv_productos.Rows.Add(datos["descrip"].ToString(), datos["ID"].ToString());
                }
                datos.Close();

                conexion.Close();
            }
            catch (AccessViolationException Exception)
            {
                Console.WriteLine(Exception.Message);
            }
        }

        //se ponen todos los mozos en un datagridview para que despues el usuario pueda seleccionarlos
        public void rellenar_mozos()
        {
            try
            {
                lbl_ventas_mozos.Text = "Seleccione un mozo.";

                conexion.Open();
                SqlCommand comando = new SqlCommand("SELECT DISTINCT Mozos.id_mozo AS ID, CONCAT(Mozos.nombre,' ',Mozos.apellido) AS NombreCompleto FROM Comandas_Cabecera JOIN Comandas_Detalle ON Comandas_Cabecera.id_comanda = Comandas_Detalle.id_comanda JOIN Mozos ON Comandas_Cabecera.id_mozo = Mozos.id_mozo WHERE Comandas_Detalle.baja=0 AND Comandas_Cabecera.baja=0 AND Mozos.baja=0 ORDER BY NombreCompleto", conexion);
                SqlDataReader datos = comando.ExecuteReader();
                while (datos.Read())
                {
                    dgv_mozos.Rows.Add(datos["NombreCompleto"].ToString(), datos["ID"].ToString());
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

                conexion.Open();
                //el segundo command y datareader sirve para saber si existe comandas en la base de datos
                SqlCommand comando2 = new SqlCommand("SELECT id_comanda FROM Comandas_Cabecera WHERE baja=0 AND estado=1", conexion);
                SqlDataReader datos2 = comando2.ExecuteReader();
                if (datos2.Read())
                {
                    conexion.Close();
                    rellenar_mozos();
                }
                else
                {
                    dgv_mozos.Enabled = false;
                    dgv_comandas_cabecera.Enabled = false;
                    dgv_comandas_detalle.Enabled = false;
                }
                datos2.Close();

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

                SqlCommand comando = new SqlCommand("SELECT descripcion, precio FROM Productos WHERE baja=0 AND id_categoria=@idcategoria ORDER BY descripcion", conexion);
                comando.Parameters.Add("@idcategoria", SqlDbType.Int);
                comando.Parameters["@idcategoria"].Value = id_cat;
                SqlDataReader datos = comando.ExecuteReader();
                while (datos.Read())
                {
                    dgv_categoria_producto.Rows.Add(datos["descripcion"].ToString(), datos["precio"].ToString());
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
            dgv_categoria_producto.ClearSelection();
            dgv_productos.ClearSelection();
            dgv_materia_productos.ClearSelection();
            dgv_mozos.ClearSelection();
            dgv_comandas_cabecera.ClearSelection();
            dgv_comandas_detalle.ClearSelection();
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
            dgv_categoria.ClearSelection();
            dgv_categoria_producto.ClearSelection();
            dgv_productos.ClearSelection();
            dgv_materia_productos.ClearSelection();
            dgv_mozos.ClearSelection();
            dgv_comandas_cabecera.ClearSelection();
            dgv_comandas_detalle.ClearSelection();
        }

        //al hacer click en una determinada fila del datagridview de mozos se muestran las comandas de ese mozo con los datos correspondientes en otro datagridview
        private void dgv_mozos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                String[] linea;
                String cadena;
                TimeSpan tiempo;

                int indice = dgv_mozos.SelectedCells[0].RowIndex;
                DataGridViewRow fila_seleccionada = dgv_mozos.Rows[indice];
                int id_mozo = Convert.ToInt32(fila_seleccionada.Cells["ID_Mozo"].Value);

                dgv_comandas_cabecera.Rows.Clear();
                dgv_comandas_detalle.Rows.Clear();

                conexion.Open();

                SqlCommand comando = new SqlCommand("SELECT Comandas_Cabecera.fecha AS fech, Comandas_Cabecera.hora AS hor, SUM(Comandas_Detalle.subtotal) AS tot, Comandas_Detalle.id_comanda AS ID FROM Comandas_Cabecera JOIN Comandas_Detalle ON Comandas_Cabecera.id_comanda = Comandas_Detalle.id_comanda JOIN Mozos ON Comandas_Cabecera.id_mozo = Mozos.id_mozo WHERE Comandas_Detalle.baja=0 AND Comandas_Cabecera.baja=0 AND Mozos.id_mozo=@idmozo AND Mozos.baja=0 GROUP BY Comandas_Cabecera.fecha, Comandas_Cabecera.hora, Comandas_Detalle.id_comanda ORDER BY fech, hor DESC", conexion);
                comando.Parameters.Add("@idmozo", SqlDbType.Int);
                comando.Parameters["@idmozo"].Value = id_mozo;
                SqlDataReader datos = comando.ExecuteReader();
                while (datos.Read())
                {
                    cadena = datos["fech"].ToString();
                    linea = cadena.Split(' ');
                    tiempo = (TimeSpan)datos["hor"];
                    dgv_comandas_cabecera.Rows.Add(linea[0], tiempo.ToString(@"hh\:mm"), datos["tot"].ToString(), datos["ID"].ToString());
                }
                datos.Close();

                conexion.Close();
                dgv_comandas_cabecera.ClearSelection();
            }
            catch (AccessViolationException Exception)
            {
                Console.WriteLine(Exception.Message);
            }
        }

        //al hacer click en una determinada fila del datagridview de la cabecera de las comandas se muestra el detalle de esa comanda con los datos correspondientes en otro datagridview
        private void dgv_comandas_cabecera_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int indice = dgv_comandas_cabecera.SelectedCells[0].RowIndex;
                DataGridViewRow fila_seleccionada = dgv_comandas_cabecera.Rows[indice];
                int id_comanda = Convert.ToInt32(fila_seleccionada.Cells["ID_Comanda"].Value);

                dgv_comandas_detalle.Rows.Clear();

                conexion.Open();

                SqlCommand comando = new SqlCommand("SELECT Productos.descripcion AS descr, Comandas_Detalle.cantidad AS cant, Comandas_Detalle.subtotal AS sub FROM Comandas_Cabecera JOIN Comandas_Detalle ON Comandas_Cabecera.id_comanda = Comandas_Detalle.id_comanda JOIN Productos ON Comandas_Detalle.id_producto = Productos.id_producto WHERE Comandas_Detalle.baja=0 AND Comandas_Cabecera.baja=0 AND Comandas_Detalle.id_comanda=@idcomanda AND Productos.baja=0 ORDER BY descr", conexion);
                comando.Parameters.Add("@idcomanda", SqlDbType.Int);
                comando.Parameters["@idcomanda"].Value = id_comanda;
                SqlDataReader datos = comando.ExecuteReader();
                while (datos.Read())
                {                    
                    dgv_comandas_detalle.Rows.Add(datos["descr"].ToString(), datos["cant"].ToString(), datos["sub"].ToString());
                }
                datos.Close();

                conexion.Close();
            }
            catch (AccessViolationException Exception)
            {
                Console.WriteLine(Exception.Message);
            }
        }
    }
}
