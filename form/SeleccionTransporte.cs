using System;
using System.Data;
using System.Windows.Forms;

namespace RitramaAPP.form
{
    public partial class SeleccionTransporte : Form
    {
        public SeleccionTransporte()
        {
            InitializeComponent();
        }
        public DataTable dttransporte { get; set; }
        public string GetTransporteId { get; set; }
        public string GetTransporteName { get; set; }
        DataView dv = new DataView();
        private void SeleccionTransporte_Load(object sender, EventArgs e)
        {
            dv = dttransporte.DefaultView;
            grid_items.AutoGenerateColumns = false;
            AGREGAR_COLUMN_GRID("transport_id", 75, "Trans. Id.", "transport_id");
            AGREGAR_COLUMN_GRID("transport_name", 2000, "Nombre transporte", "transport_name");
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
                dv.RowFilter = "transport_id LIKE '%" + this.txt_buscar.Text + "%'";
            }
            if (RA_NOMBRE_VENDEDOR.Checked)
            {
                dv.RowFilter = "transport_name LIKE '%" + this.txt_buscar.Text + "%'";
            }
            CONTADOR_REGISTROS.Text = Convert.ToString(dv.Count) + " registros encontrados.";
        }

        private void grid_items_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            GetTransporteId = grid_items.Rows[e.RowIndex].Cells[0].Value.ToString();
            GetTransporteName = grid_items.Rows[e.RowIndex].Cells[1].Value.ToString();
            this.Close();
        }
    }
}
