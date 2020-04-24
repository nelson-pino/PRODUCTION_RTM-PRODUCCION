using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace RitramaAPP.Clases
{
    public class RecepcionManager
    {
        readonly Conexion micomm = new Conexion();
        readonly SqlDataAdapter darecepcion = new SqlDataAdapter();
        readonly SqlDataAdapter daproducto = new SqlDataAdapter();
        readonly SqlDataAdapter daprovider = new SqlDataAdapter();
        private readonly DataTable dtrecepcion = new DataTable();
        readonly DataTable dtproducto = new DataTable();
        private readonly DataTable dtprovider = new DataTable();
        public DataSet ds = new DataSet();
        public DataTable Dtproducto => dtproducto;
        public DataTable Dtrecepcion => dtrecepcion;
        public DataTable Dtprovider => dtprovider;

        public RecepcionManager()
        {
            LoadRecepciones(1);
            LoadProducts();
            LoadProviders();
            RelacionesDS();
        }

        public Boolean CommandSqlGeneric(string db, string query, List<SqlParameter> spc, string messageok, string messagefail, Boolean msg_onoff)
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
                if (msg_onoff)
                {
                    MessageBox.Show(messageok);
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(messagefail + ex);
                return false;
            }
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
        public void Add(ClassRecepcion datos, Boolean message, int StatusTableName)
        {
            string TableName = "";
            if (StatusTableName == 1)
            {
                // select tabla recepciones.
                TableName = R.SQL.QUERY_SQL.RECEPCIONES.SQL_QUERY_INSERT_DOCS_RECEPCIONES;
            }
            else if (StatusTableName == 2)
            {
                // select iniciales de masters
                TableName = R.SQL.QUERY_SQL.RECEPCIONES.SQL_QUERY_INSERT_INICIALES_MASTERS;
            }
            else if (StatusTableName == 3)
            {
                // select iniciales de hojas
                TableName = R.SQL.QUERY_SQL.RECEPCIONES.SQL_QUERY_INSERT_INICIALES_HOJAS;
            }
            else if (StatusTableName == 4)
            {
                // select iniciales de graphics
                TableName = R.SQL.QUERY_SQL.RECEPCIONES.SQL_QUERY_INSERT_INICIALES_GRAPHICS;
            }
            CommandSqlGeneric(R.SQL.DATABASE.NAME, TableName,
              SetParametersAdd(datos), R.ERROR_MESSAGES.MODULO_RECEPCIONES.MESSAGE_INSERT_RECEPCIONES_OK,
              R.ERROR_MESSAGES.MODULO_RECEPCIONES.MESSAGE_INSERT_RECEPCIONES_FAIL, message);
        }
        public void Update(ClassRecepcion datos, bool msg_onoff)
        {
            CommandSqlGeneric(R.SQL.DATABASE.NAME, R.SQL.QUERY_SQL.RECEPCIONES.SQL_QUERY_UPDATE_ORDEN_RECEPCION,
            SetParametersUpdate(datos), R.ERROR_MESSAGES.MODULO_RECEPCIONES.MESSAGE_UPDATE_RECEPCIONES_OK,
            R.ERROR_MESSAGES.MODULO_RECEPCIONES.MESSAGE_UPDATE_RECEPCIONES_FAIL, msg_onoff);
        }
        public void LoadRecepciones(int StatusTableName)
        {
            string TableName = "";
            if (StatusTableName == 1)
            {
                // select tabla recepciones.
                TableName = R.SQL.QUERY_SQL.RECEPCIONES.SQL_QUERY_SELECT_ORDENES_RECEPCION;
            }
            else if (StatusTableName == 2)
            {
                // select iniciales de masters
                TableName = R.SQL.QUERY_SQL.RECEPCIONES.SQL_QUERY_SELECT_INICIALES_MASTERS;
            }
            else if (StatusTableName == 3)
            {
                // select iniciales de hojas
                TableName = R.SQL.QUERY_SQL.RECEPCIONES.SQL_QUERY_SELECT_INICIALES_HOJAS;
            }
            else if (StatusTableName == 4)
            {
                // select iniciales de graphica
                TableName = R.SQL.QUERY_SQL.RECEPCIONES.SQL_QUERY_SELECT_INICIALES_GRAPHICS;
            }
            CommandSqlGenericUpdateDs(R.SQL.DATABASE.NAME, TableName,
                darecepcion, "dtrecepcion", R.ERROR_MESSAGES.MODULO_RECEPCIONES.MESSAGE_SELECT_LOADRECEPCIONES_FAIL);
        }
        public void LoadProducts()
        {
            CommandSqlGenericUpdateDs(R.SQL.DATABASE.NAME, R.SQL.QUERY_SQL.PRODUCTS.SQL_QUERY_SELECT_PRODUCTS,
                daproducto, "dtproducto", R.ERROR_MESSAGES.MODULO_PRODUCTOS.MESSAGE_SELECT_LOADPRODUCTOS_FAIL);
        }
        public void LoadProviders()
        {
            CommandSqlGenericUpdateDs(R.SQL.DATABASE.NAME, R.SQL.QUERY_SQL.PROVIDERS.SQL_QUERY_SELECT_PROVEEDORES,
               daprovider, "dtprovider", R.ERROR_MESSAGES.MODULO_PROVEEDORES.MESSAGE_SELECT_LOADPROVEEDORES_FAIL);
        }
        public List<ClassRecepcion> DownloadDataMateriaPrimaTxtMovil()
        {

            string path = R.PATH_FILES.FILE_TXT_MATERIA_PRIMA;
            List<ClassRecepcion> lista = new List<ClassRecepcion>();
            if (File.Exists(path))
            {
                try
                {
                    using (StreamReader sr = new StreamReader(path))
                    {
                        while (sr.Peek() >= 0)
                        {
                            try
                            {
                                string str;
                                string[] strArray;
                                str = sr.ReadLine();
                                strArray = str.Split(',');
                                string strWidth = strArray[2];
                                string strLenght = strArray[3];
                                int lenWidth = strWidth.Length;
                                int lenLenght = strLenght.Length;
                                strWidth = strWidth.Substring(1, lenWidth - 1);
                                strLenght = strLenght.Substring(1, lenLenght - 1);
                                double WidthValue = double.Parse(strWidth, CultureInfo.InvariantCulture);
                                double LenghtValue = double.Parse(strLenght, CultureInfo.InvariantCulture);
                                ClassRecepcion recepcion = new ClassRecepcion
                                {
                                    Orden = strArray[0],
                                    Part_Number = strArray[1],
                                    ProductName = SearchProductName(strArray[1]),
                                    Tipo = SearchTipoProduct(strArray[1]),
                                    Width = WidthValue,
                                    Lenght = LenghtValue,
                                    Roll_ID = (strArray[4])
                                };
                                lista.Add(recepcion);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("error al leer la data y convertir el archivo txt de recepciones en la pc: " + ex);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("error al tratar de crear el txt de materia prima" + ex);
                    lista = null;
                    return lista;
                }
            }
            else
            {

            }
            return lista;
        }
        public string SearchTipoProduct(string product_id)
        {

            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            micomm.Conectar(R.SQL.DATABASE.NAME);
            SqlCommand comando = new SqlCommand
            {
                CommandType = CommandType.Text,
                CommandText = R.SQL.QUERY_SQL.PRODUCTS.SQL_QUERY_SELECT_TYPE_PRODUCT,
                Connection = micomm.cnn
            };
            SqlParameter p1 = new SqlParameter("@p1", product_id);
            comando.Parameters.Add(p1);
            da.SelectCommand = comando;
            comando.ExecuteScalar();
            da.Fill(dt);
            micomm.Desconectar();
            comando.Dispose();
            da.Dispose();
            if (dt.Rows.Count > 0)
            {
                if (Convert.ToBoolean(dt.Rows[0][0]))
                {
                    return "master roll";
                }
                if (Convert.ToBoolean(dt.Rows[0][1]))
                {
                    return "resma";
                }
                if (Convert.ToBoolean(dt.Rows[0][2]))
                {
                    return "graphics";
                }
                return "no catalogado";
            }
            else
            {
                return "no categoria";
            }

        }
        public string SearchProductName(string product_id)
        {
            string result;
            micomm.Conectar(R.SQL.DATABASE.NAME);
            SqlCommand comando = new SqlCommand
            {
                CommandType = CommandType.Text,
                CommandText = R.SQL.QUERY_SQL.PRODUCTS.SQL_QUERY_SELECT_PRODUCT_NAME,
                Connection = micomm.cnn
            };
            SqlParameter p1 = new SqlParameter("@p1", product_id);
            comando.Parameters.Add(p1);
            result = Convert.ToString(comando.ExecuteScalar());
            micomm.Desconectar();
            comando.Dispose();
            return result;
        }
        public Boolean OrderExiste(string codigo)
        {
            int result;
            micomm.Conectar(R.SQL.DATABASE.NAME);
            SqlCommand comando = new SqlCommand
            {
                CommandType = CommandType.Text,
                CommandText = R.SQL.QUERY_SQL.RECEPCIONES.SQL_QUERY_COUNT_FOR_ORDER,
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
        public Boolean VerificarID(string ID)
        {
            int result;
            micomm.Conectar(R.SQL.DATABASE.NAME);
            SqlCommand comando = new SqlCommand
            {
                CommandType = CommandType.Text,
                CommandText = R.SQL.QUERY_SQL.RECEPCIONES.SQL_QUERY_VERIFICAR_ROLLID,
                Connection = micomm.cnn
            };
            SqlParameter p1 = new SqlParameter("@p1", ID);
            comando.Parameters.Add(p1);
            result = Convert.ToInt16(comando.ExecuteScalar());
            micomm.Desconectar();
            comando.Dispose();
            if (result >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public Boolean VericarMasterollMetros(string codigo_prv)
        {
            Boolean providerMeters;
            micomm.Conectar(R.SQL.DATABASE.NAME);
            SqlCommand comando = new SqlCommand
            {
                CommandType = CommandType.Text,
                CommandText = R.SQL.QUERY_SQL.RECEPCIONES.SQL_QUERY_COUNT_FOR_VERIFY_UNIT2,
                Connection = micomm.cnn
            };
            SqlParameter p1 = new SqlParameter("@p1", codigo_prv);
            comando.Parameters.Add(p1);
            providerMeters = Convert.ToBoolean(comando.ExecuteScalar());
            micomm.Desconectar();
            comando.Dispose();
            return providerMeters;
        }
        public int VerifarProductType(string codigo_pro)
        {
            int result = 0;
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            micomm.Conectar(R.SQL.DATABASE.NAME);
            SqlCommand comando = new SqlCommand
            {
                CommandType = CommandType.Text,
                CommandText = R.SQL.QUERY_SQL.PRODUCTS.SQL_QUERY_SELECT_TYPE_PRODUCT,
                Connection = micomm.cnn
            };
            SqlParameter p1 = new SqlParameter("@p1", codigo_pro);
            comando.Parameters.Add(p1);
            comando.ExecuteNonQuery();
            da.SelectCommand = comando;
            da.Fill(dt);
            micomm.Desconectar();
            comando.Dispose();
            if (Convert.ToBoolean(dt.Rows[0]["MasterRolls"]))
            {
                result = 1;
            }

            else if (Convert.ToBoolean(dt.Rows[0]["Resmas"]))
            {
                result = 2;
            }
            else if (Convert.ToBoolean(dt.Rows[0]["Graphics"]))
            {
                result = 3;
            }
            da.Dispose();
            return result;
        }
        public Boolean VerificarExisteOrden(string orden)
        {
            int result;
            micomm.Conectar(R.SQL.DATABASE.NAME);
            SqlCommand comando = new SqlCommand
            {
                CommandType = CommandType.Text,
                CommandText = R.SQL.QUERY_SQL.RECEPCIONES.SQL_QUERY_VERIFY_ORDEN_REPEAT,
                Connection = micomm.cnn
            };
            SqlParameter p1 = new SqlParameter("@p1", orden);
            comando.Parameters.Add(p1);
            result = Convert.ToInt16(comando.ExecuteScalar());
            micomm.Desconectar();
            comando.Dispose();
            if (result == 1)
            {
                // La orden de Recepcion ya existe en la base de datos
                return true;
            }
            else
            {
                // no existe.
                return false;
            }
        }
        public List<SqlParameter> SetParametersAdd(ClassRecepcion datos)
        {
            List<SqlParameter> sp = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName = "@p1", SqlDbType = SqlDbType.NVarChar, Value = datos.Orden},
                new SqlParameter() {ParameterName = "@p2", SqlDbType = SqlDbType.NVarChar, Value = datos.Part_Number},
                new SqlParameter() {ParameterName = "@p3", SqlDbType = SqlDbType.Decimal, Value = datos.Width},
                new SqlParameter() {ParameterName = "@p4", SqlDbType = SqlDbType.Decimal, Value = datos.Lenght},
                new SqlParameter() {ParameterName = "@p5", SqlDbType = SqlDbType.NVarChar, Value = datos.Roll_ID},
                new SqlParameter() {ParameterName = "@p6", SqlDbType = SqlDbType.NVarChar, Value = datos.Supply_Id},
                new SqlParameter() {ParameterName = "@p7", SqlDbType = SqlDbType.NVarChar, Value = datos.Ubicacion},
                new SqlParameter() {ParameterName = "@p8", SqlDbType = SqlDbType.Decimal, Value = datos.Core},
                new SqlParameter() {ParameterName = "@p9", SqlDbType = SqlDbType.Decimal, Value = datos.Splice},
                new SqlParameter() {ParameterName = "@p10", SqlDbType = SqlDbType.Bit, Value = datos.Anulado},
                new SqlParameter() {ParameterName = "@p11", SqlDbType = SqlDbType.DateTime, Value = datos.Fecha_reg},
                new SqlParameter() {ParameterName = "@p12", SqlDbType = SqlDbType.NVarChar, Value = datos.Hora_reg},
                new SqlParameter() {ParameterName = "@p13", SqlDbType = SqlDbType.DateTime, Value = datos.Fecha_produccion},
                new SqlParameter() {ParameterName = "@p14", SqlDbType = SqlDbType.Bit, Value = datos.Master},
                new SqlParameter() {ParameterName = "@p15", SqlDbType = SqlDbType.Bit, Value = datos.Resma},
                new SqlParameter() {ParameterName = "@p16", SqlDbType = SqlDbType.Bit, Value = datos.Graphics},
                new SqlParameter() {ParameterName = "@p17", SqlDbType = SqlDbType.NVarChar, Value = datos.Embarque},
                new SqlParameter() {ParameterName = "@p18", SqlDbType = SqlDbType.NVarChar, Value = datos.Palet_number},
                new SqlParameter() {ParameterName = "@p19", SqlDbType = SqlDbType.Int, Value = datos.Palet_cant},
                new SqlParameter() {ParameterName = "@p20", SqlDbType = SqlDbType.Int, Value = datos.Palet_paginas},
                new SqlParameter() {ParameterName = "@p21", SqlDbType = SqlDbType.Int, Value = datos.Num_sincro},
                new SqlParameter() {ParameterName = "@p22", SqlDbType = SqlDbType.Bit, Value = datos.Registro_movil},
                new SqlParameter() {ParameterName = "@p23", SqlDbType = SqlDbType.Bit, Value = datos.Disponible},
                new SqlParameter() {ParameterName = "@p24", SqlDbType = SqlDbType.Decimal, Value = datos.Width_metros},
                new SqlParameter() {ParameterName = "@p25", SqlDbType = SqlDbType.Decimal, Value = datos.Lenght_metros},
                new SqlParameter() {ParameterName = "@p26", SqlDbType = SqlDbType.DateTime, Value = datos.Fecha_recepcion}
            };
            return sp;
        }
        public List<SqlParameter> SetParametersUpdate(ClassRecepcion datos)
        {
            List<SqlParameter> sp = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName = "@p1", SqlDbType = SqlDbType.NVarChar, Value = datos.Orden},
                new SqlParameter() {ParameterName = "@p2", SqlDbType = SqlDbType.DateTime, Value = datos.Fecha_produccion},
                new SqlParameter() {ParameterName = "@p3", SqlDbType = SqlDbType.NVarChar, Value = datos.Embarque},
                new SqlParameter() {ParameterName = "@p4", SqlDbType = SqlDbType.NVarChar, Value = datos.Roll_ID},
                new SqlParameter() {ParameterName = "@p5", SqlDbType = SqlDbType.Bit, Value = datos.Anulado},
                new SqlParameter() {ParameterName = "@p6", SqlDbType = SqlDbType.NVarChar, Value = datos.Ubicacion},
                new SqlParameter() {ParameterName = "@p7", SqlDbType = SqlDbType.NVarChar, Value = datos.Supply_Id},
                new SqlParameter() {ParameterName = "@p8", SqlDbType = SqlDbType.Decimal, Value = datos.Width},
                new SqlParameter() {ParameterName = "@p9", SqlDbType = SqlDbType.Decimal, Value = datos.Lenght},
                new SqlParameter() {ParameterName = "@p10", SqlDbType = SqlDbType.Decimal, Value = datos.Splice},
                new SqlParameter() {ParameterName = "@p11", SqlDbType = SqlDbType.Decimal, Value = datos.Core},
                new SqlParameter() {ParameterName = "@p12", SqlDbType = SqlDbType.Decimal, Value = datos.Width_metros},
                new SqlParameter() {ParameterName = "@p13", SqlDbType = SqlDbType.Decimal, Value = datos.Lenght_metros},
                new SqlParameter() {ParameterName = "@p14", SqlDbType = SqlDbType.DateTime, Value = datos.Fecha_recepcion}
            };
            return sp;
        }
        public Boolean RelacionesDS()
        {
            try
            {
                //Relacion Documento Recepcion-Producto.
                DataColumn ParentCol1 = ds.Tables["dtproducto"].Columns["Product_ID"];
                DataColumn ChildCol1 = ds.Tables["dtrecepcion"].Columns["Part_Number"];
                DataRelation recep_cliente = new DataRelation("FK_RECEPCION_PRODUCTO", ParentCol1, ChildCol1, false);
                ds.Relations.Add(recep_cliente);
                ds.Tables["dtrecepcion"].Columns.Add("product_name",
                Type.GetType("System.String"), "parent(FK_RECEPCION_PRODUCTO).Product_Name");
                //Relacion Documento recepcion-Vendedor.
                DataColumn ParentCol2 = ds.Tables["dtprovider"].Columns["Proveedor_ID"];
                DataColumn ChildCol2 = ds.Tables["dtrecepcion"].Columns["Proveedor_Id"];
                DataRelation recep_suplidor = new DataRelation("FK_RECEPCION_SUPLIDOR", ParentCol2, ChildCol2, false);
                ds.Relations.Add(recep_suplidor);
                ds.Tables["dtrecepcion"].Columns.Add("suplidor_des",
                Type.GetType("System.String"), "parent(FK_RECEPCION_SUPLIDOR).Proveedor_Name");
                return true;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al tratar de establecer las relaciones entre tablas. Error Code:" + ex);
                return false;
            }
        }
        public int MaxConsecOrden()
        {
            Int32 result;
            micomm.Conectar(R.SQL.DATABASE.NAME);
            SqlCommand comando = new SqlCommand
            {
                CommandType = CommandType.Text,
                CommandText = R.SQL.QUERY_SQL.RECEPCIONES.SQL_QUERY_RETURN_CONSENC_ORDEN,
                Connection = micomm.cnn
            };
            try
            {
                result = (Int32)comando.ExecuteScalar();
                micomm.Desconectar();
                comando.Dispose();
            }
            catch (Exception)
            {
                result = 1;
            }
            return (Int32)result;
        }
        public ClassRecepcion GetDataHojasByID(string id)
        {
            ClassRecepcion data = new ClassRecepcion();
            try
            {
                micomm.Conectar(R.SQL.DATABASE.NAME);
                SqlCommand comando = new SqlCommand
                {
                    Connection = micomm.cnn,
                    CommandType = CommandType.Text,
                    CommandText = R.SQL.QUERY_SQL.RECEPCIONES.SQL_QUERY_SELECT_GETDATABYID_HOJAS
                };
                SqlParameter p1 = new SqlParameter("@p1", id);
                comando.Parameters.Add(p1);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    data.Part_Number = reader.GetString(0);
                    data.ProductName = reader.GetString(1);
                    data.Palet_number = reader.GetString(2);
                    data.Width = Convert.ToDouble(reader["width"]);
                    data.Lenght = Convert.ToDouble(reader["lenght"]);
                    data.Palet_cant = Convert.ToDecimal(reader["palet_cant"]);
                    data.Palet_paginas = Convert.ToInt32(reader["palet_pag"]);
                    data.Tipo = reader.GetString(8);
                    data.cant_despacho = 0;
                }
                comando.Dispose();
                micomm.Desconectar();
                return data;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("error al tratar de leer la data de materia prima hojas. consulta por id..." + ex);
                return data;
            }
        }
        public ClassRecepcion GetDataGraphicsByID(string id) 
        {
            ClassRecepcion data = new ClassRecepcion();
            try
            {
                micomm.Conectar(R.SQL.DATABASE.NAME);
                SqlCommand comando = new SqlCommand
                {
                    Connection = micomm.cnn,
                    CommandType = CommandType.Text,
                    CommandText = R.SQL.QUERY_SQL.RECEPCIONES.SQL_QUERY_SELECT_GETDATABYID_GRAPHICS
                };
                SqlParameter p1 = new SqlParameter("@p1", id);
                comando.Parameters.Add(p1);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    data.Part_Number = reader.GetString(1);
                    data.ProductName = reader.GetString(2);
                    data.Width = Convert.ToDouble(reader["width"]);
                    data.Lenght = Convert.ToDouble(reader["lenght"]);
                    data.Roll_ID = reader.GetString(5);
                    
                    data.Palet_number = Convert.ToString(reader["palet_num"]);
                    data.Palet_paginas = Convert.ToInt32(reader["palet_pag"]);
                    data.Embarque = Convert.ToString(reader["palet_pag"]);
                    data.Embarque = Convert.ToString(reader["palet_pag"]);
                    data.Tipo = reader.GetString(10);
                    data.cant_despacho = 0;
                }
                comando.Dispose();
                micomm.Desconectar();
                return data;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("error al tratar de leer la data de materia prima graphics. consulta por id..." + ex);
                return data;
            }
        }
    }
}
