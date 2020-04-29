using System;
using System.Web.UI.WebControls.WebParts;
using System.Windows.Forms;
using RitramaAPP.Clases;

namespace RitramaAPP.form
{
    public partial class FrmPrintSelect : Form
    {
        public string Report_Name { get; set; }
        public int Index_Report { get; set; }
        public FrmPrintSelect()
        {
            InitializeComponent();
        }
        readonly CustomerManager customerManager = new CustomerManager();
        readonly ProductsManager productsManager = new ProductsManager();
        readonly ReportsManager reportManager = new ReportsManager();
        
        private void BOT_SEARCH_CLI1_Click(object sender, EventArgs e)
        {
            LoadCustomers(TXT_DESDE_CLI, TXT_CLIENTE1);
            TXT_HASTA_CLI.Text = TXT_DESDE_CLI.Text;
            TXT_CLIENTE2.Text = TXT_CLIENTE1.Text;
        }
        private void LoadCustomers(TextBox tb_id, TextBox tb_name) 
        {
            SeleccionCustomers clientes = new SeleccionCustomers
            {
                Dtcustomer = customerManager.GetCustomers()
            };
            clientes.ShowDialog();
            tb_id.Text = clientes.GetCustomerId;
            tb_name.Text = clientes.GetCustomerName;
        }
        private void BOT_SEARCH_CLI2_Click(object sender, EventArgs e)
        {
            LoadCustomers(TXT_HASTA_CLI, TXT_CLIENTE2);
        }
        private void BOT_IMPRIMIR_Click(object sender, EventArgs e)
        {
            switch (Index_Report) 
            {
                case 1:
                    string DESDE_CLI = TXT_DESDE_CLI.Text;
                    string HASTA_CLI = TXT_HASTA_CLI.Text;
                    DateTime DESDE_FECHA = Convert.ToDateTime(TXT_DESDE_FECHA.Text);
                    DateTime HASTA_FECHA = Convert.ToDateTime(TXT_HASTA_FECHA.Text);
                    reportManager.Reporte_ReservaProducts(DESDE_CLI,HASTA_CLI,DESDE_FECHA,HASTA_FECHA);
                    break;
                case 2:
                    break;
                case 3:
                    break;
            }
        }
    }
}
