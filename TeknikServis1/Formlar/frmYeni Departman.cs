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
    public partial class frmYeni_Departman : Form
    {
        public frmYeni_Departman()
        {
            InitializeComponent();
        }
        DbTeknikServısEntities db = new DbTeknikServısEntities();
        private void btnVazgec_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                TBLDEPARTMAN t = new TBLDEPARTMAN();
                t.AD = txtAd.Text;
                t.ACIKLAMA = txtacıklama.Text;
                t.durum = true;
                db.TBLDEPARTMAN.Add(t);
                db.SaveChanges();
                MessageBox.Show("Departman Kaydedilmiştir.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Departman Kaydedilemedi !!!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
