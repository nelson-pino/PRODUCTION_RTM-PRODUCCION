using RitramaAPP.Clases;
using RitramaAPP.form;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace RitramaAPP
{
    public partial class FrmSupply : Form
    {
        public FrmSupply()
        {
            InitializeComponent();
        }
        SupplyManager suply = new SupplyManager();
        BindingSource bs = new BindingSource();
        DataSet ds = new DataSet();
        int EditMode = 0;
        private void FrmSupply_Load(object sender, EventArgs e)
        {
            suply.ToList();
            ds = suply.ds;
            bs.DataSource = ds;
            bs.DataMember = "dtsupply";
            txt_supply_id.DataBindings.Add("text", bs, "Proveedor_ID");
            txt_supply_name.DataBindings.Add("text", bs, "Proveedor_Name");
            txt_direccion_supply.DataBindings.Add("text", bs, "Preveedor_Dir");
            txt_email_supply.DataBindings.Add("text", bs, "Preveedor_email");
            txt_telefono_supply.DataBindings.Add("text", bs, "Preveedor_phone");
            CHK_ANULADO.DataBindings.Add("checked", bs, "anulado");
            RAD_UNID1.DataBindings.Add("checked", bs, "unidad_master_1");
            RAD_UNID2.DataBindings.Add("checked", bs, "unidad_master_2");
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
            //botones del barra de herramientas.
            OpcionesMenu(1);
            //preparar los controles mode ADD
            Opcionesforms(1);
            DataRow dr = ds.Tables["dtsupply"].NewRow();
            dr["anulado"] = false;
            dr["unidad_master_1"] = false;
            dr["unidad_master_2"] = false;
            ds.Tables["dtsupply"].Rows.Add(dr);
            bs.MoveLast();
            EditMode = 1;
        }
        private void BOT_GRABAR_Click(object sender, EventArgs e)
        {
            if (EditMode == 1) GrabarNuevoRegistro();
            if (EditMode == 2) GrabarUpdateRegistro();
        }

        private void GrabarUpdateRegistro()
        {
            ClassSupply supply = new ClassSupply();
            supply.Supply_ID = txt_supply_id.Text;
            supply.Supply_Name = txt_supply_name.Text;
            supply.Supply_Direcc = txt_direccion_supply.Text;
            supply.Supply_Phone = txt_telefono_supply.Text;
            supply.Supply_Email = txt_email_supply.Text;
            supply.Anulado = CHK_ANULADO.Checked;
            supply.unid_master_1 = RAD_UNID1.Checked;
            supply.unid_master_2 = RAD_UNID2.Checked;
            SupplyManager supplyManager = new SupplyManager();
            supplyManager.Update(supply);
            OpcionesMenu(0);
            Opcionesforms(4);
            EditMode = 0;
        }

        private void GrabarNuevoRegistro()
        {
            //Crear el Objeto producto.
            ClassSupply supply = new ClassSupply();
            SupplyManager supplyManager = new SupplyManager();
            supply.Supply_ID = txt_supply_id.Text;
            supply.Supply_Name = txt_supply_name.Text;
            supply.Supply_Direcc = txt_direccion_supply.Text;
            supply.Supply_Phone = txt_telefono_supply.Text;
            supply.Supply_Email = txt_email_supply.Text;
            supply.unid_master_1 = RAD_UNID1.Checked;
            supply.unid_master_2 = RAD_UNID2.Checked;
            supply.Anulado = false;
            // Validar la entidad Producto.
            if (supply.Supply_ID == string.Empty)
            {
                MessageBox.Show("Introduzca el Id. del proveedor...");
                return;
            }
            if (supply.Supply_Name == string.Empty)
            {
                MessageBox.Show("Introduzca el nombre del proveedor.");
                return;
            }
            if (supply.unid_master_1 == false && supply.unid_master_2 == false)
            {
                MessageBox.Show("Introducir la unidad en la recepcion de master...");
                return;
            }
            supplyManager.Add(supply);
            //Activar las opciones del menu.
            OpcionesMenu(0);
            Opcionesforms(0);
            ContadorRegistros();
            EditMode = 0;
        }

        private void BOT_UPDATE_Click(object sender, EventArgs e)
        {
            OpcionesMenu(1);
            Opcionesforms(3);
            EditMode = 2;
        }

        private void BOT_BUSCAR_Click(object sender, EventArgs e)
        {
            SeleccionProveedores BrowseProviders = new SeleccionProveedores();
            BrowseProviders.dtsupply = ds.Tables["dtsupply"];
            BrowseProviders.ShowDialog();
            int itemFound = bs.Find("Proveedor_ID", BrowseProviders.itemSelected);
            bs.Position = itemFound;
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
                //activo la funciones del menu
                OpcionesMenu(0);
                Opcionesforms(0);
                EditMode = 0;
            }
            if (EditMode == 2)
            {
                OpcionesMenu(0);
                Opcionesforms(0);
                EditMode = 0;
            }
        }
        private void Txt_supply_id_Validating(object sender, CancelEventArgs e)
        {
            if (suply.ProveedorExiste(txt_supply_id.Text) && EditMode == 1)
            {
                MessageBox.Show("El codigo de producto: " + txt_supply_id.Text + " ya existe.");
                txt_supply_id.Text = "";
            }
        }
        private void Opcionesforms(int states)
        {
            switch (states)
            {
                case 0:
                    // MODO LECTURA
                    txt_supply_id.ReadOnly = true;
                    txt_supply_name.ReadOnly = true;
                    txt_direccion_supply.ReadOnly = true;
                    txt_telefono_supply.ReadOnly = true;
                    txt_email_supply.ReadOnly = true;
                    CHK_ANULADO.Enabled = false;
                    if (EditMode == 1)
                    {
                        CHK_ANULADO.DataBindings.Add("checked", bs, "anulado");
                    }
                    RAD_UNID1.Enabled = false;
                    RAD_UNID2.Enabled = false;
                    break;
                case 1:
                    // MODO ADD
                    txt_supply_id.ReadOnly = false;
                    txt_supply_name.ReadOnly = false;
                    txt_direccion_supply.ReadOnly = false;
                    txt_telefono_supply.ReadOnly = false;
                    txt_email_supply.ReadOnly = false;
                    RAD_UNID1.Enabled = true;
                    RAD_UNID2.Enabled = true;
                    CHK_ANULADO.DataBindings.Clear();
                    RAD_UNID1.Checked = false;
                    RAD_UNID2.Checked = false;
                    break;
                case 3:
                    // MODO UPDATE-ABRO.
                    txt_supply_name.ReadOnly = false;
                    txt_direccion_supply.ReadOnly = false;
                    txt_telefono_supply.ReadOnly = false;
                    txt_email_supply.ReadOnly = false;
                    CHK_ANULADO.Enabled = true;
                    RAD_UNID1.Enabled = true;
                    RAD_UNID2.Enabled = true;
                    break;
                case 4:
                    // MODO UPDATE-CIERRO.
                    txt_supply_id.ReadOnly = true;
                    txt_supply_name.ReadOnly = true;
                    txt_direccion_supply.ReadOnly = true;
                    txt_telefono_supply.ReadOnly = true;
                    txt_email_supply.ReadOnly = true;
                    RAD_UNID1.Enabled = false;
                    RAD_UNID2.Enabled = false;
                    CHK_ANULADO.Enabled = false;
                    break;
            }
        }
        private void OpcionesMenu(int states)
        {
            switch (states)
            {
                case 0:
                    // menu estado visualizar 
                    BOT_PRIMERO.Enabled = true;
                    BOT_SIGUIENTE.Enabled = true;
                    BOT_ANTERIOR.Enabled = true;
                    BOT_ULTIMO.Enabled = true;
                    BOT_NUEVO.Enabled = true;
                    BOT_CANCEL.Enabled = false;
                    BOT_UPDATE.Enabled = true;
                    BOT_GRABAR.Enabled = false;
                    BOT_BUSCAR.Enabled = true;
                    break;
                case 1:
                    // menu estado AGREGAR 
                    BOT_PRIMERO.Enabled = false;
                    BOT_SIGUIENTE.Enabled = false;
                    BOT_ANTERIOR.Enabled = false;
                    BOT_ULTIMO.Enabled = false;
                    BOT_NUEVO.Enabled = false;
                    BOT_GRABAR.Enabled = true;
                    BOT_CANCEL.Enabled = true;
                    BOT_UPDATE.Enabled = false;
                    BOT_BUSCAR.Enabled = false;
                    break;
            }
        }
    }
}
