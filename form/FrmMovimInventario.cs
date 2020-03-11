using RitramaAPP.Clases;
using System;
using System.Windows.Forms;

namespace RitramaAPP.form
{
    public partial class FrmMovimInventario : Form
    {
        public FrmMovimInventario()
        {
            InitializeComponent();
        }
        InventarioManager manager = new InventarioManager();
        public string SetProduct_Id { get; set; }
        public string SetProduct_Name { get; set; }
        public string SetProduct_Tipo { get; set; }
        int productTipo = 0;
        string rollid = "";
        private void FrmMovimInventario_Load(object sender, EventArgs e)
        {
            SelectProductTipo();
            product_id.Text = "Product Id.:" + SetProduct_Id;
            product_name.Text = "Nombre del Producto :" + SetProduct_Name;
            product_tipo.Text = "Tipo Producto :" + SetProduct_Tipo;
            FORMAT_DATAGRID();
            double totlenght_ent = 0;
            int rowsent = 0;
            for (int i = 0; i <= grid_entradas.Rows.Count - 1; i++)
            {
                totlenght_ent += Convert.ToDouble(grid_entradas.Rows[i].Cells[6].Value);
                grid_entradas.Rows[i].Cells[8].Value = Convert.ToDouble(grid_entradas.Rows[i].Cells[6].Value)
                - Convert.ToDouble(grid_entradas.Rows[i].Cells[7].Value);
                rowsent += 1;
            }
            TOTAL_LEN_ENT.Text = totlenght_ent.ToString();
            TXT_COUNT_ENT.Text = rowsent.ToString();
        }
        private void FORMAT_DATAGRID()
        {
            switch (productTipo)
            {
                //master
                case 1:
                    //se buscan las entradas en las recepciones. 
                    FORMAT_GRIDS_MASTER();
                    grid_entradas.DataSource = manager.CargarMovimientoEntradaMaster(SetProduct_Id);
                    break;
                case 2:
                    //rollo cortado
                    FORMAT_ROLLO_CORTADO();
                    grid_entradas.DataSource = manager.CargaMovimientoEntradaRollosCortados(SetProduct_Id);
                    grid_salidas.DataSource = manager.CargaMovimientoSalidasRollosCortados(SetProduct_Id);

                    break;
                case 3:

                    break;
                case 4:

                    break;
            }
        }
        private void SelectProductTipo()
        {
            switch (SetProduct_Tipo)
            {
                case "Master":
                    productTipo = 1;
                    break;
                case "Rollo Cortado":
                    productTipo = 2;
                    break;
                case "Graphics":
                    productTipo = 3;
                    break;
                case "Hojas":
                    productTipo = 4;
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
        private void FORMAT_GRIDS_MASTER()
        {
            //grid entrada
            grid_entradas.AutoGenerateColumns = false;
            AGREGAR_COLUMN_GRID("numdoc", 60, "Recepcion", "OrderPurchase", grid_entradas);
            AGREGAR_COLUMN_GRID("fecha", 80, "Fecha", "fecha_reg", grid_entradas);
            AGREGAR_COLUMN_GRID("embarque", 60, "Embarque", "embarque", grid_entradas);
            AGREGAR_COLUMN_GRID("rollid", 80, "Roll Id.", "Roll_Id", grid_entradas);
            AGREGAR_COLUMN_GRID("prov", 180, "Nombre del Proveedor", "Proveedor_Name", grid_entradas);
            AGREGAR_COLUMN_GRID("width", 60, "Width", "width", grid_entradas);
            AGREGAR_COLUMN_GRID("lenght", 55, "Lenght", "lenght", grid_entradas);
            AGREGAR_COLUMN_GRID("consumo", 55, "Consumo", "consumo", grid_entradas);
            AGREGAR_COLUMN_GRID("restan", 55, "Restan", "restan", grid_entradas);

            AGREGAR_COLUMN_GRID("splice", 50, "Splice", "splice", grid_entradas);
            AGREGAR_COLUMN_GRID("core", 50, "Core", "core", grid_entradas);
            AGREGAR_COLUMN_GRID("ubic", 50, "Ubicacion", "Ubicacion", grid_entradas);
            //grid salida
            grid_salidas.AutoGenerateColumns = false;
            AGREGAR_COLUMN_GRID("numeroc", 45, "Or. Corte", "numero", grid_salidas);
            AGREGAR_COLUMN_GRID("fechaoc", 60, "Fecha", "fecha", grid_salidas);
            AGREGAR_COLUMN_GRID("width", 60, "Width", "util1_real_width", grid_salidas);
            AGREGAR_COLUMN_GRID("lenght", 60, "Lenght", "util1_real_lenght", grid_salidas);
            AGREGAR_COLUMN_GRID("msi", 60, "Msi", "", grid_salidas);
            AGREGAR_COLUMN_GRID("descar", 50, "Desc.", "decartable1_pies", grid_salidas);
            AGREGAR_COLUMN_GRID("tot_consumo", 70, "Total ", "total_con", grid_salidas);
            AGREGAR_COLUMN_GRID("rollos", 50, "Rollos", "cant_rollos", grid_salidas);

            AGREGAR_COLUMN_GRID("width2", 60, "Width 2", "util2_real_width", grid_salidas);
            AGREGAR_COLUMN_GRID("lenght2", 60, "Lenght 2", "util2_real_lenght", grid_salidas);
            AGREGAR_COLUMN_GRID("msi2", 60, "Msi 2", "msi2", grid_salidas);
            AGREGAR_COLUMN_GRID("descar2", 60, "Desc. 2", "descartable2_pies", grid_salidas);
            AGREGAR_COLUMN_GRID("tot_consumo2", 60, "Total 2", "total_con2", grid_salidas);
        }
        private void FORMAT_ROLLO_CORTADO()
        {
            grid_entradas.AutoGenerateColumns = false;
            AGREGAR_COLUMN_GRID("oc", 60, "Orden Corte", "numero", grid_entradas);
            AGREGAR_COLUMN_GRID("fecha", 80, "Fecha", "fecha", grid_entradas);
            AGREGAR_COLUMN_GRID("roll#", 60, "Roll #", "roll_number", grid_entradas);
            AGREGAR_COLUMN_GRID("code_unique", 60, "Code Unique", "unique_code", grid_entradas);
            AGREGAR_COLUMN_GRID("width", 65, "Width", "width", grid_entradas);
            AGREGAR_COLUMN_GRID("lenght", 65, "Lenght", "large", grid_entradas);
            AGREGAR_COLUMN_GRID("msi", 65, "Msi", "msi", grid_entradas);
            AGREGAR_COLUMN_GRID("splice", 60, "Splice", "splice", grid_entradas);
            AGREGAR_COLUMN_GRID("rollid", 60, "Roll Id.", "roll_id", grid_entradas);
            AGREGAR_COLUMN_GRID("code_perso", 60, "Codigo Person.", "code_person", grid_entradas);
            AGREGAR_COLUMN_GRID("status", 60, "Status.", "status", grid_entradas);
            grid_salidas.AutoGenerateColumns = false;
            AGREGAR_COLUMN_GRID("conduce", 65, "Numero Conduce", "conduce", grid_salidas);
            AGREGAR_COLUMN_GRID("fecha", 65, "Fecha Conduce", "fecha", grid_salidas);
            AGREGAR_COLUMN_GRID("code_unique", 80, "Codigo Unico", "unique_code", grid_salidas);
            AGREGAR_COLUMN_GRID("width", 70, "Width", "util1_real_width", grid_salidas);
            AGREGAR_COLUMN_GRID("lenght", 70, "Lenght", "util1_real_lenght", grid_salidas);
            AGREGAR_COLUMN_GRID("msi", 70, "Msi", "msi", grid_salidas);
            AGREGAR_COLUMN_GRID("splice", 70, "Splice", "splice", grid_salidas);
            AGREGAR_COLUMN_GRID("rollid", 80, "Roll Id.", "roll_id", grid_salidas);
            AGREGAR_COLUMN_GRID("Customer_Name", 120, "Nombre del Cliente", "Customer_Name", grid_salidas);



        }

        private void bot_buscar_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void grid_salidas_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void grid_entradas_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void grid_entradas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            rollid = grid_entradas.Rows[e.RowIndex].Cells[3].Value.ToString();
            grid_salidas.DataSource = manager.LoadMoveSalidasMaster(rollid);
            int rowsal = 0;
            double totlenght_sal = 0;
            for (int i = 0; i <= grid_salidas.Rows.Count - 1; i++)
            {
                grid_salidas.Rows[i].Cells["msi"].Value = Convert.ToDouble(grid_salidas.Rows[i].Cells["width"].Value) *
                    Convert.ToDouble(grid_salidas.Rows[i].Cells["lenght"].Value) * R.CONSTANTES.FACTOR_CALCULO_MSI;

                grid_salidas.Rows[i].Cells["msi2"].Value = Convert.ToDouble(grid_salidas.Rows[i].Cells["width2"].Value) *
                   Convert.ToDouble(grid_salidas.Rows[i].Cells["lenght2"].Value) * R.CONSTANTES.FACTOR_CALCULO_MSI;

                totlenght_sal += Convert.ToDouble(grid_salidas.Rows[i].Cells["tot_consumo"].Value) +
                    Convert.ToDouble(grid_salidas.Rows[i].Cells["tot_consumo2"].Value);
                rowsal += 1;
            }
            TXT_COUNT_SAL.Text = rowsal.ToString();
            TXT_LENGHT_SAL.Text = totlenght_sal.ToString();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
