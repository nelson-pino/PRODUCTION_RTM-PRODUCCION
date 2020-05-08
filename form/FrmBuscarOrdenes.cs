using System;
using System.Data;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace RitramaAPP.form
{
    public partial class FrmBuscarOrdenes : Form
    {
        public DataTable Dtordenes { get; set; }
        public string Orden { get; set; }
        DataView dv = new DataView();
        public FrmBuscarOrdenes()
        {
            InitializeComponent();
        }
        private void FrmBuscarOrdenes_Load(object sender, EventArgs e)
        {
            dv = Dtordenes.DefaultView;
            dv.RowFilter = "";
            dv.Sort = "numero DESC";
            DarEstilosGrid();
            grid_ordenes.DataSource = dv;
            CONTADOR_REGISTRO.Text = "Numero de Registros: " + Convert.ToString(dv.Count);
        }
        private void DarEstilosGrid()
        {
            grid_ordenes.AutoGenerateColumns = false;

            COLUMNGRID_ADD("orden", 55, "Numero OC", "numero");
            COLUMNGRID_ADD("fecha", 70, "Fecha", "fecha");
            COLUMNGRID_ADD("product_id", 60, "Product Id", "product_id");
            COLUMNGRID_ADD("product_name", 120, "Nombre del Producto", "product_name");
            COLUMNGRID_ADD("rollos", 60, "Cant. Rollos", "cant_rollos");
            COLUMNGRID_ADD("rollid1", 60, "Roll ID", "rollid_1");
            COLUMNGRID_ADD("cortes_ancho", 60, "Cortes Ancho", "cortes_ancho");
            COLUMNGRID_ADD("cortes_largos", 60, "longitud Cortar", "longitud_cortar");
        }
        private void COLUMNGRID_ADD(string name, int size, string title, string field_bd)
        {
            DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn
            {
                Name = name,
                Width = size,
                HeaderText = title,
                DataPropertyName = field_bd
            };
            grid_ordenes.Columns.Add(col);
        }

        private void Txt_buscar_TextChanged(object sender, EventArgs e)
        {
            if (rad_orden.Checked)
            {
                dv.RowFilter = "numero LIKE '%" + this.txt_buscar.Text + "%'";
            }
            if (rad_customer_name.Checked)
            {
                dv.RowFilter = "customer_name LIKE '%" + this.txt_buscar.Text + "%'";
            }
            if (rad_id_customer.Checked)
            {
                dv.RowFilter = "customer_id LIKE '%" + this.txt_buscar.Text + "%'";
            }
            CONTADOR_REGISTRO.Text = "Numero de Registros: " + Convert.ToString(dv.Count);
        }

        private void Bot_buscar_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(Convert.ToDateTime(txt_fecha_desde.Text).Month) +
            "/" + Convert.ToString(Convert.ToDateTime(txt_fecha_desde.Text).Day) + "/" +
            Convert.ToString(Convert.ToDateTime(txt_fecha_desde.Text).Year);
            string fhasta = Convert.ToString(Convert.ToDateTime(txt_fecha_hasta.Text).Month) +
            "/" + Convert.ToString(Convert.ToDateTime(txt_fecha_hasta.Text).Day) + "/" +
            Convert.ToString(Convert.ToDateTime(txt_fecha_hasta.Text).Year);

            if (rad_fecha.Checked)
            {
                dv.RowFilter = "fecha >= #" + fdesde + "# AND  fecha <= #" + fhasta + "#";
            }
            CONTADOR_REGISTRO.Text = "Numero de Registros: " + Convert.ToString(dv.Count);
        }

        private void Grid_ordenes_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Orden = (grid_ordenes.Rows[e.RowIndex].Cells[0].Value.ToString());
            this.Close();
        }

        private void Rad_fecha_CheckedChanged(object sender, EventArgs e)
        {
            if (rad_fecha.Checked)
            {
                txt_fecha_desde.Enabled = true;
                txt_fecha_hasta.Enabled = true;
            }
            else
            {
                txt_fecha_desde.Enabled = false;
                txt_fecha_hasta.Enabled = false;
            }
        }
    }
}
