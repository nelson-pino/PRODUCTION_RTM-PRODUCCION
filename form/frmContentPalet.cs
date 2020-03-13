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
    public partial class frmContentPalet : Form
    {
        public frmContentPalet()
        {
            InitializeComponent();
        }
        public string ContentText { get; set; }
        private void frmContentPalet_Load(object sender, EventArgs e)
        {
            Txt_ContentPage.Text = ContentText;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            ContentText = Txt_ContentPage.Text;
            this.Close();
        }

       
    }
}
