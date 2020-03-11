using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace RitramaAPP.Clases
{
    public class ProductsManager
    {
        readonly Conexion micomm = new Conexion();
        public DataSet ds = new DataSet();
        readonly DataTable dtproducto = new DataTable();
        readonly SqlDataAdapter daproducto = new SqlDataAdapter();

        public DataTable Dtproducto => dtproducto;

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
        public void Add(ClassProduct datos, Boolean mensajeok)
        {
            CommandSqlGeneric(R.SQL.DATABASE.NAME, R.SQL.QUERY_SQL.PRODUCTS.SQL_QUERY_INSERT_PRODUCT,
                SetParameters(datos), mensajeok, R.ERROR_MESSAGES.MODULO_PRODUCTOS.MESSAGE_ADD_PRODUCTS_ERROR);
        }
        public void Update(ClassProduct datos)
        {
            CommandSqlGeneric(R.SQL.DATABASE.NAME, R.SQL.QUERY_SQL.PRODUCTS.SQL_QUERY_UPDATE_PRODUCTS,
                SetParameters(datos), true, R.ERROR_MESSAGES.MODULO_PRODUCTOS.MESSAGE_UPDATE_PRODUCTS_ERROR);
        }
        public List<SqlParameter> SetParameters(ClassProduct datos)
        {
            List<SqlParameter> sp = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName = "@p1", SqlDbType = SqlDbType.NVarChar, Value = datos.Product_id },
                new SqlParameter() {ParameterName = "@p2", SqlDbType = SqlDbType.NVarChar, Value = datos.ProductName },
                new SqlParameter() {ParameterName = "@p3", SqlDbType = SqlDbType.NVarChar, Value = datos.Descripcion },
                new SqlParameter() {ParameterName = "@p4", SqlDbType = SqlDbType.NVarChar, Value = datos.Referencia },
                new SqlParameter() {ParameterName = "@p5", SqlDbType = SqlDbType.NVarChar, Value = datos.Codebar },
                new SqlParameter() {ParameterName = "@p6", SqlDbType = SqlDbType.NVarChar, Value = datos.Categoria},
                new SqlParameter() {ParameterName = "@p7", SqlDbType = SqlDbType.Bit, Value = datos.MasterRolls},
                new SqlParameter() {ParameterName = "@p8", SqlDbType = SqlDbType.Bit, Value = datos.Rollo_Cortado},
                new SqlParameter() {ParameterName = "@p9", SqlDbType = SqlDbType.Bit, Value = datos.Resmas},
                new SqlParameter() {ParameterName = "@p10", SqlDbType = SqlDbType.Bit, Value = datos.Graphics},
                new SqlParameter() {ParameterName = "@p11", SqlDbType = SqlDbType.Bit, Value = datos.Anulado},
                new SqlParameter() {ParameterName = "@p12", SqlDbType = SqlDbType.Decimal, Value = datos.Precio},
                new SqlParameter() {ParameterName = "@p13", SqlDbType = SqlDbType.NVarChar, Value = datos.Code_RC},
                new SqlParameter() {ParameterName = "@p14", SqlDbType = SqlDbType.Decimal, Value = datos.Ratio}
            };
            return sp;
        }
        public DataTable GetTableProductsOnly()
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
                    MessageBox.Show("Error al cargar la lista de productos. error code:" + ex);
                    return dt;
                }
            }

        }
        public Boolean ProductoExiste(string codigo)
        {
            int result;
            micomm.Conectar(R.SQL.DATABASE.NAME);
            SqlCommand comando = new SqlCommand
            {
                CommandType = CommandType.Text,
                CommandText = R.SQL.QUERY_SQL.PRODUCTS.SQL_QUERY_COUNT_PRODUCTS,
                Connection = micomm.cnn
            };
            SqlParameter p1 = new SqlParameter("@p1", codigo);
            comando.Parameters.Add(p1);
            result = Convert.ToInt16(comando.ExecuteScalar());
            micomm.Desconectar();
            comando.Dispose();
            if (result == 1)
            {
                // producto existe
                return true;
            }
            else
            {
                //producto no existe
                return false;
            }
        }
        public Boolean ToList()
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
                daproducto.SelectCommand = comando;
                daproducto.Fill(ds, "dtproducto");
                comando.Dispose();
                micomm.Desconectar();
                return true;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al cargar la lista de productos. error code:" + ex);
                return false;
            }
        }
        public string GetProductName(string product_id)
        {
            string productName;
            micomm.Conectar(R.SQL.DATABASE.NAME);
            SqlCommand comando = new SqlCommand
            {
                CommandType = CommandType.Text,
                CommandText = R.SQL.QUERY_SQL.PRODUCTS.SQL_QUERY_SELECT_PRODUCT_NAME,
                Connection = micomm.cnn
            };
            SqlParameter p1 = new SqlParameter("@p1", product_id);
            comando.Parameters.Add(p1);
            productName = comando.ExecuteScalar().ToString();
            micomm.Desconectar();
            comando.Dispose();
            return productName;
        }
        public string GetProductType(string product_id)
        {
            string category;
            micomm.Conectar(R.SQL.DATABASE.NAME);
            SqlCommand comando = new SqlCommand
            {
                CommandType = CommandType.Text,
                CommandText = R.SQL.QUERY_SQL.PRODUCTS.SQL_QUERY_CATEGORY_PRODUCTS,
                Connection = micomm.cnn
            };
            SqlParameter p1 = new SqlParameter("@p1", product_id);
            comando.Parameters.Add(p1);
            category = comando.ExecuteScalar().ToString();
            micomm.Desconectar();
            comando.Dispose();
            return category;
        }
    }
}
