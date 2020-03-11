namespace RitramaAPP
{
    partial class FrmSupply
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSupply));
            this.txt_supply_id = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_supply_name = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_direccion_supply = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_telefono_supply = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_email_supply = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label15 = new System.Windows.Forms.Label();
            this.LABEL_CONTADOR_REGISTRO = new System.Windows.Forms.Label();
            this.CHK_ANULADO = new System.Windows.Forms.CheckBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.BOT_PRIMERO = new System.Windows.Forms.ToolStripButton();
            this.BOT_ANTERIOR = new System.Windows.Forms.ToolStripButton();
            this.BOT_SIGUIENTE = new System.Windows.Forms.ToolStripButton();
            this.BOT_ULTIMO = new System.Windows.Forms.ToolStripButton();
            this.BOT_NUEVO = new System.Windows.Forms.ToolStripButton();
            this.BOT_CANCEL = new System.Windows.Forms.ToolStripButton();
            this.BOT_GRABAR = new System.Windows.Forms.ToolStripButton();
            this.BOT_UPDATE = new System.Windows.Forms.ToolStripButton();
            this.BOT_BUSCAR = new System.Windows.Forms.ToolStripButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.RAD_UNID2 = new System.Windows.Forms.RadioButton();
            this.RAD_UNID1 = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_supply_id
            // 
            this.txt_supply_id.Location = new System.Drawing.Point(28, 153);
            this.txt_supply_id.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_supply_id.Name = "txt_supply_id";
            this.txt_supply_id.ReadOnly = true;
            this.txt_supply_id.Size = new System.Drawing.Size(100, 22);
            this.txt_supply_id.TabIndex = 0;
            this.txt_supply_id.Validating += new System.ComponentModel.CancelEventHandler(this.Txt_supply_id_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(28, 129);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "PROVEEDOR ID:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(28, 183);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(158, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "PROVEEDOR NAME:";
            // 
            // txt_supply_name
            // 
            this.txt_supply_name.Location = new System.Drawing.Point(31, 203);
            this.txt_supply_name.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_supply_name.Name = "txt_supply_name";
            this.txt_supply_name.ReadOnly = true;
            this.txt_supply_name.Size = new System.Drawing.Size(313, 22);
            this.txt_supply_name.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(28, 239);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Direccion:";
            // 
            // txt_direccion_supply
            // 
            this.txt_direccion_supply.Location = new System.Drawing.Point(28, 261);
            this.txt_direccion_supply.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_direccion_supply.Name = "txt_direccion_supply";
            this.txt_direccion_supply.ReadOnly = true;
            this.txt_direccion_supply.Size = new System.Drawing.Size(537, 22);
            this.txt_direccion_supply.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(28, 290);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Telefono :";
            // 
            // txt_telefono_supply
            // 
            this.txt_telefono_supply.Location = new System.Drawing.Point(28, 314);
            this.txt_telefono_supply.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_telefono_supply.Name = "txt_telefono_supply";
            this.txt_telefono_supply.ReadOnly = true;
            this.txt_telefono_supply.Size = new System.Drawing.Size(216, 22);
            this.txt_telefono_supply.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(28, 343);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(145, 17);
            this.label5.TabIndex = 9;
            this.label5.Text = "correo electronico:";
            // 
            // txt_email_supply
            // 
            this.txt_email_supply.Location = new System.Drawing.Point(28, 367);
            this.txt_email_supply.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_email_supply.Name = "txt_email_supply";
            this.txt_email_supply.ReadOnly = true;
            this.txt_email_supply.Size = new System.Drawing.Size(216, 22);
            this.txt_email_supply.TabIndex = 4;
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
            this.panel1.Size = new System.Drawing.Size(876, 80);
            this.panel1.TabIndex = 36;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(319, 26);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(207, 29);
            this.label15.TabIndex = 0;
            this.label15.Text = "PROVEEDORES";
            // 
            // LABEL_CONTADOR_REGISTRO
            // 
            this.LABEL_CONTADOR_REGISTRO.AutoSize = true;
            this.LABEL_CONTADOR_REGISTRO.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LABEL_CONTADOR_REGISTRO.Location = new System.Drawing.Point(34, 48);
            this.LABEL_CONTADOR_REGISTRO.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LABEL_CONTADOR_REGISTRO.Name = "LABEL_CONTADOR_REGISTRO";
            this.LABEL_CONTADOR_REGISTRO.Size = new System.Drawing.Size(128, 17);
            this.LABEL_CONTADOR_REGISTRO.TabIndex = 0;
            this.LABEL_CONTADOR_REGISTRO.Text = "0 de 0 Registros";
            // 
            // CHK_ANULADO
            // 
            this.CHK_ANULADO.AutoSize = true;
            this.CHK_ANULADO.Enabled = false;
            this.CHK_ANULADO.Location = new System.Drawing.Point(557, 129);
            this.CHK_ANULADO.Margin = new System.Windows.Forms.Padding(4);
            this.CHK_ANULADO.Name = "CHK_ANULADO";
            this.CHK_ANULADO.Size = new System.Drawing.Size(197, 21);
            this.CHK_ANULADO.TabIndex = 5;
            this.CHK_ANULADO.Text = "Desactivar este proveedor";
            this.CHK_ANULADO.UseVisualStyleBackColor = true;
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
            this.BOT_GRABAR,
            this.BOT_UPDATE,
            this.BOT_BUSCAR});
            this.toolStrip1.Location = new System.Drawing.Point(0, 80);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(876, 28);
            this.toolStrip1.TabIndex = 6;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // BOT_PRIMERO
            // 
            this.BOT_PRIMERO.AutoSize = false;
            this.BOT_PRIMERO.Image = ((System.Drawing.Image)(resources.GetObject("BOT_PRIMERO.Image")));
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
            this.BOT_CANCEL.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BOT_CANCEL.Name = "BOT_CANCEL";
            this.BOT_CANCEL.Size = new System.Drawing.Size(80, 25);
            this.BOT_CANCEL.Text = "Cancel";
            this.BOT_CANCEL.Click += new System.EventHandler(this.BOT_CANCEL_Click);
            // 
            // BOT_GRABAR
            // 
            this.BOT_GRABAR.AutoSize = false;
            this.BOT_GRABAR.Enabled = false;
            this.BOT_GRABAR.Image = ((System.Drawing.Image)(resources.GetObject("BOT_GRABAR.Image")));
            this.BOT_GRABAR.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BOT_GRABAR.Name = "BOT_GRABAR";
            this.BOT_GRABAR.Size = new System.Drawing.Size(80, 25);
            this.BOT_GRABAR.Text = "Grabar";
            this.BOT_GRABAR.Click += new System.EventHandler(this.BOT_GRABAR_Click);
            // 
            // BOT_UPDATE
            // 
            this.BOT_UPDATE.AutoSize = false;
            this.BOT_UPDATE.Image = ((System.Drawing.Image)(resources.GetObject("BOT_UPDATE.Image")));
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
            this.BOT_BUSCAR.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BOT_BUSCAR.Name = "BOT_BUSCAR";
            this.BOT_BUSCAR.Size = new System.Drawing.Size(80, 25);
            this.BOT_BUSCAR.Text = "Buscar";
            this.BOT_BUSCAR.Click += new System.EventHandler(this.BOT_BUSCAR_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.LABEL_CONTADOR_REGISTRO);
            this.groupBox1.Location = new System.Drawing.Point(554, 394);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 100);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Contador de Registro";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.RAD_UNID2);
            this.groupBox2.Controls.Add(this.RAD_UNID1);
            this.groupBox2.Location = new System.Drawing.Point(557, 288);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 100);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Unidad Recepcion: Master";
            // 
            // RAD_UNID2
            // 
            this.RAD_UNID2.AutoSize = true;
            this.RAD_UNID2.Enabled = false;
            this.RAD_UNID2.Location = new System.Drawing.Point(19, 63);
            this.RAD_UNID2.Name = "RAD_UNID2";
            this.RAD_UNID2.Size = new System.Drawing.Size(126, 21);
            this.RAD_UNID2.TabIndex = 1;
            this.RAD_UNID2.TabStop = true;
            this.RAD_UNID2.Text = "W:(Mts) L:(Mts)";
            this.RAD_UNID2.UseVisualStyleBackColor = true;
            // 
            // RAD_UNID1
            // 
            this.RAD_UNID1.AutoSize = true;
            this.RAD_UNID1.Enabled = false;
            this.RAD_UNID1.Location = new System.Drawing.Point(19, 36);
            this.RAD_UNID1.Name = "RAD_UNID1";
            this.RAD_UNID1.Size = new System.Drawing.Size(135, 21);
            this.RAD_UNID1.TabIndex = 0;
            this.RAD_UNID1.TabStop = true;
            this.RAD_UNID1.Text = "W:(Inch) L:(Pies)";
            this.RAD_UNID1.UseVisualStyleBackColor = true;
            // 
            // FrmSupply
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(876, 618);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.CHK_ANULADO);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt_email_supply);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_telefono_supply);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_direccion_supply);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_supply_name);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_supply_id);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FrmSupply";
            this.Text = "FrmSupply";
            this.Load += new System.EventHandler(this.FrmSupply_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_supply_id;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_supply_name;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_direccion_supply;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_telefono_supply;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_email_supply;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label LABEL_CONTADOR_REGISTRO;
        private System.Windows.Forms.CheckBox CHK_ANULADO;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton BOT_BUSCAR;
        private System.Windows.Forms.ToolStripButton BOT_ANTERIOR;
        private System.Windows.Forms.ToolStripButton BOT_SIGUIENTE;
        private System.Windows.Forms.ToolStripButton BOT_UPDATE;
        private System.Windows.Forms.ToolStripButton BOT_PRIMERO;
        private System.Windows.Forms.ToolStripButton BOT_ULTIMO;
        private System.Windows.Forms.ToolStripButton BOT_NUEVO;
        private System.Windows.Forms.ToolStripButton BOT_GRABAR;
        private System.Windows.Forms.ToolStripButton BOT_CANCEL;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton RAD_UNID2;
        private System.Windows.Forms.RadioButton RAD_UNID1;
    }
}