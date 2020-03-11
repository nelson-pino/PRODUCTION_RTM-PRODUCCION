using System;
using System.Data;
using System.Windows.Forms;

namespace RitramaAPP.form
{
    public partial class SeleccionVendedores : Form
    {
        public SeleccionVendedores()
        {
            InitializeComponent();
        }
        public DataTable dtvendedor { get; set; }
        public string GetVendedorId { get; set; }
        public string GetVendedorName { get; set; }
        DataView dv = new DataView();
        private void SeleccionVendedores_Load(object sender, EventArgs e)
        {
            dv = dtvendedor.DefaultView;
            grid_items.AutoGenerateColumns = false;
            AGREGAR_COLUMN_GRID("vendor_id", 75, "Vend. Id.", "vendor_id");
            AGREGAR_COLUMN_GRID("vendor_name", 2000, "Nombre del Vendedor", "vendor_name");
            grid_items.DataSource = dv;
            CONTADOR_REGISTROS.Text = Convert.ToString(dv.Count) + " registros encontrados.";
        }
        private void AGREGAR_COLUMN_GRID(string name, int size, string title, string field_bd)
        {
            DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn
            {
                Name = name,
                Width = size,
                HeaderText = title,
                DataPropertyName = field_bd
            };
            grid_items.Columns.Add(col);
        }

        private void txt_buscar_TextChanged(object sender, EventArgs e)
        {
            if (RA_CODIGO.Checked)
            {
                dv.RowFilter = "vendor_id LIKE '%" + this.txt_buscar.Text + "%'";
            }
            if (RA_NOMBRE_VENDEDOR.Checked)
            {
                dv.RowFilter = "vendor_name LIKE '%" + this.txt_buscar.Text + "%'";
            }
            CONTADOR_REGISTROS.Text = Convert.ToString(dv.Count) + " registros encontrados.";
        }

        private void grid_items_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            GetVendedorId = grid_items.Rows[e.RowIndex].Cells[0].Value.ToString();
            GetVendedorName = grid_items.Rows[e.RowIndex].Cells[1].Value.ToString();
            this.Close();
        }
    }
}
