using RitramaAPP.Clases;
using System;
using System.Windows.Forms;

namespace RitramaAPP
{
    public partial class FrmParameters : Form
    {
        public FrmParameters()
        {
            InitializeComponent();
        }
        ConfigManager manager = new ConfigManager();

        private void FrmParameters_Load(object sender, EventArgs e)
        {
            txt_param1.Text = manager.GetParameterControl("COC");
            txt_param2.Text = manager.GetParameterControl("UC");
            TXT_N2P1.Text = manager.GetParameterControl("MSI");
            TXT_N2P2.Text = manager.GetParameterControl("FMPUL");
            TXT_N2P3.Text = manager.GetParameterControl("FMPIE");
            TXT_N3P1.Text = manager.GetParameterControl("LSR");
            txt_param7.Text = manager.GetParameterControl("CONSEC_DP");
        }
    }
}
