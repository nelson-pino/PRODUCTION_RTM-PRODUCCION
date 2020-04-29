namespace RitramaAPP.form
{
    partial class FrmGetOneValue
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
            this.txt_value = new System.Windows.Forms.TextBox();
            this.bot_process = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Introduzca Valor:";
            // 
            // txt_value
            // 
            this.txt_value.Location = new System.Drawing.Point(7, 19);
            this.txt_value.Name = "txt_value";
            this.txt_value.Size = new System.Drawing.Size(104, 20);
            this.txt_value.TabIndex = 1;
            // 
            // bot_process
            // 
            this.bot_process.Location = new System.Drawing.Point(117, 17);
            this.bot_process.Name = "bot_process";
            this.bot_process.Size = new System.Drawing.Size(75, 23);
            this.bot_process.TabIndex = 2;
            this.bot_process.Text = "Procesar";
            this.bot_process.UseVisualStyleBackColor = true;
            this.bot_process.Click += new System.EventHandler(this.Bot_process_Click);
            // 
            // FrmGetOneValue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(196, 57);
            this.Controls.Add(this.bot_process);
            this.Controls.Add(this.txt_value);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmGetOneValue";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dialogo:";
            this.Load += new System.EventHandler(this.FrmGetOneValue_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_value;
        private System.Windows.Forms.Button bot_process;
    }
}