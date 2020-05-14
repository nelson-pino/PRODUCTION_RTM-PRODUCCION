using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using Microsoft.Office.Interop.Excel;
using RitramaAPP.Clases;
using RitramaAPP.form;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using DataTable = System.Data.DataTable;

namespace RitramaAPP
{
    public partial class FrmOrdenCorte : Form
    {
        public FrmOrdenCorte()
        {
            InitializeComponent();
        }
        readonly ProduccionManager managerorden = new ProduccionManager();
        readonly ConfigManager configmanager = new ConfigManager();
        readonly BindingSource bs = new BindingSource();
        readonly BindingSource bsdetalle = new BindingSource();
        readonly DataTable dtproducts = new System.Data.DataTable();
        DataSet ds = new DataSet();
        private DataRowView ParentRow;
        int EditMode = 0;
        //Boolean ischanged_rollos;
        string rollid1_tipomov = string.Empty;
        string rollid2_tipomov = string.Empty;
        string modproduct_id;
        Orden orden;
        public static List<Corte> listacorte;
        Roll_Details ROLLID_A, ROLLID_B;
        Boolean MultipleSelectId = false;

        private void FrmOrdenCorte_Load(object sender, EventArgs e)
        {
            AplicarEstilosGridRollos();
            AplicarEstilosGridCortes();
            ds = managerorden.ds;
            bs.DataSource = ds;
            bs.DataMember = "dtordenes";
            bs.Sort = "numero DESC";
            DataBinding();
            //binding del detalle
            bsdetalle.DataSource = bs;
            bsdetalle.DataMember = "FK_ORDEN_DETAILS";
            grid_rollos.DataSource = bsdetalle;
            VERIFICAR_DOCUMENTO();
            RefrescarStepIndicator();
        }
        private void RefrescarStepIndicator() 
        {
            int step;
            if (string.IsNullOrEmpty(TXT_STEP_DOCUMENT.Text))
            {
                step = 0;
            }
            else
            {
                step = Convert.ToInt16(TXT_STEP_DOCUMENT.Text);
            }
            Update_StepIndicator(step);
        }
        private void AplicarEstilosGridCortes() 
        {
            grid_cortes.AutoGenerateColumns = false;
            AGREGAR_COLUMN_GRID("num", 25, "It.", "Num", grid_cortes);
            AGREGAR_COLUMN_GRID("width", 45, "Width", "width", grid_cortes);
            AGREGAR_COLUMN_GRID("lenght", 45, "Lenght", "lenght", grid_cortes);
            AGREGAR_COLUMN_GRID("msi", 45, "Msi", "msi", grid_cortes);
            grid_cortes.Columns["num"].ReadOnly = true;
            grid_cortes.Columns["lenght"].ReadOnly = true;
            grid_cortes.Columns["msi"].ReadOnly = true;

        }
        private void Update_StepIndicator(int step) 
        {
            switch (step) 
            {
                case 1:
                    LABEL_STATE.Text = R.CONSTANTES.DOCUMENT_OC_STEP1;
                    PictureStep1.BackColor = Color.FromArgb(102, 255, 51);
                    PictureStep2.BackColor = Color.FromArgb(224, 224, 224);
                    PictureStep3.BackColor = Color.FromArgb(224, 224, 224);
                    PictureStep4.BackColor = Color.FromArgb(224, 224, 224);
                    PictureStep4.BackColor = Color.FromArgb(224, 224, 224);
                    PictureStep5.BackColor = Color.FromArgb(224, 224, 224);
                    break;
                case 2:
                    LABEL_STATE.Text = R.CONSTANTES.DOCUMENT_OC_STEP2;
                    PictureStep1.BackColor = Color.FromArgb(51, 51, 0);
                    PictureStep2.BackColor = Color.FromArgb(102, 255, 51);
                    PictureStep3.BackColor = Color.FromArgb(224, 224, 224);
                    PictureStep4.BackColor = Color.FromArgb(224, 224, 224);
                    PictureStep4.BackColor = Color.FromArgb(224, 224, 224);
                    PictureStep5.BackColor = Color.FromArgb(224, 224, 224);
                    break;
                case 3:
                    LABEL_STATE.Text = R.CONSTANTES.DOCUMENT_OC_STEP3;
                    PictureStep1.BackColor = Color.FromArgb(51, 51, 0);
                    PictureStep2.BackColor = Color.FromArgb(51, 51, 0);
                    PictureStep3.BackColor = Color.FromArgb(102, 255, 51);
                    PictureStep4.BackColor = Color.FromArgb(224, 224, 224);
                    PictureStep4.BackColor = Color.FromArgb(224, 224, 224);
                    PictureStep5.BackColor = Color.FromArgb(224, 224, 224);
                    break;
                case 4:
                    LABEL_STATE.Text = R.CONSTANTES.DOCUMENT_OC_STEP4;
                    PictureStep1.BackColor = Color.FromArgb(51, 51, 0);
                    PictureStep2.BackColor = Color.FromArgb(51, 51, 0);
                    PictureStep3.BackColor = Color.FromArgb(51, 51, 0);
                    PictureStep4.BackColor = Color.FromArgb(102, 255, 51);
                    PictureStep5.BackColor = Color.FromArgb(224, 224, 224);
                    break;
                case 5:
                    LABEL_STATE.Text = R.CONSTANTES.DOCUMENT_OC_STEP5;
                    PictureStep1.BackColor = Color.FromArgb(51, 51, 0);
                    PictureStep2.BackColor = Color.FromArgb(51, 51, 0);
                    PictureStep3.BackColor = Color.FromArgb(51, 51, 0);
                    PictureStep4.BackColor = Color.FromArgb(51, 51, 0);
                    PictureStep5.BackColor = Color.FromArgb(102, 255, 51);
                    break;
                default:
                    PictureStep1.BackColor = Color.FromArgb(51, 51, 0);
                    PictureStep2.BackColor = Color.FromArgb(51, 51, 0);
                    PictureStep3.BackColor = Color.FromArgb(51, 51, 0);
                    PictureStep4.BackColor = Color.FromArgb(51, 51, 0);
                    PictureStep5.BackColor = Color.FromArgb(51, 51, 0);
                    LABEL_STATE.Text = R.CONSTANTES.DOCUMENT_OC_STEP0;
                    break;
            }
        }


        #region ENLACE_DATOS
        private void DataBinding()
        {
            txt_numero_oc.DataBindings.Add("text", bs, "numero");
            txt_fecha_orden.DataBindings.Add("text", bs, "fecha");
            txt_fecha_producc.DataBindings.Add("text", bs, "fecha_produccion");
            txt_rollid_1.DataBindings.Add("text", bs, "rollid_1");
            txt_width1_rollid.DataBindings.Add("text", bs, "width_1");
            txt_lenght1_rollid.DataBindings.Add("text", bs, "lenght_1");
            txt_rollid_2.DataBindings.Add("text", bs, "rollid_2");
            txt_width2_rollid.DataBindings.Add("text", bs, "width_2");
            txt_lenght2_rollid.DataBindings.Add("text", bs, "lenght_2");
            txt_product_id.DataBindings.Add("text", bs, "product_id");
            txt_product_name.DataBindings.Add("text", bs, "product_name");
            //chk_process.DataBindings.Add("Checked", bs, "procesado");
            chk_anulado.DataBindings.Add("Checked", bs, "anulada");
            txt_cort_total_ancho.DataBindings.Add("text", bs, "tot_inch_ancho");
            txt_cort_long_cortar.DataBindings.Add("text", bs, "longitud_cortar");
            txt_cort_ancho.DataBindings.Add("text", bs, "cortes_ancho");
            txt_cort_largo.DataBindings.Add("text", bs, "cortes_largo");
            txt_cort_rollos_cortar.DataBindings.Add("text", bs, "cant_rollos");
            txt_pies_malos.DataBindings.Add("text", bs, "decartable1_pies");
            txt_pies_real.DataBindings.Add("text", bs, "lenght_master_real");
            txt_width_u.DataBindings.Add("text", bs, "util1_real_width");
            txt_lenght_u.DataBindings.Add("text", bs, "util1_real_lenght");
            txt_width1_r.DataBindings.Add("text", bs, "rest1_width");
            txt_lenght1_r.DataBindings.Add("text", bs, "rest1_lenght");
            txt_pies_malos2.DataBindings.Add("text", bs, "descartable2_pies");
            txt_pies_real2.DataBindings.Add("text", bs, "lenght_master_real2");
            txt_width2_r.DataBindings.Add("text", bs, "rest2_width");
            txt_lenght2_r.DataBindings.Add("text", bs, "rest2_lenght");
            txt_width_u2.DataBindings.Add("text", bs, "util2_real_width");
            txt_lenght_u2.DataBindings.Add("text", bs, "util2_real_lenght");
            txt_cort_largo2.DataBindings.Add("text", bs, "cortes_largo2");
            txt_cort_rollos_cortar2.DataBindings.Add("text", bs, "cant_rollos2");
            TXT_STEP_DOCUMENT.DataBindings.Add("text", bs, "step");
        }
        #endregion

        #region FUNCTIONS
        private void ToSaveAdd()
        {
            if (managerorden.OrderExiste(Convert.ToInt16(txt_numero_oc.Text)))
            {
                MessageBox.Show("La Orden produccion : " + txt_numero_oc.Text + " ya existe.");
                txt_numero_oc.Text = "";
                return;
            }
            //validar el formulario
            if (txt_numero_oc.Text.Length == 0 || txt_numero_oc.Text == "0")
            {
                MessageBox.Show("introduzca el numero de la orden");
                return;
            }
            if (txt_rollid_1.Text.Length == 0)
            {
                MessageBox.Show("introduzca el numero de Roll ID.");
                return;
            }
            if (txt_product_id.Text.Length == 0)
            {
                MessageBox.Show("introduzca el product id.");
                return;
            }
            if (grid_rollos.Rows.Count == 0)
            {
                MessageBox.Show("No puede grabar una orden sin renglones...");
                return;
            }
            //verificar si el master restante es negativo.
            if (Convert.ToDouble(txt_width1_r.Text) < 0 || Convert.ToDouble(txt_lenght1_r.Text) < 0)
            {
                MessageBox.Show("Los valores del master restante no puede ser negativo...");
                return;
            }
            //llenar el encabezado de la orden de produccion
            managerorden.Add(CrearObjectOrden(1), false);
            
            //chk_process.DataBindings.Add("Checked", bs, "procesado");
            chk_anulado.DataBindings.Add("Checked", bs, "anulada");
            //actualizar la interfaz grafica.
            DataRowView filaActual;
            filaActual = (DataRowView)bs.Current;
            filaActual["step"] = 1;
            bs.EndEdit();

            //marcar los master-rollid como cargado en documentos.
            managerorden.MarkMasterRollidLoadDocument(orden.Tipo_Mov1,orden.Rollid_1,orden.Numero);   


            OptionsMenu(1);
            OptionsForm(1);
            EditMode = 0;
            Update_StepIndicator(1);
        }
        private void RUN_INVENTARIO() 
        {
            
            Orden orden = CrearObjectOrden(0);
            if (chk_rebobinado.Checked == false)
            {
                UPDATE_INVENTARIO_MASTER(orden);
            }
            else
            {
                UPDATE_INVENTARIO_REBO(orden);
            }
        }
        private void UPDATE_INVENTARIO_REBO(Orden orden)
        {
            if (Convert.ToDouble(txt_lenght1_r.Text) > 0)
            {
                // RESTO EL CONSUMO ACTUALIZO MASTER1
                managerorden.UPDATE_INVENTARIO_RC(orden.Rollid_1, orden.Util1_Real_Width
                    , orden.Util1_real_Lenght + orden.Descartable1_pies);
            }
            else
            {
                // SE CONSUMIO TODO LO SACO DEL INVENTARIO
                managerorden.UpdateUniqueCode(orden.Rollid_1);
            }
        }
        private void UPDATE_INVENTARIO_MASTER(Orden orden)
        {
            Boolean MasterEmpty = false;
            //comprobar que hay master remanente master 1.
            if (Convert.ToDouble(txt_lenght1_r.Text) > 0)
            {
                //REGLA SI EL LENGHT DEL MASTER < 100 PIES LO SACO DEL INVENTARIO.

                if (Convert.ToDouble(txt_lenght1_r.Text) <= 100)
                {
                    MasterEmpty = true;
                }

                // RESTO EL CONSUMO ACTUALIZO MASTER1
                managerorden.Update_Inventario_Master(orden.Rollid_1, orden.Util1_Real_Width
                    , orden.Util1_real_Lenght + orden.Descartable1_pies, rollid1_tipomov,MasterEmpty);
            }
            else
            {
                // SE CONSUMIO TODO LO SACO DEL INVENTARIO
                managerorden.UpdateRollId(orden.Rollid_1, rollid1_tipomov);
            }

            //comprobar que hay master remanente master 2.
            Boolean MasterEmpty2 = false;
            if (Convert.ToDouble(txt_lenght2_r.Text) > 0)
            {
                //REGLA SI EL LENGHT DEL MASTER < 100 PIES LO SACO DEL INVENTARIO.
                if (Convert.ToDouble(txt_lenght2_r.Text) <= 100)
                {
                    MasterEmpty2 = true;
                }


                // RESTO EL CONSUMO ACTUALIZO MASTER2
                managerorden.Update_Inventario_Master(orden.Rollid_2, orden.Util2_Real_Width
                    , orden.Util2_real_Lenght + orden.Descartable2_pies, rollid2_tipomov,MasterEmpty2);
            }
            else
            {
                // SE CONSUMIO TODO LO SACO DEL INVENTARIO
                managerorden.UpdateRollId(orden.Rollid_2, rollid2_tipomov);
            }
        }
        private void ToSaveUpdate()
        {
            managerorden.Update_Only(CrearObjectOrden(2), false);
            //Actualizar la Interfaz Grafica
            DataRowView rowcurrent;
            rowcurrent = (DataRowView)bs.Current;
            rowcurrent["step"] = 2;
            bs.EndEdit();
            EditMode = 0;
            OptionsMenu(1);
            OptionsForm(1);
            Update_StepIndicator(2);
        }
        private void CargarRollIDNumber(int state)
        {
            //state 0 = rollid1 state 1 = rollid2
            using (FrmBuscarRollid rollid = new FrmBuscarRollid())
            {
                rollid.Dtrollid = managerorden.CargarRollsId();
                rollid.ShowDialog();

                if (state == 0)
                {
                    //Validar si el master esta montado en otro documento.
                    if (managerorden.CheckMasterDocumentOc(rollid.GetrollId)) 
                    {
                        MessageBox.Show("El roll-id que acaba se seleccionar esta montada en otra orden de corte.");
                        return;
                    }
                    ROLLID_A = new Roll_Details
                    {
                    

                        Product_id = rollid.Getproduct_id,
                        Product_name = rollid.GetProduct_name,
                        Roll_id = rollid.GetrollId,
                        Width = Convert.ToDecimal(rollid.GetValueWidth),
                        Large = Convert.ToDecimal(rollid.GetvalueLenght),
                        Tipo_mov = rollid.Gettipo_mov
                    };
                    txt_rollid_1.Text = ROLLID_A.Roll_id;
                    txt_width1_rollid.Text = Convert.ToString(ROLLID_A.Width);
                    txt_lenght1_rollid.Text = Convert.ToString(ROLLID_A.Large);
                    txt_pies_real.Text = Convert.ToString(ROLLID_A.Large);
                    txt_product_id.Text = ROLLID_A.Product_id;
                    txt_product_name.Text = ROLLID_A.Product_name;
                    rollid1_tipomov = ROLLID_A.Tipo_mov;

                    //verificar si es rebobinado.
                    if (rollid.Rebobinado == true)
                    {
                        chk_rebobinado.Checked = true;
                    }
                    else
                    {
                        chk_rebobinado.Checked = false;
                    }
                }
                else
                {
                    //Validar si el master esta montado en otro documento.
                    if (managerorden.CheckMasterDocumentOc(rollid.GetrollId))
                    {
                        MessageBox.Show("El roll-id que acaba se seleccionar esta montada en otra orden de corte.");
                        return;
                    }
                    ROLLID_B = new Roll_Details
                    {
                        Product_id = rollid.Getproduct_id,
                        Product_name = rollid.GetProduct_name,
                        Roll_id = rollid.GetrollId,
                        Width = Convert.ToDecimal(rollid.GetValueWidth),
                        Large = Convert.ToDecimal(rollid.GetvalueLenght),
                        Tipo_mov = rollid.Gettipo_mov
                    };
                    txt_rollid_2.Text = ROLLID_B.Roll_id;
                    txt_width2_rollid.Text = Convert.ToString(ROLLID_B.Width); ;
                    txt_lenght2_rollid.Text = Convert.ToString(ROLLID_B.Large);
                    txt_pies_real2.Text = Convert.ToString(ROLLID_B.Large);
                    rollid2_tipomov = ROLLID_B.Tipo_mov;
                    MultipleSelectId = true;
                }
                if (MultipleSelectId) 
                {
                    if (ROLLID_A.Product_id != ROLLID_B.Product_id)
                    {
                        MessageBox.Show("No puede seleccionar ID con productos distintos...");
                        LimpiarID();
                        MultipleSelectId = false;
                    }
                    else
                    {
                        if (ROLLID_A.Width != ROLLID_B.Width) 
                        {
                            MessageBox.Show("No puede seleccionar master con anchos distintos...");
                            LimpiarID();
                            MultipleSelectId = false;
                        }
                    }
                    if(ROLLID_A.Roll_id == ROLLID_B.Roll_id)
                    {
                        MessageBox.Show("No puede seleccionar dos veces el mismo id...");
                        LimpiarID();
                        MultipleSelectId = false;
                    }
                }
            }
        }
        private void LimpiarID() 
        {
            txt_rollid_2.Text = "0";
            txt_width2_rollid.Text = "0";
            txt_lenght2_rollid.Text = "0";
            txt_pies_real2.Text = "0";
            rollid2_tipomov = "0";
        }
        private void ContadorRegistros()
        {
            contador.Text = "Documento :" + (bs.Position + 1).ToString() + "/" + bs.Count.ToString();
        }
        private void ExportDatatoExcel()
        {
            try
            {
                Microsoft.Office.Interop.Excel.Application oExcel = null;
                Workbook wb = null;
                Worksheet sheet = null;
                oExcel = new Microsoft.Office.Interop.Excel.Application();
                string filePath = Path.GetFullPath(@"C:\Users\Npino\Desktop\DATA\tickets_oc.xlsx");
                //oExcel.Visible = true;
                wb = oExcel.Workbooks.Open(filePath);
                sheet = wb.Worksheets[1];
                sheet.Name = "prueba c#";
                int fila = 1;
                while (string.IsNullOrEmpty(((sheet.Cells[fila, 1]).Text.ToString())) == false)
                {
                    sheet.Rows.Delete();
                    fila += 1;
                }
                sheet.Cells[1, 1] = "Fecha";
                sheet.Cells[1, 2] = "Orden";
                sheet.Cells[1, 3] = "Roll #";
                sheet.Cells[1, 4] = "Product Id.";
                sheet.Cells[1, 5] = "Descripcion del Producto";
                sheet.Cells[1, 6] = "width (inch)";
                sheet.Cells[1, 7] = "large (pies)";
                sheet.Cells[1, 8] = "Msi";
                sheet.Cells[1, 9] = "Codigo Personalizado";
                sheet.Cells[1, 10] = "Roll ID";
                sheet.Cells[1, 11] = "Code Unique";
                sheet.Cells[1, 12] = "Splice";
                sheet.Cells[4].EntireColumn.NumberFormat = "@";
                string mproduct_id = grid_rollos.Rows[0].Cells["product_id"].Value.ToString();
                for (int i = 1; i <= grid_rollos.Rows.Count; i++)
                {
                    sheet.Cells[i + 1, 1] = Convert.ToDateTime(txt_fecha_orden.Text).Day + "-" + Convert.ToDateTime(txt_fecha_orden.Text).Month + "-" + Convert.ToDateTime(txt_fecha_orden.Text).Year;
                    sheet.Cells[i + 1, 2] = txt_numero_oc.Text;
                    sheet.Cells[i + 1, 3] = grid_rollos.Rows[i - 1].Cells["roll"].Value;
                    sheet.Cells[i + 1, 4] = mproduct_id;
                    sheet.Cells[i + 1, 5] = grid_rollos.Rows[i - 1].Cells["product_name"].Value;
                    sheet.Cells[i + 1, 6] = grid_rollos.Rows[i - 1].Cells["ancho"].Value;
                    sheet.Cells[i + 1, 7] = grid_rollos.Rows[i - 1].Cells["largo"].Value;
                    sheet.Cells[i + 1, 8] = grid_rollos.Rows[i - 1].Cells["msi"].Value;
                    sheet.Cells[i + 1, 9] = grid_rollos.Rows[i - 1].Cells["code_personalize"].Value;
                    sheet.Cells[i + 1, 10] = grid_rollos.Rows[i - 1].Cells["roll_id"].Value;
                    sheet.Cells[i + 1, 11] = grid_rollos.Rows[i - 1].Cells["Unique_Code"].Value;
                    sheet.Cells[i + 1, 12] = grid_rollos.Rows[i - 1].Cells["splice"].Value;
                }
                wb.Save();
                wb.Close();
                oExcel.Quit();
                MessageBox.Show("se sincronizo data con excel");
            }
            catch (Exception ex)
            {
                MessageBox.Show("error al transmitir data a excel. error code:" + ex);
            }

        }
        private void AplicarEstilosGridRollos()
        {
            grid_rollos.AutoGenerateColumns = false;
            AGREGAR_COLUMN_GRID("roll", 30, "#", "roll_number", grid_rollos);
            AGREGAR_COLUMN_GRID("product_id", 50, "Prod. Id", "product_id", grid_rollos);
            AGREGAR_COLUMN_GRID("product_name", 190, "Descripcion Producto", "product_name", grid_rollos);
            AGREGAR_COLUMN_GRID("Unique_Code", 65, "Unique Code", "unique_code", grid_rollos);
            AGREGAR_COLUMN_GRID("ancho", 52, "Ancho", "width", grid_rollos);
            AGREGAR_COLUMN_GRID("largo", 52, "largo", "large", grid_rollos);
            AGREGAR_COLUMN_GRID("msi", 40, "Msi", "msi", grid_rollos);
            AGREGAR_COLUMN_GRID("splice", 40, "Splice", "splice", grid_rollos);
            AGREGAR_COLUMN_GRID("roll_id", 70, "Roll Id.", "Roll_id", grid_rollos);
            AGREGAR_COLUMN_GRID("code_personalize", 100, "Code Person.", "code_person", grid_rollos);
            DataGridViewComboBoxColumn col = new DataGridViewComboBoxColumn();
            col.Items.Add("Ok");
            col.Items.Add("Rechazado");
            col.Items.Add("Retenido");
            col.Items.Add("Reservado");
            col.Name = "status";
            col.HeaderText = "status";
            col.DataPropertyName = "status";
            col.Width = 60;
            col.FlatStyle = FlatStyle.Popup;
            grid_rollos.Columns.Add(col);
        }
        private void ConfigurarCortes()
        {
            listacorte = new List<Corte>();

            for (int i = 1; i <= 5; i++)
            {
                Corte item = new Corte
                {
                    Num = i
                };
                listacorte.Add(item);
            }
            grid_cortes.DataSource = listacorte;

            txt_cort_total_ancho.Text = "0";
            txt_cort_long_cortar.Text = "0";
            txt_cort_ancho.Text = "0";
            txt_cort_largo.Text = "0";
            txt_cort_rollos_cortar.Text = "0";

        }
        private void VERIFICAR_DOCUMENTO()
        {
            if (bs.Count == 0) 
            {
                return;
            }

            //buscar los datos de los cortes de la orden.
            grid_cortes.DataSource = managerorden.CargarDataCortes(txt_numero_oc.Text.Trim());
            // verificar documentos cerrados
            DataRowView RowCurrent = (DataRowView)bs.Current;
            if (RowCurrent["step"].ToString() == "5" || Convert.ToBoolean(RowCurrent["anulada"]) == true) 
            {
                NO_ACTIONS();
            }
            else 
            {
                ACTIONS_ENABLED();
            }
            if (Convert.ToBoolean(RowCurrent["anulada"]) == true) 
            {
                PictDocumentStatus.Visible = true;
            }
            else 
            {
                PictDocumentStatus.Visible = false;
            }
            
        }
        private void ACTIONS_ENABLED() 
        {
            Action_UpdateDocument.Enabled = true;
            Action_LabelProducts.Enabled = true;
            Action_AutorizeDocument.Enabled = true;
            Action_CloseDocument.Enabled = true;
            BOT_IMPRIMIR.Enabled = true;
        }
        private void NO_ACTIONS() 
        {
            Action_UpdateDocument.Enabled = false;
            Action_LabelProducts.Enabled = false;
            Action_AutorizeDocument.Enabled = false;
            Action_CloseDocument.Enabled = false;
        }
        private void FUNCTION_GENERATE_ROLL_DETAILS()
        {
            if (EditMode == 2 || grid_rollos.Rows.Count > 0)
            {
                try
                {
                    //borrar los todos registros
                    List<DataRow> toDelete = new List<DataRow>();
                    foreach (DataGridViewRow row in grid_rollos.Rows)
                    {
                        toDelete.Add(((DataRowView)row.DataBoundItem).Row);
                    }
                    toDelete.ForEach(row => row.Delete());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            List<Roll_Details> lista = GENERAR_DETALLE_ROLLOS_CORTADOS();


            //Agregar encabezado a la orden.
            ParentRow.BeginEdit();
            ParentRow["numero"] = txt_numero_oc.Text;
            ParentRow["fecha"] = txt_fecha_orden.Text;
            ParentRow["fecha_produccion"] = txt_fecha_producc.Text;
            ParentRow["rollid_1"] = txt_rollid_1.Text;
            ParentRow["width_1"] = txt_width1_rollid.Text;
            ParentRow["lenght_1"] = txt_lenght1_rollid.Text;
            ParentRow["rollid_2"] = txt_rollid_2.Text;
            ParentRow["width_2"] = txt_width2_rollid.Text;
            ParentRow["lenght_2"] = txt_lenght2_rollid.Text;
            ParentRow["product_id"] = txt_product_id.Text;
            ParentRow["anulada"] = false;
            ParentRow["procesado"] = false;
            ParentRow.EndEdit();
            //Agregar el detalle de la Orden.
            DataRowView ChildRows;
            string CodeRC = managerorden.GetCodeRC(txt_product_id.Text.Trim());
            foreach (Roll_Details item in lista)
            {
                ChildRows = (DataRowView)bsdetalle.AddNew();
                ChildRows.BeginEdit();
                ChildRows["numero"] = item.Numero_Orden;
                ChildRows["roll_number"] = item.Roll_number;
                ChildRows["product_id"] = CodeRC;
                ChildRows["product_name"] = item.Product_name;
                ChildRows["unique_code"] = item.Unique_code;
                ChildRows["width"] = double.Parse(item.Width.ToString(), CultureInfo.InvariantCulture);
                ChildRows["large"] = item.Large;
                ChildRows["Msi"] = item.Msi;
                ChildRows["Splice"] = item.Splice;
                ChildRows["Roll_id"] = item.Roll_id;
                ChildRows["Code_Person"] = item.Code_Person;
                ChildRows["Status"] = item.Status;
                ChildRows.Row.SetParentRow(ParentRow.Row);
                ChildRows.EndEdit();
            }
            bs.EndEdit();
            if (EditMode == 1)
            {
                bs.Position = bs.Count - 1;
                bot_generar_rollos_cortados.Enabled = false;
            }
            //ischanged_rollos = true;
        }
        private void CALCULAR_MSI_RENGLON(int fila)
        {
            if (EditMode != 0 || Convert.ToDouble(grid_rollos.Rows[fila].Cells["largo"].Value) > 0 ||
                 Convert.ToDouble(grid_rollos.Rows[fila].Cells["ancho"].Value) > 0)
            {
                try
                {
                    double msi = ((Convert.ToDouble(grid_rollos.Rows[fila].Cells["ancho"].Value)
                            * Convert.ToDouble(grid_rollos.Rows[fila].Cells["largo"].Value))
                            * R.CONSTANTES.FACTOR_CALCULO_MSI);
                    grid_rollos.Rows[fila].Cells["msi"].Value = msi.ToString();
                }
                catch (Exception)
                {


                    grid_rollos.Rows[fila].Cells["msi"].Value = "0";
                }


            }
        }
        private void LoadTipoMov() 
        {
            DataRowView rowcurrent = (DataRowView)bs.Current;
            rollid1_tipomov = rowcurrent["tipo_mov1"].ToString();
            rollid2_tipomov = rowcurrent["tipo_mov2"].ToString();
        }
        private Orden CrearObjectOrden(int state)
        {
            orden = new Orden
            {
                Numero = (txt_numero_oc.Text),
                Fecha = Convert.ToDateTime(txt_fecha_orden.Text),
                Fecha_produccion = Convert.ToDateTime(txt_fecha_producc.Text),
                Product_id = txt_product_id.Text,
                Rollid_1 = txt_rollid_1.Text.ToString(),
                Width_1 = Convert.ToDecimal(txt_width1_rollid.Text),
                Lenght_1 = Convert.ToDecimal(txt_lenght1_rollid.Text),
                Rollid_2 = txt_rollid_2.Text,
                Width_2 = Convert.ToDecimal(txt_width2_rollid.Text),
                Lenght_2 = Convert.ToDecimal(txt_lenght2_rollid.Text),
                Inch_Ancho = Convert.ToDouble(txt_cort_total_ancho.Text),
                Longitud_Cortar = Convert.ToDouble(txt_cort_long_cortar.Text),
                Cortes_Ancho = Convert.ToInt32(txt_cort_ancho.Text),
                Cortes_Largo = Convert.ToInt32(txt_cort_largo.Text),
                Cantidad_Rollos = Convert.ToInt32(txt_cort_rollos_cortar.Text),
                Master_lenght1_Real = Convert.ToDouble(txt_pies_real.Text),
                Descartable1_pies = Convert.ToDouble(txt_pies_malos.Text),
                Util1_real_Lenght = Convert.ToDouble(txt_lenght_u.Text),
                Util1_Real_Width = Convert.ToDouble(txt_width_u.Text),
                Rest1_width = Convert.ToDouble(txt_width1_r.Text),
                Rest1_lenght = Convert.ToDouble(txt_lenght1_r.Text),
                Util2_Real_Width = Convert.ToDouble(txt_width_u2.Text),
                Util2_real_Lenght = Convert.ToDouble(txt_lenght_u2.Text),
                Descartable2_pies = Convert.ToDouble(txt_pies_malos2.Text),
                Rest2_width = Convert.ToDouble(txt_width2_r.Text),
                Rest2_lenght = Convert.ToDouble(txt_lenght2_r.Text),
                Master_lenght2_Real = Convert.ToDouble(txt_pies_real2.Text),
                Cortes_Largo2 = Convert.ToInt16(txt_cort_largo2.Text),
                Cantidad_Rollos2 = Convert.ToInt16(txt_cort_rollos_cortar2.Text),
                Tipo_Mov1 = rollid1_tipomov,
                Tipo_Mov2 = rollid2_tipomov,
                STATE = state,
                LastUpdate = DateTime.Now,
                Anulada = false,
                Procesado = false,
            };
            orden.rollos = new List<Roll_Details>();
            orden.Cortes = new List<Corte>();
            for (int fila = 0; fila <= grid_rollos.Rows.Count - 1; fila++)
            {
                Roll_Details rollo_cortado = new Roll_Details
                {
                    Numero_Orden = txt_numero_oc.Text,
                    Roll_number = grid_rollos.Rows[fila].Cells[0].Value.ToString(),
                    Product_id = grid_rollos.Rows[fila].Cells[1].Value.ToString(),
                    Product_name = grid_rollos.Rows[fila].Cells[2].Value.ToString(),
                    Unique_code = grid_rollos.Rows[fila].Cells[3].Value.ToString(),
                    Width = Convert.ToDecimal(grid_rollos.Rows[fila].Cells[4].Value),
                    Large = Convert.ToDecimal(grid_rollos.Rows[fila].Cells[5].Value),
                    Msi = Convert.ToDecimal(grid_rollos.Rows[fila].Cells[6].Value),
                    Splice = Convert.ToInt32(grid_rollos.Rows[fila].Cells[7].Value),
                    Roll_id = grid_rollos.Rows[fila].Cells[8].Value.ToString(),
                    Code_Person = grid_rollos.Rows[fila].Cells[9].Value.ToString(),
                    Status = grid_rollos.Rows[fila].Cells[10].Value.ToString(),
                    Disponible = false
                };
                orden.rollos.Add(rollo_cortado);
                //Agregar los cortes.
                orden.Cortes = listacorte;
            }
            return orden;
        }
        private List<Roll_Details> GENERAR_DETALLE_ROLLOS_CORTADOS()
        {
            List<Roll_Details> rollos = new List<Roll_Details>();
            int code_unique = Convert.ToInt32(configmanager.GetParameterControl("UC"));
            int cortes = grid_cortes.Rows.Count;

            //rollid 1
            int vueltas = Convert.ToInt16(txt_cort_largo.Text);
            int rn = 1;
            for (int i = 1; i <= vueltas; i++)
            {
                for (int j = 0; j <= cortes - 1; j++)
                {
                    rollos.Add(CreateItemRC(rn, code_unique, j, txt_rollid_1.Text));
                    rn += 1;
                    code_unique += 1;
                }
            }
            if (Convert.ToInt16(txt_cort_rollos_cortar2.Text) > 0)
            {
                //rollid 2
                vueltas = Convert.ToInt16(txt_cort_largo2.Text);
                for (int i = 1; i <= vueltas; i++)
                {
                    for (int j = 0; j <= cortes - 1; j++)
                    {
                        rollos.Add(CreateItemRC(rn, code_unique, j, txt_rollid_2.Text));
                        rn += 1;
                        code_unique += 1;
                    }
                }
            }
            configmanager.SetParametersControl(code_unique.ToString(), "UC");
            return rollos;
        }
        private Roll_Details CreateItemRC(int renglon, int rc, int cortes, string rollid)
        {

            Roll_Details item = new Roll_Details
            {
                Roll_number = (renglon).ToString(),
                Product_id = txt_product_id.Text.ToString(),
                Product_name = txt_product_name.Text,
                Unique_code = "RC" + rc,
                Width = Convert.ToDecimal(grid_cortes.Rows[cortes].Cells["width"].Value),
                Large = Convert.ToDecimal(grid_cortes.Rows[cortes].Cells["lenght"].Value),
                Msi = Convert.ToDecimal(grid_cortes.Rows[cortes].Cells["msi"].Value),
                Splice = 0,
                Roll_id = rollid,
                Code_Person = "N/A",
                Status = "Ok",
                Fecha = Convert.ToDateTime(txt_fecha_orden.Text),
                Numero_Orden = txt_numero_oc.Text
            };
            return item;
        }
        private void AGREGAR_COLUMN_GRID(string name, int size, string title, string field_bd, DataGridView grid)
        {
            DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn
            {
                Name = name,
                Width = size,
                HeaderText = title,
                DataPropertyName = field_bd
            };
            grid.Columns.Add(col);
        }
        #endregion

        #region FORM_CONTROLS
        private void BOT_EXCEL_EXPORT_Click(object sender, EventArgs e)
        {
            
        }
        private void LABELS_PRODUCTS()
        {
            //Procedimiento para generar txt para integrar con Bartender.
            GENERATE_TXT_FILE();
            // Actualizar el estado del documento.
            string numeroOC = txt_numero_oc.Text;
            int estado = 3;
            DateTime LastUpdate = DateTime.Now;
            managerorden.UpdateStateDocumentOC(numeroOC, estado, LastUpdate);

        }


        private void GENERATE_TXT_FILE() 
        {
            string separator = ",";

            using (StreamWriter sr =
                new StreamWriter(System.Windows.Forms.Application.StartupPath +
                R.PATH_FILES.FILE_TXT_DATA_ETIQUETA))
            {
                foreach (DataGridViewRow row in grid_rollos.Rows)
                {
                    sr.WriteLine(row.Cells[0].Value.ToString() + separator +
                    row.Cells[1].Value.ToString().Trim() + separator +
                    row.Cells[2].Value.ToString() + separator +
                    row.Cells[3].Value.ToString() + separator +
                    Convert.ToString(row.Cells[4].Value).Replace(",", ".") + separator +
                    Convert.ToString(row.Cells[5].Value).Replace(",", ".") + separator +
                    Convert.ToString(row.Cells[6].Value).Replace(",", ".") + separator +
                    row.Cells[7].Value.ToString() + separator +
                    row.Cells[8].Value.ToString() + separator +
                    row.Cells[9].Value.ToString() + separator +
                    row.Cells[10].Value.ToString() + separator +
                    Convert.ToDateTime(txt_fecha_orden.Text).ToShortDateString() + separator +
                    txt_numero_oc.Text);
                }
                MessageBox.Show("se genero la data de etiquetado...");
            }
        }

        private void BOT_BUSCAR_Click(object sender, EventArgs e)
        {
            using (FrmBuscarOrdenes fBuscarOrden = new FrmBuscarOrdenes
            {
                Dtordenes = ds.Tables["dtordenes"]
            })
            {
                fBuscarOrden.ShowDialog();
                int itemFound = bs.Find("numero", fBuscarOrden.Orden);
                bs.Position = itemFound;
            }
            ContadorRegistros();
            VERIFICAR_DOCUMENTO();
            RefrescarStepIndicator();
        }
        private void Bot_buscar_rollid1_Click(object sender, EventArgs e)
        {
            CargarRollIDNumber(0);

        }
        private void Bot_buscar_rollid2_Click(object sender, EventArgs e)
        {
            CargarRollIDNumber(1);
        }
        private void BOT_NUEVO_Click(object sender, EventArgs e)
        {
            CREATE_NEW_DOCUMENT();
        }
        private void CREATE_NEW_DOCUMENT() 
        {
            //chk_process.DataBindings.Clear();
            chk_anulado.DataBindings.Clear();
            ParentRow = (DataRowView)bs.AddNew();
            ParentRow.BeginEdit();
            //Inicializa los campos
            SetValueInitial();
            ParentRow.EndEdit();
            txt_numero_oc.Focus();
            ContadorRegistros();
            OptionsMenu(0);
            OptionsForm(0);
            ConfigurarCortes();
            EditMode = 1;
        }
        private void SetValueInitial() 
        {
            ParentRow["numero"] = "0";
            ParentRow["width_1"] = "0";
            ParentRow["lenght_1"] = "0";
            ParentRow["width_2"] = "0";
            ParentRow["lenght_2"] = "0";
            ParentRow["tot_inch_ancho"] = "0";
            ParentRow["longitud_cortar"] = "0";
            ParentRow["cortes_ancho"] = "0";
            ParentRow["cortes_largo"] = "0";
            ParentRow["cant_rollos"] = "0";
            ParentRow["procesado"] = false;
            ParentRow["anulada"] = false;
            ParentRow["lenght_cortado"] = "0";
            ParentRow["decartable1_pies"] = 0;
            ParentRow["descartable2_pies"] = 0;
            ParentRow["lenght_master_real"] = 0;
            ParentRow["util1_real_width"] = 0;
            ParentRow["util1_real_lenght"] = 0;
            ParentRow["util2_real_width"] = 0;
            ParentRow["util2_real_lenght"] = 0;
            ParentRow["rest1_width"] = 0;
            ParentRow["rest1_lenght"] = 0;
            ParentRow["rest2_width"] = 0;
            ParentRow["rest2_lenght"] = 0;
            ParentRow["lenght_master_real2"] = 0;
            ParentRow["cant_rollos2"] = 0;
            ParentRow["cortes_largo2"] = 0;
            txt_lenght_u2.Text = "0";
            txt_width_u.Text = "0";
            txt_lenght_u.Text = "0";
            txt_width1_r.Text = "0";
            txt_lenght1_r.Text = "0";
            txt_pies_real2.Text = "0";
            txt_width_u2.Text = "0";
            txt_pies_real2.Text = "0";
            txt_width2_r.Text = "0";
            txt_lenght2_r.Text = "0";
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            CustomerManager custom = new CustomerManager();
            using (SeleccionCustomers miformc = new SeleccionCustomers
            {
                Dtcustomer = custom.GetCustomersTableOnly()
            })
            {
                miformc.ShowDialog();
            }
        }
        private void BOT_SAVE_Click(object sender, EventArgs e)
        {
            switch (EditMode)
            {
                case 1:
                    ToSaveAdd();
                    break;
                case 2:
                    ToSaveUpdate();
                    break;
            }
        }
        private void Txt_numero_oc_KeyPress(object sender, KeyPressEventArgs e)
        {
            string CaracValid = "0123456789";
            if (e.KeyChar != Convert.ToChar(8) && CaracValid.IndexOf(e.KeyChar) == -1)
            {
                // si no es bakcspace y no es un numero se omite.   
                e.Handled = true;
            }
        }
        private void Txt_cant_cortado_KeyPress(object sender, KeyPressEventArgs e)
        {
            string CaracValid = "0123456789";
            if (e.KeyChar != Convert.ToChar(8) && CaracValid.IndexOf(e.KeyChar) == -1)
            {
                // si no es bakcspace y no es un numero se omite.   
                e.Handled = true;
            }
        }
        private void Txt_width_cortado_KeyPress(object sender, KeyPressEventArgs e)
        {
            string CaracValid = "0123456789.";
            if (e.KeyChar != Convert.ToChar(8) && CaracValid.IndexOf(e.KeyChar) == -1)
            {
                // si no es bakcspace y no es un numero se omite.   
                e.Handled = true;
            }
        }
        private void Txt_numero_oc_Validating(object sender, CancelEventArgs e)
        {
            if (managerorden.OrderExiste(Convert.ToInt16(txt_numero_oc.Text)) && EditMode == 1)
            {
                MessageBox.Show("La Orden produccion : " + txt_numero_oc.Text + " ya existe.");
                txt_numero_oc.Text = "";
            }
        }
        private void Grid_rollos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4 || e.ColumnIndex == 5)
            {
                CALCULAR_MSI_RENGLON(e.RowIndex);
            }
        }
        private void Bot_siguiente_Click(object sender, EventArgs e)
        {
            ActionPriorRecord();
        }
        
        private void Bot_anterior_Click(object sender, EventArgs e)
        {
            ActionNextRecord();
        }
        private void Bot_primero_Click(object sender, EventArgs e)
        {
            ActionLastRecord();
        }
        private void Bot_ultimo_Click(object sender, EventArgs e)
        {
            ActionFirstRecord();
        }
        private void ActionNextRecord()
        {
            bs.Position += 1;
            ContadorRegistros();
            VERIFICAR_DOCUMENTO();
            Update_StepIndicator(Convert.ToInt16(TXT_STEP_DOCUMENT.Text));
        }
        private void ActionPriorRecord()
        {
            bs.Position -= 1;
            ContadorRegistros();
            VERIFICAR_DOCUMENTO();
            Update_StepIndicator(Convert.ToInt16(TXT_STEP_DOCUMENT.Text));
        }
        private void ActionFirstRecord()
        {
            bs.Position = 0;
            ContadorRegistros();
            VERIFICAR_DOCUMENTO();
            Update_StepIndicator(Convert.ToInt16(TXT_STEP_DOCUMENT.Text));
        }
        private void ActionLastRecord()
        {
            bs.Position = bs.Count - 1;
            ContadorRegistros();
            VERIFICAR_DOCUMENTO();
            Update_StepIndicator(Convert.ToInt16(TXT_STEP_DOCUMENT.Text));
        }

        private void OptionsForm(int state)
        {
            switch (state)
            {
                case 0:
                    //modo agregar nuevo orden.
                    txt_numero_oc.ReadOnly = false;
                    txt_fecha_orden.Enabled = true;
                    txt_fecha_producc.Enabled = true;
                    txt_rollid_1.ReadOnly = false;
                    txt_rollid_2.ReadOnly = false;
                    bot_buscar_rollid1.Enabled = true;
                    bot_buscar_rollid2.Enabled = true;
                    bot_generar_rollos_cortados.Enabled = true;
                    bot_add_cortes.Enabled = true;
                    bot_delete_cortes.Enabled = true;
                    break;
                case 1:
                    // modo cerra forms despues de agregar orden colocar en lectura.
                    txt_numero_oc.ReadOnly = true;
                    txt_fecha_orden.Enabled = false;
                    txt_fecha_producc.Enabled = false;
                    txt_rollid_1.ReadOnly = true;
                    txt_rollid_2.ReadOnly = true;
                    txt_width1_rollid.ReadOnly = true;
                    txt_width2_rollid.ReadOnly = true;
                    txt_lenght1_rollid.ReadOnly = true;
                    txt_lenght2_rollid.ReadOnly = true;
                    bot_buscar_rollid1.Enabled = false;
                    bot_buscar_rollid2.Enabled = false;
                    bot_generar_rollos_cortados.Enabled = false;
                    grid_rollos.ReadOnly = true;
                    bot_add_cortes.Enabled = false;
                    bot_delete_cortes.Enabled = false;
                    break;
                case 2:
                    txt_fecha_orden.Enabled = true;
                    txt_fecha_producc.Enabled = true;
                    txt_rollid_1.ReadOnly = false;
                    txt_width1_rollid.ReadOnly = false;
                    txt_lenght1_rollid.ReadOnly = false;
                    txt_rollid_2.ReadOnly = false;
                    txt_width2_rollid.ReadOnly = false;
                    txt_lenght2_rollid.ReadOnly = false;
                    bot_buscar_rollid1.Enabled = true;
                    bot_buscar_rollid2.Enabled = true;
                    bot_generar_rollos_cortados.Enabled = true;
                    grid_rollos.ReadOnly = false;
                    grid_rollos.Columns[0].ReadOnly = true;
                    grid_rollos.Columns[1].ReadOnly = true;
                    grid_rollos.Columns[2].ReadOnly = true;
                    grid_rollos.Columns[3].ReadOnly = true;
                    grid_rollos.Columns[6].ReadOnly = true;
                    grid_rollos.Columns[8].ReadOnly = true;
                    break;
            }
        }
        private void OptionsMenu(int state)
        {
            switch (state)
            {
                case 0:
                    //modo agregar nuevo orden.
                    bot_primero.Enabled = false;
                    bot_siguiente.Enabled = false;
                    bot_anterior.Enabled = false;
                    bot_LastRecord.Enabled = false;
                    BOT_BUSCAR.Enabled = false;
                    BOT_CANCELAR.Enabled = true;
                    BOT_SAVE.Enabled = true;
                    break;
                case 1:
                    //modo agregar despues de grabar.
                    bot_primero.Enabled = true;
                    bot_siguiente.Enabled = true;
                    bot_anterior.Enabled = true;
                    bot_LastRecord.Enabled = true;
                    BOT_CANCELAR.Enabled = false;
                    BOT_BUSCAR.Enabled = true;
                    BOT_SAVE.Enabled = false;
                    Menu_Actions.Enabled = true;
                    break;
            }
        }
        private void Btn_eliminar_renglon_Click(object sender, EventArgs e)
        {
            //ACTUALIZAR LA INTERFAZ GRAFICA.

            string rc = ""; ;
            foreach (DataGridViewRow item in this.grid_rollos.SelectedRows)
            {
                rc = item.Cells["unique_code"].Value.ToString();
                grid_rollos.Rows.RemoveAt(item.Index);
            }
            //ACTUALIZAR LA BASE DE DATOS. 
            managerorden.DeleteUniqueCode(rc);

        }
        private void Bot_procesar_Click(object sender, EventArgs e)
        {
           
        }
        private void ProcesarDocumento() 
        {
            DialogResult dr = MessageBox.Show("Esta seguro de procesar este documento (S/N)?",
                    "Advertencia", MessageBoxButtons.YesNo);
            switch (dr)
            {
                case DialogResult.Yes:
                    managerorden.ProcesarOrden(txt_numero_oc.Text.Trim());
                    //chk_process.Checked = true;
                    VERIFICAR_DOCUMENTO();
                    break;
                case DialogResult.No:
                    break;
            }
        }
        private void Bot_Anular_Click(object sender, EventArgs e)
        {
        
        }
        private void AnularDocumento() 
        {
            DialogResult dr = MessageBox.Show("Esta seguro de Anular este documento (S/N)?",
                "Advertencia", MessageBoxButtons.YesNo);
            switch (dr)
            {
                case DialogResult.Yes:
                    managerorden.AnularOrden(txt_numero_oc.Text.Trim());
                    chk_anulado.Checked = true;
                    VERIFICAR_DOCUMENTO();
                    break;
                case DialogResult.No:
                    break;
            }
        }
        private void Bot_generar_rollos_cortados_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt16(txt_cort_rollos_cortar.Text) <= 0)
            {
                MessageBox.Show("No hay rollos por cortar...");
                return;
            }

            List<Roll_Details> lista = GENERAR_DETALLE_ROLLOS_CORTADOS();
            //Agregar encabezado a la orden.
            ParentRow.BeginEdit();
            ParentRow["numero"] = txt_numero_oc.Text;
            ParentRow["fecha"] = txt_fecha_orden.Text;
            ParentRow["fecha_produccion"] = txt_fecha_producc.Text;
            ParentRow["rollid_1"] = txt_rollid_1.Text;
            ParentRow["width_1"] = txt_width1_rollid.Text;
            ParentRow["lenght_1"] = txt_lenght1_rollid.Text;
            ParentRow["rollid_2"] = txt_rollid_2.Text;
            ParentRow["width_2"] = txt_width2_rollid.Text;
            ParentRow["lenght_2"] = txt_lenght2_rollid.Text;
            ParentRow["product_id"] = txt_product_id.Text;
            ParentRow["tot_inch_ancho"] = txt_cort_total_ancho.Text;
            ParentRow["cant_rollos"] = txt_cort_rollos_cortar.Text;
            ParentRow["cortes_ancho"] = txt_cort_ancho.Text;
            ParentRow["decartable1_pies"] = txt_pies_malos.Text;
            ParentRow["lenght_master_real"] = txt_pies_real.Text;
            ParentRow["util1_real_width"] = txt_width_u.Text;
            ParentRow["util1_real_lenght"] = txt_lenght_u.Text;
            ParentRow["rest1_width"] = txt_width1_r.Text;
            ParentRow["rest1_lenght"] = txt_lenght1_r.Text;
            ParentRow["util2_real_width"] = txt_width_u2.Text;
            ParentRow["util2_real_lenght"] = txt_lenght_u2.Text;
            ParentRow["rest2_width"] = txt_width2_r.Text;
            ParentRow["rest2_lenght"] = txt_lenght2_r.Text;
            ParentRow["lenght_master_real2"] = txt_pies_real2.Text;
            ParentRow["cant_rollos2"] = txt_cort_rollos_cortar2.Text;
            ParentRow["cortes_largo2"] = txt_cort_largo2.Text;
            ParentRow["anulada"] = false;
            ParentRow["procesado"] = false;
            ParentRow.EndEdit();
            //Agregar el detalle de la Orden.
            DataRowView ChildRows;
            string CodeRC = managerorden.GetCodeRC(txt_product_id.Text.Trim());
            if (CodeRC == string.Empty)
            {
                CodeRC = txt_product_id.Text;
            }
            foreach (Roll_Details item in lista)
            {
                ChildRows = (DataRowView)bsdetalle.AddNew();
                ChildRows.BeginEdit();
                ChildRows["numero"] = item.Numero_Orden;
                ChildRows["roll_number"] = item.Roll_number;
                ChildRows["product_id"] = CodeRC;
                ChildRows["product_name"] = item.Product_name;
                ChildRows["unique_code"] = item.Unique_code;
                ChildRows["width"] = double.Parse(item.Width.ToString(), CultureInfo.InvariantCulture);
                ChildRows["large"] = item.Large;
                ChildRows["Msi"] = item.Msi;
                ChildRows["Splice"] = item.Splice;
                ChildRows["Roll_id"] = item.Roll_id;
                ChildRows["Code_Person"] = item.Code_Person;
                ChildRows["Status"] = item.Status;
                ChildRows.Row.SetParentRow(ParentRow.Row);
                ChildRows.EndEdit();
            }
            bs.EndEdit();
            grid_rollos.Rows[0].Selected = true;
            bot_generar_rollos_cortados.Enabled = false;
        }
        private void Bot_modificar_Click(object sender, EventArgs e)
        {
        
        }
        private void UPDATE_DOCUMENT() 
        {
            EditMode = 2;
            modproduct_id = txt_product_id.Text;
            ParentRow = (DataRowView)bs.Current;
            OptionsMenu(0);
            OptionsForm(2);
        }
        private void Txt_cort_largo_KeyUp(object sender, KeyEventArgs e)
        {
            if (txt_cort_largo.Text == "")
            {
                return;
            }
            CALCULAR_NUMERO_ROLLOS();
            CALCULAR_MATERIAL_RESTANTE();
        }
        private void CALCULAR_NUMERO_ROLLOS()
        {
            double total_rollos = Convert.ToDouble(txt_cort_ancho.Text) * Convert.ToDouble(txt_cort_largo.Text);
            txt_cort_rollos_cortar.Text = total_rollos.ToString();
            txt_lenght_u.Text = (Convert.ToDouble(txt_cort_largo.Text)
                * Convert.ToDouble(txt_cort_long_cortar.Text)).ToString();
        }
        private void CALCULAR_NUMERO_ROLLOS2()
        {
            double total_rollos = Convert.ToDouble(txt_cort_ancho.Text) * Convert.ToDouble(txt_cort_largo2.Text);
            txt_cort_rollos_cortar2.Text = total_rollos.ToString();
            txt_lenght_u2.Text = (Convert.ToDouble(txt_cort_largo2.Text)
                * Convert.ToDouble(txt_cort_long_cortar.Text)).ToString();
        }
        private void Grid_cortes_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //calculo del msi.
            grid_cortes.Rows[e.RowIndex].Cells["msi"].Value =
                Convert.ToDouble(grid_cortes.Rows[e.RowIndex].Cells["width"].Value) *
                Convert.ToDouble(grid_cortes.Rows[e.RowIndex].Cells["lenght"].Value)
                * R.CONSTANTES.FACTOR_CALCULO_MSI;
            CALCULAR_CORTES_ANCHOS();
        }
        private void CALCULAR_CORTES_ANCHOS()
        {
            double total_inch_ancho = 0;
            for (int i = 0; i <= grid_cortes.Rows.Count - 1; i++)
            {
                total_inch_ancho += Convert.ToDouble(grid_cortes.Rows[i].Cells["width"].Value);
            }
            txt_cort_total_ancho.Text = total_inch_ancho.ToString();
            txt_width_u.Text = total_inch_ancho.ToString();
            txt_cort_ancho.Text = grid_cortes.Rows.Count.ToString();
            CALCULAR_MATERIAL_RESTANTE();
        }
        private void CALCULAR_MATERIAL_RESTANTE()
        {
            //Calculo de material restante
            decimal w1 = Convert.ToDecimal(txt_width1_rollid.Text);
            decimal w2 = Convert.ToDecimal(txt_width_u.Text);
            decimal result = Math.Round((w1 - w2), 2, MidpointRounding.AwayFromZero);
            txt_width1_r.Text = result.ToString();

            
            txt_lenght1_r.Text = Math.Round(Convert.ToDouble(txt_pies_real.Text)
            - Convert.ToDouble(txt_lenght_u.Text),2,MidpointRounding.AwayFromZero).ToString();



            if (Convert.ToDouble(txt_width1_r.Text) == 0)
            {
                txt_width1_r.Text = txt_width1_rollid.Text;
            }
        }
        private void CALCULAR_MATERIAL_RESTANTE2()
        {
            //Calculo de material restante
            txt_width2_r.Text = (Convert.ToDouble(txt_width2_rollid.Text)
            - Convert.ToDouble(txt_width_u2.Text)).ToString();

            txt_lenght2_r.Text = (Convert.ToDouble(txt_pies_real2.Text)
            - Convert.ToDouble(txt_lenght_u2.Text)).ToString();

            if (Convert.ToDouble(txt_width2_r.Text) == 0)
            {
                txt_width2_r.Text = txt_width2_rollid.Text;
            }
        }

        private void Bot_delete_cortes_Click(object sender, EventArgs e)
        {
            bot_delete_cortes.Enabled = true;
            var itemToRemove = listacorte.Single(r => r.Num ==
            Convert.ToInt32(grid_cortes.Rows[grid_cortes.CurrentRow.Index].Cells["num"].Value));
            listacorte.Remove(itemToRemove);
            int row = 1;
            foreach (Corte item in listacorte)
            {
                item.Num = row;
                row++;
            }
            grid_cortes.DataSource = null;
            grid_cortes.DataSource = listacorte;

            if (listacorte.Count == 0)
            {
                bot_delete_cortes.Enabled = false;

            }
            CALCULAR_CORTES_ANCHOS();
            CALCULAR_NUMERO_ROLLOS();
        }
        private void Bot_add_cortes_Click(object sender, EventArgs e)
        {
            Corte item = new Corte
            {
                Num = listacorte.Count + 1
            };
            listacorte.Add(item);
            grid_cortes.DataSource = null;
            grid_cortes.DataSource = listacorte;
            if (listacorte.Count > 0)
            {
                bot_delete_cortes.Enabled = true;

            }
        }
        private void BOT_CANCELAR_Click(object sender, EventArgs e)
        {
            if (EditMode == 1)
            {
                DataRowView rowcurrent;
                rowcurrent = (DataRowView)bs.Current;
                rowcurrent.Row.Delete();
                bs.EndEdit();
                ContadorRegistros();
                bs.Position = bs.Count - 1;
                //activo la funciones del menu
                OptionsMenu(1);
                OptionsForm(1);
                EditMode = 0;
            }
            if (EditMode == 2)
            {
                OptionsMenu(1);
                OptionsForm(1);
                EditMode = 0;
            }
        }
        private void Txt_lenght_cortado_KeyPress(object sender, KeyPressEventArgs e)
        {
            string CaracValid = "0123456789,.";
            if (e.KeyChar != Convert.ToChar(8) && CaracValid.IndexOf(e.KeyChar) == -1)
            {
                // si no es bakcspace y no es un numero se omite.   
                e.Handled = true;
            }
        }
        private void Txt_master__KeyUp(object sender, KeyEventArgs e)
        {
            if (txt_pies_malos.Text == "")
            {
                return;
            }
            double real = Convert.ToDouble(txt_lenght1_rollid.Text) - Convert.ToDouble(txt_pies_malos.Text);
            txt_pies_real.Text = real.ToString();
        }
        private void Txt_cort_long_cortar_KeyUp(object sender, KeyEventArgs e)
        {
            if (txt_cort_long_cortar.Text == "")
            {
                txt_cort_long_cortar.Text = "0";
            }
            for (int i = 0; i <= grid_cortes.Rows.Count - 1; i++)
            {
                grid_cortes.Rows[i].Cells["lenght"].Value = txt_cort_long_cortar.Text;
                grid_cortes.Rows[i].Cells["msi"].Value =
                Convert.ToDouble(grid_cortes.Rows[i].Cells["width"].Value) *
                Convert.ToDouble(grid_cortes.Rows[i].Cells["lenght"].Value)
                * R.CONSTANTES.FACTOR_CALCULO_MSI;
            }
        }
        private void Txt_pies_malos2_KeyUp(object sender, KeyEventArgs e)
        {
            if (txt_pies_malos2.Text == "")
            {
                return;
            }
            double real = Convert.ToDouble(txt_lenght2_rollid.Text) - Convert.ToDouble(txt_pies_malos2.Text);
            txt_pies_real2.Text = real.ToString();
        }



        #endregion
        private void Txt_cort_largo2_KeyUp(object sender, KeyEventArgs e)
        {
            if (txt_cort_largo2.Text == "")
            {
                return;
            }
            CALCULAR_NUMERO_ROLLOS2();
            CALCULAR_MATERIAL_RESTANTE2();
            txt_width_u2.Text = txt_cort_total_ancho.Text;
        }
        private void Txt_cort_largo_KeyPress(object sender, KeyPressEventArgs e)
        {
            string CaracValid = "0123456789";
            if (e.KeyChar != Convert.ToChar(8) && CaracValid.IndexOf(e.KeyChar) == -1)
            {
                // si no es bakcspace y no es un numero se omite.   
                e.Handled = true;
            }
        }
        private void Txt_cort_largo2_KeyPress(object sender, KeyPressEventArgs e)
        {
            string CaracValid = "0123456789";
            if (e.KeyChar != Convert.ToChar(8) && CaracValid.IndexOf(e.KeyChar) == -1)
            {
                // si no es bakcspace y no es un numero se omite.   
                e.Handled = true;
            }
        }
        private void Txt_cort_long_cortar_KeyPress(object sender, KeyPressEventArgs e)
        {
            string CaracValid = "0123456789";
            if (e.KeyChar != Convert.ToChar(8) && CaracValid.IndexOf(e.KeyChar) == -1)
            {
                // si no es bakcspace y no es un numero se omite.   
                e.Handled = true;
            }
        }
        private void Txt_pies_malos_KeyPress(object sender, KeyPressEventArgs e)
        {
            string CaracValid = "0123456789";
            if (e.KeyChar != Convert.ToChar(8) && CaracValid.IndexOf(e.KeyChar) == -1)
            {
                // si no es bakcspace y no es un numero se omite.   
                e.Handled = true;
            }
        }

        private void Action_NewDocument_Click(object sender, EventArgs e)
        {
            CREATE_NEW_DOCUMENT();
            Menu_Actions.Enabled = false;
            bot_generar_rollos_cortados.Enabled = true;
            Update_StepIndicator(0);
        }

        private void Action_UpdateDocument_Click(object sender, EventArgs e)
        {
            UPDATE_DOCUMENT();
            Menu_Actions.Enabled = false;
            Update_StepIndicator(1);
        }
        private void Action_LabelProducts_Click(object sender, EventArgs e)
        {
            LABELS_PRODUCTS();
            RefreshInterfazBS(3);
        }
        private void RefreshInterfazBS(int step) 
        {
            //Refrescar la Interfaz Grafica.
            DataRowView rowcurrent;
            rowcurrent = (DataRowView)bs.Current;
            rowcurrent["step"] = step;
            bs.EndEdit();
            RefrescarStepIndicator();
        }

        private void Action_AutorizeDocument_Click(object sender, EventArgs e)
        {
            FrmSaveOc Aprodoc = new FrmSaveOc
            {
                NumeroOC = txt_numero_oc.Text
            };
            Aprodoc.ShowDialog();
            RefreshInterfazBS(4);
        }

        private void Action_CloseDocument_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Esta seguro de Cerrar la orden de Corte (S/N)", "Advertencia", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {

                string numoc = txt_numero_oc.Text;
                int state = 5;
                DateTime LastUpdate = DateTime.Now;
                managerorden.UpdateStateDocumentOC(numoc,state,LastUpdate);
                RefreshInterfazBS(5);
                RefrescarStepIndicator();
                // ESTABLECER LA DISPONIBILIDAD DE LOS ROLLOS
                managerorden.UpdateDispoRollsDocumentOC(numoc, true);
                // CARGA EL ORGIEN DEL ARCHIVO DE INICIALES / ARCHIVO DE RECEPCIONES
                LoadTipoMov();
                //MOMENTO EN EL QUE SE AFECTA INVENTARÍO.
                RUN_INVENTARIO();
                //ACTUALIZAR DOCUMENTO
                VERIFICAR_DOCUMENTO();
            }
        }

        private void Accion_AnularDocument_Click(object sender, EventArgs e)
        {
            DataRowView RowCurrent = (DataRowView)bs.Current;
            Boolean sw = Convert.ToBoolean(RowCurrent["anulada"]);
            int step = Convert.ToInt16(RowCurrent["step"]); 
            if (sw) 
            {
                MessageBox.Show("Ya este documnento esta anulado...");
                return;
            }
            if (step == 5) 
            {
                MessageBox.Show("Orden Cerrada, no se puede anular");
                return;
            }
            DialogResult dialogResult = MessageBox.Show("Esta seguro de Anular esta Orden de Corte (S/N)", "Advertencia", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                string numeroOc = txt_numero_oc.Text;
                if (step >= 1 || step <= 4) 
                {
                    managerorden.AnularOrden(numeroOc);
                    RowCurrent["anulada"] = true;
                    bs.EndEdit();
                    VERIFICAR_DOCUMENTO();
                }
            }
            
        }

        private void Bot_LastRecord_Click(object sender, EventArgs e)
        {
            ActionFirstRecord();
        }

        private void Txt_pies_malos2_KeyPress(object sender, KeyPressEventArgs e)
        {
            string CaracValid = "0123456789";
            if (e.KeyChar != Convert.ToChar(8) && CaracValid.IndexOf(e.KeyChar) == -1)
            {
                // si no es bakcspace y no es un numero se omite.   
                e.Handled = true;
            }
        }

        private void ToolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void BOT_IMPRIMIR_Click(object sender, EventArgs e)
        {
            using (FrmReportViewCrystal frmReportView = new FrmReportViewCrystal())
            {
                ReportDocument reporte = new ReportDocument();
                TableLogOnInfos crtablelogoninfos = new TableLogOnInfos();
                TableLogOnInfo crtablelogoninfo = new TableLogOnInfo();
                reporte.Load(System.Windows.Forms.Application.StartupPath + R.PATH_FILES.PATH_DATA_REPORT_ORDEN_CORTE);
                reporte.SetParameterValue("number_oc", txt_numero_oc.Text.Trim());
                Tables CrTables;
                CrTables = reporte.Database.Tables;
                ConnectionInfo ConexInfo = new ConnectionInfo
                {
                    ServerName = R.SERVERS.SERVER_ETIQUETAS,
                    DatabaseName = R.DATABASES.RITRAMA,
                    UserID = R.USERS.UserMaster,
                    Password = R.USERS.KeyMaster
                };
                foreach (Table table in CrTables)
                {
                    crtablelogoninfo = table.LogOnInfo;
                    crtablelogoninfo.ConnectionInfo = ConexInfo;
                    table.ApplyLogOnInfo(crtablelogoninfo);
                }
                frmReportView.crystalReportViewer1.ReportSource = reporte;
                frmReportView.crystalReportViewer1.Zoom(150);
                frmReportView.Text = "Reporte de la Orden de Corte";
                frmReportView.Width = 1000;
                frmReportView.Height = 800;
                frmReportView.ShowDialog();
            }
        }
    }
}