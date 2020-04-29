using System;
using System.Windows.Forms;
using System.Data;
using RitramaAPP.Clases;
using System.Collections.Generic;

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
        public int NumTransac { get; set; }
        public List<string> Ids { get; set; }
        ConfigManager manager = new ConfigManager();
        private void FrmReservas_Load(object sender, EventArgs e)
        {
            ProductsReserva = new Reserva
            {
                Transac = NumTransac,
                FechaReserva = DateTime.Today,
                FechaPlan = DateTime.Today,
                items = Ids
            };
            TXT_TRANSACC.Text = Convert.ToString(ProductsReserva.Transac);
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
            if (string.IsNullOrEmpty(TXT_ORDEN_TRA.Text)) 
            {
                MessageBox.Show("Introduzca la Orden de TRabajo.");
                return; 
            }
            if (string.IsNullOrEmpty(TXT_ORDEN_SER.Text))
            {
                MessageBox.Show("Introduzca la Orden de Servicio.");
                return;
            }
            if (string.IsNullOrEmpty(TXT_IDCUST.Text))
            {
                MessageBox.Show("Seleccione un cliente.");
                return;
            }
            ProductsReserva.OrdenTrabajo = TXT_ORDEN_TRA.Text;
            ProductsReserva.OrdenServicio = TXT_ORDEN_SER.Text;
            ProductsReserva.FechaPlan = Convert.ToDateTime(TXT_FECHA_ENTREGA.Text);
            ProductsReserva.IdCust = TXT_IDCUST.Text;
            ProductsReserva.Commentary = TXT_COMMENTARY.Text;
            this.DocumReserva = ProductsReserva;
            // actualizar el numero consecutivo de los documento de reserva
            int consec = Convert.ToInt16(TXT_TRANSACC.Text) + 1;
            manager.SetParametersControl(consec.ToString(), "CONS_RESER");
            this.Close();
        }
    }
}
