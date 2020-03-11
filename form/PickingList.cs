using RitramaAPP.Clases;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace RitramaAPP.form
{
    public partial class PickingList : Form
    {
        public PickingList()
        {
            InitializeComponent();
        }
        public List<Roll_Details> Lista_rollos { get; set; }
        public List<ClassRecepcion> Lista_hojas { get; set; }
        public List<ClassRecepcion> Lista_graphics { get; set; }
        public IEnumerable<Producto> List_products { get; set; }
        public int Action { get; set; }
        readonly ProduccionManager produccionManager = new ProduccionManager();
        readonly RecepcionManager recepcionManager = new RecepcionManager();
        private void PickingList_Load(object sender, EventArgs e)
        {
            //Por Defecto Cortados
            Action = 0;
            Lista_rollos = new List<Roll_Details>();
            Lista_hojas = new List<ClassRecepcion>();
            Lista_graphics = new List<ClassRecepcion>();
            EstiloGridCortados();
        }
        #region CHANGE_CATEGORY_PRODUCTS
        private void RA_CORTADO_CheckedChanged(object sender, EventArgs e)
        {
            if (RA_CORTADO.Checked)
            {
                DELETE_COLUMN(Action);
                LABELID.Text = "CODIGO UNICO:";
                grid_itemRC.DataSource = "";
                EstiloGridCortados();
                Action = 0;
            }
        }
        private void RA_HOJAS_CheckedChanged(object sender, EventArgs e)
        {
            
            if (RA_HOJAS.Checked)
            {
                DELETE_COLUMN(Action);
                LABELID.Text = "   Id Hojas :";
                grid_itemRC.DataSource = "";
                EstiloGridHojas();
                Action = 1;
            }
        }

        private void RA_GRAPHICS_CheckedChanged(object sender, EventArgs e)
        {
           
            if (RA_GRAPHICS.Checked) 
            {
                DELETE_COLUMN(Action);
                LABELID.Text = "Id Graphics  :";
                grid_itemRC.DataSource = "";
                EstilosGridGraphics();
                Action = 2;
            }
        }
        private void Grid_itemRC_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (RA_HOJAS.Checked)
            {
                if (e.ColumnIndex == 6)
                {
                    if (Convert.ToInt32(grid_itemRC.Rows[e.RowIndex].Cells["cant_des"].Value) >
                        Convert.ToInt32(grid_itemRC.Rows[e.RowIndex].Cells["hojas"].Value))
                    {
                        MessageBox.Show("la cantidad a despachar no puede ser mayor a la cantidad de hojas...");
                        grid_itemRC.Rows[e.RowIndex].Cells["cant_des"].Value = 0;
                    }
                }
            }

        }
        #endregion
        #region ACTIVATE_BUSQUEDA
        private void Txt_uniqueCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                if (txt_uniqueCode.Text == string.Empty)
                {
                    return;
                }
                if (RA_CORTADO.Checked)
                {
                    LoadDataCortados();
                    CALCULATE_DATA();
                }
                if (RA_HOJAS.Checked)
                {
                    LoadDataHojas();
                }
                if (RA_GRAPHICS.Checked) 
                {
                    LoadDataGraphics();
                }
            }
        }
        #endregion
        #region ESTILOS_GRID   
        private void DELETE_COLUMN(int Action)
        {
            grid_itemRC.Columns.Clear();
        }
        private void EstilosGridGraphics() 
        {
            grid_itemRC.ReadOnly = false;
            grid_itemRC.AutoGenerateColumns = false;
            AGREGAR_COLUMN_GRID("product_id", 70, "Product Id.", "Part_Number", grid_itemRC);
            AGREGAR_COLUMN_GRID("product_name", 180, "Nombre del Proudcto", "ProductName", grid_itemRC);
            AGREGAR_COLUMN_GRID("numero_id", 70, "Numero ID", "roll_id", grid_itemRC);
            AGREGAR_COLUMN_GRID("ancho", 70, "Ancho [MM]", "width", grid_itemRC);
            AGREGAR_COLUMN_GRID("m2", 70, "M2.", "lenght", grid_itemRC);
            grid_itemRC.ReadOnly = true;

        }
        private void EstiloGridHojas()
        {
            grid_itemRC.ReadOnly = false;
            grid_itemRC.AutoGenerateColumns = false;
            AGREGAR_COLUMN_GRID("product_id", 70, "Product Id.", "Part_Number", grid_itemRC);
            AGREGAR_COLUMN_GRID("product_name", 180, "Nombre del Proudcto", "ProductName", grid_itemRC);
            AGREGAR_COLUMN_GRID("width", 70, "Width [MM]", "Width", grid_itemRC);
            AGREGAR_COLUMN_GRID("lenght", 70, "Lenght [MM]", "lenght", grid_itemRC);
            AGREGAR_COLUMN_GRID("pack", 70, "Resmas x Paq.", "palet_cant", grid_itemRC);
            AGREGAR_COLUMN_GRID("hojas", 70, "Cant. Hojas", "Palet_paginas", grid_itemRC);
            AGREGAR_COLUMN_GRID("cant_des", 70, "Cant. Despachar", "cant_despacho", grid_itemRC);
        }
        private void COLREADONLY() 
        {
            grid_itemRC.Columns[0].ReadOnly = true;
            grid_itemRC.Columns[1].ReadOnly = true;
            grid_itemRC.Columns[2].ReadOnly = true;
            grid_itemRC.Columns[3].ReadOnly = true;
            grid_itemRC.Columns[4].ReadOnly = true;
            grid_itemRC.Columns[5].ReadOnly = true;
        }
        private void EstiloGridCortados()
        {
            grid_itemRC.AutoGenerateColumns = false;
            AGREGAR_COLUMN_GRID("unique_code", 60, "Codigo Unico", "unique_code", grid_itemRC);
            AGREGAR_COLUMN_GRID("product_id", 60, "Product Id.", "product_id", grid_itemRC);
            AGREGAR_COLUMN_GRID("product_name", 180, "Nombre del Proudcto", "product_name", grid_itemRC);
            AGREGAR_COLUMN_GRID("roll_number", 40, "Roll number", "roll_number", grid_itemRC);
            AGREGAR_COLUMN_GRID("width", 50, "Width", "width", grid_itemRC);
            AGREGAR_COLUMN_GRID("large", 50, "Largo", "large", grid_itemRC);
            AGREGAR_COLUMN_GRID("msi", 50, "Msi", "msi", grid_itemRC);
            AGREGAR_COLUMN_GRID("splice", 60, "Splice", "splice", grid_itemRC);
            AGREGAR_COLUMN_GRID("roll_id", 60, "Roll Id.", "roll_id", grid_itemRC);
            AGREGAR_COLUMN_GRID("code_person", 60, "Codigo Perso.", "code_person", grid_itemRC);
            AGREGAR_COLUMN_GRID("status", 60, "Status Calidad", "status", grid_itemRC);
            AGREGAR_COLUMN_GRID("tipo_mov", 60, "Tipo", "tipo_mov", grid_itemRC);
            grid_productos.AutoGenerateColumns = false;
            AGREGAR_COLUMN_GRID("product_id", 60, "Product_id", "product_id", grid_productos);
            AGREGAR_COLUMN_GRID("product_name", 200, "Nombre del Producto", "product_name", grid_productos);
            AGREGAR_COLUMN_GRID("cant", 60, "Cantida Rollos", "product_quantity", grid_productos);
            AGREGAR_COLUMN_GRID("width", 60, "Width", "width", grid_productos);
            AGREGAR_COLUMN_GRID("lenght", 60, "Lenght", "lenght", grid_productos);
            AGREGAR_COLUMN_GRID("msi", 60, "Msi", "msi", grid_productos);
        }
        #endregion
        #region LOAD_DATA
        private void LoadDataGraphics() 
        {
            ClassRecepcion graphic = recepcionManager.GetDataGraphicsByID(txt_uniqueCode.Text.Trim());
            //verificar valores vacios.
            if (graphic.Roll_ID == "" || graphic.Palet_number == null) return;
            //verificar valores repetidos
            foreach (ClassRecepcion item in Lista_graphics)
            {
                if (item.Roll_ID.Equals(txt_uniqueCode.Text.Trim()))
                {
                    MessageBox.Show("esta repetido");
                    txt_uniqueCode.Text = "";
                    return;
                }
            }
            Lista_graphics.Add(graphic);
            grid_itemRC.DataSource = Lista_graphics.ToList();
            txt_uniqueCode.Text = "";
            REGISTROS_TOTALES.Text = "Numero de Registros : " + Lista_graphics.Count.ToString();
        }
        private void LoadDataHojas()
        {
            ClassRecepcion hoja = recepcionManager.GetDataHojasByID(txt_uniqueCode.Text.Trim());
            //verificar valores vacios.
            if (hoja.Palet_number == "" || hoja.Palet_number == null) return;
            //verificar valores repetidos
            foreach (ClassRecepcion item in Lista_hojas)
            {
                if (item.Palet_number.Equals(txt_uniqueCode.Text.Trim()))
                {
                    MessageBox.Show("esta repetido");
                    txt_uniqueCode.Text = "";
                    return;
                }
            }
            Lista_hojas.Add(hoja);
            grid_itemRC.DataSource = Lista_hojas.ToList();
            txt_uniqueCode.Text = "";
            REGISTROS_TOTALES.Text = "Numero de Registros : " + Lista_hojas.Count.ToString();
        }
        private void LoadDataCortados()
        {
            string prefix = "RC";

            if (chk_especial.Checked)
            {
                prefix = "";
            }

            Roll_Details rollo = produccionManager.GetDataUniqueCode(prefix + txt_uniqueCode.Text.Trim());
            //verificar valores vacios.
            if (rollo.Unique_code == "" || rollo.Unique_code == null) return;
            //verificar valores repetidos
            foreach (Roll_Details item in Lista_rollos)
            {
                if (item.Unique_code.Equals(prefix + txt_uniqueCode.Text.Trim()))
                {
                    MessageBox.Show("esta repetido");
                    txt_uniqueCode.Text = "";
                    return;
                }
            }
            rollo.Tipo_pro = 0;
            Lista_rollos.Add(rollo);
            grid_itemRC.DataSource = Lista_rollos.ToList();
            txt_uniqueCode.Text = "";
            REGISTROS_TOTALES.Text = "Numero de Registros : " + Lista_rollos.Count.ToString();
        }
        private void CALCULATE_DATA()
        {
            List_products = from line in Lista_rollos
                            group line by new { line.Product_id, line.Width, line.Large } into g
                            select new Producto
                            {
                                Product_id = g.First().Product_id,
                                Product_name = g.First().Product_name,
                                Product_quantity = g.Count().ToString(),
                                Width = g.First().Width,
                                Lenght = g.First().Large,
                                Msi = g.First().Msi
                            };

            grid_productos.DataSource = List_products.ToList();
        }
        #endregion
        #region PROCEDURES_FORMS
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
        private void Bot_transferir_Click(object sender, EventArgs e)
        {
            //Validacion de la cantidad a despachar en hojas
            if (RA_HOJAS.Checked)
            {
                for (int i = 0; i <= grid_itemRC.Rows.Count - 1; i++)
                {
                    if (Convert.ToInt32(grid_itemRC.Rows[i].Cells["cant_des"].Value) == 0)
                    {
                        MessageBox.Show("La cantida a despachar no puede tener valores en 0");
                        return;
                    }
                }
            }
            this.Close();
        }
        private void Bot_leer_Click(object sender, EventArgs e)
        {
            ExtraerDataAppMovil();
            //getdata de los unique code.
            foreach (Roll_Details item in Lista_rollos)
            {
                Roll_Details rollo = produccionManager.GetDataUniqueCode(item.Unique_code);
                item.Product_id = rollo.Product_id;
                item.Product_name = rollo.Product_name;
                item.Roll_number = rollo.Roll_number;
                item.Width = rollo.Width;
                item.Large = rollo.Large;
                item.Msi = rollo.Msi;
                item.Splice = rollo.Splice;
                item.Roll_id = rollo.Roll_id;
                item.Code_Person = rollo.Code_Person;
                item.Status = rollo.Status;
                item.Tipo_mov = rollo.Tipo_mov;
            }
            grid_itemRC.DataSource = Lista_rollos;
            //linq que consolida los renglones del conduce.

            CALCULATE_DATA();

            grid_productos.DataSource = List_products.ToList();


            REGISTROS_TOTALES.Text = "Numero de Registros : " + Lista_rollos.Count.ToString();

        }
        private void ExtraerDataAppMovil()
        {
            //extraigo los unique code
            Lista_rollos = new List<Roll_Details>();
            if (File.Exists(R.PATH_FILES.FILE_TXT_DATA_PICKING_DESPACHO))
            {
                try
                {
                    using (StreamReader sr = new StreamReader(R.PATH_FILES.FILE_TXT_DATA_PICKING_DESPACHO))
                    {
                        while (sr.Peek() >= 0)
                        {
                            try
                            {
                                string str;
                                string[] strArray;
                                str = sr.ReadLine();
                                strArray = str.Split(',');
                                string unique = strArray[0];

                                Roll_Details rollo = new Roll_Details
                                {
                                    Unique_code = strArray[0],

                                };
                                Lista_rollos.Add(rollo);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("error al leer la data y convertir el archivo txt de despacho: " + ex);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("error al tratar de crear el txt de despacho" + ex);

                }
            }
        }
        #endregion

      
    }
}
public class Producto
{
    public string Product_id { get; set; }
    public string Product_name { get; set; }
    public string Product_quantity { get; set; }
    public decimal Width { get; set; }
    public decimal Lenght { get; set; }
    public decimal Msi { get; set; }

}