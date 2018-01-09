﻿using System;
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

        // *****************debe verificar si es la primer pestaña 
        private bool validacion_copada1()
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

                if (txt_descripcion.Text.Length < 3)
                {
                    error += "Nombre de producto muy corto. ";
                }

                if (float.Parse(txt_precio.Text) < 0)
                {
                    error += "Ingrese un precio mayor. ";
                }
     
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

        // *****************debe verificar si es la segunda pestaña 
        private bool validacion_copada2()
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

                if (txt_descripcion.Text.Length < 3)
                {
                    error += "Nombre de producto muy corto. ";
                }

                if (float.Parse(txt_precio.Text) < 0)
                {
                    error += "Ingrese un precio mayor. ";
                }

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

        // *****************debe verificar si es la tercer pestaña 
        private bool validacion_copada3()
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

                if (txt_descripcion.Text.Length < 3)
                {
                    error += "Nombre de producto muy corto. ";
                }

                if (float.Parse(txt_precio.Text) < 0)
                {
                    error += "Ingrese un precio mayor. ";
                }

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

        private void b_agregar3_Click(object sender, EventArgs e)
        {
            try
            {
                if (validacion_copada3() == false)
                {
                    return;
                }
                conexion.Open();
                //Antes de agregar una marca, se intenta que no existan dos marcas iguales
                SqlCommand comando3 = new SqlCommand("SELECT * FROM Marcas WHERE nombre_marca=@Marca", conexion);
                comando3.Parameters.Add("@Marca", SqlDbType.Int);
                comando3.Parameters["@Marca"].Value = txt_marca.Text;
                SqlDataReader datos3 = comando3.ExecuteReader();
                if (datos3.Read())
                {
                    MessageBox.Show("Esta marca ya existe.", "Atención");
                    datos3.Close();
                    conexion.Close();
                    return;
                }
                datos3.Close();
                //Si la marca no existe, se agrega en la base de datos
                string sql = "INSERT INTO Marcas(nombre_marca, baja) VALUES (@Nombre,0)";
                SqlCommand comando = new SqlCommand(sql, conexion);
                comando.Parameters.Add("@Nombre", SqlDbType.VarChar);
                comando.Parameters["@Nombre"].Value = txt_marca.Text;
                comando.ExecuteNonQuery();

                conexion.Close();
                cargarGridMarcas();
                limpiarTexto();
                MessageBox.Show("Se ingresó el dato.", "Atención");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
        }

        private void b_modificar3_Click(object sender, EventArgs e)
        {
            if (id_marca != 0)
            {

                try
                {
                    if (validacion_copada3() == false)
                    {
                        return;
                    }

                    conexion.Open();
                    //al modificar la marca se verifica que no exista ya
                    SqlCommand comando4 = new SqlCommand("SELECT * FROM Marcas WHERE id_marca=@ID", conexion);
                    comando4.Parameters.Add("@ID", SqlDbType.Int);
                    comando4.Parameters["@ID"].Value = id_marca;
                    SqlDataReader datos4 = comando4.ExecuteReader();
                    string marcaor = "";
                    if (datos4.Read())
                    {
                        marcaor = (datos4["nombre_marca"]).ToString();
                    }
                    datos4.Close();

                    SqlCommand comando5 = new SqlCommand("SELECT * FROM Marca WHERE nombre_marca<>@Marca", conexion);
                    comando5.Parameters.Add("@Marca", SqlDbType.Int);
                    comando5.Parameters["@Marca"].Value = marcaor;
                    SqlDataReader datos5 = comando5.ExecuteReader();
                    String marcaref = "";
                    while (datos5.Read())
                    {
                        marcaref = datos5["nombre_marca"].ToString();
                        if (txt_marca.Text.Equals(marcaref))
                        {
                            MessageBox.Show("Esta Marca ya existe.", "Atención");
                            datos5.Close();
                            conexion.Close();
                            return;
                        }
                    }
                    datos5.Close();
                    //si el nombre esta bien, se modifica la marca
                    string sql = "UPDATE Marcas SET nombre_marca=@Nombre, WHERE id_marca=@ID";
                    SqlCommand comando = new SqlCommand(sql, conexion);
                    comando.Parameters.Add("@ID", SqlDbType.Int);
                    comando.Parameters["@ID"].Value = id_marca;
                    comando.Parameters.Add("@Nombre", SqlDbType.VarChar);
                    comando.Parameters["@Nombre"].Value = txt_marca.Text;

                    comando.ExecuteNonQuery();

                    conexion.Close();
                    cargarGridMarcas();
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

        private void b_eliminar3_Click(object sender, EventArgs e)
        {
            if (id_marca != 0)
            {
                //Se pregunta si de verdad quiere eliminar una marca... 
                if (MessageBox.Show("¿Está seguro?", "Eliminar", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        //las marcas eliminados siguen estando en la tabla de la base de datos, pero no se muestran como activos
                        conexion.Open();
                        string sql = "UPDATE Marcas SET baja=1 WHERE id_marca=@ID";
                        SqlCommand comando = new SqlCommand(sql, conexion);
                        comando.Parameters.Add("@ID", SqlDbType.Int);
                        comando.Parameters["@ID"].Value = id_marca;
                        comando.ExecuteNonQuery();

                        conexion.Close();
                        cargarGridMarcas();
                        limpiarTexto();
                        MessageBox.Show("Se eliminó la marca.", "Atención");
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



        //tercera pestaña / categorias
        int id_categoria = 0;

        // *****************debe verificar si es la primer pestaña 
        private bool validacion_copada4()
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

                if (txt_categoria.Text.Length < 3)
                {
                    error += "Nombre de categoria muy corto. ";
                }

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

        //carga dgv de categorias
        private void cargarGridCategorias()
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

        private void b_agregar4_Click(object sender, EventArgs e)
        {
            try
            {
                if (validacion_copada4() == false)
                {
                    return;
                }
                conexion.Open();
                //Antes de agregar una categoria, se intenta que no existan dos categorias iguales
                SqlCommand comando3 = new SqlCommand("SELECT * FROM Categorias WHERE nombre_categoria=@Categoria", conexion);
                comando3.Parameters.Add("@Categoria", SqlDbType.Int);
                comando3.Parameters["@Categoria"].Value = txt_categoria.Text;
                SqlDataReader datos3 = comando3.ExecuteReader();
                if (datos3.Read())
                {
                    MessageBox.Show("Esta categoría ya existe.", "Atención");
                    datos3.Close();
                    conexion.Close();
                    return;
                }
                datos3.Close();
                //Si la categoria no existe, se agrega en la base de datos
                string sql = "INSERT INTO Categorias(nombre_categoria, baja) VALUES (@Nombre,0)";
                SqlCommand comando = new SqlCommand(sql, conexion);
                comando.Parameters.Add("@Nombre", SqlDbType.VarChar);
                comando.Parameters["@Nombre"].Value = txt_categoria.Text;
                comando.ExecuteNonQuery();

                conexion.Close();
                cargarGridMarcas();
                limpiarTexto();
                MessageBox.Show("Se ingresó el dato.", "Atención");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
        }

        private void b_modificar4_Click(object sender, EventArgs e)
        {
            if (id_categoria != 0)
            {

                try
                {
                    if (validacion_copada4() == false)
                    {
                        return;
                    }

                    conexion.Open();
                    //al modificar la categoria se verifica que no exista ya
                    SqlCommand comando4 = new SqlCommand("SELECT * FROM Categorias WHERE id_categoria=@ID", conexion);
                    comando4.Parameters.Add("@ID", SqlDbType.Int);
                    comando4.Parameters["@ID"].Value = id_categoria;
                    SqlDataReader datos4 = comando4.ExecuteReader();
                    string categoriaor = "";
                    if (datos4.Read())
                    {
                        categoriaor = (datos4["nombre_categoria"]).ToString();
                    }
                    datos4.Close();

                    SqlCommand comando5 = new SqlCommand("SELECT * FROM Categorias WHERE nombre_categoria<>@Categoria", conexion);
                    comando5.Parameters.Add("@Categoria", SqlDbType.Int);
                    comando5.Parameters["@Categoria"].Value = categoriaor;
                    SqlDataReader datos5 = comando5.ExecuteReader();
                    String categoriaref = "";
                    while (datos5.Read())
                    {
                        categoriaref = datos5["nombre_categoria"].ToString();
                        if (txt_marca.Text.Equals(categoriaref))
                        {
                            MessageBox.Show("Esta Categoría ya existe.", "Atención");
                            datos5.Close();
                            conexion.Close();
                            return;
                        }
                    }
                    datos5.Close();
                    //si el nombre esta bien, se modifica la categoria
                    string sql = "UPDATE Categorias SET nombre_categoria=@Nombre, WHERE id_categoria=@ID";
                    SqlCommand comando = new SqlCommand(sql, conexion);
                    comando.Parameters.Add("@ID", SqlDbType.Int);
                    comando.Parameters["@ID"].Value = id_marca;
                    comando.Parameters.Add("@Nombre", SqlDbType.VarChar);
                    comando.Parameters["@Nombre"].Value = txt_categoria.Text;

                    comando.ExecuteNonQuery();

                    conexion.Close();
                    cargarGridMarcas();
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

        private void b_eliminar4_Click(object sender, EventArgs e)
        {
            if (id_marca != 0)
            {
                //Se pregunta si de verdad quiere eliminar una categoria... 
                if (MessageBox.Show("¿Está seguro?", "Eliminar", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        //las marcas eliminados siguen estando en la tabla de la base de datos, pero no se muestran como activos
                        conexion.Open();
                        string sql = "UPDATE Categorias SET baja=1 WHERE id_categoria=@ID";
                        SqlCommand comando = new SqlCommand(sql, conexion);
                        comando.Parameters.Add("@ID", SqlDbType.Int);
                        comando.Parameters["@ID"].Value = id_categoria;
                        comando.ExecuteNonQuery();

                        conexion.Close();
                        cargarGridCategorias();
                        limpiarTexto();
                        MessageBox.Show("Se eliminó la categoria.", "Atención");
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
