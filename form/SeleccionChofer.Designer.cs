namespace RitramaAPP.form
{
    partial class SeleccionChofer
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
            this.label1 = new System.Windows.Forms.Label();
            this.txt_buscar = new System.Windows.Forms.TextBox();
            this.grid_items = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rad_producto = new System.Windows.Forms.RadioButton();
            this.rad_codigo = new System.Windows.Forms.RadioButton();
            this.lbl_contador_registros = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grid_items)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(5, 6);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "busqueda por:";
            // 
            // txt_buscar
            // 
            this.txt_buscar.Location = new System.Drawing.Point(4, 25);
            this.txt_buscar.Margin = new System.Windows.Forms.Padding(2);
            this.txt_buscar.Name = "txt_buscar";
            this.txt_buscar.Size = new System.Drawing.Size(370, 20);
            this.txt_buscar.TabIndex = 3;
            // 
            // grid_items
            // 
            this.grid_items.AllowUserToAddRows = false;
            this.grid_items.AllowUserToDeleteRows = false;
            this.grid_items.AllowUserToResizeRows = false;
            this.grid_items.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.grid_items.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_items.Location = new System.Drawing.Point(2, 49);
            this.grid_items.Margin = new System.Windows.Forms.Padding(2);
            this.grid_items.Name = "grid_items";
            this.grid_items.ReadOnly = true;
            this.grid_items.RowHeadersWidth = 35;
            this.grid_items.RowTemplate.Height = 24;
            this.grid_items.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.grid_items.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid_items.Size = new System.Drawing.Size(369, 324);
            this.grid_items.TabIndex = 4;
            this.grid_items.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.grid_items_CellMouseDoubleClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rad_producto);
            this.groupBox1.Controls.Add(this.rad_codigo);
            this.groupBox1.Location = new System.Drawing.Point(221, 377);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(150, 102);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Buscar por:";
            // 
            // rad_producto
            // 
            this.rad_producto.AutoSize = true;
            this.rad_producto.Checked = true;
            this.rad_producto.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rad_producto.Location = new System.Drawing.Point(22, 45);
            this.rad_producto.Margin = new System.Windows.Forms.Padding(2);
            this.rad_producto.Name = "rad_producto";
            this.rad_producto.Size = new System.Drawing.Size(105, 17);
            this.rad_producto.TabIndex = 1;
            this.rad_producto.TabStop = true;
            this.rad_producto.Text = "Product Name";
            this.rad_producto.UseVisualStyleBackColor = true;
            // 
            // rad_codigo
            // 
            this.rad_codigo.AutoSize = true;
            this.rad_codigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rad_codigo.Location = new System.Drawing.Point(22, 23);
            this.rad_codigo.Margin = new System.Windows.Forms.Padding(2);
            this.rad_codigo.Name = "rad_codigo";
            this.rad_codigo.Size = new System.Drawing.Size(64, 17);
            this.rad_codigo.TabIndex = 0;
            this.rad_codigo.Text = "Codigo";
            this.rad_codigo.UseVisualStyleBackColor = true;
            // 
            // lbl_contador_registros
            // 
            this.lbl_contador_registros.AutoSize = true;
            this.lbl_contador_registros.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_contador_registros.Location = new System.Drawing.Point(29, 422);
            this.lbl_contador_registros.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_contador_registros.Name = "lbl_contador_registros";
            this.lbl_contador_registros.Size = new System.Drawing.Size(95, 13);
            this.lbl_contador_registros.TabIndex = 8;
            this.lbl_contador_registros.Text = "0 de 0 registros";
            // 
            // SeleccionChofer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 490);
            this.Controls.Add(this.lbl_contador_registros);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_buscar);
            this.Controls.Add(this.grid_items);
            this.Name = "SeleccionChofer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SeleccionChofer";
            this.Load += new System.EventHandler(this.SeleccionChofer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grid_items)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_buscar;
        private System.Windows.Forms.DataGridView grid_items;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rad_producto;
        private System.Windows.Forms.RadioButton rad_codigo;
        private System.Windows.Forms.Label lbl_contador_registros;
    }
}