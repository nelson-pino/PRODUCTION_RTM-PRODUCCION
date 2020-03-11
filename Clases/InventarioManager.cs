using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace RitramaAPP.Clases
{
    public class InventarioManager
    {
        readonly Conexion Micomm = new Conexion();
        public Boolean CommandSqlGeneric(string db, string query, List<SqlParameter> spc, Boolean msg, string messagerror)
        {
            // Ejecuta comando sql query y no devuleve ni valor ni datos.
            try
            {
                Micomm.Conectar(db);
                SqlCommand comando = new SqlCommand
                {
                    Connection = Micomm.cnn,
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
                Micomm.Desconectar();
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
        public DataTable CommandSqlGenericDt(string db, string query, string messagefail)
        {
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            try
            {

                Micomm.Conectar(db);
                SqlCommand comando = new SqlCommand
                {
                    Connection = Micomm.cnn,
                    CommandType = CommandType.Text,
                    CommandText = query
                };
                comando.ExecuteNonQuery();
                da.SelectCommand = comando;
                da.Fill(dt);
                comando.Dispose();
                Micomm.Desconectar();

            }
            catch (SqlException ex)
            {
                MessageBox.Show(messagefail + ex);

            }
            da.Dispose();
            return dt;
        }
        public DataTable CommandSqlGenericDtOnePar(string db, string query, string messagefail, string product_id)
        {
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            try
            {

                Micomm.Conectar(db);
                SqlCommand comando = new SqlCommand
                {
                    Connection = Micomm.cnn,
                    CommandType = CommandType.Text,
                    CommandText = query
                };
                SqlParameter p1 = new SqlParameter("@p1", product_id);
                comando.Parameters.Add(@p1);
                comando.ExecuteNonQuery();
                da.SelectCommand = comando;
                da.Fill(dt);
                comando.Dispose();
                Micomm.Desconectar();


            }
            catch (SqlException ex)
            {
                MessageBox.Show(messagefail + ex);

            }
            da.Dispose();
            return dt;
        }
        public List<Item> GetDataIni()
        {
            //extraer data del txt de inventario inicial
            List<Item> items = new List<Item>();
            if (File.Exists(R.PATH_FILES.FILE_TXT_DATA_CANT_INICIALES))
            {
                try
                {
                    using (StreamReader sr = new StreamReader(R.PATH_FILES.FILE_TXT_DATA_CANT_INICIALES))
                    {
                        while (sr.Peek() >= 0)
                        {
                            string str;
                            string[] strArray;
                            str = sr.ReadLine();
                            strArray = str.Split(',');
                            string tipo = strArray[0];
                            string product_id = strArray[1];

                            Item elemento = new Item
                            {
                                Product_id = strArray[1],
                                Tipo = strArray[0]

                            };
                            if (tipo == "m" || tipo == "rc")
                            {
                                elemento.Width = Convert.ToDecimal(strArray[2]);
                                elemento.Lenght = Convert.ToDecimal(strArray[3]);
                                elemento.Msi = Convert.ToDecimal(strArray[4]);
                                elemento.Ubic = strArray[5];
                                elemento.Documento = strArray[6];
                                elemento.Cantidad = 1;
                            }
                            if (tipo == "g" || tipo == "r")
                            {
                                elemento.Cantidad = Convert.ToDecimal(strArray[2]);
                                elemento.Ubic = strArray[3];
                                elemento.Documento = "";
                            }
                            items.Add(elemento);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("no se encontro el archivo txt de inventario inicial" + ex);

                }
            }
            return items;
        }
        public void SaveDataIni(List<Item> lista)
        {
            foreach (Item item in lista)
            {
                CommandSqlGeneric(R.SQL.DATABASE.NAME, R.SQL.QUERY_SQL.INVENTARIO.SQL_INSERT_INVENTARIO_SAVE_INICIALES,
                    SetParametersIni(item), false, R.ERROR_MESSAGES.INVENTARIO.MESSAGE_INSERT_INICIALES_ERROR);
            }
        }
        public List<SqlParameter> SetParametersIni(Item item)
        {
            List<SqlParameter> sp = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName = "@p1", SqlDbType = SqlDbType.NVarChar, Value = item.Product_id},
                new SqlParameter() {ParameterName = "@p2", SqlDbType = SqlDbType.Decimal, Value = item.Cantidad},
                new SqlParameter() {ParameterName = "@p3", SqlDbType = SqlDbType.Decimal, Value = item.Width},
                new SqlParameter() {ParameterName = "@p4", SqlDbType = SqlDbType.Decimal, Value = item.Lenght},
                new SqlParameter() {ParameterName = "@p5", SqlDbType = SqlDbType.Decimal, Value = item.Msi},
                new SqlParameter() {ParameterName = "@p6", SqlDbType = SqlDbType.NVarChar, Value = item.Ubic},
                new SqlParameter() {ParameterName = "@p7", SqlDbType = SqlDbType.NVarChar, Value = item.Documento}
            };
            return sp;
        }
        public DataTable ToListIni()
        {
            return CommandSqlGenericDt(R.SQL.DATABASE.NAME, R.SQL.QUERY_SQL.INVENTARIO.SQL_SELECT_INVENTARIO_INICIALES,
                R.ERROR_MESSAGES.INVENTARIO.MESSAGE_SELECT_INICIALES_ERROR);
        }
        public DataTable CargarInventario()
        {
            return CommandSqlGenericDt(R.SQL.DATABASE.NAME, R.
                SQL.QUERY_SQL.INVENTARIO.SQL_SELECT_INVENTARIO_QUERY_MASTER,
                R.ERROR_MESSAGES.INVENTARIO.MESSAGE_CARGAR_INVENTARIO_ERROR);
        }
        public DataTable CargarMovimientoEntradaMaster(string product_id)
        {
            return CommandSqlGenericDtOnePar(R.SQL.DATABASE.NAME,
                R.SQL.QUERY_SQL.INVENTARIO.SQL_QUERY_ENTRADAS_MASTER_WHERE_PRODUCT_ID,
                R.ERROR_MESSAGES.INVENTARIO.MESSAGE_CARGAR_MOVIMIENTO_MASTER, product_id);
        }
        public DataTable LoadMoveSalidasMaster(string rollid)
        {
            return CommandSqlGenericDtOnePar(R.SQL.DATABASE.NAME,
                R.SQL.QUERY_SQL.INVENTARIO.SQL_SELECT_SALIDAS_MASTER,
                R.ERROR_MESSAGES.INVENTARIO.MESSAGE_ERROR_SALIDAS_MASTER, rollid);
        }

        public DataTable CargaMovimientoEntradaRollosCortados(string product_id)
        {
            return CommandSqlGenericDtOnePar(R.SQL.DATABASE.NAME,
                   R.SQL.QUERY_SQL.INVENTARIO.SQL_QUERY_ENTRADAS_ROLLO_CORTADO_WHERE_PRODUCT_ID,
                   R.ERROR_MESSAGES.INVENTARIO.MESSAGE_CARGAR_ENTREDAS_ROLLO_CORTADO, product_id);

        }
        public DataTable CargaMovimientoSalidasRollosCortados(string product_id)
        {
            return CommandSqlGenericDtOnePar(R.SQL.DATABASE.NAME,
                   R.SQL.QUERY_SQL.INVENTARIO.SQL_QUERY_SALIDAS_ROLLOS_CORTADOS_WHERE_PRODUCT_ID,
                   R.ERROR_MESSAGES.INVENTARIO.MESSAGE_CARGAR_SALIDAS_ROLLO_CORTADO, product_id);
        }
    }
    public class Item
    {
        public string Tipo { get; set; }
        public string Product_id { get; set; }
        public string Product_name { get; set; }
        public decimal Width { get; set; }
        public decimal Lenght { get; set; }
        public decimal Msi { get; set; }
        public string Ubic { get; set; }
        public string Documento { get; set; }
        public decimal Cantidad { get; set; }
    }
}
