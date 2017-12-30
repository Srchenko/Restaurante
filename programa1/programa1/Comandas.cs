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
using Microsoft.Office.Interop.Excel;

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
        private void cargarListaMozos()
        {
            try
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand("SELECT id_mozo, CONCAT(nombre,' ',apellido) AS NombreCompleto FROM Mozos WHERE baja=0", conexion);
                System.Data.DataTable tabla_mozos = new System.Data.DataTable();
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
        private void cargarListaProductos()
        {
            for (int i = 1; i <= 15; i++)
            {
                dgv_comandas_detalle.Rows.Add();
            }
            try
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand("SELECT id_producto, descripcion FROM Productos WHERE baja=0", conexion);
                System.Data.DataTable tabla_productos = new System.Data.DataTable();
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
        double precio_total = 0;
        bool tabla_vacia=true;
        
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
            try
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand("SELECT id_comanda, id_mozo FROM Comandas_Cabecera WHERE numero_mesa=@n_mesa AND estado=0", conexion);
                comando.Parameters.Add("@n_mesa", SqlDbType.Int);
                comando.Parameters["@n_mesa"].Value = generar_valor;
                SqlDataReader datos = comando.ExecuteReader();
                if (datos.Read())
                {
                    id_comanda_general = Convert.ToInt32(datos["id_comanda"]);
                    lista_mozos.SelectedValue = datos["id_mozo"];
                    SqlCommand comando2 = new SqlCommand("SELECT id_renglon, id_producto, cantidad, subtotal FROM Comandas_Detalle WHERE id_comanda=@IDcomanda and baja=0", conexion);
                    comando2.Parameters.Add("@IDcomanda", SqlDbType.Int);
                    comando2.Parameters["@IDcomanda"].Value = id_comanda_general;
                    datos.Close();
                    SqlDataReader datos2 = comando2.ExecuteReader();
                    int fila = 0;
                    while(datos2.Read())
                    {
                        dgv_comandas_detalle.Rows[fila].Cells["Columna_Producto"].Value = datos2["id_producto"];
                        dgv_comandas_detalle.Rows[fila].Cells["Columna_Cantidad"].Value = datos2["cantidad"];
                        dgv_comandas_detalle.Rows[fila].Cells["Columna_Subtotal"].Value = datos2["subtotal"];
                        dgv_comandas_detalle.Rows[fila].Cells["ID_Renglon"].Value = datos2["id_renglon"];
                        fila = fila + 1;
                    }
                    datos2.Close();
                    conexion.Close();
                    calcular_subtotales();
                }
                datos.Close();
                conexion.Close();
            }
            catch (AccessViolationException Exception)
            {
                Console.WriteLine(Exception.Message);
            }
        }

        //al cerrar el formulario hijo, se hacen visibles los botones de la tabla del formulario padre
        private void Comandas_FormClosed(object sender, FormClosedEventArgs e)
        {
            Principal padre = this.MdiParent as Principal;
            padre.cambiar_color_boton();
            padre.tabla_visible_si();
            padre.menustrip_visible_si();
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
                    SqlCommand comando2 = new SqlCommand("INSERT INTO Comandas_Cabecera(id_mozo, fecha, hora, numero_mesa, estado, baja) VALUES (@IDmozo,@Fecha,@Hora,@NumeroMesa,0,0)", conexion);
                    comando2.Parameters.Add("@IDmozo", SqlDbType.Int);
                    comando2.Parameters["@IDmozo"].Value = Convert.ToInt32(lista_mozos.SelectedValue);
                    comando2.Parameters.Add("@Fecha", SqlDbType.Date);
                    comando2.Parameters["@Fecha"].Value = DateTime.Now;
                    comando2.Parameters.Add("@Hora", SqlDbType.Time);
                    comando2.Parameters["@Hora"].Value = DateTime.Now.TimeOfDay;
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
                    SqlCommand comando4 = new SqlCommand("UPDATE Comandas_Cabecera SET id_mozo=@idmozo, fecha=@Fecha, hora=@Hora WHERE id_comanda=@idcomanda", conexion);
                    comando4.Parameters.Add("@idmozo", SqlDbType.Int);
                    comando4.Parameters["@idmozo"].Value = Convert.ToInt32(lista_mozos.SelectedValue);
                    comando4.Parameters.Add("@Fecha", SqlDbType.Date);
                    comando4.Parameters["@Fecha"].Value = DateTime.Now;
                    comando4.Parameters.Add("@Hora", SqlDbType.Time);
                    comando4.Parameters["@Hora"].Value = DateTime.Now.TimeOfDay;
                    comando4.Parameters.Add("@idcomanda", SqlDbType.Int);
                    comando4.Parameters["@idcomanda"].Value = id_comanda_general;
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

                    if (fila.Cells["Columna_Producto"].Value != null && fila.Cells["Columna_Cantidad"].Value != null)
                    {
                        //si la columna id renglon esta vacia, significa que no existe en la base de datos, por lo tanto, se agrega
                        if (fila.Cells["ID_Renglon"].Value == null && Convert.ToInt32(fila.Cells["Columna_Cantidad"].Value) != 0)
                        {
                            comando = new SqlCommand("INSERT INTO Comandas_Detalle (id_comanda, id_producto, cantidad, subtotal, baja) VALUES (@IDcomanda,@IDproducto,@cantidad,@subtotal,0)", conexion);
                            comando.Parameters.Add("@IDcomanda", SqlDbType.Int);
                            comando.Parameters["@IDcomanda"].Value = id_comanda_general;
                            comando.Parameters.Add("@IDproducto", SqlDbType.Int);
                            comando.Parameters["@IDproducto"].Value = Convert.ToInt32(fila.Cells["Columna_Producto"].Value);
                            comando.Parameters.Add("@cantidad", SqlDbType.Int);
                            comando.Parameters["@cantidad"].Value = Convert.ToInt32(fila.Cells["Columna_Cantidad"].Value);
                            comando.Parameters.Add("@subtotal", SqlDbType.Float);
                            comando.Parameters["@subtotal"].Value = Convert.ToDouble(fila.Cells["Columna_Subtotal"].Value);
                            comando.ExecuteNonQuery();
                        }
                        //si la columna id renglon no esta vacia, significa que existe en la base de datos, por lo tanto se pueden modificar los datos si el usuario quiere
                        if(fila.Cells["ID_Renglon"].Value != null && Convert.ToInt32(fila.Cells["Columna_Cantidad"].Value) != 0)
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
                            comando2.Parameters.Add("@subtotal", SqlDbType.Float);
                            comando2.Parameters["@subtotal"].Value = Convert.ToDouble(fila.Cells["Columna_Subtotal"].Value);
                            comando2.ExecuteNonQuery();
                        }
                        // si la columna cantidad se modifica a 0, pero esa proviene de un renglon existente, entonces el renglon se elimina
                        if (fila.Cells["ID_Renglon"].Value != null && Convert.ToInt32(fila.Cells["Columna_Cantidad"].Value) == 0)
                        {
                            comando3 = new SqlCommand("UPDATE Comandas_Detalle SET baja=1, cantidad=0, subtotal=0 WHERE id_renglon=@IDrenglon", conexion);
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
                if ((fila.Cells["Columna_Producto"].Value ==null && fila.Cells["Columna_Cantidad"].Value != null) || (fila.Cells["Columna_Cantidad"].Value == null && fila.Cells["Columna_Producto"].Value != null))
                {
                        dato = false;
                        MessageBox.Show("Si usted completa la celda de Producto o de Cantidad, complete la que falta.", "Atención");
                }
                
            }
            return dato;
        }

        private bool revisar_columna_cantidad()
        {
            bool dato = true;
            foreach (DataGridViewRow fila in dgv_comandas_detalle.Rows)
            {
                //no se permite que una celda de la columna cantidad sea 0 cuando se quiera ingresar un renglon, excepto si se quiere modificar/eliminar de un renglon existente
                if (fila.Cells["Columna_Cantidad"].Value !=null && Convert.ToInt32(fila.Cells["Columna_Cantidad"].Value)==0 && fila.Cells["ID_Renglon"].Value==null)
                {
                    dato = false;
                    MessageBox.Show("No se puede ingresar datos nuevos a la comanda con productos con una cantidad igual a 0. Usted puede modificar un renglón existente poniéndole el valor 0.", "Atención");
                }

            }
            return dato;
        }

        //se calculan los subtotales en donde haya una columna producto con su respectiva columna cantidad

        private void calcular_subtotales()
        {
            try
            {
                conexion.Open();
                SqlCommand comando;
                SqlDataReader datos;
                double precio=0;
                double acumulador = -1;
                foreach (DataGridViewRow fila in dgv_comandas_detalle.Rows)
                {
                    if (fila.Cells["Columna_Producto"].Value != null && fila.Cells["Columna_Cantidad"].Value != null)
                    {
                        comando = new SqlCommand("SELECT precio FROM Productos WHERE id_producto=@IDproducto", conexion);
                        comando.Parameters.Add("@IDproducto", SqlDbType.Int);
                        comando.Parameters["@IDproducto"].Value = Convert.ToInt32(fila.Cells["Columna_Producto"].Value);
                        datos = comando.ExecuteReader();
                        if (datos.Read())
                        {
                            precio = Convert.ToDouble(datos["precio"]);
                            fila.Cells["Columna_Subtotal"].Value = Convert.ToInt32(fila.Cells["Columna_Cantidad"].Value) * precio;
                            acumulador = acumulador + (Convert.ToInt32(fila.Cells["Columna_Cantidad"].Value) * precio);
                        }
                        datos.Close();
                    }
                    else
                    {
                        fila.Cells["Columna_Subtotal"].Value = null;
                    }
                }
                if (acumulador == -1)
                {
                    valor_total_comanda.Text = "Total a pagar $ 0";
                    precio_total = acumulador;
                    tabla_vacia = true;
                }
                else
                {
                    acumulador = acumulador + 1;
                    valor_total_comanda.Text = "Total a pagar $ " + acumulador;
                    precio_total = acumulador;
                    tabla_vacia = false;
                }

                conexion.Close();
            }
            catch (AccessViolationException Exception)
            {
                Console.WriteLine(Exception.Message);
            }
        }

        private void bt_modificar_salir_Click(object sender, EventArgs e)
        {
            dgv_comandas_detalle.ClearSelection();

            if (revisar_tabla() == false)
            {
                return;
            }

            if (revisar_columna_cantidad() == false)
            {
                return;
            }

            calcular_subtotales();

            if (tabla_vacia == true)
            {
                MessageBox.Show("Por lo menos debe existir una fila con el Producto y su Cantidad completos.", "Atención");
                return;
            }

            comanda_general();
            renglones_comanda();
            try
            {
                conexion.Open();
                // en el caso de que se modifiquen los datos de una comanda existente en la cual todos sus productos tienen una cantidad igual a 0, entonces esa comanda no existira mas
                SqlCommand comando2 = new SqlCommand("SELECT Comandas_Detalle.baja FROM Comandas_Detalle JOIN Comandas_Cabecera ON Comandas_Detalle.id_comanda = Comandas_Cabecera.id_comanda WHERE Comandas_Detalle.baja=0 AND Comandas_Cabecera.id_comanda=@idcomanda", conexion);
                comando2.Parameters.Add("@idcomanda", SqlDbType.Int);
                comando2.Parameters["@idcomanda"].Value = id_comanda_general;
                SqlDataReader datos = comando2.ExecuteReader();
                if (!datos.Read())
                {
                    datos.Close();
                    SqlCommand comando3 = new SqlCommand("UPDATE Comandas_Cabecera SET baja=1, estado=1 WHERE id_comanda=@idcomanda", conexion);
                    comando3.Parameters.Add("@idcomanda", SqlDbType.Int);
                    comando3.Parameters["@idcomanda"].Value = id_comanda_general;
                    comando3.ExecuteNonQuery();
                }
                datos.Close();

                conexion.Close();
            }
            catch (AccessViolationException Exception)
            {
                Console.WriteLine(Exception.Message);
            }

            Principal padre = this.MdiParent as Principal;
            padre.cambiar_color_boton();
            padre.tabla_visible_si();
            padre.menustrip_visible_si();
            this.Close();
        }

        private void bt_finalizar_comanda_Click(object sender, EventArgs e)
        {
            dgv_comandas_detalle.ClearSelection();

            if (revisar_tabla() == false)
            {
                return;
            }

            if (revisar_columna_cantidad() == false)
            {
                return;
            }

            calcular_subtotales();

            if (tabla_vacia == true)
            {
                MessageBox.Show("Por lo menos debe existir una fila con el Producto y su Cantidad completos.", "Atención");
                return;
            }

            comanda_general();
            renglones_comanda();
            try
            {
                conexion.Open();
                // al finalizar la comanda, se pone el estado en 1, para que la mesa se quede libre para otras comandas posteriores
                SqlCommand comando = new SqlCommand("UPDATE Comandas_Cabecera SET estado=1 WHERE id_comanda=@idcomanda", conexion);
                comando.Parameters.Add("@idcomanda", SqlDbType.Int);
                comando.Parameters["@idcomanda"].Value = id_comanda_general;
                comando.ExecuteNonQuery();

                SqlCommand comando2 = new SqlCommand("SELECT Comandas_Detalle.baja FROM Comandas_Detalle JOIN Comandas_Cabecera ON Comandas_Detalle.id_comanda = Comandas_Cabecera.id_comanda WHERE Comandas_Detalle.baja=0 AND Comandas_Cabecera.id_comanda=@idcomanda", conexion);
                comando2.Parameters.Add("@idcomanda", SqlDbType.Int);
                comando2.Parameters["@idcomanda"].Value = id_comanda_general;
                SqlDataReader datos = comando2.ExecuteReader();
                if (!datos.Read())
                {
                    datos.Close();
                    SqlCommand comando3 = new SqlCommand("UPDATE Comandas_Cabecera SET baja=1 WHERE id_comanda=@idcomanda", conexion);
                    comando3.Parameters.Add("@idcomanda", SqlDbType.Int);
                    comando3.Parameters["@idcomanda"].Value = id_comanda_general;
                    comando3.ExecuteNonQuery();
                    tabla_vacia = true;
                }
                datos.Close();

                conexion.Close();
            }
            catch (AccessViolationException Exception)
            {
                Console.WriteLine(Exception.Message);
            }
            if (tabla_vacia == false)
            {
                dgv_archivo_excel.DataSource = Crear_Tabla_Excel();
                Exportar_Excel();
                MessageBox.Show("Comanda finalizada. Se creará un archivo de Excel en el escritorio para que usted pueda verla completa.", "Atención");
            }

            Principal padre = this.MdiParent as Principal;
            padre.cambiar_color_boton();
            padre.tabla_visible_si();
            padre.menustrip_visible_si();
            this.Close();
        }

        private void bt_calcular_subtotal_productos_Click(object sender, EventArgs e)
        {
            dgv_comandas_detalle.ClearSelection();

            if (revisar_tabla() == false)
            {
                return;
            }

            calcular_subtotales();

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
                System.Windows.Forms.TextBox tb = e.Control as System.Windows.Forms.TextBox;
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

        private System.Data.DataTable Crear_Tabla_Excel()
        {
            System.Data.DataTable tabla = new System.Data.DataTable();
            int fila = 0;
            String[] linea;
            String cadena;
            TimeSpan tiempo;
            try
            {
                //primero se hace la parte del encabezado
                tabla.Columns.Add("Columna_1", typeof(string));
                tabla.Columns.Add("Columna_2", typeof(string));
                tabla.Columns.Add("Columna_3", typeof(string));
                tabla.Rows.Add("Mozo", "", "Mesa");
                conexion.Open();

                SqlCommand comando = new SqlCommand("SELECT Comandas_Cabecera.id_comanda, CONCAT(Mozos.nombre,' ',Mozos.apellido) AS NombreCompleto, Comandas_Cabecera.fecha AS cc_fecha, Comandas_Cabecera.hora AS cc_hora, Comandas_Cabecera.numero_mesa AS cc_mesa FROM Comandas_Cabecera JOIN Mozos ON Comandas_Cabecera.id_mozo = Mozos.id_mozo WHERE Comandas_Cabecera.id_comanda=@idcomanda", conexion);
                comando.Parameters.Add("@idcomanda", SqlDbType.Int);
                comando.Parameters["@idcomanda"].Value = id_comanda_general;
                SqlDataReader datos = comando.ExecuteReader();
                if (datos.Read())
                {
                    tabla.Rows.Add(datos["NombreCompleto"].ToString(), "", datos["cc_mesa"].ToString());
                    tabla.Rows.Add();
                    tabla.Rows.Add("Fecha", "", "Hora");
                    cadena = datos["cc_fecha"].ToString();
                    linea = cadena.Split(' ');
                    tiempo  = (TimeSpan)datos["cc_hora"];
                    tabla.Rows.Add(linea[0], "", tiempo.ToString(@"hh\:mm"));
                    tabla.Rows.Add();
                    tabla.Rows.Add();
                    tabla.Rows.Add("Producto", "Cantidad", "Subtotal");
                }
                datos.Close();
                //luego los productos
                SqlCommand comando2 = new SqlCommand("SELECT Comandas_Detalle.id_comanda, Productos.descripcion AS p_descripcion, Comandas_Detalle.cantidad AS cd_cantidad, Comandas_Detalle.subtotal AS cd_subtotal FROM Comandas_Detalle JOIN Productos ON Comandas_Detalle.id_producto = Productos.id_producto WHERE Comandas_Detalle.id_comanda=@idcomanda2", conexion);
                comando2.Parameters.Add("@idcomanda2", SqlDbType.Int);
                comando2.Parameters["@idcomanda2"].Value = id_comanda_general;
                SqlDataReader datos2 = comando2.ExecuteReader();
                while (datos2.Read())
                {
                    tabla.Rows.Add(datos2["p_descripcion"].ToString(), datos2["cd_cantidad"].ToString(), datos2["cd_subtotal"].ToString());
                    fila = fila + 1;
                }
                datos2.Close();
                for (int i = fila; i <= 15; i++)
                {
                    tabla.Rows.Add();
                }
                //luego el total
                tabla.Rows.Add("Total", "", precio_total.ToString());
                conexion.Close();
            }
            catch (AccessViolationException Exception)
            {
                Console.WriteLine(Exception.Message);
            }
            return tabla;
        }

        private void Exportar_Excel()
        {
            Microsoft.Office.Interop.Excel.Application excel;
            Workbook workbook;
            Worksheet worksheet;
            Range cell_range;

            try
            {
                excel = new Microsoft.Office.Interop.Excel.Application();
                excel.Visible = false;
                excel.DisplayAlerts = false;

                workbook = excel.Workbooks.Add(Type.Missing);

                worksheet = (Worksheet)workbook.ActiveSheet;
                worksheet.Name = "Comanda";

                int fila_excel = 0;
                foreach (DataRow fila_tabla in Crear_Tabla_Excel().Rows)
                {
                    fila_excel = fila_excel + 1;
                    for (int i = 1; i <= Crear_Tabla_Excel().Columns.Count; i++)
                    {
                        worksheet.Cells[fila_excel, i] = fila_tabla[i - 1].ToString();
                    }
                }
                
                worksheet.Range[worksheet.Cells[3, 1], worksheet.Cells[3, 3]].Merge();
                worksheet.Range[worksheet.Cells[6, 1], worksheet.Cells[7, 3]].Merge();
                worksheet.Range[worksheet.Cells[1, 2], worksheet.Cells[2, 2]].Merge();
                worksheet.Range[worksheet.Cells[4, 2], worksheet.Cells[5, 2]].Merge();
                worksheet.Range[worksheet.Cells[24, 1], worksheet.Cells[24, 3]].Merge();

                worksheet.Cells[1, 1].Font.Bold = true;
                worksheet.Cells[1, 3].Font.Bold = true;
                worksheet.Cells[4, 1].Font.Bold = true;
                worksheet.Cells[4, 3].Font.Bold = true;
                worksheet.Cells[8, 1].Font.Bold = true;
                worksheet.Cells[8, 2].Font.Bold = true;
                worksheet.Cells[8, 3].Font.Bold = true;
                worksheet.Cells[25, 1].Font.Bold = true;

                cell_range = worksheet.Range[worksheet.Cells[1, 1], worksheet.Cells[fila_excel, Crear_Tabla_Excel().Columns.Count]];
                cell_range.EntireColumn.AutoFit();
                Borders border = cell_range.Borders;
                border.LineStyle = XlLineStyle.xlContinuous;
                border.Weight = 2d;

                worksheet.Cells[1, 1].Borders.Weight = 3d;
                worksheet.Cells[1, 3].Borders.Weight = 3d;
                worksheet.Cells[4, 1].Borders.Weight = 3d;
                worksheet.Cells[4, 3].Borders.Weight = 3d;
                worksheet.Cells[8, 1].Borders.Weight = 3d;
                worksheet.Cells[8, 2].Borders.Weight = 3d;
                worksheet.Cells[8, 3].Borders.Weight = 3d;
                worksheet.Cells[25, 1].Borders.Weight = 3d;
                worksheet.Cells[25, 2].Borders.Weight = 3d;
                worksheet.Cells[25, 3].Borders.Weight = 3d;

                cell_range = worksheet.Range[worksheet.Cells[1, 1], worksheet.Cells[2, Crear_Tabla_Excel().Columns.Count]];

                DateTime ahora = DateTime.Now;
                int horas = 0, minutos = 0, segundos = 0, total = 0;
                horas = (24 - ahora.Hour) - 1;
                minutos = (60 - ahora.Minute) - 1;
                segundos = (60 - ahora.Second - 1);
                total = segundos + (minutos * 60) + (horas * 3600);

                workbook.SaveAs("C:\\Users\\Srchenko\\Desktop\\Comanda" + DateTime.Now.ToString("ddMMyyyy") + total.ToString() + ".xlsx");
                workbook.Close();
                excel.Quit();
            }
            catch (AccessViolationException Exception)
            {
                Console.WriteLine(Exception.Message);
            }
            finally
            {
                worksheet = null;
                cell_range = null;
                workbook = null;
            }
        }
    }
}
