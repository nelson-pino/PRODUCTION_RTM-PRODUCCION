using RitramaAPP.Clases;
using RitramaAPP.form;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq.Expressions;
using System.Windows.Forms;


namespace RitramaAPP
{
    public partial class FrmInventario : Form
    {
        public FrmInventario()
        {
            InitializeComponent();
        }
        readonly ProductsManager productmanager = new ProductsManager();
        readonly InventarioManager inimanager = new InventarioManager();
        readonly RecepcionManager recemanager = new RecepcionManager();
        readonly ProduccionManager promanager = new ProduccionManager();
        readonly ConfigManager configManager = new ConfigManager();

        List<Item> items;
        public IEnumerable<Item> ItemFilter { get; set; }
        DataView DvGeneral = new DataView();
        DataView DvHojas = new DataView();
        DataView DvGraphics = new DataView();
        DataView dvinventario = new DataView();
        DataView DvRolls = new DataView();
        DataTable dtinventario;
        private void FrmInventario_Load(object sender, EventArgs e)
        {
            FormOptions();
        }
        private void FormOptions()
        {
        }
        private void Bot_sincro_Click(object sender, EventArgs e)
        {
            items = inimanager.GetDataIni();
            //buscar los nombre de los productos.
            foreach (Item elemento in items)
            {
                elemento.Product_name = productmanager.GetProductName(elemento.Product_id);
                elemento.Tipo = productmanager.GetProductType(elemento.Product_id);
            }
            inimanager.SaveDataIni(items);
        }
        private void AplicarEstilosMaster()
        {
            CREATE_COLUMN_IMAGE(GridItemsMaster);
            AGREGAR_COLUMN_GRID("doc", 63, "Numero Documento", "OrderPurchase", GridItemsMaster);
            AGREGAR_COLUMN_GRID("product_id", 60, "Codigo Producto", "Part_Number", GridItemsMaster);
            AGREGAR_COLUMN_GRID("product_name", 220, "Descripcion del Producto", "product_name", GridItemsMaster);
            AGREGAR_COLUMN_GRID("roll_id", 70, "Roll ID.", "roll_id", GridItemsMaster);
            AGREGAR_COLUMN_GRID("width", 70, "Width [Pulg.]", "width", GridItemsMaster);
            AGREGAR_COLUMN_GRID("lenght", 70, "Lenght [Pulg.]", "lenght", GridItemsMaster);
            AGREGAR_COLUMN_GRID("lenght_p", 70, "L. Restan [Pulg.]", "lenght_p", GridItemsMaster);
            AGREGAR_COLUMN_GRID("lenght_c", 70, "Consumos Parciales", "lenght_c", GridItemsMaster);
            AGREGAR_COLUMN_GRID("width_metros", 70, "Width [Mts.]", "width_metros", GridItemsMaster);
            AGREGAR_COLUMN_GRID("lenght_metros", 70, "Lenght [Mts.]", "lenght_metros", GridItemsMaster);
            AGREGAR_COLUMN_GRID("splice", 70, "# Empalmes", "splice", GridItemsMaster);
            AGREGAR_COLUMN_GRID("status", 30, "St", "status", GridItemsMaster);
            AGREGAR_COLUMN_GRID("master_load", 30, "load", "master_load", GridItemsMaster);
            AGREGAR_COLUMN_GRID("num_oc", 30, "oc", "doc_oc", GridItemsMaster);
            GridItemsMaster.Columns["master_load"].Visible = false;
            GridItemsMaster.Columns["num_oc"].Visible = false;


        }

        private void AplicarEstilosHojas()
        {
            CREATE_COLUMN_IMAGE(GridItemHojas);
            AGREGAR_COLUMN_GRID("doc", 65, "Numero Documento", "OrderPurchase", GridItemHojas);
            AGREGAR_COLUMN_GRID("product_id", 60, "Codigo Producto", "part_number", GridItemHojas);
            AGREGAR_COLUMN_GRID("product_name", 215, "Descripcion del Producto", "product_name", GridItemHojas);
            AGREGAR_COLUMN_GRID("roll_id", 65, "ID Hojas", "roll_id", GridItemHojas);
            AGREGAR_COLUMN_GRID("palet_num", 65, "Numero Paleta", "palet_num", GridItemHojas);
            AGREGAR_COLUMN_GRID("resmaxpag", 60, "Resmas x Paq.", "palet_cant", GridItemHojas);
            AGREGAR_COLUMN_GRID("canhojas", 60, "Hojas", "hojas", GridItemHojas);
            AGREGAR_COLUMN_GRID("hojas_parc", 60, "Entregas Parciales", "hojas_parc", GridItemHojas);
            AGREGAR_COLUMN_GRID("hojas_saldo", 60, "Hojas Saldo.", "hojas_saldo", GridItemHojas);
            AGREGAR_COLUMN_GRID("width", 70, "Width MM", "width", GridItemHojas);
            AGREGAR_COLUMN_GRID("lenght", 70, "Lenght MM", "lenght", GridItemHojas);
            AGREGAR_COLUMN_GRID("status", 30, "Status", "status", GridItemHojas);
        }
        private void AplicarEstilosGraphics()
        {
            CREATE_COLUMN_IMAGE(GridItemGraphics);
            AGREGAR_COLUMN_GRID("doc", 65, "Numero Documento", "OrderPurchase", GridItemGraphics);
            AGREGAR_COLUMN_GRID("product_id", 60, "Codigo Producto", "part_number", GridItemGraphics);
            AGREGAR_COLUMN_GRID("product_name", 230, "Descripcion del Producto", "product_name", GridItemGraphics);
            AGREGAR_COLUMN_GRID("roll_id", 75, "ID Hojas", "roll_id", GridItemGraphics);
            AGREGAR_COLUMN_GRID("palet_num", 75, "Numero Paleta", "palet_num", GridItemGraphics);
            AGREGAR_COLUMN_GRID("anchomm", 75, "Ancho MM", "width", GridItemGraphics);
            AGREGAR_COLUMN_GRID("m2", 75, "M2", "lenght", GridItemGraphics);
            AGREGAR_COLUMN_GRID("Numero", 100, "Numero Recepcion", "embarque", GridItemGraphics);
            AGREGAR_COLUMN_GRID("status", 35, "status", "status", GridItemGraphics);

        }
        private DataGridViewImageColumn CREATE_COLUMN_IMAGE(DataGridView dg) 
        {
            DataGridViewImageColumn iconColumn = new DataGridViewImageColumn
            {
                //iconColumn.Image = treeIcon.ToBitmap();
                Name = "ColumnImage",
                HeaderText = "St",
                Width = 20
            };
            dg.Columns.Insert(0, iconColumn);
            dg.Columns["ColumnImage"].DefaultCellStyle.NullValue = null;
            return iconColumn;
        }
        private void AplicarEstilosCortados()
        {
            CREATE_COLUMN_IMAGE(GridItemsCortados);
            AGREGAR_COLUMN_GRID("numero", 65, "Numero Documento", "numero", GridItemsCortados);
            AGREGAR_COLUMN_GRID("product_id", 56, "Codigo producto", "product_id", GridItemsCortados);
            AGREGAR_COLUMN_GRID("product_name", 210, "Descripcion del Producto", "product_name", GridItemsCortados);
            AGREGAR_COLUMN_GRID("roll_number", 60, "Roll Number", "roll_number", GridItemsCortados);
            AGREGAR_COLUMN_GRID("roll_id", 65, "Roll ID", "Roll_id", GridItemsCortados);
            AGREGAR_COLUMN_GRID("width", 65, "Width [Pulg.]", "width", GridItemsCortados);
            AGREGAR_COLUMN_GRID("lenght", 60, "Lenght [Pies]", "large", GridItemsCortados);
            AGREGAR_COLUMN_GRID("msi", 60, "Msi.", "msi", GridItemsCortados);
            AGREGAR_COLUMN_GRID("unique_code", 60, "Unique Code", "unique_code", GridItemsCortados);
            AGREGAR_COLUMN_GRID("splice", 50, "Splice", "splice", GridItemsCortados);
            AGREGAR_COLUMN_GRID("code_person", 60, "Code Person.", "code_person", GridItemsCortados);
            AGREGAR_COLUMN_GRID("status", 60, "Status", "status", GridItemsCortados);
            AGREGAR_COLUMN_GRID("ubic", 60, "Ubicacion", "ubic", GridItemsCortados);
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
        private void BOT_UPDATE_INVENTARIO_Click(object sender, EventArgs e)
        {
            dtinventario = inimanager.CargarInventario();
            dvinventario = dtinventario.DefaultView;
        }
        private void Bot_cargar_Click(object sender, EventArgs e)
        {
            LOAD_DATA_MASTER();
        }
        private void LOAD_DATA_MASTER() 
        {
            GridItemsMaster.Columns.Clear();
            recemanager.ds.Tables["dtrecepcion"].Clear();
            recemanager.ds.Tables["dtrecepcion"].AcceptChanges();
            recemanager.LoadRecepciones(2);
            var mytable = recemanager.ds.Tables["dtrecepcion"].DefaultView.ToTable();
            DvGeneral = mytable.DefaultView;
            GridItemsMaster.AutoGenerateColumns = false;
            AplicarEstilosMaster();
            GridItemsMaster.DataSource = DvGeneral;
            TXT_RECORDS.Text = DvGeneral.Count.ToString();
            SET_MAGEN_COLUM_STATUS(GridItemsMaster);
        }
        private void Bot_buscar_Click(object sender, EventArgs e)
        {
            if (RA_PRODUCTID.Checked)
            {
                if (string.IsNullOrEmpty(TXT_SEARCH_WIDTH_MASTER.Text)) 
                {
                    DvGeneral.RowFilter = "part_number LIKE '%" + this.txt_buscar.Text + "%'";
                }
                else 
                {
                    DvGeneral.RowFilter = "part_number LIKE '%" + this.txt_buscar.Text.Trim() + "%' " +
                        "AND width = " + this.TXT_SEARCH_WIDTH_MASTER.Text;
                }
            }
            if (RA_PRODUCTNAME.Checked)
            {
                DvGeneral.RowFilter = "product_name LIKE '%" + this.txt_buscar.Text + "%'";
            }
            if (RA_ROLLID.Checked)
            {
                DvGeneral.RowFilter = "roll_id LIKE '%" + this.txt_buscar.Text + "%'";
            }
            FOUND_COUNTER.Text = DvGeneral.Count.ToString() + " ENCONTRADOS.";
            SET_MAGEN_COLUM_STATUS(GridItemsMaster);
        }

        private void Txt_buscar_TextChanged_1(object sender, EventArgs e)
        {
            if (txt_buscar.Text.Length == 0)
            {
                DvGeneral.RowFilter = "";
                FOUND_COUNTER.Text = "0 ENCONTRADOS.";
            }
        }
        private void Botcarga_hoj_Click(object sender, EventArgs e)
        {
            LOAD_DATA_HOJAS();
        }
        private void LOAD_DATA_HOJAS() 
        {
            GridItemHojas.Columns.Clear();
            recemanager.ds.Tables["dtrecepcion"].Clear();
            recemanager.ds.Tables["dtrecepcion"].AcceptChanges();
            recemanager.LoadRecepciones(3);
            var mytable = recemanager.ds.Tables["dtrecepcion"].DefaultView.ToTable();
            DvHojas = mytable.DefaultView;
            GridItemHojas.AutoGenerateColumns = false;
            AplicarEstilosHojas();
            GridItemHojas.DataSource = DvHojas;
            TXT_RECORDNUMBER_HOJ.Text = DvHojas.Count.ToString();
            SET_MAGEN_COLUM_STATUS(GridItemHojas);
        }

        private void Botbuscar_hoj_Click(object sender, EventArgs e)
        {
            if (RACODIGO_HOJ.Checked)
            {
                if (string.IsNullOrEmpty(TXT_SEARCH_WIDTH_HOJA.Text)) 
                {
                    DvHojas.RowFilter = "part_number LIKE '%" + this.txtbuscar_hoj.Text + "%'";
                }
                else 
                {
                    DvHojas.RowFilter = "part_number LIKE '%" + this.txtbuscar_hoj.Text.Trim() + "%' " +
                            "AND width = " + this.TXT_SEARCH_WIDTH_HOJA.Text;
                }


                
            }
            if (RAPRODUCTNAME_HOJ.Checked)
            {
                DvHojas.RowFilter = "product_name LIKE '%" + this.txtbuscar_hoj.Text + "%'";
            }
            if (RAROLLID_HOJ.Checked)
            {
                DvHojas.RowFilter = "roll_id LIKE '%" + this.txtbuscar_hoj.Text + "%'";
            }
            FOUND_HOJAS.Text = DvHojas.Count.ToString() + " ENCONTRADOS.";
            SET_MAGEN_COLUM_STATUS(GridItemHojas);
        }

        private void Botcargar_gra_Click(object sender, EventArgs e)
        {
            LOAD_DATA_GRAPHICS();
        }
        private void LOAD_DATA_GRAPHICS() 
        {
            GridItemGraphics.Columns.Clear();
            recemanager.ds.Tables["dtrecepcion"].Clear();
            recemanager.ds.Tables["dtrecepcion"].AcceptChanges();
            recemanager.LoadRecepciones(4);
            var mytable = recemanager.ds.Tables["dtrecepcion"].DefaultView.ToTable();
            DvGraphics = mytable.DefaultView;
            GridItemGraphics.AutoGenerateColumns = false;
            AplicarEstilosGraphics();
            GridItemGraphics.DataSource = DvGraphics;
            TXTRECORD_GRA.Text = DvGraphics.Count.ToString();
            SET_MAGEN_COLUM_STATUS(GridItemGraphics);
        }

        private void Botbuscar_gra_Click(object sender, EventArgs e)
        {
            if (RA_PRODUCTID_GRA.Checked)
            {
                if (string.IsNullOrEmpty(TXT_SEARCH_WIDTH_GRAP.Text)) 
                {
                    DvGraphics.RowFilter = "part_number LIKE '%" + this.txtbuscar_gra.Text + "%'";
                }
                else 
                {
                    DvGraphics.RowFilter = "part_number LIKE '%" + this.txtbuscar_cor.Text.Trim() + "%' " +
                            "AND width = " + this.TXT_SEARCH_WIDTH_GRAP.Text;
                }     
            }
            if (RA_PRODUCTNAME_GRA.Checked)
            {
                DvGraphics.RowFilter = "product_name LIKE '%" + this.txtbuscar_gra.Text + "%'";
            }
            if (RA_ROLLID_GRA.Checked)
            {
                DvGraphics.RowFilter = "roll_id LIKE '%" + this.txtbuscar_gra.Text + "%'";
            }
            RECORD_FOUND_GRA.Text = DvGraphics.Count.ToString() + " ENCONTRADOS.";
            SET_MAGEN_COLUM_STATUS(GridItemGraphics);

        }

        private void Bot_cargar_cor_Click(object sender, EventArgs e)
        {
            LOAD_DATA_ROLLS();
        }
        private void LOAD_DATA_ROLLS() 
        {
            GridItemsCortados.Columns.Clear();
            DataTable dtrolls = promanager.LoadRolls();
            DvRolls = dtrolls.DefaultView;
            GridItemsCortados.AutoGenerateColumns = false;
            AplicarEstilosCortados();
            GridItemsCortados.DataSource = DvRolls;
            TXTRECORDNUMBER_COR.Text = DvRolls.Count.ToString();
            SET_MAGEN_COLUM_STATUS(GridItemsCortados);
            TXT_SELECT_NUMBER.Text = string.Empty;
            CHK_SELECT_ALL.Checked = false;
            txtbuscar_cor.Text = string.Empty;
            txt_wid_search.Text = string.Empty;
        }

        private void SET_MAGEN_COLUM_STATUS(DataGridView dg) 
        {
            foreach (DataGridViewRow row in dg.Rows)
            {
                //producto reservado
                DataGridViewCell cell = row.Cells["status"];
                if (cell.Value.ToString() == "Reservado")
                {
                    row.Cells["ColumnImage"].Value = (System.Drawing.Image)Properties.Resources.red_flag;
                }
                else
                {
                    row.Cells["ColumnImage"].Value = null;
                }
                //master cargado en documento. (SOLO SE EJECUTA EN LA PESTAÑA DE MASTERS)
                int page_active = TABINVENTARIO.SelectedIndex;
                if(page_active == 0) 
                {
                    DataGridViewCell CellLoad = row.Cells["master_load"];
                    if (CellLoad.Value.ToString() == "") return;
                    if (Convert.ToBoolean(CellLoad.Value) == true)
                    {
                        row.Cells["ColumnImage"].Value = (System.Drawing.Image)Properties.Resources.key_icon;
                    }
                }
                
                
                


            }
        }

        private void Bot_buscar_cor_Click(object sender, EventArgs e)
        {
            if (RA_PRODUCTID_COR.Checked)
            {
                if (string.IsNullOrEmpty(txt_wid_search.Text)) 
                {
                    DvRolls.RowFilter = "product_id LIKE '%" + this.txtbuscar_cor.Text.Trim() + "%'";
                }
                else 
                {
                    DvRolls.RowFilter = "product_id LIKE '%" + this.txtbuscar_cor.Text.Trim() + "%' " +
                        "AND width = "  + this.txt_wid_search.Text ;
                }
                
            }
            if (RA_PRODUCTNAME_COR.Checked)
            {
                DvRolls.RowFilter = "product_name LIKE '%" + this.txtbuscar_cor.Text + "%'";
            }
            if (RA_ROLLID_COR.Checked)
            {
                DvRolls.RowFilter = "roll_id LIKE '%" + this.txtbuscar_cor.Text + "%'";
            }
            if (RA_UNIQUE_CODE_COR.Checked)
            {
                DvRolls.RowFilter = "unique_code LIKE '%" + this.txtbuscar_cor.Text + "%'";
            }
            //BUSQUEDA POR UBICACION
            if (!string.IsNullOrEmpty(txt_ubic.Text))
            {
                DvRolls.RowFilter = "ubic LIKE '%" + this.txt_ubic.Text.Trim() + "%'";
            }
            RECORDFOUND_COR.Text = DvRolls.Count.ToString() + " ENCONTRADOS.";
            if (GridItemsCortados.Rows.Count == 0)
            {
                return;
            }
            DataGridViewRow item = GridItemsCortados.Rows[0];
            if(item == null) 
            {
                return;
            }
            item.Selected = false;
            SET_MAGEN_COLUM_STATUS(GridItemsCortados);
        }

        private void Txtbuscar_hoj_TextChanged(object sender, EventArgs e)
     {
            if (txtbuscar_hoj.Text.Length == 0)
            {
                DvHojas.RowFilter = "";
                FOUND_HOJAS.Text = "0 ENCONTRADOS.";
            }
        }

        private void Txtbuscar_gra_TextChanged(object sender, EventArgs e)
        {
            if (txtbuscar_gra.Text.Length == 0)
            {
                DvGraphics.RowFilter = "";
                RECORD_FOUND_GRA.Text = "0 ENCONTRADOS.";
            }
        }

        private void Txtbuscar_cor_TextChanged(object sender, EventArgs e)
        {
            if (txtbuscar_cor.Text.Length == 0)
            {
                DvRolls.RowFilter = "";
                RECORD_FOUND_GRA.Text = "0 ENCONTRADOS.";
            }
        }
        private void TXT_SELECT_NUMBER_TextChanged(object sender, EventArgs e)
        {
            SELECCIONAR_NUMERO_RESERVA(TXT_SELECT_NUMBER, GridItemsCortados);
        }

        private void TXT_SELECT_NUMBER_KeyPress(object sender, KeyPressEventArgs e)
        {
            string CaracValid = "0123456789";
            if (e.KeyChar != Convert.ToChar(8) && CaracValid.IndexOf(e.KeyChar) == -1)
            {
                // si no es bakcspace y no es un numero se omite.   
                e.Handled = true;
            }
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            SELECT_ALL_ROWS_RESERVA(CHK_SELECT_ALL, GridItemsCortados);
        }

        private void BOT_RESERVA_Click(object sender, EventArgs e)
        {
            
        }
        private void TXT_RESER_CANT_MASTER_TextChanged(object sender, EventArgs e)
        {
            SELECCIONAR_NUMERO_RESERVA(TXT_RESER_CANT_MASTER, GridItemsMaster);
        }
        private void Chk_select_all_master_CheckedChanged(object sender, EventArgs e)
        {
            SELECT_ALL_ROWS_RESERVA(chk_select_all_master, GridItemsMaster);
        }
        private void SELECCIONAR_NUMERO_RESERVA(TextBox tb, DataGridView grid)
        {
            if (string.IsNullOrEmpty(tb.Text))
            {
                return;
            }
            int SelectNumber = Convert.ToInt16(tb.Text);
            foreach (DataGridViewRow item in grid.Rows)
            {
                item.Selected = false;
            }
            if (SelectNumber > grid.Rows.Count) 
            {
                MessageBox.Show("el numero suministrado es mayor que la lista de seleccionados...");
                tb.Text = "";
                return;
            }
            for (int i = 1; i <= SelectNumber; i++)
            {
                if (grid.Rows[i-1].Cells["status"].Value.ToString() != "Reservado") 
                {
                    grid.Rows[i - 1].Selected = true;
                }
            }
        }
        private void SELECT_ALL_ROWS_RESERVA(CheckBox cb, DataGridView grid)
        {
            if (cb.Checked)
            {
                for (int i = 1; i <= grid.Rows.Count; i++)
                {
                    if (grid.Rows[i - 1].Cells["status"].Value.ToString() != "Reservado")
                    {
                        grid.Rows[i - 1].Selected = true;
                    }
                }
            }
            else
            {
                foreach (DataGridViewRow item in grid.Rows)
                {
                    item.Selected = false;
                }
            }
        }

        private void Txt_ReserCant_Hojas_TextChanged(object sender, EventArgs e)
        {
            SELECCIONAR_NUMERO_RESERVA(Txt_ReserCant_Hojas, GridItemHojas);
        }

        private void Chk_Select_All_Hojas_CheckedChanged(object sender, EventArgs e)
        {
            SELECT_ALL_ROWS_RESERVA(Chk_Select_All_Hojas, GridItemHojas);
        }

        private void Txt_ReserCant_Graf_TextChanged(object sender, EventArgs e)
        {
            SELECCIONAR_NUMERO_RESERVA(Txt_ReserCant_Graf, GridItemGraphics);
        }

        private void Chk_Select_All_Graf_CheckedChanged(object sender, EventArgs e)
        {
            SELECT_ALL_ROWS_RESERVA(Chk_Select_All_Graf, GridItemGraphics);
        }

        private void Link_menu1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int page_active = TABINVENTARIO.SelectedIndex;
            DataGridView dg;
            string nameid;
            int indexProd;
            switch (page_active) 
            {
                case 0:
                    //procedimiento para los master
                    dg = GridItemsMaster;
                    nameid = "roll_id";
                    indexProd = 0;
                    if (dg.SelectedRows.Count == 0)
                    {
                        MessageBox.Show("no se puede crear un documento de reserva si no tiene registros seleccionados...");
                        return;
                    }
                    PROC_RESERVA_PRODUCTS(dg, nameid, indexProd);
                    LOAD_DATA_MASTER();
                    break;
                case 1:
                    //procedimiento para los hojas
                    dg = GridItemHojas;
                    nameid = "roll_id";
                    indexProd = 1;
                    if (dg.SelectedRows.Count == 0)
                    {
                        MessageBox.Show("no se puede crear un documento de reserva si no tiene registros seleccionados...");
                        return;
                    }
                    PROC_RESERVA_PRODUCTS(dg, nameid, indexProd);
                    LOAD_DATA_HOJAS();
                    break;
                case 2:
                    //procedimiento para los graphics
                    dg = GridItemGraphics;
                    nameid = "roll_id";
                    indexProd = 2;
                    if (dg.SelectedRows.Count == 0)
                    {
                        MessageBox.Show("no se puede crear un documento de reserva si no tiene registros seleccionados...");
                        return;
                    }
                    PROC_RESERVA_PRODUCTS(dg, nameid, indexProd);
                    LOAD_DATA_GRAPHICS();
                    break;
                case 3:
                    //procedimiento para los rollos cortados
                    dg = GridItemsCortados;
                    nameid = "unique_code";
                    indexProd = 3;
                    if (dg.SelectedRows.Count == 0)
                    {
                        MessageBox.Show("no se puede crear un documento de reserva si no tiene registros seleccionados...");
                        return;
                    }
                    PROC_RESERVA_PRODUCTS(dg,nameid,indexProd);
                    LOAD_DATA_ROLLS();
                    break;
            }  
            
        }
        private void PROC_RESERVA_PRODUCTS(DataGridView dg,string name_id,int idx_produt) 
        {
            //buscar las filas seleccionadas.
            List<string> ids = new List<string>();
            foreach (DataGridViewRow item in dg.SelectedRows)
            {
                string id = item.Cells[name_id].Value.ToString();
                ids.Add(id);


            }
            FrmReservas reserva = new FrmReservas
            {
                Dtcustomers = inimanager.GetCustomers(),
                NumTransac = Convert.ToInt16(configManager.GetParameterControl("CONS_RESER")),
                Ids = ids
            };
            reserva.ShowDialog();
            reserva.DocumReserva.IndexProduct = idx_produt;
            //procedimiento donde se guarda el documento de reserva
            inimanager.AddReserva(reserva.DocumReserva);
            //marcar los productos como reservados
            inimanager.MarkRowReserva(ids, idx_produt);
        }
        private void GridItemsCortados_SelectionChanged(object sender, EventArgs e)
        {
            PROTECT_SELECT_RESERVA(GridItemsCortados); 
        }        
        private void GridItemGraphics_SelectionChanged(object sender, EventArgs e)
        {
            PROTECT_SELECT_RESERVA(GridItemGraphics);
        }

        private void GridItemHojas_SelectionChanged(object sender, EventArgs e)
        {
            PROTECT_SELECT_RESERVA(GridItemHojas);
        }

      
        private void PROTECT_SELECT_RESERVA(DataGridView dg)
        {    
            if (dg.Columns.Contains("status") == true) 
            {
                if (dg.CurrentRow == null) 
                {
                    return;
                }
                int RowSelect = dg.CurrentRow.Index;
                if (dg.Rows[RowSelect].Cells["status"].Value.ToString() == "Reservado")
                {
                    dg.Rows[RowSelect].Selected = false;
                }
            }
        }

        private void GridItemsMaster_SelectionChanged(object sender, EventArgs e)
        {
            PROTECT_SELECT_RESERVA(GridItemsMaster);
        }

        private void Link_info_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int page_active = TABINVENTARIO.SelectedIndex;
            switch (page_active) 
            {
                case 0:
                    break;
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    int RowSelect = GridItemsCortados.CurrentRow.Index;
                    string st = GridItemsCortados.Rows[RowSelect].Cells["status"].Value.ToString();
                    if (st == R.CONSTANTES.RESERVA_FLAG_TRUE) 
                    {
                        string code_id = GridItemsCortados.Rows[RowSelect].Cells[9].Value.ToString();
                        Reserva data = inimanager.GetInfoDocumReserva(code_id);
                        frmInfoReserva infodialog = new frmInfoReserva
                        {
                            DataInfo = data,
                            Code_id = code_id
                        };
                        infodialog.ShowDialog();
                        if (infodialog.DilogDeleteYes == true) 
                        {
                            // se borra registro de reserva.
                            inimanager.DeleteRenglonReserva(code_id);
                            // se desmarca del inicial.
                            bool result = inimanager.UnmarkItemReserva(code_id,page_active);
                            if (result) 
                            {
                                MessageBox.Show("Procesos realizado Exito.");
                                LOAD_DATA_ROLLS();
                            }
                            else 
                            {
                                MessageBox.Show("Sucedio algo inesperado, llame a sistemas");
                            }
                        }
                    }
                    else 
                    {
                        MessageBox.Show("Tiene que seleccionar un articulo reservado.");
                        return;
                    }           
                    break;
            }
        }
        private void Link_detele_reserva_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmGetOneValue formData = new FrmGetOneValue
            {
                Title_form = "Eliminar Documento Reserva:",
                Title_Textbox ="Introduzca Documento :"
                
            };
            formData.ShowDialog();
            if (string.IsNullOrEmpty(formData.DataValue)) 
            {
                return;
            }
            bool result = inimanager.DeleteDocumentReserva(formData.DataValue);
            if (result) 
            {
                MessageBox.Show("Operacion con Exito.");
            }
            else 
            {
                MessageBox.Show("Ocurrio un error.");
            }
            LOAD_DATA_ROLLS();
        }
        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //Reporte de reserva de productos 
            FrmPrintSelect DialogPrint = new FrmPrintSelect
            {
                Index_Report = 1,
                Report_Name = "Reporte Reserva de Productos"
            };
            DialogPrint.ShowDialog();
        }

        private void GridItemsMaster_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowselect = GridItemsMaster.CurrentRow.Index;
            MessageBox.Show("Numero de Orden de Corte :" + GridItemsMaster.Rows[rowselect].Cells["num_oc"].Value.ToString());
        }

        private void LinkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmUbicacionesAlmacen ubics = new FrmUbicacionesAlmacen();
            ubics.ShowDialog();
        }
    }
}
