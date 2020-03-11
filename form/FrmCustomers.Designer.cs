namespace RitramaAPP
{
    partial class FrmCustomers
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCustomers));
            this.txt_customer_id = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_CustomerName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_category = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_customers_direcc = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_customer_email = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.BOT_PRIMERO = new System.Windows.Forms.ToolStripButton();
            this.BOT_ANTERIOR = new System.Windows.Forms.ToolStripButton();
            this.BOT_SIGUIENTE = new System.Windows.Forms.ToolStripButton();
            this.BOT_ULTIMO = new System.Windows.Forms.ToolStripButton();
            this.BOT_NUEVO = new System.Windows.Forms.ToolStripButton();
            this.BOT_CANCEL = new System.Windows.Forms.ToolStripButton();
            this.BOT_GUARDAR = new System.Windows.Forms.ToolStripButton();
            this.BOT_UPDATE = new System.Windows.Forms.ToolStripButton();
            this.BOT_BUSCAR = new System.Windows.Forms.ToolStripButton();
            this.LABEL_CONTADOR_REGISTRO = new System.Windows.Forms.Label();
            this.CHK_ANULADO = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_phone = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_customer_id
            // 
            this.txt_customer_id.Location = new System.Drawing.Point(28, 160);
            this.txt_customer_id.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_customer_id.Name = "txt_customer_id";
            this.txt_customer_id.ReadOnly = true;
            this.txt_customer_id.Size = new System.Drawing.Size(100, 22);
            this.txt_customer_id.TabIndex = 0;
            this.txt_customer_id.Validating += new System.ComponentModel.CancelEventHandler(this.Txt_customer_id_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(28, 192);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Customer Name:";
            // 
            // txt_CustomerName
            // 
            this.txt_CustomerName.Location = new System.Drawing.Point(28, 214);
            this.txt_CustomerName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_CustomerName.Name = "txt_CustomerName";
            this.txt_CustomerName.ReadOnly = true;
            this.txt_CustomerName.Size = new System.Drawing.Size(492, 22);
            this.txt_CustomerName.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(31, 254);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Categoria :";
            // 
            // txt_category
            // 
            this.txt_category.Location = new System.Drawing.Point(31, 277);
            this.txt_category.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_category.Name = "txt_category";
            this.txt_category.ReadOnly = true;
            this.txt_category.Size = new System.Drawing.Size(287, 22);
            this.txt_category.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(31, 311);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Direccion :";
            // 
            // txt_customers_direcc
            // 
            this.txt_customers_direcc.Location = new System.Drawing.Point(31, 335);
            this.txt_customers_direcc.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_customers_direcc.Name = "txt_customers_direcc";
            this.txt_customers_direcc.ReadOnly = true;
            this.txt_customers_direcc.Size = new System.Drawing.Size(761, 22);
            this.txt_customers_direcc.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(31, 373);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(153, 17);
            this.label5.TabIndex = 9;
            this.label5.Text = "Correo Electronico :";
            // 
            // txt_customer_email
            // 
            this.txt_customer_email.Location = new System.Drawing.Point(31, 396);
            this.txt_customer_email.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_customer_email.Name = "txt_customer_email";
            this.txt_customer_email.ReadOnly = true;
            this.txt_customer_email.Size = new System.Drawing.Size(287, 22);
            this.txt_customer_email.TabIndex = 8;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(343, 22);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(135, 29);
            this.label15.TabIndex = 0;
            this.label15.Text = "CLIENTES";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label15);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(852, 80);
            this.panel1.TabIndex = 35;
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BOT_PRIMERO,
            this.BOT_ANTERIOR,
            this.BOT_SIGUIENTE,
            this.BOT_ULTIMO,
            this.BOT_NUEVO,
            this.BOT_CANCEL,
            this.BOT_GUARDAR,
            this.BOT_UPDATE,
            this.BOT_BUSCAR});
            this.toolStrip1.Location = new System.Drawing.Point(0, 80);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(852, 28);
            this.toolStrip1.TabIndex = 40;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.ToolStrip1_ItemClicked);
            // 
            // BOT_PRIMERO
            // 
            this.BOT_PRIMERO.AutoSize = false;
            this.BOT_PRIMERO.Image = ((System.Drawing.Image)(resources.GetObject("BOT_PRIMERO.Image")));
            this.BOT_PRIMERO.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BOT_PRIMERO.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BOT_PRIMERO.Name = "BOT_PRIMERO";
            this.BOT_PRIMERO.Size = new System.Drawing.Size(80, 25);
            this.BOT_PRIMERO.Text = "Primero";
            this.BOT_PRIMERO.Click += new System.EventHandler(this.BOT_PRIMERO_Click);
            // 
            // BOT_ANTERIOR
            // 
            this.BOT_ANTERIOR.AutoSize = false;
            this.BOT_ANTERIOR.Image = ((System.Drawing.Image)(resources.GetObject("BOT_ANTERIOR.Image")));
            this.BOT_ANTERIOR.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BOT_ANTERIOR.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BOT_ANTERIOR.Name = "BOT_ANTERIOR";
            this.BOT_ANTERIOR.Size = new System.Drawing.Size(80, 25);
            this.BOT_ANTERIOR.Text = "Anterior";
            this.BOT_ANTERIOR.Click += new System.EventHandler(this.BOT_ANTERIOR_Click);
            // 
            // BOT_SIGUIENTE
            // 
            this.BOT_SIGUIENTE.AutoSize = false;
            this.BOT_SIGUIENTE.Image = ((System.Drawing.Image)(resources.GetObject("BOT_SIGUIENTE.Image")));
            this.BOT_SIGUIENTE.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BOT_SIGUIENTE.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BOT_SIGUIENTE.Name = "BOT_SIGUIENTE";
            this.BOT_SIGUIENTE.Size = new System.Drawing.Size(80, 25);
            this.BOT_SIGUIENTE.Text = "Siguien";
            this.BOT_SIGUIENTE.Click += new System.EventHandler(this.BOT_SIGUIENTE_Click);
            // 
            // BOT_ULTIMO
            // 
            this.BOT_ULTIMO.AutoSize = false;
            this.BOT_ULTIMO.Image = ((System.Drawing.Image)(resources.GetObject("BOT_ULTIMO.Image")));
            this.BOT_ULTIMO.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BOT_ULTIMO.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BOT_ULTIMO.Name = "BOT_ULTIMO";
            this.BOT_ULTIMO.Size = new System.Drawing.Size(80, 25);
            this.BOT_ULTIMO.Text = "Ultimo";
            this.BOT_ULTIMO.Click += new System.EventHandler(this.BOT_ULTIMO_Click);
            // 
            // BOT_NUEVO
            // 
            this.BOT_NUEVO.AutoSize = false;
            this.BOT_NUEVO.Image = ((System.Drawing.Image)(resources.GetObject("BOT_NUEVO.Image")));
            this.BOT_NUEVO.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BOT_NUEVO.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BOT_NUEVO.Name = "BOT_NUEVO";
            this.BOT_NUEVO.Size = new System.Drawing.Size(80, 25);
            this.BOT_NUEVO.Text = "Nuevo";
            this.BOT_NUEVO.Click += new System.EventHandler(this.BOT_NUEVO_Click);
            // 
            // BOT_CANCEL
            // 
            this.BOT_CANCEL.AutoSize = false;
            this.BOT_CANCEL.Enabled = false;
            this.BOT_CANCEL.Image = ((System.Drawing.Image)(resources.GetObject("BOT_CANCEL.Image")));
            this.BOT_CANCEL.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BOT_CANCEL.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BOT_CANCEL.Name = "BOT_CANCEL";
            this.BOT_CANCEL.Size = new System.Drawing.Size(80, 25);
            this.BOT_CANCEL.Text = "Cancel";
            this.BOT_CANCEL.Click += new System.EventHandler(this.BOT_CANCEL_Click);
            // 
            // BOT_GUARDAR
            // 
            this.BOT_GUARDAR.AutoSize = false;
            this.BOT_GUARDAR.Enabled = false;
            this.BOT_GUARDAR.Image = ((System.Drawing.Image)(resources.GetObject("BOT_GUARDAR.Image")));
            this.BOT_GUARDAR.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BOT_GUARDAR.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BOT_GUARDAR.Name = "BOT_GUARDAR";
            this.BOT_GUARDAR.Size = new System.Drawing.Size(80, 25);
            this.BOT_GUARDAR.Text = "Grabar";
            this.BOT_GUARDAR.Click += new System.EventHandler(this.BOT_GUARDAR_Click);
            // 
            // BOT_UPDATE
            // 
            this.BOT_UPDATE.AutoSize = false;
            this.BOT_UPDATE.Image = ((System.Drawing.Image)(resources.GetObject("BOT_UPDATE.Image")));
            this.BOT_UPDATE.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BOT_UPDATE.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BOT_UPDATE.Name = "BOT_UPDATE";
            this.BOT_UPDATE.Size = new System.Drawing.Size(80, 25);
            this.BOT_UPDATE.Text = "Update";
            this.BOT_UPDATE.Click += new System.EventHandler(this.BOT_UPDATE_Click);
            // 
            // BOT_BUSCAR
            // 
            this.BOT_BUSCAR.AutoSize = false;
            this.BOT_BUSCAR.Image = ((System.Drawing.Image)(resources.GetObject("BOT_BUSCAR.Image")));
            this.BOT_BUSCAR.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BOT_BUSCAR.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BOT_BUSCAR.Name = "BOT_BUSCAR";
            this.BOT_BUSCAR.Size = new System.Drawing.Size(80, 25);
            this.BOT_BUSCAR.Text = "Buscar";
            this.BOT_BUSCAR.Click += new System.EventHandler(this.BOT_BUSCAR_Click);
            // 
            // LABEL_CONTADOR_REGISTRO
            // 
            this.LABEL_CONTADOR_REGISTRO.AutoSize = true;
            this.LABEL_CONTADOR_REGISTRO.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LABEL_CONTADOR_REGISTRO.Location = new System.Drawing.Point(37, 45);
            this.LABEL_CONTADOR_REGISTRO.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LABEL_CONTADOR_REGISTRO.Name = "LABEL_CONTADOR_REGISTRO";
            this.LABEL_CONTADOR_REGISTRO.Size = new System.Drawing.Size(131, 17);
            this.LABEL_CONTADOR_REGISTRO.TabIndex = 41;
            this.LABEL_CONTADOR_REGISTRO.Text = "0 DE 0 Registros";
            // 
            // CHK_ANULADO
            // 
            this.CHK_ANULADO.AutoSize = true;
            this.CHK_ANULADO.Enabled = false;
            this.CHK_ANULADO.Location = new System.Drawing.Point(617, 140);
            this.CHK_ANULADO.Margin = new System.Windows.Forms.Padding(4);
            this.CHK_ANULADO.Name = "CHK_ANULADO";
            this.CHK_ANULADO.Size = new System.Drawing.Size(175, 21);
            this.CHK_ANULADO.TabIndex = 42;
            this.CHK_ANULADO.Text = "Desactivar este Cliente";
            this.CHK_ANULADO.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 142);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 17);
            this.label1.TabIndex = 43;
            this.label1.Text = "Customer ID:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(31, 431);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 17);
            this.label6.TabIndex = 45;
            this.label6.Text = "Telefono :";
            // 
            // txt_phone
            // 
            this.txt_phone.Location = new System.Drawing.Point(31, 454);
            this.txt_phone.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_phone.Name = "txt_phone";
            this.txt_phone.ReadOnly = true;
            this.txt_phone.Size = new System.Drawing.Size(287, 22);
            this.txt_phone.TabIndex = 44;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.LABEL_CONTADOR_REGISTRO);
            this.groupBox1.Location = new System.Drawing.Point(592, 396);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 100);
            this.groupBox1.TabIndex = 46;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Contador de Registro";
            // 
            // FrmCustomers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(852, 642);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txt_phone);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CHK_ANULADO);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt_customer_email);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_customers_direcc);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_category);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_CustomerName);
            this.Controls.Add(this.txt_customer_id);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FrmCustomers";
            this.Text = "FrmCustomers";
            this.Load += new System.EventHandler(this.FrmCustomers_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_customer_id;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_CustomerName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_category;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_customers_direcc;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_customer_email;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton BOT_PRIMERO;
        private System.Windows.Forms.ToolStripButton BOT_ANTERIOR;
        private System.Windows.Forms.ToolStripButton BOT_SIGUIENTE;
        private System.Windows.Forms.ToolStripButton BOT_ULTIMO;
        private System.Windows.Forms.ToolStripButton BOT_NUEVO;
        private System.Windows.Forms.ToolStripButton BOT_CANCEL;
        private System.Windows.Forms.ToolStripButton BOT_GUARDAR;
        private System.Windows.Forms.ToolStripButton BOT_BUSCAR;
        private System.Windows.Forms.ToolStripButton BOT_UPDATE;
        private System.Windows.Forms.Label LABEL_CONTADOR_REGISTRO;
        private System.Windows.Forms.CheckBox CHK_ANULADO;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_phone;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}