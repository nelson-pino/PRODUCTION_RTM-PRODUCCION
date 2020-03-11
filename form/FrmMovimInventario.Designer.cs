namespace RitramaAPP.form
{
    partial class FrmMovimInventario
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.bot_buscar = new System.Windows.Forms.Button();
            this.product_tipo = new System.Windows.Forms.Label();
            this.product_name = new System.Windows.Forms.Label();
            this.product_id = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.TXT_COUNT_ENT = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TOTAL_LEN_ENT = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.grid_salidas = new System.Windows.Forms.DataGridView();
            this.grid_entradas = new System.Windows.Forms.DataGridView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.TXT_COUNT_SAL = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TXT_LENGHT_SAL = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_salidas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid_entradas)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Controls.Add(this.bot_buscar);
            this.panel1.Controls.Add(this.product_tipo);
            this.panel1.Controls.Add(this.product_name);
            this.panel1.Controls.Add(this.product_id);
            this.panel1.Location = new System.Drawing.Point(3, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(809, 67);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // bot_buscar
            // 
            this.bot_buscar.Location = new System.Drawing.Point(703, 19);
            this.bot_buscar.Name = "bot_buscar";
            this.bot_buscar.Size = new System.Drawing.Size(75, 23);
            this.bot_buscar.TabIndex = 4;
            this.bot_buscar.Text = "Buscar";
            this.bot_buscar.UseVisualStyleBackColor = true;
            this.bot_buscar.Click += new System.EventHandler(this.bot_buscar_Click);
            // 
            // product_tipo
            // 
            this.product_tipo.AutoSize = true;
            this.product_tipo.Location = new System.Drawing.Point(21, 37);
            this.product_tipo.Name = "product_tipo";
            this.product_tipo.Size = new System.Drawing.Size(99, 13);
            this.product_tipo.TabIndex = 2;
            this.product_tipo.Text = "TIPO_PRODUCTO";
            // 
            // product_name
            // 
            this.product_name.AutoSize = true;
            this.product_name.Location = new System.Drawing.Point(21, 24);
            this.product_name.Name = "product_name";
            this.product_name.Size = new System.Drawing.Size(121, 13);
            this.product_name.TabIndex = 1;
            this.product_name.Text = "NOMBRE_PRODUCTO";
            // 
            // product_id
            // 
            this.product_id.AutoSize = true;
            this.product_id.Location = new System.Drawing.Point(21, 9);
            this.product_id.Name = "product_id";
            this.product_id.Size = new System.Drawing.Size(72, 13);
            this.product_id.TabIndex = 0;
            this.product_id.Text = "PRODICT_ID";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.TXT_COUNT_SAL);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.TXT_LENGHT_SAL);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.TXT_COUNT_ENT);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.TOTAL_LEN_ENT);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.grid_salidas);
            this.tabPage1.Controls.Add(this.grid_entradas);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(805, 461);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Movimientos";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // TXT_COUNT_ENT
            // 
            this.TXT_COUNT_ENT.Location = new System.Drawing.Point(287, 184);
            this.TXT_COUNT_ENT.Name = "TXT_COUNT_ENT";
            this.TXT_COUNT_ENT.Size = new System.Drawing.Size(100, 20);
            this.TXT_COUNT_ENT.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(199, 187);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Total Entradas :";
            // 
            // TOTAL_LEN_ENT
            // 
            this.TOTAL_LEN_ENT.Location = new System.Drawing.Point(508, 184);
            this.TOTAL_LEN_ENT.Name = "TOTAL_LEN_ENT";
            this.TOTAL_LEN_ENT.Size = new System.Drawing.Size(100, 20);
            this.TOTAL_LEN_ENT.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(438, 187);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Total Lenght :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 215);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "SALIDAS :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "ENTRADAS :";
            // 
            // grid_salidas
            // 
            this.grid_salidas.AllowUserToAddRows = false;
            this.grid_salidas.AllowUserToDeleteRows = false;
            this.grid_salidas.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.grid_salidas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_salidas.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.grid_salidas.Location = new System.Drawing.Point(5, 231);
            this.grid_salidas.Name = "grid_salidas";
            this.grid_salidas.Size = new System.Drawing.Size(793, 141);
            this.grid_salidas.TabIndex = 1;
            this.grid_salidas.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.grid_salidas_CellMouseDoubleClick);
            // 
            // grid_entradas
            // 
            this.grid_entradas.AllowUserToAddRows = false;
            this.grid_entradas.AllowUserToDeleteRows = false;
            this.grid_entradas.AllowUserToResizeRows = false;
            this.grid_entradas.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.grid_entradas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_entradas.Location = new System.Drawing.Point(6, 29);
            this.grid_entradas.Name = "grid_entradas";
            this.grid_entradas.ReadOnly = true;
            this.grid_entradas.RowHeadersWidth = 25;
            this.grid_entradas.Size = new System.Drawing.Size(793, 143);
            this.grid_entradas.TabIndex = 0;
            this.grid_entradas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_entradas_CellClick);
            this.grid_entradas.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.grid_entradas_CellMouseDoubleClick);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(3, 73);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(813, 487);
            this.tabControl1.TabIndex = 0;
            // 
            // TXT_COUNT_SAL
            // 
            this.TXT_COUNT_SAL.Location = new System.Drawing.Point(287, 389);
            this.TXT_COUNT_SAL.Name = "TXT_COUNT_SAL";
            this.TXT_COUNT_SAL.Size = new System.Drawing.Size(100, 20);
            this.TXT_COUNT_SAL.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(199, 392);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Total Salidas :";
            // 
            // TXT_LENGHT_SAL
            // 
            this.TXT_LENGHT_SAL.Location = new System.Drawing.Point(488, 389);
            this.TXT_LENGHT_SAL.Name = "TXT_LENGHT_SAL";
            this.TXT_LENGHT_SAL.Size = new System.Drawing.Size(100, 20);
            this.TXT_LENGHT_SAL.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(409, 392);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Total Lenght :";
            // 
            // FrmMovimInventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(822, 561);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tabControl1);
            this.Name = "FrmMovimInventario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pantalla de movimiento de Inventarios";
            this.Load += new System.EventHandler(this.FrmMovimInventario_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_salidas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid_entradas)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label product_name;
        private System.Windows.Forms.Label product_id;
        private System.Windows.Forms.Label product_tipo;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView grid_salidas;
        private System.Windows.Forms.DataGridView grid_entradas;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Button bot_buscar;
        private System.Windows.Forms.TextBox TOTAL_LEN_ENT;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TXT_COUNT_ENT;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TXT_COUNT_SAL;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TXT_LENGHT_SAL;
        private System.Windows.Forms.Label label6;
    }
}