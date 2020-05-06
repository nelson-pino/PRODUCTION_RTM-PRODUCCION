namespace RitramaAPP.form
{
    partial class FrmSaveOc
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TXT_FECHA = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TXT_AUTORIZE = new System.Windows.Forms.TextBox();
            this.TXT_NOTES = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.chk_DocumentReady = new System.Windows.Forms.CheckBox();
            this.bot_save = new System.Windows.Forms.Button();
            this.TXT_ODEN_TRABAJO = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TXT_ORDEN_SERVICIO = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(317, 100);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(305, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Aprobacion de Orden de Corte:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Fecha de Aprobación:";
            // 
            // TXT_FECHA
            // 
            this.TXT_FECHA.Enabled = false;
            this.TXT_FECHA.Location = new System.Drawing.Point(14, 124);
            this.TXT_FECHA.Name = "TXT_FECHA";
            this.TXT_FECHA.ReadOnly = true;
            this.TXT_FECHA.Size = new System.Drawing.Size(156, 20);
            this.TXT_FECHA.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 156);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Nombre Persona Autoriza :";
            // 
            // TXT_AUTORIZE
            // 
            this.TXT_AUTORIZE.Location = new System.Drawing.Point(14, 172);
            this.TXT_AUTORIZE.Name = "TXT_AUTORIZE";
            this.TXT_AUTORIZE.Size = new System.Drawing.Size(156, 20);
            this.TXT_AUTORIZE.TabIndex = 4;
            // 
            // TXT_NOTES
            // 
            this.TXT_NOTES.Location = new System.Drawing.Point(15, 215);
            this.TXT_NOTES.Multiline = true;
            this.TXT_NOTES.Name = "TXT_NOTES";
            this.TXT_NOTES.Size = new System.Drawing.Size(293, 124);
            this.TXT_NOTES.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 199);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(157, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Observaciones del documento :";
            // 
            // chk_DocumentReady
            // 
            this.chk_DocumentReady.AutoSize = true;
            this.chk_DocumentReady.Location = new System.Drawing.Point(166, 345);
            this.chk_DocumentReady.Name = "chk_DocumentReady";
            this.chk_DocumentReady.Size = new System.Drawing.Size(112, 17);
            this.chk_DocumentReady.TabIndex = 7;
            this.chk_DocumentReady.Text = "Cerrar Documento";
            this.chk_DocumentReady.UseVisualStyleBackColor = true;
            // 
            // bot_save
            // 
            this.bot_save.Location = new System.Drawing.Point(12, 345);
            this.bot_save.Name = "bot_save";
            this.bot_save.Size = new System.Drawing.Size(75, 23);
            this.bot_save.TabIndex = 8;
            this.bot_save.Text = "Guardar";
            this.bot_save.UseVisualStyleBackColor = true;
            this.bot_save.Click += new System.EventHandler(this.Bot_save_Click);
            // 
            // TXT_ODEN_TRABAJO
            // 
            this.TXT_ODEN_TRABAJO.Location = new System.Drawing.Point(176, 124);
            this.TXT_ODEN_TRABAJO.Name = "TXT_ODEN_TRABAJO";
            this.TXT_ODEN_TRABAJO.Size = new System.Drawing.Size(131, 20);
            this.TXT_ODEN_TRABAJO.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(174, 108);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "No. Orden Tabajo :";
            // 
            // TXT_ORDEN_SERVICIO
            // 
            this.TXT_ORDEN_SERVICIO.Location = new System.Drawing.Point(176, 172);
            this.TXT_ORDEN_SERVICIO.Name = "TXT_ORDEN_SERVICIO";
            this.TXT_ORDEN_SERVICIO.Size = new System.Drawing.Size(131, 20);
            this.TXT_ORDEN_SERVICIO.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(174, 156);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(103, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "No. Orden Servicio :";
            // 
            // FrmSaveOc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(319, 380);
            this.Controls.Add(this.TXT_ORDEN_SERVICIO);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.TXT_ODEN_TRABAJO);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.bot_save);
            this.Controls.Add(this.chk_DocumentReady);
            this.Controls.Add(this.TXT_NOTES);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TXT_AUTORIZE);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TXT_FECHA);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Name = "FrmSaveOc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Aprobar Documento:";
            this.Load += new System.EventHandler(this.FrmSaveOc_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TXT_FECHA;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TXT_AUTORIZE;
        private System.Windows.Forms.TextBox TXT_NOTES;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chk_DocumentReady;
        private System.Windows.Forms.Button bot_save;
        private System.Windows.Forms.TextBox TXT_ODEN_TRABAJO;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TXT_ORDEN_SERVICIO;
        private System.Windows.Forms.Label label6;
    }
}