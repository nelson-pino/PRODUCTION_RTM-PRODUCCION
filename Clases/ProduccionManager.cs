using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq.Expressions;
using System.Web.Services.Protocols;
using System.Windows.Forms;

namespace RitramaAPP.Clases
{
    public class ProduccionManager
    {
        readonly Conexion Micomm = new Conexion();
        public DataSet ds = new DataSet();
        readonly SqlDataAdapter daordenes = new SqlDataAdapter();
        readonly SqlDataAdapter darenglones = new SqlDataAdapter();
        readonly SqlDataAdapter daproducts = new SqlDataAdapter();
        readonly DataTable dtordenes = new DataTable();
        readonly DataTable dtrenglones = new DataTable();
        readonly DataTable dtproducts = new DataTable();
        public DataTable Dtrenglones => dtrenglones;
        public DataTable Dtproducts => dtproducts;
        public DataTable Dtordenes => dtordenes;
        public ProduccionManager()
        {
            CargarProducts();
            CargarOrdenes();
            RelacionesDS();
        }
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
        public Boolean CommandSqlGenericOneParameter(string db, string query, string par, Boolean msg, string messagerror)
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
                SqlParameter p1 = new SqlParameter("@p1", par);
                comando.Parameters.Add(@p1);
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
        public Boolean CommandSqlGenericTreeParameters(string db, string query, object par1, object par2, object par3, Boolean msg, string messagerror,int process)
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
        public Boolean CommandSqlGenericUpdateDs(string db, string query, SqlDataAdapter da, string dt, string messagefail)
        {
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
                da.Fill(ds, dt);
                comando.Dispose();
                Micomm.Desconectar();
                return true;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(messagefail + ex);
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
        public Boolean CargarOrdenes()
        {
            // encabeza de la orden de corte
            CommandSqlGenericUpdateDs(R.SQL.DATABASE.NAME, R.SQL.QUERY_SQL.PRODUCCION.SQL_SELECT_ORDEN_CORTE,
            daordenes, "dtordenes", R.ERROR_MESSAGES.PRODUCCION.MESSAGE_ADD_ORDEN_ERROR_FAIL_HEADER);

            //detalle de la orden de corte.
            CommandSqlGenericUpdateDs(R.SQL.DATABASE.NAME,
            R.SQL.QUERY_SQL.PRODUCCION.SQL_QUERY_SELECT_ROLLOS_CORTADOS, darenglones, "dtrenglones",
            R.ERROR_MESSAGES.PRODUCCION.MESSAGE_LOAD_ROLLOS_CORTADOS_ERROR_FAIL);

            return true;

        }
        public DataTable LoadRolls()
        {
            // SELECT DE ROLLS CORTADOS SOLAMENTE PARA LOS INICIALES.
            return CommandSqlGenericDt(R.SQL.DATABASE.NAME,
            R.SQL.QUERY_SQL.PRODUCCION.SQL_QUERY_SELECT_ROLLOS_CORTADOS_INIC,
            R.ERROR_MESSAGES.PRODUCCION.MESSAGE_LOAD_ROLLOS_CORTADOS_ERROR_FAIL);
        }
        public void Update_Inventario_Master(string rollid, Double wid, Double len, string tipomov,Boolean ItemEmpty)
        {
            switch (tipomov)
            {
                case "M":
                    CommandSqlGeneric(R.SQL.DATABASE.NAME, R.SQL.QUERY_SQL.PRODUCCION.
                    SQL_UPDATE_INVENTARIO_MASTER, SetParametersUpdateinventarioMaster(rollid, wid, len), false,
                    R.ERROR_MESSAGES.PRODUCCION.MESSAGE_UPDATE_INVENTARIO_MASTER);

                    if (ItemEmpty) 
                    {
                        UpdateRollId(rollid, tipomov);
                    }
                    break;
                case "I":
                    CommandSqlGeneric(R.SQL.DATABASE.NAME, R.SQL.QUERY_SQL.PRODUCCION.
                        SQL_UPDATE_INVENTARIO_MASTER_WITH_INITIAL,
                        SetParametersUpdateinventarioMaster(rollid, wid, len), false,
                    R.ERROR_MESSAGES.PRODUCCION.MESSAGE_UPDATE_INVENTARIO_MASTER);

                    if (ItemEmpty)
                    {
                        UpdateRollId(rollid, tipomov);
                    }
                    break;
            }
        }
        public void UpdateRollId(string numberRollId, string tipomov)
        {
            switch (tipomov) 
            {
                case "M":
                    CommandSqlGenericOneParameter(R.SQL.DATABASE.NAME,
                    R.SQL.QUERY_SQL.PRODUCCION.SQL_QUERY_UPDATE_ROLLID_DISPONIBILIDAD,
                    numberRollId, false, R.ERROR_MESSAGES.PRODUCCION.MESSAGE_UPDATE_ERROR_UPDATE_ROLLID);
                    break;
                case "I":
                    CommandSqlGenericOneParameter(R.SQL.DATABASE.NAME,
                    R.SQL.QUERY_SQL.PRODUCCION.SQL_QUERY_UPDATE_ROLLID_DISPONIBILIDAD_INITIAL,
                    numberRollId, false, R.ERROR_MESSAGES.PRODUCCION.MESSAGE_UPDATE_ERROR_UPDATE_ROLLID);
                    break;
            }
        }
        public void UPDATE_INVENTARIO_RC(string rc, Double wid, Double len)
        {
            CommandSqlGeneric(R.SQL.DATABASE.NAME, R.SQL.QUERY_SQL.PRODUCCION.SQL_UPDATE_INVENTARIO_RC
                    , SetParametersUpdateinventarioRc(rc, wid, len), false,
                    R.ERROR_MESSAGES.PRODUCCION.MESSAGE_UPDATE_INVENTARIO_MASTER);
        }
        public void CargarProducts()
        {
            CommandSqlGenericUpdateDs(R.SQL.DATABASE.NAME, R.SQL.QUERY_SQL.PRODUCTS.SQL_QUERY_SELECT_PRODUCT_ALL,
                    daproducts, "dtproducts", R.ERROR_MESSAGES.MODULO_PRODUCTOS.MESSAGE_SELECT_LOADPRODUCTOS_FAIL);
        }
        public DataTable CargarRollsId()
        {
            return CommandSqlGenericDt(R.SQL.DATABASE.NAME, R.SQL.QUERY_SQL.PRODUCCION.SQL_QUERY_SELECT_ROLLID,
                R.ERROR_MESSAGES.PRODUCCION.MESSAGE_LOAD_ROLLID_ERROR_FAIL);
        }
        public DataTable CargarDataCortes(string orden)
        {
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            try
            {

                Micomm.Conectar(R.SQL.DATABASE.NAME);
                SqlCommand comando = new SqlCommand
                {
                    Connection = Micomm.cnn,
                    CommandType = CommandType.Text,
                    CommandText = R.SQL.QUERY_SQL.PRODUCCION.SQL_QUERY_SELECT_ITEMS_CORTES
                };
                SqlParameter p1 = new SqlParameter("@p1", orden);
                comando.Parameters.Add(p1);
                comando.ExecuteNonQuery();
                da.SelectCommand = comando;
                da.Fill(dt);
                comando.Dispose();
                Micomm.Desconectar();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(R.ERROR_MESSAGES.PRODUCCION.MESSAGE_SELECT_ITEMS_CORTES + ex);
            }
            da.Dispose();
            return dt;
        }
        public void Add(Orden datos, Boolean ismessage)
        {
            //ADD HEADER DE ORDEN DE PRODUCCION A LA BASE DE DATOS.
            CommandSqlGeneric(R.SQL.DATABASE.NAME,
            R.SQL.QUERY_SQL.PRODUCCION.SQL_QUERY_INSERT_MASTER_OC, SetParametersAddHeaderOrden(datos),
            ismessage, R.ERROR_MESSAGES.PRODUCCION.MESSAGE_ADD_ORDEN_ERROR_FAIL_HEADER);
            //ADD ITEMS-DETAILS DE ORDEN DE PRODUCCION A LA BASE DE DATOS.
            foreach (Roll_Details item in datos.rollos)
            {
                CommandSqlGeneric(R.SQL.DATABASE.NAME, R.SQL.QUERY_SQL.PRODUCCION.SQL_QUERY_INSERT_DETAILS_OC,
                SetParametersAddOrdenDetails(item), ismessage,
                R.ERROR_MESSAGES.PRODUCCION.MESSAGE_ADD_ORDEN_ERROR_FAIL_DETAILS);
            }
            //ADD ITEM CORTES.
            foreach (Corte item in datos.Cortes)
            {
                item.Orden = datos.Numero;
                CommandSqlGeneric(R.SQL.DATABASE.NAME, R.SQL.QUERY_SQL.PRODUCCION.SQL_QUERY_INSERT_ITEMS_CORTES,
                SetParametersItemsCortes(item), ismessage,
                R.ERROR_MESSAGES.PRODUCCION.MESSAGE_ADD_ITEMS_CORTES);
            }
        }
        public void AddRolls(Orden datos, Boolean ismessage)
        {
            //ADD ITEMS-DETAILS DE ORDEN DE PRODUCCION A LA BASE DE DATOS.
            foreach (Roll_Details item in datos.rollos)
            {
                CommandSqlGeneric(R.SQL.DATABASE.NAME, R.SQL.QUERY_SQL.PRODUCCION.SQL_QUERY_INSERT_ROLL_INIC,
                SetParametersAddOrdenDetails(item), ismessage,
                R.ERROR_MESSAGES.PRODUCCION.MESSAGE_ADD_ORDEN_ERROR_FAIL_ROLLS_INIC);
            }
        }
        public void Update_INSERT(Orden datos, Boolean ismessage)
        {
            //ACTUALIZAR HEADER DE ORDEN DE PRODUCCION.
            CommandSqlGeneric(R.SQL.DATABASE.NAME,
            R.SQL.QUERY_SQL.PRODUCCION.SQL_QUERY_UPDATE_ORDEN_PRODUCCION, SetParametersUpdateHeaderOrden(datos),
            ismessage, R.ERROR_MESSAGES.PRODUCCION.MESSAGE_UPDATE__ERROR_HEADER);
            //INSERTA NUEVO RENGLONES EN CAMBIO Q CAMBIE LA DATA DE LA ORDEN ITEMS-DETAILS DE ORDEN DE PRODUCCION A LA BASE DE DATOS.
            foreach (Roll_Details item in datos.rollos)
            {
                CommandSqlGeneric(R.SQL.DATABASE.NAME, R.SQL.QUERY_SQL.PRODUCCION.SQL_QUERY_INSERT_DETAILS_OC,
                SetParametersAddOrdenDetails(item), ismessage,
                R.ERROR_MESSAGES.PRODUCCION.MESSAGE_ADD_ORDEN_ERROR_FAIL_DETAILS);
            }
        }
        public void Update_Only(Orden datos, Boolean ismessage)
        {
            //ACTUALIZAR HEADER DE ORDEN DE PRODUCCION.
            CommandSqlGeneric(R.SQL.DATABASE.NAME,
            R.SQL.QUERY_SQL.PRODUCCION.SQL_QUERY_UPDATE_ORDEN_PRODUCCION, SetParametersUpdateHeaderOrden(datos),
            ismessage, R.ERROR_MESSAGES.PRODUCCION.MESSAGE_UPDATE__ERROR_HEADER);

            //INSERTA NUEVO RENGLONES EN CAMBIO Q CAMBIE LA DATA DE LA ORDEN ITEMS-DETAILS DE ORDEN DE PRODUCCION A LA BASE DE DATOS.
            foreach (Roll_Details item in datos.rollos)
            {
                CommandSqlGeneric(R.SQL.DATABASE.NAME, R.SQL.QUERY_SQL.PRODUCCION.SQL_QUERY_UPDATE_ROLLSDETAILS_RENGLON,
                SetParametersUpdateOrdenDetails(item), ismessage,
                R.ERROR_MESSAGES.PRODUCCION.MESSAGE_UPDATE_ERROR_ORDER_ROLLSDETAIL);
            }
        }
        public Boolean SaveDataDetailsRolls(List<Roll_Details> rollos)
        {
            SqlTransaction transac = null;
            try
            {
                using (Micomm.cnn)
                {
                    Micomm.Conectar(R.SQL.DATABASE.NAME);
                    transac = Micomm.cnn.BeginTransaction();
                    using (SqlCommand comando = new SqlCommand
                    {
                        Transaction = transac,
                        CommandType = CommandType.Text,
                        CommandText = R.SQL.QUERY_SQL.PRODUCCION.SQL_QUERY_INSERT_ROLLID,
                        Connection = Micomm.cnn
                    })
                    {
                        SqlParameter r1 = new SqlParameter
                        {
                            ParameterName = "@r1"
                        };
                        SqlParameter r2 = new SqlParameter
                        {
                            ParameterName = "@r2"
                        };
                        SqlParameter r3 = new SqlParameter
                        {
                            ParameterName = "@r3"
                        };
                        SqlParameter r4 = new SqlParameter
                        {
                            ParameterName = "@r4"
                        };
                        SqlParameter r5 = new SqlParameter
                        {
                            ParameterName = "@r5"
                        };
                        SqlParameter r6 = new SqlParameter
                        {
                            ParameterName = "@r6"
                        };
                        SqlParameter r7 = new SqlParameter
                        {
                            ParameterName = "@r7"
                        };
                        SqlParameter r8 = new SqlParameter
                        {
                            ParameterName = "@r8"
                        };
                        SqlParameter r9 = new SqlParameter
                        {
                            ParameterName = "@r9"
                        };
                        SqlParameter r10 = new SqlParameter
                        {
                            ParameterName = "@r10"
                        };
                        SqlParameter r11 = new SqlParameter
                        {
                            ParameterName = "@r11"
                        };
                        SqlParameter r12 = new SqlParameter
                        {
                            ParameterName = "@r12"
                        };
                        comando.Parameters.Add(r1);
                        comando.Parameters.Add(r2);
                        comando.Parameters.Add(r3);
                        comando.Parameters.Add(r4);
                        comando.Parameters.Add(r5);
                        comando.Parameters.Add(r6);
                        comando.Parameters.Add(r7);
                        comando.Parameters.Add(r8);
                        comando.Parameters.Add(r9);
                        comando.Parameters.Add(r10);
                        comando.Parameters.Add(r11);
                        comando.Parameters.Add(r12);
                        foreach (Roll_Details item in rollos)
                        {
                            r1.Value = item.Fecha;
                            r2.Value = item.Numero_Orden;
                            r3.Value = item.Roll_number;
                            r4.Value = item.Product_id;
                            r5.Value = item.Product_name;
                            r6.Value = item.Roll_id;
                            r7.Value = item.Width;
                            r8.Value = item.Large;
                            r9.Value = item.Msi;
                            r10.Value = item.Splice;
                            r11.Value = item.Code_Person;
                            r12.Value = item.Unique_code;
                            comando.ExecuteNonQuery();
                        }
                    }
                    //Ejecucion del Commit
                    transac.Commit();
                    MessageBox.Show("Se guardaron los datos correctamente de la orden de corte.");
                    return true;
                }
            }
            catch (SqlException ex)
            {
                transac.Rollback();
                MessageBox.Show("Error al grabar el detalle de los rollos cortados...error->code: " + ex);
                return false;
            }
        }
        public Boolean RelacionesDS()
        {
            try
            {
                //Relacion Maestro-producto.
                DataColumn ParentCol1 = ds.Tables["dtproducts"].Columns["product_id"];
                DataColumn ChildCol1 = ds.Tables["dtordenes"].Columns["product_id"];
                DataRelation orden_products = new DataRelation("FK_ORDENES_PRODUCTO", ParentCol1, ChildCol1);
                ds.Relations.Add(orden_products);
                ds.Tables["dtordenes"].Columns.Add("product_name",
                Type.GetType("System.String"), "parent(FK_ORDENES_PRODUCTO).product_name");
                //Relacion MASTER-DETAILS.
                DataColumn ParentCol2 = ds.Tables["dtordenes"].Columns["numero"];
                DataColumn ChildCol2 = ds.Tables["dtrenglones"].Columns["numero"];
                DataRelation orden_details = new DataRelation("FK_ORDEN_DETAILS", ParentCol2, ChildCol2);
                ds.Relations.Add(orden_details);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al tratar de establecer las relaciones entre tablas. Error Code:" + ex);
                return false;
            }
        }
        private List<SqlParameter> SetParametersItemsCortes(Corte item)
        {
            List<SqlParameter> sp = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName = "@p1", SqlDbType = SqlDbType.Int, Value = item.Num},
                new SqlParameter() {ParameterName = "@p2", SqlDbType = SqlDbType.Decimal, Value = item.Width},
                new SqlParameter() {ParameterName = "@p3", SqlDbType = SqlDbType.Decimal, Value = item.Lenght},
                new SqlParameter() {ParameterName = "@p4", SqlDbType = SqlDbType.Decimal, Value = item.Msi},
                new SqlParameter() {ParameterName = "@p5", SqlDbType = SqlDbType.Decimal, Value = item.Orden},
            };
            return sp;
        }
        public List<SqlParameter> SetParametersAddHeaderOrden(Orden datos)
        {
            List<SqlParameter> sp = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName = "@p1", SqlDbType = SqlDbType.NVarChar, Value = datos.Numero},
                new SqlParameter() {ParameterName = "@p2", SqlDbType = SqlDbType.DateTime, Value = datos.Fecha},
                new SqlParameter() {ParameterName = "@p3", SqlDbType = SqlDbType.DateTime, Value = datos.Fecha_produccion},
                new SqlParameter() {ParameterName = "@p4", SqlDbType = SqlDbType.NVarChar, Value = datos.Product_id},
                new SqlParameter() {ParameterName = "@p5", SqlDbType = SqlDbType.NVarChar, Value = datos.Rollid_1},
                new SqlParameter() {ParameterName = "@p6", SqlDbType = SqlDbType.Decimal, Value = datos.Width_1},
                new SqlParameter() {ParameterName = "@p7", SqlDbType = SqlDbType.Decimal, Value = datos.Lenght_1},
                new SqlParameter() {ParameterName = "@p8", SqlDbType = SqlDbType.NVarChar, Value = datos.Rollid_2},
                new SqlParameter() {ParameterName = "@p9", SqlDbType = SqlDbType.Decimal, Value = datos.Width_2},
                new SqlParameter() {ParameterName = "@p10", SqlDbType = SqlDbType.Decimal, Value = datos.Lenght_2},
                new SqlParameter() {ParameterName = "@p11", SqlDbType = SqlDbType.Bit, Value = datos.Anulada},
                new SqlParameter() {ParameterName = "@p12", SqlDbType = SqlDbType.Bit, Value = datos.Procesado},
                new SqlParameter() {ParameterName = "@p13", SqlDbType = SqlDbType.Decimal, Value = datos.Inch_Ancho},
                new SqlParameter() {ParameterName = "@p14", SqlDbType = SqlDbType.Decimal, Value = datos.Longitud_Cortar},
                new SqlParameter() {ParameterName = "@p15", SqlDbType = SqlDbType.Int, Value = datos.Cortes_Ancho},
                new SqlParameter() {ParameterName = "@p16", SqlDbType = SqlDbType.Int, Value = datos.Cortes_Largo},
                new SqlParameter() {ParameterName = "@p17", SqlDbType = SqlDbType.Int, Value = datos.Cantidad_Rollos},
                new SqlParameter() {ParameterName = "@p18", SqlDbType = SqlDbType.Decimal, Value = datos.Descartable1_pies},
                new SqlParameter() {ParameterName = "@p19", SqlDbType = SqlDbType.Decimal, Value = datos.Master_lenght1_Real},
                new SqlParameter() {ParameterName = "@p20", SqlDbType = SqlDbType.Decimal, Value = datos.Util1_Real_Width},
                new SqlParameter() {ParameterName = "@p21", SqlDbType = SqlDbType.Decimal, Value = datos.Util1_real_Lenght},
                new SqlParameter() {ParameterName = "@p22", SqlDbType = SqlDbType.Decimal, Value = datos.Rest1_width},
                new SqlParameter() {ParameterName = "@p23", SqlDbType = SqlDbType.Decimal, Value = datos.Rest1_lenght},
                new SqlParameter() {ParameterName = "@p24", SqlDbType = SqlDbType.Decimal, Value = datos.Descartable2_pies},
                new SqlParameter() {ParameterName = "@p25", SqlDbType = SqlDbType.Decimal, Value = datos.Master_lenght2_Real},
                new SqlParameter() {ParameterName = "@p26", SqlDbType = SqlDbType.Decimal, Value = datos.Util2_Real_Width},
                new SqlParameter() {ParameterName = "@p27", SqlDbType = SqlDbType.Decimal, Value = datos.Util2_real_Lenght},
                new SqlParameter() {ParameterName = "@p28", SqlDbType = SqlDbType.Decimal, Value = datos.Rest2_width},
                new SqlParameter() {ParameterName = "@p29", SqlDbType = SqlDbType.Decimal, Value = datos.Rest2_lenght},
                new SqlParameter() {ParameterName = "@p30", SqlDbType = SqlDbType.Int, Value = datos.Cortes_Largo2},
                new SqlParameter() {ParameterName = "@p31", SqlDbType = SqlDbType.Int, Value = datos.Cantidad_Rollos2},
                new SqlParameter() {ParameterName = "@p32", SqlDbType = SqlDbType.NChar, Value = datos.Tipo_Mov1},
                new SqlParameter() {ParameterName = "@p33", SqlDbType = SqlDbType.NChar, Value = datos.Tipo_Mov2}

            };
            return sp;
        }
        public List<SqlParameter> SetParametersAddOrdenDetails(Roll_Details datos)
        {
            List<SqlParameter> sp = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName = "@p1", SqlDbType = SqlDbType.NVarChar, Value = datos.Numero_Orden},
                new SqlParameter() {ParameterName = "@p2", SqlDbType = SqlDbType.NVarChar, Value = datos.Product_id},
                new SqlParameter() {ParameterName = "@p3", SqlDbType = SqlDbType.NVarChar, Value = datos.Product_name},
                new SqlParameter() {ParameterName = "@p4", SqlDbType = SqlDbType.NVarChar, Value = datos.Roll_number},
                new SqlParameter() {ParameterName = "@p5", SqlDbType = SqlDbType.NVarChar, Value = datos.Unique_code},
                new SqlParameter() {ParameterName = "@p6", SqlDbType = SqlDbType.Int, Value = datos.Splice},
                new SqlParameter() {ParameterName = "@p7", SqlDbType = SqlDbType.Decimal, Value = datos.Width},
                new SqlParameter() {ParameterName = "@p8", SqlDbType = SqlDbType.Decimal, Value = datos.Large},
                new SqlParameter() {ParameterName = "@p9", SqlDbType = SqlDbType.Decimal, Value = datos.Msi},
                new SqlParameter() {ParameterName = "@p10", SqlDbType = SqlDbType.NVarChar, Value = datos.Roll_id},
                new SqlParameter() {ParameterName = "@p11", SqlDbType = SqlDbType.NVarChar, Value = datos.Code_Person},
                new SqlParameter() {ParameterName = "@p12", SqlDbType = SqlDbType.NVarChar, Value = datos.Status},
                new SqlParameter() {ParameterName = "@p13", SqlDbType = SqlDbType.Bit, Value = datos.Disponible}
            };
            return sp;
        }
        public List<SqlParameter> SetParametersUpdateOrdenDetails(Roll_Details datos)
        {
            List<SqlParameter> sp = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName = "@p1", SqlDbType = SqlDbType.NVarChar, Value = datos.Numero_Orden},
                new SqlParameter() {ParameterName = "@p2", SqlDbType = SqlDbType.NVarChar, Value = datos.Unique_code},
                new SqlParameter() {ParameterName = "@p3", SqlDbType = SqlDbType.Int, Value = datos.Splice},
                new SqlParameter() {ParameterName = "@p4", SqlDbType = SqlDbType.NVarChar, Value = datos.Code_Person},
                new SqlParameter() {ParameterName = "@p5", SqlDbType = SqlDbType.NVarChar, Value = datos.Status},
                new SqlParameter() {ParameterName = "@p6", SqlDbType = SqlDbType.Decimal, Value = datos.Width},
                new SqlParameter() {ParameterName = "@p7", SqlDbType = SqlDbType.Decimal, Value = datos.Large},
                new SqlParameter() {ParameterName = "@p8", SqlDbType = SqlDbType.Decimal, Value = datos.Msi},
                new SqlParameter() {ParameterName = "@p9", SqlDbType = SqlDbType.NVarChar, Value = datos.Roll_id},
                new SqlParameter() {ParameterName = "@p10", SqlDbType = SqlDbType.Bit, Value = datos.Disponible}
            };
            return sp;
        }
        public List<SqlParameter> SetParametersUpdateHeaderOrden(Orden datos)
        {
            List<SqlParameter> sp = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName = "@p1", SqlDbType = SqlDbType.NVarChar, Value = datos.Numero},
                new SqlParameter() {ParameterName = "@p2", SqlDbType = SqlDbType.DateTime, Value = datos.Fecha},
                new SqlParameter() {ParameterName = "@p3", SqlDbType = SqlDbType.DateTime, Value = datos.Fecha_produccion},
                new SqlParameter() {ParameterName = "@p4", SqlDbType = SqlDbType.DateTime, Value = datos.LastUpdate},
                new SqlParameter() {ParameterName = "@p5", SqlDbType = SqlDbType.Int, Value = datos.STATE},


            };
            return sp;
        }
        public List<SqlParameter> SetParametersUpdateinventarioMaster(string rollid, double width_c, double lenght_c)
        {
            List<SqlParameter> sp = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName = "@p1", SqlDbType = SqlDbType.NVarChar, Value = rollid},
                new SqlParameter() {ParameterName = "@p2", SqlDbType = SqlDbType.Decimal, Value = width_c},
                new SqlParameter() {ParameterName = "@p3", SqlDbType = SqlDbType.Decimal, Value = lenght_c}
            };
            return sp;
        }
        public List<SqlParameter> SetParametersUpdateinventarioRc(string rc, double width_c, double lenght_c)
        {
            List<SqlParameter> sp = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName = "@p1", SqlDbType = SqlDbType.NVarChar, Value = rc},
                new SqlParameter() {ParameterName = "@p2", SqlDbType = SqlDbType.Decimal, Value = width_c},
                new SqlParameter() {ParameterName = "@p3", SqlDbType = SqlDbType.Decimal, Value = lenght_c}
            };
            return sp;
        }
        public void DeleteRollDetailsOrden(string numero)
        {
            CommandSqlGenericOneParameter(R.SQL.DATABASE.NAME, R.
                SQL.QUERY_SQL.PRODUCCION.SQL_QUERY_DELETE_ORDEN_ROLLDETAILS, numero, false,
                R.ERROR_MESSAGES.PRODUCCION.MESSAGE_DELETE_ORDER_ROLLSDETAIL);
        }
        public DataTable GetUniqueCodeToList()
        {
            return CommandSqlGenericDt(R.SQL.DATABASE.NAME, R.SQL.QUERY_SQL.
                PRODUCCION.SQL_QUERY_SELECT_UNIQUE_CODE_LIST,
                R.ERROR_MESSAGES.PRODUCCION.
                MESSAGE_SELECT_UNIQUE_CODE_TOLIST);
        }
        public Roll_Details GetDataUniqueCode(string rc)
        {
            Roll_Details rollo = new Roll_Details();
            try
            {
                Micomm.Conectar(R.SQL.DATABASE.NAME);
                SqlCommand comando = new SqlCommand
                {
                    Connection = Micomm.cnn,
                    CommandType = CommandType.Text,
                    CommandText = R.SQL.QUERY_SQL.PRODUCCION.SQL_QUERY_SELECT_GETDATA_UNIQUE_CODE
                };
                SqlParameter p1 = new SqlParameter("@p1", rc);
                comando.Parameters.Add(p1);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    rollo.Product_id = reader.GetString(1);
                    rollo.Product_name = reader.GetString(2);
                    rollo.Roll_number = reader.GetInt32(3).ToString();
                    rollo.Width = reader.GetDecimal(4);
                    rollo.Large = reader.GetDecimal(5);
                    rollo.Msi = reader.GetDecimal(6);
                    rollo.Splice = reader.GetInt32(7);
                    rollo.Roll_id = reader.GetString(8);
                    rollo.Code_Person = reader.GetString(9);
                    rollo.Status = reader.GetString(10);
                    rollo.Unique_code = reader.GetString(11);
                    rollo.Tipo_mov = reader.GetString(12);
                }
                comando.Dispose();
                Micomm.Desconectar();
                return rollo;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("error al tratar de leer la data de un codigo unico..." + ex);
                return rollo;
            }
        }
        public string GetCodeRC(string product_id)
        {
            Micomm.Conectar(R.SQL.DATABASE.NAME);
            SqlCommand comando = new SqlCommand
            {
                CommandType = CommandType.Text,
                CommandText = R.SQL.QUERY_SQL.PRODUCCION.SQL_QUERY_SELECT_GETDATA_CODE_RC,
                Connection = Micomm.cnn
            };
            SqlParameter p1 = new SqlParameter("@p1", product_id);
            comando.Parameters.Add(p1);
            string coderc;
            try
            {
                coderc = comando.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los codigo RC de productos...error code:" + ex);
                coderc = "vacio";
            }
            Micomm.Desconectar();
            comando.Dispose();
            return coderc;
        }
        public void UpdateUniqueCode(string UniqueCode)
        {
            CommandSqlGenericOneParameter(R.SQL.DATABASE.NAME,
                   R.SQL.QUERY_SQL.PRODUCCION.SQL_QUERY_UPDATE_UNIQUE_CODE,
                   UniqueCode, false, R.ERROR_MESSAGES.PRODUCCION.MESSAGE_UPDATE_ERROR_UPDATE_UNIQUE_CODE);
        }
        public Boolean OrderExiste(int numero_oc)
        {
            int result;
            Micomm.Conectar(R.SQL.DATABASE.NAME);
            SqlCommand comando = new SqlCommand
            {
                CommandType = CommandType.Text,
                CommandText = R.SQL.QUERY_SQL.PRODUCCION.SQL_QUERY_SELECT_VERIFIFY_REPEAT_OC,
                Connection = Micomm.cnn
            };
            SqlParameter p1 = new SqlParameter("@p1", numero_oc);
            comando.Parameters.Add(p1);
            result = Convert.ToInt16(comando.ExecuteScalar());
            Micomm.Desconectar();
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
        public Boolean DeleteUniqueCode(string Unique_Code)
        {
            int result;
            Micomm.Conectar(R.SQL.DATABASE.NAME);
            SqlCommand comando = new SqlCommand
            {
                CommandType = CommandType.Text,
                CommandText = R.SQL.QUERY_SQL.PRODUCCION.SQL_QUERY_DELETE_UNIQUE_CODE,
                Connection = Micomm.cnn
            };
            SqlParameter p1 = new SqlParameter("@p1", Unique_Code);
            comando.Parameters.Add(p1);
            result = Convert.ToInt16(comando.ExecuteScalar());
            Micomm.Desconectar();
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
        public void ProcesarOrden(string orden)
        {
            CommandSqlGenericOneParameter(R.SQL.DATABASE.NAME,
                R.SQL.QUERY_SQL.PRODUCCION.SQL_QUERY_PROCESAR_ORDEN_OC, orden,
                false, R.ERROR_MESSAGES.PRODUCCION.MESSAGE_UPDATE_PROCESAR_ORDEN_OC);
        }
        public void AnularOrden(string orden)
        {
            CommandSqlGenericOneParameter(R.SQL.DATABASE.NAME,
                    R.SQL.QUERY_SQL.PRODUCCION.SQL_QUERY_ANULAR_ORDEN_OC, orden,
                    false, R.ERROR_MESSAGES.PRODUCCION.MESSAGE_UPDATE_ANULAR_ORDEN_OC);
        }
        public void AddRendim(List<SqlParameter> sp)
        {
            CommandSqlGeneric(R.SQL.DATABASE.NAME,
                R.SQL.QUERY_SQL.PRODUCCION.SQL_QUERY_ADD_DATOS_RENDIMIENTO_MASTER,
                sp, false, R.ERROR_MESSAGES.PRODUCCION.MESSAGE_ADD_RENDIM_MASTER);
        }
        public string[] GetDataRendimiento(string orden)
        {
            string[] data = new string[20];
            try
            {
                Micomm.Conectar(R.SQL.DATABASE.NAME);
                SqlCommand comando = new SqlCommand
                {
                    Connection = Micomm.cnn,
                    CommandType = CommandType.Text,
                    CommandText = R.SQL.QUERY_SQL.PRODUCCION.SQL_QUERY_SELECT_DATOS_RENDIMIENTO_MASTER
                };
                SqlParameter p1 = new SqlParameter("@p1", orden);
                comando.Parameters.Add(p1);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    data[0] = reader.GetDecimal(0).ToString();
                    data[1] = reader.GetDecimal(1).ToString();
                    data[2] = reader.GetDecimal(2).ToString();
                    data[3] = reader.GetDecimal(3).ToString();
                    data[4] = reader.GetDecimal(4).ToString();
                    data[5] = reader.GetDecimal(5).ToString();
                    data[6] = reader.GetDecimal(6).ToString();
                    data[7] = reader.GetDecimal(7).ToString();
                    data[8] = reader.GetDecimal(8).ToString();
                    data[9] = reader.GetString(9).ToString();
                    data[10] = reader.GetDecimal(10).ToString();
                    data[11] = reader.GetDecimal(11).ToString();
                    data[12] = reader.GetDecimal(12).ToString();
                    data[13] = reader.GetDecimal(13).ToString();
                    data[14] = reader.GetDecimal(14).ToString();
                    data[15] = reader.GetDecimal(15).ToString();
                    data[16] = reader.GetDecimal(16).ToString();
                    data[17] = reader.GetDecimal(17).ToString();
                    data[18] = reader.GetDecimal(18).ToString();
                    data[19] = reader.GetString(19).ToString();
                }
                comando.Dispose();
                Micomm.Desconectar();
                return data;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("error al tratar de cargar la data de los rendimiento de los master en produccion..." + ex);
                return data;
            }
        }
        public Boolean UpdateStateDocumentOC(string numero, int state, DateTime last_update) 
        {
            try
            {
                CommandSqlGenericTreeParameters(R.DATABASES.RITRAMA,
                R.SQL.QUERY_SQL.PRODUCCION.SQL_UPDATE_DOCUMENT_STATE,
                numero,state,last_update,false,"",1);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public Boolean UpdateDispoRollsDocumentOC(string numeroOC, bool state) 
        {
            try
            {
                CommandSqlGenericTreeParameters(R.DATABASES.RITRAMA, R.SQL.QUERY_SQL.PRODUCCION.SQL_UPDATE_DISPO_ROLLS_OC,
                numeroOC, state, DateTime.Now, false, "", 1);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public Boolean SaveAutorizeOc(AutorizeDocOc doc) 
        {
            try
            {
                CommandSqlGeneric(R.DATABASES.RITRAMA, 
                R.SQL.QUERY_SQL.PRODUCCION.SQL_UPDATE_AUTHORIZE_OC,
                SetParametersAutorizeOc(doc),false, 
                R.ERROR_MESSAGES.PRODUCCION.MESSAGE_ERROR_AUTHORIZE_OC);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        private List<SqlParameter> SetParametersAutorizeOc(AutorizeDocOc item)
        {
            List<SqlParameter> sp = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName = "@p1", SqlDbType = SqlDbType.NVarChar, Value = item.Oc},
                new SqlParameter() {ParameterName = "@p2", SqlDbType = SqlDbType.DateTime, Value = item.Fecha},
                new SqlParameter() {ParameterName = "@p3", SqlDbType = SqlDbType.NVarChar, Value = item.ToAutorize},
                new SqlParameter() {ParameterName = "@p4", SqlDbType = SqlDbType.Text, Value = item.Notes},
                new SqlParameter() {ParameterName = "@p5", SqlDbType = SqlDbType.Bit, Value = item.CloseDocument},
            };
            return sp;
        }
        public Boolean CheckMasterDocumentOc(string rollid) 
        {
            //Esta funcion verifica si un master esta montado en alguna Orden de Corte.
            try
            {
                int result;
                Micomm.Conectar(R.SQL.DATABASE.NAME);
                SqlCommand comando = new SqlCommand
                {
                    CommandType = CommandType.Text,
                    CommandText = R.SQL.QUERY_SQL.PRODUCCION.SQL_SELECT_CHECK_MASTER_DOCUMENT,
                    Connection = Micomm.cnn
                };
                SqlParameter p1 = new SqlParameter("@p1", rollid);
                comando.Parameters.Add(p1);
                result = Convert.ToInt16(comando.ExecuteScalar());
                Micomm.Desconectar();
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
            catch (Exception)
            {

                return false;
            }
        }
        public Boolean MarkMasterRollidLoadDocument(string tipomov, string rollid, string oc) 
        {
            try
            {
                switch (tipomov)
                {
                    case "M":
                        CommandSqlGenericTreeParameters(R.SQL.DATABASE.NAME, R.SQL.QUERY_SQL.PRODUCCION.
                        SQL_MARK_MASTER_RECEP, rollid, oc, true, false, "", 0);
                        break;
                    case "I":
                        CommandSqlGenericTreeParameters(R.SQL.DATABASE.NAME, R.SQL.QUERY_SQL.PRODUCCION.
                        SQL_MARK_MASTER_INIC, rollid, oc, true, false, "", 0);
                        break;
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
