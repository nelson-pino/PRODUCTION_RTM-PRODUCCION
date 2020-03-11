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
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Materia Prima");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Pedidos Clientes");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("Ordenes Corte");
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("Despacho");
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("Modulo de Inventarios");
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("Productos");
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("Customers");
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("Proveedores");
            System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("Configuracion");
            System.Windows.Forms.TreeNode treeNode20 = new System.Windows.Forms.TreeNode("Reportes");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.BOT_PRIMERO = new System.Windows.Forms.ToolStripButton();
            this.BOT_ANTERIOR = new System.Windows.Forms.ToolStripButton();
            this.BOT_SIGUIENTE = new System.Windows.Forms.ToolStripButton();
            this.BOT_ULTIMO = new System.Windows.Forms.ToolStripButton();
            this.BOT_NUEVO_DOC = new System.Windows.Forms.ToolStripButton();
            this.BOT_CANCELAR_DOC = new System.Windows.Forms.ToolStripButton();
            this.BOT_GUARDAR_DOC = new System.Windows.Forms.ToolStripButton();
            this.BOT_MODIFY_DOC = new System.Windows.Forms.ToolStripButton();
            this.BOT_BROWSER_DATA = new System.Windows.Forms.ToolStripButton();
            this.BOT_PRINTER_LABEL = new System.Windows.Forms.ToolStripButton();
            this.BOT_SINCRO_DATA = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.BackColor = System.Drawing.Color.White;
            this.treeView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeView1.ImageIndex = 0;
            this.treeView1.ImageList = this.imageList1;
            this.treeView1.LabelEdit = true;
            this.treeView1.Location = new System.Drawing.Point(11, 80);
            this.treeView1.Margin = new System.Windows.Forms.Padding(2);
            this.treeView1.Name = "treeView1";
            treeNode11.Name = "Nodo0";
            treeNode11.Text = "Materia Prima";
            treeNode12.Name = "Nodo1";
            treeNode12.Text = "Pedidos Clientes";
            treeNode13.Name = "Nodo2";
            treeNode13.Text = "Ordenes Corte";
            treeNode14.Name = "Nodo0";
            treeNode14.Text = "Despacho";
            treeNode15.Name = "Nodo3";
            treeNode15.Text = "Modulo de Inventarios";
            treeNode16.Name = "Nodo4";
            treeNode16.Text = "Productos";
            treeNode17.Name = "Nodo5";
            treeNode17.Text = "Customers";
            treeNode18.Name = "Nodo6";
            treeNode18.Text = "Proveedores";
            treeNode19.Name = "Nodo1";
            treeNode19.Text = "Configuracion";
            treeNode20.Name = "Nodo2";
            treeNode20.Text = "Reportes";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode11,
            treeNode12,
            treeNode13,
            treeNode14,
            treeNode15,
            treeNode16,
            treeNode17,
            treeNode18,
            treeNode19,
            treeNode20});
            this.treeView1.SelectedImageIndex = 0;
            this.treeView1.Size = new System.Drawing.Size(190, 428);
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
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BOT_PRIMERO,
            this.BOT_ANTERIOR,
            this.BOT_SIGUIENTE,
            this.BOT_ULTIMO,
            this.BOT_NUEVO_DOC,
            this.BOT_CANCELAR_DOC,
            this.BOT_GUARDAR_DOC,
            this.BOT_MODIFY_DOC,
            this.BOT_BROWSER_DATA,
            this.BOT_PRINTER_LABEL,
            this.BOT_SINCRO_DATA});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(995, 78);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // BOT_PRIMERO
            // 
            this.BOT_PRIMERO.AutoSize = false;
            this.BOT_PRIMERO.Image = ((System.Drawing.Image)(resources.GetObject("BOT_PRIMERO.Image")));
            this.BOT_PRIMERO.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BOT_PRIMERO.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BOT_PRIMERO.Name = "BOT_PRIMERO";
            this.BOT_PRIMERO.Size = new System.Drawing.Size(60, 75);
            this.BOT_PRIMERO.Text = "Primero";
            this.BOT_PRIMERO.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BOT_PRIMERO.ToolTipText = "Ir al ultimo registro";
            this.BOT_PRIMERO.Click += new System.EventHandler(this.BOT_PRIMERO_Click);
            // 
            // BOT_ANTERIOR
            // 
            this.BOT_ANTERIOR.AutoSize = false;
            this.BOT_ANTERIOR.Image = ((System.Drawing.Image)(resources.GetObject("BOT_ANTERIOR.Image")));
            this.BOT_ANTERIOR.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BOT_ANTERIOR.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BOT_ANTERIOR.Name = "BOT_ANTERIOR";
            this.BOT_ANTERIOR.Size = new System.Drawing.Size(60, 75);
            this.BOT_ANTERIOR.Text = "Anterior";
            this.BOT_ANTERIOR.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BOT_ANTERIOR.ToolTipText = "Ir al anterior registro";
            this.BOT_ANTERIOR.Click += new System.EventHandler(this.BOT_ANTERIOR_Click);
            // 
            // BOT_SIGUIENTE
            // 
            this.BOT_SIGUIENTE.AutoSize = false;
            this.BOT_SIGUIENTE.Image = ((System.Drawing.Image)(resources.GetObject("BOT_SIGUIENTE.Image")));
            this.BOT_SIGUIENTE.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BOT_SIGUIENTE.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BOT_SIGUIENTE.Name = "BOT_SIGUIENTE";
            this.BOT_SIGUIENTE.Size = new System.Drawing.Size(60, 75);
            this.BOT_SIGUIENTE.Text = "Siguiente";
            this.BOT_SIGUIENTE.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BOT_SIGUIENTE.ToolTipText = "Ir al Siguiente registro";
            this.BOT_SIGUIENTE.Click += new System.EventHandler(this.BOT_SIGUIENTE_Click);
            // 
            // BOT_ULTIMO
            // 
            this.BOT_ULTIMO.AutoSize = false;
            this.BOT_ULTIMO.Image = ((System.Drawing.Image)(resources.GetObject("BOT_ULTIMO.Image")));
            this.BOT_ULTIMO.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BOT_ULTIMO.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BOT_ULTIMO.Name = "BOT_ULTIMO";
            this.BOT_ULTIMO.Size = new System.Drawing.Size(60, 75);
            this.BOT_ULTIMO.Text = "Ultimo";
            this.BOT_ULTIMO.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BOT_ULTIMO.ToolTipText = "Ir al ultimo registro";
            this.BOT_ULTIMO.Click += new System.EventHandler(this.BOT_ULTIMO_Click);
            // 
            // BOT_NUEVO_DOC
            // 
            this.BOT_NUEVO_DOC.AutoSize = false;
            this.BOT_NUEVO_DOC.Image = ((System.Drawing.Image)(resources.GetObject("BOT_NUEVO_DOC.Image")));
            this.BOT_NUEVO_DOC.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BOT_NUEVO_DOC.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BOT_NUEVO_DOC.Name = "BOT_NUEVO_DOC";
            this.BOT_NUEVO_DOC.Size = new System.Drawing.Size(60, 75);
            this.BOT_NUEVO_DOC.Text = "Nuevo";
            this.BOT_NUEVO_DOC.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BOT_NUEVO_DOC.ToolTipText = "Crear un nuevo documento";
            this.BOT_NUEVO_DOC.Click += new System.EventHandler(this.BOT_NUEVO_DOC_Click);
            // 
            // BOT_CANCELAR_DOC
            // 
            this.BOT_CANCELAR_DOC.AutoSize = false;
            this.BOT_CANCELAR_DOC.Enabled = false;
            this.BOT_CANCELAR_DOC.Image = ((System.Drawing.Image)(resources.GetObject("BOT_CANCELAR_DOC.Image")));
            this.BOT_CANCELAR_DOC.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BOT_CANCELAR_DOC.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BOT_CANCELAR_DOC.Name = "BOT_CANCELAR_DOC";
            this.BOT_CANCELAR_DOC.Size = new System.Drawing.Size(60, 75);
            this.BOT_CANCELAR_DOC.Text = "Cancelar";
            this.BOT_CANCELAR_DOC.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BOT_CANCELAR_DOC.ToolTipText = "Cancelar documento";
            // 
            // BOT_GUARDAR_DOC
            // 
            this.BOT_GUARDAR_DOC.AutoSize = false;
            this.BOT_GUARDAR_DOC.Enabled = false;
            this.BOT_GUARDAR_DOC.Image = ((System.Drawing.Image)(resources.GetObject("BOT_GUARDAR_DOC.Image")));
            this.BOT_GUARDAR_DOC.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BOT_GUARDAR_DOC.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BOT_GUARDAR_DOC.Name = "BOT_GUARDAR_DOC";
            this.BOT_GUARDAR_DOC.Size = new System.Drawing.Size(60, 75);
            this.BOT_GUARDAR_DOC.Text = "Guardar";
            this.BOT_GUARDAR_DOC.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BOT_GUARDAR_DOC.ToolTipText = "Guardar los datos del documento";
            // 
            // BOT_MODIFY_DOC
            // 
            this.BOT_MODIFY_DOC.AutoSize = false;
            this.BOT_MODIFY_DOC.Image = ((System.Drawing.Image)(resources.GetObject("BOT_MODIFY_DOC.Image")));
            this.BOT_MODIFY_DOC.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BOT_MODIFY_DOC.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BOT_MODIFY_DOC.Name = "BOT_MODIFY_DOC";
            this.BOT_MODIFY_DOC.Size = new System.Drawing.Size(60, 75);
            this.BOT_MODIFY_DOC.Text = "Modificar";
            this.BOT_MODIFY_DOC.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BOT_MODIFY_DOC.ToolTipText = "Modificar documentos";
            // 
            // BOT_BROWSER_DATA
            // 
            this.BOT_BROWSER_DATA.AutoSize = false;
            this.BOT_BROWSER_DATA.Image = ((System.Drawing.Image)(resources.GetObject("BOT_BROWSER_DATA.Image")));
            this.BOT_BROWSER_DATA.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BOT_BROWSER_DATA.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BOT_BROWSER_DATA.Name = "BOT_BROWSER_DATA";
            this.BOT_BROWSER_DATA.Size = new System.Drawing.Size(60, 75);
            this.BOT_BROWSER_DATA.Text = "Examinar";
            this.BOT_BROWSER_DATA.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BOT_BROWSER_DATA.ToolTipText = "Examinar datos de los documentos";
            // 
            // BOT_PRINTER_LABEL
            // 
            this.BOT_PRINTER_LABEL.AutoSize = false;
            this.BOT_PRINTER_LABEL.Image = ((System.Drawing.Image)(resources.GetObject("BOT_PRINTER_LABEL.Image")));
            this.BOT_PRINTER_LABEL.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BOT_PRINTER_LABEL.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BOT_PRINTER_LABEL.Name = "BOT_PRINTER_LABEL";
            this.BOT_PRINTER_LABEL.Size = new System.Drawing.Size(60, 75);
            this.BOT_PRINTER_LABEL.Text = "Label";
            this.BOT_PRINTER_LABEL.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BOT_PRINTER_LABEL.ToolTipText = "etiquetar los productos ";
            // 
            // BOT_SINCRO_DATA
            // 
            this.BOT_SINCRO_DATA.AutoSize = false;
            this.BOT_SINCRO_DATA.Image = ((System.Drawing.Image)(resources.GetObject("BOT_SINCRO_DATA.Image")));
            this.BOT_SINCRO_DATA.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BOT_SINCRO_DATA.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BOT_SINCRO_DATA.Name = "BOT_SINCRO_DATA";
            this.BOT_SINCRO_DATA.Size = new System.Drawing.Size(60, 75);
            this.BOT_SINCRO_DATA.Text = "Sincro";
            this.BOT_SINCRO_DATA.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BOT_SINCRO_DATA.ToolTipText = "Sincronizar data desde la aplicacion movil";
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(205, 80);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(779, 428);
            this.panel1.TabIndex = 3;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(995, 519);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.treeView1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistema de Picking y Packing [Etiquetas.com]";
            this.Load += new System.EventHandler(this.Main_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton BOT_PRIMERO;
        private System.Windows.Forms.ToolStripButton BOT_ANTERIOR;
        private System.Windows.Forms.ToolStripButton BOT_SIGUIENTE;
        private System.Windows.Forms.ToolStripButton BOT_ULTIMO;
        private System.Windows.Forms.ToolStripButton BOT_SINCRO_DATA;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolStripButton BOT_NUEVO_DOC;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripButton BOT_GUARDAR_DOC;
        private System.Windows.Forms.ToolStripButton BOT_MODIFY_DOC;
        private System.Windows.Forms.ToolStripButton BOT_CANCELAR_DOC;
        private System.Windows.Forms.ToolStripButton BOT_PRINTER_LABEL;
        private System.Windows.Forms.ToolStripButton BOT_BROWSER_DATA;
    }
}

