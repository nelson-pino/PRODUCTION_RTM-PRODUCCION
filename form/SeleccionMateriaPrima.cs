using System;
using System.Data;
using System.Windows.Forms;

namespace RitramaAPP.form
{
    public partial class SeleccionMateriaPrima : Form
    {
        public SeleccionMateriaPrima()
        {
            InitializeComponent();
        }
        public DataTable dtrecepcion { get; set; }
        public string GetOrderbyID { get; set; }

        DataView dv = new DataView();
        private void SeleccionMateriaPrima_Load(object sender, EventArgs e)
        {
            dv = dtrecepcion.DefaultView;
            dv.RowFilter = "";
            DarEstilosGrid();
            grid_ordenes.DataSource = dv;
            CONTADOR_REGISTRO.Text = "Numero de Registros: " + Convert.ToString(dv.Count);
        }
        private void DarEstilosGrid()
        {
            grid_ordenes.AutoGenerateColumns = false;
            DataGridViewTextBoxColumn col1 = new DataGridViewTextBoxColumn();
            col1.Name = "orden";
            col1.Width = 65;
            col1.HeaderText = "Orden";
            col1.DataPropertyName = "OrderPurchase";
            grid_ordenes.Columns.Add(col1);
            DataGridViewTextBoxColumn col2 = new DataGridViewTextBoxColumn();
            col2.Name = "fecha_pro";
            col2.Width = 80;
            col2.HeaderText = "Fecha Produccion";
            col2.DataPropertyName = "fecha_pro";
            grid_ordenes.Columns.Add(col2);
            DataGridViewTextBoxColumn col3 = new DataGridViewTextBoxColumn();
            col3.Name = "rollid";
            col3.Width = 85;
            col3.HeaderText = "Roll Id";
            col3.DataPropertyName = "Roll_Id";
            grid_ordenes.Columns.Add(col3);
            DataGridViewTextBoxColumn col4 = new DataGridViewTextBoxColumn();
            col4.Name = "provider_id";
            col4.Width = 60;
            col4.HeaderText = "Prov Id.";
            col4.DataPropertyName = "Proveedor_Id";
            grid_ordenes.Columns.Add(col4);
            DataGridViewTextBoxColumn col5 = new DataGridViewTextBoxColumn();
            col5.Name = "provider_name";
            col5.Width = 200;
            col5.HeaderText = "Nombre del Proveedor";
            col5.DataPropertyName = "suplidor_des";
            grid_ordenes.Columns.Add(col5);
            DataGridViewTextBoxColumn col6 = new DataGridViewTextBoxColumn();
            col6.Name = "product_id";
            col6.Width = 60;
            col6.HeaderText = "Product Id.";
            col6.DataPropertyName = "Part_Number";
            grid_ordenes.Columns.Add(col6);
            DataGridViewTextBoxColumn col7 = new DataGridViewTextBoxColumn();
            col7.Name = "product_name";
            col7.Width = 200;
            col7.HeaderText = "Nombre del Producto";
            col7.DataPropertyName = "product_name";
            grid_ordenes.Columns.Add(col7);
            DataGridViewTextBoxColumn col8 = new DataGridViewTextBoxColumn();
            col8.Name = "ubic";
            col8.Width = 60;
            col8.HeaderText = "Ubicacion";
            col8.DataPropertyName = "ubicacion";
            grid_ordenes.Columns.Add(col8);
        }
        private void Grid_ordenes_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            GetOrderbyID = (grid_ordenes.Rows[e.RowIndex].Cells[0].Value.ToString());
            this.Close();
        }
        private void Txt_buscar_TextChanged(object sender, EventArgs e)
        {
            if (rad_orden.Checked)
            {
                dv.RowFilter = "OrderPurchase LIKE '%" + this.txt_buscar.Text + "%'";
            }
            if (rad_rollid.Checked)
            {
                dv.RowFilter = "Roll_Id LIKE '%" + this.txt_buscar.Text + "%'";
            }
            if (rad_ProveedorName.Checked)
            {
                dv.RowFilter = "suplidor_des LIKE '%" + this.txt_buscar.Text + "%'";
            }
            if (rad_productName.Checked)
            {
                dv.RowFilter = "product_name LIKE '%" + this.txt_buscar.Text + "%'";
            }
            if (rad_ubic.Checked)
            {
                dv.RowFilter = "ubicacion LIKE '%" + this.txt_buscar.Text + "%'";
            }
            CONTADOR_REGISTRO.Text = "Numero de Registros: " + Convert.ToString(dv.Count);
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
                dv.RowFilter = "fecha_pro >= #" + fdesde + "# AND  fecha_pro <= #" + fhasta + "#";
            }
            CONTADOR_REGISTRO.Text = "Numero de Registros: " + Convert.ToString(dv.Count);
        }
    }
}
