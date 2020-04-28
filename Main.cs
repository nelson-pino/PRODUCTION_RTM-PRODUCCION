using RitramaAPP.form;
using System.Linq.Expressions;
using System.Reflection;
using System.Windows.Forms;

namespace RitramaAPP
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }
        
        private void TreeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            switch (e.Node.Text)
            {
                case "Recepciones":
                    panel1.Controls.Clear();
                    FrmMateriaPrima f = new FrmMateriaPrima
                    {
                        TopLevel = false
                    };
                    this.panel1.Controls.Add(f);
                    f.Dock = DockStyle.Fill;
                    f.Show();
                    break;
                case "Pedidos Clientes":
                    panel1.Controls.Clear();
                    FrmPedidos fpedido = new FrmPedidos
                    {
                        TopLevel = false
                    };
                    this.panel1.Controls.Add(fpedido);
                    fpedido.Dock = DockStyle.Fill;
                    fpedido.Show();
                    break;
                case "Ordenes Corte":
                    panel1.Controls.Clear();
                    FrmOrdenCorte fcorte = new FrmOrdenCorte
                    {
                        TopLevel = false
                    };
                    this.panel1.Controls.Add(fcorte);
                    fcorte.Dock = DockStyle.Fill;
                    fcorte.Show();
                    break;
                case "Productos":
                    panel1.Controls.Clear();
                    FrmProducts fproducts = new FrmProducts
                    {
                        TopLevel = false
                    };
                    this.panel1.Controls.Add(fproducts);
                    fproducts.Dock = DockStyle.Fill;
                    fproducts.Show();
                    break;
                case "Customers":
                    panel1.Controls.Clear();
                    FrmCustomers fcust = new FrmCustomers
                    {
                        TopLevel = false
                    };
                    this.panel1.Controls.Add(fcust);
                    fcust.Dock = DockStyle.Fill;
                    fcust.Show();
                    break;
                case "Proveedores":
                    panel1.Controls.Clear();
                    FrmSupply fsuply = new FrmSupply
                    {
                        TopLevel = false
                    };
                    this.panel1.Controls.Add(fsuply);
                    fsuply.Dock = DockStyle.Fill;
                    fsuply.Show();
                    break;
                case "Modulo de Inventarios":
                    panel1.Controls.Clear();
                    FrmInventario finvent = new FrmInventario
                    {
                        TopLevel = false
                    };
                    this.panel1.Controls.Add(finvent);
                    finvent.Dock = DockStyle.Fill;
                    finvent.Show();
                    break;
                case "Parametros":
                    panel1.Controls.Clear();
                    FrmParameters formParam = new FrmParameters
                    {
                        TopLevel = false
                    };
                    this.panel1.Controls.Add(formParam);
                    formParam.Dock = DockStyle.Fill;
                    formParam.Show();
                    break;
                case "Despacho":
                    panel1.Controls.Clear();
                    FrmDespacho fDespachos = new FrmDespacho
                    {
                        TopLevel = false
                    };
                    this.panel1.Controls.Add(fDespachos);
                    fDespachos.Dock = DockStyle.Fill;
                    fDespachos.Show();
                    break;
                case "Devoluciones":
                    panel1.Controls.Clear();
                    FrmDevol devol = new FrmDevol
                    {
                        TopLevel = false
                    };
                    this.panel1.Controls.Add(devol);
                    devol.Dock = DockStyle.Fill;
                    devol.Show();
                    break;
                
            }
        }

        private void Main_Load(object sender, System.EventArgs e)
        {
            string ver = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            LABEL_VERSION.Text = "Versión App: " + ver;
        }

    
        private void TreeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            switch (e.Node.Text) 
            {
                case R.CONSTANTES.OPTION_MENU_REPORTE1:
                    //Reporte de reserva de productos 
                    FrmPrintSelect DialogPrint = new FrmPrintSelect
                    {
                        Index_Report = 1,
                        Report_Name = "Reporte Reserva de Productos"
                    };
                    DialogPrint.ShowDialog();
                    break;
            }
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
