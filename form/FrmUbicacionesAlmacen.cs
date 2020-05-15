using RitramaAPP.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RitramaAPP.form
{
    public partial class FrmUbicacionesAlmacen : Form
    {
        public FrmUbicacionesAlmacen()
        {
            InitializeComponent();
        }

        readonly InventarioManager manager = new InventarioManager();
        public List<Item> Lista { get; set; }

        private void FrmUbicacionesAlmacen_Load(object sender, EventArgs e)
        {
            Lista = new List<Item>();

            GridUbicaciones.AutoGenerateColumns = false;
            AGREGAR_COLUMN_GRID("unique_code", 65, "Codigo Unico", "unique_code", GridUbicaciones);
            AGREGAR_COLUMN_GRID("product_id", 65, "Product Id.", "product_id", GridUbicaciones);
            AGREGAR_COLUMN_GRID("product_name", 200, "Nombre del Producto","product_name", GridUbicaciones);
            AGREGAR_COLUMN_GRID("width", 65, "Width","width", GridUbicaciones);
            AGREGAR_COLUMN_GRID("lenght", 65, "Lenght", "lenght", GridUbicaciones);
            AGREGAR_COLUMN_GRID("msi", 65, "Msi", "msi", GridUbicaciones);
            AGREGAR_COLUMN_GRID("tipo", 30, "Tipo", "tipo", GridUbicaciones);
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

        private void Bot_read_Click(object sender, EventArgs e)
        {
            GetDataTxt();
            //Actualizar la lista con los datos de los Rollos.
            GetDataBaseDataRollos();
            GridUbicaciones.DataSource = Lista;
            LABEL_TOTAL_REGISTROS.Text = "TOTAL REGISTROS :" + GridUbicaciones.Rows.Count.ToString();
        }
        private void GetDataBaseDataRollos() 
        {
            foreach(Item item in Lista) 
            {
                Item xitem = manager.GetDataRollofromRC(item.Unique_code);
                item.Product_id = xitem.Product_id;
                item.Product_name = xitem.Product_name;
                item.Width = xitem.Width;
                item.Lenght = xitem.Lenght;
                item.Msi = xitem.Msi;
                item.Tipo = xitem.Tipo;
            }
        }
        private void GetDataTxt() 
        {
            string path = @"C:\Users\Npino.ETIQUETAS\Desktop\data\ubicaciones.txt";
            if (File.Exists(path))
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    while (sr.Peek() >= 0)
                    {
                        try
                        {
                            string str;
                            string[] strArray;
                            str = sr.ReadLine();
                            strArray = str.Split(',');
                            string rc = strArray[0];
                            //crear el item de productos
                            Item item = new Item
                            {
                                Unique_code = rc
                            };
                            Lista.Add(item);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error al leer el Archivo. + Error:" + ex);
                        }
                    }
                }
            }
        }
        private void Bot_ubicar_Click(object sender, EventArgs e)
        {
            if (txt_ubicacion.Text == "") 
            {
                MessageBox.Show("Debe Introducir la Ubicacion para poder ejecutar este comando.,");
                return;
            }
            foreach (Item item in Lista)
            {
                manager.SetDataUbicationToAlmacenFromRC(item.Tipo,txt_ubicacion.Text,item.Unique_code);
            }
            MessageBox.Show("Proceso con Exito.");
        }
    }
}
