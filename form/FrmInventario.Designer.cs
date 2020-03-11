namespace RitramaAPP
{
    partial class FrmInventario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmInventario));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label15 = new System.Windows.Forms.Label();
            this.TABINVENTARIO = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.bot_cargar = new System.Windows.Forms.Button();
            this.FOUND_COUNTER = new System.Windows.Forms.Label();
            this.TXT_RECORDS = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.filter = new System.Windows.Forms.GroupBox();
            this.RA_ROLLID = new System.Windows.Forms.RadioButton();
            this.RA_PRODUCTNAME = new System.Windows.Forms.RadioButton();
            this.RA_PRODUCTID = new System.Windows.Forms.RadioButton();
            this.bot_buscar = new System.Windows.Forms.Button();
            this.txt_buscar = new System.Windows.Forms.TextBox();
            this.GridItemsMaster = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.FOUND_HOJAS = new System.Windows.Forms.Label();
            this.TXT_RECORDNUMBER_HOJ = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.RAROLLID_HOJ = new System.Windows.Forms.RadioButton();
            this.RAPRODUCTNAME_HOJ = new System.Windows.Forms.RadioButton();
            this.RACODIGO_HOJ = new System.Windows.Forms.RadioButton();
            this.GridItemHojas = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.botcarga_hoj = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.botbuscar_hoj = new System.Windows.Forms.Button();
            this.txtbuscar_hoj = new System.Windows.Forms.TextBox();
            this.TAB_GRAPHICS = new System.Windows.Forms.TabPage();
            this.RECORD_FOUND_GRA = new System.Windows.Forms.Label();
            this.TXTRECORD_GRA = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.RA_ROLLID_GRA = new System.Windows.Forms.RadioButton();
            this.RA_PRODUCTNAME_GRA = new System.Windows.Forms.RadioButton();
            this.RA_PRODUCTID_GRA = new System.Windows.Forms.RadioButton();
            this.GridItemGraphics = new System.Windows.Forms.DataGridView();
            this.label11 = new System.Windows.Forms.Label();
            this.botcargar_gra = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.botbuscar_gra = new System.Windows.Forms.Button();
            this.txtbuscar_gra = new System.Windows.Forms.TextBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.RECORDFOUND_COR = new System.Windows.Forms.Label();
            this.TXTRECORDNUMBER_COR = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.RA_UNIQUE_CODE_COR = new System.Windows.Forms.RadioButton();
            this.RA_ROLLID_COR = new System.Windows.Forms.RadioButton();
            this.RA_PRODUCTNAME_COR = new System.Windows.Forms.RadioButton();
            this.RA_PRODUCTID_COR = new System.Windows.Forms.RadioButton();
            this.GridItemsCortados = new System.Windows.Forms.DataGridView();
            this.label14 = new System.Windows.Forms.Label();
            this.bot_cargar_cor = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.bot_buscar_cor = new System.Windows.Forms.Button();
            this.txtbuscar_cor = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.TABINVENTARIO.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.filter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridItemsMaster)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridItemHojas)).BeginInit();
            this.TAB_GRAPHICS.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridItemGraphics)).BeginInit();
            this.tabPage4.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridItemsCortados)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label15);
            this.panel1.Location = new System.Drawing.Point(9, 10);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(846, 98);
            this.panel1.TabIndex = 36;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(268, 35);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(278, 25);
            this.label15.TabIndex = 0;
            this.label15.Text = "MODULO DE INVENTARIO";
            // 
            // TABINVENTARIO
            // 
            this.TABINVENTARIO.Controls.Add(this.tabPage1);
            this.TABINVENTARIO.Controls.Add(this.tabPage3);
            this.TABINVENTARIO.Controls.Add(this.TAB_GRAPHICS);
            this.TABINVENTARIO.Controls.Add(this.tabPage4);
            this.TABINVENTARIO.Location = new System.Drawing.Point(9, 113);
            this.TABINVENTARIO.Name = "TABINVENTARIO";
            this.TABINVENTARIO.SelectedIndex = 0;
            this.TABINVENTARIO.Size = new System.Drawing.Size(846, 795);
            this.TABINVENTARIO.TabIndex = 37;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.bot_cargar);
            this.tabPage1.Controls.Add(this.FOUND_COUNTER);
            this.tabPage1.Controls.Add(this.TXT_RECORDS);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.filter);
            this.tabPage1.Controls.Add(this.bot_buscar);
            this.tabPage1.Controls.Add(this.txt_buscar);
            this.tabPage1.Controls.Add(this.GridItemsMaster);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(838, 769);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "MASTERS";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // bot_cargar
            // 
            this.bot_cargar.Image = ((System.Drawing.Image)(resources.GetObject("bot_cargar.Image")));
            this.bot_cargar.Location = new System.Drawing.Point(376, 7);
            this.bot_cargar.Name = "bot_cargar";
            this.bot_cargar.Size = new System.Drawing.Size(100, 42);
            this.bot_cargar.TabIndex = 8;
            this.bot_cargar.Text = "Cargar";
            this.bot_cargar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bot_cargar.UseVisualStyleBackColor = true;
            this.bot_cargar.Click += new System.EventHandler(this.Bot_cargar_Click);
            // 
            // FOUND_COUNTER
            // 
            this.FOUND_COUNTER.AutoSize = true;
            this.FOUND_COUNTER.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FOUND_COUNTER.Location = new System.Drawing.Point(650, 429);
            this.FOUND_COUNTER.Name = "FOUND_COUNTER";
            this.FOUND_COUNTER.Size = new System.Drawing.Size(188, 13);
            this.FOUND_COUNTER.TabIndex = 7;
            this.FOUND_COUNTER.Text = "0 REGISTROS ENCONTRADOS";
            // 
            // TXT_RECORDS
            // 
            this.TXT_RECORDS.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXT_RECORDS.Location = new System.Drawing.Point(333, 445);
            this.TXT_RECORDS.Name = "TXT_RECORDS";
            this.TXT_RECORDS.Size = new System.Drawing.Size(100, 20);
            this.TXT_RECORDS.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(215, 448);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Numero de Registros :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(512, 13);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(273, 25);
            this.label3.TabIndex = 1;
            this.label3.Text = "Inventario de Rolls Masters";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(258, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Introduzca palabras claves para realizar la busqueda.";
            // 
            // filter
            // 
            this.filter.Controls.Add(this.RA_ROLLID);
            this.filter.Controls.Add(this.RA_PRODUCTNAME);
            this.filter.Controls.Add(this.RA_PRODUCTID);
            this.filter.Location = new System.Drawing.Point(9, 428);
            this.filter.Name = "filter";
            this.filter.Size = new System.Drawing.Size(200, 92);
            this.filter.TabIndex = 3;
            this.filter.TabStop = false;
            this.filter.Text = "Filtros de Busquedas";
            // 
            // RA_ROLLID
            // 
            this.RA_ROLLID.AutoSize = true;
            this.RA_ROLLID.Location = new System.Drawing.Point(19, 66);
            this.RA_ROLLID.Name = "RA_ROLLID";
            this.RA_ROLLID.Size = new System.Drawing.Size(97, 17);
            this.RA_ROLLID.TabIndex = 2;
            this.RA_ROLLID.Text = "Numero Roll-ID";
            this.RA_ROLLID.UseVisualStyleBackColor = true;
            // 
            // RA_PRODUCTNAME
            // 
            this.RA_PRODUCTNAME.AutoSize = true;
            this.RA_PRODUCTNAME.Location = new System.Drawing.Point(19, 43);
            this.RA_PRODUCTNAME.Name = "RA_PRODUCTNAME";
            this.RA_PRODUCTNAME.Size = new System.Drawing.Size(125, 17);
            this.RA_PRODUCTNAME.TabIndex = 1;
            this.RA_PRODUCTNAME.Text = "Nombre del Producto";
            this.RA_PRODUCTNAME.UseVisualStyleBackColor = true;
            // 
            // RA_PRODUCTID
            // 
            this.RA_PRODUCTID.AutoSize = true;
            this.RA_PRODUCTID.Checked = true;
            this.RA_PRODUCTID.Location = new System.Drawing.Point(19, 20);
            this.RA_PRODUCTID.Name = "RA_PRODUCTID";
            this.RA_PRODUCTID.Size = new System.Drawing.Size(104, 17);
            this.RA_PRODUCTID.TabIndex = 0;
            this.RA_PRODUCTID.TabStop = true;
            this.RA_PRODUCTID.Text = "Codigo Producto";
            this.RA_PRODUCTID.UseVisualStyleBackColor = true;
            // 
            // bot_buscar
            // 
            this.bot_buscar.Image = ((System.Drawing.Image)(resources.GetObject("bot_buscar.Image")));
            this.bot_buscar.Location = new System.Drawing.Point(270, 6);
            this.bot_buscar.Name = "bot_buscar";
            this.bot_buscar.Size = new System.Drawing.Size(100, 42);
            this.bot_buscar.TabIndex = 2;
            this.bot_buscar.Text = "Buscar";
            this.bot_buscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bot_buscar.UseVisualStyleBackColor = true;
            this.bot_buscar.Click += new System.EventHandler(this.Bot_buscar_Click);
            // 
            // txt_buscar
            // 
            this.txt_buscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_buscar.Location = new System.Drawing.Point(3, 19);
            this.txt_buscar.Name = "txt_buscar";
            this.txt_buscar.Size = new System.Drawing.Size(261, 20);
            this.txt_buscar.TabIndex = 1;
            this.txt_buscar.TextChanged += new System.EventHandler(this.Txt_buscar_TextChanged_1);
            // 
            // GridItemsMaster
            // 
            this.GridItemsMaster.AllowUserToAddRows = false;
            this.GridItemsMaster.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridItemsMaster.Location = new System.Drawing.Point(6, 50);
            this.GridItemsMaster.Name = "GridItemsMaster";
            this.GridItemsMaster.ReadOnly = true;
            this.GridItemsMaster.Size = new System.Drawing.Size(826, 376);
            this.GridItemsMaster.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.FOUND_HOJAS);
            this.tabPage3.Controls.Add(this.TXT_RECORDNUMBER_HOJ);
            this.tabPage3.Controls.Add(this.label8);
            this.tabPage3.Controls.Add(this.groupBox1);
            this.tabPage3.Controls.Add(this.GridItemHojas);
            this.tabPage3.Controls.Add(this.label7);
            this.tabPage3.Controls.Add(this.botcarga_hoj);
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Controls.Add(this.botbuscar_hoj);
            this.tabPage3.Controls.Add(this.txtbuscar_hoj);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(838, 769);
            this.tabPage3.TabIndex = 3;
            this.tabPage3.Text = "HOJAS";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // FOUND_HOJAS
            // 
            this.FOUND_HOJAS.AutoSize = true;
            this.FOUND_HOJAS.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FOUND_HOJAS.Location = new System.Drawing.Point(641, 431);
            this.FOUND_HOJAS.Name = "FOUND_HOJAS";
            this.FOUND_HOJAS.Size = new System.Drawing.Size(188, 13);
            this.FOUND_HOJAS.TabIndex = 18;
            this.FOUND_HOJAS.Text = "0 REGISTROS ENCONTRADOS";
            // 
            // TXT_RECORDNUMBER_HOJ
            // 
            this.TXT_RECORDNUMBER_HOJ.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXT_RECORDNUMBER_HOJ.Location = new System.Drawing.Point(339, 454);
            this.TXT_RECORDNUMBER_HOJ.Name = "TXT_RECORDNUMBER_HOJ";
            this.TXT_RECORDNUMBER_HOJ.Size = new System.Drawing.Size(100, 20);
            this.TXT_RECORDNUMBER_HOJ.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(221, 457);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(112, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Numero de Registros :";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.RAROLLID_HOJ);
            this.groupBox1.Controls.Add(this.RAPRODUCTNAME_HOJ);
            this.groupBox1.Controls.Add(this.RACODIGO_HOJ);
            this.groupBox1.Location = new System.Drawing.Point(6, 433);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 92);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros de Busquedas";
            // 
            // RAROLLID_HOJ
            // 
            this.RAROLLID_HOJ.AutoSize = true;
            this.RAROLLID_HOJ.Location = new System.Drawing.Point(19, 66);
            this.RAROLLID_HOJ.Name = "RAROLLID_HOJ";
            this.RAROLLID_HOJ.Size = new System.Drawing.Size(97, 17);
            this.RAROLLID_HOJ.TabIndex = 2;
            this.RAROLLID_HOJ.Text = "Numero Roll-ID";
            this.RAROLLID_HOJ.UseVisualStyleBackColor = true;
            // 
            // RAPRODUCTNAME_HOJ
            // 
            this.RAPRODUCTNAME_HOJ.AutoSize = true;
            this.RAPRODUCTNAME_HOJ.Location = new System.Drawing.Point(19, 43);
            this.RAPRODUCTNAME_HOJ.Name = "RAPRODUCTNAME_HOJ";
            this.RAPRODUCTNAME_HOJ.Size = new System.Drawing.Size(125, 17);
            this.RAPRODUCTNAME_HOJ.TabIndex = 1;
            this.RAPRODUCTNAME_HOJ.Text = "Nombre del Producto";
            this.RAPRODUCTNAME_HOJ.UseVisualStyleBackColor = true;
            // 
            // RACODIGO_HOJ
            // 
            this.RACODIGO_HOJ.AutoSize = true;
            this.RACODIGO_HOJ.Checked = true;
            this.RACODIGO_HOJ.Location = new System.Drawing.Point(19, 20);
            this.RACODIGO_HOJ.Name = "RACODIGO_HOJ";
            this.RACODIGO_HOJ.Size = new System.Drawing.Size(104, 17);
            this.RACODIGO_HOJ.TabIndex = 0;
            this.RACODIGO_HOJ.TabStop = true;
            this.RACODIGO_HOJ.Text = "Codigo Producto";
            this.RACODIGO_HOJ.UseVisualStyleBackColor = true;
            // 
            // GridItemHojas
            // 
            this.GridItemHojas.AllowUserToAddRows = false;
            this.GridItemHojas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridItemHojas.Location = new System.Drawing.Point(3, 52);
            this.GridItemHojas.Name = "GridItemHojas";
            this.GridItemHojas.ReadOnly = true;
            this.GridItemHojas.Size = new System.Drawing.Size(826, 376);
            this.GridItemHojas.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(583, 14);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(198, 25);
            this.label7.TabIndex = 13;
            this.label7.Text = "Inventario de Hojas";
            // 
            // botcarga_hoj
            // 
            this.botcarga_hoj.Image = ((System.Drawing.Image)(resources.GetObject("botcarga_hoj.Image")));
            this.botcarga_hoj.Location = new System.Drawing.Point(376, 7);
            this.botcarga_hoj.Name = "botcarga_hoj";
            this.botcarga_hoj.Size = new System.Drawing.Size(100, 42);
            this.botcarga_hoj.TabIndex = 12;
            this.botcarga_hoj.Text = "Cargar";
            this.botcarga_hoj.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.botcarga_hoj.UseVisualStyleBackColor = true;
            this.botcarga_hoj.Click += new System.EventHandler(this.Botcarga_hoj_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(258, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Introduzca palabras claves para realizar la busqueda.";
            // 
            // botbuscar_hoj
            // 
            this.botbuscar_hoj.Image = ((System.Drawing.Image)(resources.GetObject("botbuscar_hoj.Image")));
            this.botbuscar_hoj.Location = new System.Drawing.Point(270, 6);
            this.botbuscar_hoj.Name = "botbuscar_hoj";
            this.botbuscar_hoj.Size = new System.Drawing.Size(100, 42);
            this.botbuscar_hoj.TabIndex = 10;
            this.botbuscar_hoj.Text = "Buscar";
            this.botbuscar_hoj.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.botbuscar_hoj.UseVisualStyleBackColor = true;
            this.botbuscar_hoj.Click += new System.EventHandler(this.Botbuscar_hoj_Click);
            // 
            // txtbuscar_hoj
            // 
            this.txtbuscar_hoj.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbuscar_hoj.Location = new System.Drawing.Point(3, 19);
            this.txtbuscar_hoj.Name = "txtbuscar_hoj";
            this.txtbuscar_hoj.Size = new System.Drawing.Size(261, 20);
            this.txtbuscar_hoj.TabIndex = 9;
            this.txtbuscar_hoj.TextChanged += new System.EventHandler(this.Txtbuscar_hoj_TextChanged);
            // 
            // TAB_GRAPHICS
            // 
            this.TAB_GRAPHICS.Controls.Add(this.RECORD_FOUND_GRA);
            this.TAB_GRAPHICS.Controls.Add(this.TXTRECORD_GRA);
            this.TAB_GRAPHICS.Controls.Add(this.label10);
            this.TAB_GRAPHICS.Controls.Add(this.groupBox3);
            this.TAB_GRAPHICS.Controls.Add(this.GridItemGraphics);
            this.TAB_GRAPHICS.Controls.Add(this.label11);
            this.TAB_GRAPHICS.Controls.Add(this.botcargar_gra);
            this.TAB_GRAPHICS.Controls.Add(this.label12);
            this.TAB_GRAPHICS.Controls.Add(this.botbuscar_gra);
            this.TAB_GRAPHICS.Controls.Add(this.txtbuscar_gra);
            this.TAB_GRAPHICS.Location = new System.Drawing.Point(4, 22);
            this.TAB_GRAPHICS.Name = "TAB_GRAPHICS";
            this.TAB_GRAPHICS.Padding = new System.Windows.Forms.Padding(3);
            this.TAB_GRAPHICS.Size = new System.Drawing.Size(838, 769);
            this.TAB_GRAPHICS.TabIndex = 4;
            this.TAB_GRAPHICS.Text = "GRAPHICS";
            this.TAB_GRAPHICS.UseVisualStyleBackColor = true;
            // 
            // RECORD_FOUND_GRA
            // 
            this.RECORD_FOUND_GRA.AutoSize = true;
            this.RECORD_FOUND_GRA.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RECORD_FOUND_GRA.Location = new System.Drawing.Point(641, 431);
            this.RECORD_FOUND_GRA.Name = "RECORD_FOUND_GRA";
            this.RECORD_FOUND_GRA.Size = new System.Drawing.Size(188, 13);
            this.RECORD_FOUND_GRA.TabIndex = 18;
            this.RECORD_FOUND_GRA.Text = "0 REGISTROS ENCONTRADOS";
            // 
            // TXTRECORD_GRA
            // 
            this.TXTRECORD_GRA.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXTRECORD_GRA.Location = new System.Drawing.Point(339, 454);
            this.TXTRECORD_GRA.Name = "TXTRECORD_GRA";
            this.TXTRECORD_GRA.Size = new System.Drawing.Size(100, 20);
            this.TXTRECORD_GRA.TabIndex = 17;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(221, 457);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(112, 13);
            this.label10.TabIndex = 16;
            this.label10.Text = "Numero de Registros :";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.RA_ROLLID_GRA);
            this.groupBox3.Controls.Add(this.RA_PRODUCTNAME_GRA);
            this.groupBox3.Controls.Add(this.RA_PRODUCTID_GRA);
            this.groupBox3.Location = new System.Drawing.Point(6, 433);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 92);
            this.groupBox3.TabIndex = 15;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Filtros de Busquedas";
            // 
            // RA_ROLLID_GRA
            // 
            this.RA_ROLLID_GRA.AutoSize = true;
            this.RA_ROLLID_GRA.Location = new System.Drawing.Point(19, 66);
            this.RA_ROLLID_GRA.Name = "RA_ROLLID_GRA";
            this.RA_ROLLID_GRA.Size = new System.Drawing.Size(97, 17);
            this.RA_ROLLID_GRA.TabIndex = 2;
            this.RA_ROLLID_GRA.Text = "Numero Roll-ID";
            this.RA_ROLLID_GRA.UseVisualStyleBackColor = true;
            // 
            // RA_PRODUCTNAME_GRA
            // 
            this.RA_PRODUCTNAME_GRA.AutoSize = true;
            this.RA_PRODUCTNAME_GRA.Location = new System.Drawing.Point(19, 43);
            this.RA_PRODUCTNAME_GRA.Name = "RA_PRODUCTNAME_GRA";
            this.RA_PRODUCTNAME_GRA.Size = new System.Drawing.Size(125, 17);
            this.RA_PRODUCTNAME_GRA.TabIndex = 1;
            this.RA_PRODUCTNAME_GRA.Text = "Nombre del Producto";
            this.RA_PRODUCTNAME_GRA.UseVisualStyleBackColor = true;
            // 
            // RA_PRODUCTID_GRA
            // 
            this.RA_PRODUCTID_GRA.AutoSize = true;
            this.RA_PRODUCTID_GRA.Checked = true;
            this.RA_PRODUCTID_GRA.Location = new System.Drawing.Point(19, 20);
            this.RA_PRODUCTID_GRA.Name = "RA_PRODUCTID_GRA";
            this.RA_PRODUCTID_GRA.Size = new System.Drawing.Size(104, 17);
            this.RA_PRODUCTID_GRA.TabIndex = 0;
            this.RA_PRODUCTID_GRA.TabStop = true;
            this.RA_PRODUCTID_GRA.Text = "Codigo Producto";
            this.RA_PRODUCTID_GRA.UseVisualStyleBackColor = true;
            // 
            // GridItemGraphics
            // 
            this.GridItemGraphics.AllowUserToAddRows = false;
            this.GridItemGraphics.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridItemGraphics.Location = new System.Drawing.Point(9, 54);
            this.GridItemGraphics.Name = "GridItemGraphics";
            this.GridItemGraphics.ReadOnly = true;
            this.GridItemGraphics.Size = new System.Drawing.Size(826, 376);
            this.GridItemGraphics.TabIndex = 14;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(563, 14);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(229, 25);
            this.label11.TabIndex = 13;
            this.label11.Text = "Inventario de Graphics";
            // 
            // botcargar_gra
            // 
            this.botcargar_gra.Image = ((System.Drawing.Image)(resources.GetObject("botcargar_gra.Image")));
            this.botcargar_gra.Location = new System.Drawing.Point(376, 7);
            this.botcargar_gra.Name = "botcargar_gra";
            this.botcargar_gra.Size = new System.Drawing.Size(100, 42);
            this.botcargar_gra.TabIndex = 12;
            this.botcargar_gra.Text = "Cargar";
            this.botcargar_gra.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.botcargar_gra.UseVisualStyleBackColor = true;
            this.botcargar_gra.Click += new System.EventHandler(this.Botcargar_gra_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 3);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(258, 13);
            this.label12.TabIndex = 11;
            this.label12.Text = "Introduzca palabras claves para realizar la busqueda.";
            // 
            // botbuscar_gra
            // 
            this.botbuscar_gra.Image = ((System.Drawing.Image)(resources.GetObject("botbuscar_gra.Image")));
            this.botbuscar_gra.Location = new System.Drawing.Point(270, 6);
            this.botbuscar_gra.Name = "botbuscar_gra";
            this.botbuscar_gra.Size = new System.Drawing.Size(100, 42);
            this.botbuscar_gra.TabIndex = 10;
            this.botbuscar_gra.Text = "Buscar";
            this.botbuscar_gra.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.botbuscar_gra.UseVisualStyleBackColor = true;
            this.botbuscar_gra.Click += new System.EventHandler(this.Botbuscar_gra_Click);
            // 
            // txtbuscar_gra
            // 
            this.txtbuscar_gra.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbuscar_gra.Location = new System.Drawing.Point(3, 19);
            this.txtbuscar_gra.Name = "txtbuscar_gra";
            this.txtbuscar_gra.Size = new System.Drawing.Size(261, 20);
            this.txtbuscar_gra.TabIndex = 9;
            this.txtbuscar_gra.TextChanged += new System.EventHandler(this.Txtbuscar_gra_TextChanged);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.RECORDFOUND_COR);
            this.tabPage4.Controls.Add(this.TXTRECORDNUMBER_COR);
            this.tabPage4.Controls.Add(this.label13);
            this.tabPage4.Controls.Add(this.groupBox4);
            this.tabPage4.Controls.Add(this.GridItemsCortados);
            this.tabPage4.Controls.Add(this.label14);
            this.tabPage4.Controls.Add(this.bot_cargar_cor);
            this.tabPage4.Controls.Add(this.label16);
            this.tabPage4.Controls.Add(this.bot_buscar_cor);
            this.tabPage4.Controls.Add(this.txtbuscar_cor);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(838, 769);
            this.tabPage4.TabIndex = 5;
            this.tabPage4.Text = "ROLLO CORTADO";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // RECORDFOUND_COR
            // 
            this.RECORDFOUND_COR.AutoSize = true;
            this.RECORDFOUND_COR.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RECORDFOUND_COR.Location = new System.Drawing.Point(641, 431);
            this.RECORDFOUND_COR.Name = "RECORDFOUND_COR";
            this.RECORDFOUND_COR.Size = new System.Drawing.Size(188, 13);
            this.RECORDFOUND_COR.TabIndex = 18;
            this.RECORDFOUND_COR.Text = "0 REGISTROS ENCONTRADOS";
            // 
            // TXTRECORDNUMBER_COR
            // 
            this.TXTRECORDNUMBER_COR.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXTRECORDNUMBER_COR.Location = new System.Drawing.Point(339, 454);
            this.TXTRECORDNUMBER_COR.Name = "TXTRECORDNUMBER_COR";
            this.TXTRECORDNUMBER_COR.Size = new System.Drawing.Size(100, 20);
            this.TXTRECORDNUMBER_COR.TabIndex = 17;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(221, 457);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(112, 13);
            this.label13.TabIndex = 16;
            this.label13.Text = "Numero de Registros :";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.RA_UNIQUE_CODE_COR);
            this.groupBox4.Controls.Add(this.RA_ROLLID_COR);
            this.groupBox4.Controls.Add(this.RA_PRODUCTNAME_COR);
            this.groupBox4.Controls.Add(this.RA_PRODUCTID_COR);
            this.groupBox4.Location = new System.Drawing.Point(6, 433);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(200, 92);
            this.groupBox4.TabIndex = 15;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Filtros de Busquedas";
            // 
            // RA_UNIQUE_CODE_COR
            // 
            this.RA_UNIQUE_CODE_COR.AutoSize = true;
            this.RA_UNIQUE_CODE_COR.Location = new System.Drawing.Point(19, 67);
            this.RA_UNIQUE_CODE_COR.Name = "RA_UNIQUE_CODE_COR";
            this.RA_UNIQUE_CODE_COR.Size = new System.Drawing.Size(87, 17);
            this.RA_UNIQUE_CODE_COR.TabIndex = 3;
            this.RA_UNIQUE_CODE_COR.Text = "Unique Code";
            this.RA_UNIQUE_CODE_COR.UseVisualStyleBackColor = true;
            // 
            // RA_ROLLID_COR
            // 
            this.RA_ROLLID_COR.AutoSize = true;
            this.RA_ROLLID_COR.Location = new System.Drawing.Point(19, 51);
            this.RA_ROLLID_COR.Name = "RA_ROLLID_COR";
            this.RA_ROLLID_COR.Size = new System.Drawing.Size(97, 17);
            this.RA_ROLLID_COR.TabIndex = 2;
            this.RA_ROLLID_COR.Text = "Numero Roll-ID";
            this.RA_ROLLID_COR.UseVisualStyleBackColor = true;
            // 
            // RA_PRODUCTNAME_COR
            // 
            this.RA_PRODUCTNAME_COR.AutoSize = true;
            this.RA_PRODUCTNAME_COR.Location = new System.Drawing.Point(19, 36);
            this.RA_PRODUCTNAME_COR.Name = "RA_PRODUCTNAME_COR";
            this.RA_PRODUCTNAME_COR.Size = new System.Drawing.Size(125, 17);
            this.RA_PRODUCTNAME_COR.TabIndex = 1;
            this.RA_PRODUCTNAME_COR.Text = "Nombre del Producto";
            this.RA_PRODUCTNAME_COR.UseVisualStyleBackColor = true;
            // 
            // RA_PRODUCTID_COR
            // 
            this.RA_PRODUCTID_COR.AutoSize = true;
            this.RA_PRODUCTID_COR.Checked = true;
            this.RA_PRODUCTID_COR.Location = new System.Drawing.Point(19, 20);
            this.RA_PRODUCTID_COR.Name = "RA_PRODUCTID_COR";
            this.RA_PRODUCTID_COR.Size = new System.Drawing.Size(104, 17);
            this.RA_PRODUCTID_COR.TabIndex = 0;
            this.RA_PRODUCTID_COR.TabStop = true;
            this.RA_PRODUCTID_COR.Text = "Codigo Producto";
            this.RA_PRODUCTID_COR.UseVisualStyleBackColor = true;
            // 
            // GridItemsCortados
            // 
            this.GridItemsCortados.AllowUserToAddRows = false;
            this.GridItemsCortados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridItemsCortados.Location = new System.Drawing.Point(9, 54);
            this.GridItemsCortados.Name = "GridItemsCortados";
            this.GridItemsCortados.ReadOnly = true;
            this.GridItemsCortados.Size = new System.Drawing.Size(826, 376);
            this.GridItemsCortados.TabIndex = 14;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(505, 14);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(296, 25);
            this.label14.TabIndex = 13;
            this.label14.Text = "Inventario de Rollos Cortados";
            // 
            // bot_cargar_cor
            // 
            this.bot_cargar_cor.Image = ((System.Drawing.Image)(resources.GetObject("bot_cargar_cor.Image")));
            this.bot_cargar_cor.Location = new System.Drawing.Point(376, 7);
            this.bot_cargar_cor.Name = "bot_cargar_cor";
            this.bot_cargar_cor.Size = new System.Drawing.Size(100, 42);
            this.bot_cargar_cor.TabIndex = 12;
            this.bot_cargar_cor.Text = "Cargar";
            this.bot_cargar_cor.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bot_cargar_cor.UseVisualStyleBackColor = true;
            this.bot_cargar_cor.Click += new System.EventHandler(this.Bot_cargar_cor_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(6, 3);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(258, 13);
            this.label16.TabIndex = 11;
            this.label16.Text = "Introduzca palabras claves para realizar la busqueda.";
            // 
            // bot_buscar_cor
            // 
            this.bot_buscar_cor.Image = ((System.Drawing.Image)(resources.GetObject("bot_buscar_cor.Image")));
            this.bot_buscar_cor.Location = new System.Drawing.Point(270, 6);
            this.bot_buscar_cor.Name = "bot_buscar_cor";
            this.bot_buscar_cor.Size = new System.Drawing.Size(100, 42);
            this.bot_buscar_cor.TabIndex = 10;
            this.bot_buscar_cor.Text = "Buscar";
            this.bot_buscar_cor.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bot_buscar_cor.UseVisualStyleBackColor = true;
            this.bot_buscar_cor.Click += new System.EventHandler(this.Bot_buscar_cor_Click);
            // 
            // txtbuscar_cor
            // 
            this.txtbuscar_cor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbuscar_cor.Location = new System.Drawing.Point(3, 19);
            this.txtbuscar_cor.Name = "txtbuscar_cor";
            this.txtbuscar_cor.Size = new System.Drawing.Size(261, 20);
            this.txtbuscar_cor.TabIndex = 9;
            this.txtbuscar_cor.TextChanged += new System.EventHandler(this.Txtbuscar_cor_TextChanged);
            // 
            // FrmInventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(866, 920);
            this.Controls.Add(this.TABINVENTARIO);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmInventario";
            this.Text = "FrmInventario";
            this.Load += new System.EventHandler(this.FrmInventario_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.TABINVENTARIO.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.filter.ResumeLayout(false);
            this.filter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridItemsMaster)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridItemHojas)).EndInit();
            this.TAB_GRAPHICS.ResumeLayout(false);
            this.TAB_GRAPHICS.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridItemGraphics)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridItemsCortados)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TabControl TABINVENTARIO;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox filter;
        private System.Windows.Forms.RadioButton RA_ROLLID;
        private System.Windows.Forms.RadioButton RA_PRODUCTNAME;
        private System.Windows.Forms.RadioButton RA_PRODUCTID;
        private System.Windows.Forms.Button bot_buscar;
        private System.Windows.Forms.TextBox txt_buscar;
        private System.Windows.Forms.DataGridView GridItemsMaster;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label FOUND_COUNTER;
        private System.Windows.Forms.TextBox TXT_RECORDS;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button bot_cargar;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button botcarga_hoj;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button botbuscar_hoj;
        private System.Windows.Forms.TextBox txtbuscar_hoj;
        private System.Windows.Forms.DataGridView GridItemHojas;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton RAROLLID_HOJ;
        private System.Windows.Forms.RadioButton RAPRODUCTNAME_HOJ;
        private System.Windows.Forms.RadioButton RACODIGO_HOJ;
        private System.Windows.Forms.Label FOUND_HOJAS;
        private System.Windows.Forms.TextBox TXT_RECORDNUMBER_HOJ;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TabPage TAB_GRAPHICS;
        private System.Windows.Forms.Label RECORD_FOUND_GRA;
        private System.Windows.Forms.TextBox TXTRECORD_GRA;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton RA_ROLLID_GRA;
        private System.Windows.Forms.RadioButton RA_PRODUCTNAME_GRA;
        private System.Windows.Forms.RadioButton RA_PRODUCTID_GRA;
        private System.Windows.Forms.DataGridView GridItemGraphics;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button botcargar_gra;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button botbuscar_gra;
        private System.Windows.Forms.TextBox txtbuscar_gra;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Label RECORDFOUND_COR;
        private System.Windows.Forms.TextBox TXTRECORDNUMBER_COR;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton RA_ROLLID_COR;
        private System.Windows.Forms.RadioButton RA_PRODUCTNAME_COR;
        private System.Windows.Forms.RadioButton RA_PRODUCTID_COR;
        private System.Windows.Forms.DataGridView GridItemsCortados;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button bot_cargar_cor;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button bot_buscar_cor;
        private System.Windows.Forms.TextBox txtbuscar_cor;
        private System.Windows.Forms.RadioButton RA_UNIQUE_CODE_COR;
    }
}