namespace RitramaAPP.form
{
    partial class FrmDevol
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDevol));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label15 = new System.Windows.Forms.Label();
            this.toolsbar = new System.Windows.Forms.ToolStrip();
            this.bot_primero = new System.Windows.Forms.ToolStripButton();
            this.bot_anterior = new System.Windows.Forms.ToolStripButton();
            this.bot_siguiente = new System.Windows.Forms.ToolStripButton();
            this.bot_ultimo = new System.Windows.Forms.ToolStripButton();
            this.bot_nuevo = new System.Windows.Forms.ToolStripButton();
            this.bot_cancelar = new System.Windows.Forms.ToolStripButton();
            this.bot_grabar = new System.Windows.Forms.ToolStripButton();
            this.label1 = new System.Windows.Forms.Label();
            this.TXT_NUMERO = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TXT_FECHA = new System.Windows.Forms.DateTimePicker();
            this.TXT_RAZON_DEVOL = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TXT_IDCUST = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_search = new System.Windows.Forms.Button();
            this.TXT_CUSTOMER_NAME = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.GridDevol = new System.Windows.Forms.DataGridView();
            this.RA_DOCUMENT_STATUS = new System.Windows.Forms.RadioButton();
            this.BTN_AGREGAR_RENGLON = new System.Windows.Forms.Button();
            this.BTN_DELETE_RENGLON = new System.Windows.Forms.Button();
            this.REGISTER_COUNT = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.toolsbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridDevol)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label15);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(862, 82);
            this.panel1.TabIndex = 34;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(266, 26);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(231, 31);
            this.label15.TabIndex = 0;
            this.label15.Text = "DEVOLUCIONES";
            // 
            // toolsbar
            // 
            this.toolsbar.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolsbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bot_primero,
            this.bot_anterior,
            this.bot_siguiente,
            this.bot_ultimo,
            this.bot_nuevo,
            this.bot_cancelar,
            this.bot_grabar});
            this.toolsbar.Location = new System.Drawing.Point(0, 82);
            this.toolsbar.Name = "toolsbar";
            this.toolsbar.Size = new System.Drawing.Size(862, 27);
            this.toolsbar.TabIndex = 36;
            this.toolsbar.Text = "toolStrip1";
            // 
            // bot_primero
            // 
            this.bot_primero.AutoSize = false;
            this.bot_primero.Image = ((System.Drawing.Image)(resources.GetObject("bot_primero.Image")));
            this.bot_primero.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bot_primero.Name = "bot_primero";
            this.bot_primero.Size = new System.Drawing.Size(80, 24);
            this.bot_primero.Text = "Primero";
            this.bot_primero.Click += new System.EventHandler(this.Bot_primero_Click);
            // 
            // bot_anterior
            // 
            this.bot_anterior.AutoSize = false;
            this.bot_anterior.Image = ((System.Drawing.Image)(resources.GetObject("bot_anterior.Image")));
            this.bot_anterior.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bot_anterior.Name = "bot_anterior";
            this.bot_anterior.Size = new System.Drawing.Size(80, 24);
            this.bot_anterior.Text = "Anterior";
            this.bot_anterior.Click += new System.EventHandler(this.Bot_anterior_Click);
            // 
            // bot_siguiente
            // 
            this.bot_siguiente.AutoSize = false;
            this.bot_siguiente.Image = ((System.Drawing.Image)(resources.GetObject("bot_siguiente.Image")));
            this.bot_siguiente.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bot_siguiente.Name = "bot_siguiente";
            this.bot_siguiente.Size = new System.Drawing.Size(80, 24);
            this.bot_siguiente.Text = "Siguie";
            this.bot_siguiente.Click += new System.EventHandler(this.Bot_siguiente_Click);
            // 
            // bot_ultimo
            // 
            this.bot_ultimo.AutoSize = false;
            this.bot_ultimo.Image = ((System.Drawing.Image)(resources.GetObject("bot_ultimo.Image")));
            this.bot_ultimo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bot_ultimo.Name = "bot_ultimo";
            this.bot_ultimo.Size = new System.Drawing.Size(80, 24);
            this.bot_ultimo.Text = "Ultim";
            this.bot_ultimo.Click += new System.EventHandler(this.Bot_ultimo_Click);
            // 
            // bot_nuevo
            // 
            this.bot_nuevo.AutoSize = false;
            this.bot_nuevo.Image = ((System.Drawing.Image)(resources.GetObject("bot_nuevo.Image")));
            this.bot_nuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bot_nuevo.Name = "bot_nuevo";
            this.bot_nuevo.Size = new System.Drawing.Size(80, 24);
            this.bot_nuevo.Text = "Nuevo";
            this.bot_nuevo.Click += new System.EventHandler(this.Bot_nuevo_Click);
            // 
            // bot_cancelar
            // 
            this.bot_cancelar.AutoSize = false;
            this.bot_cancelar.Enabled = false;
            this.bot_cancelar.Image = ((System.Drawing.Image)(resources.GetObject("bot_cancelar.Image")));
            this.bot_cancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bot_cancelar.Name = "bot_cancelar";
            this.bot_cancelar.Size = new System.Drawing.Size(80, 24);
            this.bot_cancelar.Text = "Cancel";
            this.bot_cancelar.Click += new System.EventHandler(this.Bot_cancelar_Click);
            // 
            // bot_grabar
            // 
            this.bot_grabar.AutoSize = false;
            this.bot_grabar.Enabled = false;
            this.bot_grabar.Image = ((System.Drawing.Image)(resources.GetObject("bot_grabar.Image")));
            this.bot_grabar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bot_grabar.Name = "bot_grabar";
            this.bot_grabar.Size = new System.Drawing.Size(80, 24);
            this.bot_grabar.Text = "Grabar";
            this.bot_grabar.Click += new System.EventHandler(this.Bot_grabar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 37;
            this.label1.Text = "Numero Doc:";
            // 
            // TXT_NUMERO
            // 
            this.TXT_NUMERO.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXT_NUMERO.Location = new System.Drawing.Point(80, 32);
            this.TXT_NUMERO.Name = "TXT_NUMERO";
            this.TXT_NUMERO.ReadOnly = true;
            this.TXT_NUMERO.Size = new System.Drawing.Size(100, 20);
            this.TXT_NUMERO.TabIndex = 39;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(198, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 40;
            this.label2.Text = "Fecha Registro :";
            // 
            // TXT_FECHA
            // 
            this.TXT_FECHA.Enabled = false;
            this.TXT_FECHA.Location = new System.Drawing.Point(359, 32);
            this.TXT_FECHA.Name = "TXT_FECHA";
            this.TXT_FECHA.Size = new System.Drawing.Size(200, 20);
            this.TXT_FECHA.TabIndex = 41;
            // 
            // TXT_RAZON_DEVOL
            // 
            this.TXT_RAZON_DEVOL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXT_RAZON_DEVOL.Location = new System.Drawing.Point(80, 84);
            this.TXT_RAZON_DEVOL.Name = "TXT_RAZON_DEVOL";
            this.TXT_RAZON_DEVOL.ReadOnly = true;
            this.TXT_RAZON_DEVOL.Size = new System.Drawing.Size(479, 20);
            this.TXT_RAZON_DEVOL.TabIndex = 43;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 42;
            this.label3.Text = "Razon :";
            // 
            // TXT_IDCUST
            // 
            this.TXT_IDCUST.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXT_IDCUST.Location = new System.Drawing.Point(80, 58);
            this.TXT_IDCUST.Name = "TXT_IDCUST";
            this.TXT_IDCUST.ReadOnly = true;
            this.TXT_IDCUST.Size = new System.Drawing.Size(57, 20);
            this.TXT_IDCUST.TabIndex = 45;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 44;
            this.label4.Text = "Id Cust :";
            // 
            // btn_search
            // 
            this.btn_search.Enabled = false;
            this.btn_search.Location = new System.Drawing.Point(143, 58);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(37, 23);
            this.btn_search.TabIndex = 46;
            this.btn_search.Text = "...";
            this.btn_search.UseVisualStyleBackColor = true;
            this.btn_search.Click += new System.EventHandler(this.Btn_search_Click);
            // 
            // TXT_CUSTOMER_NAME
            // 
            this.TXT_CUSTOMER_NAME.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXT_CUSTOMER_NAME.Location = new System.Drawing.Point(249, 58);
            this.TXT_CUSTOMER_NAME.Name = "TXT_CUSTOMER_NAME";
            this.TXT_CUSTOMER_NAME.ReadOnly = true;
            this.TXT_CUSTOMER_NAME.Size = new System.Drawing.Size(310, 20);
            this.TXT_CUSTOMER_NAME.TabIndex = 47;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(198, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 48;
            this.label5.Text = "Cliente :";
            // 
            // GridDevol
            // 
            this.GridDevol.AllowUserToAddRows = false;
            this.GridDevol.AllowUserToDeleteRows = false;
            this.GridDevol.AllowUserToResizeRows = false;
            this.GridDevol.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridDevol.Location = new System.Drawing.Point(9, 267);
            this.GridDevol.Name = "GridDevol";
            this.GridDevol.ReadOnly = true;
            this.GridDevol.RowHeadersWidth = 35;
            this.GridDevol.Size = new System.Drawing.Size(724, 192);
            this.GridDevol.TabIndex = 49;
            this.GridDevol.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridDevol_CellContentClick);
            this.GridDevol.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridDevol_CellEndEdit);
            // 
            // RA_DOCUMENT_STATUS
            // 
            this.RA_DOCUMENT_STATUS.AutoSize = true;
            this.RA_DOCUMENT_STATUS.Enabled = false;
            this.RA_DOCUMENT_STATUS.Location = new System.Drawing.Point(16, 461);
            this.RA_DOCUMENT_STATUS.Name = "RA_DOCUMENT_STATUS";
            this.RA_DOCUMENT_STATUS.Size = new System.Drawing.Size(122, 17);
            this.RA_DOCUMENT_STATUS.TabIndex = 50;
            this.RA_DOCUMENT_STATUS.TabStop = true;
            this.RA_DOCUMENT_STATUS.Text = "Documento Anulado";
            this.RA_DOCUMENT_STATUS.UseVisualStyleBackColor = true;
            // 
            // BTN_AGREGAR_RENGLON
            // 
            this.BTN_AGREGAR_RENGLON.Enabled = false;
            this.BTN_AGREGAR_RENGLON.Image = ((System.Drawing.Image)(resources.GetObject("BTN_AGREGAR_RENGLON.Image")));
            this.BTN_AGREGAR_RENGLON.Location = new System.Drawing.Point(739, 267);
            this.BTN_AGREGAR_RENGLON.Name = "BTN_AGREGAR_RENGLON";
            this.BTN_AGREGAR_RENGLON.Size = new System.Drawing.Size(111, 60);
            this.BTN_AGREGAR_RENGLON.TabIndex = 51;
            this.BTN_AGREGAR_RENGLON.Text = "Agregar ";
            this.BTN_AGREGAR_RENGLON.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BTN_AGREGAR_RENGLON.UseVisualStyleBackColor = true;
            this.BTN_AGREGAR_RENGLON.Click += new System.EventHandler(this.AGREGAR_RENGLON_Click);
            // 
            // BTN_DELETE_RENGLON
            // 
            this.BTN_DELETE_RENGLON.Enabled = false;
            this.BTN_DELETE_RENGLON.Image = ((System.Drawing.Image)(resources.GetObject("BTN_DELETE_RENGLON.Image")));
            this.BTN_DELETE_RENGLON.Location = new System.Drawing.Point(739, 333);
            this.BTN_DELETE_RENGLON.Name = "BTN_DELETE_RENGLON";
            this.BTN_DELETE_RENGLON.Size = new System.Drawing.Size(111, 60);
            this.BTN_DELETE_RENGLON.TabIndex = 52;
            this.BTN_DELETE_RENGLON.Text = "Eliminar";
            this.BTN_DELETE_RENGLON.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BTN_DELETE_RENGLON.UseVisualStyleBackColor = true;
            this.BTN_DELETE_RENGLON.Click += new System.EventHandler(this.BTN_DELETE_RENGLON_Click);
            // 
            // REGISTER_COUNT
            // 
            this.REGISTER_COUNT.AutoSize = true;
            this.REGISTER_COUNT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.REGISTER_COUNT.Location = new System.Drawing.Point(463, 465);
            this.REGISTER_COUNT.Name = "REGISTER_COUNT";
            this.REGISTER_COUNT.Size = new System.Drawing.Size(114, 13);
            this.REGISTER_COUNT.TabIndex = 53;
            this.REGISTER_COUNT.Text = "REGISTRO 0 DE 0";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TXT_FECHA);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.TXT_NUMERO);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.TXT_RAZON_DEVOL);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.TXT_CUSTOMER_NAME);
            this.groupBox1.Controls.Add(this.TXT_IDCUST);
            this.groupBox1.Controls.Add(this.btn_search);
            this.groupBox1.Location = new System.Drawing.Point(9, 112);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(568, 137);
            this.groupBox1.TabIndex = 54;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Encabezado de la Devolución";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(13, 252);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(133, 13);
            this.label6.TabIndex = 55;
            this.label6.Text = "Detalle de Devolución";
            // 
            // FrmDevol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(862, 510);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.REGISTER_COUNT);
            this.Controls.Add(this.BTN_DELETE_RENGLON);
            this.Controls.Add(this.BTN_AGREGAR_RENGLON);
            this.Controls.Add(this.RA_DOCUMENT_STATUS);
            this.Controls.Add(this.GridDevol);
            this.Controls.Add(this.toolsbar);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmDevol";
            this.Text = "FrmDevol";
            this.Load += new System.EventHandler(this.FrmDevol_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolsbar.ResumeLayout(false);
            this.toolsbar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridDevol)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ToolStrip toolsbar;
        private System.Windows.Forms.ToolStripButton bot_primero;
        private System.Windows.Forms.ToolStripButton bot_anterior;
        private System.Windows.Forms.ToolStripButton bot_siguiente;
        private System.Windows.Forms.ToolStripButton bot_ultimo;
        private System.Windows.Forms.ToolStripButton bot_nuevo;
        private System.Windows.Forms.ToolStripButton bot_cancelar;
        private System.Windows.Forms.ToolStripButton bot_grabar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TXT_NUMERO;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker TXT_FECHA;
        private System.Windows.Forms.TextBox TXT_RAZON_DEVOL;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TXT_IDCUST;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.TextBox TXT_CUSTOMER_NAME;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView GridDevol;
        private System.Windows.Forms.RadioButton RA_DOCUMENT_STATUS;
        private System.Windows.Forms.Button BTN_AGREGAR_RENGLON;
        private System.Windows.Forms.Button BTN_DELETE_RENGLON;
        private System.Windows.Forms.Label REGISTER_COUNT;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
    }
}