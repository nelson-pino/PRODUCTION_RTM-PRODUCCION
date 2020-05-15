namespace RitramaAPP.form
{
    using System;
    using System.Data;
    using System.Windows.Forms;
    using RitramaAPP.Clases;
    public partial class FrmDevol : Form
    {
        public FrmDevol()
        {
            InitializeComponent();
        }
        readonly DataTable DtCustomer = new DataTable();
        readonly DevolucionManager manager = new DevolucionManager();
        readonly ConfigManager config = new ConfigManager();
        readonly BindingSource bs = new BindingSource();
        readonly BindingSource bsItemRows = new BindingSource();
        DataSet ds = new DataSet();
        DataRowView ParentRow;
        DataRowView ChildRows;
        int Consec = 0,EditMode = 0;
        private void FrmDevol_Load(object sender, EventArgs e)
        {
            //Creacion de Columnas del Grid.
            APLICAR_ESTILOS_GRID();
            //Configuracion del BindingSource
            DATABINDING();
        }
        private void DATABINDING() 
        {
            ds = manager.ds;
            bs.DataSource = ds;
            bs.DataMember = "dtdevolucion";
            TXT_NUMERO.DataBindings.Add("text", bs, "numero");
            TXT_FECHA.DataBindings.Add("text", bs, "fecha");
            TXT_IDCUST.DataBindings.Add("text", bs, "customer_id");
            TXT_CUSTOMER_NAME.DataBindings.Add("text", bs, "customer_name");
            TXT_RAZON_DEVOL.DataBindings.Add("text", bs, "razon");
            RA_DOCUMENT_STATUS.DataBindings.Add("Checked", bs, "doc_status");
            bsItemRows.DataSource = bs;
            bsItemRows.DataMember = "FK_MASTER_DETAILS";
            GridDevol.DataSource = bsItemRows;
            bs.Position = (bs.Count - 1);
            ContadorRegistros();
        }
        private void APLICAR_ESTILOS_GRID()
        {
            GridDevol.AutoGenerateColumns = false;
            AGREGAR_COLUMN_GRID("product_id", 80, "Product ID.", "product_id", GridDevol);
            DataGridViewButtonColumn col3 = new DataGridViewButtonColumn
            {
                Name = "SeachProduct",
                Width = 25,
                HeaderText = "..."
            };
            GridDevol.Columns.Add(col3);
            AGREGAR_COLUMN_GRID("product_name", 200, "Nombre del Producto", "product_name", GridDevol);
            AGREGAR_COLUMN_GRID("tipo", 60, "Tipo", "tipo", GridDevol);
            //AGREGAR_COLUMN_GRID("cantidad", 60, "Cantidad", "cantidad", GridDevol);
            AGREGAR_COLUMN_GRID("roll_id", 65, "Numero ID", "roll_id", GridDevol);
            AGREGAR_COLUMN_GRID("width", 80, "Width", "width", GridDevol);
            AGREGAR_COLUMN_GRID("lenght", 80, "Lenght", "lenght", GridDevol);
            AGREGAR_COLUMN_GRID("msi", 80, "MSI", "msi", GridDevol);
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
        private void Bot_nuevo_Click(object sender, EventArgs e)
        {
            //MenuOptions
            OptionMenu(0);
            OptionForm(0);
            RA_DOCUMENT_STATUS.DataBindings.Clear();
            //abrir un documento de devolucion.
            Consec = Convert.ToInt32(config.GetParameterControl("CONSEC_DEV")) + 1;
            ParentRow = (DataRowView)bs.AddNew();
            ParentRow.BeginEdit();
            ParentRow["numero"] = Convert.ToString(Consec);
            ParentRow["fecha"] = DateTime.Today;
            ParentRow["doc_status"] = false;
            ParentRow.EndEdit();
            TXT_NUMERO.Focus();
            AgregarRenglon();
            EditMode = 1;
        }

        private void AgregarRenglon()
        {
            // Agregar detalle de la factura.
            ChildRows = (DataRowView)bsItemRows.AddNew();
            ChildRows.BeginEdit();
            ChildRows["numero"] = TXT_NUMERO.Text;
            ChildRows["cantidad"] = 0;
            ChildRows.Row.SetParentRow(ParentRow.Row);
            ChildRows.EndEdit();
            bsItemRows.Position =  bsItemRows.Count - 1;
            ContadorRegistros();
        }

        private void ContadorRegistros()
        {
            REGISTER_COUNT.Text =  (bs.Position + 1).ToString() + " de " +  bs.Count.ToString();
        }

        private void Btn_search_Click(object sender, EventArgs e)
        {
            using (SeleccionCustomers customers = new SeleccionCustomers()) 
            {
                customers.Dtcustomer = manager.GetCustomers();
                customers.ShowDialog();
                TXT_IDCUST.Text = customers.GetCustomerId;
                TXT_CUSTOMER_NAME.Text = customers.GetCustomerName;
            };
        }

        private void GridDevol_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1) 
            {
                SeleccionProductos products = new SeleccionProductos
                {
                    Dtproducto = manager.GetProducts()
                };
                products.ShowDialog();
                GridDevol.Rows[e.RowIndex].Cells["product_id"].Value = products.GetProductId;
                GridDevol.Rows[e.RowIndex].Cells["tipo"].Value = products.GetProductTipo;
                //GridDevol.Rows[e.RowIndex].Cells["cantidad"].Value = "1";
                GridDevol.Rows[e.RowIndex].Cells["roll_id"].Value = "";
                GridDevol.CurrentCell = GridDevol[4, e.RowIndex];
            }
        }

        private void AGREGAR_RENGLON_Click(object sender, EventArgs e)
        {
            if (ValidarRenglon()) 
            {
                AgregarRenglon();
            }
        }

        private void Bot_grabar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TXT_IDCUST.Text))
            {
                MessageBox.Show("Los datos del documento no estan completos...(codigo cliente?)");
                return;
            }
            if (string.IsNullOrEmpty(TXT_RAZON_DEVOL.Text))
            {
                MessageBox.Show("Los datos del documento no estan completos...(razon de la devolución?)");
                return;
            }
            if (!ValidarRenglon()) 
            {
                return;
            }
            Save();
            RA_DOCUMENT_STATUS.DataBindings.Add("Checked", bs, "doc_status");
            EditMode = 0;
        }
        private void Save()
        {
            manager.Add(CreateObjectDevolucion(),false);
            config.SetParametersControl(Consec.ToString(), "CONSEC_DEV");
            //actualiza los inventarios.
            UpdateInventory(true);
            OptionMenu(1);
            OptionForm(1);
        }

        private void UpdateInventory(bool st)
        {
            Item item = new Item();
            for (int i=0; i <= GridDevol.Rows.Count-1; i++)
            {
                string tipo = GridDevol.Rows[i].Cells["tipo"].Value.ToString();
                item.Product_id = GridDevol.Rows[i].Cells["product_id"].Value.ToString();
                item.Unique_code = GridDevol.Rows[i].Cells["roll_id"].Value.ToString();
                item.Width = Convert.ToDecimal(GridDevol.Rows[i].Cells["width"].Value);
                item.Lenght = Convert.ToDecimal(GridDevol.Rows[i].Cells["lenght"].Value);
                item.Msi = Convert.ToDecimal(GridDevol.Rows[i].Cells["msi"].Value);
                bool status = st;
                switch (tipo)
                {
                    case R.CONSTANTES.TIPO_MASTER:
                        // MASTER.
                        manager.UpdateDataInventory(ReturnTypeProduct(tipo) ,status,item);
                        break;
                    case R.CONSTANTES.TIPO_ROLL:
                        //ROLLO CORTADO.
                        manager.UpdateDataInventory(ReturnTypeProduct(tipo), status,item);
                        break;
                    case R.CONSTANTES.TIPO_GRAP:
                        //GRAPHICS.
                        manager.UpdateDataInventory(ReturnTypeProduct(tipo), status, item);
                        break;
                    case R.CONSTANTES.TIPO_HOJA:
                        //HOJAS.
                        manager.UpdateDataInventory(ReturnTypeProduct(tipo), status, item);
                        break;
                }
            }
        }

        private ClassDevolucion CreateObjectDevolucion() 
        {
            ClassDevolucion documento = new ClassDevolucion
            {
                Numero = TXT_NUMERO.Text,
                Fecha = Convert.ToDateTime(TXT_FECHA.Text),
                Id_Cust = TXT_IDCUST.Text,
                Razon = TXT_RAZON_DEVOL.Text,
                DocAnulado = false
            };
            for (int fila = 0; fila <= GridDevol.Rows.Count - 1; fila++) 
            {
                Item_Devol row = new Item_Devol
                {
                    Numero = TXT_NUMERO.Text.ToString(),
                    Product_id = GridDevol.Rows[fila].Cells["product_id"].Value.ToString(),
                    Cantidad = 1,
                    NumeroID = GridDevol.Rows[fila].Cells["roll_id"].Value.ToString(),
                    Tipo = GridDevol.Rows[fila].Cells["tipo"].Value.ToString(),
                    Width = Convert.ToDouble(GridDevol.Rows[fila].Cells["width"].Value),
                    Lenght = Convert.ToDouble(GridDevol.Rows[fila].Cells["lenght"].Value),
                    Msi = Convert.ToDouble(GridDevol.Rows[fila].Cells["msi"].Value)
                };
                documento.items.Add(row);
            }
            return documento;
        }

        private void Bot_buscar_Click(object sender, EventArgs e)
        {

        }

        private void Bot_siguiente_Click(object sender, EventArgs e)
        {
            bs.Position += 1;
            ContadorRegistros();
        }

        private void Bot_anterior_Click(object sender, EventArgs e)
        {
            bs.Position -= 1;
            ContadorRegistros();
        }

        private void Bot_ultimo_Click(object sender, EventArgs e)
        {
            bs.Position = bs.Count - 1;
        }

        private void Bot_primero_Click(object sender, EventArgs e)
        {
            bs.Position = 0;
        }

        private void Bot_cancelar_Click(object sender, EventArgs e)
        {
            DataRowView rowcurrent;
            rowcurrent = (DataRowView)bs.Current;
            rowcurrent.Row.Delete();
            bs.EndEdit();
            ContadorRegistros();
            bs.Position = bs.Count - 1;
            OptionMenu(1);
            OptionForm(1);
            RA_DOCUMENT_STATUS.DataBindings.Add("Checked", bs, "doc_status");
            EditMode = 0;
        }
        private void OptionMenu(int state) 
        {
            switch (state) 
            {
                case 0:
                    //modo nuevo registro.
                    bot_grabar.Enabled = true;
                    bot_cancelar.Enabled = true;
                    bot_anterior.Enabled = false;
                    bot_siguiente.Enabled = false;
                    bot_primero.Enabled = false;
                    bot_ultimo.Enabled = false;
                    //bot_buscar.Enabled = false;
                    bot_nuevo.Enabled = false;
                    break;
                case 1:
                    //modo despues guardar.
                    bot_grabar.Enabled = false;
                    bot_cancelar.Enabled = false;
                    bot_anterior.Enabled = true;
                    bot_siguiente.Enabled = true;
                    bot_primero.Enabled = true;
                    bot_ultimo.Enabled = true;
                    //bot_buscar.Enabled = true;
                    bot_nuevo.Enabled = true;
                    break;
            }
        }
        private void OptionForm(int state) 
        {
            switch (state)
            {
                case 0:
                    //modo nuevo registro.
                    btn_search.Enabled = true;
                    BTN_AGREGAR_RENGLON.Enabled = true;
                    BTN_DELETE_RENGLON.Enabled = true;
                    TXT_FECHA.Enabled = true;
                    TXT_RAZON_DEVOL.ReadOnly = false;
                    TXT_IDCUST.ReadOnly = false;
                    GridDevol.ReadOnly = false;
                    GridDevol.Columns[0].ReadOnly = true;
                    GridDevol.Columns[2].ReadOnly = true;
                    GridDevol.Columns[3].ReadOnly = true;
                    //GridDevol.Columns[8].ReadOnly = true;
                    break;
                case 1:
                    //modo despues guardar.
                    btn_search.Enabled = false;
                    BTN_AGREGAR_RENGLON.Enabled = false;
                    BTN_DELETE_RENGLON.Enabled = false;
                    TXT_FECHA.Enabled = false;
                    TXT_RAZON_DEVOL.ReadOnly = true;
                    TXT_IDCUST.ReadOnly = true;
                    GridDevol.ReadOnly = true;
                    break;
            }
        }
        private Boolean ValidarRenglon()
        {
            Boolean chk = true;
            for (int i = 0; i <= GridDevol.Rows.Count - 1; i++)
            {
                if (Convert.ToString(GridDevol.Rows[i].Cells["product_id"].Value) == "")
                {
                    MessageBox.Show("falta el codigo del articulo.?");
                    chk = false;
                    break;
                }
                //if (Convert.ToDecimal(GridDevol.Rows[i].Cells["cantidad"].Value) <= 0)
                //{
                //    MessageBox.Show("Introduzca la cantidad.?");
                //    chk = false;
                //    break;
                //}
                if (Convert.ToString(GridDevol.Rows[i].Cells["roll_id"].Value) == "")
                {
                    MessageBox.Show("Introduzca el roll_id.?");
                    chk = false;
                    break;
                }
            }
            return chk;
        }

        private void BTN_DELETE_RENGLON_Click(object sender, EventArgs e)
        {
            DataRowView rowSelect = (DataRowView)bsItemRows.Current;
            rowSelect.Row.Delete();
        }

        private void GridDevol_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (GridDevol.Rows[e.RowIndex].Cells["tipo"].Value == null) 
            {
                GridDevol.Rows[e.RowIndex].Cells["tipo"].Value = "";
                MessageBox.Show("seleccione el producto primero");
                return;
            }
            
            if (e.ColumnIndex == 4 && EditMode == 1 &&
                !string.IsNullOrEmpty(GridDevol.Rows[e.RowIndex].Cells["roll_id"].Value.ToString()) &&
                !string.IsNullOrEmpty(GridDevol.Rows[e.RowIndex].Cells["tipo"].Value.ToString())) 
            {
                string id = GridDevol.Rows[e.RowIndex].Cells["roll_id"].Value.ToString();
                string tipo = GridDevol.Rows[e.RowIndex].Cells["tipo"].Value.ToString();
                string product_id = GridDevol.Rows[e.RowIndex].Cells["product_id"].Value.ToString();

                //BUSCAR EL RC/ID
                if (CheckDataID(id, tipo, product_id))
                {
                    //puedo devolver el producto (FUE DESPACHADO).
                    MessageBox.Show("Correcto despachado.");
                    Item item = manager.GetDataForID(ReturnTypeProduct(tipo), id, product_id);
                    GridDevol.Rows[e.RowIndex].Cells["width"].Value = item.Width;
                    GridDevol.Rows[e.RowIndex].Cells["lenght"].Value = item.Lenght;
                    GridDevol.Rows[e.RowIndex].Cells["msi"].Value = item.Msi;
                    GridDevol.CurrentCell = GridDevol[0, e.RowIndex];
                }
            }
            // si el producto es de tipo hojas no calculo el msi.
            int tipo_product = ReturnTypeProduct(GridDevol.Rows[e.RowIndex].Cells["tipo"].Value.ToString());
            //cambiar los textheader dependiendo del tipo de producto
            if(tipo_product == 4) 
            {
                GridDevol.Columns["width"].HeaderText = "Resmas x Paletas";
                GridDevol.Columns["lenght"].HeaderText = "Hojas x Resmas";
                GridDevol.Columns["msi"].HeaderText = "Cantidad Despachada";
            }
            else 
            {
                GridDevol.Columns["width"].HeaderText = "Width";
                GridDevol.Columns["lenght"].HeaderText = "Lenght";
                GridDevol.Columns["msi"].HeaderText = "Msi";
            }
            if (tipo_product != 4) 
            {
                CALCULAR_MSI_RENGLON(e.RowIndex);
            } 
            
        }

        private void Bot_Anular_Click(object sender, EventArgs e)
        {
            if (RA_DOCUMENT_STATUS.Checked) 
            {
                MessageBox.Show("Este Documento ya esta anulado...");
                return;
            }

            DialogResult dr = MessageBox.Show("Esta seguro de Anular este documento (S/N)?",
               "Advertencia", MessageBoxButtons.YesNo);
            switch (dr)
            {
                case DialogResult.Yes:
                    //actualizar la base de datos.
                    manager.DisableDocument(TXT_NUMERO.Text);
                    //actualizar la interfaz grafica.
                    ParentRow = (DataRowView)bs.Current;
                    ParentRow.BeginEdit();
                    ParentRow["doc_status"] = true;
                    ParentRow.EndEdit();
                    //actualizar los inventarios
                    UpdateInventory(false);
                    break;
                case DialogResult.No:
                    break;
            }
        }

        private int ReturnTypeProduct(string tipo_product) 
        {
            switch (tipo_product)
            {
                case R.CONSTANTES.TIPO_MASTER:
                    return 1;
                case R.CONSTANTES.TIPO_ROLL:
                    return 2;
                case R.CONSTANTES.TIPO_GRAP:
                    return 3;
                case R.CONSTANTES.TIPO_HOJA:
                    return 4;
                default:
                    return 0;
            }
        }


        private bool CheckDataID(string id, string tipo_product, string product_id)
        {
            //devulve verdadero si lo puedo devolver false si no se puede devolver.
            switch (tipo_product) 
            {
                case R.CONSTANTES.TIPO_MASTER:
                     return manager.CheckStatusDespachoID(id, 1,product_id);
                case R.CONSTANTES.TIPO_ROLL:
                    return manager.CheckStatusDespachoID(id, 2, product_id);
                case R.CONSTANTES.TIPO_GRAP:
                    return manager.CheckStatusDespachoID(id, 3, product_id);
                case R.CONSTANTES.TIPO_HOJA:
                     return manager.CheckStatusDespachoID(id, 4, product_id);
                default:
                    return false;
            }
        }
        private void CALCULAR_MSI_RENGLON(int fila)
        {
            if (EditMode != 0 || Convert.ToDouble(GridDevol.Rows[fila].Cells["lenght"].Value) > 0 ||
                 Convert.ToDouble(GridDevol.Rows[fila].Cells["width"].Value) > 0)
            {
                try
                {
                    double msi = ((Convert.ToDouble(GridDevol.Rows[fila].Cells["width"].Value)
                            * Convert.ToDouble(GridDevol.Rows[fila].Cells["lenght"].Value))
                            * R.CONSTANTES.FACTOR_CALCULO_MSI);
                    GridDevol.Rows[fila].Cells["msi"].Value = msi.ToString();
                }
                catch (Exception)
                {


                    GridDevol.Rows[fila].Cells["msi"].Value = "0";
                }


            }
        }
    }
}
