namespace RitramaAPP.form
{
    partial class FrmBuscarOrdenes
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
            this.txt_buscar = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grid_ordenes = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rad_fecha = new System.Windows.Forms.RadioButton();
            this.rad_orden = new System.Windows.Forms.RadioButton();
            this.rad_customer_name = new System.Windows.Forms.RadioButton();
            this.rad_id_customer = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_fecha_desde = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_fecha_hasta = new System.Windows.Forms.DateTimePicker();
            this.CONTADOR_REGISTRO = new System.Windows.Forms.Label();
            this.bot_buscar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grid_ordenes)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_buscar
            // 
            this.txt_buscar.Location = new System.Drawing.Point(9, 27);
            this.txt_buscar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txt_buscar.Name = "txt_buscar";
            this.txt_buscar.Size = new System.Drawing.Size(454, 20);
            this.txt_buscar.TabIndex = 0;
            this.txt_buscar.TextChanged += new System.EventHandler(this.Txt_buscar_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(358, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Introduzca aqui las palabras claves para encontrar los registros requeridos:";
            // 
            // grid_ordenes
            // 
            this.grid_ordenes.AllowUserToAddRows = false;
            this.grid_ordenes.AllowUserToDeleteRows = false;
            this.grid_ordenes.AllowUserToResizeRows = false;
            this.grid_ordenes.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.grid_ordenes.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.grid_ordenes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_ordenes.Location = new System.Drawing.Point(9, 50);
            this.grid_ordenes.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grid_ordenes.MultiSelect = false;
            this.grid_ordenes.Name = "grid_ordenes";
            this.grid_ordenes.ReadOnly = true;
            this.grid_ordenes.RowHeadersWidth = 30;
            this.grid_ordenes.RowTemplate.Height = 24;
            this.grid_ordenes.Size = new System.Drawing.Size(453, 378);
            this.grid_ordenes.TabIndex = 2;
            this.grid_ordenes.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.Grid_ordenes_CellMouseDoubleClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rad_fecha);
            this.groupBox1.Controls.Add(this.rad_orden);
            this.groupBox1.Controls.Add(this.rad_customer_name);
            this.groupBox1.Controls.Add(this.rad_id_customer);
            this.groupBox1.Location = new System.Drawing.Point(312, 449);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(150, 115);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Busqueda por:";
            // 
            // rad_fecha
            // 
            this.rad_fecha.AutoSize = true;
            this.rad_fecha.Location = new System.Drawing.Point(21, 80);
            this.rad_fecha.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rad_fecha.Name = "rad_fecha";
            this.rad_fecha.Size = new System.Drawing.Size(55, 17);
            this.rad_fecha.TabIndex = 3;
            this.rad_fecha.Text = "Fecha";
            this.rad_fecha.UseVisualStyleBackColor = true;
            this.rad_fecha.CheckedChanged += new System.EventHandler(this.Rad_fecha_CheckedChanged);
            // 
            // rad_orden
            // 
            this.rad_orden.AutoSize = true;
            this.rad_orden.Checked = true;
            this.rad_orden.Location = new System.Drawing.Point(21, 30);
            this.rad_orden.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rad_orden.Name = "rad_orden";
            this.rad_orden.Size = new System.Drawing.Size(94, 17);
            this.rad_orden.TabIndex = 2;
            this.rad_orden.TabStop = true;
            this.rad_orden.Text = "Numero Orden";
            this.rad_orden.UseVisualStyleBackColor = true;
            // 
            // rad_customer_name
            // 
            this.rad_customer_name.AutoSize = true;
            this.rad_customer_name.Location = new System.Drawing.Point(21, 63);
            this.rad_customer_name.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rad_customer_name.Name = "rad_customer_name";
            this.rad_customer_name.Size = new System.Drawing.Size(100, 17);
            this.rad_customer_name.TabIndex = 1;
            this.rad_customer_name.Text = "Customer Name";
            this.rad_customer_name.UseVisualStyleBackColor = true;
            // 
            // rad_id_customer
            // 
            this.rad_id_customer.AutoSize = true;
            this.rad_id_customer.Location = new System.Drawing.Point(21, 46);
            this.rad_id_customer.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rad_id_customer.Name = "rad_id_customer";
            this.rad_id_customer.Size = new System.Drawing.Size(84, 17);
            this.rad_id_customer.TabIndex = 0;
            this.rad_id_customer.Text = "Id. Customer";
            this.rad_id_customer.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 433);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Fecha Desde :";
            // 
            // txt_fecha_desde
            // 
            this.txt_fecha_desde.Enabled = false;
            this.txt_fecha_desde.Location = new System.Drawing.Point(9, 449);
            this.txt_fecha_desde.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txt_fecha_desde.Name = "txt_fecha_desde";
            this.txt_fecha_desde.Size = new System.Drawing.Size(209, 20);
            this.txt_fecha_desde.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(7, 467);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Fecha Hasta :";
            // 
            // txt_fecha_hasta
            // 
            this.txt_fecha_hasta.Enabled = false;
            this.txt_fecha_hasta.Location = new System.Drawing.Point(9, 483);
            this.txt_fecha_hasta.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txt_fecha_hasta.Name = "txt_fecha_hasta";
            this.txt_fecha_hasta.Size = new System.Drawing.Size(209, 20);
            this.txt_fecha_hasta.TabIndex = 9;
            // 
            // CONTADOR_REGISTRO
            // 
            this.CONTADOR_REGISTRO.AutoSize = true;
            this.CONTADOR_REGISTRO.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CONTADOR_REGISTRO.Location = new System.Drawing.Point(7, 587);
            this.CONTADOR_REGISTRO.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.CONTADOR_REGISTRO.Name = "CONTADOR_REGISTRO";
            this.CONTADOR_REGISTRO.Size = new System.Drawing.Size(94, 13);
            this.CONTADOR_REGISTRO.TabIndex = 10;
            this.CONTADOR_REGISTRO.Text = "Registro 0 de 0";
            // 
            // bot_buscar
            // 
            this.bot_buscar.Location = new System.Drawing.Point(9, 506);
            this.bot_buscar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.bot_buscar.Name = "bot_buscar";
            this.bot_buscar.Size = new System.Drawing.Size(56, 22);
            this.bot_buscar.TabIndex = 11;
            this.bot_buscar.Text = "BUSCAR";
            this.bot_buscar.UseVisualStyleBackColor = true;
            this.bot_buscar.Click += new System.EventHandler(this.Bot_buscar_Click);
            // 
            // FrmBuscarOrdenes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 604);
            this.Controls.Add(this.bot_buscar);
            this.Controls.Add(this.CONTADOR_REGISTRO);
            this.Controls.Add(this.txt_fecha_hasta);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_fecha_desde);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grid_ordenes);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_buscar);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FrmBuscarOrdenes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Formulario para buscar Ordenes";
            this.Load += new System.EventHandler(this.FrmBuscarOrdenes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grid_ordenes)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_buscar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView grid_ordenes;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rad_customer_name;
        private System.Windows.Forms.RadioButton rad_id_customer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker txt_fecha_desde;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker txt_fecha_hasta;
        private System.Windows.Forms.Label CONTADOR_REGISTRO;
        private System.Windows.Forms.RadioButton rad_orden;
        private System.Windows.Forms.Button bot_buscar;
        private System.Windows.Forms.RadioButton rad_fecha;
    }
}