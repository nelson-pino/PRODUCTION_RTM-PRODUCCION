namespace RitramaAPP.form
{
    partial class SeleccionMateriaPrima
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bot_buscar = new System.Windows.Forms.Button();
            this.CONTADOR_REGISTRO = new System.Windows.Forms.Label();
            this.txt_fecha_hasta = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rad_fecha = new System.Windows.Forms.RadioButton();
            this.rad_orden = new System.Windows.Forms.RadioButton();
            this.rad_ProveedorName = new System.Windows.Forms.RadioButton();
            this.rad_rollid = new System.Windows.Forms.RadioButton();
            this.grid_ordenes = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_buscar = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_fecha_desde = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.rad_productName = new System.Windows.Forms.RadioButton();
            this.rad_ubic = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_ordenes)).BeginInit();
            this.SuspendLayout();
            // 
            // bot_buscar
            // 
            this.bot_buscar.Location = new System.Drawing.Point(23, 630);
            this.bot_buscar.Name = "bot_buscar";
            this.bot_buscar.Size = new System.Drawing.Size(75, 27);
            this.bot_buscar.TabIndex = 21;
            this.bot_buscar.Text = "BUSCAR";
            this.bot_buscar.UseVisualStyleBackColor = true;
            this.bot_buscar.Click += new System.EventHandler(this.Bot_buscar_Click);
            // 
            // CONTADOR_REGISTRO
            // 
            this.CONTADOR_REGISTRO.AutoSize = true;
            this.CONTADOR_REGISTRO.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CONTADOR_REGISTRO.Location = new System.Drawing.Point(20, 721);
            this.CONTADOR_REGISTRO.Name = "CONTADOR_REGISTRO";
            this.CONTADOR_REGISTRO.Size = new System.Drawing.Size(120, 17);
            this.CONTADOR_REGISTRO.TabIndex = 20;
            this.CONTADOR_REGISTRO.Text = "Registro 0 de 0";
            // 
            // txt_fecha_hasta
            // 
            this.txt_fecha_hasta.Enabled = false;
            this.txt_fecha_hasta.Location = new System.Drawing.Point(20, 594);
            this.txt_fecha_hasta.Name = "txt_fecha_hasta";
            this.txt_fecha_hasta.Size = new System.Drawing.Size(277, 22);
            this.txt_fecha_hasta.TabIndex = 19;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rad_ubic);
            this.groupBox1.Controls.Add(this.rad_productName);
            this.groupBox1.Controls.Add(this.rad_fecha);
            this.groupBox1.Controls.Add(this.rad_orden);
            this.groupBox1.Controls.Add(this.rad_ProveedorName);
            this.groupBox1.Controls.Add(this.rad_rollid);
            this.groupBox1.Location = new System.Drawing.Point(404, 552);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 186);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Busqueda por:";
            // 
            // rad_fecha
            // 
            this.rad_fecha.AutoSize = true;
            this.rad_fecha.Location = new System.Drawing.Point(29, 138);
            this.rad_fecha.Name = "rad_fecha";
            this.rad_fecha.Size = new System.Drawing.Size(143, 21);
            this.rad_fecha.TabIndex = 3;
            this.rad_fecha.Text = "Fecha Produccion";
            this.rad_fecha.UseVisualStyleBackColor = true;
            this.rad_fecha.CheckedChanged += new System.EventHandler(this.Rad_fecha_CheckedChanged);
            // 
            // rad_orden
            // 
            this.rad_orden.AutoSize = true;
            this.rad_orden.Checked = true;
            this.rad_orden.Location = new System.Drawing.Point(28, 37);
            this.rad_orden.Name = "rad_orden";
            this.rad_orden.Size = new System.Drawing.Size(123, 21);
            this.rad_orden.TabIndex = 2;
            this.rad_orden.TabStop = true;
            this.rad_orden.Text = "Numero Orden";
            this.rad_orden.UseVisualStyleBackColor = true;
            // 
            // rad_ProveedorName
            // 
            this.rad_ProveedorName.AutoSize = true;
            this.rad_ProveedorName.Location = new System.Drawing.Point(28, 78);
            this.rad_ProveedorName.Name = "rad_ProveedorName";
            this.rad_ProveedorName.Size = new System.Drawing.Size(149, 21);
            this.rad_ProveedorName.TabIndex = 1;
            this.rad_ProveedorName.Text = "Proveedor Nombre";
            this.rad_ProveedorName.UseVisualStyleBackColor = true;
            // 
            // rad_rollid
            // 
            this.rad_rollid.AutoSize = true;
            this.rad_rollid.Location = new System.Drawing.Point(28, 57);
            this.rad_rollid.Name = "rad_rollid";
            this.rad_rollid.Size = new System.Drawing.Size(72, 21);
            this.rad_rollid.TabIndex = 0;
            this.rad_rollid.Text = "Roll Id.";
            this.rad_rollid.UseVisualStyleBackColor = true;
            // 
            // grid_ordenes
            // 
            this.grid_ordenes.AllowUserToAddRows = false;
            this.grid_ordenes.AllowUserToDeleteRows = false;
            this.grid_ordenes.AllowUserToResizeRows = false;
            this.grid_ordenes.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.grid_ordenes.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.grid_ordenes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grid_ordenes.DefaultCellStyle = dataGridViewCellStyle3;
            this.grid_ordenes.Location = new System.Drawing.Point(9, 60);
            this.grid_ordenes.MultiSelect = false;
            this.grid_ordenes.Name = "grid_ordenes";
            this.grid_ordenes.ReadOnly = true;
            this.grid_ordenes.RowHeadersWidth = 30;
            this.grid_ordenes.RowTemplate.Height = 24;
            this.grid_ordenes.Size = new System.Drawing.Size(595, 465);
            this.grid_ordenes.TabIndex = 14;
            this.grid_ordenes.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.Grid_ordenes_CellMouseDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(485, 17);
            this.label1.TabIndex = 13;
            this.label1.Text = "Introduzca aqui las palabras claves para encontrar los registros requeridos:";
            // 
            // txt_buscar
            // 
            this.txt_buscar.Location = new System.Drawing.Point(9, 32);
            this.txt_buscar.Name = "txt_buscar";
            this.txt_buscar.Size = new System.Drawing.Size(587, 22);
            this.txt_buscar.TabIndex = 12;
            this.txt_buscar.TextChanged += new System.EventHandler(this.Txt_buscar_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(17, 574);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 17);
            this.label4.TabIndex = 18;
            this.label4.Text = "Fecha Hasta :";
            // 
            // txt_fecha_desde
            // 
            this.txt_fecha_desde.Enabled = false;
            this.txt_fecha_desde.Location = new System.Drawing.Point(20, 552);
            this.txt_fecha_desde.Name = "txt_fecha_desde";
            this.txt_fecha_desde.Size = new System.Drawing.Size(277, 22);
            this.txt_fecha_desde.TabIndex = 17;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(20, 532);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 17);
            this.label3.TabIndex = 16;
            this.label3.Text = "Fecha Desde :";
            // 
            // rad_productName
            // 
            this.rad_productName.AutoSize = true;
            this.rad_productName.Location = new System.Drawing.Point(29, 98);
            this.rad_productName.Name = "rad_productName";
            this.rad_productName.Size = new System.Drawing.Size(140, 21);
            this.rad_productName.TabIndex = 4;
            this.rad_productName.Text = "Nombre Producto";
            this.rad_productName.UseVisualStyleBackColor = true;
            // 
            // rad_ubic
            // 
            this.rad_ubic.AutoSize = true;
            this.rad_ubic.Location = new System.Drawing.Point(29, 117);
            this.rad_ubic.Name = "rad_ubic";
            this.rad_ubic.Size = new System.Drawing.Size(117, 21);
            this.rad_ubic.TabIndex = 5;
            this.rad_ubic.Text = "Por Ubicacion";
            this.rad_ubic.UseVisualStyleBackColor = true;
            // 
            // SeleccionMateriaPrima
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(616, 747);
            this.Controls.Add(this.bot_buscar);
            this.Controls.Add(this.CONTADOR_REGISTRO);
            this.Controls.Add(this.txt_fecha_hasta);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grid_ordenes);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_buscar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_fecha_desde);
            this.Controls.Add(this.label3);
            this.Name = "SeleccionMateriaPrima";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Buscar en las recepciones de materia prima";
            this.Load += new System.EventHandler(this.SeleccionMateriaPrima_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_ordenes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bot_buscar;
        private System.Windows.Forms.Label CONTADOR_REGISTRO;
        private System.Windows.Forms.DateTimePicker txt_fecha_hasta;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rad_fecha;
        private System.Windows.Forms.RadioButton rad_orden;
        private System.Windows.Forms.RadioButton rad_ProveedorName;
        private System.Windows.Forms.RadioButton rad_rollid;
        private System.Windows.Forms.DataGridView grid_ordenes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_buscar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker txt_fecha_desde;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton rad_productName;
        private System.Windows.Forms.RadioButton rad_ubic;
    }
}