using System;
using System.Data;
using System.Windows.Forms;

namespace RitramaAPP.form
{
    public partial class SeleccionCustomers : Form
    {
        public SeleccionCustomers()
        {
            InitializeComponent();
        }
        public DataTable Dtcustomer { get; set; }
        public string ItemSelected { get; set; }
        public string GetCustomerId { get; set; }
        public string GetCustomerName { get; set; }
        public string GetCustomerDirecc { get; set; }


        DataView dv = new DataView();
        private void SeleccionCustomers_Load(object sender, EventArgs e)
        {
            dv = Dtcustomer.DefaultView;
            grid_customers.AutoGenerateColumns = false;
            DataGridViewTextBoxColumn col1 = new DataGridViewTextBoxColumn
            {
                Name = "customer_id",
                Width = 60,
                HeaderText = "Codigo",
                DataPropertyName = "Customer_ID"
            };
            grid_customers.Columns.Add(col1);
            DataGridViewTextBoxColumn col2 = new DataGridViewTextBoxColumn
            {
                Name = "customer_name",
                Width = 390,
                HeaderText = "Customer Name",
                DataPropertyName = "Customer_Name"
            };
            grid_customers.Columns.Add(col2);
            DataGridViewTextBoxColumn col3 = new DataGridViewTextBoxColumn
            {
                Name = "Customer_Dir",
                Width = 100,
                HeaderText = "Direccion",
                DataPropertyName = "Customer_Dir"
            };
            grid_customers.Columns.Add(col3);
            dv.RowFilter = "";
            grid_customers.DataSource = dv;
            lbl_contador_registros.Text = Convert.ToString(dv.Count) + " registros encontrados.";
        }
        private void Txt_buscar_TextChanged(object sender, EventArgs e)
        {
            if (rad_codigo.Checked)
            {
                dv.RowFilter = "Customer_ID LIKE '%" + this.txt_buscar.Text + "%'";
            }
            if (rad_name.Checked)
            {
                dv.RowFilter = "Customer_Name LIKE '%" + this.txt_buscar.Text + "%'";
            }
            lbl_contador_registros.Text = Convert.ToString(dv.Count) + " registros encontrados.";
        }

        private void Grid_customers_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ItemSelected = grid_customers.Rows[e.RowIndex].Cells[0].Value.ToString();
            GetCustomerId = grid_customers.Rows[e.RowIndex].Cells[0].Value.ToString();
            GetCustomerName = grid_customers.Rows[e.RowIndex].Cells[1].Value.ToString();
            GetCustomerDirecc = grid_customers.Rows[e.RowIndex].Cells[2].Value.ToString();
            this.Close();
        }
    }
}
