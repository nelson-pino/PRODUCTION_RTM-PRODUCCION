namespace RitramaAPP.form
{
    partial class SeleccionCamion
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.RA_PLACAS = new System.Windows.Forms.RadioButton();
            this.RA_CODIGO = new System.Windows.Forms.RadioButton();
            this.txt_buscar = new System.Windows.Forms.TextBox();
            this.grid_items = new System.Windows.Forms.DataGridView();
            this.CONTADOR_REGISTROS = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_items)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.RA_PLACAS);
            this.groupBox1.Controls.Add(this.RA_CODIGO);
            this.groupBox1.Location = new System.Drawing.Point(161, 365);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(152, 100);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros de Busqueda";
            // 
            // RA_PLACAS
            // 
            this.RA_PLACAS.AutoSize = true;
            this.RA_PLACAS.Location = new System.Drawing.Point(30, 51);
            this.RA_PLACAS.Name = "RA_PLACAS";
            this.RA_PLACAS.Size = new System.Drawing.Size(60, 17);
            this.RA_PLACAS.TabIndex = 1;
            this.RA_PLACAS.TabStop = true;
            this.RA_PLACAS.Text = "Modelo";
            this.RA_PLACAS.UseVisualStyleBackColor = true;
            // 
            // RA_CODIGO
            // 
            this.RA_CODIGO.AutoSize = true;
            this.RA_CODIGO.Checked = true;
            this.RA_CODIGO.Location = new System.Drawing.Point(30, 28);
            this.RA_CODIGO.Name = "RA_CODIGO";
            this.RA_CODIGO.Size = new System.Drawing.Size(57, 17);
            this.RA_CODIGO.TabIndex = 0;
            this.RA_CODIGO.TabStop = true;
            this.RA_CODIGO.Text = "Placas";
            this.RA_CODIGO.UseVisualStyleBackColor = true;
            // 
            // txt_buscar
            // 
            this.txt_buscar.Location = new System.Drawing.Point(12, 12);
            this.txt_buscar.Name = "txt_buscar";
            this.txt_buscar.Size = new System.Drawing.Size(311, 20);
            this.txt_buscar.TabIndex = 5;
            this.txt_buscar.TextChanged += new System.EventHandler(this.txt_buscar_TextChanged);
            // 
            // grid_items
            // 
            this.grid_items.AllowUserToAddRows = false;
            this.grid_items.AllowUserToDeleteRows = false;
            this.grid_items.AllowUserToResizeRows = false;
            this.grid_items.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.grid_items.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_items.Location = new System.Drawing.Point(12, 36);
            this.grid_items.MultiSelect = false;
            this.grid_items.Name = "grid_items";
            this.grid_items.ReadOnly = true;
            this.grid_items.RowHeadersWidth = 25;
            this.grid_items.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid_items.Size = new System.Drawing.Size(301, 323);
            this.grid_items.TabIndex = 4;
            this.grid_items.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.grid_items_CellMouseDoubleClick);
            // 
            // CONTADOR_REGISTROS
            // 
            this.CONTADOR_REGISTROS.AutoSize = true;
            this.CONTADOR_REGISTROS.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CONTADOR_REGISTROS.Location = new System.Drawing.Point(9, 378);
            this.CONTADOR_REGISTROS.Name = "CONTADOR_REGISTROS";
            this.CONTADOR_REGISTROS.Size = new System.Drawing.Size(140, 13);
            this.CONTADOR_REGISTROS.TabIndex = 7;
            this.CONTADOR_REGISTROS.Text = "NUMERO_REGISTROS";
            // 
            // SeleccionCamion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 499);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txt_buscar);
            this.Controls.Add(this.grid_items);
            this.Controls.Add(this.CONTADOR_REGISTROS);
            this.Name = "SeleccionCamion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SeleccionCamion";
            this.Load += new System.EventHandler(this.SeleccionCamion_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_items)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton RA_PLACAS;
        private System.Windows.Forms.RadioButton RA_CODIGO;
        private System.Windows.Forms.TextBox txt_buscar;
        private System.Windows.Forms.DataGridView grid_items;
        private System.Windows.Forms.Label CONTADOR_REGISTROS;
    }
}