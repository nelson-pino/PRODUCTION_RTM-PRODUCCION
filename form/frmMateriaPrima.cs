using RitramaAPP.Clases;
using RitramaAPP.form;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace RitramaAPP
{
    public partial class FrmMateriaPrima : Form
    {
        public FrmMateriaPrima()
        {
            InitializeComponent();
        }

        readonly RecepcionManager manager = new RecepcionManager();
        readonly BindingSource bs = new BindingSource();
        DataSet ds = new DataSet();
        int EditMode = 0;
        public RecepcionManager Manager => manager;
        private void FrmMateriaPrima_Load(object sender, EventArgs e)
        {
            ds = Manager.ds;
            bs.DataSource = ds;
            bs.DataMember = "dtrecepcion";
            txt_orden.DataBindings.Add("text", bs, "OrderPurchase");
            txt_part_number.DataBindings.Add("text", bs, "Part_Number");
            txt_width.DataBindings.Add("text", bs, "Width");
            txt_lenght.DataBindings.Add("text", bs, "Lenght");
            txt_roll_id.DataBindings.Add("text", bs, "Roll_Id");
            txt_id_supply.DataBindings.Add("text", bs, "Proveedor_Id");
            txt_ubic.DataBindings.Add("text", bs, "Ubicacion");
            txt_splice.DataBindings.Add("text", bs, "Splice");
            txt_core.DataBindings.Add("text", bs, "Core");
            txt_supply_name.DataBindings.Add("text", bs, "suplidor_des");
            txt_product_name.DataBindings.Add("text", bs, "product_name");
            txt_fecha_produccion.DataBindings.Add("text", bs, "fecha_pro");
            Txt_fecha_recep.DataBindings.Add("text", bs, "fecha_recep");
            rad_masterRolls.DataBindings.Add("checked", bs, "master");
            rad_resmas.DataBindings.Add("checked", bs, "resma");
            rad_graphics.DataBindings.Add("checked", bs, "graphics");
            txt_num_embarque.DataBindings.Add("text", bs, "embarque");
            txt_numero_palet.DataBindings.Add("text", bs, "palet_num");
            txt_cant_palet.DataBindings.Add("text", bs, "palet_cant");
            txt_paginas.DataBindings.Add("text", bs, "palet_pag");
            CHK_ANULADO.DataBindings.Add("checked", bs, "anulado");
            txt_width_metros.DataBindings.Add("text", bs, "width_metros");
            txt_lenght_metros.DataBindings.Add("text", bs, "lenght_metros");
            ContadorRegistros();
        }
        private void Bot_sincro_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Esta seguro de sincronizar los datos desde colector de datos(S/N)?",
                     "Advertencia", MessageBoxButtons.YesNo);
            switch (dr)
            {
                case DialogResult.Yes:
                    TransferirDataMovil();

                    break;
                case DialogResult.No:
                    break;
            }
            //actualizar la pantalla con los cambios de la sincronizacion.
            manager.LoadRecepciones(1);
            bs.Position = 0;
            ContadorRegistros();
        }
        private void TransferirDataMovil()
        {
            RecepcionManager manager = new RecepcionManager();
            List<ClassRecepcion> lista = manager.DownloadDataMateriaPrimaTxtMovil();
            using (FrmSincroRecepciones sincro = new FrmSincroRecepciones
            {
                Lista = lista,
                Dtsupply = ds.Tables["dtprovider"]
            })
            {
                sincro.ShowDialog();
            }
        }
        private void Bot_siguiente_Click(object sender, EventArgs e)
        {
            bs.Position += 1;
            ContadorRegistros();
        }
        private void Bot_anterior_Click(object sender, EventArgs e)
        {
            bs.Position -= 1;
            ContadorRegistros();
        }
        private void Bot_primero_Click(object sender, EventArgs e)
        {
            bs.Position = 0;
            ContadorRegistros();
        }
        private void Bot_ultimo_Click(object sender, EventArgs e)
        {
            bs.Position = bs.Count - 1;
            ContadorRegistros();
        }
        private void ContadorRegistros()
        {
            LABEL_CONTADOR_REGISTRO.Text = (bs.Position + 1) + " de " + (bs.Count.ToString()) + " Registros";
        }

        private void Bot_nuevo_Click(object sender, EventArgs e)
        {
            OpcionesMenu(1);
            OpcionesForms(0);
            DataRow dr = ds.Tables["dtrecepcion"].NewRow();
            dr["fecha_reg"] = DateTime.Today;
            dr["hora_reg"] = DateTime.Now;
            dr["anulado"] = false;
            dr["core"] = 0;
            dr["splice"] = 0;
            dr["width"] = 0;
            dr["lenght"] = 0;
            dr["master"] = false;
            dr["resma"] = false;
            dr["graphics"] = false;
            dr["palet_num"] = "";
            dr["palet_cant"] = 0;
            dr["palet_pag"] = 0;
            ds.Tables["dtrecepcion"].Rows.Add(dr);
            bs.MoveLast();
            EditMode = 1;
            rad_resmas.Checked = false;
            rad_graphics.Checked = false;
            rad_masterRolls.Checked = false;
        }

        private void Bot_grabar_Click(object sender, EventArgs e)
        {
            if (EditMode == 1) GrabarNuevoRegistro();
            if (EditMode == 2) GrabarUpdateRegistro();
        }
        private void GrabarNuevoRegistro()
        {
            //Actualizo la Interfaz Grafica.
            DataRowView FilaActual;
            FilaActual = (DataRowView)bs.Current;
            FilaActual["OrderPurchase"] = txt_orden.Text;
            FilaActual["master"] = rad_masterRolls.Checked;
            FilaActual["resma"] = rad_resmas.Checked;
            FilaActual["Graphics"] = rad_graphics.Checked;
            FilaActual["palet_num"] = txt_numero_palet.Text;
            FilaActual["palet_cant"] = txt_cant_palet.Text;
            FilaActual["palet_PAG"] = txt_paginas.Text;
            bs.EndEdit();
            //Crear el Objeto producto.
            ClassRecepcion recepcion = new ClassRecepcion();
            RecepcionManager recepcionManager = new RecepcionManager();
            recepcion.Orden = txt_orden.Text;
            recepcion.Part_Number = txt_part_number.Text;
            recepcion.ProductName = txt_product_name.Text;
            recepcion.Supply_Id = txt_id_supply.Text;
            recepcion.SupplyName = txt_supply_name.Text;
            recepcion.Width = Convert.ToDouble(txt_width.Text);
            recepcion.Lenght = Convert.ToDouble(txt_lenght.Text);
            recepcion.Width_metros = Convert.ToDouble(txt_width_metros.Text == "" ? "0" : txt_width_metros.Text);
            recepcion.Lenght_metros = Convert.ToDouble(txt_lenght_metros.Text == "" ? "0" : txt_lenght_metros.Text);
            recepcion.Roll_ID = txt_roll_id.Text;
            recepcion.Ubicacion = txt_ubic.Text;
            recepcion.Splice = Convert.ToInt16(txt_splice.Text);
            recepcion.Core = Convert.ToDecimal(txt_core.Text);
            recepcion.Anulado = false;
            recepcion.Fecha_produccion = Convert.ToDateTime(txt_fecha_produccion.Text);
            recepcion.Fecha_recepcion = Convert.ToDateTime(Txt_fecha_recep.Text);
            recepcion.Fecha_reg = DateTime.Today;
            recepcion.Hora_reg = DateTime.Now.ToString("h:mm:ss");
            recepcion.Master = rad_masterRolls.Checked;
            recepcion.Resma = rad_resmas.Checked;
            recepcion.Graphics = rad_graphics.Checked;
            recepcion.Embarque = txt_num_embarque.Text;
            recepcion.Palet_number = txt_numero_palet.Text;
            recepcion.Palet_cant = Convert.ToInt32(txt_cant_palet.Text);
            recepcion.Palet_paginas = Convert.ToInt32(txt_paginas.Text);
            recepcion.Disponible = true;
            // Validar la entidad documento recepcion.
            if (recepcion.Orden == string.Empty)
            {
                MessageBox.Show("Introduzca el numero de orden.");
                return;
            }
            if (recepcion.Roll_ID == string.Empty)
            {
                MessageBox.Show("Introduzca el roll ID.");
                return;
            }
            if (recepcion.Supply_Id == string.Empty)
            {
                MessageBox.Show("Introduzca el ID del proveedor.");
                return;
            }
            if (recepcion.Part_Number == string.Empty)
            {
                MessageBox.Show("Introduzca el part number.");
                return;
            }
            if (rad_masterRolls.Checked == false &&
                rad_graphics.Checked == false &&
                rad_resmas.Checked == false)
            {
                MessageBox.Show("debe suministrar el tipo de producto...");
                return;
            }
            if (rad_masterRolls.Checked)
            {
                if (recepcion.Width <= 0)
                {
                    MessageBox.Show("debe suministrar un valor valido para width del master rolls...");
                    return;
                }
                if (recepcion.Lenght <= 0)
                {
                    MessageBox.Show("debe suministrar un valor valido para lenght del master rolls...");
                    return;
                }
            }
            if (rad_resmas.Checked)
            {
                if (recepcion.Palet_number == "")
                {
                    MessageBox.Show("debe suministrar un valor valido para palet number...");
                    return;
                }
                if (recepcion.Palet_cant <= 0)
                {
                    MessageBox.Show("debe suministrar un valor valido para cantidad en el palet...");
                    return;
                }
            }
            recepcionManager.Add(recepcion, true, 1);
            OpcionesMenu(0);
            OpcionesForms(1);
            ContadorRegistros();
            EditMode = 0;
        }
        private void GrabarUpdateRegistro()
        {
            ClassRecepcion recepcion = new ClassRecepcion
            {
                Orden = txt_orden.Text,
                Fecha_produccion = Convert.ToDateTime(txt_fecha_produccion.Text),
                Fecha_recepcion = Convert.ToDateTime(Txt_fecha_recep.Text),
                Embarque = txt_num_embarque.Text,
                Roll_ID = txt_roll_id.Text,
                Ubicacion = txt_ubic.Text,
                Anulado = CHK_ANULADO.Checked,
                Supply_Id = txt_id_supply.Text,
                Width = Convert.ToDouble(txt_width.Text),
                Lenght = Convert.ToDouble(txt_lenght.Text),
                Width_metros = Convert.ToDouble(txt_width_metros.Text),
                Lenght_metros = Convert.ToDouble(txt_lenght_metros.Text),
                Splice = Convert.ToInt32(txt_splice.Text),
                Core = Convert.ToDecimal(txt_core.Text)
            };
            manager.Update(recepcion, false);
            OpcionesMenu(0);
            OpcionesForms(1);
            EditMode = 0;
        }
        private void OpcionesMenu(int state)
        {
            switch (state)
            {
                case 0:
                    // MODO READ
                    bot_primero.Enabled = true;
                    bot_siguiente.Enabled = true;
                    bot_anterior.Enabled = true;
                    bot_ultimo.Enabled = true;
                    bot_nuevo.Enabled = true;
                    bot_grabar.Enabled = false;
                    bot_cancelar.Enabled = false;
                    bot_modificar.Enabled = true;
                    bot_buscar.Enabled = true;
                    bot_sincro.Enabled = true;
                    break;
                case 1:
                    //MODO ADD OPEN
                    bot_primero.Enabled = false;
                    bot_siguiente.Enabled = false;
                    bot_anterior.Enabled = false;
                    bot_ultimo.Enabled = false;
                    bot_nuevo.Enabled = false;
                    bot_grabar.Enabled = true;
                    bot_cancelar.Enabled = true;
                    bot_modificar.Enabled = false;
                    bot_buscar.Enabled = false;
                    bot_sincro.Enabled = false;
                    break;
            }
        }
        private void OpcionesForms(int state)
        {
            switch (state)
            {
                case 0:
                    // NEW-OPEN
                    bot_search_product.Enabled = true;
                    bot_search_provider.Enabled = true;
                    bot_convert.Enabled = true;
                    txt_orden.ReadOnly = false;
                    txt_part_number.ReadOnly = false;
                    txt_id_supply.ReadOnly = false;
                    txt_roll_id.ReadOnly = false;
                    txt_ubic.ReadOnly = false;
                    txt_num_embarque.ReadOnly = false;
                    txt_fecha_produccion.Enabled = true;
                    Txt_fecha_recep.Enabled = true;
                    //rad_masterRolls.Enabled = true;
                    //rad_resmas.Enabled = true;
                    //rad_graphics.Enabled = true;
                    txt_width.ReadOnly = false;
                    txt_lenght.ReadOnly = false;
                    txt_splice.ReadOnly = false;
                    txt_core.ReadOnly = false;
                    CHK_ANULADO.DataBindings.Clear();
                    rad_masterRolls.DataBindings.Clear();
                    rad_resmas.DataBindings.Clear();
                    rad_graphics.DataBindings.Clear();
                    break;
                case 1:
                    //SAVE-ADD
                    txt_orden.ReadOnly = true;
                    txt_part_number.ReadOnly = true;
                    txt_id_supply.ReadOnly = true;
                    txt_roll_id.ReadOnly = true;
                    txt_ubic.ReadOnly = true;
                    txt_fecha_produccion.Enabled = false;
                    Txt_fecha_recep.Enabled = false;
                    txt_num_embarque.ReadOnly = true;
                    bot_search_product.Enabled = false;
                    bot_search_provider.Enabled = false;
                    bot_convert.Enabled = false;
                    //rad_masterRolls.Enabled = false;
                    //rad_resmas.Enabled = false;
                    //rad_graphics.Enabled = false;
                    if (EditMode == 1)
                    {
                        rad_masterRolls.DataBindings.Add("checked", bs, "master");
                        rad_resmas.DataBindings.Add("checked", bs, "resma");
                        rad_graphics.DataBindings.Add("checked", bs, "graphics");
                        CHK_ANULADO.DataBindings.Add("checked", bs, "anulado");
                    }
                    txt_numero_palet.ReadOnly = true;
                    txt_cant_palet.ReadOnly = true;
                    txt_paginas.ReadOnly = true;
                    txt_width.ReadOnly = true;
                    txt_lenght.ReadOnly = true;
                    txt_splice.ReadOnly = true;
                    txt_core.ReadOnly = true;
                    CHK_ANULADO.Enabled = false;
                    break;
                case 2:
                    //MODO UPDATE-OPEN
                    txt_fecha_produccion.Enabled = true;
                    Txt_fecha_recep.Enabled = true;
                    txt_num_embarque.ReadOnly = false;
                    txt_roll_id.ReadOnly = false;
                    txt_ubic.ReadOnly = false;
                    txt_id_supply.ReadOnly = false;
                    bot_search_provider.Enabled = true;
                    bot_search_product.Enabled = true;
                    txt_part_number.ReadOnly = false;
                    CHK_ANULADO.Enabled = true;
                    if (rad_masterRolls.Checked)
                    {
                        txt_width.ReadOnly = false;
                        txt_lenght.ReadOnly = false;
                        txt_splice.ReadOnly = false;
                        txt_core.ReadOnly = false;
                    }
                    break;
                case 3:
                    break;
            }
        }

        private void Bot_search_provider_Click(object sender, EventArgs e)
        {
            using (SeleccionProveedores BrowseProviders = new SeleccionProveedores
            {
                dtsupply = ds.Tables["dtprovider"]
            })
            {
                BrowseProviders.ShowDialog();
                if (BrowseProviders.GetProviderID == null || BrowseProviders.GetProviderID == string.Empty)
                {
                    return;
                }
                txt_id_supply.Text = BrowseProviders.GetProviderID;
                txt_supply_name.Text = BrowseProviders.GetProviderName;
                chk_master_mts.Checked = manager.VericarMasterollMetros(BrowseProviders.GetProviderID);
            }
        }
        private void Bot_search_product_Click(object sender, EventArgs e)
        {
            using (SeleccionProductos BrowseProducts = new SeleccionProductos
            {
                Dtproducto = ds.Tables["dtproducto"]
            })
            {
                BrowseProducts.ShowDialog();
                if (BrowseProducts.GetProductId == null || BrowseProducts.GetProductId == string.Empty)
                {
                    return;
                }
                txt_part_number.Text = BrowseProducts.GetProductId;
                txt_product_name.Text = BrowseProducts.GetProductName;
                int tipo = manager.VerifarProductType(BrowseProducts.GetProductId);
                if (tipo == 1)
                {
                    rad_masterRolls.Checked = true;
                }
                else if (tipo == 2)
                {
                    rad_resmas.Checked = true;
                }
                else if (tipo == 3)
                {
                    rad_graphics.Checked = true;
                }
            }

        }
        private void Txt_orden_Validating(object sender, CancelEventArgs e)
        {
            if (manager.OrderExiste(txt_orden.Text) && EditMode == 1)
            {
                MessageBox.Show("La Orden Purchase : " + txt_orden.Text + " ya existe.");
                txt_orden.Text = "";
            }
        }
        private void Rad_resma_CheckedChanged(object sender, EventArgs e)
        {
            //if (rad_resmas.Checked)
            //{
            //    txt_numero_palet.ReadOnly = false;
            //    txt_cant_palet.ReadOnly = false;
            //    txt_paginas.ReadOnly = false;
            //}
            //else
            //{
            //    txt_numero_palet.ReadOnly = true;
            //    txt_cant_palet.ReadOnly = true;
            //    txt_paginas.ReadOnly = true;
            //}
        }
        private void Rad_masterRolls_CheckedChanged(object sender, EventArgs e)
        {
            //if (EditMode == 1 || EditMode == 2)
            //{
            //    if (rad_masterRolls.Checked)
            //    {
            //        txt_width.ReadOnly = false;
            //        txt_lenght.ReadOnly = false;
            //        txt_core.ReadOnly = false;
            //        txt_splice.ReadOnly = false;
            //    }
            //    else
            //    {
            //        txt_width.ReadOnly = true;
            //        txt_lenght.ReadOnly = true;
            //        txt_core.ReadOnly = true;
            //        txt_splice.ReadOnly = true;
            //    }
            //}
        }
        private void Rad_graphics_CheckedChanged(object sender, EventArgs e)
        {
            //if (EditMode == 1 || EditMode == 2)
            //{
            //    if (rad_graphics.Checked)
            //    {
            //        txt_numero_palet.ReadOnly = false;
            //        txt_cant_palet.ReadOnly = false;
            //    }
            //    else
            //    {
            //        txt_numero_palet.ReadOnly = true;
            //        txt_cant_palet.ReadOnly = true;
            //    }
            //}
        }
        private void Rad_resmas_CheckedChanged(object sender, EventArgs e)
        {
            if (EditMode == 1 || EditMode == 2)
            {
                if (rad_resmas.Checked)
                {
                    txt_numero_palet.ReadOnly = false;
                    txt_cant_palet.ReadOnly = false;
                    txt_paginas.ReadOnly = false;
                    txt_width.ReadOnly = false;
                    txt_lenght.ReadOnly = false;
                }
                else
                {
                    txt_numero_palet.ReadOnly = true;
                    txt_cant_palet.ReadOnly = false;
                    txt_paginas.ReadOnly = false;
                    txt_width.ReadOnly = true;
                    txt_lenght.ReadOnly = true;

                }
            }
        }

        private void Bot_convert_Click(object sender, EventArgs e)
        {
            if (chk_master_mts.Checked && rad_masterRolls.Checked
                && Convert.ToDouble(txt_width.Text) > 0
                && Convert.ToDouble(txt_lenght.Text) > 0)
            {
                DialogResult dr = MessageBox.Show("Esta seguro de convertir los valores de width y lenght a pulgadas-pies(S/N)?",
                      "Mood Test", MessageBoxButtons.YesNo);
                switch (dr)
                {
                    case DialogResult.Yes:
                        double value_width = Math.Round((Convert.ToDouble(txt_width.Text) * R.CONSTANTES.FACTOR_METROS_PULDADAS), 2, MidpointRounding.ToEven);
                        double value_lengh = Math.Round((Convert.ToDouble(txt_lenght.Text) * R.CONSTANTES.FACTOR_METROS_PIES), 2, MidpointRounding.ToEven);
                        txt_width.Text = Convert.ToString(value_width);
                        txt_lenght.Text = Convert.ToString(value_lengh);
                        bot_convert.Enabled = false;
                        break;
                    case DialogResult.No:
                        break;
                }
            }
        }

        private void Bot_cancelar_Click(object sender, EventArgs e)
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
                OpcionesForms(1);
                EditMode = 0;
            }
            if (EditMode == 2)
            {
                OpcionesMenu(0);
                OpcionesForms(0);
                EditMode = 0;
            }
        }

        private void Bot_buscar_Click(object sender, EventArgs e)
        {
            using (SeleccionMateriaPrima frmbuscarOrden = new SeleccionMateriaPrima
            {
                dtrecepcion = ds.Tables["dtrecepcion"]
            })
            {
                frmbuscarOrden.ShowDialog();
                int itemFound = bs.Find("OrderPurchase", frmbuscarOrden.GetOrderbyID);
                bs.Position = itemFound;
            }

        }

        private void Bot_modificar_Click(object sender, EventArgs e)
        {
            OpcionesMenu(1);
            OpcionesForms(2);
            EditMode = 2;
        }
        private void FrmMateriaPrima_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void Toolsbar_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void Txt_width_KeyUp(object sender, KeyEventArgs e)
        {
            if (txt_width.Text == "")
            {
                return;
            }
            if (rad_masterRolls.Checked) 
            {
                CONVERT_INCH_METROS();
            }
            
        }

        private void Txt_lenght_KeyUp(object sender, KeyEventArgs e)
        {
            if (txt_lenght.Text == "")
            {
                return;
            }
            if (rad_masterRolls.Checked) 
            {
                CONVERT_PIES_METROS();
            }
            
        }
        private void CONVERT_INCH_METROS()
        {
            double width_inch_metros = Math.Round(Convert.ToDouble(txt_width.Text)
                * R.CONSTANTES.FACTOR_PULGADAS_METROS, 2);
            txt_width_metros.Text = width_inch_metros.ToString();
        }
        private void CONVERT_PIES_METROS()
        {
            double width_pie_metros = Math.Round(Convert.ToDouble(txt_lenght.Text)
                * R.CONSTANTES.FACTOR_PIES_METROS, 2);
            txt_lenght_metros.Text = width_pie_metros.ToString();
        }

        private void Bot_excel_Click(object sender, EventArgs e)
        {
            FrmImportExcelMP excel = new FrmImportExcelMP();
            excel.ShowDialog();
        }

        private void Txt_width_KeyPress(object sender, KeyPressEventArgs e)
        {
            string CaracValid = "0123456789.,";
            if (e.KeyChar != Convert.ToChar(8) && CaracValid.IndexOf(e.KeyChar) == -1)
            {
                // si no es bakcspace y no es un numero se omite.   
                e.Handled = true;
            }
        }

        private void Txt_lenght_KeyPress(object sender, KeyPressEventArgs e)
        {
            string CaracValid = "0123456789.,";
            if (e.KeyChar != Convert.ToChar(8) && CaracValid.IndexOf(e.KeyChar) == -1)
            {
                // si no es bakcspace y no es un numero se omite.   
                e.Handled = true;
            }
        }

        private void Txt_lenght_TextChanged(object sender, EventArgs e)
        {

        }

        private void Txt_roll_id_Validating(object sender, CancelEventArgs e)
        {
            if (manager.VerificarID(txt_roll_id.Text) && EditMode == 1)
            {
                MessageBox.Show("Numero de ID ya existe...");
                txt_roll_id.Text = "";
                txt_roll_id.Focus();
            }
        }
    }
}
