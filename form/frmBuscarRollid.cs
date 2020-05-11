using RitramaAPP.Clases;
using System;
using System.Data;
using System.Windows.Forms;

namespace RitramaAPP.form
{
    public partial class FrmBuscarRollid : Form
    {
        public FrmBuscarRollid()
        {
            InitializeComponent();
        }

        readonly ProduccionManager produccionmanager = new ProduccionManager();
        public DataTable Dtrollid { get; set; }
        DataView dv = new DataView();
        public string GetrollId { get; set; }
        public string Getproduct_id { get; set; }
        public string GetProduct_name { get; set; }
        public string GetValueWidth { get; set; }
        public string GetvalueLenght { get; set; }
        public Boolean Rebobinado { get; set; }
        public string Gettipo_mov { get; set; }

        private void FrmBuscarRollid_Load(object sender, EventArgs e)
        {
            Rebobinado = false;
            dv = Dtrollid.DefaultView;
            Grid_Items.AutoGenerateColumns = false;
            AplicarEstilosGrid();
            Grid_Items.DataSource = Dtrollid;
            CONTADOR_REGISTRO.Text = Convert.ToString(dv.Count) + " registros encontrados.";
        }
        private void AplicarEstilosGrid()
        {
            AGREGAR_COLUMN_GRID("rollid", 62, "Roll Id", "Roll_Id");
            AGREGAR_COLUMN_GRID("product_id", 55, "Product Id", "part_number");
            AGREGAR_COLUMN_GRID("product_name", 250, "Nombre del Producto", "product_name");
            AGREGAR_COLUMN_GRID("width", 65, "Width", "width");
            AGREGAR_COLUMN_GRID("lenght", 65, "Lenght", "lenght");
            AGREGAR_COLUMN_GRID("fecha_pro", 67, "Fecha produccion", "fecha_pro");
            AGREGAR_COLUMN_GRID("fecha_doc", 67, "Fecha Recepcion", "fecha_recep");
            AGREGAR_COLUMN_GRID("splice", 40, "Splice", "splice");
            AGREGAR_COLUMN_GRID("ubicacion", 60, "Ubicacion", "ubicacion");
            AGREGAR_COLUMN_GRID("tipo_mov", 60, "Tipo", "tipo_mov");
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
            Grid_Items.Columns.Add(col);
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            if (RAD_ROLLID.Checked)
            {
                dv.RowFilter = "Roll_Id LIKE '%" + this.TXT_BUSCAR.Text + "%'";
            }
            if (RAD_NOMBRE_PRODUCTO.Checked)
            {
                dv.RowFilter = "Product_Name LIKE '%" + this.TXT_BUSCAR.Text + "%'";
            }
            if (ra_number_rc.Checked)
            {
                dv.RowFilter = "unique_code LIKE '%" + this.TXT_BUSCAR.Text + "%'";
            }
            CONTADOR_REGISTRO.Text = Convert.ToString(dv.Count) + " registros encontrados.";
        }

        private void Grid_Items_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            GetrollId = Grid_Items.Rows[e.RowIndex].Cells[0].Value.ToString();
            Getproduct_id = Grid_Items.Rows[e.RowIndex].Cells[1].Value.ToString();
            GetProduct_name = Grid_Items.Rows[e.RowIndex].Cells[2].Value.ToString();
            GetValueWidth = Grid_Items.Rows[e.RowIndex].Cells[3].Value.ToString();
            GetvalueLenght = Grid_Items.Rows[e.RowIndex].Cells[4].Value.ToString();
            Gettipo_mov = Grid_Items.Rows[e.RowIndex].Cells["tipo_mov"].Value.ToString();
            this.Close();
        }

        private void BOT_ACTUALIZAR_REBO_Click(object sender, EventArgs e)
        {
            if (chk_rebobinado.Checked == true)
            {
                PROC_REBOBINADO_ORDEN();
            }
        }
        private void PROC_REBOBINADO_ORDEN()
        {
            Grid_Items.DataSource = null;
            Grid_Items.Columns.Clear();

            AGREGAR_COLUMN_GRID("unique_code", 60, "Unique Code", "unique_code");
            AGREGAR_COLUMN_GRID("product_id", 60, "Product Id.", "product_id");
            AGREGAR_COLUMN_GRID("product_name", 100, "Nombre del Producto", "product_name");
            AGREGAR_COLUMN_GRID("Width", 50, "Width", "width");
            AGREGAR_COLUMN_GRID("Lenght", 50, "Lenght", "large");
            AGREGAR_COLUMN_GRID("msi", 60, "Msi", "msi");
            AGREGAR_COLUMN_GRID("splice", 45, "Splice", "splice");
            AGREGAR_COLUMN_GRID("rollid", 70, "Roll Id.", "roll_id");
            AGREGAR_COLUMN_GRID("code_person", 60, "Codigo Per.", "code_person");
            AGREGAR_COLUMN_GRID("status", 50, "Status", "status");
            AGREGAR_COLUMN_GRID("roll_number", 20, "#", "roll_number");
            dv = produccionmanager.GetUniqueCodeToList().DefaultView;
            Grid_Items.DataSource = dv;
            CONTADOR_REGISTRO.Text = Convert.ToString(dv.Count) + " registros encontrados.";
            Rebobinado = true;
        }
    }
}
