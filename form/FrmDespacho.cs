using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using RitramaAPP.Clases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;


namespace RitramaAPP.form
{
    public partial class FrmDespacho : Form
    {
        public FrmDespacho()
        {
            InitializeComponent();
        } 
        readonly DespachosManager despachomanager = new DespachosManager();
        readonly ReportsManager reportManager = new ReportsManager();
        DataSet ds = new DataSet();
        readonly BindingSource bs = new BindingSource();
        readonly ConfigManager config = new ConfigManager();
        readonly BindingSource bsitem = new BindingSource();
        DataRowView ParentRow, ChildRows;
        int EditMode = 0, Consec = 0, UpdatePaleta = 0;
        readonly decimal PORC_ITBIS = 18;
        ClassDespacho despacho;
        readonly List<Roll_Details> listarc = new List<Roll_Details>();
        List<Paleta> ListPalet = new List<Paleta>();
        private void FrmDespacho_Load(object sender, EventArgs e)
        {
            AplicarEstilosGrid();
            ENLACE_DATOS();
            RefreshFormData();
        }
       
        #region DATOS_PICKING
        private void LoadPicking()
        {
            DeleteRowBlank();
            using (PickingList pl = new PickingList())
            {
                pl.ShowDialog();
                switch (pl.Action)
                {
                    case 0:
                        //pick de rolls
                        if (pl.List_products == null || pl.List_products.Count() == 0)
                        {
                            return;
                        }
                        FillFormDataCortados(pl);
                        break;
                    case 1:
                        //pick de hojas
                        if (pl.Lista_hojas == null || pl.Lista_hojas.Count() == 0)
                        {
                            return;
                        }
                        FillFormDataHojas(pl);
                        break;
                    case 2:
                        //pick de graphics
                        if (pl.Lista_graphics == null || pl.Lista_graphics.Count() == 0)
                        {
                            return;
                        }
                        FillFormDatagraphics(pl);
                        break;
                }
            }
        }
        private void FillFormDatagraphics(PickingList pl)
        {
            int row = grid_items.Rows.Count;
            int index = 0;
            foreach (ClassRecepcion item in pl.Lista_graphics)
            {
                AgregarRenglon();
                grid_items.Rows[row].Cells["product_id"].Value = pl.Lista_graphics.ElementAt(index).Part_Number;
                grid_items.Rows[row].Cells["cant"].Value = 1;
                grid_items.Rows[row].Cells["unidad"].Value = "graphics";
                grid_items.Rows[row].Cells["ancho"].Value = pl.Lista_graphics.ElementAt(index).Width;
                grid_items.Rows[row].Cells["largo"].Value = pl.Lista_graphics.ElementAt(index).Lenght;
                grid_items.Rows[row].Cells["msi"].Value = 0;
                grid_items.Rows[row].Cells["pie_lin"].Value = 0;
                grid_items.Rows[row].Cells["ratio"].Value = 0;
                grid_items.Rows[row].Cells["kilo_rollo"].Value = 0;
                grid_items.Rows[row].Cells["kilo_total"].Value = 0;
                grid_items.Rows[row].Cells["action"].Value = 2;
                row += 1;
                index += 1;
            }
            //llenar el grid de ID con los datos de las hojas.
            foreach (ClassRecepcion item in pl.Lista_graphics)
            {
                Roll_Details graphic = new Roll_Details
                {
                    Product_id = item.Part_Number,
                    Product_name = item.ProductName,
                    Roll_id = item.Roll_ID,
                    Roll_number = "0",
                    Code_Person = "0",
                    Unique_code = "0",
                    Tipo_pro = 2,
                    Cant_despacho = 1,
                    Cantidad = 1,
                    Tipo_mov = item.Tipo
                };
                listarc.Add(graphic);
            }
            grid_UniqueCode.DataSource = listarc.ToList();
        }
        private void FillFormDataCortados(PickingList pl)
        {
            int row = grid_items.Rows.Count;
            int index = 0;
            //llenar el grid de renglones desde la sincronizacion. 
            foreach (Producto item in pl.List_products)
            {
                AgregarRenglon();
                grid_items.Rows[row].Cells["product_id"].Value = pl.List_products.ElementAt(index).Product_id;
                grid_items.Rows[row].Cells["cant"].Value = pl.List_products.ElementAt(index).Product_quantity;
                grid_items.Rows[row].Cells["unidad"].Value = "rollo cortado.";
                grid_items.Rows[row].Cells["ancho"].Value = pl.List_products.ElementAt(index).Width;
                grid_items.Rows[row].Cells["largo"].Value = pl.List_products.ElementAt(index).Lenght;
                grid_items.Rows[row].Cells["msi"].Value = pl.List_products.ElementAt(index).Msi;
                grid_items.Rows[row].Cells["pie_lin"].Value = Convert.ToDouble(pl.List_products.ElementAt(index).Msi) *
                    Convert.ToDouble(pl.List_products.ElementAt(index).Product_quantity);
                grid_items.Rows[row].Cells["ratio"].Value = despachomanager
                    .GetRatioProduct(pl.List_products.ElementAt(index).Product_id);
                grid_items.Rows[row].Cells["kilo_rollo"].Value =
                    Convert.ToDouble(grid_items.Rows[row].Cells["msi"].Value) /
                    Convert.ToDouble(grid_items.Rows[row].Cells["ratio"].Value);

                grid_items.Rows[row].Cells["kilo_total"].Value =
                    Convert.ToDouble(grid_items.Rows[row].Cells["kilo_rollo"].Value) *
                    Convert.ToDouble(grid_items.Rows[row].Cells["cant"].Value);
                grid_items.Rows[row].Cells["action"].Value = 0;

                row += 1;
                index += 1;
            }
            //llenar el grid de unique_code.
            foreach (Roll_Details item in pl.Lista_rollos) 
            {
                listarc.Add(item);
            }
            grid_UniqueCode.DataSource = listarc.ToList();
        }
        private void FillFormDataHojas(PickingList pl)
        {
             int row = grid_items.Rows.Count;
            int index = 0;
            //llenar el grid de renglones desde la sincronizacion. 
            foreach (ClassRecepcion item in pl.Lista_hojas)
            {
                AgregarRenglon();
                grid_items.Rows[row].Cells["product_id"].Value = pl.Lista_hojas.ElementAt(index).Part_Number;
                grid_items.Rows[row].Cells["cant"].Value = pl.Lista_hojas.ElementAt(index).cant_despacho;
                grid_items.Rows[row].Cells["unidad"].Value = "hojas";
                grid_items.Rows[row].Cells["ancho"].Value = pl.Lista_hojas.ElementAt(index).Width;
                grid_items.Rows[row].Cells["largo"].Value = pl.Lista_hojas.ElementAt(index).Lenght;
                grid_items.Rows[row].Cells["msi"].Value = 0;
                grid_items.Rows[row].Cells["pie_lin"].Value = 0;
                grid_items.Rows[row].Cells["ratio"].Value = 0;
                grid_items.Rows[row].Cells["kilo_rollo"].Value = 0;
                grid_items.Rows[row].Cells["kilo_total"].Value = 0;
                grid_items.Rows[row].Cells["action"].Value = 1;
                row += 1;
                index += 1;
            }
            //llenar el grid de ID con los datos de las hojas.
            foreach (ClassRecepcion item in pl.Lista_hojas) 
            {
                Roll_Details hoja = new Roll_Details
                {
                    Product_id = item.Part_Number,
                    Product_name = item.ProductName,
                    Roll_id = item.Palet_number,
                    Roll_number ="0",
                    Code_Person="0",
                    Unique_code="0",
                    Tipo_pro=1,
                    Cant_despacho = Convert.ToInt32(item.cant_despacho),
                    Cantidad = item.Palet_paginas,
                    Tipo_mov=item.Tipo
                };
                listarc.Add(hoja);     
            }
            grid_UniqueCode.DataSource = listarc.ToList();
        }
        private void LoadDataRC()
        {
            grid_UniqueCode.DataSource = despachomanager.GetDataUniqueCode(txt_numero_despacho.Text.Trim());
        }
        #endregion
        #region UPDATE_INVENTARIOS
        private void Actualizarinventarios()
        {
            foreach (Roll_Details item in listarc)
            {
                //ACTUALIZAR ROLLO CORTADO.
                if (item.Tipo_pro == 0) 
                {
                    despachomanager.UpdateUniqueCode(item.Unique_code, item.Tipo_mov);
                }
                //ACTUALIZAR HOJAS.
                if (item.Tipo_pro == 1) 
                {
                    despachomanager.UpdateInventoryHojas(item.Roll_id,item.Tipo_mov,item.Cantidad,item.Cant_despacho);
                }
                //ACTUALIZAR GRAPHICS.
                if (item.Tipo_pro == 2) 
                {
                    despachomanager.UpdateInventoryGraphics(item.Roll_id, item.Tipo_mov);
                }
                
            }
        }
        #endregion
        #region PROCESOS_FORMS
        private Boolean ValidarRenglon()
        {
            Boolean chk = true;
            for (int i = 0; i <= grid_items.Rows.Count - 1; i++)
            {
                if (Convert.ToString(grid_items.Rows[i].Cells["product_id"].Value) == "")
                {
                    MessageBox.Show("falta el codigo del articulo.?");
                    chk = false;
                    break;
                }
                if (Convert.ToDecimal(grid_items.Rows[i].Cells["cant"].Value) <= 0)
                {
                    MessageBox.Show("Introduzca la cantidad.?");
                    chk = false;
                    break;
                }
                if (Convert.ToDecimal(grid_items.Rows[i].Cells["precio"].Value) <= 0)
                {
                    MessageBox.Show("Introduzca el precio.?");
                    chk = false;
                    break;
                }
            }
            return chk;
        }
        private void DeleteRowBlank()
        {
            foreach (DataRowView row in bsitem)
            {
                if (Convert.ToString(row["product_id"]) == "")
                {
                    row.Delete();
                }
            }
        }
        private void DeleteRow()
        {
            DataRowView rowSelect = (DataRowView)bsitem.Current;
            rowSelect.Row.Delete();
        }
        private ClassDespacho CrearObjectDespacho()
        {
            despacho = new ClassDespacho
            {
                Numero = (txt_numero_despacho.Text),
                Fecha_despacho = Convert.ToDateTime(txt_fecha_despacho.Text),
                Curstomer_id = txt_customer_id.Text,
                Curstomer_name = txt_customer_name.Text,
                Curstomer_direc = txt_customer_direc.Text,
                Persona_entrega = txt_contact_person.Text,
                Vendedor_id = txt_vendor_id.Text,
                Vendedor_name = txt_vendor_name.Text,
                Transport_id = txt_transport_id.Text,
                Transport_name = txt_transport_name.Text,
                Chofer_id = txt_chofer_id.Text,
                Chofer_name = txt_chofer_name.Text,
                Placas_id = txt_placas.Text,
                Modelo_camion = txt_camion.Text,
                Tipo_embalaje = txt_tipo_embalaje.Text,
                Orden_trabajo = txt_otrabajo.Text,
                Orden_compra = txt_ocompra.Text,
                Subtotal = Convert.ToDecimal(txt_subtotal.Text),
                Monto_itbis = Convert.ToDecimal(txt_monto_itbis.Text),
                Total = Convert.ToDecimal(txt_total_despacho.Text)
            };
            despacho.items = new List<Items_despacho>();
            for (int fila = 0; fila <= grid_items.Rows.Count - 1; fila++)
            {
                Items_despacho item = new Items_despacho
                {
                    product_id = grid_items.Rows[fila].Cells["product_id"].Value.ToString(),
                    product_name = grid_items.Rows[fila].Cells["product_name"].Value.ToString(),
                    cantidad = Convert.ToDecimal(grid_items.Rows[fila].Cells["cant"].Value),
                    unidad = grid_items.Rows[fila].Cells["unidad"].Value.ToString(),
                    width = Convert.ToDecimal(grid_items.Rows[fila].Cells["ancho"].Value),
                    lenght = Convert.ToDecimal(grid_items.Rows[fila].Cells["largo"].Value),
                    msi = Convert.ToDecimal(grid_items.Rows[fila].Cells["msi"].Value),
                    total_pie_lineal = Convert.ToDecimal(grid_items.Rows[fila].Cells["pie_lin"].Value),
                    ratio = Convert.ToDecimal(grid_items.Rows[fila].Cells["ratio"].Value),
                    kilo_rollo = Convert.ToDecimal(grid_items.Rows[fila].Cells["kilo_rollo"].Value),
                    kilo_total = Convert.ToDecimal(grid_items.Rows[fila].Cells["kilo_total"].Value),
                    precio = Convert.ToDecimal(grid_items.Rows[fila].Cells["precio"].Value),
                    subtotal = Convert.ToDecimal(grid_items.Rows[fila].Cells["total_renglon"].Value)
                };
                despacho.items.Add(item);
            }
            return despacho;
        }
        private string CalcularTotal(decimal subtotal, decimal monto_itbis)
        {
            decimal total = subtotal + monto_itbis;
            return string.Format("{0,12:N2}", total);
        }
        private string CalcularIva(decimal PORC_ITBIS, decimal subtotal)
        {
            decimal monto_itbis = PORC_ITBIS * subtotal / 100;
            return string.Format("{0,12:N2}", monto_itbis);
        }
        private void OptionsMenu(int state)
        {
            switch (state)
            {
                case 0:
                    //modo agregar nuevo orden.
                    BOT_PRIMERO.Enabled = false;
                    BOT_SIGUIENTE.Enabled = false;
                    BOT_ANTERIOR.Enabled = false;
                    BOT_ULTIMO.Enabled = false;
                    bot_nuevo.Enabled = false;
                    BOT_BUSCAR.Enabled = false;
                    BOT_CANCELAR.Enabled = true;
                    BOT_SAVE.Enabled = true;
                    bot_modificar.Enabled = false;
                    BOT_IMPRIMIR.Enabled = false;
                    break;
                case 1:
                    //modo despues de grabar
                    BOT_PRIMERO.Enabled = true;
                    BOT_SIGUIENTE.Enabled = true;
                    BOT_ANTERIOR.Enabled = true;
                    BOT_ULTIMO.Enabled = true;
                    bot_nuevo.Enabled = true;
                    BOT_BUSCAR.Enabled = true;
                    BOT_CANCELAR.Enabled = false;
                    BOT_SAVE.Enabled = false;
                    bot_modificar.Enabled = true;
                    BOT_IMPRIMIR.Enabled = true;
                    break;
                case 2:
                    break;
            }

        }
        private void OptionsForm(int state)
        {
            switch (state)
            {
                case 0:
                    //abrir el formulario para agregar un nuevo despacho
                    txt_fecha_despacho.Enabled = true;
                    txt_customer_id.ReadOnly = false;
                    txt_contact_person.ReadOnly = false;
                    txt_ocompra.ReadOnly = false;
                    txt_otrabajo.ReadOnly = false;
                    txt_tipo_embalaje.ReadOnly = false;
                    bot_vendor_search.Enabled = true;
                    bot_chofer_search.Enabled = true;
                    BOT_CAMION.Enabled = true;
                    bot_transport_search.Enabled = true;
                    bot_agregar_renglon.Enabled = true;
                    bot_buscar_clientes.Enabled = true;
                    bot_sincro.Enabled = true;
                    grid_items.Enabled = true;
                    grid_items.ReadOnly = false;
                    grid_items.Columns["total_renglon"].ReadOnly = true;
                    grid_paleta.ReadOnly = false;
                    grid_paleta.Columns[0].ReadOnly = true;
                    //abrir el detalle de paleta.
                    bot_addpalet.Enabled = true;
                    bot_deletepalet.Enabled = true;
                    bot_UpdatePalet.Enabled = false;
                    break;
                case 1:
                    // cerrar el formulario para no permitir mas cambio y colocarlo en modo readonly.
                    txt_fecha_despacho.Enabled = false;
                    txt_customer_id.ReadOnly = true;
                    txt_contact_person.ReadOnly = true;
                    txt_ocompra.ReadOnly = true;
                    txt_otrabajo.ReadOnly = true;
                    txt_tipo_embalaje.ReadOnly = true;
                    bot_buscar_clientes.Enabled = false;
                    BOT_CAMION.Enabled = false;
                    bot_chofer_search.Enabled = false;
                    bot_vendor_search.Enabled = false;
                    bot_transport_search.Enabled = false;
                    bot_agregar_renglon.Enabled = false;
                    bot_sincro.Enabled = false;
                    grid_items.ReadOnly = true;
                    grid_paleta.Enabled = false;
                    bot_UpdatePalet.Enabled = true;
                    break;
                case 2:
                    break;
            }
        }
        private void AGREGAR_COLUMN_GRID(string name, int size, string title, string field_bd, DataGridView grid)
        {
            DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn
            {
                Name = name,
                Width = size,
                HeaderText = title,
                DataPropertyName = field_bd
            };
            grid.Columns.Add(col);
        }
        private string CalcularSubtotal()
        {
            decimal subtotal = 0;
            for (int i = 0; i <= grid_items.Rows.Count - 1; i++)
            {
                subtotal += Convert.ToDecimal(grid_items.Rows[i].Cells["total_renglon"].Value);
            }
            return string.Format("{0,12:N2}", subtotal);
        }
        private void BOT_CANCELAR_Click(object sender, EventArgs e)
        {
            if (EditMode == 1)
            {
                DataRowView rowcurrent;
                rowcurrent = (DataRowView)bs.Current;
                rowcurrent.Row.Delete();
                bs.EndEdit();
                RefreshFormData();
                bs.Position = bs.Count - 1;
                //activo la funciones del menu
                OptionsMenu(1);
                OptionsForm(1);
                EditMode = 0;
            }
            if (EditMode == 2)
            {
                OptionsMenu(1);
                OptionsForm(1);
                EditMode = 0;
            }
        }
        private void Agregar_renglon_Click(object sender, EventArgs e)
        {
            if (!ValidarRenglon())
            {
                return;
            }
            AgregarRenglon();
        }
        private void ContadorRegistros()
        {
        
        }
        private void Bot_sincro_Click(object sender, EventArgs e)
        {
            LoadPicking();
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            DeleteRow();
        }
        #endregion
        #region CRUD_DESPACHO
        private void ToSaveAdd()
        {
            //validar el formulario
            if (txt_customer_id.Text.Length == 0)
            {
                MessageBox.Show("Introduzca el codigo del Cliente.?");
                return;
            }
            if (txt_vendor_id.Text.Length == 0)
            {
                MessageBox.Show("Introduzca el codigo del Vendedor.?");
                return;
            }
            if (txt_transport_id.Text.Length == 0)
            {
                MessageBox.Show("Introduzca el codigo del transporte.?");
                return;
            }
            if (txt_chofer_id.Text.Length == 0)
            {
                MessageBox.Show("Introduzca el codigo del chofer.?");
                return;
            }
            if (txt_placas.Text.Length == 0)
            {
                MessageBox.Show("Introduzca el codigo placas.?");
                return;
            }
            //validar que exista 
            if (grid_items.Rows.Count < 1)
            {
                MessageBox.Show("Ingrese los datos del renglon antes de grabar.?");
                return;
            }
            //validar renglones
            if (!ValidarRenglon())
            {
                return;
            };
            // grabar la orden de conduce.
            despachomanager.Add(CrearObjectDespacho(), false);
            // grabar el detalle de los uniques code
            despachomanager.AddRC(listarc, txt_numero_despacho.Text.Trim());
            despachomanager.AddPalet(ListPalet);
            //grabar el consecutivo en la tabla de parametros.
            config.SetParametersControl(Consec.ToString(), "CONSEC_DP");
            //Actualizar los inventarios
            Actualizarinventarios();
            OptionsMenu(1);
            OptionsForm(1);
            //BORRO LA LISTA DE ID.
            listarc.Clear();
            ListPalet.Clear();
        }
        private void ToSaveUpdate()
        {

        }
        private void AgregarRenglon()
        {
            //Agregar detalle de la factura.

            ChildRows = (DataRowView)bsitem.AddNew();
            ChildRows.BeginEdit();
            ChildRows["numero"] = txt_numero_despacho.Text;
            ChildRows["cant"] = 0;
            ChildRows["ratio"] = 0;
            ChildRows["width"] = 0;
            ChildRows["msi"] = 0;
            ChildRows["kilo_rollo"] = 0;
            ChildRows["precio"] = 0.0;
            ChildRows["total_renglon"] = 0;
            ChildRows.Row.SetParentRow(ParentRow.Row);
            ChildRows.EndEdit();
            bsitem.Position = bsitem.Count - 1;
            ContadorRegistros();
        }
        private void BOT_SAVE_Click(object sender, EventArgs e)
        {
            switch (EditMode)
            {
                case 1:
                    ToSaveAdd();
                    break;
                case 2:
                    ToSaveUpdate();
                    break;
            }
        }
        private void Bot_nuevo_Click(object sender, EventArgs e)
        {
            Consec = Convert.ToInt32(config.GetParameterControl("CONSEC_DP")) + 1;
            ParentRow = (DataRowView)bs.AddNew();
            ParentRow.BeginEdit();
            ParentRow["numero"] = Convert.ToString(Consec);
            ParentRow["fecha"] = DateTime.Today;
            ParentRow.EndEdit();
            txt_numero_despacho.Focus();
            AgregarRenglon();
            ContadorRegistros();
            OptionsMenu(0);
            OptionsForm(0);
            txt_porc_itbis.Text = PORC_ITBIS.ToString();
            EditMode = 1;
            grid_UniqueCode.DataSource = "";
            grid_items.Focus();
            grid_items.Rows[0].Cells[0].Selected = true;
            grid_paleta.DataSource = "";
            total_kilos1.Text = "0";
            total_kilos2.Text = "0";
        }
        #endregion
        #region IMPRESION
        private void BOT_IMPRIMIR_Click(object sender, EventArgs e)
        {
            //entra al detalle de los Unique Code RC
            if (ra_reporte1.Checked)
            {
                reportManager.Conduce_Precio(txt_numero_despacho.Text);
            }
            if (ra_reporte2.Checked)
            {
                reportManager.Conduce_sin_Precio(txt_numero_despacho.Text);
            }
            if (ra_reporte3.Checked)
            {
                reportManager.Detalle_RC(txt_numero_despacho.Text);
            }
            if (ra_reporte4.Checked)
            {
                reportManager.Detalle_Paleta(txt_numero_despacho.Text);
            }
        }
        #endregion
        #region CONFIG_DATABINDING
        private void ENLACE_DATOS()
        {
            ds = despachomanager.ds;
            bs.DataSource = ds;
            bs.DataMember = "dtdespacho";
            txt_numero_despacho.DataBindings.Add("text", bs, "numero");
            txt_fecha_despacho.DataBindings.Add("text", bs, "fecha");
            txt_customer_id.DataBindings.Add("text", bs, "customer_id");
            txt_customer_name.DataBindings.Add("text", bs, "customer_name");
            txt_customer_direc.DataBindings.Add("text", bs, "customer_dir");
            txt_contact_person.DataBindings.Add("text", bs, "person_contact");
            txt_vendor_id.DataBindings.Add("text", bs, "vendor_id");
            txt_vendor_name.DataBindings.Add("text", bs, "vendor_name");
            txt_transport_id.DataBindings.Add("text", bs, "transport_id");
            txt_transport_name.DataBindings.Add("text", bs, "transport_name");
            txt_chofer_id.DataBindings.Add("text", bs, "chofer_id");
            txt_chofer_name.DataBindings.Add("text", bs, "chofer_name");
            txt_placas.DataBindings.Add("text", bs, "placas_id");
            txt_camion.DataBindings.Add("text", bs, "camion_name");
            txt_tipo_embalaje.DataBindings.Add("text", bs, "packing");
            txt_ocompra.DataBindings.Add("text", bs, "orden_compra");
            txt_otrabajo.DataBindings.Add("text", bs, "orden_trabajo");
            txt_subtotal.DataBindings.Add("text", bs, "subtotal");
            txt_monto_itbis.DataBindings.Add("text", bs, "itbis");
            txt_total_despacho.DataBindings.Add("text", bs, "total$rd");
            txt_porc_itbis.DataBindings.Add("text", bs, "porc_itbis");
            bsitem.DataSource = bs;
            bsitem.DataMember = "FK_MASTER_DETAILS";
            grid_items.DataSource = bsitem;
        }
        #endregion
        #region ESTILOS_DATAGRID
        private void AplicarEstilosGrid()
        {
            //grid renglones
            grid_items.AutoGenerateColumns = false;
            AGREGAR_COLUMN_GRID("product_id", 50, "Product Id.", "product_id", grid_items);

            AGREGAR_COLUMN_GRID("product_name", 180, "Nombre del Producto", "product_name", grid_items);
            AGREGAR_COLUMN_GRID("unidad", 50, "Unidad", "unid_id", grid_items);
            DataGridViewButtonColumn col3 = new DataGridViewButtonColumn
            {
                Name = "SeachProduct",
                Width = 25,
                HeaderText = "..."
            };
            grid_items.Columns.Add(col3);
            AGREGAR_COLUMN_GRID("cant", 45, "Cant.", "cant", grid_items);
            AGREGAR_COLUMN_GRID("ancho", 45, "Ancho (inch)", "width", grid_items);
            AGREGAR_COLUMN_GRID("largo", 45, "Largo (pies)", "lenght", grid_items);
            AGREGAR_COLUMN_GRID("msi", 45, "Msi.", "msi", grid_items);
            AGREGAR_COLUMN_GRID("pie_lin", 45, "Total Pie Lin.", "total_pie_lin", grid_items);
            AGREGAR_COLUMN_GRID("ratio", 45, "Ratio", "ratio", grid_items);
            AGREGAR_COLUMN_GRID("kilo_rollo", 45, "kilo rollo", "kilo_rollo", grid_items);
            AGREGAR_COLUMN_GRID("kilo_total", 45, "kilo Total", "kilo_total", grid_items);
            AGREGAR_COLUMN_GRID("precio", 60, "precio", "precio", grid_items);
            AGREGAR_COLUMN_GRID("total_renglon", 65, "Total renglon", "total_renglon", grid_items);
            AGREGAR_COLUMN_GRID("action", 25, "A", "", grid_items);
            // GRID DETALLE DE LOS ID.
            grid_UniqueCode.AutoGenerateColumns = false;
            AGREGAR_COLUMN_GRID("code_unique", 60, "Codigo Unico", "unique_code", grid_UniqueCode);
            AGREGAR_COLUMN_GRID("product_id", 60, "Product Id", "product_id", grid_UniqueCode);
            AGREGAR_COLUMN_GRID("product_name", 200, "Nombre del Producto", "product_name", grid_UniqueCode);
            AGREGAR_COLUMN_GRID("roll_number", 50, "Roll Number", "roll_number", grid_UniqueCode);
            AGREGAR_COLUMN_GRID("width", 50, "Width", "width", grid_UniqueCode);
            AGREGAR_COLUMN_GRID("lenght", 50, "Lenght", "large", grid_UniqueCode);
            AGREGAR_COLUMN_GRID("msi", 50, "Msi", "msi", grid_UniqueCode);
            AGREGAR_COLUMN_GRID("splice", 50, "Splice", "splice", grid_UniqueCode);
            AGREGAR_COLUMN_GRID("rollid", 50, "Roll Id", "roll_id", grid_UniqueCode);
            AGREGAR_COLUMN_GRID("cant_despacho", 50, "Cantidad Despacho", "cant_despacho", grid_UniqueCode);
            AGREGAR_COLUMN_GRID("action", 25,"A", "tipo_pro", grid_UniqueCode);
            AGREGAR_COLUMN_GRID("tipo_mov", 25, "tipo_mov", "tipo_mov", grid_UniqueCode);
            grid_items.Columns["action"].Visible = false;
            grid_UniqueCode.Columns["action"].Visible = false;
            //GRID PALETA
            grid_paleta.AutoGenerateColumns = false;
            AGREGAR_COLUMN_GRID("number_palet", 40, "# Paleta", "number_palet", grid_paleta);
            AGREGAR_COLUMN_GRID("medida", 50, "Medida", "medida", grid_paleta);
            AGREGAR_COLUMN_GRID("contenido", 250, "Contenido", "contenido", grid_paleta);
            DataGridViewButtonColumn contectCol = new DataGridViewButtonColumn
            {
                Name = "content",
                Width = 20,
                HeaderText = "..."
            };
            grid_paleta.Columns.Add(contectCol);
            AGREGAR_COLUMN_GRID("Kilos_netos", 50, "Kilos Netos", "kilo_neto", grid_paleta);
            AGREGAR_COLUMN_GRID("Kilos_brutos", 50, "Kilos Brutos", "kilo_bruto", grid_paleta);
            grid_paleta.Columns[2].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
        }
        #endregion
        #region BOTONES_BUSQUEDA_MENU
        private void Bot_buscar_clientes_Click(object sender, EventArgs e)
        {
            using (SeleccionCustomers selectcustomer = new SeleccionCustomers())
            {
                selectcustomer.Dtcustomer = ds.Tables["dtcustomer"];
                selectcustomer.ShowDialog();
                txt_customer_id.Text = selectcustomer.GetCustomerId;
                txt_customer_name.Text = selectcustomer.GetCustomerName;
                txt_customer_direc.Text = selectcustomer.GetCustomerDirecc;
            }
        }

        private void Bot_vendor_search_Click(object sender, EventArgs e)
        {
            SeleccionVendedores selectvendedores = new SeleccionVendedores
            {
                dtvendedor = ds.Tables["dtvendor"]
            };
            selectvendedores.ShowDialog();
            txt_vendor_id.Text = selectvendedores.GetVendedorId;
            txt_vendor_name.Text = selectvendedores.GetVendedorName;
        }

        private void Bot_transport_search_Click(object sender, EventArgs e)
        {
            SeleccionTransporte selecttransporte = new SeleccionTransporte
            {
                dttransporte = ds.Tables["dttransporte"]
            };
            selecttransporte.ShowDialog();
            txt_transport_id.Text = selecttransporte.GetTransporteId;
            txt_transport_name.Text = selecttransporte.GetTransporteName;
        }
        private void Bot_chofer_search_Click(object sender, EventArgs e)
        {
            SeleccionChofer selectchofer = new SeleccionChofer
            {
                dtchofer = ds.Tables["dtchofer"]
            };
            selectchofer.ShowDialog();
            txt_chofer_id.Text = selectchofer.GetChoferId;
            txt_chofer_name.Text = selectchofer.GetChoferName;
        }

        private void BOT_CAMION_Click(object sender, EventArgs e)
        {
            SeleccionCamion selectcamion = new SeleccionCamion
            {
                dtcamion = ds.Tables["dtcamion"]
            };
            selectcamion.ShowDialog();
            txt_placas.Text = selectcamion.GetCamionPlaca;
            txt_camion.Text = selectcamion.GetCamionModelo;
        }
        private void BOT_SIGUIENTE_Click(object sender, EventArgs e)
        {
            bs.Position += 1;
            RefreshFormData();
        }

        private void BOT_ANTERIOR_Click(object sender, EventArgs e)
        {
            bs.Position -= 1;
            RefreshFormData();
        }

        private void BOT_PRIMERO_Click(object sender, EventArgs e)
        {
            bs.Position = 0;
            RefreshFormData();
        }
        private void RefreshFormData() 
        {
            ContadorRegistros();
            LoadDataRC();
            DatosPaleta();
        }

        private void BOT_ULTIMO_Click(object sender, EventArgs e)
        {
            bs.Position = bs.Count - 1;
            RefreshFormData();
        }
        #endregion
        #region INTERFACE-GRID
        private void Grid_items_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //Calcular el subtotal col12 = precio
            if (e.ColumnIndex == 4 || e.ColumnIndex == 12)
            {
                if (Convert.ToString(grid_items.Rows[e.RowIndex].Cells["cant"].Value) == "")
                {
                    return;
                }
                switch (Convert.ToInt16(grid_items.Rows[e.RowIndex].Cells["action"].Value))
                {
                    case 0:
                        //calculo de subtotal cortados.
                        grid_items.Rows[e.RowIndex].Cells["total_renglon"].Value =
                        Convert.ToDouble(grid_items.Rows[e.RowIndex].Cells["pie_lin"].Value) *
                        Convert.ToDouble(grid_items.Rows[e.RowIndex].Cells["precio"].Value);
                        break;
                    
                    case 1:
                        //calculo de subtotal hojas y graphics.
                        grid_items.Rows[e.RowIndex].Cells["total_renglon"].Value =
                        Convert.ToDouble(grid_items.Rows[e.RowIndex].Cells["cant"].Value) *
                        Convert.ToDouble(grid_items.Rows[e.RowIndex].Cells["precio"].Value);
                        break;
                    case 2:
                        //calculo de subtotal hojas y graphics.
                        grid_items.Rows[e.RowIndex].Cells["total_renglon"].Value =
                        Convert.ToDouble(grid_items.Rows[e.RowIndex].Cells["cant"].Value) *
                        Convert.ToDouble(grid_items.Rows[e.RowIndex].Cells["precio"].Value);
                        break;
                    default:
                        break;
                }
                //calcular el subtotal.
                txt_subtotal.Text = CalcularSubtotal();
                txt_monto_itbis.Text = CalcularIva(PORC_ITBIS, Convert.ToDecimal(txt_subtotal.Text));
                txt_total_despacho.Text = CalcularTotal(Convert.ToDecimal(txt_subtotal.Text), Convert.ToDecimal(txt_monto_itbis.Text));
            }
            //Calcular los pesos 
            if (e.ColumnIndex == 9)
            {
                grid_items.Rows[e.RowIndex].Cells["kilo_rollo"].Value = Convert.ToDouble(grid_items.Rows[e.RowIndex].Cells["msi"].Value) /
                    Convert.ToDouble(grid_items.Rows[e.RowIndex].Cells["ratio"].Value);

                grid_items.Rows[e.RowIndex].Cells["kilo_total"].Value = Convert.ToDouble(grid_items.Rows[e.RowIndex].Cells["kilo_rollo"].Value) *
                    Convert.ToDouble(grid_items.Rows[e.RowIndex].Cells["cant"].Value);
            }
        }

        private void Btn_crystal_Click(object sender, EventArgs e)
        {
            FrmReportViewCrystal frmReportView = new FrmReportViewCrystal();
            ReportDocument reporte = new ReportDocument();
            reporte.Load(Application.StartupPath + @"\Reports\ConduceConPrecio.rpt");
            frmReportView.crystalReportViewer1.ReportSource = reporte;
            frmReportView.Refresh();
            frmReportView.crystalReportViewer1.Zoom(80);
            frmReportView.Text = "Detalle de los Unique Code (RC)";
            frmReportView.Width = 900;
            frmReportView.Height = 700;
            frmReportView.Refresh();
            frmReportView.ShowDialog();
        }

        private void BOT_BUSCAR_Click(object sender, EventArgs e)
        {

        }

        private void Bot_addpalet_Click(object sender, EventArgs e)
        {
            if (!ValidRowPalet())
            {
                return;
            }
            Paleta item = new Paleta
            {
                Number_palet = (ListPalet.Count +1).ToString(),
                Numero = txt_numero_despacho.Text,
                Medida="",
                Contenido=""
            };
            ListPalet.Add(item);
            grid_paleta.DataSource = null;
            grid_paleta.DataSource = ListPalet;
            if (ListPalet.Count > 0)
            {
                bot_deletepalet.Enabled = true;
            }
            if (ListPalet.Count > 1) 
            {
                grid_paleta.CurrentCell = grid_paleta[1, ListPalet.Count - 1];
            }
            
        }

        private void Grid_paleta_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 3) 
            {
                frmContentPalet ContentPalet = new frmContentPalet();
                if(grid_paleta.Rows[e.RowIndex].Cells[2].Value == null) 
                {
                    grid_paleta.Rows[e.RowIndex].Cells[2].Value = "";
                }
                ContentPalet.ContentText = grid_paleta.Rows[e.RowIndex].Cells[2].Value.ToString();
                ContentPalet.ShowDialog();
                grid_paleta.Rows[e.RowIndex].Cells[2].Value = ContentPalet.ContentText;
            }
        }

        private void Bot_SavePalet_Click(object sender, EventArgs e)
        {
            
        }

        private void Bot_loadpalet_Click(object sender, EventArgs e)
        {
            grid_paleta.DataSource = despachomanager.GetDataPalet(txt_numero_despacho.Text);
        }

        private void Grid_items_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                SeleccionProductos selectProducts = new SeleccionProductos
                {
                    Dtproducto = ds.Tables["dtproducto"]
                };
                selectProducts.ShowDialog();
                grid_items.Rows[e.RowIndex].Cells["product_id"].Value = selectProducts.GetProductId;
                //establecer la unidad.
                if (selectProducts.GetMasterRolls)
                {
                    grid_items.Rows[e.RowIndex].Cells["unidad"].Value = "Master";
                }
                if (selectProducts.GetResma)
                {
                    grid_items.Rows[e.RowIndex].Cells["unidad"].Value = "Resma";
                }
                if (selectProducts.Getgraphics)
                {
                    grid_items.Rows[e.RowIndex].Cells["unidad"].Value = "Graphics";
                }
            }
        }
        private void Grid_items_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int columnIndex = grid_items.CurrentCell.ColumnIndex;
                // detectar el enter sobre la columna productid
                if (columnIndex == 0)
                {
                    LoadPicking();
                }
                SendKeys.Send("{TAB}");
            }
        }

        private void Bot_deletepalet_Click(object sender, EventArgs e)
        {
            if (ListPalet.Count == 1) 
            {
                return;
            }
            var itemToRemove = ListPalet.Single(r => r.Number_palet ==
            Convert.ToString(grid_paleta.Rows[grid_paleta.CurrentRow.Index].Cells["number_palet"].Value));
            ListPalet.Remove(itemToRemove);
            int row = 1;
            foreach (Paleta item in ListPalet)
            {
                item.Number_palet = row.ToString();
                row++;
            }
            grid_paleta.DataSource = null;
            grid_paleta.DataSource = ListPalet;
        }
        private void Bot_UpdatePalet_Click(object sender, EventArgs e)
        {
            if (UpdatePaleta == 0) 
            {
                
                if (grid_paleta.Rows.Count == 0)
                {
                    ListPalet.Clear();
                    Paleta item = new Paleta
                    {
                        Number_palet = (ListPalet.Count + 1).ToString(),
                        Numero = txt_numero_despacho.Text,
                    };
                    ListPalet.Add(item);
                    grid_paleta.DataSource = null;
                    grid_paleta.DataSource = ListPalet;
                    grid_items.Refresh();
                }
                if(grid_paleta.Rows.Count > 0)
                {
                    ListPalet = (List<Paleta>)grid_paleta.DataSource;
                }
                bot_UpdatePalet.Text = "Save";
                bot_addpalet.Enabled = true;
                bot_deletepalet.Enabled = true;
                grid_paleta.ReadOnly = false;
                UpdatePaleta = 1;
            }
            else 
            {
                //Borro la paleta anterior en BD.
                despachomanager.DeletePalet(txt_numero_despacho.Text);
                //Agrego la nueva Paleta
                despachomanager.AddPalet(ListPalet);
                bot_UpdatePalet.Text = "Modif";
                bot_addpalet.Enabled = false;
                bot_deletepalet.Enabled = false;
                grid_paleta.ReadOnly = true;
                UpdatePaleta = 0;
            }
        }

        private void Grid_paleta_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4 || e.ColumnIndex == 5)
            {
                TotalkilosPalet();
            }
        }

        private void DatosPaleta() 
        {
            grid_paleta.DataSource = despachomanager.GetDataPalet(txt_numero_despacho.Text);
            TotalkilosPalet();
        }
        private bool ValidRowPalet()
        {
            Boolean chk = true;
            for (int i = 0; i <= grid_paleta.Rows.Count - 1; i++)
            {
                if (Convert.ToString(grid_paleta.Rows[i].Cells["medida"].Value) == "")
                {
                    MessageBox.Show("Datos de la medida de paleta.?");
                    chk = false;
                    break;
                }
                if (Convert.ToString(grid_paleta.Rows[i].Cells["contenido"].Value) == "")
                {
                    MessageBox.Show("Introduzca el contenido de la paleta.?");
                    chk = false;
                    break;
                }
                if (Convert.ToDecimal(grid_paleta.Rows[i].Cells["kilos_netos"].Value) <= 0)
                {
                    MessageBox.Show("Kilo neto.?");
                    chk = false;
                    break;
                }
                if (Convert.ToDecimal(grid_paleta.Rows[i].Cells["kilos_brutos"].Value) <= 0)
                {
                    MessageBox.Show("Kilo bruto.?");
                    chk = false;
                    break;
                }
            }
            return chk;
        }
        private void TotalkilosPalet() 
        {
            decimal tk_brutos = 0;
            decimal tk_netos = 0;
            for (int i = 0; i <= grid_paleta.Rows.Count-1; i++) 
            {
                tk_netos += Convert.ToDecimal(grid_paleta.Rows[i].Cells["kilos_netos"].Value);
                tk_brutos += Convert.ToDecimal(grid_paleta.Rows[i].Cells["kilos_brutos"].Value);
            }
            total_kilos1.Text = tk_netos.ToString();
            total_kilos2.Text = tk_brutos.ToString();
        }
        #endregion
    }
}