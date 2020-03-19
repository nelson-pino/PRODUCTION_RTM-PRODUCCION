namespace RitramaAPP.form
{
    partial class FrmReservas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmReservas));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.TXT_ORDEN_TRA = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TXT_ORDEN_SER = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.BOT_GUARDAR = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.TXT_FECHA_ENTREGA = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.TXT_CUSTOMER = new System.Windows.Forms.TextBox();
            this.BOT_SEARCH_CUSTOM = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.TXT_COMMENTARY = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.TXT_TRANSACC = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.TXT_FECHA_RESERVA = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.TXT_IDCUST = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(193)))), ((int)(((byte)(233)))));
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(359, 100);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(141, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "R E S E R V A ";
            // 
            // TXT_ORDEN_TRA
            // 
            this.TXT_ORDEN_TRA.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXT_ORDEN_TRA.Location = new System.Drawing.Point(12, 125);
            this.TXT_ORDEN_TRA.Name = "TXT_ORDEN_TRA";
            this.TXT_ORDEN_TRA.Size = new System.Drawing.Size(118, 20);
            this.TXT_ORDEN_TRA.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Orden Trabajo";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 151);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Orden Servicio";
            // 
            // TXT_ORDEN_SER
            // 
            this.TXT_ORDEN_SER.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXT_ORDEN_SER.Location = new System.Drawing.Point(12, 167);
            this.TXT_ORDEN_SER.Name = "TXT_ORDEN_SER";
            this.TXT_ORDEN_SER.Size = new System.Drawing.Size(118, 20);
            this.TXT_ORDEN_SER.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 191);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Fecha de Reserva :";
            // 
            // BOT_GUARDAR
            // 
            this.BOT_GUARDAR.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(155)))), ((int)(((byte)(32)))));
            this.BOT_GUARDAR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BOT_GUARDAR.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BOT_GUARDAR.ForeColor = System.Drawing.Color.White;
            this.BOT_GUARDAR.Image = ((System.Drawing.Image)(resources.GetObject("BOT_GUARDAR.Image")));
            this.BOT_GUARDAR.Location = new System.Drawing.Point(92, 415);
            this.BOT_GUARDAR.Name = "BOT_GUARDAR";
            this.BOT_GUARDAR.Size = new System.Drawing.Size(174, 57);
            this.BOT_GUARDAR.TabIndex = 7;
            this.BOT_GUARDAR.Text = "  Guardar";
            this.BOT_GUARDAR.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BOT_GUARDAR.UseVisualStyleBackColor = false;
            this.BOT_GUARDAR.Click += new System.EventHandler(this.BOT_GUARDAR_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 234);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Fecha Entrega :";
            // 
            // TXT_FECHA_ENTREGA
            // 
            this.TXT_FECHA_ENTREGA.Location = new System.Drawing.Point(12, 250);
            this.TXT_FECHA_ENTREGA.Name = "TXT_FECHA_ENTREGA";
            this.TXT_FECHA_ENTREGA.Size = new System.Drawing.Size(224, 20);
            this.TXT_FECHA_ENTREGA.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 280);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Nombre del Cliente";
            // 
            // TXT_CUSTOMER
            // 
            this.TXT_CUSTOMER.BackColor = System.Drawing.Color.White;
            this.TXT_CUSTOMER.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXT_CUSTOMER.Location = new System.Drawing.Point(12, 296);
            this.TXT_CUSTOMER.Name = "TXT_CUSTOMER";
            this.TXT_CUSTOMER.ReadOnly = true;
            this.TXT_CUSTOMER.Size = new System.Drawing.Size(254, 20);
            this.TXT_CUSTOMER.TabIndex = 10;
            // 
            // BOT_SEARCH_CUSTOM
            // 
            this.BOT_SEARCH_CUSTOM.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BOT_SEARCH_CUSTOM.Image = ((System.Drawing.Image)(resources.GetObject("BOT_SEARCH_CUSTOM.Image")));
            this.BOT_SEARCH_CUSTOM.Location = new System.Drawing.Point(272, 293);
            this.BOT_SEARCH_CUSTOM.Name = "BOT_SEARCH_CUSTOM";
            this.BOT_SEARCH_CUSTOM.Size = new System.Drawing.Size(75, 26);
            this.BOT_SEARCH_CUSTOM.TabIndex = 12;
            this.BOT_SEARCH_CUSTOM.Text = "Buscar";
            this.BOT_SEARCH_CUSTOM.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BOT_SEARCH_CUSTOM.UseVisualStyleBackColor = true;
            this.BOT_SEARCH_CUSTOM.Click += new System.EventHandler(this.BOT_SEARCH_CUSTOM_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 325);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Comentario :";
            // 
            // TXT_COMMENTARY
            // 
            this.TXT_COMMENTARY.Location = new System.Drawing.Point(12, 341);
            this.TXT_COMMENTARY.Multiline = true;
            this.TXT_COMMENTARY.Name = "TXT_COMMENTARY";
            this.TXT_COMMENTARY.Size = new System.Drawing.Size(335, 68);
            this.TXT_COMMENTARY.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(226, 109);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Transacción";
            // 
            // TXT_TRANSACC
            // 
            this.TXT_TRANSACC.BackColor = System.Drawing.Color.White;
            this.TXT_TRANSACC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXT_TRANSACC.Location = new System.Drawing.Point(229, 125);
            this.TXT_TRANSACC.Name = "TXT_TRANSACC";
            this.TXT_TRANSACC.ReadOnly = true;
            this.TXT_TRANSACC.Size = new System.Drawing.Size(118, 20);
            this.TXT_TRANSACC.TabIndex = 15;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 100);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // TXT_FECHA_RESERVA
            // 
            this.TXT_FECHA_RESERVA.BackColor = System.Drawing.Color.White;
            this.TXT_FECHA_RESERVA.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXT_FECHA_RESERVA.Location = new System.Drawing.Point(12, 207);
            this.TXT_FECHA_RESERVA.Name = "TXT_FECHA_RESERVA";
            this.TXT_FECHA_RESERVA.ReadOnly = true;
            this.TXT_FECHA_RESERVA.Size = new System.Drawing.Size(224, 20);
            this.TXT_FECHA_RESERVA.TabIndex = 17;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(269, 237);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 13);
            this.label9.TabIndex = 19;
            this.label9.Text = "Id. Cliente:";
            // 
            // TXT_IDCUST
            // 
            this.TXT_IDCUST.BackColor = System.Drawing.Color.White;
            this.TXT_IDCUST.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXT_IDCUST.Location = new System.Drawing.Point(272, 253);
            this.TXT_IDCUST.Name = "TXT_IDCUST";
            this.TXT_IDCUST.ReadOnly = true;
            this.TXT_IDCUST.Size = new System.Drawing.Size(75, 20);
            this.TXT_IDCUST.TabIndex = 18;
            // 
            // FrmReservas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(359, 484);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.TXT_IDCUST);
            this.Controls.Add(this.TXT_FECHA_RESERVA);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.TXT_TRANSACC);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.TXT_COMMENTARY);
            this.Controls.Add(this.BOT_SEARCH_CUSTOM);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.TXT_CUSTOMER);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.TXT_FECHA_ENTREGA);
            this.Controls.Add(this.BOT_GUARDAR);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TXT_ORDEN_SER);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TXT_ORDEN_TRA);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmReservas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "                                                                                 " +
    "                                                                                " +
    "                  ";
            this.Load += new System.EventHandler(this.FrmReservas_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TXT_ORDEN_TRA;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TXT_ORDEN_SER;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button BOT_GUARDAR;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker TXT_FECHA_ENTREGA;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TXT_CUSTOMER;
        private System.Windows.Forms.Button BOT_SEARCH_CUSTOM;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox TXT_COMMENTARY;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox TXT_TRANSACC;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox TXT_FECHA_RESERVA;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox TXT_IDCUST;
    }
}