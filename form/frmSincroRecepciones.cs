using RitramaAPP.Clases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace RitramaAPP.form
{
    public partial class FrmSincroRecepciones : Form
    {
        public FrmSincroRecepciones()
        {
            InitializeComponent();
        }
        public DataTable Dtsupply { get; set; }
        public List<ClassRecepcion> Lista { get; set; }
        int fila_actual = 0;
        readonly ProductsManager productsmanager = new ProductsManager();
        readonly RecepcionManager recepmanager = new RecepcionManager();
        readonly ConfigManager configmanager = new ConfigManager();

        private void FrmSincroRecepciones_Load(object sender, EventArgs e)
        {
            SetStyleGrid();
            grid_item.DataSource = Lista;
            REGISTROS_TRANSFERIDOS.Text = "Registros Leidos :" + Lista.Count().ToString();
            grid_item.ClearSelection();
        }
        private void SetStyleGrid()
        {
            grid_item.AutoGenerateColumns = false;
            CREATE_COLUMN_TEXTBOX_GRID("orden", 60, "Orden", "orden");
            CREATE_COLUMN_TEXTBOX_GRID("id_product", 75, "Codigo", "part_number");
            CREATE_COLUMN_TEXTBOX_GRID("product_name", 200, "Nombre del producto", "productname");
            CREATE_COLUMN_TEXTBOX_GRID("tipo", 60, "tipo", "tipo");
            CREATE_COLUMN_TEXTBOX_GRID("width", 100, "Width", "width");
            CREATE_COLUMN_TEXTBOX_GRID("lenght", 100, "Lenght", "lenght");
            CREATE_COLUMN_TEXTBOX_GRID("rollid", 120, "Roll Id.", "Roll_ID");
            CREATE_COLUMN_TEXTBOX_GRID("proveedor_id", 60, "Prov. Id", "Supply_Id");
            CREATE_COLUMN_TEXTBOX_GRID("proveedor_name", 200, "Nombre del Proveedor", "SupplyName");
            CREATE_COLUMN_CHECKBOX_GRID("proveedor_ok", 60, "proveedor_ok", "");
            CREATE_COLUMN_CHECKBOX_GRID("product_ok", 60, "product_ok", "");
            CREATE_COLUMN_CHECKBOX_GRID("orden_ok", 60, "orden_ok", "");
            CREATE_COLUMN_CHECKBOX_GRID("total_ok", 60, "total_ok", "");
        }
        private void Bot_search_proveedor_Click(object sender, EventArgs e)
        {
            SeleccionProveedores BrowseProviders = new SeleccionProveedores
            {
                dtsupply = this.Dtsupply
            };
            BrowseProviders.ShowDialog();
            txt_id_proveedor.Text = BrowseProviders.GetProviderID;
            txt_proveedor_name.Text = BrowseProviders.GetProviderName;
        }

        private void Bot_register_select_Click(object sender, EventArgs e)
        {
            if (txt_id_proveedor.Text == "")
            {
                MessageBox.Show("seleccione en proveedor primero.");
            }
            grid_item.Rows[fila_actual].Cells["proveedor_id"].Value = txt_id_proveedor.Text;
            grid_item.Rows[fila_actual].Cells["proveedor_name"].Value = txt_proveedor_name.Text;
        }

        private void Grid_item_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            fila_actual = e.RowIndex;
        }

        private void Bot_register_all_Click(object sender, EventArgs e)
        {
            if (txt_id_proveedor.Text == "")
            {
                MessageBox.Show("seleccione en proveedor primero.");
            }
            for (int i = 0; i <= grid_item.Rows.Count - 1; i++)
            {
                if (Convert.ToString(grid_item.Rows[i].Cells["proveedor_id"].Value) == "")
                {
                    grid_item.Rows[i].Cells["proveedor_id"].Value = txt_id_proveedor.Text;
                    grid_item.Rows[i].Cells["proveedor_name"].Value = txt_proveedor_name.Text;
                }
            }
        }

        private void Bot_validar_Click(object sender, EventArgs e)
        {
            VALID_DATA();
            bot_tranferir_data.Enabled = true;
        }

        private void Grid_item_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            foreach (DataGridViewRow Myrow in grid_item.Rows)
            {
                if (Myrow.Cells["total_ok"].Value != null)
                {
                    if (Convert.ToBoolean(Myrow.Cells["total_ok"].Value) == false)
                    {

                        Myrow.DefaultCellStyle.BackColor = Color.Red;

                    }
                    else
                    {
                        Myrow.DefaultCellStyle.BackColor = Color.LightGreen;
                    }
                }
            }
        }
        public void CREATE_COLUMN_TEXTBOX_GRID(string name, int wid, string text, string campodb)
        {
            DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn
            {
                Name = name,
                Width = wid,
                HeaderText = text,
                DataPropertyName = campodb
            };
            grid_item.Columns.Add(col);
        }
        public void CREATE_COLUMN_CHECKBOX_GRID(string name, int wid, string text, string campodb)
        {
            DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn
            {
                Name = name,
                Width = wid,
                HeaderText = text,
                DataPropertyName = campodb
            };
            grid_item.Columns.Add(col);
        }
        public void VALID_DATA()
        {
            // Validar los datos extraidos del movil.
            // validar los datos del proveedor
            int fil = 0;
            foreach (ClassRecepcion item in Lista)
            {

                if (item.Supply_Id == "" || item.Supply_Id == null)
                {
                    MessageBox.Show("complete los datos de proveedor");
                    grid_item.Rows[fil].Cells["proveedor_ok"].Value = false;
                    return;
                }
                else
                {
                    grid_item.Rows[fil].Cells["proveedor_ok"].Value = true;
                }
                fil += 1;
            }
            txt_consola.Text = "la verificacion de proveedores es OK...";

            // validar que los productos existan en la base de datos.
            fil = 0;
            foreach (ClassRecepcion item in Lista)
            {
                if (productsmanager.ProductoExiste(item.Part_Number.ToString()) == false)
                {
                    //un producto no existe
                    grid_item.Rows[fil].Cells["product_ok"].Value = false;
                    //return;
                }
                else
                {
                    grid_item.Rows[fil].Cells["product_ok"].Value = true;
                }
                fil += 1;
            }
            txt_consola.Text = "la verificacion de productos es OK...";
            //valid que las ordenes no se repitan
            fil = 0;
            foreach (ClassRecepcion item in Lista)
            {
                if (recepmanager.VerificarExisteOrden(item.Orden) == true)
                {
                    //existe ordenes repetidas...
                    MessageBox.Show("existen ordenes repetidas. numero de orden: " + item.Orden);
                    grid_item.Rows[fil].Cells["orden_ok"].Value = false;
                    //return;
                }
                else
                {
                    grid_item.Rows[fil].Cells["orden_ok"].Value = true;
                }
                fil += 1;
            }
            // validacion total
            for (int i = 0; i <= grid_item.Rows.Count - 1; i++)
            {
                if (Convert.ToBoolean(grid_item.Rows[i].Cells["proveedor_ok"].Value) &&
                    Convert.ToBoolean(grid_item.Rows[i].Cells["product_ok"].Value) &&
                    Convert.ToBoolean(grid_item.Rows[i].Cells["orden_ok"].Value))
                {
                    grid_item.Rows[i].Cells["total_ok"].Value = true;
                }
                else
                {
                    grid_item.Rows[i].Cells["total_ok"].Value = false;
                }
            }
            chk_isvalid.Checked = true;
        }

        private void Bot_tranferir_data_Click(object sender, EventArgs e)
        {
            Boolean sincrook = false;
            int numsincro = Convert.ToInt32(configmanager.GetParameterControl("LSR")) + 1;
            //SAVE DATA RECEPCIONES
            foreach (DataGridViewRow row in grid_item.Rows)
            {
                if (Convert.ToBoolean(row.Cells["total_ok"].Value))
                {
                    ClassRecepcion data = new ClassRecepcion
                    {
                        Orden = Convert.ToString(row.Cells["orden"].Value),
                        Fecha_reg = DateTime.Now,
                        Hora_reg = DateTime.Now.ToString(),
                        Part_Number = Convert.ToString(row.Cells["id_product"].Value),
                        ProductName = Convert.ToString(row.Cells["product_name"].Value)
                    };
                    ;
                    data.Supply_Id = Convert.ToString(row.Cells["proveedor_id"].Value); ;
                    data.SupplyName = Convert.ToString(row.Cells["proveedor_name"].Value); ;
                    data.Width = Convert.ToDouble(row.Cells["width"].Value); ;
                    data.Lenght = Convert.ToDouble(row.Cells["lenght"].Value);
                    data.Roll_ID = Convert.ToString(row.Cells["rollid"].Value);
                    data.Ubicacion = "";
                    data.Splice = 0;
                    data.Core = 0;
                    data.Anulado = false;
                    data.Fecha_produccion = DateTime.Today;
                    data.Master = true;
                    data.Resma = false;
                    data.Graphics = false;
                    data.Embarque = "";
                    data.Palet_number = "";
                    data.Palet_cant = 0;
                    data.Palet_paginas = 0;
                    data.Num_sincro = numsincro;
                    data.Registro_movil = true;
                    data.Disponible = true;
                    recepmanager.Add(data, false, 1);
                    sincrook = true;
                }
            }
            configmanager.SetParametersControl(numsincro.ToString(), "LSR");
            if (sincrook)
            {
                MessageBox.Show("Se guardaron los datos correctamente.");
            }

            //borra el archivo
            try
            {
                if (File.Exists(R.PATH_FILES.FILE_TXT_MATERIA_PRIMA))
                {
                    File.Delete(R.PATH_FILES.FILE_TXT_MATERIA_PRIMA);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("error al tratar de eliminar el txt de recepciones materia prima" + ex);

            }

            Lista.Clear();
            grid_item.DataSource = "";
        }
    }
}
