using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RitramaAPP.form
{
    public partial class FrmGetOneValue : Form
    {
        public string Title_form { get; set; }
        public string Title_Textbox { get; set; }
        public string  DataValue { get; set; }

        public FrmGetOneValue()
        {
            InitializeComponent();
        }

        private void FrmGetOneValue_Load(object sender, EventArgs e)
        {
            this.Text = Title_form;
            label1.Text = Title_Textbox;
        }

        private void Bot_process_Click(object sender, EventArgs e)
        {
            this.DataValue = txt_value.Text.Trim();
            this.Close();
        }
    }
}
