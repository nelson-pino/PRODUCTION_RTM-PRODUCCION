namespace RitramaAPP.form
{
    partial class FrmUbicacionesAlmacen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUbicacionesAlmacen));
            this.GridUbicaciones = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.bot_read = new System.Windows.Forms.Button();
            this.bot_ubicar = new System.Windows.Forms.Button();
            this.LABEL_TOTAL_REGISTROS = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.txt_ubicacion = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.LABEL_REG_RECHAZADOS = new System.Windows.Forms.Label();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.GridUbicaciones)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // GridUbicaciones
            // 
            this.GridUbicaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridUbicaciones.Location = new System.Drawing.Point(12, 151);
            this.GridUbicaciones.Name = "GridUbicaciones";
            this.GridUbicaciones.Size = new System.Drawing.Size(457, 287);
            this.GridUbicaciones.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(1, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(593, 100);
            this.panel1.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(32, 22);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(52, 52);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(111, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(447, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "UBICACIONES DE PRODUCTOS EN EL ALMACEN";
            // 
            // bot_read
            // 
            this.bot_read.Image = ((System.Drawing.Image)(resources.GetObject("bot_read.Image")));
            this.bot_read.Location = new System.Drawing.Point(475, 151);
            this.bot_read.Name = "bot_read";
            this.bot_read.Size = new System.Drawing.Size(115, 63);
            this.bot_read.TabIndex = 2;
            this.bot_read.Text = "Leer Data";
            this.bot_read.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bot_read.UseVisualStyleBackColor = true;
            this.bot_read.Click += new System.EventHandler(this.Bot_read_Click);
            // 
            // bot_ubicar
            // 
            this.bot_ubicar.Image = ((System.Drawing.Image)(resources.GetObject("bot_ubicar.Image")));
            this.bot_ubicar.Location = new System.Drawing.Point(475, 220);
            this.bot_ubicar.Name = "bot_ubicar";
            this.bot_ubicar.Size = new System.Drawing.Size(115, 63);
            this.bot_ubicar.TabIndex = 3;
            this.bot_ubicar.Text = "Reubicar";
            this.bot_ubicar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bot_ubicar.UseVisualStyleBackColor = true;
            this.bot_ubicar.Click += new System.EventHandler(this.Bot_ubicar_Click);
            // 
            // LABEL_TOTAL_REGISTROS
            // 
            this.LABEL_TOTAL_REGISTROS.AutoSize = true;
            this.LABEL_TOTAL_REGISTROS.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LABEL_TOTAL_REGISTROS.Location = new System.Drawing.Point(12, 483);
            this.LABEL_TOTAL_REGISTROS.Name = "LABEL_TOTAL_REGISTROS";
            this.LABEL_TOTAL_REGISTROS.Size = new System.Drawing.Size(142, 13);
            this.LABEL_TOTAL_REGISTROS.TabIndex = 1;
            this.LABEL_TOTAL_REGISTROS.Text = "TOTAL REGISTROS : 0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(178, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "ESTABLECER A LA UBUICACION :";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // txt_ubicacion
            // 
            this.txt_ubicacion.Location = new System.Drawing.Point(196, 114);
            this.txt_ubicacion.Name = "txt_ubicacion";
            this.txt_ubicacion.Size = new System.Drawing.Size(100, 20);
            this.txt_ubicacion.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(193, 457);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(269, 65);
            this.label4.TabIndex = 7;
            this.label4.Text = "Debe tener una lista de productos identificados por Codigos Unicos almacenados de" +
    "sde un Chipherlab\r\n\r\n";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LABEL_REG_RECHAZADOS
            // 
            this.LABEL_REG_RECHAZADOS.AutoSize = true;
            this.LABEL_REG_RECHAZADOS.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LABEL_REG_RECHAZADOS.Location = new System.Drawing.Point(12, 496);
            this.LABEL_REG_RECHAZADOS.Name = "LABEL_REG_RECHAZADOS";
            this.LABEL_REG_RECHAZADOS.Size = new System.Drawing.Size(110, 13);
            this.LABEL_REG_RECHAZADOS.TabIndex = 8;
            this.LABEL_REG_RECHAZADOS.Text = "RECHAZADOS : 0";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(474, 380);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(89, 17);
            this.radioButton1.TabIndex = 9;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Rollo Cortado";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(474, 395);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(67, 17);
            this.radioButton2.TabIndex = 10;
            this.radioButton2.Text = "Graphics";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(474, 410);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(52, 17);
            this.radioButton3.TabIndex = 11;
            this.radioButton3.Text = "Hojas";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(474, 425);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(57, 17);
            this.radioButton4.TabIndex = 12;
            this.radioButton4.Text = "Master";
            this.radioButton4.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(476, 361);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Tipo de Producto:";
            // 
            // FrmUbicacionesAlmacen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(595, 531);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.radioButton4);
            this.Controls.Add(this.radioButton3);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.LABEL_REG_RECHAZADOS);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_ubicacion);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.LABEL_TOTAL_REGISTROS);
            this.Controls.Add(this.bot_ubicar);
            this.Controls.Add(this.bot_read);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.GridUbicaciones);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmUbicacionesAlmacen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ubicaciones";
            this.Load += new System.EventHandler(this.FrmUbicacionesAlmacen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GridUbicaciones)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView GridUbicaciones;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bot_read;
        private System.Windows.Forms.Button bot_ubicar;
        private System.Windows.Forms.Label LABEL_TOTAL_REGISTROS;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.TextBox txt_ubicacion;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label LABEL_REG_RECHAZADOS;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.Label label2;
    }
}