using RitramaAPP.Clases;
using RitramaAPP.form;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace RitramaAPP
{
    public partial class FrmCustomers : Form
    {
        public FrmCustomers()
        {
            InitializeComponent();
        }
        CustomerManager customer = new CustomerManager();
        BindingSource bs = new BindingSource();
        DataSet ds = new DataSet();
        int EditMode = 0;
        private void FrmCustomers_Load(object sender, EventArgs e)
        {
            customer.ToList();
            ds = customer.ds;
            bs.DataSource = ds;
            bs.DataMember = "dtcustomer";
            txt_customer_id.DataBindings.Add("text", bs, "Customer_ID");
            txt_CustomerName.DataBindings.Add("text", bs, "Customer_Name");
            txt_customers_direcc.DataBindings.Add("text", bs, "Customer_Dir");
            txt_category.DataBindings.Add("text", bs, "Customer_Category");
            txt_customer_email.DataBindings.Add("text", bs, "Customer_Email");
            txt_phone.DataBindings.Add("text", bs, "phone");
            CHK_ANULADO.DataBindings.Add("checked", bs, "anulado");

            ContadorRegistros();
        }
        private void ContadorRegistros()
        {
            LABEL_CONTADOR_REGISTRO.Text = (bs.Position + 1) + " de " + (bs.Count.ToString()) + " Registros";
        }
        private void BOT_SIGUIENTE_Click(object sender, EventArgs e)
        {
            bs.Position = bs.Position + 1;
            ContadorRegistros();
        }
        private void BOT_ANTERIOR_Click(object sender, EventArgs e)
        {
            bs.Position = bs.Position - 1;
            ContadorRegistros();
        }
        private void BOT_PRIMERO_Click(object sender, EventArgs e)
        {
            bs.Position = 0;
            ContadorRegistros();
        }
        private void BOT_ULTIMO_Click(object sender, EventArgs e)
        {
            bs.Position = bs.Count - 1;
            ContadorRegistros();
        }
        private void BOT_NUEVO_Click(object sender, EventArgs e)
        {
            OpcionesMenu(1);
            OpcionesForms(1);
            DataRow dr = ds.Tables["dtcustomer"].NewRow();
            dr["anulado"] = false;
            ds.Tables["dtcustomer"].Rows.Add(dr);
            bs.MoveLast();
            EditMode = 1;
        }
        private void BOT_GUARDAR_Click(object sender, EventArgs e)
        {
            if (EditMode == 1) GrabarNuevoRegistro();
            if (EditMode == 2) GrabarUpdateRegistro();
        }
        private void GrabarUpdateRegistro()
        {
            ClassCustomer customer = new ClassCustomer();
            customer.CustomerID = txt_customer_id.Text;
            customer.CustomerName = txt_CustomerName.Text;
            customer.Category = txt_category.Text;
            customer.direcc = txt_customers_direcc.Text;
            customer.email = txt_customer_email.Text;
            customer.Anulado = CHK_ANULADO.Checked;
            customer.phone = txt_phone.Text;
            CustomerManager customerManager = new CustomerManager();
            customerManager.Update(customer);
            OpcionesMenu(0);
            OpcionesForms(0);
            CHK_ANULADO.Enabled = false;
            EditMode = 0;
        }
        private void GrabarNuevoRegistro()
        {
            //Crear el Objeto producto.
            ClassCustomer customer = new ClassCustomer();
            CustomerManager customerManager = new CustomerManager();
            customer.CustomerID = txt_customer_id.Text;
            customer.CustomerName = txt_CustomerName.Text;
            customer.Category = txt_category.Text;
            customer.direcc = txt_customers_direcc.Text;
            customer.email = txt_customer_email.Text;
            customer.phone = txt_phone.Text;
            customer.Anulado = false;
            // Validar la entidad Producto.
            if (customer.CustomerID == string.Empty)
            {
                MessageBox.Show("Introduzca el ID del cliente...");
                return;
            }
            if (customer.CustomerName == string.Empty)
            {
                MessageBox.Show("Introduzca el nombre del Cliente.");
                return;
            }
            customerManager.Add(customer);
            OpcionesMenu(0);
            OpcionesForms(0);
            CHK_ANULADO.DataBindings.Add("checked", bs, "anulado");
            ContadorRegistros();
            EditMode = 0;
        }
        private void BOT_UPDATE_Click(object sender, EventArgs e)
        {
            OpcionesMenu(1);
            OpcionesForms(2);
            EditMode = 2;
        }

        private void BOT_CANCEL_Click(object sender, EventArgs e)
        {
            if (EditMode == 1)
            {
                //borro la factura alcual.
                DataRowView FilaActual;
                FilaActual = (DataRowView)bs.Current;
                FilaActual.Row.Delete();
                bs.EndEdit();
                bs.Position = bs.Count;
                ContadorRegistros();
                OpcionesMenu(0);
                OpcionesForms(0);
                CHK_ANULADO.Enabled = false;
                EditMode = 0;
            }
            if (EditMode == 2)
            {
                OpcionesMenu(0);
                OpcionesForms(3);
                CHK_ANULADO.Enabled = false;
                EditMode = 0;
            }
        }

        private void BOT_BUSCAR_Click(object sender, EventArgs e)
        {
            SeleccionCustomers BrowseCustomers = new SeleccionCustomers();
            BrowseCustomers.Dtcustomer = ds.Tables["dtcustomer"];
            BrowseCustomers.ShowDialog();
            int itemFound = bs.Find("Customer_ID", BrowseCustomers.ItemSelected);
            bs.Position = itemFound;
        }
        private void OpcionesMenu(int states)
        {
            switch (states)
            {
                case 0:
                    // modo lectura.
                    BOT_PRIMERO.Enabled = true;
                    BOT_SIGUIENTE.Enabled = true;
                    BOT_ANTERIOR.Enabled = true;
                    BOT_ULTIMO.Enabled = true;
                    BOT_NUEVO.Enabled = true;
                    BOT_CANCEL.Enabled = false;
                    BOT_GUARDAR.Enabled = false;
                    BOT_UPDATE.Enabled = true;
                    BOT_BUSCAR.Enabled = true;

                    break;
                case 1:
                    // modo add
                    BOT_PRIMERO.Enabled = false;
                    BOT_SIGUIENTE.Enabled = false;
                    BOT_ANTERIOR.Enabled = false;
                    BOT_ULTIMO.Enabled = false;
                    BOT_NUEVO.Enabled = false;
                    BOT_CANCEL.Enabled = true;
                    BOT_GUARDAR.Enabled = true;
                    BOT_UPDATE.Enabled = false;
                    BOT_BUSCAR.Enabled = false;
                    break;
            }
        }
        private void OpcionesForms(int states)
        {
            switch (states)
            {
                case 0:
                    //modo READ
                    txt_customer_id.ReadOnly = true;
                    txt_CustomerName.ReadOnly = true;
                    txt_customers_direcc.ReadOnly = true;
                    txt_category.ReadOnly = true;
                    txt_customer_email.ReadOnly = true;
                    txt_phone.ReadOnly = true;
                    break;
                case 1:
                    // MODO ADD
                    txt_customer_id.ReadOnly = false;
                    txt_CustomerName.ReadOnly = false;
                    txt_category.ReadOnly = false;
                    txt_customers_direcc.ReadOnly = false;
                    txt_customer_email.ReadOnly = false;
                    txt_phone.ReadOnly = false;
                    CHK_ANULADO.DataBindings.Clear();
                    break;
                case 2:
                    // MODO UPDATE-OPEN
                    txt_CustomerName.ReadOnly = false;
                    txt_category.ReadOnly = false;
                    txt_customers_direcc.ReadOnly = false;
                    txt_customer_email.ReadOnly = false;
                    txt_phone.ReadOnly = false;
                    CHK_ANULADO.Enabled = true;
                    break;
                case 3:
                    // MODO UPDATE-CLOSE
                    txt_customer_id.ReadOnly = true;
                    txt_CustomerName.ReadOnly = true;
                    txt_category.ReadOnly = true;
                    txt_customers_direcc.ReadOnly = true;
                    txt_customer_email.ReadOnly = true;
                    txt_phone.ReadOnly = true;
                    break;
            }
        }
        private void Txt_customer_id_Validating(object sender, CancelEventArgs e)
        {
            if (customer.ClienteExiste(txt_customer_id.Text) && EditMode == 1)
            {
                MessageBox.Show("El codigo del cliente: " + txt_customer_id.Text + " ya existe.");
                txt_customer_id.Text = "";
            }
        }

        private void ToolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
