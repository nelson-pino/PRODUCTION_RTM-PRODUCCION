using RitramaAPP.Clases;
using RitramaAPP.form;
using System;
using System.Collections.Generic;
using System.Data;
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
            AGREGAR_COLUMN_GRID("doc", 63, "Numero Documento", "OrderPurchase", GridItemsMaster);
            AGREGAR_COLUMN_GRID("product_id", 60, "Codigo Producto", "Part_Number", GridItemsMaster);
            AGREGAR_COLUMN_GRID("product_name", 220, "Descripcion del Producto", "product_name", GridItemsMaster);
            AGREGAR_COLUMN_GRID("roll_id", 70, "Roll ID.", "roll_id", GridItemsMaster);
            AGREGAR_COLUMN_GRID("width", 70, "Width [Pulg.]", "width", GridItemsMaster);
            AGREGAR_COLUMN_GRID("lenght", 70, "Lenght [Pulg.]", "lenght", GridItemsMaster);
            AGREGAR_COLUMN_GRID("lenght_p", 70, "L. Restan [Pulg.]", "lenght_p", GridItemsMaster);
            AGREGAR_COLUMN_GRID("lenght_c", 70, "Consumos PArciales", "lenght_c", GridItemsMaster);
            AGREGAR_COLUMN_GRID("width_metros", 70, "Width [Mts.]", "width_metros", GridItemsMaster);
            AGREGAR_COLUMN_GRID("lenght_metros", 70, "Lenght [Mts.]", "lenght_metros", GridItemsMaster);
            AGREGAR_COLUMN_GRID("splice", 70, "# Empalmes", "splice", GridItemsMaster);
        }
        
        private void AplicarEstilosHojas()
        {
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
        }
        private void AplicarEstilosGraphics()
        {
            AGREGAR_COLUMN_GRID("doc", 65, "Numero Documento", "OrderPurchase", GridItemGraphics);
            AGREGAR_COLUMN_GRID("product_id", 60, "Codigo Producto", "part_number", GridItemGraphics);
            AGREGAR_COLUMN_GRID("product_name", 230, "Descripcion del Producto", "product_name", GridItemGraphics);
            AGREGAR_COLUMN_GRID("roll_id", 75, "ID Hojas", "roll_id", GridItemGraphics);
            AGREGAR_COLUMN_GRID("palet_num", 75, "Numero Paleta", "palet_num", GridItemGraphics);
            AGREGAR_COLUMN_GRID("anchomm", 75, "Ancho MM", "width", GridItemGraphics);
            AGREGAR_COLUMN_GRID("m2", 75, "M2", "lenght", GridItemGraphics);
            AGREGAR_COLUMN_GRID("Numero", 100, "Numero Recepcion", "embarque", GridItemGraphics);
        }
        private void AplicarEstilosCortados()
        {
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
        }

        private void Bot_buscar_Click(object sender, EventArgs e)
        {
            if (RA_PRODUCTID.Checked)
            {
                DvGeneral.RowFilter = "part_number LIKE '%" + this.txt_buscar.Text + "%'";
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
        }

        private void Botbuscar_hoj_Click(object sender, EventArgs e)
        {
            if (RACODIGO_HOJ.Checked)
            {
                DvHojas.RowFilter = "part_number LIKE '%" + this.txtbuscar_hoj.Text + "%'";
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
        }

        private void Botcargar_gra_Click(object sender, EventArgs e)
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
        }

        private void Botbuscar_gra_Click(object sender, EventArgs e)
        {
            if (RA_PRODUCTID_GRA.Checked)
            {
                DvGraphics.RowFilter = "part_number LIKE '%" + this.txtbuscar_gra.Text + "%'";
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
        }

        private void Bot_cargar_cor_Click(object sender, EventArgs e)
        {
            GridItemsCortados.Columns.Clear();
            DataTable dtrolls = promanager.LoadRolls();
            DvRolls = dtrolls.DefaultView;
            GridItemsCortados.AutoGenerateColumns = false;
            AplicarEstilosCortados();
            GridItemsCortados.DataSource = DvRolls;
            TXTRECORDNUMBER_COR.Text = DvRolls.Count.ToString();
        }

        private void Bot_buscar_cor_Click(object sender, EventArgs e)
        {
            if (RA_PRODUCTID_COR.Checked)
            {
                DvRolls.RowFilter = "product_id LIKE '%" + this.txtbuscar_cor.Text + "%'";
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
            RECORDFOUND_COR.Text = DvRolls.Count.ToString() + " ENCONTRADOS.";
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
    }
}
