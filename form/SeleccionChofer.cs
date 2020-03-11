using System;
using System.Data;
using System.Windows.Forms;

namespace RitramaAPP.form
{
    public partial class SeleccionChofer : Form
    {
        public SeleccionChofer()
        {
            InitializeComponent();
        }
        public DataTable dtchofer { get; set; }
        public string GetChoferId { get; set; }
        public string GetChoferName { get; set; }
        DataView dv = new DataView();
        private void SeleccionChofer_Load(object sender, EventArgs e)
        {
            dv = dtchofer.DefaultView;
            grid_items.AutoGenerateColumns = false;
            AGREGAR_COLUMN_GRID("chofer_id", 60, "Chofer Id.", "chofer_id");
            AGREGAR_COLUMN_GRID("chofer_name", 200, "Nombre chofer", "chofer_name");
            grid_items.DataSource = dv;
            lbl_contador_registros.Text = Convert.ToString(dv.Count) + " registros encontrados.";
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
            if (rad_codigo.Checked)
            {
                dv.RowFilter = "transport_id LIKE '%" + this.txt_buscar.Text + "%'";
            }
            if (rad_producto.Checked)
            {
                dv.RowFilter = "transport_name LIKE '%" + this.txt_buscar.Text + "%'";
            }
            lbl_contador_registros.Text = Convert.ToString(dv.Count) + " registros encontrados.";
        }

        private void grid_items_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            GetChoferId = grid_items.Rows[e.RowIndex].Cells[0].Value.ToString();
            GetChoferName = grid_items.Rows[e.RowIndex].Cells[1].Value.ToString();
            this.Close();
        }
    }
}
