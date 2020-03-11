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
    }
}
