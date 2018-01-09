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
    public partial class Productos : Form
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


        //primera pestaña

        int id_producto = 0;

        //carga dgv de productos
        private void cargarGridProductos()
        {
            try
            {
                //se carga una grilla con todos los datos posibles de una tabla en particular de una base de datos
                conexion.Open();
                string sql = "SELECT id_producto, descripcion, id_categoria, precio, compuesto FROM Productos JOIN Categoria ON Productos.id_categoria = Categorias.id_categoria WHERE Productos.baja=0";
                DataTable lista = new DataTable("lista");
                SqlCommand comando = new SqlCommand(sql, conexion);
                SqlDataAdapter sqldat = new SqlDataAdapter(comando);
                sqldat.Fill(lista);
                this.dgv_productos.DataSource = lista;
                conexion.Close();
            }
            catch (AccessViolationException Exception)
            {
                Console.WriteLine(Exception.Message);
            }
        }

        //limpiar campos
        private void limpiarTexto()
        {
            txt_descripcion.Text = "";
            txt_precio.Text = "";
            clb_simple_compuesto.SetItemChecked(1, true);
            id_producto = 0;
        }

        //se ponen las categorias en un combobox
        private void cargarListaCategorias()
        {
            try
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand("SELECT id_categoria, nombre_categoria FROM Categorias WHERE baja=0", conexion);
                System.Data.DataTable tabla_categorias = new System.Data.DataTable();
                SqlDataAdapter sqldat = new SqlDataAdapter(comando);
                sqldat.Fill(tabla_categorias);
                cb_categoria.DisplayMember = "nombre_categoria";
                cb_categoria.ValueMember = "id_categoria";
                cb_categoria.DataSource = tabla_categorias;
                conexion.Close();
            }
            catch (AccessViolationException Exception)
            {
                Console.WriteLine(Exception.Message);
            }
        }

        //carga dgv de materias primas
        private void cargarGridMaterias()
        {
            try
            {
                //se carga una grilla con todos los datos posibles de una tabla en particular de una base de datos
                conexion.Open();
                string sql = "SELECT id_materia, descripcion, costo, id_marca FROM Materias_Primas JOIN Marcas ON Materias_Primas.id_marca = Marcas.id_marca WHERE Materias_Primas.baja=0";
                DataTable lista = new DataTable("lista");
                SqlCommand comando = new SqlCommand(sql, conexion);
                SqlDataAdapter sqldat = new SqlDataAdapter(comando);
                sqldat.Fill(lista);
                this.dgv_materia_prima.DataSource = lista;
                conexion.Close();
            }
            catch (AccessViolationException Exception)
            {
                Console.WriteLine(Exception.Message);
            }
        }

        //permite un item del checklist
        private void clb_simple_compuesto_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked)
                for (int ix = 0; ix < clb_simple_compuesto.Items.Count; ++ix)
                    if (e.Index != ix) clb_simple_compuesto.SetItemChecked(ix, false);
        }

        private void dgv_productos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //Cada vez que se seleccione una fila, se mostraran los datos correspondientes en los textboxs para luego modificar o eliminar los productos
                int campa = Convert.ToInt32(this.dgv_productos.CurrentRow.Cells["id_producto"].Value);
                conexion.Open();
                SqlCommand comando = new SqlCommand("SELECT * FROM Productos WHERE id_producto=@ID ", conexion);
                comando.Parameters.Add("@ID", SqlDbType.VarChar);
                comando.Parameters["@ID"].Value = campa;
                SqlDataReader datos = comando.ExecuteReader();
                if (datos.Read())
                {
                    txt_descripcion.Text = datos["descripcion"].ToString();
                    txt_precio.Text = datos["precio"].ToString();
                    cb_categoria.SelectedValue = datos["id_categoria"];
                    if (Convert.ToBoolean(datos["compuesto"]) == false)
                    {
                        clb_simple_compuesto.SetItemChecked(1, true);
                        clb_simple_compuesto.SetItemChecked(2, false);
                    }

                    else
                    {
                        clb_simple_compuesto.SetItemChecked(1, false);
                        clb_simple_compuesto.SetItemChecked(2, true);
                    }
                    id_producto = Convert.ToInt32(datos["id_producto"]);
                }
                datos.Close();

                conexion.Close();
            }
            catch (AccessViolationException Exception)
            {
                Console.WriteLine(Exception.Message);
            }

        }

        private void b_eliminar_Click(object sender, EventArgs e)
        {
            if (id_producto != 0)
            {
                //Se pregunta si de verdad quiere eliminar a un producto.
                if (MessageBox.Show("¿Está seguro?", "Eliminar", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        //los productos eliminados siguen estando en la tabla de la base de datos, pero no se muestran como activos
                        conexion.Open();
                        string sql = "UPDATE Productos SET baja=1 WHERE id_producto=@ID";
                        SqlCommand comando = new SqlCommand(sql, conexion);
                        comando.Parameters.Add("@ID", SqlDbType.Int);
                        comando.Parameters["@ID"].Value = id_producto;
                        comando.ExecuteNonQuery();

                        conexion.Close();
                        cargarGridProductos();
                        limpiarTexto();
                        MessageBox.Show("Se eliminó el producto.", "Atención");
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

        private void b_limpiar_campos_Click(object sender, EventArgs e)
        {
            limpiarTexto();
        }

        //segunda pestaña

        int id_materia_prima = 0;

        //carga dgv de materias primas
        private void cargarGridMateriasPrimas()
        {
            try
            {
                //se carga una grilla con todos los datos posibles de una tabla en particular de una base de datos
                conexion.Open();
                string sql = "SELECT id_materia_prima, descripcion, id_marca, costo FROM Materia_Prima JOIN Marcas ON Materia_Prima.id_marca = Marcas.id_marca WHERE Materia_Prima.baja=0";
                DataTable lista = new DataTable("lista");
                SqlCommand comando = new SqlCommand(sql, conexion);
                SqlDataAdapter sqldat = new SqlDataAdapter(comando);
                sqldat.Fill(lista);
                this.dgv_productos.DataSource = lista;
                conexion.Close();
            }
            catch (AccessViolationException Exception)
            {
                Console.WriteLine(Exception.Message);
            }
        }

        //limpiar campos
        private void limpiarTexto2()
        {
            txt_descripcion2.Text = "";
            txt_costo.Text = "";
            id_materia_prima = 0;
        }

        //se ponen las categorias en un combobox
        private void cargarListaMarcas()
        {
            try
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand("SELECT id_marca, nombre_marca FROM Marcas WHERE baja=0", conexion);
                System.Data.DataTable tabla_marcas = new System.Data.DataTable();
                SqlDataAdapter sqldat = new SqlDataAdapter(comando);
                sqldat.Fill(tabla_marcas);
                cb_marca.DisplayMember = "nombre_marca";
                cb_marca.ValueMember = "id_marca";
                cb_marca.DataSource = tabla_marcas;
                conexion.Close();
            }
            catch (AccessViolationException Exception)
            {
                Console.WriteLine(Exception.Message);
            }
        }

        private void dgv_materias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //Cada vez que se seleccione una fila, se mostraran los datos correspondientes en los textboxs para luego modificar o eliminar los productos
                int campa = Convert.ToInt32(this.dgv_productos.CurrentRow.Cells["id_materia_prima"].Value);
                conexion.Open();
                SqlCommand comando = new SqlCommand("SELECT * FROM Materia_Prima WHERE id_materia_prima=@ID ", conexion);
                comando.Parameters.Add("@ID", SqlDbType.VarChar);
                comando.Parameters["@ID"].Value = campa;
                SqlDataReader datos = comando.ExecuteReader();
                if (datos.Read())
                {
                    txt_descripcion2.Text = datos["descripcion"].ToString();
                    txt_costo.Text = datos["costo"].ToString();
                    cb_marca.SelectedValue = datos["id_marca"];
                    
                    id_materia_prima = Convert.ToInt32(datos["id_materia_prima"]);
                }
                datos.Close();

                conexion.Close();
            }
            catch (AccessViolationException Exception)
            {
                Console.WriteLine(Exception.Message);
            }

        }

        private void b_eliminar2_Click(object sender, EventArgs e)
        {
            if (id_materia_prima != 0)
            {
                //Se pregunta si de verdad quiere eliminar a una materia prima.
                if (MessageBox.Show("¿Está seguro?", "Eliminar", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        //las materias primas eliminadas siguen estando en la tabla de la base de datos, pero no se muestran como activos
                        conexion.Open();
                        string sql = "UPDATE Materia_Prima SET baja=1 WHERE id_materia_prima=@ID";
                        SqlCommand comando = new SqlCommand(sql, conexion);
                        comando.Parameters.Add("@ID", SqlDbType.Int);
                        comando.Parameters["@ID"].Value = id_materia_prima;
                        comando.ExecuteNonQuery();

                        conexion.Close();
                        cargarGridProductos();
                        limpiarTexto();
                        MessageBox.Show("Se eliminó la materia prima.", "Atención");
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

        private void b_limpiar_campos2_Click(object sender, EventArgs e)
        {
            limpiarTexto();
        }

        //tercera pestaña / marcas

        int id_marca = 0;

        //carga dgv de marcas
        private void cargarGridMarcas()
        {
            try
            {
                //se carga una grilla con todos los datos posibles de una tabla en particular de una base de datos
                conexion.Open();
                string sql = "SELECT id_marca, nombre_marca FROM Marcas WHERE Marcas.baja=0";
                DataTable lista = new DataTable("lista");
                SqlCommand comando = new SqlCommand(sql, conexion);
                SqlDataAdapter sqldat = new SqlDataAdapter(comando);
                sqldat.Fill(lista);
                this.dgv_productos.DataSource = lista;
                conexion.Close();
            }
            catch (AccessViolationException Exception)
            {
                Console.WriteLine(Exception.Message);
            }
        }

        //limpiar campos
        private void limpiarTexto3()
        {
            txt_marca.Text = "";
        }

        private void b_limpiar_campos3_Click(object sender, EventArgs e)
        {
            limpiarTexto();
        }
        //tercera pestaña / categorias
        int id_categoria = 0;

        //carga dgv de marcas
        private void cargarGridCategoria()
        {
            try
            {
                //se carga una grilla con todos los datos posibles de una tabla en particular de una base de datos
                conexion.Open();
                string sql = "SELECT id_categoria, nombre_categoria FROM Categorias WHERE baja=0";
                DataTable lista = new DataTable("lista");
                SqlCommand comando = new SqlCommand(sql, conexion);
                SqlDataAdapter sqldat = new SqlDataAdapter(comando);
                sqldat.Fill(lista);
                this.dgv_productos.DataSource = lista;
                conexion.Close();
            }
            catch (AccessViolationException Exception)
            {
                Console.WriteLine(Exception.Message);
            }
        }

        //limpiar campos
        private void limpiarTexto4()
        {
            txt_categoria.Text = "";
        }

        private void b_limpiar4_campos_Click(object sender, EventArgs e)
        {
            limpiarTexto();
        }

        public Productos()
        {
            InitializeComponent();
        }

        //no tocar, rompe diseño
        private void Mesas_Load(object sender, EventArgs e)
        {

        }

        //al cerrar el formulario hijo, se hacen visibles los botones de la tabla del formulario padre
        private void Productos_FormClosed(object sender, FormClosedEventArgs e)
        {
            Principal padre = this.MdiParent as Principal;
            padre.cambiar_color_boton();
            padre.tabla_visible_si();
            padre.menustrip_visible_si();
        }

    }
}
