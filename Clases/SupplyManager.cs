using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace RitramaAPP.Clases
{
    public class SupplyManager
    {
        // Codigo para administrar todos los procesos de Preveedores   

        readonly Conexion micomm = new Conexion();
        public DataSet ds = new DataSet();
        readonly DataTable dtsupply = new DataTable();
        readonly SqlDataAdapter dasupply = new SqlDataAdapter();

        public DataTable Dtsupply => dtsupply;

        public Boolean CommandSqlGeneric(string db, string query, List<SqlParameter> spc)
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
                MessageBox.Show("proceso realizado con exito...");
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar nuevo registro de proveedor...Error Code:" + ex);
                return false;
            }
        }
        public Boolean ProveedorExiste(string codigo)
        {
            int result;
            micomm.Conectar(R.SQL.DATABASE.NAME);
            SqlCommand comando = new SqlCommand
            {
                CommandType = CommandType.Text,
                CommandText = R.SQL.QUERY_SQL.PROVIDERS.SQL_QUERY_COUNT_PROVEEDORES,
                Connection = micomm.cnn
            };
            SqlParameter p1 = new SqlParameter("@p1", codigo);
            comando.Parameters.Add(p1);
            result = Convert.ToInt16(comando.ExecuteScalar());
            micomm.Desconectar();
            comando.Dispose();
            if (result == 1)
            {
                return true;
            }
            else
            {
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
                    CommandText = R.SQL.QUERY_SQL.PROVIDERS.SQL_QUERY_SELECT_PROVEEDORES
                };
                comando.ExecuteNonQuery();
                dasupply.SelectCommand = comando;
                dasupply.Fill(ds, "dtsupply");
                comando.Dispose();
                micomm.Desconectar();
                return true;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al cargar la lista de los proveedores. error code:" + ex);
                return false;
            }
        }
        public void Add(ClassSupply datos)
        {

            //llamo al comando sql generico.
            CommandSqlGeneric(R.SQL.DATABASE.NAME,
                R.SQL.QUERY_SQL.PROVIDERS.SQL_QUERY_INSERT_PROVEEDORES, SetParameters(datos));
        }

        public void Update(ClassSupply datos)
        {
            CommandSqlGeneric(R.SQL.DATABASE.NAME,
                R.SQL.QUERY_SQL.PROVIDERS.SQL_QUERY_UPDATE_PROVEEDORES, SetParameters(datos));
        }
        public List<SqlParameter> SetParameters(ClassSupply datos)
        {
            List<SqlParameter> sp = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName = "@p1", SqlDbType = SqlDbType.NVarChar, Value = datos.Supply_ID},
                new SqlParameter() {ParameterName = "@p2", SqlDbType = SqlDbType.NVarChar, Value = datos.Supply_Name},
                new SqlParameter() {ParameterName = "@p3", SqlDbType = SqlDbType.NVarChar, Value = datos.Supply_Direcc},
                new SqlParameter() {ParameterName = "@p4", SqlDbType = SqlDbType.NVarChar, Value = datos.Supply_Phone},
                new SqlParameter() {ParameterName = "@p5", SqlDbType = SqlDbType.NVarChar, Value = datos.Supply_Email},
                new SqlParameter() {ParameterName = "@p6", SqlDbType = SqlDbType.Bit, Value = datos.Anulado},
                new SqlParameter() {ParameterName = "@p7", SqlDbType = SqlDbType.Bit, Value = datos.unid_master_1},
                new SqlParameter() {ParameterName = "@p8", SqlDbType = SqlDbType.Bit, Value = datos.unid_master_2}
            };
            return sp;
        }
    }
}
