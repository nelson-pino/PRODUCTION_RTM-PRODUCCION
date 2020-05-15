using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RitramaAPP.Clases
{
    public class DevolucionManager
    {
        readonly Conexion micomm;
        public DataSet ds;
        private readonly SqlDataAdapter dadevolucion;
        private readonly SqlDataAdapter daitemrows;
        private readonly SqlDataAdapter daproduct;
        private readonly SqlDataAdapter dacustomer;
        private readonly DataTable dtdevolucion;
        private readonly DataTable dtitemsrows;
        private readonly DataTable dtproduct;
        private readonly DataTable dtcustomer;

        public DevolucionManager()
        { 
            micomm = new Conexion();
            ds = new DataSet();
            dadevolucion = new SqlDataAdapter();
            daitemrows = new SqlDataAdapter();
            daproduct = new SqlDataAdapter();
            dacustomer = new SqlDataAdapter();
            dtdevolucion = new DataTable();
            dtitemsrows = new DataTable();
            dtproduct = new DataTable();
            dtcustomer = new DataTable();
            LoadDevoluciones();
            LoadProducts();
            LoadCustomers();
            RelacionesDS();
        }
        public void Add(ClassDevolucion documento, Boolean ismessage) 
        {
            //ADD HEADER TABLE DEVOLUCION.
            CommandSqlGeneric(R.SQL.DATABASE.NAME,
            R.SQL.QUERY_SQL.DEVOLUCION.SQL_INSERT_HEADER, SetParametersAddHeaderDevolucion(documento),
            ismessage, R.ERROR_MESSAGES.DEVOLUCIONES.MESSAGE_ERROR_INSERT_HEADER);

            //ADD ITEMROWS TABLE.
            foreach (Item_Devol item in documento.items)
            {
                CommandSqlGeneric(R.SQL.DATABASE.NAME, R.SQL.QUERY_SQL.DEVOLUCION.SQL_INSERT_ITEMROWS,
                SetParametersItemRowsDevolucion(item, documento.Numero), ismessage,
                R.ERROR_MESSAGES.DEVOLUCIONES.MESSAGE_ERROR_INSERT_ITEMROWS);
            }
        }
        public List<SqlParameter> SetParametersItemRowsDevolucion(Item_Devol items,string numero) 
        {
            List<SqlParameter> sp = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName = "@p1", SqlDbType = SqlDbType.NVarChar, Value = numero},
                new SqlParameter() {ParameterName = "@p2", SqlDbType = SqlDbType.NVarChar, Value = items.Product_id},
                new SqlParameter() {ParameterName = "@p3", SqlDbType = SqlDbType.Decimal, Value = items.Cantidad},
                new SqlParameter() {ParameterName = "@p4", SqlDbType = SqlDbType.NVarChar, Value = items.NumeroID},
                new SqlParameter() {ParameterName = "@p5", SqlDbType = SqlDbType.NVarChar, Value = items.Tipo},
                new SqlParameter() {ParameterName = "@p6", SqlDbType = SqlDbType.Decimal, Value = items.Width},
                new SqlParameter() {ParameterName = "@p7", SqlDbType = SqlDbType.Decimal, Value = items.Lenght},
                new SqlParameter() {ParameterName = "@p8", SqlDbType = SqlDbType.Decimal, Value = items.Msi},
                new SqlParameter() {ParameterName = "@p9", SqlDbType = SqlDbType.Int, Value = items.Sw_estado},
            };
            return sp;
        }
        public List<SqlParameter> SetParametersAddHeaderDevolucion(ClassDevolucion documento)
        {
            List<SqlParameter> sp = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName = "@p1", SqlDbType = SqlDbType.NVarChar, Value = documento.Numero},
                new SqlParameter() {ParameterName = "@p2", SqlDbType = SqlDbType.DateTime, Value = documento.Fecha},
                new SqlParameter() {ParameterName = "@p3", SqlDbType = SqlDbType.NVarChar, Value = documento.Id_Cust},
                new SqlParameter() {ParameterName = "@p4", SqlDbType = SqlDbType.NVarChar, Value = documento.Razon},
                new SqlParameter() {ParameterName = "@p5", SqlDbType = SqlDbType.NVarChar, Value = documento.DocAnulado}
            };
            return sp;
        }
        public Boolean CommandSqlGenericUpdateDs(string db, string query, SqlDataAdapter da, string dt, string messagefail)
        {
            try
            {
                micomm.Conectar(db);
                SqlCommand comando = new SqlCommand
                {
                    Connection = micomm.cnn,
                    CommandType = CommandType.Text,
                    CommandText = query
                };
                comando.ExecuteNonQuery();
                da.SelectCommand = comando;
                da.Fill(ds, dt);
                comando.Dispose();
                micomm.Desconectar();
                return true;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(messagefail + ex);
                return false;
            }
        }
        public Boolean CommandSqlGeneric(string db, string query, List<SqlParameter> spc, Boolean msg, string messagerror)
        {
            // Ejecuta comando sql query y no devuleve ni valor ni datos.
            try
            {
                micomm.Conectar(db);
                SqlCommand comando = new SqlCommand
                {
                    Connection = micomm.cnn,
                    CommandType = CommandType.Text,
                    CommandText = query
                };
                if (spc.Count > 0)
                {
                    foreach (SqlParameter item in spc)
                    {
                        comando.Parameters.Add(item);
                    }
                }
                comando.ExecuteNonQuery();
                comando.Dispose();
                micomm.Desconectar();
                if (msg)
                {
                    MessageBox.Show("proceso realizado con exito...");
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(messagerror + ex);
                return false;
            }
        }
        public Boolean CommandSqlGenericTwoParameter(string db, string query, string id, string product_id, Boolean msg, string messagerror)
        {
            // Ejecuta comando sql query y no devuleve ni valor ni datos.
            try
            {
                SqlDataAdapter da = new SqlDataAdapter();
                DataTable dt = new DataTable();
                micomm.Conectar(db);
                SqlCommand comando = new SqlCommand
                {
                    Connection = micomm.cnn,
                    CommandType = CommandType.Text,
                    CommandText = query
                };
                SqlParameter p1 = new SqlParameter("@p1", id);
                SqlParameter p2 = new SqlParameter("@p2", product_id);
                comando.Parameters.Add(@p1);
                comando.Parameters.Add(@p2);
                da.SelectCommand = comando;
                comando.ExecuteNonQuery();
                da.Fill(dt);

                comando.Dispose();
                micomm.Desconectar();
                if (msg)
                {
                    MessageBox.Show("proceso realizado con exito...");
                }
                if (dt.Rows.Count == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(messagerror + ex);
                return false;
            }
        }
        public Boolean SqlGenericTwoParamOnlyUpdate(string db, string query, string id, bool status, Boolean msg, string messagerror)
        {
            // Ejecuta comando sql query y no devuleve ni valor ni datos.
            try
            {
                micomm.Conectar(db);
                SqlCommand comando = new SqlCommand
                {
                    Connection = micomm.cnn,
                    CommandType = CommandType.Text,
                    CommandText = query
                };
                SqlParameter p1 = new SqlParameter("@p1", id);
                SqlParameter p2 = new SqlParameter("@p2", status);
                comando.Parameters.Add(@p1);
                comando.Parameters.Add(@p2);
                comando.ExecuteNonQuery();
                comando.Dispose();
                micomm.Desconectar();
                if (msg)
                {
                    MessageBox.Show("proceso realizado con exito...");
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(messagerror + ex);
                return false;
            }
        }
        public Boolean CommandSqlGenericOneParameter(string db, string query, string par, Boolean msg, string messagerror)
        {
            // Ejecuta comando sql query y no devuleve ni valor ni datos.
            try
            {
                micomm.Conectar(db);
                SqlCommand comando = new SqlCommand
                {
                    Connection = micomm.cnn,
                    CommandType = CommandType.Text,
                    CommandText = query
                };
                SqlParameter p1 = new SqlParameter("@p1", par);
                comando.Parameters.Add(@p1);
                comando.ExecuteNonQuery();
                comando.Dispose();
                micomm.Desconectar();
                if (msg)
                {
                    MessageBox.Show("proceso realizado con exito...");
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(messagerror + ex);
                return false;
            }
        }
        public DataTable CommandSqlGenericDt(string db, string query,string par1,string par2, string messagefail)
        {
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            try
            {

                micomm.Conectar(db);
                SqlCommand comando = new SqlCommand
                {
                    Connection = micomm.cnn,
                    CommandType = CommandType.Text,
                    CommandText = query
                };
                SqlParameter p1 = new SqlParameter("@p1", par1);
                SqlParameter p2 = new SqlParameter("@p2", par2);
                comando.Parameters.Add(p1);
                comando.Parameters.Add(p2);
                comando.ExecuteNonQuery();
                da.SelectCommand = comando;
                da.Fill(dt);
                comando.Dispose();
                micomm.Desconectar();

            }
            catch (SqlException ex)
            {
                MessageBox.Show(messagefail + ex);

            }
            da.Dispose();
            return dt;
        }
        public DataTable GetCustomers() 
        {
			DataTable dt = new DataTable();
            using (SqlDataAdapter da = new SqlDataAdapter())
            {
                try
                {
                    micomm.Conectar(R.SQL.DATABASE.NAME);
                    SqlCommand comando = new SqlCommand
                    {
                        Connection = micomm.cnn,
                        CommandType = CommandType.Text,
                        CommandText = R.SQL.QUERY_SQL.CUSTOMERS.SQL_SELECT_CUSTOMERS
                    };
                    comando.ExecuteNonQuery();
                    da.SelectCommand = comando;
                    da.Fill(dt);
                    comando.Dispose();
                    micomm.Desconectar();
                    return dt;
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(R.ERROR_MESSAGES.CUSTOMERS.MESSAGE_ERROR_GETLISTCUSTOMERS + ex);
                    return dt;
                }
            }
        }
        public DataTable GetProducts()
        {
            DataTable dt = new DataTable();
            using (SqlDataAdapter da = new SqlDataAdapter())
            {
                try
                {
                    micomm.Conectar(R.SQL.DATABASE.NAME);
                    SqlCommand comando = new SqlCommand
                    {
                        Connection = micomm.cnn,
                        CommandType = CommandType.Text,
                        CommandText = R.SQL.QUERY_SQL.PRODUCTS.SQL_QUERY_SELECT_PRODUCT_ALL
                    };
                    comando.ExecuteNonQuery();
                    da.SelectCommand = comando;
                    da.Fill(dt);
                    comando.Dispose();
                    micomm.Desconectar();
                    return dt;
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(R.ERROR_MESSAGES.MODULO_PRODUCTOS.MESSAGE_SELECT_LOADPRODUCTOS_FAIL + ex);
                    return dt;
                }
            }

        }
        public void LoadDevoluciones() 
        {
            //TABLA MASTER
            CommandSqlGenericUpdateDs(R.SQL.DATABASE.NAME, R.SQL.QUERY_SQL.DEVOLUCION.SQL_SELECT_DEVOLUCIONES_SELECT_HEADER,
            dadevolucion, "dtdevolucion", R.ERROR_MESSAGES.DEVOLUCIONES.MESSAGE_SELECT_DEV_ERROR_HEADER);
            //TABLA DETAILS
            CommandSqlGenericUpdateDs(R.SQL.DATABASE.NAME, R.SQL.QUERY_SQL.DEVOLUCION.SQL_SELECT_DEVOLUCIONES_SELECT_ITEMSROWS,
            daitemrows, "dtitemrows", R.ERROR_MESSAGES.DEVOLUCIONES.MESSAGE_SELECT_DEV_ERROR_ITEMROWS);
        }
        public void LoadProducts() 
        {
            CommandSqlGenericUpdateDs(R.SQL.DATABASE.NAME, R.SQL.QUERY_SQL.DESPACHOS.SQL_SELECT_PRODUCTOS,
                daproduct, "dtproduct", R.ERROR_MESSAGES.DESPACHOS.MESSAGE_SELECT_ERROR_LOAD_PRODUCTS);
        }
        public void LoadCustomers() 
        {
            CommandSqlGenericUpdateDs(R.SQL.DATABASE.NAME, R.SQL.QUERY_SQL.DESPACHOS.SQL_SELECT_CUSTOMERS,
               dacustomer, "dtcustomer", R.ERROR_MESSAGES.DESPACHOS.MESSAGE_SELECT_ERROR_LOAD_CUSTOMERS);
        }
        public Boolean RelacionesDS() 
        {
            try
            {
                //Relacion Maestro-detalle.
                DataColumn ParentCol0 = ds.Tables["dtdevolucion"].Columns["numero"];
                DataColumn ChildCol0 = ds.Tables["dtitemrows"].Columns["numero"];
                DataRelation master_details = new DataRelation("FK_MASTER_DETAILS", ParentCol0, ChildCol0);
                ds.Relations.Add(master_details);
                //Relacion Detalle-productos.
                DataColumn ParentCol1 = ds.Tables["dtproduct"].Columns["PRODUCT_ID"];
                DataColumn ChildCol1 = ds.Tables["dtitemrows"].Columns["PRODUCT_ID"];
                DataRelation ITEMS_PRODUCTS = new DataRelation("FK_ITEMS_PRODUCTS", ParentCol1, ChildCol1);
                ds.Relations.Add(ITEMS_PRODUCTS);
                //Agregar la columna de nombre del producto.
                ds.Tables["dtitemrows"].Columns.Add("product_name",
                Type.GetType("System.String"), "parent(FK_ITEMS_PRODUCTS).product_name");
                //Relacion Devolucion-Cliente.
                DataColumn ParentCol2 = ds.Tables["dtcustomer"].Columns["customer_id"];
                DataColumn ChildCol2 = ds.Tables["dtdevolucion"].Columns["customer_id"];
                DataRelation DEVOL_cliente = new DataRelation("FK_DEVOL_CLIENTE", ParentCol2, ChildCol2);
                ds.Relations.Add(DEVOL_cliente);
                ds.Tables["dtdevolucion"].Columns.Add("customer_name",
                Type.GetType("System.String"), "parent(FK_DEVOL_CLIENTE).customer_name");
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        public Item GetDataForID(int tipo_product,string unique_code,string product_id) 
        {
            DataTable dt = new DataTable();
            switch (tipo_product) 
            {
                case 1:
                    //MASTER.
                    break;
                case 2:
                    //ROLLOS CORTADOS.
                     dt = CommandSqlGenericDt(R.DATABASES.RITRAMA,R.SQL.QUERY_SQL.DEVOLUCION.SQL_GETDATA_ID_ROLL_DEVOL,
                     unique_code,product_id,R.ERROR_MESSAGES.DEVOLUCIONES.MESSAGE_ERROR_GETDATA_UNIQUE);                    
                    break;
                case 3:
                    //GRAPHICS.
                    dt = CommandSqlGenericDt(R.DATABASES.RITRAMA, R.SQL.QUERY_SQL.DEVOLUCION.SQL_GETDATA_ID_GRAPHICS_DEVOL,
                    unique_code, product_id, R.ERROR_MESSAGES.DEVOLUCIONES.MESSAGE_ERROR_GETDATA_UNIQUE);
                    break;
                case 4:
                    // HOJAS.
                    dt = CommandSqlGenericDt(R.DATABASES.RITRAMA, R.SQL.QUERY_SQL.DEVOLUCION.SQL_GETDATA_ID_HOJAS_DEVOL,
                    unique_code, product_id, R.ERROR_MESSAGES.DEVOLUCIONES.MESSAGE_ERROR_GETDATA_UNIQUE);
                    break;
            }
            Item item = new Item
            {
                Unique_code = unique_code,
                Product_id = product_id,
                Width = Convert.ToDecimal(dt.Rows[0][0]),
                Lenght = Convert.ToDecimal(dt.Rows[0][1]),
                Msi = Convert.ToDecimal(dt.Rows[0][2])
            };
            return item;
        }
        public bool CheckStatusDespachoID(string id, int tipo_product, string product_id) 
        {
            switch (tipo_product)
            {
                case 1:
                    //MASTER.
                    return CommandSqlGenericTwoParameter(R.DATABASES.RITRAMA,
                        R.SQL.QUERY_SQL.DEVOLUCION.SQL_CHECK_ID_MASTER_DEVOL,id,product_id,false,"");
                case 2:
                    //ROLLOS CORTADOS.
                    return CommandSqlGenericTwoParameter(R.DATABASES.RITRAMA, 
                        R.SQL.QUERY_SQL.DEVOLUCION.SQL_CHECK_ID_ROLL_DEVOL, id, product_id, false, "");
                case 3:
                    //GRAPHICS.
                    return CommandSqlGenericTwoParameter(R.DATABASES.RITRAMA, 
                        R.SQL.QUERY_SQL.DEVOLUCION.SQL_CHECK_ID_GRAPHICS_DEVOL, id, product_id, false, "");
                case 4:
                    // HOJAS.
                    return CommandSqlGenericTwoParameter(R.DATABASES.RITRAMA, 
                        R.SQL.QUERY_SQL.DEVOLUCION.SQL_CHECK_ID_HOJAS_DEVOL, id, product_id, false, "");
                default:
                    return false;
            }
        }
        public void UpdateDataInventory(int tipo_product, bool status,Item item) 
        {
            switch (tipo_product)
            {
                case 1:
                    ////MASTER.
                    //SqlGenericTwoParamOnlyUpdate(R.DATABASES.RITRAMA,
                    //R.SQL.QUERY_SQL.DEVOLUCION.SQL_UPDATE_INVENTORY_MASTER_DEVOL,id,status,false,"");
                    break;
                case 2:
                    //ROLLOS CORTADOS.
                    CommandSqlGeneric(R.DATABASES.RITRAMA, R.SQL.QUERY_SQL.DEVOLUCION.SQL_UPDATE_INVENTORY_ROLL_DEVOL,
                    SetParametersInventary(item,status),false,R.ERROR_MESSAGES.DEVOLUCIONES.MESSAGE_ERROR_UPDATE_INVENTARY);
                    break;
                case 3:
                    //GRAPHICS.
                    CommandSqlGeneric(R.DATABASES.RITRAMA, R.SQL.QUERY_SQL.DEVOLUCION.SQL_UPDATE_INVENTORY_GRAPHICS_DEVOL,
                    SetParametersInventary(item, status), false, R.ERROR_MESSAGES.DEVOLUCIONES.MESSAGE_ERROR_UPDATE_INVENTARY);
                    break;
                case 4:
                    // HOJAS.
                    CommandSqlGeneric(R.DATABASES.RITRAMA, R.SQL.QUERY_SQL.DEVOLUCION.SQL_UPDATE_INVENTORY_HOJAS_DEVOL,
                    SetParametersInventary(item, status), false, R.ERROR_MESSAGES.DEVOLUCIONES.MESSAGE_ERROR_UPDATE_INVENTARY);
                    break;
            }
        }
        public List<SqlParameter> SetParametersInventary(Item item,Boolean sw)
        {
            List<SqlParameter> sp = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName = "@p1", SqlDbType = SqlDbType.NVarChar, Value = item.Unique_code},
                new SqlParameter() {ParameterName = "@p2", SqlDbType = SqlDbType.NVarChar, Value = item.Width},
                new SqlParameter() {ParameterName = "@p3", SqlDbType = SqlDbType.Decimal, Value = item.Lenght},
                new SqlParameter() {ParameterName = "@p4", SqlDbType = SqlDbType.NVarChar, Value = item.Msi},
                new SqlParameter() {ParameterName = "@p5", SqlDbType = SqlDbType.NVarChar, Value = sw}
            };
            return sp;
        }
        public bool DisableDocument(string numero) 
        {
            try
            {
                CommandSqlGenericOneParameter(R.DATABASES.RITRAMA,
                R.SQL.QUERY_SQL.DEVOLUCION.SQL_ANULAR_DOCUMENTO_DEVOL, numero, false, "");
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(R.ERROR_MESSAGES.DEVOLUCIONES.
                    MESSAGE_ERROR_ANULAR_DOC + ex.ToString());
                return false;
            }
            
        }
    }
}
