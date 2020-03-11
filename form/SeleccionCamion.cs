using System;
using System.Data;
using System.Windows.Forms;

namespace RitramaAPP.form
{
    public partial class SeleccionCamion : Form
    {
        public SeleccionCamion()
        {
            InitializeComponent();
        }
        public DataTable dtcamion { get; set; }
        public string GetCamionPlaca { get; set; }
        public string GetCamionModelo { get; set; }
        DataView dv = new DataView();
        private void SeleccionCamion_Load(object sender, EventArgs e)
        {
            dv = dtcamion.DefaultView;
            grid_items.AutoGenerateColumns = false;
            AGREGAR_COLUMN_GRID("placas_id", 75, "Placas", "placas_id");
            AGREGAR_COLUMN_GRID("camion_name", 200, "Modelo", "camion_name");
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
                dv.RowFilter = "PLACAS_ID LIKE '%" + this.txt_buscar.Text + "%'";
            }
            if (RA_PLACAS.Checked)
            {
                dv.RowFilter = "Camion_Name LIKE '%" + this.txt_buscar.Text + "%'";
            }
            CONTADOR_REGISTROS.Text = Convert.ToString(dv.Count) + " registros encontrados.";
        }

        private void grid_items_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            GetCamionPlaca = grid_items.Rows[e.RowIndex].Cells[0].Value.ToString();
            GetCamionModelo = grid_items.Rows[e.RowIndex].Cells[1].Value.ToString();
            this.Close();
        }
    }
}
