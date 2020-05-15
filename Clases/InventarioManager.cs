namespace RitramaAPP.Clases
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.IO;
    using System.Linq;
    using System.Windows.Forms;
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
        public Boolean CommandSqlGenericTreeParameters(string db, string query, object par1, object par2, object par3, Boolean msg, string messagerror, int process)
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
                switch (process)
                {
                    case 1:
                        string po1 = par1.ToString();
                        int po2 = Convert.ToInt16(par2);
                        DateTime po3 = Convert.ToDateTime(par3);
                        break;
                }

                SqlParameter p1 = new SqlParameter("@p1", par1);
                SqlParameter p2 = new SqlParameter("@p2", par2);
                SqlParameter p3 = new SqlParameter("@p3", par3);
                comando.Parameters.Add(@p1);
                comando.Parameters.Add(@p2);
                comando.Parameters.Add(@p3);
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
        public DataTable GetCustomers()
        {
            DataTable dt = new DataTable();
            using (SqlDataAdapter da = new SqlDataAdapter())
            {
                try
                {
                    Micomm.Conectar(R.SQL.DATABASE.NAME);
                    SqlCommand comando = new SqlCommand
                    {
                        Connection = Micomm.cnn,
                        CommandType = CommandType.Text,
                        CommandText = R.SQL.QUERY_SQL.CUSTOMERS.SQL_SELECT_CUSTOMERS
                    };
                    comando.ExecuteNonQuery();
                    da.SelectCommand = comando;
                    da.Fill(dt);
                    comando.Dispose();
                    Micomm.Desconectar();
                    return dt;
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(R.ERROR_MESSAGES.CUSTOMERS.MESSAGE_ERROR_GETLISTCUSTOMERS + ex);
                    return dt;
                }
            }
        }
        public bool AddReserva(Reserva doc)
        {
            try
            {
                foreach (string id in doc.items)
                {
                    CommandSqlGeneric(R.DATABASES.RITRAMA,
                    R.SQL.QUERY_SQL.INVENTARIO.SQL_INSERT_DATA_RESERVA,
                    ParamReserva(doc, id), false, "");
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        public List<SqlParameter> ParamReserva(Reserva item, string id)
        {
            List<SqlParameter> sp = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName = "@p1", SqlDbType = SqlDbType.NVarChar, Value = item.Transac},
                new SqlParameter() {ParameterName = "@p2", SqlDbType = SqlDbType.NVarChar, Value = item.OrdenTrabajo},
                new SqlParameter() {ParameterName = "@p3", SqlDbType = SqlDbType.NVarChar, Value = item.OrdenServicio},
                new SqlParameter() {ParameterName = "@p4", SqlDbType = SqlDbType.DateTime, Value = item.FechaReserva},
                new SqlParameter() {ParameterName = "@p5", SqlDbType = SqlDbType.DateTime, Value = item.FechaPlan},
                new SqlParameter() {ParameterName = "@p6", SqlDbType = SqlDbType.NVarChar, Value = item.IdCust},
                new SqlParameter() {ParameterName = "@p7", SqlDbType = SqlDbType.NVarChar, Value = item.Commentary},
                new SqlParameter() {ParameterName = "@p8", SqlDbType = SqlDbType.NVarChar, Value = id},
                new SqlParameter() {ParameterName = "@p9", SqlDbType = SqlDbType.Int, Value = item.IndexProduct}
            };
            return sp;
        }
        public int GetTransacReserva()
        {
            int cant_value;
            Micomm.Conectar(R.DATABASES.RITRAMA);
            SqlCommand comando = new SqlCommand
            {
                CommandType = CommandType.Text,
                CommandText = R.SQL.QUERY_SQL.INVENTARIO.SQL_TRANSACT_DATA_RESERVA,
                Connection = Micomm.cnn
            };
            try
            {
                cant_value = (int)comando.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(R.ERROR_MESSAGES.INVENTARIO.MESSAGE_ERROR_TRANSAC_RESERVAS + ex);
                cant_value = 0;
            }
            Micomm.Desconectar();
            comando.Dispose();
            return cant_value;
        }
        public void MarkRowReserva(List<String> listid, int type_product)
        {
            try
            {
                switch (type_product)
                {
                    case 0:
                        // marcar master
                        SQL_COMMAND_MARK_RESERVA(listid, R.SQL.QUERY_SQL.INVENTARIO.SQL_MARK_RESERVA_MASTER);
                        break;
                    case 1:
                        // marcar hojas
                        SQL_COMMAND_MARK_RESERVA(listid, R.SQL.QUERY_SQL.INVENTARIO.SQL_MARK_RESERVA_HOJAS);
                        break;
                    case 2:
                        // marcar graphics
                        SQL_COMMAND_MARK_RESERVA(listid, R.SQL.QUERY_SQL.INVENTARIO.SQL_MARK_RESERVA_GRAF);
                        break;
                    case 3:
                        // marcar graphics
                        SQL_COMMAND_MARK_RESERVA(listid, R.SQL.QUERY_SQL.INVENTARIO.SQL_MARK_RESERVA_ROLLS);
                        break;
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("error al marcar las reserva de productos" + ex);

            }
        }
        public void SQL_COMMAND_MARK_RESERVA(List<String> listaid, string comando)
        {
            foreach (string item in listaid)
            {
                CommandSqlGenericDtOnePar(R.DATABASES.RITRAMA, comando, "", item);
            }

        }
        public bool UnmarkItemReserva(string id,int type_product) 
        {
            try
            {
                switch (type_product) 
                {
                    case 0:
                        break;
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        CommandSqlGenericDtOnePar(R.DATABASES.RITRAMA,
                        R.SQL.QUERY_SQL.INVENTARIO.SQL_UPDATE_ITEM_UNMARK_RESERVA3, "", id);
                        break;
                }
                
                return true;
            }
            catch (Exception)
            {
                return false;
            }        
        }
        public Reserva GetInfoDocumReserva(string id)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = CommandSqlGenericDtOnePar(R.DATABASES.RITRAMA,
                R.SQL.QUERY_SQL.INVENTARIO.SQL_SELECT_INFO_RESERVA,
                R.ERROR_MESSAGES.INVENTARIO.MESSAGE_ERROR_INFO_RESERVAS, id);
                Reserva documreserva = new Reserva
                {
                    Transac = Convert.ToInt16(dt.Rows[0]["transac"]),
                    OrdenServicio = Convert.ToString(dt.Rows[0]["orden_s"]),
                    OrdenTrabajo = Convert.ToString(dt.Rows[0]["orden_t"]),
                    FechaReserva = Convert.ToDateTime(dt.Rows[0]["fecha_reserva"]),
                    FechaPlan = Convert.ToDateTime(dt.Rows[0]["fecha_entrega"]),
                    IdCust = Convert.ToString(dt.Rows[0]["id_cust"]),
                    Customer_Name = Convert.ToString(dt.Rows[0]["customer_name"]),
                    Commentary = Convert.ToString(dt.Rows[0]["commentary"])
                };
                return documreserva;
            }
            catch (Exception)
            {
                MessageBox.Show("error al traer los datos de la reserva de productos");
                return null;
            }
        }
        public Boolean DeleteRenglonReserva(string id)
        {
            try
            {
                CommandSqlGenericDtOnePar(R.DATABASES.RITRAMA,
                    R.SQL.QUERY_SQL.INVENTARIO.SQL_DELETE_ITEM_RESERVA,
                    R.ERROR_MESSAGES.INVENTARIO.MESSAGE_ERROR_DELETE_ITEM_RESERVAS, id);
                return true;
            }
            catch (Exception)
            {
                return false;

            }
        }
        public Boolean DeleteDocumentReserva(string doc) 
        {
            try
            {
                //crear los objetos a utilizar
                List<string> ids = new List<string>();
                DataTable dt = new DataTable();
                //traer los codigos id desde la tabla de reserva
                dt = CommandSqlGenericDtOnePar(R.DATABASES.RITRAMA,
                R.SQL.QUERY_SQL.INVENTARIO.SQL_LIST_ID_ITEM_RESERVA,
                R.ERROR_MESSAGES.INVENTARIO.MESSAGE_ERROR_DELETE_DOCUMENT_RESERVAS,doc);
                //convertirlos a lista
                ids = dt.AsEnumerable()
                      .Select(r => r.Field<string>("id"))
                      .ToList();
                //recorrer la lista y ejecutar comando sql para desmarcalos
                foreach (string item in ids) 
                {
                    CommandSqlGenericDtOnePar(R.DATABASES.RITRAMA,
                    R.SQL.QUERY_SQL.INVENTARIO.SQL_UPDATE_ITEM_UNMARK_RESERVA3,
                    R.ERROR_MESSAGES.INVENTARIO.MESSAGE_ERROR_DELETE_DOCUMENT_RESERVAS,item);
                }
                //borra el documento de la tabla de reserva.
                CommandSqlGenericDtOnePar(R.DATABASES.RITRAMA,
                R.SQL.QUERY_SQL.INVENTARIO.SQL_DELETE_DOCUMENT_RESERVA,
                R.ERROR_MESSAGES.INVENTARIO.MESSAGE_ERROR_DELETE_DOCUMENT_RESERVAS, doc);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public Item GetDataRollofromRC(string rc) 
        {
            //procedimento para buscar los datos de los rollos desde RC
            DataTable dt = new DataTable();
            try
            {
                dt = CommandSqlGenericDtOnePar(R.DATABASES.RITRAMA,R.SQL.QUERY_SQL.INVENTARIO.SQL_GETDATA_ROLLS_FROMRC,"",rc);
            }
            catch (Exception)
            {
                MessageBox.Show("Error al traer la informacion de los rollos para cambiar las ubicaiones");
            }
            Item item = new Item
            {
                Product_id = dt.Rows[0]["product_id"].ToString(),
                Product_name = dt.Rows[0]["product_name"].ToString(),
                Width = Convert.ToDecimal(dt.Rows[0]["width"]),
                Lenght = Convert.ToDecimal(dt.Rows[0]["large"]),
                Msi = Convert.ToDecimal(dt.Rows[0]["msi"]),
                Tipo = dt.Rows[0]["tipo"].ToString()
            };
            return item;
        }
        public bool SetDataUbicationToAlmacenFromRC(string tipo, string ubicacion, string rc) 
        {
            //procedimiento para guardar en base de datos la ubicacion desde el RC
            try
            {
                switch (tipo) 
                {
                    case "I":
                        CommandSqlGenericTreeParameters(R.DATABASES.RITRAMA,
                        R.SQL.QUERY_SQL.INVENTARIO.SQL_UPDATE_UBICATION_ROLLS_INIC, rc, ubicacion, "", false, "", 0);
                        break;
                    case "M":
                        CommandSqlGenericTreeParameters(R.DATABASES.RITRAMA,
                        R.SQL.QUERY_SQL.INVENTARIO.SQL_UPDATE_UBICATION_ROLLS_ORDEN, rc, ubicacion, "", false, "", 0);
                        break;
                }
                return true;
            }
            catch (Exception)
            {
                MessageBox.Show(R.ERROR_MESSAGES.INVENTARIO.MESSAGE_ERROR_UBICATION_FROMRC);
                return false;       
            }
        }
    }
}
