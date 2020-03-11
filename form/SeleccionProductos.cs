using System;
using System.Data;
using System.Windows.Forms;

namespace RitramaAPP.form
{
    public partial class SeleccionProductos : Form
    {
        public SeleccionProductos()
        {
            InitializeComponent();
        }
        public DataTable Dtproducto { get; set; }
        public string ItemSelected { get; set; }
        public string GetProductId { get; set; }
        public string GetProductName { get; set; }
        public Boolean GetMasterRolls { get; set; }
        public Boolean GetResma { get; set; }
        public Boolean Getgraphics { get; set; }

        DataView dv = new DataView();
        private void SeleccionProductos_Load(object sender, EventArgs e)
        {
            dv = Dtproducto.DefaultView;
            grid_productos.AutoGenerateColumns = false;
            DataGridViewTextBoxColumn col1 = new DataGridViewTextBoxColumn
            {
                Name = "id_product",
                Width = 65,
                HeaderText = "Codigo",
                DataPropertyName = "Product_ID"
            };
            grid_productos.Columns.Add(col1);
            DataGridViewTextBoxColumn col2 = new DataGridViewTextBoxColumn
            {
                Name = "part_name",
                Width = 250,
                HeaderText = "Producto",
                DataPropertyName = "Product_Name"
            };
            grid_productos.Columns.Add(col2);
            DataGridViewTextBoxColumn col3 = new DataGridViewTextBoxColumn
            {
                Name = "product_type",
                Width = 80,
                HeaderText = "Tipo",
                DataPropertyName = "Tipo"
            };
            grid_productos.Columns.Add(col3);
            DataGridViewTextBoxColumn col4 = new DataGridViewTextBoxColumn
            {
                Name = "masterRolls",
                Width = 60,
                HeaderText = "Master",
                DataPropertyName = "masterRolls",
                Visible = false
            };
            grid_productos.Columns.Add(col4);
            DataGridViewTextBoxColumn col5 = new DataGridViewTextBoxColumn
            {
                Name = "resmas",
                Width = 60,
                HeaderText = "Hojas",
                DataPropertyName = "Resmas",
                Visible = false
            };
            grid_productos.Columns.Add(col5);
            DataGridViewTextBoxColumn col6 = new DataGridViewTextBoxColumn
            {
                Name = "graphics",
                Width = 60,
                HeaderText = "Graphics",
                DataPropertyName = "graphics",
                Visible = false
            };
            grid_productos.Columns.Add(col6);

            dv.RowFilter = "";
            grid_productos.DataSource = dv;
            lbl_contador_registros.Text = Convert.ToString(dv.Count) + " registros encontrados.";
        }
        private void Txt_buscar_TextChanged(object sender, EventArgs e)
        {
            if (rad_codigo.Checked)
            {
                dv.RowFilter = "Product_ID LIKE '%" + this.txt_buscar.Text + "%'";
            }
            if (rad_producto.Checked)
            {
                dv.RowFilter = "Product_Name LIKE '%" + this.txt_buscar.Text + "%'";
            }
            if (ra_tipo.Checked)
            {
                dv.RowFilter = "tipo LIKE '%" + this.txt_buscar.Text + "%'";
            }
            lbl_contador_registros.Text = Convert.ToString(dv.Count) + " registros encontrados.";
        }

        private void Grid_productos_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            ItemSelected = grid_productos.Rows[e.RowIndex].Cells[0].Value.ToString();
            GetProductId = grid_productos.Rows[e.RowIndex].Cells[0].Value.ToString();
            GetProductName = grid_productos.Rows[e.RowIndex].Cells[1].Value.ToString();
            GetMasterRolls = Convert.ToBoolean(grid_productos.Rows[e.RowIndex].Cells[3].Value);
            GetResma = Convert.ToBoolean(grid_productos.Rows[e.RowIndex].Cells[4].Value);
            Getgraphics = Convert.ToBoolean(grid_productos.Rows[e.RowIndex].Cells[5].Value);
            this.Close();
        }
    }
}
