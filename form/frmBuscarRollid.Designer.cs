namespace RitramaAPP.form
{
    partial class FrmBuscarRollid
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
            this.TXT_BUSCAR = new System.Windows.Forms.TextBox();
            this.Grid_Items = new System.Windows.Forms.DataGridView();
            this.CONTADOR_REGISTRO = new System.Windows.Forms.Label();
            this.RAD_ROLLID = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ra_number_rc = new System.Windows.Forms.RadioButton();
            this.RAD_NOMBRE_PRODUCTO = new System.Windows.Forms.RadioButton();
            this.chk_rebobinado = new System.Windows.Forms.CheckBox();
            this.BOT_ACTUALIZAR_REBO = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_Items)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TXT_BUSCAR
            // 
            this.TXT_BUSCAR.Location = new System.Drawing.Point(12, 28);
            this.TXT_BUSCAR.Name = "TXT_BUSCAR";
            this.TXT_BUSCAR.Size = new System.Drawing.Size(677, 20);
            this.TXT_BUSCAR.TabIndex = 0;
            this.TXT_BUSCAR.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // Grid_Items
            // 
            this.Grid_Items.AllowUserToAddRows = false;
            this.Grid_Items.AllowUserToDeleteRows = false;
            this.Grid_Items.AllowUserToResizeRows = false;
            this.Grid_Items.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.Grid_Items.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid_Items.Location = new System.Drawing.Point(12, 54);
            this.Grid_Items.MultiSelect = false;
            this.Grid_Items.Name = "Grid_Items";
            this.Grid_Items.ReadOnly = true;
            this.Grid_Items.RowHeadersWidth = 28;
            this.Grid_Items.Size = new System.Drawing.Size(677, 283);
            this.Grid_Items.TabIndex = 1;
            this.Grid_Items.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.Grid_Items_CellMouseDoubleClick);
            // 
            // CONTADOR_REGISTRO
            // 
            this.CONTADOR_REGISTRO.AutoSize = true;
            this.CONTADOR_REGISTRO.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CONTADOR_REGISTRO.Location = new System.Drawing.Point(12, 343);
            this.CONTADOR_REGISTRO.Name = "CONTADOR_REGISTRO";
            this.CONTADOR_REGISTRO.Size = new System.Drawing.Size(147, 13);
            this.CONTADOR_REGISTRO.TabIndex = 2;
            this.CONTADOR_REGISTRO.Text = "CONTADOR_REGISTRO";
            // 
            // RAD_ROLLID
            // 
            this.RAD_ROLLID.AutoSize = true;
            this.RAD_ROLLID.Checked = true;
            this.RAD_ROLLID.Location = new System.Drawing.Point(16, 29);
            this.RAD_ROLLID.Name = "RAD_ROLLID";
            this.RAD_ROLLID.Size = new System.Drawing.Size(58, 17);
            this.RAD_ROLLID.TabIndex = 3;
            this.RAD_ROLLID.TabStop = true;
            this.RAD_ROLLID.Text = "Roll Id.";
            this.RAD_ROLLID.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ra_number_rc);
            this.groupBox1.Controls.Add(this.RAD_NOMBRE_PRODUCTO);
            this.groupBox1.Controls.Add(this.RAD_ROLLID);
            this.groupBox1.Location = new System.Drawing.Point(489, 343);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 100);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros de Busqueda :";
            // 
            // ra_number_rc
            // 
            this.ra_number_rc.AutoSize = true;
            this.ra_number_rc.Location = new System.Drawing.Point(16, 62);
            this.ra_number_rc.Name = "ra_number_rc";
            this.ra_number_rc.Size = new System.Drawing.Size(80, 17);
            this.ra_number_rc.TabIndex = 5;
            this.ra_number_rc.Text = "Numero RC";
            this.ra_number_rc.UseVisualStyleBackColor = true;
            // 
            // RAD_NOMBRE_PRODUCTO
            // 
            this.RAD_NOMBRE_PRODUCTO.AutoSize = true;
            this.RAD_NOMBRE_PRODUCTO.Location = new System.Drawing.Point(16, 46);
            this.RAD_NOMBRE_PRODUCTO.Name = "RAD_NOMBRE_PRODUCTO";
            this.RAD_NOMBRE_PRODUCTO.Size = new System.Drawing.Size(128, 17);
            this.RAD_NOMBRE_PRODUCTO.TabIndex = 4;
            this.RAD_NOMBRE_PRODUCTO.Text = "Nombre del Producto.";
            this.RAD_NOMBRE_PRODUCTO.UseVisualStyleBackColor = true;
            // 
            // chk_rebobinado
            // 
            this.chk_rebobinado.AutoSize = true;
            this.chk_rebobinado.Location = new System.Drawing.Point(58, 384);
            this.chk_rebobinado.Name = "chk_rebobinado";
            this.chk_rebobinado.Size = new System.Drawing.Size(131, 17);
            this.chk_rebobinado.TabIndex = 5;
            this.chk_rebobinado.Text = "Orden de Rebobinado";
            this.chk_rebobinado.UseVisualStyleBackColor = true;
            // 
            // BOT_ACTUALIZAR_REBO
            // 
            this.BOT_ACTUALIZAR_REBO.Location = new System.Drawing.Point(58, 407);
            this.BOT_ACTUALIZAR_REBO.Name = "BOT_ACTUALIZAR_REBO";
            this.BOT_ACTUALIZAR_REBO.Size = new System.Drawing.Size(131, 23);
            this.BOT_ACTUALIZAR_REBO.TabIndex = 6;
            this.BOT_ACTUALIZAR_REBO.Text = "Actualizar";
            this.BOT_ACTUALIZAR_REBO.UseVisualStyleBackColor = true;
            this.BOT_ACTUALIZAR_REBO.Click += new System.EventHandler(this.BOT_ACTUALIZAR_REBO_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(272, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Introduzca la palabra clave para realizar una busqueda :";
            // 
            // FrmBuscarRollid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(701, 453);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BOT_ACTUALIZAR_REBO);
            this.Controls.Add(this.chk_rebobinado);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.CONTADOR_REGISTRO);
            this.Controls.Add(this.Grid_Items);
            this.Controls.Add(this.TXT_BUSCAR);
            this.Name = "FrmBuscarRollid";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Buscar Materia Prima de Master Roll";
            this.Load += new System.EventHandler(this.FrmBuscarRollid_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Grid_Items)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TXT_BUSCAR;
        private System.Windows.Forms.DataGridView Grid_Items;
        private System.Windows.Forms.Label CONTADOR_REGISTRO;
        private System.Windows.Forms.RadioButton RAD_ROLLID;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton RAD_NOMBRE_PRODUCTO;
        private System.Windows.Forms.CheckBox chk_rebobinado;
        private System.Windows.Forms.Button BOT_ACTUALIZAR_REBO;
        private System.Windows.Forms.RadioButton ra_number_rc;
        private System.Windows.Forms.Label label1;
    }
}