using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace RitramaAPP.Clases
{
    public class DespachosManager
    {
        readonly Conexion Micomm = new Conexion();
        readonly SqlDataAdapter dadespacho = new SqlDataAdapter();
        readonly SqlDataAdapter dacustomer = new SqlDataAdapter();
        readonly SqlDataAdapter davendor = new SqlDataAdapter();
        readonly SqlDataAdapter datransporte = new SqlDataAdapter();
        readonly SqlDataAdapter dachofer = new SqlDataAdapter();
        readonly SqlDataAdapter dacamion = new SqlDataAdapter();
        readonly SqlDataAdapter daitems = new SqlDataAdapter();
        readonly SqlDataAdapter daproducto = new SqlDataAdapter();
        readonly DataTable dtdespacho = new DataTable();
        readonly DataTable dtcustomer = new DataTable();
        readonly DataTable dtvendor = new DataTable();
        private readonly DataTable dttransporte = new DataTable();
        readonly DataTable dtchofer = new DataTable();
        readonly DataTable dtcamion = new DataTable();
        readonly DataTable dtitems = new DataTable();
        readonly DataTable dtproducto = new DataTable();
        public DataSet ds = new DataSet();
        public DespachosManager()
        {
            GetProducto();
            GetDespachos();
            GetCustomers();
            GetVendedores();
            GetTransporte();
            Getchofer();
            GetCamion();
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
        public Boolean CommandSqlGenericTwoParameter(string db, string query, string par1,int par2, Boolean msg, string messagerror)
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
                SqlParameter p1 = new SqlParameter("@p1", par1);
                SqlParameter p2 = new SqlParameter("@p2", par2);
                comando.Parameters.Add(@p1);
                comando.Parameters.Add(@p2);
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
        public void UpdateUniqueCode(string unique_code,string tipo_mov)
        {
            switch (tipo_mov) 
            {
                case "M":
                    CommandSqlGenericOneParameter(R.SQL.DATABASE.NAME, R.SQL.QUERY_SQL.DESPACHOS.SQL_UPDATE_UNIQUE_CODE_FALSE,
                    unique_code, false, R.ERROR_MESSAGES.DESPACHOS.MESSAGE_UPDATE_UNIQUECODE_DISPOFALSE);
                    break;
                case "I":
                    CommandSqlGenericOneParameter(R.SQL.DATABASE.NAME, R.SQL.QUERY_SQL.DESPACHOS.SQL_UPDATE_UNIQUE_CODE_FALSE_INITIAL,
                    unique_code, false, R.ERROR_MESSAGES.DESPACHOS.MESSAGE_UPDATE_UNIQUECODE_DISPOFALSE);
                    break;
            }
        }
        public void UpdateInventoryGraphics(string ID, string tipo_mov) 
        {
            switch (tipo_mov) 
            {
                case "M":
                   CommandSqlGenericOneParameter(R.SQL.DATABASE.NAME, 
                   R.SQL.QUERY_SQL.DESPACHOS.SQL_UPDATE_GRAPHICS_MOV_DISPOFALSE,
                   ID, false, R.ERROR_MESSAGES.DESPACHOS.MESSAGE_UPDATE_graphics);
                   break;
                   
                case "I":
                   CommandSqlGenericOneParameter(R.SQL.DATABASE.NAME,
                   R.SQL.QUERY_SQL.DESPACHOS.SQL_UPDATE_GRAPHICS_INI_DISPOFALSE,
                   ID, false, R.ERROR_MESSAGES.DESPACHOS.MESSAGE_UPDATE_graphics);
                   break;
            }
        }
        public void UpdateInventoryHojas(string ID,string tipo_mov,int cant_hojas,int cant_despacho) 
        {
            switch (tipo_mov) 
            {
                case "M":
                    if (cant_hojas == cant_despacho)
                    {
                        //despacho total.
                        CommandSqlGenericTwoParameter(R.SQL.DATABASE.NAME, 
                            R.SQL.QUERY_SQL.DESPACHOS.SQL_UPDATE_INVENTORY_HOJAS_MOVIM_COMPLETE,
                    ID, cant_despacho, false, R.ERROR_MESSAGES.DESPACHOS.MESSAGE_UPDATE_UNIQUECODE_DISPOFALSE);
                    }
                    else 
                    {
                        //despacho parcial.
                        CommandSqlGenericTwoParameter(R.SQL.DATABASE.NAME, 
                            R.SQL.QUERY_SQL.DESPACHOS.SQL_UPDATE_INVENTORY_HOJAS_MOVIM_PARCIAL,
                    ID, cant_despacho, false, R.ERROR_MESSAGES.DESPACHOS.MESSAGE_UPDATE_UNIQUECODE_DISPOFALSE);
                    }
                    
                    break;
                case "I":
                    if (cant_hojas == cant_despacho)
                    {
                        //despacho total.
                        CommandSqlGenericTwoParameter(R.SQL.DATABASE.NAME,
                            R.SQL.QUERY_SQL.DESPACHOS.SQL_UPDATE_INVENTORY_HOJAS_COMPLETE_INITIAL,
                    ID, cant_despacho, false, R.ERROR_MESSAGES.DESPACHOS.MESSAGE_UPDATE_UNIQUECODE_DISPOFALSE);
                    }
                    else
                    {
                        //despacho parcial.
                        CommandSqlGenericTwoParameter(R.SQL.DATABASE.NAME,
                            R.SQL.QUERY_SQL.DESPACHOS.SQL_UPDATE_INVENTORY_HOJAS_PARCIAL_INITIAL,
                    ID, cant_despacho, false, R.ERROR_MESSAGES.DESPACHOS.MESSAGE_UPDATE_UNIQUECODE_DISPOFALSE);
                    }



                    break;
            }
        }
        public void Add(ClassDespacho datos, Boolean ismessage)
        {
            //ADD HEADER DE ORDEN DE PRODUCCION A LA BASE DE DATOS.
            CommandSqlGeneric(R.SQL.DATABASE.NAME,
            R.SQL.QUERY_SQL.DESPACHOS.SQL_INSERT_HEADER_ORDEN_DESPACHO, SetParametersAddHeaderDespacho(datos),
            ismessage, R.ERROR_MESSAGES.DESPACHOS.MESSAGE_INSERT_ERROR_ADD_HEADER_DESPACHOS);

            //ADD ITEMS-DETAILS DE ORDEN DE PRODUCCION A LA BASE DE DATOS.
            foreach (Items_despacho item in datos.items)
            {
                CommandSqlGeneric(R.SQL.DATABASE.NAME, R.SQL.QUERY_SQL.DESPACHOS.SQL_INSERT_HEADER_DETAILS_DESPACHO,
                SetParametersAddDetailsDespacho(item, datos.Numero), ismessage,
                R.ERROR_MESSAGES.DESPACHOS.MESSAGE_INSERT_ERROR_ADD_DETAILS_DESPACHOS);
            }
        }
        public void AddRC(List<Roll_Details> datos, string numero)
        {
            foreach (Roll_Details item in datos)
            {
                CommandSqlGeneric(R.SQL.DATABASE.NAME, R.SQL.QUERY_SQL.DESPACHOS.SQL_INSERT_UNIQUECODE_LIST_DESPACHO,
                SetParametersAddRCDespacho(item, numero), false, R.ERROR_MESSAGES.DESPACHOS.MESSAGE_INSERT_UNIQUECODE_ADD_DETAILS_DESPACHOS);
            }
        }
        public List<SqlParameter> SetParametersAddDetailsDespacho(Items_despacho datos, string numero)
        {
            List<SqlParameter> sp = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName = "@p1", SqlDbType = SqlDbType.NVarChar, Value = numero},
                new SqlParameter() {ParameterName = "@p2", SqlDbType = SqlDbType.NVarChar, Value = datos.product_id},
                new SqlParameter() {ParameterName = "@p3", SqlDbType = SqlDbType.Decimal, Value = datos.cantidad},
                new SqlParameter() {ParameterName = "@p4", SqlDbType = SqlDbType.NVarChar, Value = datos.unidad},
                new SqlParameter() {ParameterName = "@p5", SqlDbType = SqlDbType.Decimal, Value = datos.width},
                new SqlParameter() {ParameterName = "@p6", SqlDbType = SqlDbType.Decimal, Value = datos.lenght},
                new SqlParameter() {ParameterName = "@p7", SqlDbType = SqlDbType.Decimal, Value = datos.msi},
                new SqlParameter() {ParameterName = "@p8", SqlDbType = SqlDbType.Decimal, Value = datos.ratio},
                new SqlParameter() {ParameterName = "@p9", SqlDbType = SqlDbType.Decimal, Value = datos.kilo_rollo},
                new SqlParameter() {ParameterName = "@p10", SqlDbType = SqlDbType.Decimal, Value = datos.precio},
                new SqlParameter() {ParameterName = "@p11", SqlDbType = SqlDbType.Decimal, Value = datos.subtotal},
                new SqlParameter() {ParameterName = "@p12", SqlDbType = SqlDbType.Decimal, Value = datos.total_pie_lineal},
                new SqlParameter() {ParameterName = "@p13", SqlDbType = SqlDbType.Decimal, Value = datos.kilo_total}
            };
            return sp;
        }
        public List<SqlParameter> SetParametersAddHeaderDespacho(ClassDespacho datos)
        {
            List<SqlParameter> sp = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName = "@p1", SqlDbType = SqlDbType.NVarChar, Value = datos.Numero},
                new SqlParameter() {ParameterName = "@p2", SqlDbType = SqlDbType.DateTime, Value = datos.Fecha_despacho},
                new SqlParameter() {ParameterName = "@p3", SqlDbType = SqlDbType.NVarChar, Value = datos.Curstomer_id},
                new SqlParameter() {ParameterName = "@p4", SqlDbType = SqlDbType.NVarChar, Value = datos.Persona_entrega},
                new SqlParameter() {ParameterName = "@p5", SqlDbType = SqlDbType.NVarChar, Value = datos.Vendedor_id},
                new SqlParameter() {ParameterName = "@p6", SqlDbType = SqlDbType.NVarChar, Value = datos.Transport_id},
                new SqlParameter() {ParameterName = "@p7", SqlDbType = SqlDbType.NVarChar, Value = datos.Chofer_id},
                new SqlParameter() {ParameterName = "@p8", SqlDbType = SqlDbType.NVarChar, Value = datos.Placas_id},
                new SqlParameter() {ParameterName = "@p9", SqlDbType = SqlDbType.NVarChar, Value = datos.Tipo_embalaje},
                new SqlParameter() {ParameterName = "@p10", SqlDbType = SqlDbType.NVarChar, Value = datos.Orden_trabajo},
                new SqlParameter() {ParameterName = "@p11", SqlDbType = SqlDbType.NVarChar, Value = datos.Orden_compra},
                new SqlParameter() {ParameterName = "@p12", SqlDbType = SqlDbType.Decimal, Value = datos.Subtotal},
                new SqlParameter() {ParameterName = "@p13", SqlDbType = SqlDbType.Decimal, Value = datos.Monto_itbis},
                new SqlParameter() {ParameterName = "@p14", SqlDbType = SqlDbType.Decimal, Value = datos.Total},
            };
            return sp;
        }
        public List<SqlParameter> SetParametersAddRCDespacho(Roll_Details datos, string numero)
        {
            List<SqlParameter> sp = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName = "@p1", SqlDbType = SqlDbType.NVarChar, Value = numero},
                new SqlParameter() {ParameterName = "@p2", SqlDbType = SqlDbType.NVarChar, Value = datos.Unique_code},
                new SqlParameter() {ParameterName = "@p3", SqlDbType = SqlDbType.NVarChar, Value = datos.Product_id},
                new SqlParameter() {ParameterName = "@p4", SqlDbType = SqlDbType.Decimal, Value = datos.Width},
                new SqlParameter() {ParameterName = "@p5", SqlDbType = SqlDbType.Decimal, Value = datos.Large},
                new SqlParameter() {ParameterName = "@p6", SqlDbType = SqlDbType.Decimal, Value = datos.Msi},
                new SqlParameter() {ParameterName = "@p7", SqlDbType = SqlDbType.NVarChar, Value = datos.Roll_number},
                new SqlParameter() {ParameterName = "@p8", SqlDbType = SqlDbType.NVarChar, Value = datos.Roll_id},
                new SqlParameter() {ParameterName = "@p9", SqlDbType = SqlDbType.Int, Value = datos.Splice}
            };
            return sp;
        }
        public void GetProducto()
        {
            CommandSqlGenericUpdateDs(R.SQL.DATABASE.NAME, R.SQL.QUERY_SQL.DESPACHOS.SQL_SELECT_PRODUCTOS,
            daproducto, "dtproducto", R.ERROR_MESSAGES.DESPACHOS.MESSAGE_SELECT_ERROR_LOAD_PRODUCTS);
        }
        public void Getchofer()
        {
            CommandSqlGenericUpdateDs(R.SQL.DATABASE.NAME, R.SQL.QUERY_SQL.DESPACHOS.SQL_SELECT_CHEFERES,
            dachofer, "dtchofer", R.ERROR_MESSAGES.DESPACHOS.MESSAGE_SELECT_ERROR_LOAD_CHOFERES);
        }
        private void GetCamion()
        {
            CommandSqlGenericUpdateDs(R.SQL.DATABASE.NAME, R.SQL.QUERY_SQL.DESPACHOS.SQL_SELECT_CAMION,
            dacamion, "dtcamion", R.ERROR_MESSAGES.DESPACHOS.MESSAGE_SELECT_ERROR_LOAD_CAMIONES);
        }
        private void GetTransporte()
        {
            CommandSqlGenericUpdateDs(R.SQL.DATABASE.NAME, R.SQL.QUERY_SQL.DESPACHOS.SQL_SELECT_TRANSPORTE,
            datransporte, "dttransporte", R.ERROR_MESSAGES.DESPACHOS.MESSAGE_SELECT_ERROR_LOAD_TRANSPORTE);
        }
        private void GetVendedores()
        {
            CommandSqlGenericUpdateDs(R.SQL.DATABASE.NAME, R.SQL.QUERY_SQL.DESPACHOS.SQL_SELECT_VENDEDORES,
            davendor, "dtvendor", R.ERROR_MESSAGES.DESPACHOS.MESSAGE_SELECT_ERROR_LOAD_VENDEDOR);
        }
        private void GetCustomers()
        {
            CommandSqlGenericUpdateDs(R.SQL.DATABASE.NAME, R.SQL.QUERY_SQL.DESPACHOS.SQL_SELECT_CUSTOMERS,
            dacustomer, "dtcustomer", R.ERROR_MESSAGES.DESPACHOS.MESSAGE_SELECT_ERROR_LOAD_CUSTOMERS);
        }
        public void GetDespachos()
        {
            //TABLA MASTER
            CommandSqlGenericUpdateDs(R.SQL.DATABASE.NAME, R.SQL.QUERY_SQL.DESPACHOS.SQL_SELECT_DESPACHOS_HEADER,
            dadespacho, "dtdespacho", R.ERROR_MESSAGES.DESPACHOS.MESSAGE_SELECT_ERROR_LOAD_HEADER_DESPACHOS);
            //TABLA DETAILS
            CommandSqlGenericUpdateDs(R.SQL.DATABASE.NAME, R.SQL.QUERY_SQL.DESPACHOS.SQL_SELECT_DESPACHOS_DETAILS,
            daitems, "dtitems", R.ERROR_MESSAGES.DESPACHOS.MESSAGE_SELECT_ERROR_LOAD_DETAILS_DESPACHOS);
        }
        public Boolean RelacionesDS()
        {
            try
            {
                //Relacion Maestro-detalle.
                DataColumn ParentCol0 = ds.Tables["dtdespacho"].Columns["numero"];
                DataColumn ChildCol0 = ds.Tables["dtitems"].Columns["numero"];
                DataRelation master_details = new DataRelation("FK_MASTER_DETAILS", ParentCol0, ChildCol0);
                ds.Relations.Add(master_details);
                //Relacion Despacho-Cliente.
                DataColumn ParentCol1 = ds.Tables["dtcustomer"].Columns["Customer_ID"];
                DataColumn ChildCol1 = ds.Tables["dtdespacho"].Columns["customer_id"];
                DataRelation despachos_cliente = new DataRelation("FK_DESPACHO_CLIENTE", ParentCol1, ChildCol1);
                ds.Relations.Add(despachos_cliente);
                ds.Tables["dtdespacho"].Columns.Add("customer_name",
                Type.GetType("System.String"), "parent(FK_DESPACHO_CLIENTE).customer_name");
                ds.Tables["dtdespacho"].Columns.Add("customer_dir",
               Type.GetType("System.String"), "parent(FK_DESPACHO_CLIENTE).customer_dir");
                //Relacion Despacho-Vendedor.
                DataColumn ParentCol2 = ds.Tables["dtvendor"].Columns["VENDOR_ID"];
                DataColumn ChildCol2 = ds.Tables["dtdespacho"].Columns["vendor_id"];
                DataRelation despachos_vendedor = new DataRelation("FK_DESPACHO_VENDEDOR", ParentCol2, ChildCol2);
                ds.Relations.Add(despachos_vendedor);
                ds.Tables["dtdespacho"].Columns.Add("vendor_name",
                Type.GetType("System.String"), "parent(FK_DESPACHO_VENDEDOR).vendor_name");
                //Relacion Despacho-transporte.
                DataColumn ParentCol3 = ds.Tables["dttransporte"].Columns["TRANSPORT_ID"];
                DataColumn ChildCol3 = ds.Tables["dtdespacho"].Columns["transport_id"];
                DataRelation despachos_transporte = new DataRelation("FK_DESPACHO_TRANSPORTE", ParentCol3, ChildCol3);
                ds.Relations.Add(despachos_transporte);
                ds.Tables["dtdespacho"].Columns.Add("transport_name",
                Type.GetType("System.String"), "parent(FK_DESPACHO_TRANSPORTE).transport_name");
                //Relacion Despacho-chofer.
                DataColumn ParentCol4 = ds.Tables["dtchofer"].Columns["CHOFER_ID"];
                DataColumn ChildCol4 = ds.Tables["dtdespacho"].Columns["CHOFER_ID"];
                DataRelation despachos_chofer = new DataRelation("FK_DESPACHO_CHOFER", ParentCol4, ChildCol4);
                ds.Relations.Add(despachos_chofer);
                ds.Tables["dtdespacho"].Columns.Add("chofer_name",
                Type.GetType("System.String"), "parent(FK_DESPACHO_CHOFER).chofer_name");
                //Relacion Despacho-camion.
                DataColumn ParentCol5 = ds.Tables["dtcamion"].Columns["PLACAS_ID"];
                DataColumn ChildCol5 = ds.Tables["dtdespacho"].Columns["PLACAS_ID"];
                DataRelation despachos_camion = new DataRelation("FK_DESPACHO_CAMION", ParentCol5, ChildCol5);
                ds.Relations.Add(despachos_camion);
                ds.Tables["dtdespacho"].Columns.Add("camion_name",
                Type.GetType("System.String"), "parent(FK_DESPACHO_CAMION).camion_name");
                //Relacion Detalle-productos.
                DataColumn ParentCol6 = ds.Tables["dtproducto"].Columns["PRODUCT_ID"];
                DataColumn ChildCol6 = ds.Tables["dtitems"].Columns["PRODUCT_ID"];
                DataRelation ITEMS_PRODUCTS = new DataRelation("FK_ITEMS_PRODUCTS", ParentCol6, ChildCol6);
                ds.Relations.Add(ITEMS_PRODUCTS);
                ds.Tables["dtitems"].Columns.Add("product_name",
                Type.GetType("System.String"), "parent(FK_ITEMS_PRODUCTS).product_name");
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("error al establecer las relaciones. error code:" + ex);
                return false;
            }
        }
        public string GetRatioProduct(string product_id)
        {
            Micomm.Conectar(R.SQL.DATABASE.NAME);
            SqlCommand comando = new SqlCommand
            {
                CommandType = CommandType.Text,
                CommandText = R.SQL.QUERY_SQL.DESPACHOS.SQL_QUERY_SELECT_GET_RATIO_PRODUCTS,
                Connection = Micomm.cnn
            };
            SqlParameter p1 = new SqlParameter("@p1", product_id);
            comando.Parameters.Add(p1);
            string ratio;
            try
            {
                ratio = comando.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al traer el valor del ratio de un producto...error code:" + ex);
                ratio = "vacio";
            }
            Micomm.Desconectar();
            comando.Dispose();
            return ratio;
        }
        public List<Roll_Details> GetDataUniqueCode(string conduce)
        {
            List<Roll_Details> lista = new List<Roll_Details>();

            try
            {
                Micomm.Conectar(R.SQL.DATABASE.NAME);
                SqlCommand comando = new SqlCommand
                {
                    Connection = Micomm.cnn,
                    CommandType = CommandType.Text,
                    CommandText = R.SQL.QUERY_SQL.DESPACHOS.SQL_SELECT_UNIQUECODE_DETAILS_DESPACHO
                };

                SqlParameter p1 = new SqlParameter("@p1", conduce);
                comando.Parameters.Add(p1);
                SqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    Roll_Details rollo = new Roll_Details
                    {
                        Product_id = reader.GetString(0),
                        Product_name = reader.GetString(1),
                        Roll_number = reader.GetInt32(2).ToString(),
                        Width = reader.GetDecimal(3),
                        Large = reader.GetDecimal(4),
                        Msi = reader.GetDecimal(5),
                        Splice = reader.GetInt32(6),
                        Roll_id = reader.GetString(7),
                        Code_Person = "",
                        Status = "",
                        Unique_code = reader.GetString(8)
                    };

                    lista.Add(rollo);


                }

                comando.Dispose();
                Micomm.Desconectar();
                return lista;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("error al tratar de leer los RC en el detalle del conduce (DESPACHO)..." + ex);
                return lista;
            }
        }
        public Boolean AddPalet(List<Paleta> lista) 
        {
            try
            {
                foreach (Paleta item in lista) 
                {
                    if (!string.IsNullOrEmpty(item.Medida) && !string.IsNullOrEmpty(item.Contenido))
                        
                    {
                        CommandSqlGeneric(R.DATABASES.RITRAMA, R.SQL.QUERY_SQL.DESPACHOS.SQL_INSERT_DATA_PALET_DESPACHO,
                            SetParametersAddDataPalet(item), false, "");
                    }
                    
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(R.ERROR_MESSAGES.DESPACHOS.MESSAGE_SELECT_ADDPALET + ex);
                return false;
            }

        }
        public List<SqlParameter> SetParametersAddDataPalet(Paleta datos)
        {
          
            List<SqlParameter> sp = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName = "@p1", SqlDbType = SqlDbType.NVarChar, Value = datos.Numero},
                new SqlParameter() {ParameterName = "@p2", SqlDbType = SqlDbType.NVarChar, Value = datos.Number_palet},
                new SqlParameter() {ParameterName = "@p3", SqlDbType = SqlDbType.NVarChar, Value = datos.Medida},
                new SqlParameter() {ParameterName = "@p4", SqlDbType = SqlDbType.NVarChar, Value = datos.Contenido},
                new SqlParameter() {ParameterName = "@p5", SqlDbType = SqlDbType.Decimal, Value = datos.Kilo_neto},
                new SqlParameter() {ParameterName = "@p6", SqlDbType = SqlDbType.Decimal, Value = datos.Kilo_bruto},
            };
            return sp;
        }
        public List<Paleta> GetDataPalet(string conduce) 
        {
            List<Paleta> lista = new List<Paleta>();
            try
            {
                Micomm.Conectar(R.SQL.DATABASE.NAME);
                SqlCommand comando = new SqlCommand
                {
                    Connection = Micomm.cnn,
                    CommandType = CommandType.Text,
                    CommandText = R.SQL.QUERY_SQL.DESPACHOS.SQL_SELECT_DATA_PALET_DESPACHO
                };
                SqlParameter p1 = new SqlParameter("@p1", conduce);
                comando.Parameters.Add(p1);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Paleta rollo = new Paleta
                    {
                        Number_palet = reader.GetString(0),
                        Medida = reader.GetString(1),
                        Contenido = reader.GetString(2),
                        Kilo_bruto = reader.GetDecimal(3),
                        Kilo_neto = reader.GetDecimal(4),
                        Numero = reader.GetString(5)
                    };
                    lista.Add(rollo);
                }
                comando.Dispose();
                Micomm.Desconectar();
                return lista;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(R.ERROR_MESSAGES.DESPACHOS.
                    MESSAGE_SELECT_GETDATAPALET + ex);
                return lista;
            }
        }
        public bool DeletePalet(string numero)
        {
            try
            {
                CommandSqlGenericOneParameter(R.DATABASES.RITRAMA, 
                R.SQL.QUERY_SQL.DESPACHOS.SQL_DELETE_DATA_PALET_DESPACHO,numero,false,"");
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
