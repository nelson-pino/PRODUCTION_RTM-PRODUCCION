using System;
using System.Data;
using System.Windows.Forms;

namespace RitramaAPP.form
{
    public partial class SeleccionProveedores : Form
    {
        public SeleccionProveedores()
        {
            InitializeComponent();
        }
        public DataTable dtsupply { get; set; }
        public string itemSelected { get; set; }
        public string GetProviderID { get; set; }
        public string GetProviderName { get; set; }
        DataView dv = new DataView();
        private void SeleccionProveedores_Load(object sender, EventArgs e)
        {
            dv = dtsupply.DefaultView;
            grid_providers.AutoGenerateColumns = false;
            DataGridViewTextBoxColumn col1 = new DataGridViewTextBoxColumn();
            col1.Name = "id_provider";
            col1.Width = 75;
            col1.HeaderText = "Codigo";
            col1.DataPropertyName = "Proveedor_ID";
            grid_providers.Columns.Add(col1);
            DataGridViewTextBoxColumn col2 = new DataGridViewTextBoxColumn();
            col2.Name = "provider_name";
            col2.Width = 390;
            col2.HeaderText = "Nombre del Proveedor";
            col2.DataPropertyName = "Proveedor_Name";
            grid_providers.Columns.Add(col2);
            dv.RowFilter = "";
            grid_providers.DataSource = dv;
            lbl_contador_registros.Text = Convert.ToString(dv.Count) + " registros encontrados.";
        }

        private void Txt_buscar_TextChanged(object sender, EventArgs e)
        {
            if (rad_codigo.Checked)
            {
                dv.RowFilter = "Proveedor_ID LIKE '%" + this.txt_buscar.Text + "%'";
            }
            if (rad_nombre.Checked)
            {
                dv.RowFilter = "Proveedor_Name LIKE '%" + this.txt_buscar.Text + "%'";
            }
            lbl_contador_registros.Text = Convert.ToString(dv.Count) + " registros encontrados.";
        }

        private void Grid_providers_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            GetProviderID = grid_providers.Rows[e.RowIndex].Cells[0].Value.ToString();
            GetProviderName = grid_providers.Rows[e.RowIndex].Cells[1].Value.ToString();
            itemSelected = grid_providers.Rows[e.RowIndex].Cells[0].Value.ToString();
            this.Close();
        }
    }
}
