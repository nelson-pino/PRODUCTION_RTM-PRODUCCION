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
            this.components = new System.ComponentModel.Container();
            this.txt_product_id = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_product_name = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_referencia = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_code_bar = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_existencia = new System.Windows.Forms.TextBox();
            this.cbo_category = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.RAD_PRODUCTO_MP = new System.Windows.Forms.RadioButton();
            this.RAD_PRODUCTO_PT = new System.Windows.Forms.RadioButton();
            this.label15 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.CHK_ANULADO = new System.Windows.Forms.CheckBox();
            this.LABEL_CONTADOR_REGISTRO = new System.Windows.Forms.Label();
            this.GRUPO_TIPO_PRODUCTO = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_descrip_product = new System.Windows.Forms.TextBox();
            this.bs = new System.Windows.Forms.BindingSource(this.components);
            this.ds = new System.Data.DataSet();
            this.panel1.SuspendLayout();
            this.GRUPO_TIPO_PRODUCTO.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ds)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_product_id
            // 
            this.txt_product_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_product_id.Location = new System.Drawing.Point(25, 68);
            this.txt_product_id.Margin = new System.Windows.Forms.Padding(2);
            this.txt_product_id.Name = "txt_product_id";
            this.txt_product_id.ReadOnly = true;
            this.txt_product_id.Size = new System.Drawing.Size(113, 20);
            this.txt_product_id.TabIndex = 0;
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
            this.label2.Location = new System.Drawing.Point(22, 95);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Product Name:";
            // 
            // txt_product_name
            // 
            this.txt_product_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_product_name.Location = new System.Drawing.Point(25, 111);
            this.txt_product_name.Margin = new System.Windows.Forms.Padding(2);
            this.txt_product_name.Name = "txt_product_name";
            this.txt_product_name.ReadOnly = true;
            this.txt_product_name.Size = new System.Drawing.Size(387, 20);
            this.txt_product_name.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(157, 67);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(28, 22);
            this.button1.TabIndex = 4;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 186);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Referencia:";
            // 
            // txt_referencia
            // 
            this.txt_referencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_referencia.Location = new System.Drawing.Point(25, 203);
            this.txt_referencia.Margin = new System.Windows.Forms.Padding(2);
            this.txt_referencia.Name = "txt_referencia";
            this.txt_referencia.ReadOnly = true;
            this.txt_referencia.Size = new System.Drawing.Size(113, 20);
            this.txt_referencia.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 232);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Codigo de Barra:";
            // 
            // txt_code_bar
            // 
            this.txt_code_bar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_code_bar.Location = new System.Drawing.Point(25, 248);
            this.txt_code_bar.Margin = new System.Windows.Forms.Padding(2);
            this.txt_code_bar.Name = "txt_code_bar";
            this.txt_code_bar.ReadOnly = true;
            this.txt_code_bar.Size = new System.Drawing.Size(113, 20);
            this.txt_code_bar.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 273);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Existencia:";
            // 
            // txt_existencia
            // 
            this.txt_existencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_existencia.Location = new System.Drawing.Point(25, 290);
            this.txt_existencia.Margin = new System.Windows.Forms.Padding(2);
            this.txt_existencia.Name = "txt_existencia";
            this.txt_existencia.ReadOnly = true;
            this.txt_existencia.Size = new System.Drawing.Size(113, 20);
            this.txt_existencia.TabIndex = 9;
            // 
            // cbo_category
            // 
            this.cbo_category.Enabled = false;
            this.cbo_category.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_category.FormattingEnabled = true;
            this.cbo_category.Items.AddRange(new object[] {
            "PAPELES ENTUCADOS",
            "PAPELES NO ENTUCADOS",
            "PAPELES DE COLORES",
            "PAPELES METALIZADOS"});
            this.cbo_category.Location = new System.Drawing.Point(25, 334);
            this.cbo_category.Margin = new System.Windows.Forms.Padding(2);
            this.cbo_category.Name = "cbo_category";
            this.cbo_category.Size = new System.Drawing.Size(228, 21);
            this.cbo_category.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 318);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Categoria:";
            // 
            // RAD_PRODUCTO_MP
            // 
            this.RAD_PRODUCTO_MP.AutoSize = true;
            this.RAD_PRODUCTO_MP.Enabled = false;
            this.RAD_PRODUCTO_MP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RAD_PRODUCTO_MP.Location = new System.Drawing.Point(35, 38);
            this.RAD_PRODUCTO_MP.Margin = new System.Windows.Forms.Padding(2);
            this.RAD_PRODUCTO_MP.Name = "RAD_PRODUCTO_MP";
            this.RAD_PRODUCTO_MP.Size = new System.Drawing.Size(102, 17);
            this.RAD_PRODUCTO_MP.TabIndex = 14;
            this.RAD_PRODUCTO_MP.TabStop = true;
            this.RAD_PRODUCTO_MP.Text = "Materia Prima";
            this.RAD_PRODUCTO_MP.UseVisualStyleBackColor = true;
            // 
            // RAD_PRODUCTO_PT
            // 
            this.RAD_PRODUCTO_PT.AutoSize = true;
            this.RAD_PRODUCTO_PT.Enabled = false;
            this.RAD_PRODUCTO_PT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RAD_PRODUCTO_PT.Location = new System.Drawing.Point(35, 61);
            this.RAD_PRODUCTO_PT.Margin = new System.Windows.Forms.Padding(2);
            this.RAD_PRODUCTO_PT.Name = "RAD_PRODUCTO_PT";
            this.RAD_PRODUCTO_PT.Size = new System.Drawing.Size(139, 17);
            this.RAD_PRODUCTO_PT.TabIndex = 15;
            this.RAD_PRODUCTO_PT.TabStop = true;
            this.RAD_PRODUCTO_PT.Text = "Producto Terminado";
            this.RAD_PRODUCTO_PT.UseVisualStyleBackColor = true;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(234, 9);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(140, 25);
            this.label15.TabIndex = 0;
            this.label15.Text = "PRODUCTOS";
            this.label15.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Window;
            this.panel1.Controls.Add(this.label15);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(600, 50);
            this.panel1.TabIndex = 35;
            // 
            // CHK_ANULADO
            // 
            this.CHK_ANULADO.AutoSize = true;
            this.CHK_ANULADO.Enabled = false;
            this.CHK_ANULADO.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CHK_ANULADO.Location = new System.Drawing.Point(417, 67);
            this.CHK_ANULADO.Name = "CHK_ANULADO";
            this.CHK_ANULADO.Size = new System.Drawing.Size(173, 17);
            this.CHK_ANULADO.TabIndex = 36;
            this.CHK_ANULADO.Text = "Desactivar este producto.";
            this.CHK_ANULADO.UseVisualStyleBackColor = true;
            // 
            // LABEL_CONTADOR_REGISTRO
            // 
            this.LABEL_CONTADOR_REGISTRO.AutoSize = true;
            this.LABEL_CONTADOR_REGISTRO.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LABEL_CONTADOR_REGISTRO.Location = new System.Drawing.Point(494, 344);
            this.LABEL_CONTADOR_REGISTRO.Name = "LABEL_CONTADOR_REGISTRO";
            this.LABEL_CONTADOR_REGISTRO.Size = new System.Drawing.Size(94, 13);
            this.LABEL_CONTADOR_REGISTRO.TabIndex = 38;
            this.LABEL_CONTADOR_REGISTRO.Text = "Registro 0 de 0";
            // 
            // GRUPO_TIPO_PRODUCTO
            // 
            this.GRUPO_TIPO_PRODUCTO.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.GRUPO_TIPO_PRODUCTO.Controls.Add(this.RAD_PRODUCTO_MP);
            this.GRUPO_TIPO_PRODUCTO.Controls.Add(this.RAD_PRODUCTO_PT);
            this.GRUPO_TIPO_PRODUCTO.Location = new System.Drawing.Point(143, 203);
            this.GRUPO_TIPO_PRODUCTO.Name = "GRUPO_TIPO_PRODUCTO";
            this.GRUPO_TIPO_PRODUCTO.Size = new System.Drawing.Size(200, 107);
            this.GRUPO_TIPO_PRODUCTO.TabIndex = 39;
            this.GRUPO_TIPO_PRODUCTO.TabStop = false;
            this.GRUPO_TIPO_PRODUCTO.Text = "Tipo de Producto";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(22, 140);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 13);
            this.label7.TabIndex = 41;
            this.label7.Text = "Descripcion :";
            // 
            // txt_descrip_product
            // 
            this.txt_descrip_product.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_descrip_product.Location = new System.Drawing.Point(25, 156);
            this.txt_descrip_product.Margin = new System.Windows.Forms.Padding(2);
            this.txt_descrip_product.Name = "txt_descrip_product";
            this.txt_descrip_product.ReadOnly = true;
            this.txt_descrip_product.Size = new System.Drawing.Size(387, 20);
            this.txt_descrip_product.TabIndex = 40;
            // 
            // bs
            // 
            // 
            // ds
            // 
            this.ds.DataSetName = "NewDataSet";
            // 
            // FrmProducts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txt_descrip_product);
            this.Controls.Add(this.GRUPO_TIPO_PRODUCTO);
            this.Controls.Add(this.LABEL_CONTADOR_REGISTRO);
            this.Controls.Add(this.CHK_ANULADO);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cbo_category);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt_existencia);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_code_bar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_referencia);
            this.Controls.Add(this.button1);
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
            this.GRUPO_TIPO_PRODUCTO.ResumeLayout(false);
            this.GRUPO_TIPO_PRODUCTO.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ds)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_product_id;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_product_name;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_referencia;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_code_bar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_existencia;
        private System.Windows.Forms.ComboBox cbo_category;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton RAD_PRODUCTO_MP;
        private System.Windows.Forms.RadioButton RAD_PRODUCTO_PT;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox CHK_ANULADO;
        private System.Windows.Forms.Label LABEL_CONTADOR_REGISTRO;
        private System.Windows.Forms.GroupBox GRUPO_TIPO_PRODUCTO;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_descrip_product;
        internal System.Windows.Forms.BindingSource bs;
        internal System.Data.DataSet ds;
    }
}