using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RitramaAPP
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }
        private void TreeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            SELECT_OPCION_MENU_MAIN(e.Node.Text);
        }
        private void Main_Load(object sender, EventArgs e)
        {

        }
        private void BOT_PRIMERO_Click(object sender, EventArgs e)
        {
            PROC_MOVE_REGISTERS_DOCUMENT_FIRST(treeView1.SelectedNode.Text);
        }
        private void BOT_SIGUIENTE_Click(object sender, EventArgs e)
        {
            PROC_MOVE_REGISTERS_DOCUMENT_NEXT(treeView1.SelectedNode.Text);
        }
        private void BOT_ANTERIOR_Click(object sender, EventArgs e)
        {
            PROC_MOVE_REGISTERS_DOCUMENT_ANTERIOR(treeView1.SelectedNode.Text);
        }
        private void BOT_ULTIMO_Click(object sender, EventArgs e)
        {
            PROC_MOVE_REGISTERS_DOCUMENT_LAST(treeView1.SelectedNode.Text);
        }
        private void BOT_NUEVO_DOC_Click(object sender, EventArgs e)
        {
            PROC_GENERATE_NEW_DOCUMENTS(treeView1.SelectedNode.Text);
        }
        private void SELECT_OPCION_MENU_MAIN(string str_option)
        {
            switch (str_option)
            {
                case "Materia Prima":
                    panel1.Controls.Clear();
                    frmMateriaPrima f = new frmMateriaPrima
                    {
                        TopLevel = false
                    };
                    this.panel1.Controls.Add(f);
                    f.Dock = DockStyle.Fill;
                    f.Show();
                    break;
                case "Pedidos Clientes":
                    panel1.Controls.Clear();
                    FrmPedidos fpedido = new FrmPedidos
                    {
                        TopLevel = false
                    };
                    this.panel1.Controls.Add(fpedido);
                    fpedido.Dock = DockStyle.Fill;
                    fpedido.Show();
                    break;
                case "Ordenes Corte":
                    panel1.Controls.Clear();
                    FrmOrdenCorte fcorte = new FrmOrdenCorte
                    {
                        TopLevel = false
                    };
                    this.panel1.Controls.Add(fcorte);
                    fcorte.Dock = DockStyle.Fill;
                    fcorte.Show();
                    break;
                case "Productos":
                    panel1.Controls.Clear();
                    FrmProducts fproducts = new FrmProducts
                    {
                        TopLevel = false
                    };
                    this.panel1.Controls.Add(fproducts);
                    fproducts.Dock = DockStyle.Fill;
                    fproducts.Show();
                    break;
                case "Customers":
                    panel1.Controls.Clear();
                    FrmCustomers fcust = new FrmCustomers
                    {
                        TopLevel = false
                    };
                    this.panel1.Controls.Add(fcust);
                    fcust.Dock = DockStyle.Fill;
                    fcust.Show();
                    break;
                case "Proveedores":
                    panel1.Controls.Clear();
                    FrmSupply fsuply = new FrmSupply
                    {
                        TopLevel = false
                    };
                    this.panel1.Controls.Add(fsuply);
                    fsuply.Dock = DockStyle.Fill;
                    fsuply.Show();
                    break;
                case "Modulo de Inventarios":
                    panel1.Controls.Clear();
                    FrmInventario finvent = new FrmInventario
                    {
                        TopLevel = false
                    };
                    this.panel1.Controls.Add(finvent);
                    finvent.Dock = DockStyle.Fill;
                    finvent.Show();
                    break;
                case "Configuracion":
                    panel1.Controls.Clear();
                    FrmConfig fconfig = new FrmConfig
                    {
                        TopLevel = false
                    };
                    this.panel1.Controls.Add(fconfig);
                    fconfig.Dock = DockStyle.Fill;
                    fconfig.Show();
                    break;
            }
        }
        //EVENTOS MAIN DEL TOOLSBAR PARA TODAS LAS PAGINAS.
        private void PROC_MOVE_REGISTERS_DOCUMENT_FIRST(string StrSelectOption)
        {
            switch (StrSelectOption)
            {
                case "Productos":
                    MOVE_DOCUMENTS_FIRST_PRODUCTS();
                    break;
                case "Customers":
                    MessageBox.Show("customers primero");
                    break;
                case "Proveedores":
                    MessageBox.Show("proveedor primero");
                    break;
            }

        }
        private void PROC_MOVE_REGISTERS_DOCUMENT_NEXT(string StrSelectOption)
        {
            switch (StrSelectOption)
            {
                case "Productos":
                    MOVE_DOCUMENTS_NEXT_PRODUCTS();
                   
                    


                    break;
                case "Customers":
                    MessageBox.Show("customers NEXT");
                    break;
                case "Proveedores":
                    MessageBox.Show("proveedor NEXT");
                    break;
            }

        }
        private void PROC_MOVE_REGISTERS_DOCUMENT_ANTERIOR(string StrSelectOption)
        {
            switch (StrSelectOption)
            {
                case "Productos":
                    MOVE_DOCUMENTS_ANTERIOR_PRODUCTS();
                    break;
                case "Customers":
                    MessageBox.Show("customers ANTERIOR");
                    break;
                case "Proveedores":
                    MessageBox.Show("proveedor ANTERIOR");
                    break;
            }

        }
        private void PROC_MOVE_REGISTERS_DOCUMENT_LAST(string StrSelectOption)
        {
            switch (StrSelectOption)
            {
                case "Productos":
                    MOVE_DOCUMENTS_LAST_PRODUCTS();
                    break;
                case "Customers":
                    MessageBox.Show("customers ultimo");
                    break;
                case "Proveedores":
                    MessageBox.Show("proveedor ultimo");
                    break;
            }
        }
        private void PROC_GENERATE_NEW_DOCUMENTS(string StrSelectOption)
        {
            switch (StrSelectOption)
            {
                case "Productos":
                    CREATE_NEW_DOCUMENTS_PRODUCTS();
                    break;
                case "Customers":
                    MessageBox.Show("customers nuevos");
                    break;
                case "Proveedores":
                    MessageBox.Show("proveedor nuevos");
                    break;
            }
        }

        // FUNCIONALIDAD DE LA PAGINA DE PRODUCTOS.
        #region CODIGO PARA GESTIONAR LOS PRODUCTOS 
        private void CREATE_NEW_DOCUMENTS_PRODUCTS()
        {
            Form formRef = (Form)panel1.Controls["FrmProducts"];
            BindingSource bs = ((RitramaAPP.FrmProducts)formRef).bs;
            DataSet ds = ((RitramaAPP.FrmProducts)formRef).ds;
            TextBox txt_product_id = (TextBox)formRef.Controls["txt_product_id"];
            TextBox txt_product_name = (TextBox)formRef.Controls["txt_product_name"];
            TextBox txt_descrip_product = (TextBox)formRef.Controls["txt_descrip_product"];
            TextBox txt_referencia = (TextBox)formRef.Controls["txt_referencia"];
            TextBox txt_code_bar = (TextBox)formRef.Controls["txt_code_bar"];
            TextBox txt_existencia = (TextBox)formRef.Controls["txt_existencia"];
            ComboBox cbo_category = (ComboBox)formRef.Controls["cbo_category"];
            CheckBox CHK_ANULADO = (CheckBox)formRef.Controls["CHK_ANULADO"];
            GroupBox gb = (GroupBox)formRef.Controls["GRUPO_TIPO_PRODUCTO"];
            RadioButton RAD_PRODUCTO_MP = (RadioButton)gb.Controls["RAD_PRODUCTO_MP"];
            RadioButton RAD_PRODUCTO_PT = (RadioButton)gb.Controls["RAD_PRODUCTO_PT"];
            Label LABEL_CONTADOR_REGISTRO = (Label)formRef.Controls["LABEL_CONTADOR_REGISTRO"];
            txt_product_id.ReadOnly = false;
            txt_referencia.ReadOnly = false;
            txt_code_bar.ReadOnly = false;
            txt_descrip_product.ReadOnly = false;
            txt_product_name.ReadOnly = false;
            txt_existencia.ReadOnly = false;
            cbo_category.Enabled = true;
            RAD_PRODUCTO_MP.Enabled = true;
            RAD_PRODUCTO_PT.Enabled = true;
            CHK_ANULADO.Checked = false;
            DataTable Mitabla = ds.Tables["dtproducto"];
            DataRowCollection Filas = Mitabla.Rows;
            DataRow NuevaFila;
            try
            {
                //Agregar Fila.
                NuevaFila = Mitabla.NewRow();
                Filas.Add(NuevaFila);
                bs.Position = (bs.Count-1);
                LABEL_CONTADOR_REGISTRO.Text = "Registro: 1 de " + bs.Count;
                txt_product_id.Focus();
            }
            catch (ConstraintException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void MOVE_DOCUMENTS_FIRST_PRODUCTS()
        {
            Form formRef = (Form)panel1.Controls["FrmProducts"];
            BindingSource bsRef = ((RitramaAPP.FrmProducts)formRef).bs;
            bsRef.Position = 0;
            Label LABEL_CONTADOR_REGISTRO = (Label)formRef.Controls["LABEL_CONTADOR_REGISTRO"];
            LABEL_CONTADOR_REGISTRO.Text = "Registro: 1 de " + bsRef.Count;
        }
        private void MOVE_DOCUMENTS_NEXT_PRODUCTS()
        {
            Form formRef = (Form)panel1.Controls["FrmProducts"];
            //TextBox tb = (TextBox) formRef.Controls["txt_product_id"];
            //tb.BackColor = Color.AliceBlue;
            BindingSource bsRef = ((RitramaAPP.FrmProducts)formRef).bs;
            bsRef.Position = (bsRef.Position + 1);
            Label LABEL_CONTADOR_REGISTRO = (Label)formRef.Controls["LABEL_CONTADOR_REGISTRO"];
            LABEL_CONTADOR_REGISTRO.Text = "Registro: " + (bsRef.Position + 1) + " de " + bsRef.Count;
        }
        private void MOVE_DOCUMENTS_ANTERIOR_PRODUCTS()
        {
            Form formRef = (Form)panel1.Controls["FrmProducts"];
            BindingSource bsRef = ((RitramaAPP.FrmProducts)formRef).bs;
            bsRef.Position = (bsRef.Position - 1);
            Label LABEL_CONTADOR_REGISTRO = (Label)formRef.Controls["LABEL_CONTADOR_REGISTRO"];
            LABEL_CONTADOR_REGISTRO.Text = "Registro: " + (bsRef.Position + 1) + " de " + bsRef.Count;


        }
        private void MOVE_DOCUMENTS_LAST_PRODUCTS()
        {
            Form formRef = (Form)panel1.Controls["FrmProducts"];
            BindingSource bsRef = ((RitramaAPP.FrmProducts)formRef).bs;
            bsRef.Position = (bsRef.Count - 1);
            Label LABEL_CONTADOR_REGISTRO = (Label)formRef.Controls["LABEL_CONTADOR_REGISTRO"];
            LABEL_CONTADOR_REGISTRO.Text = "Registro: " + (bsRef.Position + 1) + " de " + bsRef.Count;
        }
       
        #endregion






    }
}
