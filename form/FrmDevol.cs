﻿namespace RitramaAPP.form
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
        int Consec = 0;
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
            bsItemRows.DataSource = bs;
            bsItemRows.DataMember = "FK_MASTER_DETAILS";
            GridDevol.DataSource = bsItemRows;
            bs.Position = (bs.Count - 1);
            ContadorRegistros();
        }
        private void APLICAR_ESTILOS_GRID()
        {
            GridDevol.AutoGenerateColumns = false;
            AGREGAR_COLUMN_GRID("product_id", 70, "Product ID.", "product_id", GridDevol);
            DataGridViewButtonColumn col3 = new DataGridViewButtonColumn
            {
                Name = "SeachProduct",
                Width = 25,
                HeaderText = "..."
            };
            GridDevol.Columns.Add(col3);
            AGREGAR_COLUMN_GRID("product_name", 290, "Nombre del Producto", "product_name", GridDevol);
            AGREGAR_COLUMN_GRID("cantidad", 70, "Cantidad", "cantidad", GridDevol);
            AGREGAR_COLUMN_GRID("roll_id", 70, "Numero ID", "roll_id", GridDevol);
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
            //abro textbox
           
            //abrir un documento de devolucion.
            Consec = Convert.ToInt32(config.GetParameterControl("CONSEC_DEV")) + 1;
            ParentRow = (DataRowView)bs.AddNew();
            ParentRow.BeginEdit();
            ParentRow["numero"] = Convert.ToString(Consec);
            ParentRow["fecha"] = DateTime.Today;
            ParentRow.EndEdit();
            TXT_NUMERO.Focus();
            AgregarRenglon();
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
                //GridDevol.Rows[e.RowIndex].Cells["product_name"].Value = products.GetProductName;
                GridDevol.Rows[e.RowIndex].Cells["cantidad"].Value = "1";
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
        }
        private void Save()
        {
            manager.Add(CreateObjectDevolucion(),false);
            config.SetParametersControl(Consec.ToString(), "CONSEC_DEV");
            OptionMenu(1);
            OptionForm(1);
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
                    Cantidad = Convert.ToDouble(GridDevol.Rows[fila].Cells["cantidad"].Value.ToString()),
                    NumeroID = GridDevol.Rows[fila].Cells["roll_id"].Value.ToString()
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
                    bot_buscar.Enabled = false;
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
                    bot_buscar.Enabled = true;
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
                if (Convert.ToDecimal(GridDevol.Rows[i].Cells["cantidad"].Value) <= 0)
                {
                    MessageBox.Show("Introduzca la cantidad.?");
                    chk = false;
                    break;
                }
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
    }
}
