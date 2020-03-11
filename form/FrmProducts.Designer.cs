namespace RitramaAPP
{
    partial class FrmProducts
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmProducts));
            this.txt_product_id = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_product_name = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_referencia = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_code_bar = new System.Windows.Forms.TextBox();
            this.cbo_category = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.RAD_MASTER_ROLLS = new System.Windows.Forms.RadioButton();
            this.RAD_RESMAS = new System.Windows.Forms.RadioButton();
            this.label15 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.RAD_ROLLO_CORTADO = new System.Windows.Forms.RadioButton();
            this.RAD_GRAPHICS = new System.Windows.Forms.RadioButton();
            this.CHK_ANULADO = new System.Windows.Forms.CheckBox();
            this.LABEL_CONTADOR_REGISTRO = new System.Windows.Forms.Label();
            this.label_descrip = new System.Windows.Forms.Label();
            this.txt_descrip_product = new System.Windows.Forms.TextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.BOT_PRIMERO = new System.Windows.Forms.ToolStripButton();
            this.BOT_ANTERIOR = new System.Windows.Forms.ToolStripButton();
            this.BOT_SIGUIENTE = new System.Windows.Forms.ToolStripButton();
            this.BOT_ULTIMO = new System.Windows.Forms.ToolStripButton();
            this.BOT_NUEVO = new System.Windows.Forms.ToolStripButton();
            this.BOT_CANCELAR = new System.Windows.Forms.ToolStripButton();
            this.BOT_GRABAR = new System.Windows.Forms.ToolStripButton();
            this.BOT_MODIFICAR = new System.Windows.Forms.ToolStripButton();
            this.BOT_BUSCAR = new System.Windows.Forms.ToolStripButton();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_precio = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_codeRC = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_ratio = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_product_id
            // 
            this.txt_product_id.Location = new System.Drawing.Point(25, 125);
            this.txt_product_id.Margin = new System.Windows.Forms.Padding(2);
            this.txt_product_id.Name = "txt_product_id";
            this.txt_product_id.ReadOnly = true;
            this.txt_product_id.Size = new System.Drawing.Size(113, 20);
            this.txt_product_id.TabIndex = 0;
            this.txt_product_id.TextChanged += new System.EventHandler(this.Txt_product_id_TextChanged);
            this.txt_product_id.Validating += new System.ComponentModel.CancelEventHandler(this.Txt_product_id_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 52);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Product ID.:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 152);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Product Name:";
            // 
            // txt_product_name
            // 
            this.txt_product_name.Location = new System.Drawing.Point(25, 168);
            this.txt_product_name.Margin = new System.Windows.Forms.Padding(2);
            this.txt_product_name.Name = "txt_product_name";
            this.txt_product_name.ReadOnly = true;
            this.txt_product_name.Size = new System.Drawing.Size(469, 20);
            this.txt_product_name.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 236);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Referencia:";
            // 
            // txt_referencia
            // 
            this.txt_referencia.Location = new System.Drawing.Point(25, 252);
            this.txt_referencia.Margin = new System.Windows.Forms.Padding(2);
            this.txt_referencia.Name = "txt_referencia";
            this.txt_referencia.ReadOnly = true;
            this.txt_referencia.Size = new System.Drawing.Size(113, 20);
            this.txt_referencia.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 282);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Codigo de Barra:";
            // 
            // txt_code_bar
            // 
            this.txt_code_bar.Location = new System.Drawing.Point(25, 298);
            this.txt_code_bar.Margin = new System.Windows.Forms.Padding(2);
            this.txt_code_bar.Name = "txt_code_bar";
            this.txt_code_bar.ReadOnly = true;
            this.txt_code_bar.Size = new System.Drawing.Size(113, 20);
            this.txt_code_bar.TabIndex = 4;
            // 
            // cbo_category
            // 
            this.cbo_category.Enabled = false;
            this.cbo_category.FormattingEnabled = true;
            this.cbo_category.Items.AddRange(new object[] {
            "Papeles Entucados",
            "Papeles No Entucados",
            "Papeles Metalizados",
            "Peliculas Monomericas",
            "otros productos"});
            this.cbo_category.Location = new System.Drawing.Point(25, 388);
            this.cbo_category.Margin = new System.Windows.Forms.Padding(2);
            this.cbo_category.Name = "cbo_category";
            this.cbo_category.Size = new System.Drawing.Size(274, 21);
            this.cbo_category.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 372);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Categoria:";
            // 
            // RAD_MASTER_ROLLS
            // 
            this.RAD_MASTER_ROLLS.AutoSize = true;
            this.RAD_MASTER_ROLLS.Enabled = false;
            this.RAD_MASTER_ROLLS.Location = new System.Drawing.Point(17, 24);
            this.RAD_MASTER_ROLLS.Margin = new System.Windows.Forms.Padding(2);
            this.RAD_MASTER_ROLLS.Name = "RAD_MASTER_ROLLS";
            this.RAD_MASTER_ROLLS.Size = new System.Drawing.Size(83, 17);
            this.RAD_MASTER_ROLLS.TabIndex = 0;
            this.RAD_MASTER_ROLLS.TabStop = true;
            this.RAD_MASTER_ROLLS.Text = "Master Rolls";
            this.RAD_MASTER_ROLLS.UseVisualStyleBackColor = true;
            // 
            // RAD_RESMAS
            // 
            this.RAD_RESMAS.AutoSize = true;
            this.RAD_RESMAS.Enabled = false;
            this.RAD_RESMAS.Location = new System.Drawing.Point(17, 46);
            this.RAD_RESMAS.Margin = new System.Windows.Forms.Padding(2);
            this.RAD_RESMAS.Name = "RAD_RESMAS";
            this.RAD_RESMAS.Size = new System.Drawing.Size(52, 17);
            this.RAD_RESMAS.TabIndex = 1;
            this.RAD_RESMAS.TabStop = true;
            this.RAD_RESMAS.Text = "Hojas";
            this.RAD_RESMAS.UseVisualStyleBackColor = true;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(458, 22);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(140, 25);
            this.label15.TabIndex = 0;
            this.label15.Text = "PRODUCTOS";
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
            this.panel1.Size = new System.Drawing.Size(710, 65);
            this.panel1.TabIndex = 35;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.RAD_ROLLO_CORTADO);
            this.groupBox1.Controls.Add(this.RAD_GRAPHICS);
            this.groupBox1.Controls.Add(this.RAD_MASTER_ROLLS);
            this.groupBox1.Controls.Add(this.RAD_RESMAS);
            this.groupBox1.Location = new System.Drawing.Point(515, 169);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(150, 126);
            this.groupBox1.TabIndex = 36;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tipo de producto:";
            // 
            // RAD_ROLLO_CORTADO
            // 
            this.RAD_ROLLO_CORTADO.AutoSize = true;
            this.RAD_ROLLO_CORTADO.Enabled = false;
            this.RAD_ROLLO_CORTADO.Location = new System.Drawing.Point(17, 89);
            this.RAD_ROLLO_CORTADO.Margin = new System.Windows.Forms.Padding(2);
            this.RAD_ROLLO_CORTADO.Name = "RAD_ROLLO_CORTADO";
            this.RAD_ROLLO_CORTADO.Size = new System.Drawing.Size(89, 17);
            this.RAD_ROLLO_CORTADO.TabIndex = 3;
            this.RAD_ROLLO_CORTADO.TabStop = true;
            this.RAD_ROLLO_CORTADO.Text = "Rollo Cortado";
            this.RAD_ROLLO_CORTADO.UseVisualStyleBackColor = true;
            // 
            // RAD_GRAPHICS
            // 
            this.RAD_GRAPHICS.AutoSize = true;
            this.RAD_GRAPHICS.Enabled = false;
            this.RAD_GRAPHICS.Location = new System.Drawing.Point(17, 68);
            this.RAD_GRAPHICS.Margin = new System.Windows.Forms.Padding(2);
            this.RAD_GRAPHICS.Name = "RAD_GRAPHICS";
            this.RAD_GRAPHICS.Size = new System.Drawing.Size(67, 17);
            this.RAD_GRAPHICS.TabIndex = 2;
            this.RAD_GRAPHICS.TabStop = true;
            this.RAD_GRAPHICS.Text = "Graphics";
            this.RAD_GRAPHICS.UseVisualStyleBackColor = true;
            // 
            // CHK_ANULADO
            // 
            this.CHK_ANULADO.AutoSize = true;
            this.CHK_ANULADO.Enabled = false;
            this.CHK_ANULADO.Location = new System.Drawing.Point(512, 128);
            this.CHK_ANULADO.Margin = new System.Windows.Forms.Padding(2);
            this.CHK_ANULADO.Name = "CHK_ANULADO";
            this.CHK_ANULADO.Size = new System.Drawing.Size(145, 17);
            this.CHK_ANULADO.TabIndex = 7;
            this.CHK_ANULADO.Text = "Desactivar este producto";
            this.CHK_ANULADO.UseVisualStyleBackColor = true;
            // 
            // LABEL_CONTADOR_REGISTRO
            // 
            this.LABEL_CONTADOR_REGISTRO.AutoSize = true;
            this.LABEL_CONTADOR_REGISTRO.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LABEL_CONTADOR_REGISTRO.Location = new System.Drawing.Point(20, 35);
            this.LABEL_CONTADOR_REGISTRO.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LABEL_CONTADOR_REGISTRO.Name = "LABEL_CONTADOR_REGISTRO";
            this.LABEL_CONTADOR_REGISTRO.Size = new System.Drawing.Size(122, 13);
            this.LABEL_CONTADOR_REGISTRO.TabIndex = 8;
            this.LABEL_CONTADOR_REGISTRO.Text = "0 DE 0 REGISTROS";
            // 
            // label_descrip
            // 
            this.label_descrip.AutoSize = true;
            this.label_descrip.Location = new System.Drawing.Point(22, 195);
            this.label_descrip.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_descrip.Name = "label_descrip";
            this.label_descrip.Size = new System.Drawing.Size(126, 13);
            this.label_descrip.TabIndex = 40;
            this.label_descrip.Text = "Descripcion del Producto";
            // 
            // txt_descrip_product
            // 
            this.txt_descrip_product.Location = new System.Drawing.Point(25, 211);
            this.txt_descrip_product.Margin = new System.Windows.Forms.Padding(2);
            this.txt_descrip_product.Name = "txt_descrip_product";
            this.txt_descrip_product.ReadOnly = true;
            this.txt_descrip_product.Size = new System.Drawing.Size(469, 20);
            this.txt_descrip_product.TabIndex = 2;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BOT_PRIMERO,
            this.BOT_ANTERIOR,
            this.BOT_SIGUIENTE,
            this.BOT_ULTIMO,
            this.BOT_NUEVO,
            this.BOT_CANCELAR,
            this.BOT_GRABAR,
            this.BOT_MODIFICAR,
            this.BOT_BUSCAR});
            this.toolStrip1.Location = new System.Drawing.Point(0, 65);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(710, 27);
            this.toolStrip1.TabIndex = 41;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // BOT_PRIMERO
            // 
            this.BOT_PRIMERO.Image = ((System.Drawing.Image)(resources.GetObject("BOT_PRIMERO.Image")));
            this.BOT_PRIMERO.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BOT_PRIMERO.Name = "BOT_PRIMERO";
            this.BOT_PRIMERO.Size = new System.Drawing.Size(73, 24);
            this.BOT_PRIMERO.Text = "Primero";
            this.BOT_PRIMERO.Click += new System.EventHandler(this.BOT_PRIMERO_Click);
            // 
            // BOT_ANTERIOR
            // 
            this.BOT_ANTERIOR.Image = ((System.Drawing.Image)(resources.GetObject("BOT_ANTERIOR.Image")));
            this.BOT_ANTERIOR.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BOT_ANTERIOR.Name = "BOT_ANTERIOR";
            this.BOT_ANTERIOR.Size = new System.Drawing.Size(74, 24);
            this.BOT_ANTERIOR.Text = "Anterior";
            this.BOT_ANTERIOR.Click += new System.EventHandler(this.BOT_ANTERIOR_Click);
            // 
            // BOT_SIGUIENTE
            // 
            this.BOT_SIGUIENTE.Image = ((System.Drawing.Image)(resources.GetObject("BOT_SIGUIENTE.Image")));
            this.BOT_SIGUIENTE.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BOT_SIGUIENTE.Name = "BOT_SIGUIENTE";
            this.BOT_SIGUIENTE.Size = new System.Drawing.Size(80, 24);
            this.BOT_SIGUIENTE.Text = "Siguiente";
            this.BOT_SIGUIENTE.Click += new System.EventHandler(this.BOT_SIGUIENTE_Click);
            // 
            // BOT_ULTIMO
            // 
            this.BOT_ULTIMO.Image = ((System.Drawing.Image)(resources.GetObject("BOT_ULTIMO.Image")));
            this.BOT_ULTIMO.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BOT_ULTIMO.Name = "BOT_ULTIMO";
            this.BOT_ULTIMO.Size = new System.Drawing.Size(67, 24);
            this.BOT_ULTIMO.Text = "Ultimo";
            this.BOT_ULTIMO.Click += new System.EventHandler(this.BOT_ULTIMO_Click);
            // 
            // BOT_NUEVO
            // 
            this.BOT_NUEVO.Image = ((System.Drawing.Image)(resources.GetObject("BOT_NUEVO.Image")));
            this.BOT_NUEVO.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BOT_NUEVO.Name = "BOT_NUEVO";
            this.BOT_NUEVO.Size = new System.Drawing.Size(66, 24);
            this.BOT_NUEVO.Text = "Nuevo";
            this.BOT_NUEVO.Click += new System.EventHandler(this.BOT_NUEVO_Click);
            // 
            // BOT_CANCELAR
            // 
            this.BOT_CANCELAR.Enabled = false;
            this.BOT_CANCELAR.Image = ((System.Drawing.Image)(resources.GetObject("BOT_CANCELAR.Image")));
            this.BOT_CANCELAR.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BOT_CANCELAR.Name = "BOT_CANCELAR";
            this.BOT_CANCELAR.Size = new System.Drawing.Size(77, 24);
            this.BOT_CANCELAR.Text = "Cancelar";
            this.BOT_CANCELAR.Click += new System.EventHandler(this.BOT_CANCELAR_Click);
            // 
            // BOT_GRABAR
            // 
            this.BOT_GRABAR.Enabled = false;
            this.BOT_GRABAR.Image = ((System.Drawing.Image)(resources.GetObject("BOT_GRABAR.Image")));
            this.BOT_GRABAR.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BOT_GRABAR.Name = "BOT_GRABAR";
            this.BOT_GRABAR.Size = new System.Drawing.Size(66, 24);
            this.BOT_GRABAR.Text = "Grabar";
            this.BOT_GRABAR.Click += new System.EventHandler(this.BOT_GRABAR_Click);
            // 
            // BOT_MODIFICAR
            // 
            this.BOT_MODIFICAR.Image = ((System.Drawing.Image)(resources.GetObject("BOT_MODIFICAR.Image")));
            this.BOT_MODIFICAR.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BOT_MODIFICAR.Name = "BOT_MODIFICAR";
            this.BOT_MODIFICAR.Size = new System.Drawing.Size(82, 24);
            this.BOT_MODIFICAR.Text = "Modificar";
            this.BOT_MODIFICAR.Click += new System.EventHandler(this.BOT_MODIFICAR_Click);
            // 
            // BOT_BUSCAR
            // 
            this.BOT_BUSCAR.Image = ((System.Drawing.Image)(resources.GetObject("BOT_BUSCAR.Image")));
            this.BOT_BUSCAR.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BOT_BUSCAR.Name = "BOT_BUSCAR";
            this.BOT_BUSCAR.Size = new System.Drawing.Size(66, 24);
            this.BOT_BUSCAR.Text = "Buscar";
            this.BOT_BUSCAR.Click += new System.EventHandler(this.BOT_BUSCAR_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(22, 109);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 13);
            this.label7.TabIndex = 42;
            this.label7.Text = "Part Id.:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 325);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 44;
            this.label5.Text = "Precio :";
            // 
            // txt_precio
            // 
            this.txt_precio.Location = new System.Drawing.Point(25, 341);
            this.txt_precio.Margin = new System.Windows.Forms.Padding(2);
            this.txt_precio.Name = "txt_precio";
            this.txt_precio.ReadOnly = true;
            this.txt_precio.Size = new System.Drawing.Size(113, 20);
            this.txt_precio.TabIndex = 5;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.LABEL_CONTADOR_REGISTRO);
            this.groupBox2.Location = new System.Drawing.Point(515, 304);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(150, 81);
            this.groupBox2.TabIndex = 45;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Contador de Registros:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(22, 467);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(113, 13);
            this.label8.TabIndex = 47;
            this.label8.Text = "Codigo Rollo Cortado :";
            // 
            // txt_codeRC
            // 
            this.txt_codeRC.Location = new System.Drawing.Point(25, 483);
            this.txt_codeRC.Margin = new System.Windows.Forms.Padding(2);
            this.txt_codeRC.Name = "txt_codeRC";
            this.txt_codeRC.ReadOnly = true;
            this.txt_codeRC.Size = new System.Drawing.Size(113, 20);
            this.txt_codeRC.TabIndex = 46;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(22, 418);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 13);
            this.label9.TabIndex = 49;
            this.label9.Text = "Ratio :";
            // 
            // txt_ratio
            // 
            this.txt_ratio.Location = new System.Drawing.Point(25, 434);
            this.txt_ratio.Margin = new System.Windows.Forms.Padding(2);
            this.txt_ratio.Name = "txt_ratio";
            this.txt_ratio.ReadOnly = true;
            this.txt_ratio.Size = new System.Drawing.Size(113, 20);
            this.txt_ratio.TabIndex = 48;
            // 
            // FrmProducts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(710, 558);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txt_ratio);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txt_codeRC);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt_precio);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.label_descrip);
            this.Controls.Add(this.txt_descrip_product);
            this.Controls.Add(this.CHK_ANULADO);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cbo_category);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_code_bar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_referencia);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_product_name);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_product_id);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmProducts";
            this.Text = "FrmProducts";
            this.Load += new System.EventHandler(this.FrmProducts_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_product_id;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_product_name;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_referencia;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_code_bar;
        private System.Windows.Forms.ComboBox cbo_category;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton RAD_MASTER_ROLLS;
        private System.Windows.Forms.RadioButton RAD_RESMAS;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox CHK_ANULADO;
        private System.Windows.Forms.Label LABEL_CONTADOR_REGISTRO;
        private System.Windows.Forms.Label label_descrip;
        private System.Windows.Forms.TextBox txt_descrip_product;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton BOT_NUEVO;
        private System.Windows.Forms.ToolStripButton BOT_GRABAR;
        private System.Windows.Forms.ToolStripButton BOT_MODIFICAR;
        private System.Windows.Forms.ToolStripButton BOT_BUSCAR;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ToolStripButton BOT_PRIMERO;
        private System.Windows.Forms.ToolStripButton BOT_ANTERIOR;
        private System.Windows.Forms.ToolStripButton BOT_SIGUIENTE;
        private System.Windows.Forms.ToolStripButton BOT_ULTIMO;
        private System.Windows.Forms.ToolStripButton BOT_CANCELAR;
        private System.Windows.Forms.RadioButton RAD_GRAPHICS;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_precio;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton RAD_ROLLO_CORTADO;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_codeRC;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txt_ratio;
    }
}