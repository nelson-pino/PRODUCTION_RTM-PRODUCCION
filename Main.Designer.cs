namespace RitramaAPP
{
    partial class Main
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Recepciones");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Ordenes Corte");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Despacho");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Modulo de Inventarios");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Devoluciones");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Productos");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Customers");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Proveedores");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Parametros");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Listado de rollos cortados por Ubicacion");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Imprimir Conduce de Despacho");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Reporte", new System.Windows.Forms.TreeNode[] {
            treeNode10,
            treeNode11});
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.LABEL_VERSION = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.ImageIndex = 0;
            this.treeView1.ImageList = this.imageList1;
            this.treeView1.LabelEdit = true;
            this.treeView1.Location = new System.Drawing.Point(0, 103);
            this.treeView1.Margin = new System.Windows.Forms.Padding(2);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "Nodo0";
            treeNode1.Text = "Recepciones";
            treeNode2.Name = "Nodo2";
            treeNode2.Text = "Ordenes Corte";
            treeNode3.Name = "Nodo0";
            treeNode3.Text = "Despacho";
            treeNode4.Name = "Nodo3";
            treeNode4.Text = "Modulo de Inventarios";
            treeNode5.Name = "Nodo1";
            treeNode5.Text = "Devoluciones";
            treeNode6.Name = "Nodo4";
            treeNode6.Text = "Productos";
            treeNode7.Name = "Nodo5";
            treeNode7.Text = "Customers";
            treeNode8.Name = "Nodo6";
            treeNode8.Text = "Proveedores";
            treeNode9.Name = "Nodo1";
            treeNode9.Text = "Parametros";
            treeNode10.Name = "Nodo0";
            treeNode10.Text = "Listado de rollos cortados por Ubicacion";
            treeNode11.Name = "Nodo1";
            treeNode11.Text = "Imprimir Conduce de Despacho";
            treeNode12.Name = "Nodo2";
            treeNode12.Text = "Reporte";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5,
            treeNode6,
            treeNode7,
            treeNode8,
            treeNode9,
            treeNode12});
            this.treeView1.SelectedImageIndex = 0;
            this.treeView1.Size = new System.Drawing.Size(157, 640);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeView1_AfterSelect);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "box.png");
            this.imageList1.Images.SetKeyName(1, "order.png");
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(160, 2);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(916, 640);
            this.panel1.TabIndex = 3;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::RitramaAPP.Properties.Resources.logo;
            this.pictureBox1.Location = new System.Drawing.Point(0, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(157, 98);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // LABEL_VERSION
            // 
            this.LABEL_VERSION.AutoSize = true;
            this.LABEL_VERSION.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LABEL_VERSION.Location = new System.Drawing.Point(12, 622);
            this.LABEL_VERSION.Name = "LABEL_VERSION";
            this.LABEL_VERSION.Size = new System.Drawing.Size(41, 13);
            this.LABEL_VERSION.TabIndex = 5;
            this.LABEL_VERSION.Text = "label1";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1020, 715);
            this.Controls.Add(this.LABEL_VERSION);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.treeView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "APLICACION DE RITRAMA CONTROL DE INVENTARIOS";
            this.Load += new System.EventHandler(this.Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label LABEL_VERSION;
    }
}

