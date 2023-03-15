using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeknikServis1.Formlar
{
    public partial class FrmArizaDetay : Form
    {
        public FrmArizaDetay()
        {
            InitializeComponent();
        }

        private void btnvazgec_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        DbTeknikServısEntities db = new DbTeknikServısEntities();
        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            TBLURUNTAKIP t = new TBLURUNTAKIP();
            t.ACIKLAMA = richTextBox1.Text;
            t.SERINO = txtserino.Text;
            t.TARİH = DateTime.Parse(txttarih.Text);
            db.TBLURUNTAKIP.Add(t);
            db.SaveChanges();
            MessageBox.Show("Ürün Arıza Detayları Güncellenmiştir","BİLGİ",MessageBoxButtons.OK,MessageBoxIcon.Information);
            this.Hide();
        }
    }
}
