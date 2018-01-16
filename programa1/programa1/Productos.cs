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

        SqlConnection conexion = new SqlConnection("Data Source=SEBA-PC\\SQLEXPRESS;Initial Catalog=Restaurante;Integrated Security=True");

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

        //evita que ponga 2 espacios seguidos o empiece un textbox con espacios
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


        //primera pestaña

        int id_producto = 0;

        //carga dgv de productos
        private void cargarGridProductos()
        {
            try
            {
                //se carga una grilla con todos los datos posibles de una tabla en particular de una base de datos
                conexion.Open();
                string sql = "SELECT Productos.id_producto AS ID, Productos.descripcion AS Descripción, Productos.id_categoria AS Categoría, Productos.precio AS Precio, Productos.compuesto AS Compuesto FROM Productos JOIN Categoria ON Productos.id_categoria = Categoria.id_categoria WHERE Productos.baja=0";
                DataTable lista = new DataTable("lista");
                SqlCommand comando = new SqlCommand(sql, conexion);
                SqlDataAdapter sqldat = new SqlDataAdapter(comando);
                sqldat.Fill(lista);
                this.dgv_productos.DataSource = lista;
                dgv_productos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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
            clb_simple_compuesto.SetItemChecked(0, true);
            id_producto = 0;
            dgv_materia_prima.ClearSelection();
            dgv_materia_producto.ClearSelection();
            dgv_productos.ClearSelection();
        }

        // validacion de datos
        private bool validacion_copada1()
        {
            string error = "";
            //primero se verifica si hay textboxs vacios
            if (String.IsNullOrEmpty(txt_descripcion.Text) == true || (String.IsNullOrEmpty(txt_precio.Text) == true)) 
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
                SqlCommand comando = new SqlCommand("SELECT id_categoria, nombre_categoria FROM Categoria WHERE baja=0", conexion);
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
                string sql = "SELECT Materia_Prima.id_materia_prima AS ID, Materia_Prima.descripcion AS [Materia Prima], Marca.nombre_marca AS Marca, Materia_Prima.costo AS Costo FROM Materia_Prima JOIN Marca ON Materia_Prima.id_marca = Marca.id_marca WHERE Materia_Prima.baja=0";
                DataTable lista = new DataTable("lista");
                SqlCommand comando = new SqlCommand(sql, conexion);
                SqlDataAdapter sqldat = new SqlDataAdapter(comando);
                sqldat.Fill(lista);
                this.dgv_materia_prima.DataSource = lista;
                dgv_materia_prima.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgv_materia_prima.Columns["ID"].Visible = false;
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
            if (clb_simple_compuesto.CheckedItems.Count == 1)
            {
                Boolean isCheckedItemBeingUnchecked = (e.CurrentValue == CheckState.Checked);
                if (isCheckedItemBeingUnchecked)
                {
                    e.NewValue = CheckState.Checked;
                }
                else
                {
                    Int32 checkedItemIndex = clb_simple_compuesto.CheckedIndices[0];
                    clb_simple_compuesto.ItemCheck -= clb_simple_compuesto_ItemCheck;
                    clb_simple_compuesto.SetItemChecked(checkedItemIndex, false);
                    clb_simple_compuesto.ItemCheck += clb_simple_compuesto_ItemCheck;
                }

            }

            if (clb_simple_compuesto.SelectedIndex==0)
            {
                b_agregarmateria.Enabled = false;
                b_quitar.Enabled = false;
                dgv_materia_prima.DataSource=null;
                dgv_materia_prima.Enabled = false;
                dgv_materia_producto.Rows.Clear();
                dgv_materia_producto.Enabled = false;
            }
            else
            {
                b_agregarmateria.Enabled = true;
                b_quitar.Enabled = true;
                dgv_materia_prima.Enabled = true;
                cargarGridMaterias();
                dgv_materia_producto.Enabled = true;
            }
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

        //espacios primer pestaña
        private void txt_descripcion_KeyDown(object sender, KeyEventArgs e)
        {
            no_mas_espacios(e);
        }

        private void txt_precio_KeyDown(object sender, KeyEventArgs e)
        {
            no_mas_espacios(e);
        }



        //segunda pestaña

        int id_materia_prima = 0;

        // validacion de datos
        private bool validacion_copada2()
        {
            string error = "";
            //primero se verifica si hay textboxs vacios
            if (String.IsNullOrEmpty(txt_descripcion2.Text) == true || (String.IsNullOrEmpty(txt_costo.Text) == true))
            {
                MessageBox.Show("Faltan completar campos", "Atención");
                return false;
            }
            //si no hay textboxs vacios entonces se pasa por una serie de validaciones para  tratar de tener mas datos correctos
            else
            {

                if (txt_descripcion2.Text.Length < 3)
                {
                    error += "Nombre de Materia Prima muy corto. ";
                }

                if (float.Parse(txt_costo.Text) < 0)
                {
                    error += "Ingrese un costo mayor. ";
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
                string sql = "SELECT Materia_Prima.id_materia_prima AS ID, Materia_Prima.descripcion AS [Materia Prima], Marca.nombre_marca AS Marca, Materia_Prima.costo AS Costo FROM Materia_Prima JOIN Marca ON Materia_Prima.id_marca = Marca.id_marca WHERE Materia_Prima.baja=0";
                DataTable lista = new DataTable("lista");
                SqlCommand comando = new SqlCommand(sql, conexion);
                SqlDataAdapter sqldat = new SqlDataAdapter(comando);
                sqldat.Fill(lista);
                this.dgv_materias.DataSource = lista;
                dgv_materias.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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
            cb_marca.SelectedValue = 1;
            dgv_materias.ClearSelection();
        }

        //se ponen las categorias en un combobox
        private void cargarListaMarcas()
        {
            try
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand("SELECT id_marca, nombre_marca FROM Marca WHERE baja=0", conexion);
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
                        cargarGridMateriasPrimas();
                        limpiarTexto2();
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
            limpiarTexto2();
        }

        //agregar dropdownlist
        private void b_agregar2_Click(object sender, EventArgs e)
        {
            try
            {
                if (validacion_copada2() == false)
                {
                    return;
                }
                conexion.Open();
                //Antes de agregar una materia prima, se intenta que no existan dos iguales
                SqlCommand comando3 = new SqlCommand("SELECT * FROM Materia_Prima WHERE descripcion=@Descripcion and id_marca=@Marca", conexion);
                comando3.Parameters.Add("@Descripcion", SqlDbType.VarChar);
                comando3.Parameters["@Descripcion"].Value = txt_descripcion2.Text;
                comando3.Parameters.Add("@Marca", SqlDbType.Int);
                comando3.Parameters["@Marca"].Value = cb_marca.SelectedValue;
                SqlDataReader datos3 = comando3.ExecuteReader();
                if (datos3.Read())
                {
                    MessageBox.Show("Ya existe una Materia Prima con la misma Descripción y la misma Marca", "Atención");
                    datos3.Close();
                    conexion.Close();
                    return;
                }
                datos3.Close();
                //Si la materia prima no existe, se agrega en la base de datos
                string sql = "INSERT INTO Materia_Prima(descripcion, id_marca, costo, baja) VALUES (@Descripcion, @Marca, @Costo, 0)";
                SqlCommand comando = new SqlCommand(sql, conexion);
                comando.Parameters.Add("@Descripcion", SqlDbType.VarChar);
                comando.Parameters["@Descripcion"].Value = txt_descripcion2.Text;
                comando.Parameters.Add("@Marca", SqlDbType.Int);
                comando.Parameters["@Marca"].Value = cb_marca.SelectedValue;
                comando.Parameters.Add("@Costo", SqlDbType.Float);
                comando.Parameters["@Costo"].Value = txt_costo.Text;
                comando.ExecuteNonQuery();

                conexion.Close();
                cargarGridMateriasPrimas();
                cargarGridMaterias();
                limpiarTexto2();
                MessageBox.Show("Se ingresó el dato.", "Atención");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
        }

        //modificacion de materias primas
        private void b_modificar2_Click(object sender, EventArgs e)
        {
            if (id_materia_prima != 0)
            {

                try
                {
                    if (validacion_copada2() == false)
                    {
                        return;
                    }

                    conexion.Open();
                    //al modificar la materia prima se verifica que no exista ya
                    SqlCommand comando4 = new SqlCommand("SELECT * FROM Materia_Prima WHERE id_materia_prima<>@ID and descripcion=@Descripcion and id_marca=@Marca", conexion);
                    comando4.Parameters.Add("@ID", SqlDbType.Int);
                    comando4.Parameters["@ID"].Value = id_materia_prima;
                    comando4.Parameters.Add("@Descripcion", SqlDbType.VarChar);
                    comando4.Parameters["@Descripcion"].Value = txt_descripcion2.Text;
                    comando4.Parameters.Add("@Marca", SqlDbType.Int);
                    comando4.Parameters["@Marca"].Value = cb_marca.SelectedValue;
                    SqlDataReader datos4 = comando4.ExecuteReader();
                    if (datos4.Read())
                    {
                        MessageBox.Show("Esta Materia Prima ya existe.", "Atención");
                        datos4.Close();
                        conexion.Close();
                        return;
                    }

                    //si la descripcion esta bien, se modifica la materia prima
                    string sql = "UPDATE Materia_Prima SET descripcion=@Descripcion, costo=@Costo, id_marca=@Marca WHERE id_materia_prima=@ID";
                    SqlCommand comando = new SqlCommand(sql, conexion);
                    comando.Parameters.Add("@ID", SqlDbType.Int);
                    comando.Parameters["@ID"].Value = id_materia_prima;
                    comando.Parameters.Add("@Descripcion", SqlDbType.VarChar);
                    comando.Parameters["@Descripcion"].Value = txt_descripcion2.Text;
                    comando.Parameters.Add("@Costo", SqlDbType.Float);
                    comando.Parameters["@Costo"].Value = txt_costo.Text;
                    comando.Parameters.Add("@Marca", SqlDbType.Int);
                    comando.Parameters["@Marca"].Value = cb_marca.SelectedValue;
                    datos4.Close();
                    comando.ExecuteNonQuery();

                    conexion.Close();
                    cargarGridMateriasPrimas();
                    MessageBox.Show("Se modificó el dato.", "Atención");
                    limpiarTexto2();
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

        private void dgv_materias_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //Cada vez que se seleccione una fila, se mostraran los datos correspondientes en los textboxs para luego modificar o eliminar los productos
                int campa = Convert.ToInt32(this.dgv_materias.CurrentRow.Cells["ID"].Value);
                conexion.Open();
                SqlCommand comando = new SqlCommand("SELECT * FROM Materia_Prima WHERE id_materia_prima=@ID ", conexion);
                comando.Parameters.Add("@ID", SqlDbType.VarChar);
                comando.Parameters["@ID"].Value = campa;
                SqlDataReader datos = comando.ExecuteReader();
                if (datos.Read())
                {
                    txt_descripcion2.Text = datos["descripcion"].ToString();
                    id_materia_prima = Convert.ToInt32(datos["id_materia_prima"]);
                    cb_marca.SelectedValue = Convert.ToInt32(datos["id_marca"]);
                    txt_costo.Text= datos["costo"].ToString();
                }
                datos.Close();

                conexion.Close();
            }
            catch (AccessViolationException Exception)
            {
                Console.WriteLine(Exception.Message);
            }
        }

        //espacios segunda pestaña
        private void txt_descripcion2_KeyDown(object sender, KeyEventArgs e)
        {
            no_mas_espacios(e);
        }

        private void txt_costo_KeyDown(object sender, KeyEventArgs e)
        {
            no_mas_espacios(e);
        }


        //tercera pestaña / marcas

        int id_marca = 0;

        // validacion de datos 
        private bool validacion_copada3()
        {
            string error = "";
            //primero se verifica si hay textboxs vacios
            if (String.IsNullOrEmpty(txt_marca.Text) == true)
            {
                MessageBox.Show("Faltan completar campos", "Atención");
                return false;
            }
            //si no hay textboxs vacios entonces se pasa por una serie de validaciones para  tratar de tener mas datos correctos
            else
            {

                if (txt_marca.Text.Length < 2)
                {
                    error += "Nombre de Marca muy corto. ";
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
                string sql = "SELECT id_marca AS ID, nombre_marca AS Marca FROM Marca WHERE baja=0";
                DataTable lista = new DataTable("lista");
                SqlCommand comando = new SqlCommand(sql, conexion);
                SqlDataAdapter sqldat = new SqlDataAdapter(comando);
                sqldat.Fill(lista);
                this.dgv_marca.DataSource = lista;
                dgv_marca.AutoSizeColumnsMode=DataGridViewAutoSizeColumnsMode.Fill;
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
            id_marca = 0;
            dgv_marca.ClearSelection();
            dgv_categoria.ClearSelection();
            cargarListaMarcas();
        }

        private void b_limpiar_campos3_Click(object sender, EventArgs e)
        {
            limpiarTexto3();

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
                SqlCommand comando3 = new SqlCommand("SELECT * FROM Marca WHERE nombre_marca=@Marca", conexion);
                comando3.Parameters.Add("@Marca", SqlDbType.VarChar);
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
                string sql = "INSERT INTO Marca(nombre_marca, baja) VALUES (@Nombre,0)";
                SqlCommand comando = new SqlCommand(sql, conexion);
                comando.Parameters.Add("@Nombre", SqlDbType.VarChar);
                comando.Parameters["@Nombre"].Value = txt_marca.Text;
                comando.ExecuteNonQuery();

                conexion.Close();
                cargarGridMarcas();
                limpiarTexto3();
                cargarListaMarcas();
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
                    SqlCommand comando4 = new SqlCommand("SELECT * FROM Marca WHERE id_marca=@ID", conexion);
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
                    comando5.Parameters.Add("@Marca", SqlDbType.VarChar);
                    comando5.Parameters["@Marca"].Value = marcaor;
                    SqlDataReader datos5 = comando5.ExecuteReader();
                    String marcaref = "";
                    while (datos5.Read())
                    {
                        marcaref = datos5["nombre_marca"].ToString();
                        if (txt_marca.Text.Equals(marcaref))
                        {
                            MessageBox.Show("Esta marca ya existe.", "Atención");
                            datos5.Close();
                            conexion.Close();
                            return;
                        }
                    }
                    datos5.Close();
                    //si el nombre esta bien, se modifica la marca
                    string sql = "UPDATE Marca SET nombre_marca=@Nombre WHERE id_marca=@ID";
                    SqlCommand comando = new SqlCommand(sql, conexion);
                    comando.Parameters.Add("@ID", SqlDbType.Int);
                    comando.Parameters["@ID"].Value = id_marca;
                    comando.Parameters.Add("@Nombre", SqlDbType.VarChar);
                    comando.Parameters["@Nombre"].Value = txt_marca.Text;

                    comando.ExecuteNonQuery();

                    conexion.Close();
                    cargarGridMarcas();
                    MessageBox.Show("Se modificó el dato.", "Atención");
                    limpiarTexto3();
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
                        string sql = "UPDATE Marca SET baja=1 WHERE id_marca=@ID";
                        SqlCommand comando = new SqlCommand(sql, conexion);
                        comando.Parameters.Add("@ID", SqlDbType.Int);
                        comando.Parameters["@ID"].Value = id_marca;
                        comando.ExecuteNonQuery();

                        conexion.Close();
                        cargarGridMarcas();
                        limpiarTexto3();
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

        private void dgv_marca_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //Cada vez que se seleccione una fila, se mostraran los datos correspondientes en los textboxs para luego modificar o eliminar los productos
                int campa = Convert.ToInt32(this.dgv_marca.CurrentRow.Cells["ID"].Value);
                conexion.Open();
                SqlCommand comando = new SqlCommand("SELECT * FROM Marca WHERE id_marca=@ID ", conexion);
                comando.Parameters.Add("@ID", SqlDbType.VarChar);
                comando.Parameters["@ID"].Value = campa;
                SqlDataReader datos = comando.ExecuteReader();
                if (datos.Read())
                {
                    txt_marca.Text = datos["nombre_marca"].ToString();
                    id_marca = Convert.ToInt32(datos["id_marca"]);
                }
                datos.Close();

                conexion.Close();
            }
            catch (AccessViolationException Exception)
            {
                Console.WriteLine(Exception.Message);
            }
        }



        //tercera pestaña / categorias
        int id_categoria = 0;

        // validacion de datos
        private bool validacion_copada4()
        {
            string error = "";
            //primero se verifica si hay textboxs vacios
            if (String.IsNullOrEmpty(txt_categoria.Text) == true)
            {
                MessageBox.Show("Faltan completar campos", "Atención");
                return false;
            }
            //si no hay textboxs vacios entonces se pasa por una serie de validaciones para  tratar de tener mas datos correctos
            else
            {

                if (txt_categoria.Text.Length < 2)
                {
                    error += "Nombre de Marca muy corto. ";
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
                string sql = "SELECT id_categoria AS ID, nombre_categoria AS Categoria FROM Categoria WHERE baja=0";
                DataTable lista = new DataTable("lista");
                SqlCommand comando = new SqlCommand(sql, conexion);
                SqlDataAdapter sqldat = new SqlDataAdapter(comando);
                sqldat.Fill(lista);
                this.dgv_categoria.DataSource = lista;
                dgv_categoria.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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
            id_categoria = 0;
            dgv_categoria.ClearSelection();
            dgv_marca.ClearSelection();

        }

        private void b_limpiar4_campos_Click(object sender, EventArgs e)
        {
            limpiarTexto4();
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
                SqlCommand comando3 = new SqlCommand("SELECT * FROM Categoria WHERE nombre_categoria=@Categoria", conexion);
                comando3.Parameters.Add("@Categoria", SqlDbType.VarChar);
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
                string sql = "INSERT INTO Categoria(nombre_categoria, baja) VALUES (@Nombre,0)";
                SqlCommand comando = new SqlCommand(sql, conexion);
                comando.Parameters.Add("@Nombre", SqlDbType.VarChar);
                comando.Parameters["@Nombre"].Value = txt_categoria.Text;
                comando.ExecuteNonQuery();

                conexion.Close();
                cargarGridCategorias();
                limpiarTexto4();
                cargarListaCategorias();
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
                    SqlCommand comando4 = new SqlCommand("SELECT * FROM Categoria WHERE id_categoria=@ID", conexion);
                    comando4.Parameters.Add("@ID", SqlDbType.Int);
                    comando4.Parameters["@ID"].Value = id_categoria;
                    SqlDataReader datos4 = comando4.ExecuteReader();
                    string categoriaor = "";
                    if (datos4.Read())
                    {
                        categoriaor = (datos4["nombre_categoria"]).ToString();
                    }
                    datos4.Close();

                    SqlCommand comando5 = new SqlCommand("SELECT * FROM Categoria WHERE nombre_categoria<>@Categoria", conexion);
                    comando5.Parameters.Add("@Categoria", SqlDbType.VarChar);
                    comando5.Parameters["@Categoria"].Value = categoriaor;
                    SqlDataReader datos5 = comando5.ExecuteReader();
                    String categoriaref = "";
                    while (datos5.Read())
                    {
                        categoriaref = datos5["nombre_categoria"].ToString();
                        if (txt_categoria.Text.Equals(categoriaref))
                        {
                            MessageBox.Show("Esta Categoría ya existe.", "Atención");
                            datos5.Close();
                            conexion.Close();
                            return;
                        }
                    }
                    datos5.Close();
                    //si el nombre esta bien, se modifica la categoria
                    string sql = "UPDATE Categoria SET nombre_categoria=@Nombre WHERE id_categoria=@ID";
                    SqlCommand comando = new SqlCommand(sql, conexion);
                    comando.Parameters.Add("@ID", SqlDbType.Int);
                    comando.Parameters["@ID"].Value = id_categoria;
                    comando.Parameters.Add("@Nombre", SqlDbType.VarChar);
                    comando.Parameters["@Nombre"].Value = txt_categoria.Text;

                    comando.ExecuteNonQuery();

                    conexion.Close();
                    cargarGridCategorias();
                    MessageBox.Show("Se modificó el dato.", "Atención");
                    limpiarTexto4();
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
            if (id_categoria != 0)
            {
                //Se pregunta si de verdad quiere eliminar una categoria... 
                if (MessageBox.Show("¿Está seguro?", "Eliminar", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        //las marcas eliminados siguen estando en la tabla de la base de datos, pero no se muestran como activos
                        conexion.Open();
                        string sql = "UPDATE Categoria SET baja=1 WHERE id_categoria=@ID";
                        SqlCommand comando = new SqlCommand(sql, conexion);
                        comando.Parameters.Add("@ID", SqlDbType.Int);
                        comando.Parameters["@ID"].Value = id_categoria;
                        comando.ExecuteNonQuery();

                        conexion.Close();
                        cargarGridCategorias();
                        limpiarTexto4();
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

        private void dgv_categoria_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //Cada vez que se seleccione una fila, se mostraran los datos correspondientes en los textboxs para luego modificar o eliminar los productos
                int campa = Convert.ToInt32(this.dgv_categoria.CurrentRow.Cells["ID"].Value);
                conexion.Open();
                SqlCommand comando = new SqlCommand("SELECT * FROM Categoria WHERE id_categoria=@ID ", conexion);
                comando.Parameters.Add("@ID", SqlDbType.VarChar);
                comando.Parameters["@ID"].Value = campa;
                SqlDataReader datos = comando.ExecuteReader();
                if (datos.Read())
                {
                    txt_categoria.Text = datos["nombre_categoria"].ToString();
                    id_categoria = Convert.ToInt32(datos["id_categoria"]);
                }
                datos.Close();

                conexion.Close();
            }
            catch (AccessViolationException Exception)
            {
                Console.WriteLine(Exception.Message);
            }
        }

        //espacios tercer pestaña
        private void txt_marca_KeyDown(object sender, KeyEventArgs e)
        {
            no_mas_espacios(e);
        }

        private void txt_categoria_KeyDown(object sender, KeyEventArgs e)
        {
            no_mas_espacios(e);
        }


        public Productos()
        {
            InitializeComponent();
            cargarGridProductos();
            cargarGridMateriasPrimas();
            cargarGridCategorias();
            cargarGridMarcas();
            cargarListaCategorias();
            cargarListaMarcas();
            b_agregarmateria.Enabled = false;
            b_quitar.Enabled = false;
            dgv_materia_prima.Enabled = false;
            dgv_materia_producto.Enabled = false;

            clb_simple_compuesto.SetItemChecked(0, true);
            b_agregarmateria.Enabled = false;
            b_quitar.Enabled = false;
            dgv_materia_prima.DataSource = null;
            dgv_materia_prima.Enabled = false;
            dgv_materia_producto.Rows.Clear();
            dgv_materia_producto.Enabled = false;
        }

        //no tocar, rompe diseño
        private void Mesas_Load(object sender, EventArgs e)
        {

        }
        private void txt_precio_TextChanged(object sender, EventArgs e)
        {

        }
        private void txt_marca_TextChanged(object sender, EventArgs e)
        {
        }
        private void txt_categoria_TextChanged(object sender, EventArgs e)
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

        private void Productos_Shown(object sender, EventArgs e)
        {
            dgv_marca.ClearSelection();
            dgv_categoria.ClearSelection();
            dgv_productos.ClearSelection();
            dgv_materias.ClearSelection();
            dgv_materia_prima.ClearSelection();
        }

        private void tc_formulario_Click(object sender, EventArgs e)
        {
            dgv_marca.ClearSelection();
            dgv_categoria.ClearSelection();
            dgv_productos.ClearSelection();
            dgv_materias.ClearSelection();
            dgv_materia_prima.ClearSelection();
        }


    }
}
