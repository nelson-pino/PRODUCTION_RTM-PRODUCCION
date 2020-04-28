using RitramaAPP.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RitramaAPP.form
{
    public partial class frmInfoReserva : Form
    {
        public Reserva DataInfo { get; set; }
        public string Code_id { get; set; }
        public Boolean DilogDeleteYes { get; set; }
        public frmInfoReserva()
        {
            InitializeComponent();
        }

        private void FrmInfoReserva_Load(object sender, EventArgs e)
        {
            txt_docum.Text = DataInfo.Transac.ToString();
            txt_orden_s.Text = DataInfo.OrdenServicio;
            txt_orden_t.Text = DataInfo.OrdenTrabajo;
            txt_fecha_entrega.Text = Convert.ToString(DataInfo.FechaPlan);
            txt_fecha_reserva.Text = Convert.ToString(DataInfo.FechaReserva);
            txt_idcust.Text = DataInfo.IdCust;
            txt_cliente_name.Text = DataInfo.Customer_Name;
            txt_nota.Text = DataInfo.Commentary;
            txt_numero_id.Text = Code_id;
            DilogDeleteYes = false;
        }

        private void Txt_eliminar_item_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Esta seguro de Liberar este item (S/N)?",
               "Advertencia", MessageBoxButtons.YesNo);
            switch (dr)
            {
                case DialogResult.Yes:
                    DilogDeleteYes = true;
                    this.Close();
                    break;
                case DialogResult.No:
                    break;
            }
        }
    }
}
