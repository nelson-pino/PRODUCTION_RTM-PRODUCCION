using System;
using System.Windows.Forms;
using RitramaAPP.Clases;

namespace RitramaAPP.form
{
    public partial class FrmSaveOc : Form
    {
        public FrmSaveOc()
        {
            InitializeComponent();
        }
        readonly ProduccionManager manager = new ProduccionManager();
        public string NumeroOC { get; set; }
        private void FrmSaveOc_Load(object sender, EventArgs e)
        {
            TXT_FECHA.Text = DateTime.Now.ToString();
        }

        private void Bot_save_Click(object sender, EventArgs e)
        {
            SaveData();
        }
        private void SaveData() 
        {
            AutorizeDocOc doc = new AutorizeDocOc
            {
                Oc = NumeroOC,
                Fecha = Convert.ToDateTime(TXT_FECHA.Text),
                ToAutorize = TXT_AUTORIZE.Text,
                Notes = TXT_NOTES.Text,
                CloseDocument = chk_DocumentReady.Checked
            };
            this.Close();
            manager.SaveAutorizeOc(doc);
        }
    }
}
