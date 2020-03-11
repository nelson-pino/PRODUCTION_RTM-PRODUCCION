namespace RitramaAPP.form
{
    partial class FrmSincroRecepciones
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grid_item = new System.Windows.Forms.DataGridView();
            this.REGISTROS_TRANSFERIDOS = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.bot_register_all = new System.Windows.Forms.Button();
            this.txt_proveedor_name = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.bot_register_select = new System.Windows.Forms.Button();
            this.bot_search_proveedor = new System.Windows.Forms.Button();
            this.txt_id_proveedor = new System.Windows.Forms.TextBox();
            this.bot_validar = new System.Windows.Forms.Button();
            this.bot_tranferir_data = new System.Windows.Forms.Button();
            this.chk_isvalid = new System.Windows.Forms.CheckBox();
            this.txt_consola = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grid_item)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grid_item
            // 
            this.grid_item.AllowUserToAddRows = false;
            this.grid_item.AllowUserToDeleteRows = false;
            this.grid_item.AllowUserToOrderColumns = true;
            this.grid_item.AllowUserToResizeRows = false;
            this.grid_item.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.grid_item.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grid_item.DefaultCellStyle = dataGridViewCellStyle2;
            this.grid_item.Location = new System.Drawing.Point(9, 10);
            this.grid_item.Margin = new System.Windows.Forms.Padding(2);
            this.grid_item.MultiSelect = false;
            this.grid_item.Name = "grid_item";
            this.grid_item.ReadOnly = true;
            this.grid_item.RowHeadersWidth = 30;
            this.grid_item.RowTemplate.Height = 24;
            this.grid_item.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid_item.Size = new System.Drawing.Size(582, 294);
            this.grid_item.TabIndex = 0;
            this.grid_item.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grid_item_CellClick);
            this.grid_item.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.Grid_item_CellFormatting);
            // 
            // REGISTROS_TRANSFERIDOS
            // 
            this.REGISTROS_TRANSFERIDOS.AutoSize = true;
            this.REGISTROS_TRANSFERIDOS.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.REGISTROS_TRANSFERIDOS.Location = new System.Drawing.Point(18, 616);
            this.REGISTROS_TRANSFERIDOS.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.REGISTROS_TRANSFERIDOS.Name = "REGISTROS_TRANSFERIDOS";
            this.REGISTROS_TRANSFERIDOS.Size = new System.Drawing.Size(174, 13);
            this.REGISTROS_TRANSFERIDOS.TabIndex = 1;
            this.REGISTROS_TRANSFERIDOS.Text = "REGISTRO_TRANSFERIDOS";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.bot_register_all);
            this.groupBox1.Controls.Add(this.txt_proveedor_name);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.bot_register_select);
            this.groupBox1.Controls.Add(this.bot_search_proveedor);
            this.groupBox1.Controls.Add(this.txt_id_proveedor);
            this.groupBox1.Location = new System.Drawing.Point(9, 332);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(256, 163);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos del Proveedor :";
            // 
            // bot_register_all
            // 
            this.bot_register_all.Image = global::RitramaAPP.Properties.Resources.grid;
            this.bot_register_all.Location = new System.Drawing.Point(6, 120);
            this.bot_register_all.Name = "bot_register_all";
            this.bot_register_all.Size = new System.Drawing.Size(177, 37);
            this.bot_register_all.TabIndex = 5;
            this.bot_register_all.Text = "Todos los registros";
            this.bot_register_all.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bot_register_all.UseVisualStyleBackColor = true;
            this.bot_register_all.Click += new System.EventHandler(this.Bot_register_all_Click);
            // 
            // txt_proveedor_name
            // 
            this.txt_proveedor_name.Location = new System.Drawing.Point(4, 59);
            this.txt_proveedor_name.Name = "txt_proveedor_name";
            this.txt_proveedor_name.Size = new System.Drawing.Size(233, 20);
            this.txt_proveedor_name.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nombre del Proveedor";
            // 
            // bot_register_select
            // 
            this.bot_register_select.Image = global::RitramaAPP.Properties.Resources.rowselect;
            this.bot_register_select.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bot_register_select.Location = new System.Drawing.Point(6, 83);
            this.bot_register_select.Name = "bot_register_select";
            this.bot_register_select.Size = new System.Drawing.Size(177, 37);
            this.bot_register_select.TabIndex = 4;
            this.bot_register_select.Text = "Resgistro Seleccionado";
            this.bot_register_select.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bot_register_select.UseVisualStyleBackColor = true;
            this.bot_register_select.Click += new System.EventHandler(this.Bot_register_select_Click);
            // 
            // bot_search_proveedor
            // 
            this.bot_search_proveedor.Location = new System.Drawing.Point(112, 17);
            this.bot_search_proveedor.Name = "bot_search_proveedor";
            this.bot_search_proveedor.Size = new System.Drawing.Size(35, 23);
            this.bot_search_proveedor.TabIndex = 1;
            this.bot_search_proveedor.Text = "...";
            this.bot_search_proveedor.UseVisualStyleBackColor = true;
            this.bot_search_proveedor.Click += new System.EventHandler(this.Bot_search_proveedor_Click);
            // 
            // txt_id_proveedor
            // 
            this.txt_id_proveedor.Location = new System.Drawing.Point(6, 19);
            this.txt_id_proveedor.Name = "txt_id_proveedor";
            this.txt_id_proveedor.Size = new System.Drawing.Size(100, 20);
            this.txt_id_proveedor.TabIndex = 0;
            // 
            // bot_validar
            // 
            this.bot_validar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bot_validar.Image = global::RitramaAPP.Properties.Resources.FILTRO;
            this.bot_validar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bot_validar.Location = new System.Drawing.Point(438, 308);
            this.bot_validar.Margin = new System.Windows.Forms.Padding(2);
            this.bot_validar.Name = "bot_validar";
            this.bot_validar.Size = new System.Drawing.Size(153, 54);
            this.bot_validar.TabIndex = 4;
            this.bot_validar.Text = "Validar Data";
            this.bot_validar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bot_validar.UseVisualStyleBackColor = true;
            this.bot_validar.Click += new System.EventHandler(this.Bot_validar_Click);
            // 
            // bot_tranferir_data
            // 
            this.bot_tranferir_data.Enabled = false;
            this.bot_tranferir_data.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bot_tranferir_data.Image = global::RitramaAPP.Properties.Resources.Upload;
            this.bot_tranferir_data.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bot_tranferir_data.Location = new System.Drawing.Point(438, 366);
            this.bot_tranferir_data.Margin = new System.Windows.Forms.Padding(2);
            this.bot_tranferir_data.Name = "bot_tranferir_data";
            this.bot_tranferir_data.Size = new System.Drawing.Size(153, 54);
            this.bot_tranferir_data.TabIndex = 2;
            this.bot_tranferir_data.Text = "Transferir Data";
            this.bot_tranferir_data.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bot_tranferir_data.UseVisualStyleBackColor = true;
            this.bot_tranferir_data.Click += new System.EventHandler(this.Bot_tranferir_data_Click);
            // 
            // chk_isvalid
            // 
            this.chk_isvalid.AutoSize = true;
            this.chk_isvalid.Enabled = false;
            this.chk_isvalid.Location = new System.Drawing.Point(308, 332);
            this.chk_isvalid.Name = "chk_isvalid";
            this.chk_isvalid.Size = new System.Drawing.Size(103, 17);
            this.chk_isvalid.TabIndex = 5;
            this.chk_isvalid.Text = "Datos Validados";
            this.chk_isvalid.UseVisualStyleBackColor = true;
            // 
            // txt_consola
            // 
            this.txt_consola.Location = new System.Drawing.Point(308, 510);
            this.txt_consola.Multiline = true;
            this.txt_consola.Name = "txt_consola";
            this.txt_consola.Size = new System.Drawing.Size(278, 116);
            this.txt_consola.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(308, 491);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Consola de Sucesos";
            // 
            // FrmSincroRecepciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 638);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_consola);
            this.Controls.Add(this.chk_isvalid);
            this.Controls.Add(this.bot_validar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.bot_tranferir_data);
            this.Controls.Add(this.REGISTROS_TRANSFERIDOS);
            this.Controls.Add(this.grid_item);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmSincroRecepciones";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sincronizacion de data desde la aplicacion movil";
            this.Load += new System.EventHandler(this.FrmSincroRecepciones_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grid_item)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView grid_item;
        private System.Windows.Forms.Label REGISTROS_TRANSFERIDOS;
        private System.Windows.Forms.Button bot_tranferir_data;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button bot_register_all;
        private System.Windows.Forms.Button bot_register_select;
        private System.Windows.Forms.TextBox txt_proveedor_name;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bot_search_proveedor;
        private System.Windows.Forms.TextBox txt_id_proveedor;
        private System.Windows.Forms.Button bot_validar;
        private System.Windows.Forms.CheckBox chk_isvalid;
        private System.Windows.Forms.TextBox txt_consola;
        private System.Windows.Forms.Label label2;
    }
}