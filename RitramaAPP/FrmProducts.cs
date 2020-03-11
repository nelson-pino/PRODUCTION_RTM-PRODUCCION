using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RitramaAPP.Clases;

namespace RitramaAPP
{
    public partial class FrmProducts : Form
    {
        public FrmProducts()
        {
            InitializeComponent();
        }
        readonly ProductManager producto = new ProductManager();
        private void FrmProducts_Load(object sender, EventArgs e)
        {
            producto.ToList();
            ds = producto.ds;
  
            bs.DataSource = ds;
            bs.DataMember = "dtproducto";
            txt_product_id.DataBindings.Add("text",bs, "Product_ID");
            txt_product_name.DataBindings.Add("text", bs, "Product_Name");
            txt_descrip_product.DataBindings.Add("text",bs, "Product_Descrip");
            txt_referencia.DataBindings.Add("text",bs, "Product_Ref");
            txt_code_bar.DataBindings.Add("text", bs, "Codebar");
            txt_existencia.DataBindings.Add("text",bs, "existencia_final");
            cbo_category.DataBindings.Add("text",bs, "Category_ID");
            //CHK_ANULADO.DataBindings.Add("checked", bs, "anulado");
            RAD_PRODUCTO_MP.DataBindings.Add("checked", bs, "Tipo_MP");
            RAD_PRODUCTO_PT.DataBindings.Add("checked", bs, "Tipo_PT");
            ContadorRegistros();
        }
        private void ContadorRegistros()
        {
            LABEL_CONTADOR_REGISTRO.Text = "Registro: " + (bs.Position + 1) + " de " + bs.Count;

        }

      

        
       
    }
}
