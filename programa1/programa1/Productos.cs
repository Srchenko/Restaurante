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
using System.Text.RegularExpressions;

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

        //evita que ponga 2 espacios seguidos 
        private int no_mas_espacios(KeyEventArgs e, int contador_general)
        {
            if (e.KeyCode == Keys.Space)
            {
                contador_general++;
                return contador_general;
            }
            else
            {
                contador_general = 0;
                return contador_general;
            }
        }

        // evita que empiece un textbox con comas
        private void no_comas_al_principio(object sender, KeyPressEventArgs e)
        {
            if ((sender as TextBox).SelectionStart == 0)
            {
                e.Handled = (e.KeyChar == ',');
            }
            else
            {
                e.Handled = false;
            }
        }

        // evita que empiece un textbox con espacios
        private void no_espacios_al_principio(object sender, KeyPressEventArgs e)
        {
            if ((sender as TextBox).SelectionStart == 0)
            {
                e.Handled = (e.KeyChar == (char)Keys.Space);
            }
            else
            {
                e.Handled = false;
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
                string sql = "SELECT Productos.id_producto AS ID, Productos.descripcion AS Descripción, Categoria.nombre_categoria AS Categoría, Productos.precio AS Precio, Productos.compuesto AS Compuesto FROM Productos JOIN Categoria ON Productos.id_categoria = Categoria.id_categoria WHERE Productos.baja=0";
                DataTable lista = new DataTable("lista");
                SqlCommand comando = new SqlCommand(sql, conexion);
                SqlDataAdapter sqldat = new SqlDataAdapter(comando);
                sqldat.Fill(lista);
                this.dgv_productos.DataSource = lista;
                dgv_productos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                foreach (DataGridViewColumn column in dgv_productos.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
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
            id_producto = 0;
            dgv_materia_prima.ClearSelection();
            dgv_materia_producto.ClearSelection();
            dgv_productos.ClearSelection();
            clb_simple_compuesto.SelectedIndex = 0;
            clb_simple_compuesto.SetItemChecked(0, true);
            clb_simple_compuesto.SetItemChecked(1, false);
            cb_categoria.SelectedValue = 1;
            b_agregarmateria.Enabled = false;
            b_quitar.Enabled = false;
            dgv_materia_prima.DataSource = null;
            dgv_materia_prima.Enabled = false;
            dgv_materia_producto.Rows.Clear();
            dgv_materia_producto.Enabled = false;
        }

        //validacion de datos
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

                if (cb_categoria.SelectedIndex == -1)
                {
                    error += "No existen categorías. ";
                }
     
            }

            Regex re = new Regex("^([0-9]{1,2})?,?([0-9]{3})?,?([0-9]{3})?([0-9]{2})?[$]?$");
            if (!re.IsMatch(txt_precio.Text))
            {
                error += "Ingrese un precio valido";
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
                foreach (DataGridViewColumn column in dgv_materia_prima.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
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
                foreach (DataGridViewRow fila in dgv_materia_producto.Rows)
                {
                    int id_materia_producto = Convert.ToInt32(fila.Cells["id_materia_producto"].Value);
                    foreach (DataGridViewRow fila2 in dgv_materia_prima.Rows)
                    {
                        if (Convert.ToInt32(fila2.Cells["ID"].Value) == id_materia_producto)
                        {
                            dgv_materia_prima.CurrentCell = null;
                            fila2.Visible = false;
                            break;
                        }

                    }
                }


            }
            if (id_producto !=0)
            {
                if (clb_simple_compuesto.SelectedIndex == 0)
                {
                    b_agregarmateria.Enabled = false;
                    b_quitar.Enabled = false;
                    dgv_materia_prima.DataSource = null;
                    dgv_materia_prima.Enabled = false;
                    dgv_materia_producto.Rows.Clear();
                    dgv_materia_producto.Enabled = false;
                }
                else
                {
                    int campa = Convert.ToInt32(this.dgv_productos.CurrentRow.Cells["ID"].Value);
                    b_agregarmateria.Enabled = true;
                    b_quitar.Enabled = true;
                    dgv_materia_prima.Enabled = true;
                    dgv_materia_producto.Enabled = true;
                    conexion.Close();
                    cargarGridMaterias();
                    dgv_materia_producto.Rows.Clear();
                    conexion.Open();
                    SqlCommand comando2 = new SqlCommand("SELECT Productos_Materia_Prima.id_materia_prima AS ID, Productos_Materia_Prima.cantidad AS cant, Materia_Prima.descripcion AS descrip, Marca.nombre_marca AS Marca, Materia_Prima.costo AS Costo FROM Productos_Materia_Prima JOIN Materia_Prima ON Materia_Prima.id_materia_prima = Productos_Materia_Prima.id_materia_prima JOIN Marca ON Materia_Prima.id_marca= Marca.id_marca WHERE Productos_Materia_Prima.id_producto=@ID ", conexion);
                    comando2.Parameters.Add("@ID", SqlDbType.Int);
                    comando2.Parameters["@ID"].Value = campa;
                    SqlDataReader datos2 = comando2.ExecuteReader();

                    while (datos2.Read())
                    {
                        int id_materia = Convert.ToInt32(datos2["ID"]);
                        int cantidad = Convert.ToInt32(datos2["cant"]);

                        dgv_materia_producto.Rows.Add(id_materia, datos2["descrip"].ToString(), datos2["Marca"].ToString(), datos2["Costo"].ToString(), cantidad);

                        foreach (DataGridViewRow fila in dgv_materia_producto.Rows)
                        {
                            int id_materia_producto = Convert.ToInt32(fila.Cells["id_materia_producto"].Value);
                            foreach (DataGridViewRow fila2 in dgv_materia_prima.Rows)
                            {
                                if (Convert.ToInt32(fila2.Cells["ID"].Value) == id_materia_producto)
                                {
                                    dgv_materia_prima.CurrentCell = null;
                                    fila2.Visible = false;
                                    break;
                                }

                            }
                        }

                    }
                    dgv_materia_producto.ClearSelection();
                    datos2.Close();
                }
                
            }
            else
            {
                if (clb_simple_compuesto.SelectedIndex == 0)
                {
                    b_agregarmateria.Enabled = false;
                    b_quitar.Enabled = false;
                    dgv_materia_prima.DataSource = null;
                    dgv_materia_prima.Enabled = false;
                    dgv_materia_producto.Rows.Clear();
                    dgv_materia_producto.Enabled = false;
                }
                else
                {
                    b_agregarmateria.Enabled = true;
                    b_quitar.Enabled = true;
                    dgv_materia_prima.Enabled = true;
                    conexion.Close();
                    cargarGridMaterias();
                    dgv_materia_producto.Enabled = true;
                    foreach (DataGridViewRow fila in dgv_materia_producto.Rows)
                    {
                        int id_materia_producto = Convert.ToInt32(fila.Cells["id_materia_producto"].Value);
                        foreach (DataGridViewRow fila2 in dgv_materia_prima.Rows)
                        {
                            if (Convert.ToInt32(fila2.Cells["ID"].Value) == id_materia_producto)
                            {
                                dgv_materia_prima.CurrentCell = null;
                                fila2.Visible = false;
                                break;
                            }

                        }
                    }
                }
            }
            conexion.Close();
            
            
        }

        private void dgv_productos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {     
                
                b_agregarmateria.Enabled = false;
                b_quitar.Enabled = false;
                dgv_materia_producto.Enabled = false;
                dgv_materia_prima.Enabled = false;
                clb_simple_compuesto.ClearSelected();
                dgv_materia_prima.DataSource = null;
                dgv_materia_producto.Rows.Clear();
                //Cada vez que se seleccione una fila, se mostraran los datos correspondientes en los textboxs para luego modificar o eliminar los productos
                int campa = Convert.ToInt32(this.dgv_productos.CurrentRow.Cells["ID"].Value);
                conexion.Open();
                SqlCommand comando = new SqlCommand("SELECT * FROM Productos WHERE id_producto=@ID ", conexion);
                comando.Parameters.Add("@ID", SqlDbType.Int);
                comando.Parameters["@ID"].Value = campa;
                SqlDataReader datos = comando.ExecuteReader();
                if (datos.Read())
                {
                    txt_descripcion.Text = datos["descripcion"].ToString();
                    txt_precio.Text = datos["precio"].ToString();
                    cb_categoria.SelectedValue = datos["id_categoria"];
                    id_producto = Convert.ToInt32(datos["id_producto"]);
                    
                    if (Convert.ToBoolean(datos["compuesto"]) == false)
                    {
                        datos.Close();
                        conexion.Close();
                        clb_simple_compuesto.SelectedIndex = 0;
                        clb_simple_compuesto.SetItemChecked(0, true);
                        clb_simple_compuesto.SetItemChecked(1, false);
                        b_agregarmateria.Enabled = false;
                        b_quitar.Enabled = false;
                        dgv_materia_producto.Enabled = false;
                        dgv_materia_prima.Enabled = false;
                        dgv_materia_prima.DataSource = null;
                        dgv_materia_producto.Rows.Clear();
                    }

                    else
                    {
                        datos.Close();
                        conexion.Close();
                        clb_simple_compuesto.SelectedIndex = 1;
                        clb_simple_compuesto.SetItemChecked(0, false);
                        clb_simple_compuesto.SetItemChecked(1, true);
                        b_agregarmateria.Enabled = true;
                        b_quitar.Enabled = true;
                        dgv_materia_prima.Enabled = true;
                        dgv_materia_producto.Enabled = true;
                        cargarGridMaterias();
                        dgv_materia_producto.Rows.Clear();
                        conexion.Open();
                        SqlCommand comando2 = new SqlCommand("SELECT Productos_Materia_Prima.id_materia_prima AS ID, Productos_Materia_Prima.cantidad AS cant, Materia_Prima.descripcion AS descrip, Marca.nombre_marca AS Marca, Materia_Prima.costo AS Costo FROM Productos_Materia_Prima JOIN Materia_Prima ON Materia_Prima.id_materia_prima = Productos_Materia_Prima.id_materia_prima JOIN Marca ON Materia_Prima.id_marca= Marca.id_marca WHERE Productos_Materia_Prima.id_producto=@ID ", conexion);
                        comando2.Parameters.Add("@ID", SqlDbType.Int);
                        comando2.Parameters["@ID"].Value = campa;
                        SqlDataReader datos2 = comando2.ExecuteReader();

                        while (datos2.Read())
                        {
                            int id_materia = Convert.ToInt32(datos2["ID"]);
                            int cantidad = Convert.ToInt32(datos2["cant"]);

                            dgv_materia_producto.Rows.Add(id_materia, datos2["descrip"].ToString(), datos2["Marca"].ToString(), datos2["Costo"].ToString(), cantidad);

                            foreach (DataGridViewRow fila in dgv_materia_producto.Rows)
                            {
                                int id_materia_producto = Convert.ToInt32(fila.Cells["id_materia_producto"].Value);
                                foreach (DataGridViewRow fila2 in dgv_materia_prima.Rows)
                                {
                                    if (Convert.ToInt32(fila2.Cells["ID"].Value) == id_materia_producto)
                                    {
                                        dgv_materia_prima.CurrentCell = null;
                                        fila2.Visible = false;
                                        break;
                                    }

                                }
                            }

                        }
                        dgv_materia_producto.ClearSelection();
                        datos2.Close();
                    }
                }
                datos.Close();
                conexion.Close();
            }
            catch (AccessViolationException Exception)
            {
                Console.WriteLine(Exception.Message);
            }

        }

        //elimina el producto seleccionado
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

        //boton de limpieza de textboxs y dropdownlist
        private void b_limpiar_campos_Click(object sender, EventArgs e)
        {
            limpiarTexto();
        }

        //variable bandera para que no se tome la primer fila del dgv automaticamente
        bool rowselected_materia_prima = false;
        private void dgv_materia_prima_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            rowselected_materia_prima = true;
        }

        //variable bandera para que no se tome la primer fila del dgv automaticamente
        bool rowselected_materia_producto = false;
        private void dgv_materia_producto_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            rowselected_materia_producto = true;
        }

        //mueve una fila de la tabla de materias primas a la tabla de materias de productos
        private void b_agregarmateria_Click(object sender, EventArgs e)
        {
            int id_materia_agregar=0;
            try
            {
                
                if(dgv_materia_prima.Rows.Count==0)
                {
                    MessageBox.Show("No hay más filas", "Atención");
                    return;
                }

                if (dgv_materia_producto.Rows.Count > 19)
                {
                    MessageBox.Show("Este producto ya posee demasiada materia prima", "Atención");
                    return;
                }

                if (rowselected_materia_prima == false)
                {
                    MessageBox.Show("Seleccione una fila.", "Atención");
                    return;
                }

                int indice = dgv_materia_prima.SelectedCells[0].RowIndex;
                DataGridViewRow fila_seleccionada = dgv_materia_prima.Rows[indice];
                id_materia_agregar = Convert.ToInt32(fila_seleccionada.Cells["ID"].Value);
                if (id_materia_agregar != 0)
                {
                    conexion.Open();

                    SqlCommand comando = new SqlCommand("SELECT Materia_Prima.id_materia_prima AS ID, Materia_Prima.descripcion AS descrip, Marca.nombre_marca AS Marca, Materia_Prima.costo AS Costo FROM Materia_Prima JOIN Marca ON Materia_Prima.id_marca = Marca.id_marca WHERE Materia_Prima.baja=0 and Materia_Prima.id_materia_prima= @id_materia", conexion);
                    comando.Parameters.Add("@id_materia", SqlDbType.Int);
                    comando.Parameters["@id_materia"].Value = id_materia_agregar;
                    SqlDataReader datos = comando.ExecuteReader();
                    if (datos.Read())
                    {
                        dgv_materia_producto.Rows.Add(datos["ID"].ToString(), datos["descrip"].ToString(), datos["Marca"].ToString(), datos["Costo"].ToString(), 1);
                    }

                    dgv_materia_prima.CurrentCell = null;

                    dgv_materia_prima.Rows[indice].Visible = false;

                    datos.Close();

                    conexion.Close();


                }
                else
                {
                    MessageBox.Show("Seleccione una fila.", "Atención");
                }
                rowselected_materia_prima = false;
                rowselected_materia_producto = false;
                dgv_materia_prima.ClearSelection();
                dgv_materia_producto.ClearSelection();
            }
            catch (AccessViolationException Exception)
            {
                Console.WriteLine(Exception.Message);
            }
            
        }

        //mueve una fila de la tabla de materias de productos a la tabla de materias primas
        private void b_quitar_Click(object sender, EventArgs e)
        {
            int id_materia_producto = 0;
            try
            {

                if (dgv_materia_producto.Rows.Count == 0)
                {
                    MessageBox.Show("No hay más filas", "Atención");
                    return;
                }

                if (rowselected_materia_producto == false)
                {
                    MessageBox.Show("Seleccione una fila.", "Atención");
                    return;
                }

                int indice = dgv_materia_producto.SelectedCells[0].RowIndex;
                DataGridViewRow fila_seleccionada = dgv_materia_producto.Rows[indice];
                id_materia_producto = Convert.ToInt32(fila_seleccionada.Cells["id_materia_producto"].Value);

                if (id_materia_producto != 0)
                {
                    foreach (DataGridViewRow fila in dgv_materia_prima.Rows)
                    {
                        if (Convert.ToInt32(fila.Cells["ID"].Value) == id_materia_producto)
                        {
                            fila.Visible = true;
                            dgv_materia_producto.Rows.RemoveAt(indice);
                            break;
                        }

                    }

                }
                else
                {
                    MessageBox.Show("Seleccione una fila.", "Atención");
                }
                rowselected_materia_prima = false;
                rowselected_materia_producto = false;
                dgv_materia_producto.ClearSelection();
                dgv_materia_prima.ClearSelection();
            }
            catch (AccessViolationException Exception)
            {
                Console.WriteLine(Exception.Message);
            }
        }

        private void b_agregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (validacion_copada1() == false)
                {
                    return;
                }
                conexion.Open();
                //Antes de agregar un producto se verifica que no haya 2 con el mismo nombre y misma categoria
                SqlCommand comando3 = new SqlCommand("SELECT * FROM Productos WHERE descripcion=@Descripcion and id_categoria=@Categoria and baja=0", conexion);
                comando3.Parameters.Add("@Descripcion", SqlDbType.VarChar);
                comando3.Parameters["@Descripcion"].Value = txt_descripcion.Text;
                comando3.Parameters.Add("@Categoria", SqlDbType.Int);
                comando3.Parameters["@Categoria"].Value = cb_categoria.SelectedValue;

                SqlDataReader datos3 = comando3.ExecuteReader();
                if (datos3.Read())
                {
                    MessageBox.Show("Este Producto ya existe.", "Atención");
                    datos3.Close();
                    conexion.Close();
                    return;
                }
                datos3.Close();
                //Si el nombre es diferente a todos los productos de la base de datos, se agrega
                if (clb_simple_compuesto.SelectedIndex == 0)
                {
                    // ingreso de un producto simple
                    SqlCommand comando4 = new SqlCommand("SELECT * FROM Materia_Prima WHERE descripcion=@Descripcion", conexion);
                    comando4.Parameters.Add("@Descripcion", SqlDbType.VarChar);
                    comando4.Parameters["@Descripcion"].Value = txt_descripcion.Text;
                    SqlDataReader datos4 = comando4.ExecuteReader();

                    if (datos4.Read())
                    {
                        //validacion de precio
                        double costo = Convert.ToDouble(datos4["costo"]);
                        if (Convert.ToDouble(txt_precio.Text) <= costo)
                        {
                            MessageBox.Show("Procure poner un precio mayor al costo de la materia prima.", "Atención");
                            datos4.Close();
                            conexion.Close();
                            return;
                        }
                        int id_materia = Convert.ToInt32(datos4["id_materia_prima"]);
                        datos4.Close();
                        string sql2 = "INSERT INTO Productos(descripcion, precio, id_categoria, compuesto, baja) VALUES (@Descripcion,@Precio,@Categoria,@Compuesto,0)";
                        SqlCommand comando5 = new SqlCommand(sql2, conexion);
                        comando5.Parameters.Add("@Descripcion", SqlDbType.VarChar);
                        comando5.Parameters["@Descripcion"].Value = txt_descripcion.Text;
                        comando5.Parameters.Add("@Precio", SqlDbType.Float);
                        comando5.Parameters["@Precio"].Value = txt_precio.Text;
                        comando5.Parameters.Add("@Categoria", SqlDbType.Int);
                        comando5.Parameters["@Categoria"].Value = cb_categoria.SelectedValue;
                        comando5.Parameters.Add("@Compuesto", SqlDbType.Bit);
                        comando5.Parameters["@Compuesto"].Value = 0;

                        comando5.ExecuteNonQuery();
                        

                        //ingreso las id de materia y producto en la tabla de union
                        SqlCommand comando6 = new SqlCommand("SELECT id_producto FROM Productos WHERE descripcion=@Descripcion and id_categoria=@Categoria", conexion);
                        comando6.Parameters.Add("@Descripcion", SqlDbType.VarChar);
                        comando6.Parameters["@Descripcion"].Value = txt_descripcion.Text;
                        comando6.Parameters.Add("@Categoria", SqlDbType.Int);
                        comando6.Parameters["@Categoria"].Value = cb_categoria.SelectedValue;
                        SqlDataReader datos6 = comando6.ExecuteReader();

                        if (datos6.Read())
                        {
                            int id_producto2= Convert.ToInt32(datos6["id_producto"]);
                            datos6.Close();
                            SqlCommand comando7 = new SqlCommand("INSERT INTO Productos_Materia_Prima(id_producto, id_materia_prima, cantidad) VALUES (@Id_Producto, @Id_Materia_Prima, 1)", conexion);
                            
                            comando7.Parameters.Add("@Id_Materia_Prima", SqlDbType.Int);
                            comando7.Parameters["@Id_Materia_Prima"].Value = id_materia;
                            comando7.Parameters.Add("@Id_Producto", SqlDbType.Int);
                            comando7.Parameters["@Id_Producto"].Value = id_producto2;

                            comando7.ExecuteNonQuery();
                            
                        }
                        datos6.Close();
                    }
                    else
                    {
                        MessageBox.Show("Antes de ingresar un producto simple verifique que exista una materia prima con su misma descripción", "Atención");
                        datos4.Close();
                        conexion.Close();
                        return;
                    }
                }
                else
                {
                    //ingreso de un producto compuesto
                    if  (dgv_materia_producto.RowCount<2)
                    {
                        MessageBox.Show("Un producto compuesto debe poseer al menos 2 materias primas", "Atención");
                        conexion.Close();
                        return;
                    }

                    if (revisar_columna_cantidad() == false)
                    {
                        conexion.Close();
                        return;
                    }

                    //validacion de precio
                    double costo = 0;
                    foreach (DataGridViewRow fila in dgv_materia_producto.Rows)
                    {
                        costo = costo + Convert.ToDouble(fila.Cells["costo_materia"].Value)* Convert.ToInt32(fila.Cells["cantidad_materia"].Value);

                    }
                    if (Convert.ToDouble(txt_precio.Text) <= costo)
                    {
                        MessageBox.Show("Procure poner un precio mayor al costo de las materias primas.", "Atención");
                        conexion.Close();
                        return;
                    }

                    string sql2 = "INSERT INTO Productos(descripcion, precio, id_categoria, compuesto, baja) VALUES (@Descripcion,@Precio,@Categoria,@Compuesto,0)";
                    SqlCommand comando10 = new SqlCommand(sql2, conexion);
                    comando10.Parameters.Add("@Descripcion", SqlDbType.VarChar);
                    comando10.Parameters["@Descripcion"].Value = txt_descripcion.Text;
                    comando10.Parameters.Add("@Precio", SqlDbType.Float);
                    comando10.Parameters["@Precio"].Value = txt_precio.Text;
                    comando10.Parameters.Add("@Categoria", SqlDbType.Int);
                    comando10.Parameters["@Categoria"].Value = cb_categoria.SelectedValue;
                    comando10.Parameters.Add("@Compuesto", SqlDbType.Bit);
                    comando10.Parameters["@Compuesto"].Value = 1;
                    comando10.ExecuteNonQuery();

                    //ingreso las id de materia y producto en la tabla de union
                    SqlCommand comando11 = new SqlCommand("SELECT id_producto FROM Productos WHERE descripcion=@Descripcion and id_categoria=@Categoria", conexion);
                    comando11.Parameters.Add("@Descripcion", SqlDbType.VarChar);
                    comando11.Parameters["@Descripcion"].Value = txt_descripcion.Text;
                    comando11.Parameters.Add("@Categoria", SqlDbType.Int);
                    comando11.Parameters["@Categoria"].Value = cb_categoria.SelectedValue;
                    SqlDataReader datos10 = comando11.ExecuteReader();

                    if (datos10.Read())
                    {
                        int id_producto2 = Convert.ToInt32(datos10["id_producto"]);
                        datos10.Close();
                        foreach (DataGridViewRow fila in dgv_materia_producto.Rows)
                        {
                            int id_materia2 = Convert.ToInt32(fila.Cells["id_materia_producto"].Value);
                            int cantidad = Convert.ToInt32(fila.Cells["cantidad_materia"].Value);

                            SqlCommand comando12 = new SqlCommand("INSERT INTO Productos_Materia_Prima(id_producto, id_materia_prima, cantidad) VALUES (@Id_Producto, @Id_Materia_Prima, @Cantidad)", conexion);

                            comando12.Parameters.Add("@Id_Materia_Prima", SqlDbType.Int);
                            comando12.Parameters["@Id_Materia_Prima"].Value = id_materia2;
                            comando12.Parameters.Add("@Id_Producto", SqlDbType.Int);
                            comando12.Parameters["@Id_Producto"].Value = id_producto2;
                            comando12.Parameters.Add("@Cantidad", SqlDbType.Int);
                            comando12.Parameters["@Cantidad"].Value = cantidad;
                            comando12.ExecuteNonQuery();

                        }


                    }
                    datos10.Close();
                }

                conexion.Close();
                cargarGridProductos();
                limpiarTexto();
                MessageBox.Show("Se ingresó el dato.", "Atención");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
        }

        private void b_modificar_Click(object sender, EventArgs e)
        {
            if (id_producto != 0)
            {

                try
                {
                    if (validacion_copada1() == false)
                    {
                        return;
                    }

                    conexion.Open();
                    //al modificar el producto se verifica que no exista ya
                    SqlCommand comando4 = new SqlCommand("SELECT * FROM Productos WHERE id_producto<>@ID and descripcion=@Descripcion and id_categoria=@Categoria and baja=0", conexion);
                    comando4.Parameters.Add("@ID", SqlDbType.Int);
                    comando4.Parameters["@ID"].Value = id_producto;
                    comando4.Parameters.Add("@Descripcion", SqlDbType.VarChar);
                    comando4.Parameters["@Descripcion"].Value = txt_descripcion.Text;
                    comando4.Parameters.Add("@Categoria", SqlDbType.Int);
                    comando4.Parameters["@Categoria"].Value = cb_categoria.SelectedValue;
                    SqlDataReader datos4 = comando4.ExecuteReader();
                    if (datos4.Read())
                    {
                        MessageBox.Show("Este Producto ya existe.", "Atención");
                        datos4.Close();
                        conexion.Close();
                        return;
                    }
                    datos4.Close();
                    //se verifica que de ser compuesto no debe poseer una sola materia prima
                    if (clb_simple_compuesto.SelectedIndex == 1)
                    {
                        if (dgv_materia_producto.RowCount < 2)
                        {
                            MessageBox.Show("Un producto compuesto debe poseer al menos 2 materias primas", "Atención");
                            conexion.Close();
                            return;
                        }
                    }

                    //busco el tipo de producto que estoy por modificar
                    SqlCommand comando5 = new SqlCommand("SELECT compuesto FROM Productos WHERE id_producto=@ID and descripcion=@Descripcion and id_categoria=@Categoria and baja=0", conexion);
                    comando5.Parameters.Add("@ID", SqlDbType.Int);
                    comando5.Parameters["@ID"].Value = id_producto;
                    comando5.Parameters.Add("@Descripcion", SqlDbType.VarChar);
                    comando5.Parameters["@Descripcion"].Value = txt_descripcion.Text;
                    comando5.Parameters.Add("@Categoria", SqlDbType.Int);
                    comando5.Parameters["@Categoria"].Value = cb_categoria.SelectedValue;
                    SqlDataReader datos5 = comando5.ExecuteReader();
                    int compuesto = 0;
                    if (datos5.Read())
                    {
                        compuesto = Convert.ToInt32(datos5["compuesto"]);
                    }

                    datos5.Close();
                    //si la descripcion y categoria estan bien, se modifica el producto


                    //si es simple se setea en 0
                    if (clb_simple_compuesto.SelectedIndex == 0)
                    {
                        SqlCommand comando3 = new SqlCommand("SELECT * FROM Materia_Prima WHERE descripcion=@Descripcion and baja=0", conexion);
                        comando3.Parameters.Add("@Descripcion", SqlDbType.VarChar);
                        comando3.Parameters["@Descripcion"].Value = txt_descripcion.Text;
                        SqlDataReader datos3 = comando3.ExecuteReader();
                        if (!datos3.Read())
                        {
                            MessageBox.Show("No existe la materia prima con esa descripción", "Atención");
                            datos3.Close();
                            conexion.Close();
                            return;
                        }
                        datos3.Close();

                        SqlCommand comando8 = new SqlCommand("SELECT * FROM Materia_Prima WHERE descripcion=@Descripcion and baja=0", conexion);
                        comando8.Parameters.Add("@Descripcion", SqlDbType.VarChar);
                        comando8.Parameters["@Descripcion"].Value = txt_descripcion.Text;
                        SqlDataReader datos8 = comando8.ExecuteReader();

                        //validacion de precio
                        double costo = 0;
                        if (datos8.Read())
                        {
                            costo = Convert.ToDouble(datos8["costo"]);
                        }    

                        if (Convert.ToDouble(txt_precio.Text) <= costo)
                        {
                            MessageBox.Show("Procure poner un precio mayor al costo de la materia prima.", "Atención");
                            datos8.Close();
                            conexion.Close();
                            return;
                        }
                        datos8.Close();

                        if (compuesto == 0)
                        {
                            SqlCommand comando2 = new SqlCommand("SELECT id_materia_prima FROM Materia_Prima WHERE descripcion=@Descripcion and baja=0", conexion);

                            comando2.Parameters.Add("@Descripcion", SqlDbType.VarChar);
                            comando2.Parameters["@Descripcion"].Value = txt_descripcion.Text;
                            SqlDataReader datos2 = comando2.ExecuteReader();
                            if (datos2.Read())
                            {
                                int id_materia_prima = Convert.ToInt32(datos2["id_materia_prima"]);
                                datos2.Close();

                                string sql5 = "UPDATE Productos_Materia_Prima SET id_materia_prima=@Id_materia WHERE id_producto=@ID ";
                                SqlCommand comando6 = new SqlCommand(sql5, conexion);
                                comando6.Parameters.Add("@ID", SqlDbType.Int);
                                comando6.Parameters["@ID"].Value = id_producto;
                                comando6.Parameters.Add("@Id_materia", SqlDbType.Int);
                                comando6.Parameters["@Id_materia"].Value = id_materia_prima;

                                comando6.ExecuteNonQuery();
                            }
                            datos2.Close();
                        }
                        else
                        {
                            //borro todas las uniones de ese producto
                            SqlCommand comando2 = new SqlCommand("DELETE FROM Productos_Materia_Prima WHERE id_producto=@Id_producto", conexion);
                            comando2.Parameters.Add("@Id_producto", SqlDbType.Int);
                            comando2.Parameters["@Id_producto"].Value = id_producto;
                            comando2.ExecuteNonQuery();

                            SqlCommand comando7 = new SqlCommand("SELECT * FROM Materia_Prima WHERE descripcion=@Descripcion", conexion);
                            comando7.Parameters.Add("@Descripcion", SqlDbType.VarChar);
                            comando7.Parameters["@Descripcion"].Value = txt_descripcion.Text;
                            SqlDataReader datos7 = comando7.ExecuteReader();
                            if (datos7.Read())
                            {
                                int id_materia = Convert.ToInt32(datos7["id_materia_prima"]);
                                datos7.Close();
                                SqlCommand comando9 = new SqlCommand("INSERT INTO Productos_Materia_Prima(id_producto, id_materia_prima, cantidad) VALUES (@Id_Producto, @Id_Materia_Prima, 1)", conexion);
                                comando9.Parameters.Add("@Id_Materia_Prima", SqlDbType.Int);
                                comando9.Parameters["@Id_Materia_Prima"].Value = id_materia;
                                comando9.Parameters.Add("@Id_Producto", SqlDbType.Int);
                                comando9.Parameters["@Id_Producto"].Value = id_producto;
                                comando9.ExecuteNonQuery();
                                
                            }
                            datos7.Close();                            

                        }
                        string sql = "UPDATE Productos SET descripcion=@Descripcion, precio=@Precio, id_categoria=@Categoria, compuesto=@Compuesto WHERE id_producto=@ID";
                        SqlCommand comando = new SqlCommand(sql, conexion);
                        comando.Parameters.Add("@ID", SqlDbType.Int);
                        comando.Parameters["@ID"].Value = id_producto;
                        comando.Parameters.Add("@Descripcion", SqlDbType.VarChar);
                        comando.Parameters["@Descripcion"].Value = txt_descripcion.Text;
                        comando.Parameters.Add("@Precio", SqlDbType.Float);
                        comando.Parameters["@Precio"].Value = txt_precio.Text;
                        comando.Parameters.Add("@Categoria", SqlDbType.Int);
                        comando.Parameters["@Categoria"].Value = cb_categoria.SelectedValue;
                        comando.Parameters.Add("@Compuesto", SqlDbType.Bit);
                        comando.Parameters["@Compuesto"].Value = 0;
                        comando.ExecuteNonQuery();
                    }
                    //productos compuestos
                    else
                    {
                        if (revisar_columna_cantidad() == false)
                        {
                            conexion.Close();
                            return;
                        }
                        //validacion de precio
                        double costo2 = 0;
                        foreach (DataGridViewRow fila in dgv_materia_producto.Rows)
                        {
                            costo2 = costo2 + Convert.ToDouble(fila.Cells["costo_materia"].Value) * Convert.ToInt32(fila.Cells["cantidad_materia"].Value);

                        }
                        if (Convert.ToDouble(txt_precio.Text) <= costo2)
                        {
                            MessageBox.Show("Procure poner un precio mayor al costo de las materias primas.", "Atención");
                            conexion.Close();
                            return;
                        }

                        //borro todas las uniones de ese producto
                        SqlCommand comando2 = new SqlCommand("DELETE FROM Productos_Materia_Prima WHERE id_producto=@Id_producto", conexion);
                        comando2.Parameters.Add("@Id_producto", SqlDbType.Int);
                        comando2.Parameters["@Id_producto"].Value = id_producto;
                        comando2.ExecuteNonQuery();
                        //agrego las nuevas uniones, o las mismas en caso de no haber modificacion
                        foreach (DataGridViewRow fila in dgv_materia_producto.Rows)
                        {
                            int id_materia = Convert.ToInt32(fila.Cells["id_materia_producto"].Value);
                            int cantidad = Convert.ToInt32(fila.Cells["cantidad_materia"].Value);

                            SqlCommand comando12 = new SqlCommand("INSERT INTO Productos_Materia_Prima(id_producto, id_materia_prima, cantidad) VALUES (@Id_Producto, @Id_Materia_Prima, @Cantidad)", conexion);

                            comando12.Parameters.Add("@Id_Materia_Prima", SqlDbType.Int);
                            comando12.Parameters["@Id_Materia_Prima"].Value = id_materia;
                            comando12.Parameters.Add("@Id_Producto", SqlDbType.Int);
                            comando12.Parameters["@Id_Producto"].Value = id_producto;
                            comando12.Parameters.Add("@Cantidad", SqlDbType.Int);
                            comando12.Parameters["@Cantidad"].Value = cantidad;
                            comando12.ExecuteNonQuery();

                        }
                        string sql = "UPDATE Productos SET descripcion=@Descripcion, precio=@Precio, id_categoria=@Categoria, compuesto=@Compuesto WHERE id_producto=@ID";
                        SqlCommand comando = new SqlCommand(sql, conexion);
                        comando.Parameters.Add("@ID", SqlDbType.Int);
                        comando.Parameters["@ID"].Value = id_producto;
                        comando.Parameters.Add("@Descripcion", SqlDbType.VarChar);
                        comando.Parameters["@Descripcion"].Value = txt_descripcion.Text;
                        comando.Parameters.Add("@Precio", SqlDbType.Float);
                        comando.Parameters["@Precio"].Value = txt_precio.Text;
                        comando.Parameters.Add("@Categoria", SqlDbType.Int);
                        comando.Parameters["@Categoria"].Value = cb_categoria.SelectedValue;
                        comando.Parameters.Add("@Compuesto", SqlDbType.Bit);
                        comando.Parameters["@Compuesto"].Value = 1;
                        comando.ExecuteNonQuery();

                    }         
                    conexion.Close();
                    cargarGridProductos();
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

        //espacios primer pestaña
        private int contador_descripcion = 0;
        private void txt_descripcion_KeyDown(object sender, KeyEventArgs e)
        {
            contador_descripcion = no_mas_espacios(e, contador_descripcion);
            if (contador_descripcion > 1)
            {
                e.SuppressKeyPress = true;
            }
        }

        private int contador_precio = 0;
        private void txt_precio_KeyDown(object sender, KeyEventArgs e)
        {
            contador_precio = no_mas_espacios(e, contador_precio);
            if (contador_precio > 1)
            {
                e.SuppressKeyPress = true;
            }
        }

        private void txt_precio_KeyPress(object sender, KeyPressEventArgs e)
        {
            no_comas_al_principio(sender, e);
            char nom = e.KeyChar;
            if (!(Char.IsDigit(nom)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != ','))
            {
                e.Handled = true;
            }

            if (e.KeyChar == ',' && (sender as TextBox).Text.IndexOf(',') > -1)
            {
                e.Handled = true;
            }
        }

        private void txt_descripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            no_espacios_al_principio(sender, e);
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

                if (cb_marca.SelectedIndex == -1)
                {
                    error += "No existen marcas. ";
                }

            }

            Regex re = new Regex("^([0-9]{1,2})?,?([0-9]{3})?,?([0-9]{3})?([0-9]{2})?[$]?$");
            if (!re.IsMatch(txt_costo.Text))
            {
                error += "Ingrese un costo valido";
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
                foreach (DataGridViewColumn column in dgv_materias.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
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

        //eliminar materia prima
        private void b_eliminar2_Click(object sender, EventArgs e)
        {
            if (id_materia_prima != 0)
            {
                //Se pregunta si de verdad quiere eliminar a una materia prima.
                if (MessageBox.Show("¿Está seguro?", "Eliminar", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        conexion.Open();
                        //Antes de eliminar verifica que no se esté usando la materia prima para evitar que un producto quede con una materia prima eliminada
                        SqlCommand comando4 = new SqlCommand("SELECT Productos_Materia_Prima.id_producto AS idprod FROM Productos_Materia_Prima JOIN Productos ON Productos_Materia_Prima.id_producto=Productos.id_producto where Productos_Materia_Prima.id_materia_prima=@ID and Productos.baja=0", conexion);
                        comando4.Parameters.Add("@ID", SqlDbType.Int);
                        comando4.Parameters["@ID"].Value = id_materia_prima;
                        SqlDataReader datos4 = comando4.ExecuteReader();
                        if (datos4.Read())
                        {
                            MessageBox.Show("No se puede eliminar una materia prima en uso.", "Atención");
                            datos4.Close();
                            conexion.Close();
                            return;
                        }
                        datos4.Close();

                        //las materias primas eliminadas siguen estando en la tabla de la base de datos, pero no se muestran como activos
                        string sql = "UPDATE Materia_Prima SET baja=1 WHERE id_materia_prima=@ID";
                        SqlCommand comando = new SqlCommand(sql, conexion);
                        comando.Parameters.Add("@ID", SqlDbType.Int);
                        comando.Parameters["@ID"].Value = id_materia_prima;
                        comando.ExecuteNonQuery();

                        conexion.Close();
                        cargarGridMateriasPrimas();

                        if (clb_simple_compuesto.SelectedIndex == 1)
                        {
                            cargarGridMaterias();
                            foreach (DataGridViewRow fila in dgv_materia_producto.Rows)
                            {
                                int id_materia_producto = Convert.ToInt32(fila.Cells["id_materia_producto"].Value);
                                foreach (DataGridViewRow fila2 in dgv_materia_prima.Rows)
                                {
                                    if (Convert.ToInt32(fila2.Cells["ID"].Value) == id_materia_producto)
                                    {
                                        dgv_materia_prima.CurrentCell = null;
                                        fila2.Visible = false;
                                        break;
                                    }
                                }
                            }
                        }

                        foreach (DataGridViewRow fila in dgv_materia_producto.Rows)
                        {
                            if (Convert.ToInt32(fila.Cells["id_materia_producto"].Value) == id_materia_prima)
                            {
                                dgv_materia_producto.Rows.RemoveAt(fila.Index);
                            }
                        }

                        limpiarTexto2();
                        MessageBox.Show("Se eliminó la materia prima.", "Atención");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
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
                SqlCommand comando3 = new SqlCommand("SELECT * FROM Materia_Prima WHERE descripcion=@Descripcion and baja=0", conexion);
                comando3.Parameters.Add("@Descripcion", SqlDbType.VarChar);
                comando3.Parameters["@Descripcion"].Value = txt_descripcion2.Text;
                SqlDataReader datos3 = comando3.ExecuteReader();
                if (datos3.Read())
                {
                    MessageBox.Show("Ya existe una Materia Prima con la misma Descripción", "Atención");
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

                if (clb_simple_compuesto.SelectedIndex == 1)
                {
                    cargarGridMaterias();
                    foreach (DataGridViewRow fila in dgv_materia_producto.Rows)
                    {
                        int id_materia_producto = Convert.ToInt32(fila.Cells["id_materia_producto"].Value);
                        foreach (DataGridViewRow fila2 in dgv_materia_prima.Rows)
                        {
                            if (Convert.ToInt32(fila2.Cells["ID"].Value) == id_materia_producto)
                            {
                                dgv_materia_prima.CurrentCell = null;
                                fila2.Visible = false;
                                break;
                            }

                        }
                    }
                    
                }
                cargarGridMateriasPrimas();
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
                    SqlCommand comando4 = new SqlCommand("SELECT * FROM Materia_Prima WHERE id_materia_prima<>@ID and descripcion=@Descripcion and baja=0", conexion);
                    comando4.Parameters.Add("@ID", SqlDbType.Int);
                    comando4.Parameters["@ID"].Value = id_materia_prima;
                    comando4.Parameters.Add("@Descripcion", SqlDbType.VarChar);
                    comando4.Parameters["@Descripcion"].Value = txt_descripcion2.Text;
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

                    if (clb_simple_compuesto.SelectedIndex == 1)
                    {
                        cargarGridMaterias();
                        foreach (DataGridViewRow fila in dgv_materia_producto.Rows)
                        {
                            int id_materia_producto = Convert.ToInt32(fila.Cells["id_materia_producto"].Value);
                            foreach (DataGridViewRow fila2 in dgv_materia_prima.Rows)
                            {
                                if (Convert.ToInt32(fila2.Cells["ID"].Value) == id_materia_producto)
                                {
                                    dgv_materia_prima.CurrentCell = null;
                                    fila2.Visible = false;
                                    break;
                                }
                            }
                        }
                    }

                    foreach (DataGridViewRow fila in dgv_materia_producto.Rows)
                    {
                        if (Convert.ToInt32(fila.Cells["id_materia_producto"].Value) == id_materia_prima)
                        {
                            fila.Cells["descripcion_materia"].Value = txt_descripcion2.Text;
                            fila.Cells["marca_materia"].Value = cb_marca.Text;
                            fila.Cells["costo_materia"].Value = txt_costo.Text;
                            break;
                        }

                    }

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
        private int contador_descripcion2 = 0;
        private void txt_descripcion2_KeyDown(object sender, KeyEventArgs e)
        {
            contador_descripcion2 = no_mas_espacios(e, contador_descripcion2);
            if (contador_descripcion2 > 1)
            {
                e.SuppressKeyPress = true;
            }
        }

        private int contador_costo = 0;
        private void txt_costo_KeyDown(object sender, KeyEventArgs e)
        {
            contador_costo = no_mas_espacios(e, contador_costo);
            if (contador_costo > 1)
            {
                e.SuppressKeyPress = true;
            }
        }

        private void txt_descripcion2_KeyPress(object sender, KeyPressEventArgs e)
        {
            no_espacios_al_principio(sender, e);
        }

        private void txt_costo_KeyPress(object sender, KeyPressEventArgs e)
        {
            no_comas_al_principio(sender, e);
            char nom = e.KeyChar;
            if (!(Char.IsDigit(nom)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != ','))
            {
                e.Handled = true;
            }

            if (e.KeyChar == ',' && (sender as TextBox).Text.IndexOf(',') > -1)
            {
                e.Handled = true;
            }
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
                foreach (DataGridViewColumn column in dgv_marca.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
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
                SqlCommand comando3 = new SqlCommand("SELECT * FROM Marca WHERE nombre_marca=@Marca and baja=0", conexion);
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
                    SqlCommand comando4 = new SqlCommand("SELECT * FROM Marca WHERE id_marca=@ID and baja=0", conexion);
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
                        conexion.Open();
                        //Antes de eliminar verifica que no se esté usando la marca para evitar que una materia prima quede con una marca eliminada
                        SqlCommand comando4 = new SqlCommand("SELECT * FROM Materia_Prima WHERE id_marca=@ID and baja=0", conexion);
                        comando4.Parameters.Add("@ID", SqlDbType.Int);
                        comando4.Parameters["@ID"].Value = id_marca;
                        SqlDataReader datos4 = comando4.ExecuteReader();
                        if (datos4.Read())
                        {
                            MessageBox.Show("No se puede eliminar una marca en uso.", "Atención");
                            datos4.Close();
                            conexion.Close();
                            return;
                        }
                        datos4.Close();
                        //las marcas eliminados siguen estando en la tabla de la base de datos, pero no se muestran como activos
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
                foreach (DataGridViewColumn column in dgv_categoria.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
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
                SqlCommand comando3 = new SqlCommand("SELECT * FROM Categoria WHERE nombre_categoria=@Categoria and baja=0", conexion);
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
                    SqlCommand comando4 = new SqlCommand("SELECT * FROM Categoria WHERE id_categoria=@ID and baja=0", conexion);
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
                        conexion.Open();
                        //Antes de eliminar verifica que no se esté usando la categoría para evitar que un producto quede con una categoria eliminada
                        SqlCommand comando4 = new SqlCommand("SELECT * FROM Productos WHERE id_categoria=@ID and baja=0", conexion);
                        comando4.Parameters.Add("@ID", SqlDbType.Int);
                        comando4.Parameters["@ID"].Value = id_categoria;
                        SqlDataReader datos4 = comando4.ExecuteReader();
                        if (datos4.Read())
                        {
                            MessageBox.Show("No se puede eliminar una categoría en uso.", "Atención");
                            datos4.Close();
                            conexion.Close();
                            return;
                        }
                        datos4.Close();

                        //las marcas eliminados siguen estando en la tabla de la base de datos, pero no se muestran como activos
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
        private int contador_marca = 0;
        private void txt_marca_KeyDown(object sender, KeyEventArgs e)
        {
            contador_marca = no_mas_espacios(e, contador_marca);
            if (contador_marca > 1)
            {
                e.SuppressKeyPress = true;
            }
        }

        private int contador_categoria = 0;
        private void txt_categoria_KeyDown(object sender, KeyEventArgs e)
        {
            contador_categoria = no_mas_espacios(e, contador_categoria);
            if (contador_categoria > 1)
            {
                e.SuppressKeyPress = true;
            }
        }

        private void txt_marca_KeyPress(object sender, KeyPressEventArgs e)
        {
            no_espacios_al_principio(sender, e);
        }

        private void txt_categoria_KeyPress(object sender, KeyPressEventArgs e)
        {
            no_espacios_al_principio(sender, e);
        }



        //tambien se crea un nuevo evento para que en la columna de cantidad se pongan solo numeros
        private void dgv_materia_producto_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgv_materia_producto.CurrentCell.ColumnIndex == 4)
            {
                e.Control.KeyPress -= new KeyPressEventHandler(columna3_cantidad_KeyPress);
                System.Windows.Forms.TextBox tb = e.Control as System.Windows.Forms.TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(columna3_cantidad_KeyPress);
                }
            }
        }

        private void columna3_cantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
            }
        }

        //se revisa que a la tabla no le falten ciertos datos
        private bool revisar_columna_cantidad()
        {
            bool dato = true;
            foreach (DataGridViewRow fila in dgv_materia_producto.Rows)
            {
                //no se permite que una celda de la columna cantidad sea 0 cuando se quiera ingresar un renglon, excepto si se quiere modificar/eliminar de un renglon existente
                if (fila.Cells["cantidad_materia"].Value != null && Convert.ToInt32(fila.Cells["cantidad_materia"].Value) == 0)
                {
                    dato = false;
                    MessageBox.Show("No se puede ingresar una cantidad de 0 a la materia prima utilizada", "Atención");
                }

            }
            return dato;
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
            dgv_materia_producto.Enabled = false;
            clb_simple_compuesto.SelectedIndex = 0;
            dgv_materia_prima.Enabled = false;
            dgv_materia_prima.DataSource = null;
            dgv_materia_producto.Rows.Clear();

            

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

        private void Productos_Load(object sender, EventArgs e)
        {
            clb_simple_compuesto.SetItemCheckState(0, CheckState.Checked);
        }

    }
}
