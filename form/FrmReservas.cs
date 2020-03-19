using System;
using System.Windows.Forms;
using System.Data;
using RitramaAPP.Clases;

namespace RitramaAPP.form
{
    public partial class FrmReservas : Form
    {
        public FrmReservas()
        {
            InitializeComponent();
        }
        Reserva ProductsReserva;
        public DataTable Dtcustomers { get; set; }
        public Reserva DocumReserva { get; set; }
        private void FrmReservas_Load(object sender, EventArgs e)
        {
            ProductsReserva = new Reserva
            {
                Transac="0001",
                FechaReserva=DateTime.Today,
                FechaPlan = DateTime.Today
            };
            TXT_TRANSACC.Text = ProductsReserva.Transac;
            TXT_FECHA_ENTREGA.Text = Convert.ToString(ProductsReserva.FechaPlan);
            TXT_FECHA_RESERVA.Text = Convert.ToString(ProductsReserva.FechaReserva);
        }

        private void BOT_SEARCH_CUSTOM_Click(object sender, EventArgs e)
        {
            SeleccionCustomers customers = new SeleccionCustomers
            {
                Dtcustomer = this.Dtcustomers
            };
            customers.ShowDialog();
            TXT_CUSTOMER.Text = customers.GetCustomerName;
            TXT_IDCUST.Text = customers.GetCustomerId;
        }

        private void BOT_GUARDAR_Click(object sender, EventArgs e)
        {
            ProductsReserva.OrdenTrabajo = TXT_ORDEN_TRA.Text;
            ProductsReserva.OrdenServicio = TXT_ORDEN_SER.Text;
            ProductsReserva.FechaPlan = Convert.ToDateTime(TXT_FECHA_ENTREGA.Text);
            ProductsReserva.IdCust = TXT_IDCUST.Text;
            ProductsReserva.Commentary = TXT_COMMENTARY.Text;
            this.DocumReserva = ProductsReserva;
            this.Close();
        }
    }
}
