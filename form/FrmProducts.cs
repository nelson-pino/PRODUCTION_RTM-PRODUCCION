using RitramaAPP.Clases;
using RitramaAPP.form;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace RitramaAPP
{
    public partial class FrmProducts : Form
    {
        public FrmProducts()
        {
            InitializeComponent();
        }

        readonly ProductsManager producto = new ProductsManager();
        readonly BindingSource bs = new BindingSource();
        DataSet ds = new DataSet();
        int EditMode = 0;
        private void FrmProducts_Load(object sender, EventArgs e)
        {
            producto.ToList();
            ds = producto.ds;
            bs.DataSource = ds;
            bs.DataMember = "dtproducto";
            txt_product_id.DataBindings.Add("text", bs, "Product_ID");
            txt_product_name.DataBindings.Add("text", bs, "Product_Name");
            txt_descrip_product.DataBindings.Add("text", bs, "Product_Descrip");
            txt_precio.DataBindings.Add("text", bs, "precio");
            txt_referencia.DataBindings.Add("text", bs, "Product_Ref");
            txt_code_bar.DataBindings.Add("text", bs, "Codebar");
            cbo_category.DataBindings.Add("text", bs, "Category_ID");
            CHK_ANULADO.DataBindings.Add("checked", bs, "anulado");
            RAD_MASTER_ROLLS.DataBindings.Add("checked", bs, "MasterRolls");
            RAD_ROLLO_CORTADO.DataBindings.Add("checked", bs, "rollo_cortado");
            RAD_RESMAS.DataBindings.Add("checked", bs, "Resmas");
            RAD_GRAPHICS.DataBindings.Add("checked", bs, "graphics");
            txt_codeRC.DataBindings.Add("text", bs, "code_RC");
            txt_ratio.DataBindings.Add("text", bs, "ratio");
            ContadorRegistros();
        }
        private void ContadorRegistros()
        {
            LABEL_CONTADOR_REGISTRO.Text = (bs.Position + 1) + " de " + (bs.Count.ToString()) + " Registros";
        }
        private void BOT_SIGUIENTE_Click(object sender, EventArgs e)
        {
            bs.Position += 1;
            ContadorRegistros();
        }

        private void BOT_ANTERIOR_Click(object sender, EventArgs e)
        {
            bs.Position -= 1;
            ContadorRegistros();
        }

        private void BOT_PRIMERO_Click(object sender, EventArgs e)
        {
            bs.Position = 0;
            ContadorRegistros();
        }

        private void BOT_ULTIMO_Click(object sender, EventArgs e)
        {
            bs.Position = bs.Count;
            ContadorRegistros();
        }

        private void BOT_NUEVO_Click(object sender, EventArgs e)
        {
            BOT_PRIMERO.Enabled = false;
            BOT_SIGUIENTE.Enabled = false;
            BOT_ULTIMO.Enabled = false;
            BOT_ANTERIOR.Enabled = false;
            BOT_NUEVO.Enabled = false;
            BOT_MODIFICAR.Enabled = false;
            BOT_BUSCAR.Enabled = false;
            BOT_GRABAR.Enabled = true;
            BOT_CANCELAR.Enabled = true;
            txt_product_id.ReadOnly = false;
            txt_product_name.ReadOnly = false;
            txt_descrip_product.ReadOnly = false;
            txt_code_bar.ReadOnly = false;
            txt_precio.ReadOnly = false;
            txt_referencia.ReadOnly = false;
            txt_ratio.ReadOnly = false;
            cbo_category.Enabled = true;
            RAD_MASTER_ROLLS.Enabled = true;
            RAD_RESMAS.Enabled = true;
            RAD_GRAPHICS.Enabled = true;
            RAD_MASTER_ROLLS.Checked = false;
            RAD_RESMAS.Checked = false;
            RAD_GRAPHICS.Checked = false;
            RAD_ROLLO_CORTADO.Checked = false;
            CHK_ANULADO.Checked = false;
            CHK_ANULADO.DataBindings.Clear();
            RAD_MASTER_ROLLS.DataBindings.Clear();
            RAD_ROLLO_CORTADO.DataBindings.Clear();
            RAD_RESMAS.DataBindings.Clear();
            RAD_GRAPHICS.DataBindings.Clear();
            DataRow dr = ds.Tables["dtproducto"].NewRow();
            dr["anulado"] = false;
            dr["MasterRolls"] = false;
            dr["rollo_cortado"] = false;
            dr["Resmas"] = false;
            dr["graphics"] = false;
            dr["precio"] = 0;
            dr["ratio"] = 0;
            ds.Tables["dtproducto"].Rows.Add(dr);
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

            ClassProduct producto = new ClassProduct
            {
                Product_id = txt_product_id.Text,
                ProductName = txt_product_name.Text,
                Descripcion = txt_descrip_product.Text,
                Referencia = txt_referencia.Text,
                Codebar = txt_code_bar.Text,
                Categoria = cbo_category.Text,
                Precio = Convert.ToDouble(txt_precio.Text),
                MasterRolls = RAD_MASTER_ROLLS.Checked,
                Resmas = RAD_RESMAS.Checked,
                Code_RC = "",
                Anulado = CHK_ANULADO.Checked,
                Graphics = RAD_GRAPHICS.Checked,
                Ratio = Convert.ToDecimal(txt_ratio.Text)
            };
            ProductsManager productoManager = new ProductsManager();
            productoManager.Update(producto);
            txt_descrip_product.ReadOnly = true;
            txt_product_name.ReadOnly = true;
            txt_referencia.ReadOnly = true;
            txt_code_bar.ReadOnly = true;
            txt_precio.ReadOnly = true;
            txt_ratio.ReadOnly = true;
            cbo_category.Enabled = false;
            CHK_ANULADO.Enabled = false;
            RAD_GRAPHICS.Enabled = false;
            RAD_MASTER_ROLLS.Enabled = false;
            RAD_RESMAS.Enabled = false;
            BOT_PRIMERO.Enabled = true;
            BOT_SIGUIENTE.Enabled = true;
            BOT_ULTIMO.Enabled = true;
            BOT_ANTERIOR.Enabled = true;
            BOT_NUEVO.Enabled = true;
            BOT_MODIFICAR.Enabled = true;
            BOT_BUSCAR.Enabled = true;
            BOT_GRABAR.Enabled = false;
            BOT_CANCELAR.Enabled = false;
            EditMode = 0;
        }
        private ClassProduct CreateProductRollCut(ClassProduct producto)
        {
            //creo el producto rollo cortado.
            DataRow dr = ds.Tables["dtproducto"].NewRow();
            dr["product_id"] = producto.Product_id + "0";
            dr["product_name"] = producto.ProductName + " RC";
            dr["rollo_Cortado"] = true;
            dr["MasterRolls"] = false;
            dr["Graphics"] = false;
            dr["Resmas"] = false;
            dr["Product_Ref"] = "";
            dr["Anulado"] = false;
            dr["Codebar"] = "";
            dr["Code_RC"] = "";
            dr["precio"] = 0;
            ds.Tables["dtproducto"].Rows.Add(dr);
            //Creo el objeto y lo agrego a la base de datos.
            ClassProduct rollo_cortado = new ClassProduct
            {
                Product_id = Convert.ToString(dr["product_id"]),
                ProductName = producto.ProductName,
                Rollo_Cortado = true,
                MasterRolls = false,
                Graphics = false,
                Resmas = false,
                Referencia = "",
                Anulado = false,
                Codebar = "",
                Descripcion = "",
                Categoria = "",
                Precio = 0,
                Code_RC = ""
            };
            return rollo_cortado;
        }
        private void GrabarNuevoRegistro()
        {
            //Actualizo la Interfaz Grafica.
            DataRowView FilaActual;
            FilaActual = (DataRowView)bs.Current;
            FilaActual["precio"] = txt_precio.Text;
            FilaActual["product_name"] = txt_product_name.Text;
            FilaActual["MasterRolls"] = RAD_MASTER_ROLLS.Checked;
            FilaActual["Resmas"] = RAD_RESMAS.Checked;
            FilaActual["Graphics"] = RAD_GRAPHICS.Checked;
            FilaActual["Product_Ref"] = txt_referencia.Text;
            FilaActual["Codebar"] = txt_code_bar.Text;
            FilaActual["Ratio"] = txt_ratio.Text;

            if (RAD_MASTER_ROLLS.Checked)
            {
                FilaActual["Code_RC"] = txt_product_id.Text + "0";
            }
            else
            {
                FilaActual["Code_RC"] = "";
            }
            bs.EndEdit();
            //Crear el Objeto producto.
            ClassProduct producto = new ClassProduct
            {
                Precio = 0,
                Product_id = txt_product_id.Text,
                ProductName = txt_product_name.Text,
                Descripcion = txt_descrip_product.Text,
                Referencia = txt_referencia.Text,
                Codebar = txt_code_bar.Text,
                Categoria = cbo_category.Text,
                MasterRolls = RAD_MASTER_ROLLS.Checked,
                Resmas = RAD_RESMAS.Checked,
                Graphics = RAD_GRAPHICS.Checked,
                Code_RC = FilaActual["Code_RC"].ToString(),
                Ratio = Convert.ToDecimal(txt_ratio.Text)
            };
            producto.Precio = Convert.ToDouble(txt_precio.Text);
            producto.Anulado = false;
            ProductsManager productoManager = new ProductsManager();
            // Validar la entidad Producto.
            if (producto.Product_id == string.Empty)
            {
                MessageBox.Show("Introduzca el Part Number.");
                return;
            }
            if (producto.ProductName == string.Empty)
            {
                MessageBox.Show("Introduzca el nombre del producto.");
                return;
            }
            if (producto.MasterRolls == false && producto.Resmas == false && producto.Graphics == false)
            {
                MessageBox.Show("Introduzca el tipo de producto Master Roll,Resma,Graphics.");
                return;
            }
            productoManager.Add(producto, false);
            // Verifico que el producto creado es un master rolls
            // para crear tambien el producto como rollo cortado.
            if (producto.MasterRolls)
            {
                productoManager.Add(CreateProductRollCut(producto), true);
            }
            txt_product_id.ReadOnly = true;
            txt_product_name.ReadOnly = true;
            txt_descrip_product.ReadOnly = true;
            txt_code_bar.ReadOnly = true;
            txt_referencia.ReadOnly = true;
            txt_precio.ReadOnly = true;
            txt_ratio.ReadOnly = true;
            cbo_category.Enabled = true;
            RAD_MASTER_ROLLS.Enabled = false;
            RAD_RESMAS.Enabled = false;
            RAD_GRAPHICS.Enabled = false;
            cbo_category.Enabled = false;
            CHK_ANULADO.DataBindings.Add("checked", bs, "anulado");
            RAD_MASTER_ROLLS.DataBindings.Add("checked", bs, "MasterRolls");
            RAD_ROLLO_CORTADO.DataBindings.Add("checked", bs, "rollo_cortado");
            RAD_RESMAS.DataBindings.Add("checked", bs, "Resmas");
            RAD_GRAPHICS.DataBindings.Add("checked", bs, "graphics");
            ContadorRegistros();
            EditMode = 0;
            BOT_PRIMERO.Enabled = true;
            BOT_SIGUIENTE.Enabled = true;
            BOT_ANTERIOR.Enabled = true;
            BOT_ULTIMO.Enabled = true;
            BOT_NUEVO.Enabled = true;
            BOT_CANCELAR.Enabled = false;
            BOT_GRABAR.Enabled = false;
            BOT_MODIFICAR.Enabled = true;
            BOT_BUSCAR.Enabled = true;
        }

        private void BOT_MODIFICAR_Click(object sender, EventArgs e)
        {
            txt_product_name.ReadOnly = false;
            txt_descrip_product.ReadOnly = false;
            txt_code_bar.ReadOnly = false;
            txt_referencia.ReadOnly = false;
            txt_precio.ReadOnly = false;
            txt_ratio.ReadOnly = false;
            cbo_category.Enabled = true;
            CHK_ANULADO.Enabled = true;
            RAD_MASTER_ROLLS.Enabled = true;
            RAD_RESMAS.Enabled = true;
            RAD_GRAPHICS.Enabled = true;
            BOT_PRIMERO.Enabled = false;
            BOT_SIGUIENTE.Enabled = false;
            BOT_ANTERIOR.Enabled = false;
            BOT_ULTIMO.Enabled = false;
            BOT_NUEVO.Enabled = false;
            BOT_CANCELAR.Enabled = true;
            BOT_GRABAR.Enabled = true;
            BOT_MODIFICAR.Enabled = false;
            BOT_BUSCAR.Enabled = false;
            EditMode = 2;
        }

        private void BOT_BUSCAR_Click(object sender, EventArgs e)
        {
            SeleccionProductos BrowseProducts = new SeleccionProductos
            {
                Dtproducto = ds.Tables["dtproducto"]
            };
            BrowseProducts.ShowDialog();
            int itemFound = bs.Find("Product_ID", BrowseProducts.ItemSelected);
            bs.Position = itemFound;
        }

        private void BOT_CANCELAR_Click(object sender, EventArgs e)
        {
            if (EditMode == 1)
            {
                //viene de agregar nuevo
                //borro la factura alcual.
                BOT_CANCELAR.Enabled = false;
                BOT_GRABAR.Enabled = false;
                BOT_PRIMERO.Enabled = true;
                BOT_SIGUIENTE.Enabled = true;
                BOT_ULTIMO.Enabled = true;
                BOT_ANTERIOR.Enabled = true;
                BOT_NUEVO.Enabled = true;
                BOT_MODIFICAR.Enabled = true;
                BOT_BUSCAR.Enabled = true;
                DataRowView FilaActual;
                FilaActual = (DataRowView)bs.Current;
                FilaActual.Row.Delete();
                bs.EndEdit();
                bs.Position = bs.Count;
                ContadorRegistros();
                txt_product_id.ReadOnly = true;
                txt_product_name.ReadOnly = true;
                txt_descrip_product.ReadOnly = true;
                txt_code_bar.ReadOnly = true;
                txt_referencia.ReadOnly = true;
                txt_precio.ReadOnly = true;
                cbo_category.Enabled = true;
                txt_ratio.ReadOnly = true;
                RAD_MASTER_ROLLS.DataBindings.Add("checked", bs, "MasterRolls");
                RAD_RESMAS.DataBindings.Add("checked", bs, "Resmas");
                RAD_GRAPHICS.DataBindings.Add("checked", bs, "graphics");
                RAD_MASTER_ROLLS.Enabled = false;
                RAD_RESMAS.Enabled = false;
                RAD_GRAPHICS.Enabled = false;
                cbo_category.Enabled = false;

            }
            if (EditMode == 2)
            {
                BOT_CANCELAR.Enabled = false;
                BOT_GRABAR.Enabled = false;
                BOT_PRIMERO.Enabled = true;
                BOT_SIGUIENTE.Enabled = true;
                BOT_ULTIMO.Enabled = true;
                BOT_ANTERIOR.Enabled = true;
                BOT_NUEVO.Enabled = true;
                BOT_MODIFICAR.Enabled = true;
                BOT_BUSCAR.Enabled = true;
                txt_product_id.ReadOnly = true;
                txt_product_name.ReadOnly = true;
                txt_descrip_product.ReadOnly = true;
                txt_code_bar.ReadOnly = true;
                txt_referencia.ReadOnly = true;
                txt_precio.ReadOnly = true;
                txt_ratio.ReadOnly = true;
                cbo_category.Enabled = true;
                RAD_MASTER_ROLLS.Enabled = false;
                RAD_RESMAS.Enabled = false;
                RAD_GRAPHICS.Enabled = false;
                cbo_category.Enabled = false;
            }





        }

        private void Txt_product_id_Validating(object sender, CancelEventArgs e)
        {
            if (producto.ProductoExiste(txt_product_id.Text) && EditMode == 1)
            {
                MessageBox.Show("El codigo de producto: " + txt_product_id.Text + " ya existe.");
                txt_product_id.Text = "";
            }
        }

        private void Txt_product_id_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
